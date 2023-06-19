using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using static RestaurantDashboardDRoom.Program;

namespace RestaurantDashboardDRoom
{
    public partial class Form1 : Form
    {
        // Global variables
        static DateTime date_now = DateTime.Now;
        static SheetsService service;
        string sheetTitle;
        static string SpreadsheetId = "1LTfSmD9ew3rT23FL7Ffw2t92mJlhG-Ept-AR0QE0_1U";

        public Form1()
        {

            InitializeComponent();

            // Google api new instance, starting connection
            string[] Scopes = { SheetsService.Scope.Spreadsheets };
            string ApplicationName = "ApplicationName";
            GoogleCredential credential;

            /* ---  Access json file path  --- */
            using (var stream = new FileStream("restaurantdashboard-384320-b3d9c1d86d17.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }
            service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public class apiSheetsRead
        {
            DataGridView dataGridView1 = new DataGridView();

            // Google Api Spreadsheet global variables
            static string SpreadsheetId = "1LTfSmD9ew3rT23FL7Ffw2t92mJlhG-Ept-AR0QE0_1U";
            internal static Order order { get; set; }
            string sheetTitle = DateTime.Now.ToString("dd/MM/yyyy");
            public void clearBeforeYouGoAndAddHeaders(DataGridView dataGridView1)
            {
                // Clear the datagridview before you add the new data
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("TIME", "TIME");
                dataGridView1.Columns.Add("TABLE", "TABLE");
                dataGridView1.Columns.Add("ORDER_MENU", "ORDER_MENU");
                dataGridView1.Columns.Add("BILL", "BILL");
                dataGridView1.Columns.Add("STAFF", "STAFF");
                dataGridView1.Columns.Add("STATUS", "STATUS");
                dataGridView1.Columns["ORDER_MENU"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dataGridView1.Columns["ID"].Width = 30;
                dataGridView1.Columns["TIME"].Width = 50;
                dataGridView1.Columns["TABLE"].Width = 60;
                dataGridView1.Columns["ORDER_MENU"].Width = 300;
                dataGridView1.Columns["BILL"].Width = 50;
                dataGridView1.Columns["STAFF"].Width = 80;
                dataGridView1.Columns["STATUS"].Width = 80;
            }

            public void readEntries(string sheet, DataGridView dataGridView1, bool popUpWarn)
            {

                var range = $"{sheet}!A:Z";
                var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
                var response = request.Execute();
                var values = response.Values;

                // Create the order ID counter and assign the values according to the spreadsheet
                if (order != null)
                {
                    if (values != null && values.Count > 0)
                    {
                        order.ID = values.Count;
                    }
                    else
                    {
                        order.ID = 0;
                    }
                }


                void addTheRowsAfterHeaders()
                {

                    // Add the rows from the spreadsheet to the datagridview
                    if (values != null && values.Count > 0)
                    {
                        for (int i = 0; i < values.Count; i++)
                        {
                            var row = values[i];
                            dataGridView1.Rows.Add(row.ToArray());
                        }
                    }
                    else if (popUpWarn == true)
                    {
                        MessageBox.Show("No data found");
                    }


                }

                clearBeforeYouGoAndAddHeaders(dataGridView1);
                addTheRowsAfterHeaders();
            }

            public void createEntries(string sheet)
            {
                // Order objects to string
                string orderStringMenu = "";
                // Order.OrderDate only with hours and minutes
                string orderDateHHmmToString = order.OrderDate.ToString("HH:mm");

                // Order.tableID to string
                string orderTableIDToString = order.TableID.ToString();

                // Creating a string from the order object
                void getOrderMenuAndMakeItString()
                {
                    foreach (var item in order.OrderMenu)
                    {
                        orderStringMenu += $"- {item.Nazwa} ({item.Cena} z³)\n";
                    }
                }
                getOrderMenuAndMakeItString();

                // Access to the google sheets necessary variables
                var range = $"{sheet}!A:Z";
                var valueRange = new ValueRange();
                var objectList = new List<object>() { order.ID, orderDateHHmmToString, orderTableIDToString, orderStringMenu, $"{order.Bill} z³", $"{order.Staff.Imie} {order.Staff.Nazwisko}", order.Status };
                valueRange.Values = new List<IList<object>> { objectList };
                var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
                appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                var appendReponse = appendRequest.Execute();
            }

            public bool checkForSheet(DateTime selectedDate)
            {
                // Pick date and time and connect it with the sheet title
                sheetTitle = selectedDate.ToString("dd/MM/yyyy");
                var request = service.Spreadsheets.Get(SpreadsheetId); // Object to get data from the spreadsheet as specified by the parameters
                var response = request.Execute();
                var sheet = response.Sheets.FirstOrDefault(s => s.Properties.Title == sheetTitle);

                if (sheet != null)
                {
                    readEntries(sheetTitle, dataGridView1, false);
                    return true;
                }
                else
                {
                    // MessageBox.Show($"No data for: {sheetTitle}.");
                    return false;
                }
            }

            public void createNewDaySheet()
            {
                // Create a new sheet with the name of the current date
                var addSheetRequest = new AddSheetRequest();
                addSheetRequest.Properties = new SheetProperties();
                addSheetRequest.Properties.Title = date_now.ToString("dd/MM/yyyy");
                var addSheetRequestList = new List<Request>();
                var addSheetRequestContainer = new Request();
                addSheetRequestContainer.AddSheet = addSheetRequest;
                addSheetRequestList.Add(addSheetRequestContainer);
                var batchUpdateRequest = new BatchUpdateSpreadsheetRequest();
                batchUpdateRequest.Requests = addSheetRequestList;
                var batchUpdateResponse = service.Spreadsheets.BatchUpdate(batchUpdateRequest, SpreadsheetId);
                batchUpdateResponse.Execute();
            }
        }

        private void Timer_now_Tick(object sender, EventArgs e)
        {
            // Update the date_time_now label with the current time
            date_time_main.Text = DateTime.Now.ToString("dd/MM/yyyy\nhh:mm:ss tt ");
        }

        private void new_order_button_Click(object sender, EventArgs e)
        {

            // Create a new instance of the NewForm class
            NewForm newForm = new NewForm();

            // Show the new form
            newForm.Show();
        }

        void view_orders_api_button(object sender, EventArgs e)
        {
            sheetTitle = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            apiSheetsRead apiSheetsRead = new apiSheetsRead();
            try
            {
                apiSheetsRead.readEntries(sheetTitle, dataGridView1, true);
            }
            catch (Google.GoogleApiException ex)
            {
                apiSheetsRead.clearBeforeYouGoAndAddHeaders(dataGridView1);
                MessageBox.Show("No data found");
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            apiSheetsRead apiSheetsRead = new apiSheetsRead();
            apiSheetsRead.checkForSheet(selectedDate);
            sheetTitle = selectedDate.ToString("dd/MM/yyyy");
            string todayDateToString = DateTime.Now.ToString("dd/MM/yyyy");
            try
            {
                apiSheetsRead.readEntries(sheetTitle, dataGridView1, true);
            }
            catch (Google.GoogleApiException ex)
            {
                apiSheetsRead.clearBeforeYouGoAndAddHeaders(dataGridView1);
                MessageBox.Show("No data found");
                // Handle the exception as needed
            }

            // Disable the new order button if the sheet is not the current date
            if (sheetTitle == todayDateToString)
            {
                new_order_button.Enabled = true;
            }
            else
            {
                new_order_button.Enabled = false;
            }
        }

        private void autoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (autoRefresh.Checked)
            {
                StartAutoRefresh();
            }
            else
            {
                StopAutoRefresh();
            }
        }

        private System.Windows.Forms.Timer timer;
        private void StartAutoRefresh()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 15000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void StopAutoRefresh()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            view_orders_api_button(sender, e);
        }

        private void update_order_status_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.RowCount > 1)
            {
                string status = "DELIVERED";

                foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                {
                    int orderId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    int rowIndex = selectedRow.Index;
                    dataGridView1.Rows[rowIndex].Cells["STATUS"].Value = status;
                    UpdateOrderStatusInSheets(orderId, status);
                }
            }
            else
            {
                MessageBox.Show("No row selected");
            }

        }

        private void UpdateOrderStatusInSheets(int orderId, string status)
        {
            var range = $"{sheetTitle}!A:G";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    var row = values[i];
                    if (row.Count >= 7 && row[0] != null && int.TryParse(row[0].ToString(), out int rowOrderId) && rowOrderId == orderId)
                    {
                        row[6] = status;
                        var updateRange = $"{sheetTitle}!A{i + 1}:G{i + 1}";
                        var updateValueRange = new ValueRange();
                        updateValueRange.Values = new List<IList<object>> { row };
                        var updateRequest = service.Spreadsheets.Values.Update(updateValueRange, SpreadsheetId, updateRange);
                        updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                        var updateResponse = updateRequest.Execute();
                        break;
                    }
                }
            }
        }
    }
}