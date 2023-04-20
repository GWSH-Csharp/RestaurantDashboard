namespace RestarantDashboard
{
    partial class Restaurant_Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Restaurant_Dashboard));
            headerPanel = new Panel();
            timeLbl = new Label();
            menuPanel = new Panel();
            quitBtn = new Button();
            menuchangeBtn = new Button();
            dinningroomBtn = new Button();
            kitchenBtn = new Button();
            dinning_Room1 = new Dinning_Room();
            kitchen1 = new Kitchen();
            timer1 = new System.Windows.Forms.Timer(components);
            mainScreen1 = new MainScreen();
            menuPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackgroundImage = (Image)resources.GetObject("headerPanel.BackgroundImage");
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1244, 161);
            headerPanel.TabIndex = 0;
            // 
            // timeLbl
            // 
            timeLbl.AutoSize = true;
            timeLbl.Location = new Point(12, 12);
            timeLbl.Name = "timeLbl";
            timeLbl.Size = new Size(33, 15);
            timeLbl.TabIndex = 0;
            timeLbl.Text = "Time";
            // 
            // menuPanel
            // 
            menuPanel.BackColor = SystemColors.ActiveCaption;
            menuPanel.Controls.Add(timeLbl);
            menuPanel.Controls.Add(quitBtn);
            menuPanel.Controls.Add(menuchangeBtn);
            menuPanel.Controls.Add(dinningroomBtn);
            menuPanel.Controls.Add(kitchenBtn);
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Location = new Point(0, 161);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(181, 700);
            menuPanel.TabIndex = 1;
            // 
            // quitBtn
            // 
            quitBtn.Location = new Point(12, 618);
            quitBtn.Name = "quitBtn";
            quitBtn.Size = new Size(159, 70);
            quitBtn.TabIndex = 3;
            quitBtn.Text = "Quit";
            quitBtn.UseVisualStyleBackColor = true;
            quitBtn.Click += quitBtn_Click;
            // 
            // menuchangeBtn
            // 
            menuchangeBtn.Location = new Point(12, 241);
            menuchangeBtn.Name = "menuchangeBtn";
            menuchangeBtn.Size = new Size(159, 70);
            menuchangeBtn.TabIndex = 2;
            menuchangeBtn.Text = "Menu Change";
            menuchangeBtn.UseVisualStyleBackColor = true;
            // 
            // dinningroomBtn
            // 
            dinningroomBtn.Location = new Point(12, 148);
            dinningroomBtn.Name = "dinningroomBtn";
            dinningroomBtn.Size = new Size(159, 70);
            dinningroomBtn.TabIndex = 1;
            dinningroomBtn.Text = "Dinning Room";
            dinningroomBtn.UseVisualStyleBackColor = true;
            dinningroomBtn.Click += dinningroomBtn_Click;
            // 
            // kitchenBtn
            // 
            kitchenBtn.Location = new Point(12, 62);
            kitchenBtn.Name = "kitchenBtn";
            kitchenBtn.Size = new Size(159, 70);
            kitchenBtn.TabIndex = 0;
            kitchenBtn.Text = "Kitchen";
            kitchenBtn.UseVisualStyleBackColor = true;
            kitchenBtn.Click += kitchenBtn_Click;
            // 
            // dinning_Room1
            // 
            dinning_Room1.BackColor = Color.FromArgb(224, 224, 224);
            dinning_Room1.Location = new Point(177, 161);
            dinning_Room1.Name = "dinning_Room1";
            dinning_Room1.Size = new Size(1067, 700);
            dinning_Room1.TabIndex = 2;
            // 
            // kitchen1
            // 
            kitchen1.BackColor = SystemColors.GradientInactiveCaption;
            kitchen1.Location = new Point(177, 161);
            kitchen1.Name = "kitchen1";
            kitchen1.Size = new Size(1067, 700);
            kitchen1.TabIndex = 3;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // mainScreen1
            // 
            mainScreen1.BackColor = SystemColors.GradientInactiveCaption;
            mainScreen1.Location = new Point(177, 161);
            mainScreen1.Name = "mainScreen1";
            mainScreen1.Size = new Size(1067, 700);
            mainScreen1.TabIndex = 4;
            // 
            // Restaurant_Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1244, 861);
            Controls.Add(mainScreen1);
            Controls.Add(kitchen1);
            Controls.Add(dinning_Room1);
            Controls.Add(menuPanel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Restaurant_Dashboard";
            Text = "Restaurant Dashboard";
            menuPanel.ResumeLayout(false);
            menuPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel headerPanel;
        private Panel menuPanel;
        private Button quitBtn;
        private Button menuchangeBtn;
        private Button dinningroomBtn;
        private Button kitchenBtn;
        private Dinning_Room dinning_Room1;
        private Kitchen kitchen1;
        private Label timeLbl;
        private System.Windows.Forms.Timer timer1;
        private MainScreen mainScreen1;
    }
}