using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace RestarantDashboard
{
    public partial class ViewOrders : UserControl
    {

        List<string> rows = new List<string>();

        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "RestaurantDashboard";
        static readonly string SpreadsheetId = "1bPWpKSvywPYtiD_j1TSUMCBcb13YBg-ivaVNMiTJdjU";
        static readonly string sheet = "Released_Orders";
        static SheetsService service;

        public ViewOrders()
        {
            InitializeComponent();
            RefreshList();
            timerRefreshOrdersList.Interval = 15000;
            timerRefreshOrdersList.Tick += TimerRefreshOrdersList_Tick;
            timerRefreshOrdersList.Start();
            activeOrdersList.CheckOnClick = true;
        }

        private void TimerRefreshOrdersList_Tick(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void activeOrdersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        protected void RefreshList()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("C:\\Users\\piotr\\source\\repos\\RestarantDashboard\\Client_Secret\\restaurantdashboard-384320-d450b5056d5f.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }

            service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            rows = ReadEntries();

            var checkedItems = activeOrdersList.CheckedItems.OfType<string>().ToList();

            activeOrdersList.Items.Clear();
            activeOrdersList.Items.AddRange(rows.ToArray());

            foreach (var item in checkedItems)
            {
                int index = activeOrdersList.Items.IndexOf(item);
                if (index != -1)
                {
                    activeOrdersList.SetItemChecked(index, true);
                }
            }
        }


        static List<string> ReadEntries()
        {
            var range = $"{sheet}!A2:F";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            var values = response.Values;
            if (values != null && values.Count > 0)
            {
                List<string> rows = new List<string>();
                foreach (var row in values)
                {
                    string rowString = string.Format("{0} | {1} | {2} | {3} | {4}", row[0], row[1], row[2], row[3], row[5]);
                    rows.Add(rowString);
                }
                return rows;
            }
            else
            {
                Console.WriteLine("No data found");
                return null;
            }
        }


        private void readyToServeBtn_Click(object sender, EventArgs e)
        {
            var checkedItems = activeOrdersList.CheckedItems.OfType<string>().ToList();
            var range = $"{sheet}!A2:F";

            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;

            if (values == null || values.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            var rangeToUpdate = new List<IList<object>>();

            foreach (var checkedItem in checkedItems)
            {
                var rowIndex = rows.IndexOf(checkedItem) + 2;
                var newValue = "Yes";
                var oldValue = values[rowIndex - 2][5].ToString();

                if (oldValue != newValue)
                {
                    rangeToUpdate.Add(new List<object>() { newValue });
                }
            }

            if (rangeToUpdate.Count > 0)
            {
                var valueRange = new ValueRange { Values = rangeToUpdate };
                var updateRange = $"{sheet}!F2:F{rangeToUpdate.Count + 1}";
                var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, updateRange);
                updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                var updateResponse = updateRequest.Execute();
            }
            RefreshList();
        }








    }
}
