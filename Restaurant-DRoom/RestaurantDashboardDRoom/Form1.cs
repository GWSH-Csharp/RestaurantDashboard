using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using static RestaurantDashboardDRoom.Program;
using static RestaurantDashboardDRoom.Program.Order;

namespace RestaurantDashboardDRoom
{
    public partial class Form1 : Form
    {
        // Global variables
        DateTime date_now = DateTime.Now;



        // Google Api Spreadsheet global variables
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "ApplicationName";
        static readonly string SpreadsheetId = "1LTfSmD9ew3rT23FL7Ffw2t92mJlhG-Ept-AR0QE0_1U";

        static SheetsService service;



        public Form1()
        {

            InitializeComponent();

            // Google api new instance, starting connection
            GoogleCredential credential;
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

            internal static Order order { get; set; }
            public static void readEntries(string sheet, DataGridView dataGridView1)
            {
                var range = $"{sheet}!A:Z";
                var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
                var response = request.Execute();
                var values = response.Values;

                void clearBeforeYouGoAndAddHeaders()
                {
                    // Clear the datagridview before you add the new data
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Columns.Add("ID", "ID");
                    dataGridView1.Columns.Add("TIME", "TIME");
                    dataGridView1.Columns.Add("TABLE", "TABLE");
                    dataGridView1.Columns.Add("ORDER_MENU", "ORDER_MENU");
                    dataGridView1.Columns.Add("BILL", "BILL");
                    dataGridView1.Columns.Add("STAFF", "STAFF");
                    dataGridView1.Columns.Add("STATUS", "STATUS");
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
                    else
                    {
                        MessageBox.Show("No data available.");
                    }
                }

                clearBeforeYouGoAndAddHeaders();
                addTheRowsAfterHeaders();
            }

            public static void createEntries(string sheet)
            {
                // Order objects to string
                string orderString = "";
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
                        // Sum the bill
                    }
                    orderString += $"------------------------\n";
                    orderString += $"Short description: {order.ShortDescription}\n";
                    orderString += $"------------------------\n";
                }
                getOrderMenuAndMakeItString();

                var range = $"{sheet}!A:Z";
                var valueRange = new ValueRange();
                var objectList = new List<object>() { order.ID, orderDateHHmmToString, orderTableIDToString, orderStringMenu, $"{order.Bill} z³", $"{order.Staff.Imie} {order.Staff.Nazwisko}", "STATUS" };
                valueRange.Values = new List<IList<object>> { objectList };
                var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
                appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                var appendReponse = appendRequest.Execute();

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void view_orders_api_button(object sender, EventArgs e)
        {
            apiSheetsRead.readEntries("Arkusz1", dataGridView1);
        }

    }
}