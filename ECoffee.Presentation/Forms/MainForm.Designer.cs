namespace ECoffee.Presentation.Forms
{
    partial class MainForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            tsmiLogout = new ToolStripMenuItem();
            tsmiExit = new ToolStripMenuItem();
            quảnLýToolStripMenuItem = new ToolStripMenuItem();
            tsmiStaffManagement = new ToolStripMenuItem();
            khuyếnMãiToolStripMenuItem = new ToolStripMenuItem();
            đơnHàngToolStripMenuItem = new ToolStripMenuItem();
            thanhToánToolStripMenuItem = new ToolStripMenuItem();
            khoToolStripMenuItem = new ToolStripMenuItem();
            menuToolStripMenuItem = new ToolStripMenuItem();
            loạiMenuToolStripMenuItem = new ToolStripMenuItem();
            báoCáoToolStripMenuItem = new ToolStripMenuItem();
            nhânViênToolStripMenuItem1 = new ToolStripMenuItem();
            tsmiReportOrder = new ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(menuStrip1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1029, 630);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, quảnLýToolStripMenuItem, báoCáoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1029, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiLogout, tsmiExit });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(72, 20);
            hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // tsmiLogout
            // 
            tsmiLogout.Name = "tsmiLogout";
            tsmiLogout.Size = new Size(129, 22);
            tsmiLogout.Text = "Đăng Xuất";
            tsmiLogout.Click += tsmiLogout_Click;
            // 
            // tsmiExit
            // 
            tsmiExit.Name = "tsmiExit";
            tsmiExit.Size = new Size(129, 22);
            tsmiExit.Text = "Thoát";
            tsmiExit.Click += tsmiExit_Click;
            // 
            // quảnLýToolStripMenuItem
            // 
            quảnLýToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiStaffManagement, khuyếnMãiToolStripMenuItem, đơnHàngToolStripMenuItem, thanhToánToolStripMenuItem, khoToolStripMenuItem, menuToolStripMenuItem, loạiMenuToolStripMenuItem });
            quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            quảnLýToolStripMenuItem.Size = new Size(60, 20);
            quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // tsmiStaffManagement
            // 
            tsmiStaffManagement.Name = "tsmiStaffManagement";
            tsmiStaffManagement.Size = new Size(137, 22);
            tsmiStaffManagement.Text = "Nhân viên";
            tsmiStaffManagement.Click += tsmiStaffManagement_Click;
            // 
            // khuyếnMãiToolStripMenuItem
            // 
            khuyếnMãiToolStripMenuItem.Name = "khuyếnMãiToolStripMenuItem";
            khuyếnMãiToolStripMenuItem.Size = new Size(137, 22);
            khuyếnMãiToolStripMenuItem.Text = "Khuyến mãi";
            // 
            // đơnHàngToolStripMenuItem
            // 
            đơnHàngToolStripMenuItem.Name = "đơnHàngToolStripMenuItem";
            đơnHàngToolStripMenuItem.Size = new Size(137, 22);
            đơnHàngToolStripMenuItem.Text = "Đơn hàng";
            // 
            // thanhToánToolStripMenuItem
            // 
            thanhToánToolStripMenuItem.Name = "thanhToánToolStripMenuItem";
            thanhToánToolStripMenuItem.Size = new Size(137, 22);
            thanhToánToolStripMenuItem.Text = "Thanh toán";
            // 
            // khoToolStripMenuItem
            // 
            khoToolStripMenuItem.Name = "khoToolStripMenuItem";
            khoToolStripMenuItem.Size = new Size(137, 22);
            khoToolStripMenuItem.Text = "Kho";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(137, 22);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // loạiMenuToolStripMenuItem
            // 
            loạiMenuToolStripMenuItem.Name = "loạiMenuToolStripMenuItem";
            loạiMenuToolStripMenuItem.Size = new Size(137, 22);
            loạiMenuToolStripMenuItem.Text = "Loại nước";
            // 
            // báoCáoToolStripMenuItem
            // 
            báoCáoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nhânViênToolStripMenuItem1, tsmiReportOrder });
            báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            báoCáoToolStripMenuItem.Size = new Size(63, 20);
            báoCáoToolStripMenuItem.Text = "Báo Cáo";
            // 
            // nhânViênToolStripMenuItem1
            // 
            nhânViênToolStripMenuItem1.Name = "nhânViênToolStripMenuItem1";
            nhânViênToolStripMenuItem1.Size = new Size(180, 22);
            nhânViênToolStripMenuItem1.Text = "Nhân viên";
            // 
            // tsmiReportOrder
            // 
            tsmiReportOrder.Name = "tsmiReportOrder";
            tsmiReportOrder.Size = new Size(180, 22);
            tsmiReportOrder.Text = "Đơn hàng";
            tsmiReportOrder.Click += tsmiReportOrder_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 630);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ECoffee";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem tsmiLogout;
        private ToolStripMenuItem tsmiExit;
        private ToolStripMenuItem quảnLýToolStripMenuItem;
        private ToolStripMenuItem tsmiStaffManagement;
        private ToolStripMenuItem khuyếnMãiToolStripMenuItem;
        private ToolStripMenuItem đơnHàngToolStripMenuItem;
        private ToolStripMenuItem thanhToánToolStripMenuItem;
        private ToolStripMenuItem khoToolStripMenuItem;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem loạiMenuToolStripMenuItem;
        private ToolStripMenuItem báoCáoToolStripMenuItem;
        private ToolStripMenuItem nhânViênToolStripMenuItem1;
        private ToolStripMenuItem tsmiReportOrder;
    }
}