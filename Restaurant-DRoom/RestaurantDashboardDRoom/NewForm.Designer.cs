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
            submit_button = new Button();
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
            add_button = new Button();
            remove_button = new Button();
            SuspendLayout();
            // 
            // submit_button
            // 
            submit_button.BackColor = SystemColors.Control;
            submit_button.Enabled = false;
            submit_button.Location = new Point(12, 374);
            submit_button.Name = "submit_button";
            submit_button.Size = new Size(225, 64);
            submit_button.TabIndex = 0;
            submit_button.Text = "Submit";
            submit_button.UseVisualStyleBackColor = false;
            submit_button.Click += submit_button_Click;
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
            tableListCombox.BackColor = SystemColors.Control;
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
            userListCombox.BackColor = SystemColors.Control;
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
            menu_chose_combox.BackColor = SystemColors.Control;
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
            actual_order.BackColor = SystemColors.Control;
            actual_order.Location = new Point(552, 34);
            actual_order.Name = "actual_order";
            actual_order.Size = new Size(236, 404);
            actual_order.TabIndex = 7;
            actual_order.UseCompatibleStateImageBehavior = false;
            actual_order.View = View.List;
            // 
            // menu_category_view
            // 
            menu_category_view.BackColor = SystemColors.Control;
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
            // add_button
            // 
            add_button.Location = new Point(485, 149);
            add_button.Name = "add_button";
            add_button.Size = new Size(61, 64);
            add_button.TabIndex = 0;
            add_button.Text = "Add";
            add_button.UseVisualStyleBackColor = true;
            add_button.Click += add_button_Click;
            // 
            // remove_button
            // 
            remove_button.Location = new Point(485, 219);
            remove_button.Name = "remove_button";
            remove_button.Size = new Size(61, 64);
            remove_button.TabIndex = 0;
            remove_button.Text = "Remove";
            remove_button.UseVisualStyleBackColor = true;
            remove_button.Click += remove_button_Click;
            // 
            // NewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
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
            Controls.Add(remove_button);
            Controls.Add(add_button);
            Controls.Add(submit_button);
            Name = "NewForm";
            Text = "New order";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submit_button;
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
        private Button add_button;
        private Button remove_button;
    }
}