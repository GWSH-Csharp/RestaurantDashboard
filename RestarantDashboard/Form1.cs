namespace RestarantDashboard
{

    public partial class Restaurant_Dashboard : Form
    {

        public Restaurant_Dashboard()
        {
            InitializeComponent();
            timer1.Start();
            this.MaximizeBox = false;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(1260, 900); // set a fixed size
            dinning_Room1.Hide();
            kitchen1.Hide();
            mainScreen1.Show();
            mainScreen1.BringToFront();

        }
        private void kitchenBtn_Click(object sender, EventArgs e)
        {
            dinning_Room1.Hide();
            kitchen1.Show();
            kitchen1.BringToFront();
        }

        private void dinningroomBtn_Click(object sender, EventArgs e)
        {
            kitchen1.Hide();
            dinning_Room1.Show();
            dinning_Room1.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.timeLbl.Text = dateTime.ToString();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            Restaurant_Dashboard.ActiveForm.Close();
        }
    }
}