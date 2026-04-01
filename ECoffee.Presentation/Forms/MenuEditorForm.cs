using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Services;

namespace ECoffee.Presentation.Forms
{
    public partial class MenuEditorForm : Form
    {
        private readonly MenuService _menuService;
        private readonly long? _menuId;
        private readonly bool _readOnly;
        public MenuEditorForm(MenuService menuService, long? menuId = null, bool readOnly = false)
        {
            InitializeComponent();
            _menuService = menuService;
            _menuId = menuId;
            _readOnly = readOnly;
        }

        private void MenuEditorForm_Load(object sender, EventArgs e)
        {
            Text = _readOnly ? "Xem món" : _menuId.HasValue ? "Sửa món" : "Thêm món";
            if (_menuId.HasValue)
            {
                var item = _menuService.FindById(_menuId.Value);
                tbName.Text = item.Name; tbCategory.Text = item.CategoryName;
                nudSmall.Value = item.SmallPrice; nudMedium.Value = item.MediumPrice; nudLarge.Value = item.LargePrice;
                nudQuantity.Value = item.QuantityAvailable; nudReorder.Value = item.ReorderLevel;
            }
            if (_readOnly)
            {
                foreach (Control c in Controls.OfType<TableLayoutPanel>().SelectMany(x => x.Controls.Cast<Control>()))
                { if (c is TextBox tb) tb.ReadOnly = true; if (c is NumericUpDown nud) nud.Enabled = false; }
                bSave.Visible = false;
            }
        }

        private async void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new UpdateMenuRequest{ Name=tbName.Text, CategoryName=tbCategory.Text, SmallPrice=nudSmall.Value, MediumPrice=nudMedium.Value, LargePrice=nudLarge.Value, QuantityAvailable=(int)nudQuantity.Value, ReorderLevel=(int)nudReorder.Value };
                if (_menuId.HasValue) await _menuService.UpdateAsync(_menuId.Value, request); else await _menuService.CreateAsync(request);
                DialogResult = DialogResult.OK; Close();
            }
            catch (Exception ex) when (ex is BadRequestException || ex is NotFoundException)
            { MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void bCancel_Click(object sender, EventArgs e) => Close();
    }
}
