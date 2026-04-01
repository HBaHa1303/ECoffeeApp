namespace ECoffee.Presentation
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            bLogin = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            tbPassword = new TextBox();
            label3 = new Label();
            label1 = new Label();
            tbEmail = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(bLogin, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Size = new Size(484, 161);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // bLogin
            // 
            bLogin.Anchor = AnchorStyles.Right;
            bLogin.Location = new Point(348, 120);
            bLogin.Margin = new Padding(4, 4, 40, 4);
            bLogin.Name = "bLogin";
            bLogin.Size = new Size(96, 32);
            bLogin.TabIndex = 0;
            bLogin.Text = "Đăng nhập";
            bLogin.UseVisualStyleBackColor = true;
            bLogin.Click += bLogin_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel2.Controls.Add(tbPassword, 1, 1);
            tableLayoutPanel2.Controls.Add(label3, 0, 1);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(tbEmail, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(4, 4);
            tableLayoutPanel2.Margin = new Padding(4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(20, 0, 20, 0);
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(476, 104);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbPassword.Location = new Point(197, 63);
            tbPassword.Name = "tbPassword";
            tbPassword.PlaceholderText = "Nhập mật khẩu";
            tbPassword.Size = new Size(256, 29);
            tbPassword.TabIndex = 4;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(23, 67);
            label3.Name = "label3";
            label3.Size = new Size(75, 21);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(23, 15);
            label1.Name = "label1";
            label1.Size = new Size(48, 21);
            label1.TabIndex = 0;
            label1.Text = "Email";
            // 
            // tbEmail
            // 
            tbEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbEmail.Location = new Point(197, 11);
            tbEmail.Name = "tbEmail";
            tbEmail.PlaceholderText = "Nhập email";
            tbEmail.Size = new Size(256, 29);
            tbEmail.TabIndex = 3;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 161);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Load += LoginForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button bLogin;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private Label label3;
        private TextBox tbEmail;
        private TextBox tbPassword;
    }
}
