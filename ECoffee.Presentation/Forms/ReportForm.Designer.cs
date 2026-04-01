namespace ECoffee.Presentation.Forms
{
    partial class ReportForm
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
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            cbReportGranularity = new ComboBox();
            wv2Report = new Microsoft.Web.WebView2.WinForms.WebView2();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wv2Report).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(wv2Report, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(cbReportGranularity, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(794, 94);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(212, 28);
            label1.Name = "label1";
            label1.Size = new Size(210, 37);
            label1.TabIndex = 0;
            label1.Text = "Quản lý báo cáo";
            // 
            // cbReportGranularity
            // 
            cbReportGranularity.Anchor = AnchorStyles.Bottom;
            cbReportGranularity.AutoCompleteCustomSource.AddRange(new string[] { "Ngày", "Tuần", "Tháng ", "Năm" });
            cbReportGranularity.FormattingEnabled = true;
            cbReportGranularity.Location = new Point(654, 68);
            cbReportGranularity.Name = "cbReportGranularity";
            cbReportGranularity.Size = new Size(121, 23);
            cbReportGranularity.TabIndex = 1;
            cbReportGranularity.SelectedIndexChanged += cbReportGranularity_SelectedIndexChanged;
            // 
            // wv2Report
            // 
            wv2Report.AllowExternalDrop = true;
            wv2Report.CreationProperties = null;
            wv2Report.DefaultBackgroundColor = Color.White;
            wv2Report.Dock = DockStyle.Fill;
            wv2Report.Location = new Point(3, 103);
            wv2Report.Name = "wv2Report";
            wv2Report.Size = new Size(794, 344);
            wv2Report.TabIndex = 2;
            wv2Report.ZoomFactor = 1D;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý báo cáo";
            Load += ReportForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)wv2Report).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private ComboBox cbReportGranularity;
        private Microsoft.Web.WebView2.WinForms.WebView2 wv2Report;
    }
}