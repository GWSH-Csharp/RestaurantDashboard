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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            orders_list_view = new ListView();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            orderds_main_list_title = new RichTextBox();
            new_order_button = new Button();
            columnHeader1 = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // orders_list_view
            // 
            orders_list_view.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            orders_list_view.Location = new Point(12, 185);
            orders_list_view.Name = "orders_list_view";
            orders_list_view.Size = new Size(238, 450);
            orders_list_view.TabIndex = 0;
            orders_list_view.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            button1.Location = new Point(256, 572);
            button1.Name = "button1";
            button1.Size = new Size(228, 63);
            button1.TabIndex = 1;
            button1.Text = "Select";
            button1.UseVisualStyleBackColor = true;
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
            // orderds_main_list_title
            // 
            orderds_main_list_title.BackColor = SystemColors.ButtonFace;
            orderds_main_list_title.BorderStyle = BorderStyle.None;
            orderds_main_list_title.Font = new Font("Ebrima", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            orderds_main_list_title.ForeColor = SystemColors.WindowText;
            orderds_main_list_title.Location = new Point(12, 153);
            orderds_main_list_title.Name = "orderds_main_list_title";
            orderds_main_list_title.ReadOnly = true;
            orderds_main_list_title.ScrollBars = RichTextBoxScrollBars.None;
            orderds_main_list_title.Size = new Size(238, 26);
            orderds_main_list_title.TabIndex = 3;
            orderds_main_list_title.Text = "Orders List";
            // 
            // new_order_button
            // 
            new_order_button.Location = new Point(490, 572);
            new_order_button.Name = "new_order_button";
            new_order_button.Size = new Size(228, 63);
            new_order_button.TabIndex = 4;
            new_order_button.Text = "New Order";
            new_order_button.UseVisualStyleBackColor = true;
            new_order_button.Click += new_order_button_Click;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = -1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1127, 647);
            Controls.Add(new_order_button);
            Controls.Add(orderds_main_list_title);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(orders_list_view);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListView orders_list_view;
        private Button button1;
        private PictureBox pictureBox1;
        private RichTextBox orderds_main_list_title;
        private Button new_order_button;
        private ColumnHeader columnHeader1;
    }
}