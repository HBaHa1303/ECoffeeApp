namespace ECoffee.Presentation.Forms
{
    partial class PromotionForm
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
            dtpEndDate = new DateTimePicker();
            label1 = new Label();
            tbDiscountAmount = new TextBox();
            tbDiscountPercent = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            label4 = new Label();
            ten = new Label();
            tbName = new TextBox();
            dtpStartDate = new DateTimePicker();
            cbType = new ComboBox();
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
            tableLayoutPanel2.Controls.Add(dtpEndDate, 1, 5);
            tableLayoutPanel2.Controls.Add(label1, 0, 5);
            tableLayoutPanel2.Controls.Add(tbDiscountAmount, 1, 3);
            tableLayoutPanel2.Controls.Add(tbDiscountPercent, 1, 2);
            tableLayoutPanel2.Controls.Add(label9, 0, 4);
            tableLayoutPanel2.Controls.Add(label8, 0, 3);
            tableLayoutPanel2.Controls.Add(label6, 0, 2);
            tableLayoutPanel2.Controls.Add(label4, 0, 1);
            tableLayoutPanel2.Controls.Add(ten, 0, 0);
            tableLayoutPanel2.Controls.Add(tbName, 1, 0);
            tableLayoutPanel2.Controls.Add(dtpStartDate, 1, 4);
            tableLayoutPanel2.Controls.Add(cbType, 1, 1);
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
            // dtpEndDate
            // 
            dtpEndDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpEndDate.CustomFormat = "dd/MM/yyyy";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(198, 346);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(257, 23);
            dtpEndDate.TabIndex = 17;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 347);
            label1.Name = "label1";
            label1.Size = new Size(106, 21);
            label1.TabIndex = 16;
            label1.Text = "Ngày kết thúc";
            // 
            // tbDiscountAmount
            // 
            tbDiscountAmount.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbDiscountAmount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbDiscountAmount.Location = new Point(198, 219);
            tbDiscountAmount.Name = "tbDiscountAmount";
            tbDiscountAmount.Size = new Size(257, 29);
            tbDiscountAmount.TabIndex = 14;
            // 
            // tbDiscountPercent
            // 
            tbDiscountPercent.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbDiscountPercent.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbDiscountPercent.Location = new Point(198, 158);
            tbDiscountPercent.Name = "tbDiscountPercent";
            tbDiscountPercent.Size = new Size(257, 29);
            tbDiscountPercent.TabIndex = 13;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(23, 284);
            label9.Name = "label9";
            label9.Size = new Size(103, 21);
            label9.TabIndex = 8;
            label9.Text = "Ngày bắt đầu";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(23, 223);
            label8.Name = "label8";
            label8.Size = new Size(127, 21);
            label8.TabIndex = 6;
            label8.Text = "Giảm giá cố định";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(23, 162);
            label6.Name = "label6";
            label6.Size = new Size(146, 21);
            label6.TabIndex = 4;
            label6.Text = "Phần trăm giảm giá";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(23, 101);
            label4.Name = "label4";
            label4.Size = new Size(124, 21);
            label4.TabIndex = 2;
            label4.Text = "Loại khuyến mãi";
            // 
            // ten
            // 
            ten.Anchor = AnchorStyles.Left;
            ten.AutoSize = true;
            ten.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ten.Location = new Point(23, 40);
            ten.Name = "ten";
            ten.Size = new Size(33, 21);
            ten.TabIndex = 0;
            ten.Text = "Tên";
            // 
            // tbName
            // 
            tbName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbName.Location = new Point(198, 36);
            tbName.Name = "tbName";
            tbName.Size = new Size(257, 29);
            tbName.TabIndex = 11;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(198, 283);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(257, 23);
            dtpStartDate.TabIndex = 15;
            // 
            // cbType
            // 
            cbType.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(198, 100);
            cbType.Name = "cbType";
            cbType.Size = new Size(257, 23);
            cbType.TabIndex = 18;
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
            // PromotionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 561);
            Controls.Add(tableLayoutPanel1);
            Name = "PromotionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Khuyến mãi";
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
        private Label ten;
        private TextBox tbDiscountAmount;
        private TextBox tbDiscountPercent;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label label4;
        private TextBox tbName;
        private DateTimePicker dtpStartDate;
        private TableLayoutPanel tableLayoutPanel3;
        private Button bCancel;
        private Button bSubmit;
        private DateTimePicker dtpEndDate;
        private Label label1;
        private ComboBox cbType;
    }
}