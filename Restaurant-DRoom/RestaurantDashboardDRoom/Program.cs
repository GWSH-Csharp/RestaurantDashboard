using static RestaurantDashboardDRoom.Program.Order;

namespace RestaurantDashboardDRoom
{
    internal static class Program
    {
        public class Order
        {
            // Order main object 
            public int ID { get; set; }
            public List<MenuPosition> OrderMenu { get; set; }
            public DateTime OrderDate { get; set; }
            public int TableID { get; set; }
            public double Bill { get; set; }
            public string ShortDescription { get { return $"ID: {ID},  Table: {TableID}, Date: {OrderDate}, Bill: {Bill}"; } }

            // Each menu position definition
            public class MenuPosition
            {
                public int Id { get; set; }
                public int Pozycja { get; set; }
                public string Kategoria { get; set; }
                public string Nazwa { get; set; }
                public double Cena { get; set; }
            }
            public class Pracownik
            {
                public int Id { get; set; }
                public string Imie { get; set; }
                public string Nazwisko { get; set; }
                public string Dzial { get; set; }
                public string Stanowisko { get; set; }

            }

        }
        public class Database
        {
            public List<Pracownik> pracownicy = new List<Pracownik>
            {
                new Pracownik { Id = 1, Imie = "Jan", Nazwisko = "Kowalski", Dzial = "SALA", Stanowisko = "Manager" },
                new Pracownik { Id = 2, Imie = "Anna", Nazwisko = "Nowak", Dzial = "SALA", Stanowisko = "Kelner" },
                new Pracownik { Id = 3, Imie = "Piotr", Nazwisko = "Wójcik", Dzial = "SALA", Stanowisko = "Kelner" },
                new Pracownik { Id = 4, Imie = "Marek", Nazwisko = "Lewandowski", Dzial = "KUCHNIA", Stanowisko = "Chef" },
                new Pracownik { Id = 5, Imie = "Kasia", Nazwisko = "Nowakowska", Dzial = "KUCHNIA", Stanowisko = "Pomoc kuchenna" },
                new Pracownik { Id = 6, Imie = "Adam", Nazwisko = "Kowalczyk", Dzial = "SALA", Stanowisko = "Kelner" }
            };

            public List<MenuPosition> przystawki = new List<MenuPosition>
            {
                new MenuPosition { Id = 1, Pozycja = 1, Kategoria = "Przystawki", Nazwa = "Sa³atka grecka", Cena = 10.50 },
                new MenuPosition { Id = 2, Pozycja = 2, Kategoria = "Przystawki", Nazwa = "Krewetki koktajlowe", Cena = 19.50 },
                new MenuPosition { Id = 3, Pozycja = 3, Kategoria = "Przystawki", Nazwa = "Tatar wo³owy", Cena = 17.00 },
                // Dodaj pozosta³e przystawki
            };

            public List<MenuPosition> drugie = new List<MenuPosition>
            {
                new MenuPosition { Id = 9, Pozycja = 1, Kategoria = "Drugie", Nazwa = "Schabowy z ziemniakami i kapust¹", Cena = 22.00 },
                new MenuPosition { Id = 10, Pozycja = 2, Kategoria = "Drugie", Nazwa = "Gulasz z jagniêciny", Cena = 27.50 },
                new MenuPosition { Id = 11, Pozycja = 3, Kategoria = "Drugie", Nazwa = "Kotlet de volaille", Cena = 20.00 },
                // Dodaj pozosta³e drugie
            };

            public List<MenuPosition> desery = new List<MenuPosition>
            {
                new MenuPosition { Id = 17, Pozycja = 1, Kategoria = "Desery", Nazwa = "Tarta cytrynowa", Cena = 12.00 },
                new MenuPosition { Id = 18, Pozycja = 2, Kategoria = "Desery", Nazwa = "Sernik na zimno", Cena = 14.50 },
                new MenuPosition { Id = 19, Pozycja = 3, Kategoria = "Desery", Nazwa = "Truskawki w bitwie œmietanie", Cena = 10.00 },
                // Dodaj pozosta³e desery
            };

            public List<MenuPosition> napoje = new List<MenuPosition>
            {
                new MenuPosition { Id = 25, Pozycja = 1, Kategoria = "Napoje", Nazwa = "Kawa czarna", Cena = 7.00 },
                new MenuPosition { Id = 26, Pozycja = 2, Kategoria = "Napoje", Nazwa = "Herbata", Cena = 6.50 },
                new MenuPosition { Id = 27, Pozycja = 3, Kategoria = "Napoje", Nazwa = "Sok pomarañczowy", Cena = 8.50 },
                // Dodaj pozosta³e napoje
            };

        }





        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}