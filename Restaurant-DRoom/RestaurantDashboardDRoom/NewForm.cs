using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using static RestaurantDashboardDRoom.Program;
using static RestaurantDashboardDRoom.Program.Order;

namespace RestaurantDashboardDRoom
{
    public partial class NewForm : Form
    {
        Database db = new Database();
        Order order = new Order();
        public NewForm()
        {
            InitializeComponent();

            // Starting pracownicy database 
            List<Pracownik> pracownicy = db.pracownicy;

            // Menu database started 
            List<MenuPosition> all_menu_positions = db.przystawki.Concat(db.drugie).Concat(db.desery).Concat(db.napoje).ToList();

            // Function adding users to combo box list
            void addUsersToComboBox()
            {
                foreach (Pracownik pracownik in pracownicy)
                {
                    userListCombox.Items.Add($"{pracownik.Imie} {pracownik.Nazwisko} ({pracownik.Stanowisko})");
                }
            }
            addUsersToComboBox();

            // Adding tables number to combobox (10 is the testing number)
            void addTableNumbers()
            {
                for (int i = 0; i < 10; i++)
                {
                    tableListCombox.Items.Add(i);
                }
            }
            addTableNumbers();

            // Menu positions adding to chose combox 
            void addMenuPositions()
            {
                var unique_kategorie = all_menu_positions.Select(mp => mp.Kategoria).Distinct();
                foreach (string kategoria in unique_kategorie)
                {
                    menu_chose_combox.Items.Add(kategoria);
                }
            }
            addMenuPositions();
        }

        string selectedTable, selectedEmployee;

        // Chosing user 
        void userListCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEmployee = userListCombox.SelectedItem.ToString();
        }

        // Chosing table
        void tableListCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTable = tableListCombox.SelectedItem.ToString();
        }


        // Chosing menu 
        void menu_chose_combox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected category from the ComboBox
            string selectedCategory = menu_chose_combox.SelectedItem.ToString();

            // Get the corresponding list of MenuPositions based on the selected category
            List<MenuPosition> selectedMenuPositions = null;

            switch (selectedCategory)
            {
                case "Przystawki":
                    selectedMenuPositions = db.przystawki;
                    break;
                case "Drugie":
                    selectedMenuPositions = db.drugie;
                    break;
                case "Desery":
                    selectedMenuPositions = db.desery;
                    break;
                case "Napoje":
                    selectedMenuPositions = db.napoje;
                    break;
                default:
                    return; // Exit the event handler if the selected category is not recognized
            }

            // Clear the existing items in the ListView control
            menu_category_view.Items.Clear();

            // Filter the selected list of MenuPositions based on the "Kategoria" property
            List<MenuPosition> filteredMenuPositions = selectedMenuPositions.Where(mp => mp.Kategoria == selectedCategory).ToList();


            // Add the filtered MenuPositions to the ListView control
            foreach (MenuPosition mp in filteredMenuPositions)
            {
                ListViewItem item = new ListViewItem();
                string itemsToString = $"{mp.Nazwa} {"   "} {mp.Cena.ToString()}";
                menu_category_view.Items.Add(itemsToString);
            }

        }

        // Add button to order 
        void add_button_Click_1(object sender, EventArgs e)
        {
            if (menu_category_view.SelectedItems.Count > 0 && selectedTable != null && selectedEmployee != null)
            {
                // Get the selected item
                ListViewItem selectedItem = menu_category_view.SelectedItems[0];

                // Access the data of the selected item
                string itemName = selectedItem.Text;
                // string itemPrice = selectedItem.SubItems[1].Text;

                // Perform your desired action using the selected item's data
                // Example: Display the selected item's details in a message box
                // MessageBox.Show($"Selected Item: {itemName}\nPrice: {itemPrice}");
                tableListCombox.Enabled = false;
                userListCombox.Enabled = false;
                actual_order.Items.Add(itemName);
            }
            else
            {
                // No item is selected
                MessageBox.Show("Missing data!");
            }
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Added order!");
        }
    }
}
