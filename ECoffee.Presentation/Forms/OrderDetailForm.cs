using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Services;
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
    public partial class OrderDetailForm : Form
    {
        private readonly OrderService _orderService;
        private readonly long _orderId;
        public OrderDetailForm(long orderId, OrderService orderService)
        {
            InitializeComponent();
            _orderId = orderId;
            _orderService = orderService;
        }

        private void OrderDetailForm_Load(object sender, EventArgs e)
        {
            lOrderDetail.Text = "Chi tiết đơn hàng: " + _orderId;

            LoadOrderDetailAsync(_orderId);
        }

        private async Task LoadOrderDetailAsync(long orderId)
        {
            List<OrderItemResponse> orderItemResponses = await _orderService.FindAllOrderItemById(orderId);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = orderItemResponses;
        }
    }
}
