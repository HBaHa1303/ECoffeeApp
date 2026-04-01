namespace ECoffee.Presentation.Forms
{
    partial class PaymentDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel(); lTitle = new Label(); label1 = new Label(); label2 = new Label(); label3 = new Label(); label4 = new Label(); label5 = new Label(); label6 = new Label(); label7 = new Label(); lPaymentIdValue = new Label(); lOrderIdValue = new Label(); lMethodValue = new Label(); lAmountValue = new Label(); lStatusValue = new Label(); lTransactionValue = new Label(); lCreatedValue = new Label(); lUpdatedValue = new Label(); tbQrContent = new TextBox(); bClose = new Button(); tableLayoutPanel1.SuspendLayout(); SuspendLayout();
            tableLayoutPanel1.ColumnCount=2; tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,170F)); tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100F)); tableLayoutPanel1.Dock=DockStyle.Fill; tableLayoutPanel1.Padding=new Padding(16);
            tableLayoutPanel1.Controls.Add(lTitle,0,0); tableLayoutPanel1.SetColumnSpan(lTitle,2); lTitle.AutoSize=true; lTitle.Font=new Font("Segoe UI",16F,FontStyle.Bold); lTitle.Text="Chi tiết payment";
            string[] labels={"Payment Id","Order Id","Method","Amount","Status","Transaction Ref","Created At","Updated At"}; Label[] vals={lPaymentIdValue,lOrderIdValue,lMethodValue,lAmountValue,lStatusValue,lTransactionValue,lCreatedValue,lUpdatedValue};
            for(int i=0;i<labels.Length;i++){ var lab=new Label(){Text=labels[i],Anchor=AnchorStyles.Left,AutoSize=true}; tableLayoutPanel1.Controls.Add(lab,0,i+1); vals[i].Anchor=AnchorStyles.Left; vals[i].AutoSize=true; tableLayoutPanel1.Controls.Add(vals[i],1,i+1);} tableLayoutPanel1.Controls.Add(new Label(){Text="QR Content",Anchor=AnchorStyles.Left,AutoSize=true},0,9); tbQrContent.Multiline=true; tbQrContent.ReadOnly=true; tbQrContent.ScrollBars=ScrollBars.Vertical; tbQrContent.Height=100; tbQrContent.Dock=DockStyle.Fill; tableLayoutPanel1.Controls.Add(tbQrContent,1,9); bClose.Text="Đóng"; bClose.Anchor=AnchorStyles.Right; bClose.Click += bClose_Click; tableLayoutPanel1.Controls.Add(bClose,1,10);
            AutoScaleDimensions = new SizeF(9F,21F); AutoScaleMode=AutoScaleMode.Font; ClientSize=new Size(640,520); Controls.Add(tableLayoutPanel1); Font=new Font("Segoe UI",12F); FormBorderStyle=FormBorderStyle.FixedDialog; MaximizeBox=false; MinimizeBox=false; StartPosition=FormStartPosition.CenterParent; Text="Chi tiết payment"; Load += PaymentDetailForm_Load; tableLayoutPanel1.ResumeLayout(false); tableLayoutPanel1.PerformLayout(); ResumeLayout(false);
        }
        #endregion
        private TableLayoutPanel tableLayoutPanel1; private Label lTitle; private Label lPaymentIdValue; private Label lOrderIdValue; private Label lMethodValue; private Label lAmountValue; private Label lStatusValue; private Label lTransactionValue; private Label lCreatedValue; private Label lUpdatedValue; private TextBox tbQrContent; private Button bClose; private Label label1; private Label label2; private Label label3; private Label label4; private Label label5; private Label label6; private Label label7;
    }
}
