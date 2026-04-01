using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Enums;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Models;
using ECoffee.Application.Services;
using ECoffee.Application.ValueObjects;
using ECoffee.Presentation.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECoffee.Presentation.Forms
{
    public partial class CategoryManagementForm : Form
    {
        private readonly CategoryService _categoryService;
        private readonly System.Windows.Forms.Timer _searchTimer = new();
        public CategoryManagementForm(CategoryService CategoryService)
        {
            InitializeComponent();
            _categoryService = CategoryService;
            _searchTimer.Interval = 400; // ms
            _searchTimer.Tick += searchTimer_Tick;
        }

        private async void bCreate_Click(object sender, EventArgs e)
        {
            var form = new CategoryForm(_categoryService, FormMode.Create, null);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                await LoadCategoryAsync();
            }
        }

        private async void CategoryManagementForm_Load(object sender, EventArgs e)
        {
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.Columns["Id"].DataPropertyName = "Id";
            dgvStaff.Columns["Name"].DataPropertyName = "Name";
            dgvStaff.Columns["Status"].DataPropertyName = "StatusText";
            ((DataGridViewButtonColumn)dgvStaff.Columns["Edit"]).UseColumnTextForButtonValue = true;
            ((DataGridViewButtonColumn)dgvStaff.Columns["ToggleStatus"]).UseColumnTextForButtonValue = false;
            await LoadCategoryAsync();
        }

        private async Task LoadCategoryAsync()
        {
            List<CategoryResponse> promotionResponses = await _categoryService.FindAllAsync();
            dgvStaff.DataSource = null;
            dgvStaff.DataSource = promotionResponses;
        }

        private void dgvStaff_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStaff.Columns[e.ColumnIndex].Name == "ToggleStatus")
            {
                var category = dgvStaff.Rows[e.RowIndex].DataBoundItem as CategoryResponse;

                e.Value = category.Status == CategoryStatus.Active ? "Khóa" : "Mở Khóa";
            }
        }

        private async void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var category = (CategoryResponse)dgvStaff.Rows[e.RowIndex].DataBoundItem;
            var column = dgvStaff.Columns[e.ColumnIndex].Name;

            switch (column)
            {
                case "Edit":
                    CategoryForm form = new CategoryForm(_categoryService, FormMode.Edit, category.Id);
                    if (form.ShowDialog(this) == DialogResult.OK)
                        await LoadCategoryAsync();
                    break;

                case "ToggleStatus":
                    if (category.Status == CategoryStatus.Active)
                        await _categoryService.InactiveAsync(category.Id);
                    else
                        await _categoryService.ActiveAsync(category.Id);

                    await LoadCategoryAsync();
                    break;
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private async void searchTimer_Tick(object? sender, EventArgs e)
        {
            _searchTimer.Stop();
            var keyword = tbSearch.Text;

            List<CategoryResponse> categoryResponses = await _categoryService.FindAllByNameAsync(keyword);
            dgvStaff.DataSource = null;
            dgvStaff.DataSource = categoryResponses;
        }
    }
}
