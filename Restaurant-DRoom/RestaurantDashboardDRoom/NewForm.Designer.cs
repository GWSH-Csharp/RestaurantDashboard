namespace RestaurantDashboardDRoom
{
    partial class NewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            tableLabel = new Label();
            tableListCombox = new ComboBox();
            label1 = new Label();
            userListCombox = new ComboBox();
            menu_combox = new Label();
            menu_chose_combox = new ComboBox();
            actual_order = new ListView();
            menu_category_view = new ListView();
            category_menu_label = new Label();
            actual_order_label = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 374);
            button1.Name = "button1";
            button1.Size = new Size(225, 64);
            button1.TabIndex = 0;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            // 
            // tableLabel
            // 
            tableLabel.AutoSize = true;
            tableLabel.Location = new Point(12, 73);
            tableLabel.Name = "tableLabel";
            tableLabel.Size = new Size(34, 15);
            tableLabel.TabIndex = 3;
            tableLabel.Text = "Table";
            // 
            // tableListCombox
            // 
            tableListCombox.DropDownStyle = ComboBoxStyle.DropDownList;
            tableListCombox.FormattingEnabled = true;
            tableListCombox.Location = new Point(12, 91);
            tableListCombox.Name = "tableListCombox";
            tableListCombox.Size = new Size(225, 23);
            tableListCombox.TabIndex = 4;
            tableListCombox.SelectedIndexChanged += tableListCombox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 5;
            label1.Text = "User";
            // 
            // userListCombox
            // 
            userListCombox.DropDownStyle = ComboBoxStyle.DropDownList;
            userListCombox.FormattingEnabled = true;
            userListCombox.Location = new Point(12, 34);
            userListCombox.Name = "userListCombox";
            userListCombox.Size = new Size(225, 23);
            userListCombox.TabIndex = 4;
            userListCombox.SelectedIndexChanged += userListCombox_SelectedIndexChanged;
            // 
            // menu_combox
            // 
            menu_combox.AutoSize = true;
            menu_combox.Location = new Point(12, 131);
            menu_combox.Name = "menu_combox";
            menu_combox.Size = new Size(38, 15);
            menu_combox.TabIndex = 3;
            menu_combox.Text = "Menu";
            // 
            // menu_chose_combox
            // 
            menu_chose_combox.DropDownStyle = ComboBoxStyle.DropDownList;
            menu_chose_combox.FormattingEnabled = true;
            menu_chose_combox.Location = new Point(12, 149);
            menu_chose_combox.Name = "menu_chose_combox";
            menu_chose_combox.Size = new Size(225, 23);
            menu_chose_combox.TabIndex = 4;
            menu_chose_combox.SelectedIndexChanged += menu_chose_combox_SelectedIndexChanged;
            // 
            // actual_order
            // 
            actual_order.Location = new Point(552, 34);
            actual_order.Name = "actual_order";
            actual_order.Size = new Size(236, 404);
            actual_order.TabIndex = 7;
            actual_order.UseCompatibleStateImageBehavior = false;
            // 
            // menu_category_view
            // 
            menu_category_view.Location = new Point(243, 34);
            menu_category_view.Name = "menu_category_view";
            menu_category_view.Size = new Size(236, 404);
            menu_category_view.TabIndex = 7;
            menu_category_view.UseCompatibleStateImageBehavior = false;
            menu_category_view.View = View.List;
            // 
            // category_menu_label
            // 
            category_menu_label.AutoSize = true;
            category_menu_label.Location = new Point(243, 16);
            category_menu_label.Name = "category_menu_label";
            category_menu_label.Size = new Size(55, 15);
            category_menu_label.TabIndex = 5;
            category_menu_label.Text = "Category";
            // 
            // actual_order_label
            // 
            actual_order_label.Location = new Point(552, 16);
            actual_order_label.Name = "actual_order_label";
            actual_order_label.Size = new Size(55, 15);
            actual_order_label.TabIndex = 5;
            actual_order_label.Text = "Order";
            // 
            // NewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menu_category_view);
            Controls.Add(actual_order);
            Controls.Add(actual_order_label);
            Controls.Add(category_menu_label);
            Controls.Add(label1);
            Controls.Add(userListCombox);
            Controls.Add(menu_chose_combox);
            Controls.Add(menu_combox);
            Controls.Add(tableListCombox);
            Controls.Add(tableLabel);
            Controls.Add(button1);
            Name = "NewForm";
            Text = "New order";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label tableLabel;
        private ComboBox tableListCombox;
        private Label label1;
        private ComboBox userListCombox;
        private Label menu_combox;
        private ComboBox menu_chose_combox;
        private ListView actual_order;
        private ListView menu_category_view;
        private Label category_menu_label;
        private Label actual_order_label;
    }
}