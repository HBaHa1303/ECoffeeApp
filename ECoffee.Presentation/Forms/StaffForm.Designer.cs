namespace ECoffee.Presentation.Forms
{
    partial class StaffForm
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
            lHeader = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            tbAddress = new TextBox();
            tbFullName = new TextBox();
            tbPassword = new TextBox();
            label12 = new Label();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            label4 = new Label();
            label2 = new Label();
            tbEmail = new TextBox();
            dtpDateOfBirth = new DateTimePicker();
            clbRoles = new CheckedListBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            bCancel = new Button();
            bSubmit = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lHeader, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(484, 561);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lHeader
            // 
            lHeader.Anchor = AnchorStyles.None;
            lHeader.AutoSize = true;
            lHeader.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lHeader.Location = new Point(197, 33);
            lHeader.Name = "lHeader";
            lHeader.Size = new Size(90, 37);
            lHeader.TabIndex = 0;
            lHeader.Text = "label1";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel2.Controls.Add(tbAddress, 1, 3);
            tableLayoutPanel2.Controls.Add(tbFullName, 1, 2);
            tableLayoutPanel2.Controls.Add(tbPassword, 1, 1);
            tableLayoutPanel2.Controls.Add(label12, 0, 5);
            tableLayoutPanel2.Controls.Add(label9, 0, 4);
            tableLayoutPanel2.Controls.Add(label8, 0, 3);
            tableLayoutPanel2.Controls.Add(label6, 0, 2);
            tableLayoutPanel2.Controls.Add(label4, 0, 1);
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(tbEmail, 1, 0);
            tableLayoutPanel2.Controls.Add(dtpDateOfBirth, 1, 4);
            tableLayoutPanel2.Controls.Add(clbRoles, 1, 5);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 107);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(20);
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666718F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel2.Size = new Size(478, 410);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // tbAddress
            // 
            tbAddress.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbAddress.Location = new Point(198, 219);
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(257, 29);
            tbAddress.TabIndex = 14;
            // 
            // tbFullName
            // 
            tbFullName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbFullName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbFullName.Location = new Point(198, 158);
            tbFullName.Name = "tbFullName";
            tbFullName.Size = new Size(257, 29);
            tbFullName.TabIndex = 13;
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPassword.Location = new Point(198, 97);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(257, 29);
            tbPassword.TabIndex = 12;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Left;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(23, 347);
            label12.Name = "label12";
            label12.Size = new Size(55, 21);
            label12.TabIndex = 10;
            label12.Text = "Vai trò";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(23, 284);
            label9.Name = "label9";
            label9.Size = new Size(80, 21);
            label9.TabIndex = 8;
            label9.Text = "Ngày sinh";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(23, 223);
            label8.Name = "label8";
            label8.Size = new Size(57, 21);
            label8.TabIndex = 6;
            label8.Text = "Địa chỉ";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(23, 162);
            label6.Name = "label6";
            label6.Size = new Size(56, 21);
            label6.TabIndex = 4;
            label6.Text = "Họ tên";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(23, 101);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 2;
            label4.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 40);
            label2.Name = "label2";
            label2.Size = new Size(48, 21);
            label2.TabIndex = 0;
            label2.Text = "Email";
            // 
            // tbEmail
            // 
            tbEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbEmail.Location = new Point(198, 36);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(257, 29);
            tbEmail.TabIndex = 11;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpDateOfBirth.CustomFormat = "dd/MM/yyyy";
            dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtpDateOfBirth.Location = new Point(198, 283);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(257, 23);
            dtpDateOfBirth.TabIndex = 15;
            // 
            // clbRoles
            // 
            clbRoles.Dock = DockStyle.Fill;
            clbRoles.FormattingEnabled = true;
            clbRoles.Location = new Point(198, 328);
            clbRoles.Name = "clbRoles";
            clbRoles.Size = new Size(257, 59);
            clbRoles.TabIndex = 16;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(bCancel, 0, 0);
            tableLayoutPanel3.Controls.Add(bSubmit, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 523);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(478, 35);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // bCancel
            // 
            bCancel.Anchor = AnchorStyles.None;
            bCancel.Location = new Point(82, 6);
            bCancel.Name = "bCancel";
            bCancel.Size = new Size(75, 23);
            bCancel.TabIndex = 1;
            bCancel.Text = "Hủy";
            bCancel.UseVisualStyleBackColor = true;
            bCancel.Click += bCancel_Click;
            // 
            // bSubmit
            // 
            bSubmit.Anchor = AnchorStyles.None;
            bSubmit.Location = new Point(321, 6);
            bSubmit.Name = "bSubmit";
            bSubmit.Size = new Size(75, 23);
            bSubmit.TabIndex = 0;
            bSubmit.Text = "Tạo mới";
            bSubmit.UseVisualStyleBackColor = true;
            bSubmit.Click += bSubmit_Click;
            // 
            // StaffForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 561);
            Controls.Add(tableLayoutPanel1);
            Name = "StaffForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "StaffForm";
            Load += StaffForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lHeader;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private TextBox tbAddress;
        private TextBox tbFullName;
        private TextBox tbPassword;
        private Label label12;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label label4;
        private TextBox tbEmail;
        private DateTimePicker dtpDateOfBirth;
        private TableLayoutPanel tableLayoutPanel3;
        private Button bCancel;
        private Button bSubmit;
        private CheckedListBox clbRoles;
    }
}