namespace ECoffee.Presentation.Forms
{
    partial class MenuEditForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            cboCategory = new ComboBox();
            label3 = new Label();
            nudPriceS = new NumericUpDown();
            label4 = new Label();
            nudPriceM = new NumericUpDown();
            label5 = new Label();
            nudPriceL = new NumericUpDown();
            label6 = new Label();
            nudQuantity = new NumericUpDown();
            label7 = new Label();
            nudReorder = new NumericUpDown();
            chkIsActive = new CheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPriceS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudReorder).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(txtName, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(cboCategory, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(nudPriceS, 1, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(nudPriceM, 1, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(nudPriceL, 1, 4);
            tableLayoutPanel1.Controls.Add(label6, 0, 5);
            tableLayoutPanel1.Controls.Add(nudQuantity, 1, 5);
            tableLayoutPanel1.Controls.Add(label7, 0, 6);
            tableLayoutPanel1.Controls.Add(nudReorder, 1, 6);
            tableLayoutPanel1.Controls.Add(chkIsActive, 1, 7);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 8);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(20);
            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(684, 495);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(23, 23);
            label1.Name = "label1";
            label1.Size = new Size(143, 45);
            label1.TabIndex = 0;
            label1.Text = "Tên món";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(203, 23);
            txtName.Name = "txtName";
            txtName.Size = new Size(458, 50);
            txtName.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(23, 75);
            label2.Name = "label2";
            label2.Size = new Size(158, 45);
            label2.TabIndex = 2;
            label2.Text = "Loại nước";
            // 
            // cboCategory
            // 
            cboCategory.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(203, 78);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(458, 53);
            cboCategory.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(23, 127);
            label3.Name = "label3";
            label3.Size = new Size(154, 45);
            label3.TabIndex = 4;
            label3.Text = "Giá size S";
            // 
            // nudPriceS
            // 
            nudPriceS.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudPriceS.Location = new Point(203, 127);
            nudPriceS.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudPriceS.Name = "nudPriceS";
            nudPriceS.Size = new Size(458, 50);
            nudPriceS.TabIndex = 5;
            nudPriceS.ThousandsSeparator = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(23, 179);
            label4.Name = "label4";
            label4.Size = new Size(166, 45);
            label4.TabIndex = 6;
            label4.Text = "Giá size M";
            // 
            // nudPriceM
            // 
            nudPriceM.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudPriceM.Location = new Point(203, 179);
            nudPriceM.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudPriceM.Name = "nudPriceM";
            nudPriceM.Size = new Size(458, 50);
            nudPriceM.TabIndex = 7;
            nudPriceM.ThousandsSeparator = true;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(23, 231);
            label5.Name = "label5";
            label5.Size = new Size(152, 45);
            label5.TabIndex = 8;
            label5.Text = "Giá size L";
            // 
            // nudPriceL
            // 
            nudPriceL.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudPriceL.Location = new Point(203, 231);
            nudPriceL.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudPriceL.Name = "nudPriceL";
            nudPriceL.Size = new Size(458, 50);
            nudPriceL.TabIndex = 9;
            nudPriceL.ThousandsSeparator = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(23, 280);
            label6.Name = "label6";
            label6.Size = new Size(157, 52);
            label6.TabIndex = 10;
            label6.Text = "Số lượng tồn kho";
            // 
            // nudQuantity
            // 
            nudQuantity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudQuantity.Location = new Point(203, 283);
            nudQuantity.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(458, 50);
            nudQuantity.TabIndex = 11;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(23, 332);
            label7.Name = "label7";
            label7.Size = new Size(172, 52);
            label7.TabIndex = 12;
            label7.Text = "Mức nhập lại";
            // 
            // nudReorder
            // 
            nudReorder.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudReorder.Location = new Point(203, 335);
            nudReorder.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudReorder.Name = "nudReorder";
            nudReorder.Size = new Size(458, 50);
            nudReorder.TabIndex = 13;
            // 
            // chkIsActive
            // 
            chkIsActive.Anchor = AnchorStyles.Left;
            chkIsActive.AutoSize = true;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Location = new Point(203, 387);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(189, 39);
            chkIsActive.TabIndex = 14;
            chkIsActive.Text = "Đang bán";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(203, 432);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(458, 40);
            flowLayoutPanel1.TabIndex = 15;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(355, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(249, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // MenuEditForm
            // 
            AutoScaleDimensions = new SizeF(18F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 495);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F);
            Name = "MenuEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm món";
            Load += MenuEditForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPriceS).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceM).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceL).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudReorder).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox txtName;
        private Label label2;
        private ComboBox cboCategory;
        private Label label3;
        private NumericUpDown nudPriceS;
        private Label label4;
        private NumericUpDown nudPriceM;
        private Label label5;
        private NumericUpDown nudPriceL;
        private Label label6;
        private NumericUpDown nudQuantity;
        private Label label7;
        private NumericUpDown nudReorder;
        private CheckBox chkIsActive;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnSave;
        private Button btnCancel;
    }
}
