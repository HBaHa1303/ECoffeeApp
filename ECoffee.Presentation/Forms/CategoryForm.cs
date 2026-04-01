using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Enums;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Models;
using ECoffee.Application.Services;
using ECoffee.Presentation.Enums;

namespace ECoffee.Presentation.Forms
{
    public partial class CategoryForm : Form
    {
        private readonly FormMode _mode;
        private readonly long? _categoryId;
        private readonly CategoryService _categoryService;

        public CategoryForm(
            CategoryService categoryService,
            FormMode mode,
            long? categoryId)
        {
            InitializeComponent();

            _mode = mode;
            _categoryId = categoryId;
            _categoryService = categoryService;
        }

        private async void CategoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (_mode == FormMode.Create)
                {
                    lHeader.Text = "Tạo danh mục";
                    bSubmit.Text = "Tạo";
                    return;
                }
                lHeader.Text = "Sửa danh mục";
                bSubmit.Text = "Sửa";

                if (_categoryId is null) throw new BadRequestException("Thiếu category id");

                CategoryResponse category = await _categoryService.FindByIdAsync(_categoryId.Value);

                tbName.Text = category.Name;
            }
            catch (BadRequestException ex)
            {
                MessageBox.Show(ex.Message, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi không mong muốn.", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
            }
        }

        private async void bSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbName.Text.Trim();

                string message = string.Empty;

                if (_mode == FormMode.Create)
                {
                    await CreateCategory(name);
                    message = "Tạo danh mục thành công";
                }

                if (_mode == FormMode.Edit)
                {
                    if (_categoryId is null) throw new BadRequestException("Thiếu category id");

                    await UpdateCategory(_categoryId.Value, name);

                    message = "Cập nhật danh mục thành công";
                }

                MessageBox.Show(message, "Thành công", MessageBoxButtons.OK);

                DialogResult = DialogResult.OK;
            }
            catch (BadRequestException ex)
            {
                MessageBox.Show(ex.Message, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ConflictException ex)
            {
                MessageBox.Show(ex.Message, "Danh mục đã tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show( "Đã xảy ra lỗi không mong muốn.", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CreateCategory(string name)
        {
            await _categoryService.CreateAsync(name);
        }

        private async Task UpdateCategory( long id, string name)
        {
            await _categoryService.RenameAsync(id, name);
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}