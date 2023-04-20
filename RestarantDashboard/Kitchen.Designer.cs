namespace RestarantDashboard
{
    partial class Kitchen
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
            viewOrders1 = new ViewOrders();
            viewOrdersBtn = new Button();
            readyToServeBtn = new Button();
            SuspendLayout();
            // 
            // viewOrders1
            // 
            viewOrders1.BackColor = SystemColors.GradientInactiveCaption;
            viewOrders1.Location = new Point(0, 136);
            viewOrders1.Name = "viewOrders1";
            viewOrders1.Size = new Size(1064, 564);
            viewOrders1.TabIndex = 0;
            // 
            // viewOrdersBtn
            // 
            viewOrdersBtn.Location = new Point(28, 22);
            viewOrdersBtn.Name = "viewOrdersBtn";
            viewOrdersBtn.Size = new Size(349, 83);
            viewOrdersBtn.TabIndex = 1;
            viewOrdersBtn.Text = "View Active Orders";
            viewOrdersBtn.UseVisualStyleBackColor = true;
            viewOrdersBtn.Click += viewOrdersBtn_Click;
            // 
            // readyToServeBtn
            // 
            readyToServeBtn.Location = new Point(690, 23);
            readyToServeBtn.Name = "readyToServeBtn";
            readyToServeBtn.Size = new Size(349, 82);
            readyToServeBtn.TabIndex = 2;
            readyToServeBtn.Text = "Ready to serve - Yes";
            readyToServeBtn.UseVisualStyleBackColor = true;
            // 
            // Kitchen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            Controls.Add(readyToServeBtn);
            Controls.Add(viewOrdersBtn);
            Controls.Add(viewOrders1);
            Name = "Kitchen";
            Size = new Size(1067, 700);
            ResumeLayout(false);
        }

        #endregion

        private ViewOrders viewOrders1;
        private Button viewOrdersBtn;
        private Button readyToServeBtn;
    }
}
