namespace ECoffee.Presentation.Forms
{
    partial class StaffManagementForm
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            tbSearch = new TextBox();
            bCreate = new Button();
            label2 = new Label();
            dgvStaff = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            DateOfBirth = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewButtonColumn();
            ToggleStatus = new DataGridViewButtonColumn();
            searchTimer = new System.Windows.Forms.Timer(components);
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
            tableLayoutPanel1.Size = new Size(1000, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(363, 28);
            label1.Name = "label1";
            label1.Size = new Size(274, 37);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(tbSearch, 1, 0);
            tableLayoutPanel2.Controls.Add(bCreate, 2, 0);
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(11, 88);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(8, 0, 8, 0);
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(978, 42);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // tbSearch
            // 
            tbSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSearch.Location = new Point(155, 6);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "Tìm kiếm ...";
            tbSearch.Size = new Size(330, 29);
            tbSearch.TabIndex = 0;
            tbSearch.TextChanged += tbSearch_TextChanged;
            // 
            // bCreate
            // 
            bCreate.Anchor = AnchorStyles.Right;
            bCreate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bCreate.Location = new Point(866, 3);
            bCreate.Name = "bCreate";
            bCreate.Size = new Size(101, 35);
            bCreate.TabIndex = 1;
            bCreate.Text = "Thêm mới";
            bCreate.UseVisualStyleBackColor = true;
            bCreate.Click += bCreate_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 10);
            label2.Name = "label2";
            label2.Size = new Size(135, 21);
            label2.TabIndex = 2;
            label2.Text = "Tìm kiếm theo tên";
            // 
            // dgvStaff
            // 
            dgvStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStaff.Columns.AddRange(new DataGridViewColumn[] { Id, FullName, Email, Status, DateOfBirth, Address, Edit, ToggleStatus });
            dgvStaff.Dock = DockStyle.Fill;
            dgvStaff.Location = new Point(11, 136);
            dgvStaff.Name = "dgvStaff";
            dgvStaff.Size = new Size(978, 303);
            dgvStaff.TabIndex = 2;
            dgvStaff.CellContentClick += dgvStaff_CellContentClick;
            dgvStaff.CellFormatting += dgvStaff_CellFormatting;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.Width = 50;
            // 
            // FullName
            // 
            FullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FullName.HeaderText = "Họ Tên";
            FullName.Name = "FullName";
            // 
            // Email
            // 
            Email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Email.HeaderText = "Email";
            Email.Name = "Email";
            // 
            // Status
            // 
            Status.HeaderText = "Trạng thái";
            Status.Name = "Status";
            // 
            // DateOfBirth
            // 
            DateOfBirth.HeaderText = "Ngày Sinh";
            DateOfBirth.Name = "DateOfBirth";
            // 
            // Address
            // 
            Address.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Address.HeaderText = "Địa Chỉ";
            Address.Name = "Address";
            // 
            // Edit
            // 
            Edit.HeaderText = "";
            Edit.Name = "Edit";
            Edit.Resizable = DataGridViewTriState.True;
            Edit.SortMode = DataGridViewColumnSortMode.Automatic;
            Edit.Text = "Sửa";
            // 
            // ToggleStatus
            // 
            ToggleStatus.HeaderText = "";
            ToggleStatus.Name = "ToggleStatus";
            ToggleStatus.Resizable = DataGridViewTriState.True;
            ToggleStatus.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // searchTimer
            // 
            searchTimer.Tick += searchTimer_Tick;
            // 
            // StaffManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "StaffManagementForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý nhân viên";
            Load += StaffManagementForm_Load;
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
        private TextBox tbSearch;
        private Button bCreate;
        private DataGridView dgvStaff;
        private Label label2;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn DateOfBirth;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewButtonColumn Edit;
        private DataGridViewButtonColumn ToggleStatus;
        private System.Windows.Forms.Timer searchTimer;
    }
}