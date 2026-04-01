namespace ECoffee.Presentation.Forms
{
    partial class MenuManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            panelTop = new Panel();
            lHeader = new Label();
            panelActions = new FlowLayoutPanel();
            bCreate = new Button();
            bEdit = new Button();
            bView = new Button();
            bToggle = new Button();
            bRefresh = new Button();
            tbSearch = new TextBox();
            bSearch = new Button();
            dgvMenu = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colSmall = new DataGridViewTextBoxColumn();
            colMedium = new DataGridViewTextBoxColumn();
            colLarge = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colReorder = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            tableLayoutPanel1.SuspendLayout(); panelTop.SuspendLayout(); panelActions.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit(); SuspendLayout();
            tableLayoutPanel1.ColumnCount = 1; tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F)); tableLayoutPanel1.Controls.Add(panelTop,0,0); tableLayoutPanel1.Controls.Add(dgvMenu,0,1); tableLayoutPanel1.Dock = DockStyle.Fill; tableLayoutPanel1.RowCount = 2; tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute,120F)); tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent,100F));
            panelTop.Controls.Add(panelActions); panelTop.Controls.Add(lHeader); panelTop.Dock = DockStyle.Fill;
            lHeader.AutoSize = true; lHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold); lHeader.Location = new Point(16,16); lHeader.Text = "Quản lý Menu";
            panelActions.Anchor = AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right; panelActions.Controls.AddRange(new Control[]{bCreate,bEdit,bView,bToggle,bRefresh,tbSearch,bSearch}); panelActions.Location = new Point(16,58); panelActions.Size = new Size(1040,40);
            bCreate.Text="Thêm"; bCreate.Click += bCreate_Click; bEdit.Text="Sửa"; bEdit.Click += bEdit_Click; bView.Text="Xem"; bView.Click += bView_Click; bToggle.Text="Đổi trạng thái"; bToggle.Click += bToggle_Click; bRefresh.Text="Tải lại"; bRefresh.Click += bRefresh_Click; tbSearch.PlaceholderText="Tìm theo tên / loại nước"; tbSearch.Width=280; bSearch.Text="Tìm"; bSearch.Click += bSearch_Click;
            dgvMenu.AllowUserToAddRows=false; dgvMenu.AllowUserToDeleteRows=false; dgvMenu.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill; dgvMenu.BackgroundColor=Color.White; dgvMenu.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize; dgvMenu.Columns.AddRange(new DataGridViewColumn[]{colId,colName,colCategory,colSmall,colMedium,colLarge,colQty,colReorder,colStatus}); dgvMenu.Dock=DockStyle.Fill; dgvMenu.MultiSelect=false; dgvMenu.ReadOnly=true; dgvMenu.RowTemplate.Height=28; dgvMenu.SelectionMode=DataGridViewSelectionMode.FullRowSelect; dgvMenu.CellDoubleClick += dgvMenu_CellDoubleClick;
            colId.DataPropertyName="Id"; colId.HeaderText="Id"; colId.FillWeight=50;
            colName.DataPropertyName="Name"; colName.HeaderText="Tên món";
            colCategory.DataPropertyName="CategoryName"; colCategory.HeaderText="Loại";
            colSmall.DataPropertyName="SmallPrice"; colSmall.HeaderText="Giá S";
            colMedium.DataPropertyName="MediumPrice"; colMedium.HeaderText="Giá M";
            colLarge.DataPropertyName="LargePrice"; colLarge.HeaderText="Giá L";
            colQty.DataPropertyName="QuantityAvailable"; colQty.HeaderText="Tồn kho";
            colReorder.DataPropertyName="ReorderLevel"; colReorder.HeaderText="Mức nhập lại";
            colStatus.DataPropertyName="StatusText"; colStatus.HeaderText="Trạng thái";
            AutoScaleDimensions = new SizeF(9F,21F); AutoScaleMode = AutoScaleMode.Font; ClientSize = new Size(1100,650); Controls.Add(tableLayoutPanel1); Font = new Font("Segoe UI",12F); StartPosition = FormStartPosition.CenterParent; Text = "Quản lý Menu"; Load += MenuManagementForm_Load;
            tableLayoutPanel1.ResumeLayout(false); panelTop.ResumeLayout(false); panelTop.PerformLayout(); panelActions.ResumeLayout(false); panelActions.PerformLayout(); ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit(); ResumeLayout(false);
        }
        #endregion
        private TableLayoutPanel tableLayoutPanel1; private Panel panelTop; private Label lHeader; private FlowLayoutPanel panelActions; private Button bCreate; private Button bEdit; private Button bView; private Button bToggle; private Button bRefresh; private TextBox tbSearch; private Button bSearch; private DataGridView dgvMenu; private DataGridViewTextBoxColumn colId; private DataGridViewTextBoxColumn colName; private DataGridViewTextBoxColumn colCategory; private DataGridViewTextBoxColumn colSmall; private DataGridViewTextBoxColumn colMedium; private DataGridViewTextBoxColumn colLarge; private DataGridViewTextBoxColumn colQty; private DataGridViewTextBoxColumn colReorder; private DataGridViewTextBoxColumn colStatus;
    }
}
