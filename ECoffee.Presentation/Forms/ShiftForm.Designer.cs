namespace ECoffee.Presentation.Forms
{
    partial class ShiftForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblStatus = new Label();
            lblInfo = new Label();
            lblOpeningCash = new Label();
            tbOpeningCash = new TextBox();
            bOpenShift = new Button();
            lblClosingCash = new Label();
            tbClosingCash = new TextBox();
            bCloseShift = new Button();
            SuspendLayout();
            //
            // lblStatus
            //
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            lblStatus.Location = new Point(20, 20);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(150, 38);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Trạng thái";
            //
            // lblInfo
            //
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 10.8F);
            lblInfo.Location = new Point(20, 70);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(200, 25);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "Thông tin ca";
            //
            // lblOpeningCash
            //
            lblOpeningCash.AutoSize = true;
            lblOpeningCash.Location = new Point(20, 150);
            lblOpeningCash.Name = "lblOpeningCash";
            lblOpeningCash.Size = new Size(85, 21);
            lblOpeningCash.TabIndex = 2;
            lblOpeningCash.Text = "Tiền mở ca";
            //
            // tbOpeningCash
            //
            tbOpeningCash.Location = new Point(120, 147);
            tbOpeningCash.Name = "tbOpeningCash";
            tbOpeningCash.PlaceholderText = "0";
            tbOpeningCash.Size = new Size(200, 29);
            tbOpeningCash.TabIndex = 3;
            //
            // bOpenShift
            //
            bOpenShift.Location = new Point(335, 145);
            bOpenShift.Name = "bOpenShift";
            bOpenShift.Size = new Size(100, 32);
            bOpenShift.TabIndex = 4;
            bOpenShift.Text = "Mở ca";
            bOpenShift.UseVisualStyleBackColor = true;
            bOpenShift.Click += bOpenShift_Click;
            //
            // lblClosingCash
            //
            lblClosingCash.AutoSize = true;
            lblClosingCash.Location = new Point(20, 200);
            lblClosingCash.Name = "lblClosingCash";
            lblClosingCash.Size = new Size(87, 21);
            lblClosingCash.TabIndex = 5;
            lblClosingCash.Text = "Tiền đóng ca";
            //
            // tbClosingCash
            //
            tbClosingCash.Location = new Point(120, 197);
            tbClosingCash.Name = "tbClosingCash";
            tbClosingCash.PlaceholderText = "0";
            tbClosingCash.Size = new Size(200, 29);
            tbClosingCash.TabIndex = 6;
            //
            // bCloseShift
            //
            bCloseShift.Location = new Point(335, 195);
            bCloseShift.Name = "bCloseShift";
            bCloseShift.Size = new Size(100, 32);
            bCloseShift.TabIndex = 7;
            bCloseShift.Text = "Đóng ca";
            bCloseShift.UseVisualStyleBackColor = true;
            bCloseShift.Click += bCloseShift_Click;
            //
            // ShiftForm
            //
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 260);
            Controls.Add(bCloseShift);
            Controls.Add(tbClosingCash);
            Controls.Add(lblClosingCash);
            Controls.Add(bOpenShift);
            Controls.Add(tbOpeningCash);
            Controls.Add(lblOpeningCash);
            Controls.Add(lblInfo);
            Controls.Add(lblStatus);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ShiftForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý ca làm việc";
            Load += ShiftForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private Label lblInfo;
        private Label lblOpeningCash;
        private TextBox tbOpeningCash;
        private Button bOpenShift;
        private Label lblClosingCash;
        private TextBox tbClosingCash;
        private Button bCloseShift;
    }
}
