namespace ECoffee.Presentation.Forms
{
    partial class MenuManagementForm
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
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            txtSearch = new TextBox();
            btnAdd = new Button();
            dgvMenu = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            MenuName = new DataGridViewTextBoxColumn();
            CategoryName = new DataGridViewTextBoxColumn();
            PriceSmall = new DataGridViewTextBoxColumn();
            PriceMedium = new DataGridViewTextBoxColumn();
            PriceLarge = new DataGridViewTextBoxColumn();
            QuantityAvailable = new DataGridViewTextBoxColumn();
            ReorderLevel = new DataGridViewTextBoxColumn();
            StatusText = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewButtonColumn();
            ToggleStatus = new DataGridViewButtonColumn();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblTitle, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(dgvMenu, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(12);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1284, 681);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Left;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(15, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(442, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ MENU";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(txtSearch, 1, 0);
            tableLayoutPanel2.Controls.Add(btnAdd, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(15, 80);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1254, 46);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 46);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(123, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên món hoặc loại nước...";
            txtSearch.Size = new Size(998, 50);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Right;
            btnAdd.Location = new Point(1131, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 35);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm món";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvMenu
            // 
            dgvMenu.AllowUserToAddRows = false;
            dgvMenu.AllowUserToDeleteRows = false;
            dgvMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMenu.Columns.AddRange(new DataGridViewColumn[] { Id, MenuName, CategoryName, PriceSmall, PriceMedium, PriceLarge, QuantityAvailable, ReorderLevel, StatusText, Edit, ToggleStatus });
            dgvMenu.Dock = DockStyle.Fill;
            dgvMenu.Location = new Point(15, 132);
            dgvMenu.Name = "dgvMenu";
            dgvMenu.ReadOnly = true;
            dgvMenu.RowHeadersWidth = 82;
            dgvMenu.RowTemplate.Height = 28;
            dgvMenu.Size = new Size(1254, 534);
            dgvMenu.TabIndex = 2;
            dgvMenu.CellContentClick += dgvMenu_CellContentClick;
            dgvMenu.CellFormatting += dgvMenu_CellFormatting;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.MinimumWidth = 10;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 60;
            // 
            // MenuName
            // 
            MenuName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MenuName.DataPropertyName = "Name";
            MenuName.HeaderText = "Tên món";
            MenuName.MinimumWidth = 10;
            MenuName.Name = "MenuName";
            MenuName.ReadOnly = true;
            // 
            // CategoryName
            // 
            CategoryName.DataPropertyName = "CategoryName";
            CategoryName.HeaderText = "Loại nước";
            CategoryName.MinimumWidth = 10;
            CategoryName.Name = "CategoryName";
            CategoryName.ReadOnly = true;
            CategoryName.Width = 150;
            // 
            // PriceSmall
            // 
            PriceSmall.DataPropertyName = "PriceSmall";
            PriceSmall.HeaderText = "S";
            PriceSmall.MinimumWidth = 10;
            PriceSmall.Name = "PriceSmall";
            PriceSmall.ReadOnly = true;
            PriceSmall.Width = 200;
            // 
            // PriceMedium
            // 
            PriceMedium.DataPropertyName = "PriceMedium";
            PriceMedium.HeaderText = "M";
            PriceMedium.MinimumWidth = 10;
            PriceMedium.Name = "PriceMedium";
            PriceMedium.ReadOnly = true;
            PriceMedium.Width = 200;
            // 
            // PriceLarge
            // 
            PriceLarge.DataPropertyName = "PriceLarge";
            PriceLarge.HeaderText = "L";
            PriceLarge.MinimumWidth = 10;
            PriceLarge.Name = "PriceLarge";
            PriceLarge.ReadOnly = true;
            PriceLarge.Width = 200;
            // 
            // QuantityAvailable
            // 
            QuantityAvailable.DataPropertyName = "QuantityAvailable";
            QuantityAvailable.HeaderText = "Tồn kho";
            QuantityAvailable.MinimumWidth = 10;
            QuantityAvailable.Name = "QuantityAvailable";
            QuantityAvailable.ReadOnly = true;
            QuantityAvailable.Width = 200;
            // 
            // ReorderLevel
            // 
            ReorderLevel.DataPropertyName = "ReorderLevel";
            ReorderLevel.HeaderText = "Mức nhập lại";
            ReorderLevel.MinimumWidth = 10;
            ReorderLevel.Name = "ReorderLevel";
            ReorderLevel.ReadOnly = true;
            ReorderLevel.Width = 120;
            // 
            // StatusText
            // 
            StatusText.DataPropertyName = "StatusText";
            StatusText.HeaderText = "Trạng thái";
            StatusText.MinimumWidth = 10;
            StatusText.Name = "StatusText";
            StatusText.ReadOnly = true;
            StatusText.Width = 120;
            // 
            // Edit
            // 
            Edit.HeaderText = "";
            Edit.MinimumWidth = 10;
            Edit.Name = "Edit";
            Edit.ReadOnly = true;
            Edit.Text = "Sửa";
            Edit.UseColumnTextForButtonValue = true;
            Edit.Width = 80;
            // 
            // ToggleStatus
            // 
            ToggleStatus.HeaderText = "";
            ToggleStatus.MinimumWidth = 10;
            ToggleStatus.Name = "ToggleStatus";
            ToggleStatus.ReadOnly = true;
            ToggleStatus.Width = 110;
            // 
            // MenuManagementForm
            // 
            AutoScaleDimensions = new SizeF(18F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 681);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F);
            Name = "MenuManagementForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Menu";
            WindowState = FormWindowState.Maximized;
            Load += MenuManagementForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblTitle;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private TextBox txtSearch;
        private Button btnAdd;
        private DataGridView dgvMenu;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn MenuName;
        private DataGridViewTextBoxColumn CategoryName;
        private DataGridViewTextBoxColumn PriceSmall;
        private DataGridViewTextBoxColumn PriceMedium;
        private DataGridViewTextBoxColumn PriceLarge;
        private DataGridViewTextBoxColumn QuantityAvailable;
        private DataGridViewTextBoxColumn ReorderLevel;
        private DataGridViewTextBoxColumn StatusText;
        private DataGridViewButtonColumn Edit;
        private DataGridViewButtonColumn ToggleStatus;
    }
}
