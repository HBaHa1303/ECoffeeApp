namespace ECoffee.Presentation.Forms
{
    partial class frmKdsDashboard
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
            components = new System.ComponentModel.Container();
            panle1 = new Panel();
            lblSystemDateTime = new Label();
            lblTitle = new Label();
            tmrClock = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            btnShowCompleted = new Button();
            btnShowPending = new Button();
            panel2 = new Panel();
            flpPendingOrders = new FlowLayoutPanel();
            flpCompletedOrders = new FlowLayoutPanel();
            btnLogout = new Button();
            panle1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            //
            // btnLogout
            //
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.Location = new Point(610, 10);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(80, 28);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            //
            // panle1
            //
            panle1.Controls.Add(btnLogout);
            panle1.Controls.Add(lblSystemDateTime);
            panle1.Controls.Add(lblTitle);
            panle1.Dock = DockStyle.Top;
            panle1.Location = new Point(0, 0);
            panle1.Margin = new Padding(3, 2, 3, 2);
            panle1.Name = "panle1";
            panle1.Size = new Size(700, 48);
            panle1.TabIndex = 0;
            // 
            // lblSystemDateTime
            // 
            lblSystemDateTime.AutoSize = true;
            lblSystemDateTime.Location = new Point(10, 28);
            lblSystemDateTime.Name = "lblSystemDateTime";
            lblSystemDateTime.Size = new Size(34, 15);
            lblSystemDateTime.TabIndex = 1;
            lblSystemDateTime.Text = "Time";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(173, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Kitchen Display";
            // 
            // tmrClock
            // 
            tmrClock.Enabled = true;
            tmrClock.Interval = 1000;
            tmrClock.Tick += tmrClock_Tick;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnShowCompleted);
            panel1.Controls.Add(btnShowPending);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 48);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 37);
            panel1.TabIndex = 1;
            // 
            // btnShowCompleted
            // 
            btnShowCompleted.Location = new Point(110, 2);
            btnShowCompleted.Margin = new Padding(3, 2, 3, 2);
            btnShowCompleted.Name = "btnShowCompleted";
            btnShowCompleted.Size = new Size(82, 32);
            btnShowCompleted.TabIndex = 1;
            btnShowCompleted.Text = "Hoàn thành";
            btnShowCompleted.UseVisualStyleBackColor = true;
            btnShowCompleted.Click += btnShowCompleted_Click;
            // 
            // btnShowPending
            // 
            btnShowPending.Location = new Point(10, 2);
            btnShowPending.Margin = new Padding(3, 2, 3, 2);
            btnShowPending.Name = "btnShowPending";
            btnShowPending.Size = new Size(82, 32);
            btnShowPending.TabIndex = 0;
            btnShowPending.Text = "Món đợi";
            btnShowPending.UseVisualStyleBackColor = true;
            btnShowPending.Click += btnShowPending_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(flpPendingOrders);
            panel2.Controls.Add(flpCompletedOrders);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 85);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(700, 253);
            panel2.TabIndex = 2;
            // 
            // flpPendingOrders
            // 
            flpPendingOrders.AutoScroll = true;
            flpPendingOrders.Dock = DockStyle.Fill;
            flpPendingOrders.Location = new Point(0, 0);
            flpPendingOrders.Margin = new Padding(3, 2, 3, 2);
            flpPendingOrders.Name = "flpPendingOrders";
            flpPendingOrders.Size = new Size(700, 253);
            flpPendingOrders.TabIndex = 0;
            // 
            // flpCompletedOrders
            // 
            flpCompletedOrders.AutoScroll = true;
            flpCompletedOrders.Dock = DockStyle.Fill;
            flpCompletedOrders.Location = new Point(0, 0);
            flpCompletedOrders.Margin = new Padding(3, 2, 3, 2);
            flpCompletedOrders.Name = "flpCompletedOrders";
            flpCompletedOrders.Size = new Size(700, 253);
            flpCompletedOrders.TabIndex = 1;
            // 
            // frmKdsDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panle1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmKdsDashboard";
            StartPosition = FormStartPosition.CenterParent;
            Text = "KDS";
            WindowState = FormWindowState.Maximized;
            Load += frmKdsDashboard_Load;
            panle1.ResumeLayout(false);
            panle1.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panle1;
        private Label lblTitle;
        private System.Windows.Forms.Timer tmrClock;
        private Label lblSystemDateTime;
        private Panel panel1;
        private Button btnShowCompleted;
        private Button btnShowPending;
        private Panel panel2;
        private FlowLayoutPanel flpCompletedOrders;
        private FlowLayoutPanel flpPendingOrders;
        private Button btnLogout;
    }
}