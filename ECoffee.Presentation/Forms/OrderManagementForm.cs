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
    public partial class OrderManagementForm : Form
    {
        private readonly OrderService _orderService;
        public OrderManagementForm(OrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService;
        }

        //private async void bCreate_Click(object sender, EventArgs e)
        //{
        //    var form = new PromotionForm(_promotionService, FormMode.Create, null);

        //    if (form.ShowDialog(this) == DialogResult.OK)
        //    {
        //        await LoadStaffAsync();
        //    }
        //}

        private async void OrderManagementForm_Load(object sender, EventArgs e)
        {
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.Columns["Id"].DataPropertyName = "Id";
            dgvStaff.Columns["UserName"].DataPropertyName = "UserName";
            dgvStaff.Columns["PromotionName"].DataPropertyName = "PromotionName";
            dgvStaff.Columns["Status"].DataPropertyName = "StatusText";
            dgvStaff.Columns["TotalAmount"].DataPropertyName = "TotalAmount";
            dgvStaff.Columns["CreatedAt"].DataPropertyName = "CreatedAt";
            dgvStaff.Columns["CreatedAt"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            ((DataGridViewButtonColumn)dgvStaff.Columns["Detail"]).UseColumnTextForButtonValue = true;
            await LoadOrderAsync(DateTime.Now, DateTime.Now);
        }

        private async Task LoadOrderAsync(DateTime from, DateTime to)
        {
            List<OrderResponse> orderRepsonses = await _orderService.FindAllByCreatedAtAsync(from, to);
            dgvStaff.DataSource = null;
            dgvStaff.DataSource = orderRepsonses;
        }

        //private void dgvStaff_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (dgvStaff.Columns[e.ColumnIndex].Name == "ToggleStatus")
        //    {
        //        var promotion = dgvStaff.Rows[e.RowIndex].DataBoundItem as PromotionResponse;

        //        e.Value = promotion.Status == PromotionStatus.Activate ? "Khóa" : "Mở Khóa";
        //    }
        //}

        private async void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var order = (OrderResponse)dgvStaff.Rows[e.RowIndex].DataBoundItem;
            var column = dgvStaff.Columns[e.ColumnIndex].Name;

            switch (column)
            {
                case "Detail":
                    new OrderDetailForm(order.Id, _orderService).ShowDialog(this);
                    break;
            }
        }

        private async void bSearch_Click(object sender, EventArgs e)
        {
            DateTime from = dtpFrom.Value;
            DateTime to = dtpTo.Value;
            await LoadOrderAsync(from, to);
        }
    }
}
