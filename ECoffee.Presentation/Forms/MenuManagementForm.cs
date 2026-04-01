using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Services;

namespace ECoffee.Presentation.Forms
{
    public partial class MenuManagementForm : Form
    {
        private readonly MenuService _menuService;
        public MenuManagementForm(MenuService menuService)
        {
            InitializeComponent();
            _menuService = menuService;
        }

        private async void MenuManagementForm_Load(object sender, EventArgs e) => await LoadDataAsync();

        private async Task LoadDataAsync(string? keyword = null)
        {
            try
            {
                var items = await _menuService.FindAllAsync(keyword);
                dgvMenu.AutoGenerateColumns = false;
                dgvMenu.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private MenuResponse? SelectedItem() => dgvMenu.CurrentRow?.DataBoundItem as MenuResponse;

        private async void bSearch_Click(object sender, EventArgs e) => await LoadDataAsync(tbSearch.Text);
        private async void bRefresh_Click(object sender, EventArgs e) { tbSearch.Clear(); await LoadDataAsync(); }
        private async void bCreate_Click(object sender, EventArgs e)
        {
            using var form = new MenuEditorForm(_menuService);
            if (form.ShowDialog(this) == DialogResult.OK) await LoadDataAsync(tbSearch.Text);
        }
        private async void bEdit_Click(object sender, EventArgs e)
        {
            var item = SelectedItem(); if (item == null) { MessageBox.Show("Hãy chọn một món trước."); return; }
            using var form = new MenuEditorForm(_menuService, item.Id, false);
            if (form.ShowDialog(this) == DialogResult.OK) await LoadDataAsync(tbSearch.Text);
        }
        private void bView_Click(object sender, EventArgs e)
        {
            var item = SelectedItem(); if (item == null) { MessageBox.Show("Hãy chọn một món trước."); return; }
            using var form = new MenuEditorForm(_menuService, item.Id, true);
            form.ShowDialog(this);
        }
        private async void bToggle_Click(object sender, EventArgs e)
        {
            try
            {
                var item = SelectedItem(); if (item == null) { MessageBox.Show("Hãy chọn một món trước."); return; }
                await _menuService.ToggleAvailabilityAsync(item.Id);
                await LoadDataAsync(tbSearch.Text);
            }
            catch (Exception ex) when (ex is BadRequestException || ex is NotFoundException)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dgvMenu_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { if (e.RowIndex >= 0) bView_Click(sender, EventArgs.Empty); }
    }
}
