using static RestaurantDashboardDRoom.Program;
using static RestaurantDashboardDRoom.Program.Order;

namespace RestaurantDashboardDRoom
{
    public partial class NewForm : Form
    {
        Database db = new Database();
        Order order = new Order();

        MenuPosition menuPosition = new MenuPosition();
        List<MenuPosition> menuPositions = new List<MenuPosition>();

        string selectedTable, selectedEmployee;
        // Add the return MenuPosition object to the list of menu positions
        void addMenuPositionToList()
        {
            menuPositions.Add(menuPosition);
        }

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
                    userListCombox.Items.Add($"{pracownik.Id} {pracownik.Imie} {pracownik.Nazwisko} ({pracownik.Stanowisko})");
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

        int returnSelectedTableID()
        {
            // Get the selected table from the ComboBox 
            selectedTable = tableListCombox.SelectedItem.ToString();

            // Convert the selected table to an integer and assign it to the Order object
            int tableIdToInt = int.Parse(selectedTable);

            return tableIdToInt;
        }

        int returnSelectedUserID()
        {

            selectedEmployee = userListCombox.SelectedItem.ToString();

            // Convert the selected employee to an integer and assign it to the Order object
            int selectedEmployeId = int.Parse(selectedEmployee.Split(' ')[0]);

            return selectedEmployeId;

        }

        void removeTheSelectedItemFromListView()
        {
            // Remove the selected item from the ListView control
            if (actual_order.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = actual_order.SelectedItems[0];
                actual_order.Items.Remove(selectedItem);
            }

        }

        void addPositionToCategoryViewList()
        {
            // Get the selected category from the ComboBox
            string selectedCategory = menu_chose_combox.SelectedItem.ToString();

            // Get the corresponding list of MenuPositions based on the selected category
            List<MenuPosition> selectedMenuPositions = null;

            // Assign the selected list of MenuPositions to the ListView control
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

        MenuPosition returnSelectedMenuPosition()
        {
            // Checking if all the values are selected
            if (menu_category_view.SelectedItems.Count > 0 && selectedTable != null && selectedEmployee != null)
            {
                // Enable the "Submit" button and disable the ComboBoxes
                submit_button.Enabled = true;
                tableListCombox.Enabled = false;
                userListCombox.Enabled = false;

                // Get the selected item
                ListViewItem selectedItem = menu_category_view.SelectedItems[0];

                // As MenuPosition object
                menuPosition = selectedItem.Tag as MenuPosition;

                // Print the selected item in list view 
                string itemName = selectedItem.Text;
                actual_order.Items.Add(itemName);

                return menuPosition;

            }
            else
            {
                // No item is selected
                MessageBox.Show($"Missing data!");
                return null;
            }

        }

        // Chosing user 
        void userListCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnSelectedUserID();
            // order.Staff = db.pracownicy.Where(p => p.Id == selectedEmployeId).FirstOrDefault();

        }

        // Chosing table
        void tableListCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnSelectedTableID();
        }


        // Chosing menu 
        void menu_chose_combox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addPositionToCategoryViewList();
        }


        // Add button to order 
        void add_button_Click(object sender, EventArgs e)
        {
            if (menuPosition != null)
            {
                menuPositions.Add(returnSelectedMenuPosition());
            }
        }

        private void remove_button_Click(object sender, EventArgs e)
        {
            removeTheSelectedItemFromListView();
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            order.OrderMenu = menuPositions;
            order.TableID = returnSelectedTableID();
            order.Staff = db.pracownicy.Where(p => p.Id == returnSelectedUserID()).FirstOrDefault();
            
            // Further actions required
            MessageBox.Show($"{order.OrderMenu.ToString}");

        }

    }
}
