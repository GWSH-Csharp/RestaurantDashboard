namespace RestaurantDashboardKitchen
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            update_order_status = new Button();
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
            quit = new Button();
            cancel_order_status = new Button();
            autoRefresh = new CheckBox();
            lastRefresh = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.AppWorkspace;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(-4, -9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1135, 149);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // update_order_status
            // 
            update_order_status.BackColor = SystemColors.Control;
            update_order_status.ForeColor = Color.FromArgb(0, 192, 0);
            update_order_status.Location = new Point(13, 550);
            update_order_status.Name = "update_order_status";
            update_order_status.Size = new Size(107, 63);
            update_order_status.TabIndex = 4;
            update_order_status.Text = "Update Order Status";
            update_order_status.UseVisualStyleBackColor = false;
            update_order_status.Click += update_order_status_Click;
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
            view_orders_button.Location = new Point(13, 481);
            view_orders_button.Name = "view_orders_button";
            view_orders_button.Size = new Size(228, 63);
            view_orders_button.TabIndex = 4;
            view_orders_button.Text = "View Orders";
            view_orders_button.UseVisualStyleBackColor = false;
            view_orders_button.Click += view_orders_api_button;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7 });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(270, 188);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(824, 486);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
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
            dateTimePicker1.Location = new Point(270, 159);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 8;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // quit
            // 
            quit.BackColor = SystemColors.Control;
            quit.Location = new Point(13, 619);
            quit.Name = "quit";
            quit.Size = new Size(227, 55);
            quit.TabIndex = 9;
            quit.Text = "Quit";
            quit.UseVisualStyleBackColor = false;
            quit.Click += quit_Click;
            // 
            // cancel_order_status
            // 
            cancel_order_status.BackColor = SystemColors.Control;
            cancel_order_status.ForeColor = Color.Red;
            cancel_order_status.Location = new Point(133, 550);
            cancel_order_status.Name = "cancel_order_status";
            cancel_order_status.Size = new Size(107, 63);
            cancel_order_status.TabIndex = 10;
            cancel_order_status.Text = "Cancel Order Status";
            cancel_order_status.UseVisualStyleBackColor = false;
            cancel_order_status.Click += cancel_order_status_Click;
            // 
            // autoRefresh
            // 
            autoRefresh.AutoSize = true;
            autoRefresh.Location = new Point(13, 427);
            autoRefresh.Name = "autoRefresh";
            autoRefresh.Size = new Size(124, 19);
            autoRefresh.TabIndex = 11;
            autoRefresh.Text = "Automatic Refresh";
            autoRefresh.UseVisualStyleBackColor = true;
            autoRefresh.CheckedChanged += autoRefresh_CheckedChanged;
            // 
            // lastRefresh
            // 
            lastRefresh.BackColor = SystemColors.Control;
            lastRefresh.Location = new Point(13, 452);
            lastRefresh.Name = "lastRefresh";
            lastRefresh.ReadOnly = true;
            lastRefresh.Size = new Size(227, 23);
            lastRefresh.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1106, 686);
            Controls.Add(lastRefresh);
            Controls.Add(autoRefresh);
            Controls.Add(cancel_order_status);
            Controls.Add(quit);
            Controls.Add(dateTimePicker1);
            Controls.Add(dataGridView1);
            Controls.Add(date_time_main);
            Controls.Add(view_orders_button);
            Controls.Add(update_order_status);
            Controls.Add(pictureBox1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Restaurant Dashboard - Kitchen View";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Button update_order_status;
        private Label date_time_main;
        private Button view_orders_button;
        private System.Windows.Forms.Timer timer_now;
        public DataGridView dataGridView1;
        private DateTimePicker dateTimePicker1;
        private Button quit;
        private Button cancel_order_status;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private CheckBox autoRefresh;
        private TextBox lastRefresh;
    }
}