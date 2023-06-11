using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using static RestaurantDashboardKitchen.Program;

namespace RestaurantDashboardKitchen
{
    public partial class Form1 : Form
    {
        static DateTime date_now = DateTime.Now;
        static SheetsService service;
        private string sheetTitle = null;
        static string SpreadsheetId = "1LTfSmD9ew3rT23FL7Ffw2t92mJlhG-Ept-AR0QE0_1U";

        public Form1()
        {

            InitializeComponent();

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
            int orderIdInt;

            static string SpreadsheetId = "1LTfSmD9ew3rT23FL7Ffw2t92mJlhG-Ept-AR0QE0_1U";
            internal static Order order { get; set; }
            string sheetTitle = DateTime.Now.ToString("dd/MM/yyyy");

            public void readEntries(string sheet, DataGridView dataGridView1, bool popUpWarn)
            {
                var range = $"{sheet}!A:Z";
                var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
                var response = request.Execute();
                var values = response.Values;

                orderIdInt = dataGridView1.Rows.Count;

                void clearBeforeYouGoAndAddHeaders()
                {
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
                }

                void addTheRowsAfterHeaders()
                {
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

                clearBeforeYouGoAndAddHeaders();
                addTheRowsAfterHeaders();
            }


            public void createEntries(string sheet)
            {
                string orderStringMenu = "";

                order.ID = orderIdInt;
                string orderDateHHmmToString = order.OrderDate.ToString("HH:mm");

                string orderTableIDToString = order.TableID.ToString();

                void getOrderMenuAndMakeItString()
                {
                    foreach (var item in order.OrderMenu)
                    {
                        orderStringMenu += $"- {item.Nazwa} ({item.Cena} z³)\n";
                    }
                }
                getOrderMenuAndMakeItString();

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
                sheetTitle = selectedDate.ToString("dd/MM/yyyy");
                var request = service.Spreadsheets.Get(SpreadsheetId);
                var response = request.Execute();
                var sheet = response.Sheets.FirstOrDefault(s => s.Properties.Title == sheetTitle);

                if (sheet != null)
                {
                    readEntries(sheetTitle, dataGridView1, false);
                    return true;
                }
                else
                {
                    return false;
                }
            }


            public void createNewDaySheet()
            {
                var addSheetRequest = new AddSheetRequest();
                addSheetRequest.Properties = new SheetProperties();
                addSheetRequest.Properties.Title = sheetTitle;
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
            date_time_main.Text = DateTime.Now.ToString("dd/MM/yyyy\nhh:mm:ss tt ");
        }



        void view_orders_api_button(object sender, EventArgs e)
        {
            apiSheetsRead apiSheetsRead = new apiSheetsRead();
            try
            {
                DateTime selectedDate = dateTimePicker1.Value;
                bool sheetExists = apiSheetsRead.checkForSheet(selectedDate);

                if (sheetExists)
                {
                    apiSheetsRead.readEntries(sheetTitle, dataGridView1, true);
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    MessageBox.Show("Brak zamówieñ w wybranym dniu.");
                }
            }
            catch (Google.GoogleApiException ex)
            {
                MessageBox.Show("No data found");
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            apiSheetsRead apiSheetsRead = new apiSheetsRead();
            bool sheetExists = apiSheetsRead.checkForSheet(selectedDate);

            if (sheetExists)
            {
                sheetTitle = selectedDate.ToString("dd/MM/yyyy");
                apiSheetsRead.readEntries(sheetTitle, dataGridView1, true);
                update_order_status.Enabled = sheetTitle == DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                MessageBox.Show("Brak zamówieñ w wybranym dniu.");
                update_order_status.Enabled = false;
            }
        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void update_order_status_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string status = "Gotowe";

                foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                {
                    int orderId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    int rowIndex = selectedRow.Index;
                    dataGridView1.Rows[rowIndex].Cells["STATUS"].Value = status;
                    UpdateOrderStatusInSheets(orderId, status);
                }
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

        private void quit_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();
        }

        private void cancel_order_status_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                {
                    int orderId = Convert.ToInt32(selectedRow.Cells["ID"].Value);

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
                                row[6] = "STATUS";

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

                apiSheetsRead sheetsRead = new apiSheetsRead();
                sheetsRead.readEntries(sheetTitle, dataGridView1, false);
            }
        }

    }
}