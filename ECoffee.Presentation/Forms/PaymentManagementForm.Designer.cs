namespace ECoffee.Presentation.Forms
{
    partial class PaymentManagementForm
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
            lblTitle = new Label();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            tlpCreate = new TableLayoutPanel();
            label1 = new Label();
            nudOrderId = new NumericUpDown();
            label2 = new Label();
            cboMethod = new ComboBox();
            label3 = new Label();
            nudAmount = new NumericUpDown();
            label4 = new Label();
            txtTransactionRef = new TextBox();
            label5 = new Label();
            txtBankName = new TextBox();
            label6 = new Label();
            txtAccountNo = new TextBox();
            label7 = new Label();
            txtAccountName = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnCreatePayment = new Button();
            btnGenerateQr = new Button();
            picQr = new PictureBox();
            groupBox2 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label8 = new Label();
            txtSearch = new TextBox();
            btnCheckSuccess = new Button();
            dgvPayments = new DataGridView();
            PaymentId = new DataGridViewTextBoxColumn();
            OrderId = new DataGridViewTextBoxColumn();
            Method = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            TransactionRef = new DataGridViewTextBoxColumn();
            CreatedAt = new DataGridViewTextBoxColumn();
            ViewPayment = new DataGridViewButtonColumn();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            tlpCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudOrderId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQr).BeginInit();
            groupBox2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblTitle, 0, 0);
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(12);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1400, 760);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Left;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(15, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(311, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ THANH TOÁN";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(15, 79);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Size = new Size(1370, 666);
            splitContainer1.SplitterDistance = 430;
            splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tlpCreate);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(430, 666);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tạo payment / Tạo QR";
            // 
            // tlpCreate
            // 
            tlpCreate.ColumnCount = 2;
            tlpCreate.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
            tlpCreate.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpCreate.Controls.Add(label1, 0, 0);
            tlpCreate.Controls.Add(nudOrderId, 1, 0);
            tlpCreate.Controls.Add(label2, 0, 1);
            tlpCreate.Controls.Add(cboMethod, 1, 1);
            tlpCreate.Controls.Add(label3, 0, 2);
            tlpCreate.Controls.Add(nudAmount, 1, 2);
            tlpCreate.Controls.Add(label4, 0, 3);
            tlpCreate.Controls.Add(txtTransactionRef, 1, 3);
            tlpCreate.Controls.Add(label5, 0, 4);
            tlpCreate.Controls.Add(txtBankName, 1, 4);
            tlpCreate.Controls.Add(label6, 0, 5);
            tlpCreate.Controls.Add(txtAccountNo, 1, 5);
            tlpCreate.Controls.Add(label7, 0, 6);
            tlpCreate.Controls.Add(txtAccountName, 1, 6);
            tlpCreate.Controls.Add(flowLayoutPanel1, 1, 7);
            tlpCreate.Controls.Add(picQr, 0, 8);
            tlpCreate.Dock = DockStyle.Fill;
            tlpCreate.Location = new Point(3, 25);
            tlpCreate.Name = "tlpCreate";
            tlpCreate.Padding = new Padding(10);
            tlpCreate.RowCount = 9;
            tlpCreate.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tlpCreate.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tlpCreate.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tlpCreate.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tlpCreate.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tlpCreate.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tlpCreate.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tlpCreate.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tlpCreate.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCreate.Size = new Size(424, 638);
            tlpCreate.TabIndex = 0;
            tlpCreate.SetColumnSpan(picQr, 2);
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(13, 23);
            label1.Name = "label1";
            label1.Size = new Size(67, 21);
            label1.TabIndex = 0;
            label1.Text = "Order ID";
            // 
            // nudOrderId
            // 
            nudOrderId.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudOrderId.Location = new Point(148, 19);
            nudOrderId.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudOrderId.Name = "nudOrderId";
            nudOrderId.Size = new Size(263, 29);
            nudOrderId.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(13, 71);
            label2.Name = "label2";
            label2.Size = new Size(79, 21);
            label2.TabIndex = 2;
            label2.Text = "Phương thức";
            // 
            // cboMethod
            // 
            cboMethod.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMethod.FormattingEnabled = true;
            cboMethod.Location = new Point(148, 67);
            cboMethod.Name = "cboMethod";
            cboMethod.Size = new Size(263, 29);
            cboMethod.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(13, 119);
            label3.Name = "label3";
            label3.Size = new Size(65, 21);
            label3.TabIndex = 4;
            label3.Text = "Số tiền";
            // 
            // nudAmount
            // 
            nudAmount.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudAmount.Location = new Point(148, 115);
            nudAmount.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(263, 29);
            nudAmount.TabIndex = 5;
            nudAmount.ThousandsSeparator = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(13, 167);
            label4.Name = "label4";
            label4.Size = new Size(103, 21);
            label4.TabIndex = 6;
            label4.Text = "TransactionRef";
            // 
            // txtTransactionRef
            // 
            txtTransactionRef.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTransactionRef.Location = new Point(148, 163);
            txtTransactionRef.Name = "txtTransactionRef";
            txtTransactionRef.Size = new Size(263, 29);
            txtTransactionRef.TabIndex = 7;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(13, 215);
            label5.Name = "label5";
            label5.Size = new Size(76, 21);
            label5.TabIndex = 8;
            label5.Text = "Tên ngân hàng";
            // 
            // txtBankName
            // 
            txtBankName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBankName.Location = new Point(148, 211);
            txtBankName.Name = "txtBankName";
            txtBankName.Size = new Size(263, 29);
            txtBankName.TabIndex = 9;
            txtBankName.Text = "MBBank";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(13, 263);
            label6.Name = "label6";
            label6.Size = new Size(96, 21);
            label6.TabIndex = 10;
            label6.Text = "Số tài khoản";
            // 
            // txtAccountNo
            // 
            txtAccountNo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtAccountNo.Location = new Point(148, 259);
            txtAccountNo.Name = "txtAccountNo";
            txtAccountNo.Size = new Size(263, 29);
            txtAccountNo.TabIndex = 11;
            txtAccountNo.Text = "0123456789";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(13, 311);
            label7.Name = "label7";
            label7.Size = new Size(102, 21);
            label7.TabIndex = 12;
            label7.Text = "Tên thụ hưởng";
            // 
            // txtAccountName
            // 
            txtAccountName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtAccountName.Location = new Point(148, 307);
            txtAccountName.Name = "txtAccountName";
            txtAccountName.Size = new Size(263, 29);
            txtAccountName.TabIndex = 13;
            txtAccountName.Text = "E.Coffee";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnCreatePayment);
            flowLayoutPanel1.Controls.Add(btnGenerateQr);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(148, 349);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(263, 50);
            flowLayoutPanel1.TabIndex = 14;
            // 
            // btnCreatePayment
            // 
            btnCreatePayment.Location = new Point(160, 3);
            btnCreatePayment.Name = "btnCreatePayment";
            btnCreatePayment.Size = new Size(100, 35);
            btnCreatePayment.TabIndex = 0;
            btnCreatePayment.Text = "Tạo payment";
            btnCreatePayment.UseVisualStyleBackColor = true;
            btnCreatePayment.Click += btnCreatePayment_Click;
            // 
            // btnGenerateQr
            // 
            btnGenerateQr.Location = new Point(54, 3);
            btnGenerateQr.Name = "btnGenerateQr";
            btnGenerateQr.Size = new Size(100, 35);
            btnGenerateQr.TabIndex = 1;
            btnGenerateQr.Text = "Tạo QR";
            btnGenerateQr.UseVisualStyleBackColor = true;
            btnGenerateQr.Click += btnGenerateQr_Click;
            // 
            // picQr
            // 
            picQr.BorderStyle = BorderStyle.FixedSingle;
            picQr.Dock = DockStyle.Fill;
            picQr.Location = new Point(13, 405);
            picQr.Name = "picQr";
            picQr.Size = new Size(398, 220);
            picQr.SizeMode = PictureBoxSizeMode.Zoom;
            picQr.TabIndex = 15;
            picQr.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tableLayoutPanel2);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(936, 666);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách payment / Xem / Check thành công";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190F));
            tableLayoutPanel2.Controls.Add(label8, 0, 0);
            tableLayoutPanel2.Controls.Add(txtSearch, 1, 0);
            tableLayoutPanel2.Controls.Add(btnCheckSuccess, 2, 0);
            tableLayoutPanel2.Controls.Add(dgvPayments, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 25);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(10);
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.SetColumnSpan(dgvPayments, 3);
            tableLayoutPanel2.Size = new Size(930, 638);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Location = new Point(13, 24);
            label8.Name = "label8";
            label8.Size = new Size(78, 21);
            label8.TabIndex = 0;
            label8.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(113, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập orderId hoặc transactionRef...";
            txtSearch.Size = new Size(614, 29);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnCheckSuccess
            // 
            btnCheckSuccess.Anchor = AnchorStyles.Right;
            btnCheckSuccess.Location = new Point(736, 17);
            btnCheckSuccess.Name = "btnCheckSuccess";
            btnCheckSuccess.Size = new Size(181, 35);
            btnCheckSuccess.TabIndex = 2;
            btnCheckSuccess.Text = "Check thanh toán thành công";
            btnCheckSuccess.UseVisualStyleBackColor = true;
            btnCheckSuccess.Click += btnCheckSuccess_Click;
            // 
            // dgvPayments
            // 
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayments.Columns.AddRange(new DataGridViewColumn[] { PaymentId, OrderId, Method, Amount, Status, TransactionRef, CreatedAt, ViewPayment });
            dgvPayments.Dock = DockStyle.Fill;
            dgvPayments.Location = new Point(13, 63);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.ReadOnly = true;
            dgvPayments.RowTemplate.Height = 28;
            dgvPayments.Size = new Size(904, 562);
            dgvPayments.TabIndex = 3;
            dgvPayments.CellContentClick += dgvPayments_CellContentClick;
            // 
            // PaymentId
            // 
            PaymentId.DataPropertyName = "Id";
            PaymentId.HeaderText = "PaymentId";
            PaymentId.Name = "PaymentId";
            PaymentId.ReadOnly = true;
            PaymentId.Width = 90;
            // 
            // OrderId
            // 
            OrderId.DataPropertyName = "OrderId";
            OrderId.HeaderText = "OrderId";
            OrderId.Name = "OrderId";
            OrderId.ReadOnly = true;
            OrderId.Width = 90;
            // 
            // Method
            // 
            Method.DataPropertyName = "Method";
            Method.HeaderText = "Method";
            Method.Name = "Method";
            Method.ReadOnly = true;
            Method.Width = 120;
            // 
            // Amount
            // 
            Amount.DataPropertyName = "Amount";
            Amount.HeaderText = "Amount";
            Amount.Name = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 120;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // TransactionRef
            // 
            TransactionRef.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TransactionRef.DataPropertyName = "TransactionRef";
            TransactionRef.HeaderText = "TransactionRef";
            TransactionRef.Name = "TransactionRef";
            TransactionRef.ReadOnly = true;
            // 
            // CreatedAt
            // 
            CreatedAt.DataPropertyName = "CreatedAt";
            CreatedAt.HeaderText = "CreatedAt";
            CreatedAt.Name = "CreatedAt";
            CreatedAt.ReadOnly = true;
            CreatedAt.Width = 150;
            // 
            // ViewPayment
            // 
            ViewPayment.HeaderText = "";
            ViewPayment.Name = "ViewPayment";
            ViewPayment.ReadOnly = true;
            ViewPayment.Text = "Xem";
            ViewPayment.UseColumnTextForButtonValue = true;
            ViewPayment.Width = 80;
            // 
            // PaymentManagementForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 760);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F);
            Name = "PaymentManagementForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý thanh toán";
            WindowState = FormWindowState.Maximized;
            Load += PaymentManagementForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tlpCreate.ResumeLayout(false);
            tlpCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudOrderId).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picQr).EndInit();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblTitle;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private TableLayoutPanel tlpCreate;
        private Label label1;
        private NumericUpDown nudOrderId;
        private Label label2;
        private ComboBox cboMethod;
        private Label label3;
        private NumericUpDown nudAmount;
        private Label label4;
        private TextBox txtTransactionRef;
        private Label label5;
        private TextBox txtBankName;
        private Label label6;
        private TextBox txtAccountNo;
        private Label label7;
        private TextBox txtAccountName;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnCreatePayment;
        private Button btnGenerateQr;
        private PictureBox picQr;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label8;
        private TextBox txtSearch;
        private Button btnCheckSuccess;
        private DataGridView dgvPayments;
        private DataGridViewTextBoxColumn PaymentId;
        private DataGridViewTextBoxColumn OrderId;
        private DataGridViewTextBoxColumn Method;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn TransactionRef;
        private DataGridViewTextBoxColumn CreatedAt;
        private DataGridViewButtonColumn ViewPayment;
    }
}
