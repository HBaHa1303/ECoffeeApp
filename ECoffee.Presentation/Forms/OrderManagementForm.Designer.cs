namespace ECoffee.Presentation.Forms
{
    partial class OrderManagementForm
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
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            label2 = new Label();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            dgvStaff = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            UserName = new DataGridViewTextBoxColumn();
            PromotionName = new DataGridViewTextBoxColumn();
            CreatedAt = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            TotalAmount = new DataGridViewTextBoxColumn();
            Detail = new DataGridViewButtonColumn();
            bSearch = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(dgvStaff, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(8);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.Size = new Size(1142, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(433, 28);
            label1.Name = "label1";
            label1.Size = new Size(275, 37);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ ĐƠN HÀNG";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Controls.Add(label3, 2, 0);
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(dtpFrom, 1, 0);
            tableLayoutPanel2.Controls.Add(dtpTo, 3, 0);
            tableLayoutPanel2.Controls.Add(bSearch, 4, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(11, 88);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(8, 0, 8, 0);
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1120, 42);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(485, 10);
            label3.Name = "label3";
            label3.Size = new Size(36, 21);
            label3.TabIndex = 5;
            label3.Text = "đến";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 10);
            label2.Name = "label2";
            label2.Size = new Size(163, 21);
            label2.TabIndex = 2;
            label2.Text = "Tìm kiếm đơn hàng từ";
            // 
            // dtpFrom
            // 
            dtpFrom.Anchor = AnchorStyles.Left;
            dtpFrom.CustomFormat = "dd/MM/yyyy";
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.Location = new Point(231, 9);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(186, 23);
            dtpFrom.TabIndex = 3;
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Left;
            dtpTo.CustomFormat = "dd/MM/yyyy";
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.Location = new Point(561, 9);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(186, 23);
            dtpTo.TabIndex = 4;
            // 
            // dgvStaff
            // 
            dgvStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStaff.Columns.AddRange(new DataGridViewColumn[] { Id, UserName, PromotionName, CreatedAt, Status, TotalAmount, Detail });
            dgvStaff.Dock = DockStyle.Fill;
            dgvStaff.Location = new Point(11, 136);
            dgvStaff.Name = "dgvStaff";
            dgvStaff.Size = new Size(1120, 303);
            dgvStaff.TabIndex = 2;
            dgvStaff.CellContentClick += dgvStaff_CellContentClick;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.Width = 50;
            // 
            // UserName
            // 
            UserName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            UserName.HeaderText = "Tên Khách Hàng";
            UserName.Name = "UserName";
            // 
            // PromotionName
            // 
            PromotionName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PromotionName.HeaderText = "Tên Khuyến Mãi";
            PromotionName.Name = "PromotionName";
            // 
            // CreatedAt
            // 
            CreatedAt.HeaderText = "Ngày Đặt Hàng";
            CreatedAt.Name = "CreatedAt";
            CreatedAt.Width = 150;
            // 
            // Status
            // 
            Status.HeaderText = "Trạng thái";
            Status.Name = "Status";
            // 
            // TotalAmount
            // 
            TotalAmount.HeaderText = "Tổng Tiền";
            TotalAmount.Name = "TotalAmount";
            TotalAmount.Width = 150;
            // 
            // Detail
            // 
            Detail.HeaderText = "Chi Tiết";
            Detail.Name = "Detail";
            // 
            // bSearch
            // 
            bSearch.Anchor = AnchorStyles.Left;
            bSearch.Location = new Point(781, 9);
            bSearch.Name = "bSearch";
            bSearch.Size = new Size(75, 23);
            bSearch.TabIndex = 6;
            bSearch.Text = "Lọc";
            bSearch.UseVisualStyleBackColor = true;
            bSearch.Click += bSearch_Click;
            // 
            // OrderManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1142, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "OrderManagementForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý đơn hàng";
            Load += OrderManagementForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridView dgvStaff;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn UserName;
        private DataGridViewTextBoxColumn PromotionName;
        private DataGridViewTextBoxColumn CreatedAt;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn TotalAmount;
        private DataGridViewButtonColumn Detail;
        private Button bSearch;
    }
}