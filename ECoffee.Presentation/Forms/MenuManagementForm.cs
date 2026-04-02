using ECoffee.Presentation.Services;
using ECoffee.Presentation.ViewModels;

namespace ECoffee.Presentation.Forms
{
    public partial class MenuManagementForm : Form
    {
        private readonly MenuModuleService _menuModuleService;
        private readonly System.Windows.Forms.Timer _searchTimer = new();

        public MenuManagementForm(MenuModuleService menuModuleService)
        {
            InitializeComponent();
            _menuModuleService = menuModuleService;
            _searchTimer.Interval = 400;
            _searchTimer.Tick += SearchTimer_Tick;
        }

        private async void MenuManagementForm_Load(object sender, EventArgs e)
        {
            dgvMenu.AutoGenerateColumns = false;
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            dgvMenu.DataSource = null;
            dgvMenu.DataSource = await _menuModuleService.GetMenuItemsAsync(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private async void SearchTimer_Tick(object? sender, EventArgs e)
        {
            _searchTimer.Stop();
            await LoadDataAsync();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new MenuEditForm(_menuModuleService, null);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                await LoadDataAsync();
            }
        }

        private async void dgvMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var item = dgvMenu.Rows[e.RowIndex].DataBoundItem as MenuGridItemViewModel;
            if (item == null)
            {
                return;
            }

            var columnName = dgvMenu.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                using var form = new MenuEditForm(_menuModuleService, item.Id);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    await LoadDataAsync();
                }
            }
            else if (columnName == "ToggleStatus")
            {
                await _menuModuleService.ToggleStatusAsync(item.Id, "system");
                await LoadDataAsync();
            }
        }

        private void dgvMenu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvMenu.Columns[e.ColumnIndex].Name == "ToggleStatus")
            {
                var item = dgvMenu.Rows[e.RowIndex].DataBoundItem as MenuGridItemViewModel;
                e.Value = item?.IsActive == true ? "Ngừng bán" : "Mở bán";
            }
        }
    }
}
