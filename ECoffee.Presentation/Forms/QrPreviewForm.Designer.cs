namespace ECoffee.Presentation.Forms
{
    partial class QrPreviewForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel(); lTitle = new Label(); tbQrAscii = new TextBox(); bClose = new Button(); tableLayoutPanel1.SuspendLayout(); SuspendLayout();
            tableLayoutPanel1.ColumnCount=1; tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100F)); tableLayoutPanel1.Controls.Add(lTitle,0,0); tableLayoutPanel1.Controls.Add(tbQrAscii,0,1); tableLayoutPanel1.Controls.Add(bClose,0,2); tableLayoutPanel1.Dock=DockStyle.Fill; tableLayoutPanel1.Padding=new Padding(16);
            lTitle.AutoSize=true; lTitle.Font=new Font("Segoe UI",16F,FontStyle.Bold); lTitle.Text="QR thanh toán"; tbQrAscii.Dock=DockStyle.Fill; tbQrAscii.Multiline=true; tbQrAscii.ReadOnly=true; tbQrAscii.ScrollBars=ScrollBars.Both; tbQrAscii.Font=new Font("Consolas",12F); bClose.Text="Đóng"; bClose.Anchor=AnchorStyles.Right; bClose.Click += bClose_Click;
            AutoScaleDimensions = new SizeF(9F,21F); AutoScaleMode=AutoScaleMode.Font; ClientSize=new Size(600,500); Controls.Add(tableLayoutPanel1); Font=new Font("Segoe UI",12F); StartPosition=FormStartPosition.CenterParent; Text="QR thanh toán"; Load += QrPreviewForm_Load; tableLayoutPanel1.ResumeLayout(false); tableLayoutPanel1.PerformLayout(); ResumeLayout(false);
        }
        #endregion
        private TableLayoutPanel tableLayoutPanel1; private Label lTitle; private TextBox tbQrAscii; private Button bClose;
    }
}
