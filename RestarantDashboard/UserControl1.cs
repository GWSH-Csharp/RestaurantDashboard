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
            timerRefreshOrdersList.Interval = 15000;
            timerRefreshOrdersList.Tick += TimerRefreshOrdersList_Tick;
            timerRefreshOrdersList.Start();
            activeOrdersList.DrawMode = DrawMode.OwnerDrawFixed;
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

        private void RefreshList()
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

            List<string> rows = ReadEntries();

            activeOrdersList.Items.Clear();
            activeOrdersList.Items.AddRange(rows.ToArray());
        }

        private void activeOrdersList_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0)
            {
                string text = activeOrdersList.Items[e.Index].ToString();
                bool isChecked = activeOrdersList.GetItemChecked(e.Index);
                Rectangle checkboxRect = new Rectangle(e.Bounds.X + 3, e.Bounds.Y + 3, 14, 14);
                ControlPaint.DrawCheckBox(e.Graphics, checkboxRect, isChecked ? ButtonState.Checked : ButtonState.Normal);
                using (SolidBrush brush = new SolidBrush(e.ForeColor))
                {
                    Rectangle textRect = new Rectangle(e.Bounds.X + checkboxRect.Width + 6, e.Bounds.Y, e.Bounds.Width - checkboxRect.Width - 6, e.Bounds.Height);
                    e.Graphics.DrawString(text, e.Font, brush, textRect);
                }
            }

            e.DrawFocusRectangle();
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
    }
}
