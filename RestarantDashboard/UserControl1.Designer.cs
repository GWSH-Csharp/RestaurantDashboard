namespace RestarantDashboard
{
    partial class ViewOrders
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            activeOrdersList = new CheckedListBox();
            timerRefreshOrdersList = new System.Windows.Forms.Timer(components);
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // activeOrdersList
            // 
            activeOrdersList.FormattingEnabled = true;
            activeOrdersList.Location = new Point(18, 41);
            activeOrdersList.Name = "activeOrdersList";
            activeOrdersList.Size = new Size(1033, 490);
            activeOrdersList.TabIndex = 0;
            activeOrdersList.SelectedIndexChanged += activeOrdersList_SelectedIndexChanged;
            // 
            // timerRefreshOrdersList
            // 
            timerRefreshOrdersList.Interval = 1;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.InactiveCaption;
            textBox1.Enabled = false;
            textBox1.Location = new Point(20, 16);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1031, 23);
            textBox1.TabIndex = 1;
            textBox1.Text = "     | Date           | Table               | Guest                      | Order                                                                                                 | Ready to serve";
            // 
            // ViewOrders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            Controls.Add(textBox1);
            Controls.Add(activeOrdersList);
            Name = "ViewOrders";
            Size = new Size(1064, 564);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox activeOrdersList;
        private System.Windows.Forms.Timer timerRefreshOrdersList;
        private TextBox textBox1;
    }
}
