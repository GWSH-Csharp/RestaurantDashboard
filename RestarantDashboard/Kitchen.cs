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
    public partial class Kitchen : UserControl
    {
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "RestaurantDashboard";
        static readonly string SpreadsheetId = "1IjKC6S7XlTwX3zV5LluioFVrMUid1u2UBs3KfeMWvoY";
        static readonly string sheet = "Arkusz1";
        static SheetsService service;

        public Kitchen()
        {
            InitializeComponent();
            viewOrders1.Hide();
        }

        private void viewOrdersBtn_Click(object sender, EventArgs e)
        {
            viewOrders1.Show();
            viewOrders1.BringToFront();
        }
    }
}
