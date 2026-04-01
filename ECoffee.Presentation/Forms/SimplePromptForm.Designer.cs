namespace ECoffee.Presentation.Forms
{
    partial class SimplePromptForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel(); lTitle = new Label(); tbValue = new TextBox(); panelButtons = new FlowLayoutPanel(); bOk = new Button(); bCancel = new Button(); tableLayoutPanel1.SuspendLayout(); panelButtons.SuspendLayout(); SuspendLayout();
            tableLayoutPanel1.ColumnCount=1; tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100F)); tableLayoutPanel1.Controls.Add(lTitle,0,0); tableLayoutPanel1.Controls.Add(tbValue,0,1); tableLayoutPanel1.Controls.Add(panelButtons,0,2); tableLayoutPanel1.Dock=DockStyle.Fill; tableLayoutPanel1.Padding=new Padding(16); lTitle.AutoSize=true; tbValue.Dock=DockStyle.Fill; panelButtons.Dock=DockStyle.Fill; panelButtons.FlowDirection=FlowDirection.RightToLeft; panelButtons.Controls.AddRange(new Control[]{bOk,bCancel}); bOk.Text="OK"; bOk.Click += bOk_Click; bCancel.Text="Hủy"; bCancel.Click += bCancel_Click; AutoScaleDimensions = new SizeF(9F,21F); AutoScaleMode=AutoScaleMode.Font; ClientSize=new Size(460,180); Controls.Add(tableLayoutPanel1); Font=new Font("Segoe UI",12F); StartPosition=FormStartPosition.CenterParent; Text="Nhập dữ liệu"; tableLayoutPanel1.ResumeLayout(false); tableLayoutPanel1.PerformLayout(); panelButtons.ResumeLayout(false); ResumeLayout(false);
        }
        #endregion
        private TableLayoutPanel tableLayoutPanel1; private Label lTitle; private TextBox tbValue; private FlowLayoutPanel panelButtons; private Button bOk; private Button bCancel;
    }
}
