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
            panle1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panle1
            // 
            panle1.Controls.Add(lblSystemDateTime);
            panle1.Controls.Add(lblTitle);
            panle1.Dock = DockStyle.Top;
            panle1.Location = new Point(0, 0);
            panle1.Name = "panle1";
            panle1.Size = new Size(800, 64);
            panle1.TabIndex = 0;
            // 
            // lblSystemDateTime
            // 
            lblSystemDateTime.AutoSize = true;
            lblSystemDateTime.Location = new Point(12, 38);
            lblSystemDateTime.Name = "lblSystemDateTime";
            lblSystemDateTime.Size = new Size(42, 20);
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
            lblTitle.Size = new Size(220, 38);
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
            panel1.Location = new Point(0, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 49);
            panel1.TabIndex = 1;
            // 
            // btnShowCompleted
            // 
            btnShowCompleted.Location = new Point(126, 3);
            btnShowCompleted.Name = "btnShowCompleted";
            btnShowCompleted.Size = new Size(94, 43);
            btnShowCompleted.TabIndex = 1;
            btnShowCompleted.Text = "Hoàn thành";
            btnShowCompleted.UseVisualStyleBackColor = true;
            btnShowCompleted.Click += btnShowCompleted_Click;
            // 
            // btnShowPending
            // 
            btnShowPending.Location = new Point(12, 3);
            btnShowPending.Name = "btnShowPending";
            btnShowPending.Size = new Size(94, 43);
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
            panel2.Location = new Point(0, 113);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 337);
            panel2.TabIndex = 2;
            // 
            // flpPendingOrders
            // 
            flpPendingOrders.AutoScroll = true;
            flpPendingOrders.Dock = DockStyle.Fill;
            flpPendingOrders.Location = new Point(0, 0);
            flpPendingOrders.Name = "flpPendingOrders";
            flpPendingOrders.Size = new Size(800, 337);
            flpPendingOrders.TabIndex = 0;
            // 
            // flpCompletedOrders
            // 
            flpCompletedOrders.AutoScroll = true;
            flpCompletedOrders.Dock = DockStyle.Fill;
            flpCompletedOrders.Location = new Point(0, 0);
            flpCompletedOrders.Name = "flpCompletedOrders";
            flpCompletedOrders.Size = new Size(800, 337);
            flpCompletedOrders.TabIndex = 1;
            // 
            // frmKdsDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panle1);
            Name = "frmKdsDashboard";
            Text = "KDS";
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
    }
}