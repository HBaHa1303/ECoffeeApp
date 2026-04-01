namespace ECoffee.Presentation.Forms
{
    partial class SelectRoleForm
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
            label1 = new Label();
            bOk = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            label2 = new Label();
            cbRoles = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(bOk, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(384, 161);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(62, 3);
            label1.Name = "label1";
            label1.Size = new Size(259, 42);
            label1.TabIndex = 0;
            label1.Text = "Bạn có nhiều hơn 1 vai trò.\r\nVui lòng chọn vai trò muốn sử dụng";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bOk
            // 
            bOk.Anchor = AnchorStyles.None;
            bOk.Location = new Point(152, 126);
            bOk.Name = "bOk";
            bOk.Size = new Size(80, 28);
            bOk.TabIndex = 1;
            bOk.Text = "Sử dụng";
            bOk.UseVisualStyleBackColor = true;
            bOk.Click += bOk_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(cbRoles, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 51);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(378, 66);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 22);
            label2.Name = "label2";
            label2.Size = new Size(55, 21);
            label2.TabIndex = 1;
            label2.Text = "Vai trò";
            // 
            // cbRoles
            // 
            cbRoles.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbRoles.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbRoles.FormattingEnabled = true;
            cbRoles.Location = new Point(154, 18);
            cbRoles.Name = "cbRoles";
            cbRoles.Size = new Size(221, 29);
            cbRoles.TabIndex = 2;
            // 
            // SelectRoleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 161);
            Controls.Add(tableLayoutPanel1);
            Name = "SelectRoleForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chọn vai trò";
            Load += SelectRoleForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Button bOk;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private ComboBox cbRoles;
    }
}