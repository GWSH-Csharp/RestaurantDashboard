namespace RestaurantDashboardDRoom
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            new_order_button = new Button();
            date_time_main = new Label();
            view_orders_button = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            timer_now = new System.Windows.Forms.Timer(components);
            dateTimePicker1 = new DateTimePicker();
            autoRefresh = new CheckBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.AppWorkspace;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(-179, -6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1135, 147);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // new_order_button
            // 
            new_order_button.BackColor = SystemColors.Control;
            new_order_button.Location = new Point(13, 605);
            new_order_button.Name = "new_order_button";
            new_order_button.Size = new Size(228, 63);
            new_order_button.TabIndex = 4;
            new_order_button.Text = "New Order";
            new_order_button.UseVisualStyleBackColor = false;
            new_order_button.Click += new_order_button_Click;
            // 
            // date_time_main
            // 
            date_time_main.AutoSize = true;
            date_time_main.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            date_time_main.Location = new Point(13, 171);
            date_time_main.Name = "date_time_main";
            date_time_main.Size = new Size(118, 37);
            date_time_main.TabIndex = 5;
            date_time_main.Text = "TheTime";
            // 
            // view_orders_button
            // 
            view_orders_button.BackColor = SystemColors.Control;
            view_orders_button.Location = new Point(12, 536);
            view_orders_button.Name = "view_orders_button";
            view_orders_button.Size = new Size(228, 63);
            view_orders_button.TabIndex = 4;
            view_orders_button.Text = "Refresh";
            view_orders_button.UseVisualStyleBackColor = false;
            view_orders_button.Click += view_orders_api_button;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7 });
            dataGridView1.Location = new Point(247, 188);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(693, 480);
            dataGridView1.TabIndex = 7;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.FillWeight = 10.3918686F;
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.FillWeight = 41.3482552F;
            Column2.HeaderText = "Column2";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.FillWeight = 17.333025F;
            Column3.HeaderText = "Column3";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.FillWeight = 65.8709259F;
            Column4.HeaderText = "Column4";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column5.FillWeight = 20.64853F;
            Column5.HeaderText = "Column5";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column6.FillWeight = 44.6981163F;
            Column6.HeaderText = "Column6";
            Column6.Name = "Column6";
            // 
            // Column7
            // 
            Column7.HeaderText = "Column7";
            Column7.Name = "Column7";
            // 
            // timer_now
            // 
            timer_now.Enabled = true;
            timer_now.Interval = 1000;
            timer_now.Tick += Timer_now_Tick;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(247, 159);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 8;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // autoRefresh
            // 
            autoRefresh.AutoSize = true;
            autoRefresh.Location = new Point(13, 511);
            autoRefresh.Name = "autoRefresh";
            autoRefresh.Size = new Size(94, 19);
            autoRefresh.TabIndex = 9;
            autoRefresh.Text = "Auto Refresh";
            autoRefresh.UseVisualStyleBackColor = true;
            autoRefresh.CheckedChanged += autoRefresh_CheckedChanged;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.Location = new Point(145, 467);
            button1.Name = "button1";
            button1.Size = new Size(95, 63);
            button1.TabIndex = 4;
            button1.Text = "Delivered";
            button1.UseVisualStyleBackColor = false;
            button1.Click += update_order_status_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(947, 673);
            Controls.Add(autoRefresh);
            Controls.Add(dateTimePicker1);
            Controls.Add(dataGridView1);
            Controls.Add(date_time_main);
            Controls.Add(button1);
            Controls.Add(view_orders_button);
            Controls.Add(new_order_button);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Restaurant Dashboar - Dinning Room";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Button new_order_button;
        private Label date_time_main;
        private Button view_orders_button;
        private System.Windows.Forms.Timer timer_now;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        public DataGridView dataGridView1;
        private DateTimePicker dateTimePicker1;
        private CheckBox autoRefresh;
        private Button button1;
    }
}