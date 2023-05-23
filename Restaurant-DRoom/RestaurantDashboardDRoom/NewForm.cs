using System.Windows.Forms;
using static RestaurantDashboardDRoom.Form1;
using static RestaurantDashboardDRoom.Program;
using static RestaurantDashboardDRoom.Program.Order;

namespace RestaurantDashboardDRoom
{
    public partial class NewForm : Form
    {
        // Global database decalarion
        Database db = new Database();
        Order order = new Order();
        MenuPosition menuPosition = new MenuPosition();
        List<MenuPosition> menuPositions = new List<MenuPosition>();
        List <string> menuPositionsString;

        // Global variables
        string selectedTable, selectedEmployee;

        // New form constructor
        public NewForm()
        {
            InitializeComponent();


            /* ------------- 
                                     Functions that are basically filling the comboboxes with data
                                       most of them are called right after the declaration.
                                                                                                           ------------- */

            // Starting pracownicy database 
            List<Pracownik> pracownicy = db.pracownicy;

            // All menu positions concatenation
            List<MenuPosition> all_menu_positions = db.przystawki.Concat(db.drugie).Concat(db.desery).Concat(db.napoje).ToList();


            // Adding users to combobox
            void addUsersToComboBox()
            {
                foreach (Pracownik pracownik in pracownicy)
                {
                    userListCombox.Items.Add($"{pracownik.Id} {pracownik.Imie} {pracownik.Nazwisko} ({pracownik.Stanowisko})");
                }
            }
            addUsersToComboBox();


            // Adding tables number to combobox (10 is the testing number)
            void addTableNumbersToComboBox()
            {
                for (int i = 0; i < 10; i++)
                {
                    tableListCombox.Items.Add(i);
                }
            }
            addTableNumbersToComboBox();


            // Adding menu positions to chose combox 
            void addMenuPositionsToComboBox()
            {
                var unique_kategorie = all_menu_positions.Select(mp => mp.Kategoria).Distinct();
                foreach (string kategoria in unique_kategorie)
                {
                    menu_chose_combox.Items.Add(kategoria);
                }
            }
            addMenuPositionsToComboBox();
        }


        /* ------------- 
                         Functions called by the buttons or comboboxes
                Each function should return a value and in total the object Order should be filled with data
                                                                                                          ------------- */


        // According to the selected category in combobox, the listview is filled with the corresponding menu positions
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
                string itemsToString = $"{mp.Nazwa}";
                menu_category_view.Items.Add(itemsToString);
            }


        }


        // According to the selected table in combobox, the table number is returned as an integer
        int returnSelectedTableID()
        {
            // Get the selected table from the ComboBox 
            selectedTable = tableListCombox.SelectedItem.ToString();

            // Convert the selected table to an integer and assign it to the Order object
            int tableIdToInt = int.Parse(selectedTable);

            return tableIdToInt;
        }


        // According to the selected user in combobox, the user ID is returned as an integer
        int returnSelectedUserID()
        {

            selectedEmployee = userListCombox.SelectedItem.ToString();

            // Convert the selected employee to an integer and assign it to the Order object
            int selectedEmployeId = int.Parse(selectedEmployee.Split(' ')[0]);

            return selectedEmployeId;
        }

        // Total of order calculated 
        double returnTheBillTotal()
        {
            double billTotal = 0;
            foreach (MenuPosition mp in menuPositions)
            {
                billTotal += mp.Cena;
            }
            return billTotal;
        }

        // Removing the selected item from the listview
        void removeTheSelectedItemFromListView()
        {
            // Remove the selected item from the ListView control
            if (actual_order.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = actual_order.SelectedItems[0];
                actual_order.Items.Remove(selectedItem);

            }

        }

        // Adding the selected item to the listview
        void addPositionToOrderViewList()
        {
            List<MenuPosition> all_menu_positions = db.przystawki.Concat(db.drugie).Concat(db.desery).Concat(db.napoje).ToList();
            // Checking if all the values are selected
            if (menu_category_view.SelectedItems.Count > 0 && selectedTable != null && selectedEmployee != null)
            {
                // Enable the "Submit" button and disable the ComboBoxes
                submit_button.Enabled = true;
                tableListCombox.Enabled = false;
                userListCombox.Enabled = false;

                // Get the selected item from the ListView control
                string selectedItem = menu_category_view.SelectedItems[0].Text;

                // Add the selectedm item to the menuPositions list
                // menuPosition = all_menu_positions.Where(item => item.Nazwa == selectedItem).FirstOrDefault();

                // Add the selected item to the ListView control
                actual_order.Items.Add(selectedItem);

                // Find the selected MenuPosition in the database
                MenuPosition menuPosition = all_menu_positions.Where(item => item.Nazwa == selectedItem).FirstOrDefault();

                // Add the menuPosition to the menuPositions list
                menuPositions.Add(menuPosition);

            }
            else
            {
                // No item is selected
                MessageBox.Show($"Missing data!");
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

        // Adding menu positions to view list on click "ADD"
        void add_button_Click(object sender, EventArgs e)
        {
            addPositionToOrderViewList();
        }

        // Remove the selected item from the ListView control
        private void remove_button_Click(object sender, EventArgs e)
        {
            removeTheSelectedItemFromListView();
        }

        // Submit the order and return to mother's form
        private void submit_button_Click(object sender, EventArgs e)
        {
            order.TableID = returnSelectedTableID();
            order.Staff = db.pracownicy.Where(p => p.Id == returnSelectedUserID()).FirstOrDefault();
            order.OrderDate = DateTime.Now;
            order.OrderMenu = menuPositions;
            order.Bill = returnTheBillTotal();

            // Pop up summary 
            MessageBox.Show($"{order.OrderDate} \n {order.Staff.Imie} {order.Staff.Nazwisko} \n {order.TableID}");

            // Return the order object to the main form
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            if (form1 != null)
            {
                apiSheetsRead apiSheetsRead = new apiSheetsRead();
                apiSheetsRead.order = order;
                DataGridView dataGridView1 = form1.dataGridView1;

                // Refresh the entries in the DataGridView control and then append the new entry
                apiSheetsRead.readEntries("Arkusz1", dataGridView1);
                apiSheetsRead.createEntries("Arkusz1");
                apiSheetsRead.readEntries("Arkusz1", dataGridView1);
            }


            // Close the form
            this.Close();

        }

    }
}
