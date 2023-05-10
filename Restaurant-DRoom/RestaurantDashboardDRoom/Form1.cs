using System.Windows.Forms;
using static RestaurantDashboardDRoom.Program;

namespace RestaurantDashboardDRoom
{
    public partial class Form1 : Form
    {
        DateTime date_now = DateTime.Now;

        private Order myOrder;
        public Form1()
        {
            InitializeComponent();
            myOrder = new Order();
            myOrder.ID = 1;
            myOrder.OrderDate = date_now;
            myOrder.TableID = 2;
            myOrder.Bill = 29.99;
        }

        private void new_order_button_Click(object sender, EventArgs e)
        {
            // Set ReadOnly property on other windows 
            orders_list_view.Enabled = false;
            // Set focus on the RichTextBox control
            orders_list_view.Focus();
            orders_list_view.Items.Add(myOrder.ShortDescription);
            // Create a new instance of the NewForm class
            NewForm newForm = new NewForm();

            // Show the new form
            newForm.Show();
        }


        private void orders_list_view_on_click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = orders_list_view.SelectedItems[0];
            string selectedText = selectedItem.Text;
            orders_view.Text = "Total:" + myOrder.Bill.ToString();
        }
    }
}