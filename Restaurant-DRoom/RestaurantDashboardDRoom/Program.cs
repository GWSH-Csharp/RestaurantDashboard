namespace RestaurantDashboardDRoom
{
    internal static class Program
    {
        public class Order
        {



            public DateTime GetTime()
            {
                DateTime now = DateTime.Now;
                TimeSpan time = new TimeSpan(now.Hour, now.Minute, now.Second);
                DateTime timeOnly = DateTime.Today.Add(time);
                return timeOnly;
            }


            public int ID { get; set; }
            public List<string> MenuOrder { get; set; }
            public DateTime OrderDate { get; set; }
            public int TableID { get; set; }
            public double Bill { get; set; }
            public string ShortDescription { get { return $"ID: {ID},  Table: {TableID}, Date: {OrderDate}, Bill: { Bill}"; } }

        }

        static void addNewOrder()
        {



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