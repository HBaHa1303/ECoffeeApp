using ECoffee.Presentation.Services;
using ECoffee.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ECoffee.Presentation.Forms
{
    public partial class MenuEditForm : Form
    {
        private readonly MenuModuleService _menuModuleService;
        private readonly long? _menuId;

        public MenuEditForm()
            : this(Program.Services.GetRequiredService<MenuModuleService>(), null)
        {
        }

        public MenuEditForm(long? menuId)
            : this(Program.Services.GetRequiredService<MenuModuleService>(), menuId)
        {
        }

        public MenuEditForm(MenuModuleService menuModuleService, long? menuId = null)
        {
            InitializeComponent();
            _menuModuleService = menuModuleService;
            _menuId = menuId;
        }

        private async void MenuEditForm_Load(object sender, EventArgs e)
        {
            var categories = await _menuModuleService.GetCategoriesAsync();
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";

            if (_menuId.HasValue)
            {
                var model = await _menuModuleService.GetByIdAsync(_menuId.Value);
                if (model == null)
                {
                    MessageBox.Show("Không tìm thấy món cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtName.Text = model.Name;
                cboCategory.SelectedValue = model.CategoryId;
                nudPriceS.Value = model.PriceSmall;
                nudPriceM.Value = model.PriceMedium;
                nudPriceL.Value = model.PriceLarge;
                nudQuantity.Value = model.QuantityAvailable;
                nudReorder.Value = model.ReorderLevel;
                chkIsActive.Checked = model.IsActive;
                Text = "Sửa món";
            }
            else
            {
                Text = "Thêm món";
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var categoryId = cboCategory.SelectedValue != null
                    ? Convert.ToInt64(cboCategory.SelectedValue)
                    : 0;

                var model = new MenuEditorViewModel
                {
                    Id = _menuId,
                    Name = txtName.Text.Trim(),
                    CategoryId = categoryId,
                    PriceSmall = nudPriceS.Value,
                    PriceMedium = nudPriceM.Value,
                    PriceLarge = nudPriceL.Value,
                    QuantityAvailable = (int)nudQuantity.Value,
                    ReorderLevel = (int)nudReorder.Value,
                    IsActive = chkIsActive.Checked
                };

                await _menuModuleService.SaveAsync(model, "system");
                MessageBox.Show("Lưu menu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}