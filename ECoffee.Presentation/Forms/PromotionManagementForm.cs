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
    public partial class PromotionManagementForm : Form
    {
        private readonly PromotionService _promotionService;
        private readonly System.Windows.Forms.Timer _searchTimer = new();
        public PromotionManagementForm(PromotionService promotionService)
        {
            InitializeComponent();
            _promotionService = promotionService;
            _searchTimer.Interval = 400; // ms
            _searchTimer.Tick += searchTimer_Tick;
        }

        private async void bCreate_Click(object sender, EventArgs e)
        {
            var form = new PromotionForm(_promotionService, FormMode.Create, null);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                await LoadStaffAsync();
            }
        }

        private async void StaffManagementForm_Load(object sender, EventArgs e)
        {
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.Columns["Id"].DataPropertyName = "Id";
            dgvStaff.Columns["Name"].DataPropertyName = "Name";
            dgvStaff.Columns["Type"].DataPropertyName = "TypeText";
            dgvStaff.Columns["Status"].DataPropertyName = "StatusText";
            dgvStaff.Columns["StartDate"].DataPropertyName = "StartDate";
            dgvStaff.Columns["StartDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvStaff.Columns["EndDate"].DataPropertyName = "EndDate";
            dgvStaff.Columns["EndDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            ((DataGridViewButtonColumn)dgvStaff.Columns["Edit"]).UseColumnTextForButtonValue = true;
            ((DataGridViewButtonColumn)dgvStaff.Columns["ToggleStatus"]).UseColumnTextForButtonValue = false;
            await LoadStaffAsync();
        }

        private async Task LoadStaffAsync()
        {
            List<PromotionResponse> promotionResponses = await _promotionService.FindAllAsync();
            dgvStaff.DataSource = null;
            dgvStaff.DataSource = promotionResponses;
        }

        private void dgvStaff_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStaff.Columns[e.ColumnIndex].Name == "ToggleStatus")
            {
                var promotion = dgvStaff.Rows[e.RowIndex].DataBoundItem as PromotionResponse;

                e.Value = promotion.Status == PromotionStatus.Activate ? "Khóa" : "Mở Khóa";
            }
        }

        private async void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var promotion = (PromotionResponse)dgvStaff.Rows[e.RowIndex].DataBoundItem;
            var column = dgvStaff.Columns[e.ColumnIndex].Name;

            switch (column)
            {
                case "Edit":
                    PromotionForm form = new PromotionForm(_promotionService, FormMode.Edit, promotion.Id);
                    if (form.ShowDialog(this) == DialogResult.OK)
                        await LoadStaffAsync();
                    break;

                case "ToggleStatus":
                    if (promotion.Status == PromotionStatus.Activate)
                        await _promotionService.InactiveAsync(promotion.Id);
                    else
                        await _promotionService.ActiveAsync(promotion.Id);

                    await LoadStaffAsync();
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

            List<PromotionResponse> userResponses = await _promotionService.FindAllByNameAsync(keyword);
            dgvStaff.DataSource = null;
            dgvStaff.DataSource = userResponses;
        }
    }
}
