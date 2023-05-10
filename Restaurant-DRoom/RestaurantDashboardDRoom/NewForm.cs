using static RestaurantDashboardDRoom.Program;
using static RestaurantDashboardDRoom.Program.Order;

namespace RestaurantDashboardDRoom
{
    public partial class NewForm : Form
    {
        Database db = new Database();

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



        // Chosing user 
        private void userListCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEmployee = userListCombox.SelectedItem.ToString();
        }

        // Chosing table
        private void tableListCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTable = tableListCombox.SelectedItem.ToString();
        }

        // Chosing menu 
        private void menu_chose_combox_SelectedIndexChanged(object sender, EventArgs e)
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
                string itemsToString = mp.Nazwa + mp.Cena.ToString(); 
                menu_category_view.Items.Add(itemsToString);
            }


        }

    }
}
