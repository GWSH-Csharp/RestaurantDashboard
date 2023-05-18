using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;

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

        public static class apiSheetsRead
        {
            public static void ReadEntries(string sheet, DataGridView dataGridView1)
            {
                int indexColumn = 0;
                var range = $"{sheet}!A1:D30";
                var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
                var response = request.Execute();
                var values = response.Values;
                
                void clearBeforeYouGo()
                {
                    // Clear the datagridview before you add the new data
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Columns.Add("Column1", "Header1");
                    dataGridView1.Columns.Add("Column2", "Header2");
                    dataGridView1.Columns.Add("Column3", "Header3");
                    dataGridView1.Columns.Add("Column4", "Header4");
                    dataGridView1.Columns.Add("Column5", "Header5");
                    dataGridView1.Columns.Add("Column6", "Header6");
                    dataGridView1.Columns.Add("Column7", "Header7");

                }
                void addTheHeaders()
                {
                    // Add the header row from the spreadsheet to the datagridview
                    if (values != null && values.Count > 0)
                    {
                        var headerRow = values[0];
                        foreach (var cellValue in headerRow)
                        {
                            if (indexColumn < dataGridView1.Columns.Count)
                            {
                                dataGridView1.Columns[indexColumn].HeaderText = cellValue?.ToString();
                            }
                            indexColumn++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to read data");
                    }
                }
                void addTheRowsAfterHeaders()
                {
                    // Add the rows from the spreadsheet to the datagridview
                    if (values != null && values.Count > 0)
                    {
                        for (int i = 1; i < values.Count; i++)
                        {
                            var row = values[i];
                            dataGridView1.Rows.Add(row.ToArray());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to read data");
                    }
                }
                clearBeforeYouGo();
                addTheHeaders();
                addTheRowsAfterHeaders();
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
            apiSheetsRead.ReadEntries("Arkusz1", dataGridView1);
        }

    }
}