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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void new_order_button_Click(object sender, EventArgs e)
        {

            orders_list_view.Items.Add(myOrder.ShortDescription);
        }

    }
}