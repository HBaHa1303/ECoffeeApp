using ECoffee.Application.Repositories;
using ECoffee.Application.Services;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Repositories;
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
    public partial class frmKdsDashboard : Form
    {
        private readonly KdsService _kdsService;
        private int _refreshCounter = 0;
        public frmKdsDashboard(KdsService kdsService)
        {
            InitializeComponent();
            _kdsService = kdsService;
            tmrClock.Start();

            
        }


        // time
        private void tmrClock_Tick(object sender, EventArgs e)
        {
            // 1. Việc này làm mỗi giây: Hiện giờ hệ thống
            string shiftName = _kdsService.GetCurrentShiftName();
            lblSystemDateTime.Text = $"{shiftName} - {DateTime.Now:dd/MM/yyyy HH:mm:ss}";

            // 2. Việc này làm mỗi 10 giây: Nạp dữ liệu
            _refreshCounter++;
            if (_refreshCounter >= 10)
            {
                LoadKdsData();
                _refreshCounter = 0; // Reset bộ đếm
            }
        }
        private string GetVietnameseDayOfWeek(DayOfWeek dotw)
        {
            return dotw switch
            {
                DayOfWeek.Monday => "Thứ 2",
                DayOfWeek.Tuesday => "Thứ 3",
                DayOfWeek.Wednesday => "Thứ 4",
                DayOfWeek.Thursday => "Thứ 5",
                DayOfWeek.Friday => "Thứ 6",
                DayOfWeek.Saturday => "Thứ 7",
                DayOfWeek.Sunday => "Chủ Nhật",
                _ => ""
            };
        }

        private void frmKdsDashboard_Load(object sender, EventArgs e)
        {
            LoadKdsData();
        }

        //layout kds order
        private void btnShowPending_Click(object sender, EventArgs e)
        {
            flpPendingOrders.Visible = true;
            flpCompletedOrders.Visible = false;

            // 2. Đưa lên trên cùng để chắc chắn nhìn thấy
            flpPendingOrders.BringToFront();

            // 3. (Tùy chọn) Đổi màu nút để biết đang chọn Tab nào
            btnShowPending.BackColor = Color.LightBlue;
            btnShowCompleted.BackColor = Color.Gainsboro;

            flpPendingOrders.BringToFront(); 
        }

        private void btnShowCompleted_Click(object sender, EventArgs e)
        {
            // 1. Hiện panel hoàn thành, ẩn món đợi
            flpCompletedOrders.Visible = true;
            flpPendingOrders.Visible = false;

            // 2. Đưa lên trên cùng
            flpCompletedOrders.BringToFront();

            // 3. Load lại dữ liệu để cập nhật danh sách món vừa hoàn thành
            LoadKdsData();

            // 4. Đổi màu nút
            btnShowCompleted.BackColor = Color.LightBlue;
            btnShowPending.BackColor = Color.Gainsboro;
            flpCompletedOrders.BringToFront(); 
        }

        private void LoadKdsData()
        {
            // 1. Nạp Món Đợi
            var pendingOrders = _kdsService.GetActiveOrders();
            flpPendingOrders.Controls.Clear();
            foreach (var order in pendingOrders)
            {
                var card = new ucKdsCard();
                card.SetData(order);
                card.OnFinishClicked += (s, e) => {
                    _kdsService.UpdateOrderStatus(order.OrderId, "Completed");
                    LoadKdsData();
                };
                flpPendingOrders.Controls.Add(card);
            }

            // 2. Nạp Món Hoàn Thành (PHẢI THÊM ĐOẠN NÀY)
            // Bạn cần gọi hàm lấy danh sách "Completed" từ Service
            var completedOrders = _kdsService.GetOrdersByStatus("Completed");
            flpCompletedOrders.Controls.Clear();
            foreach (var order in completedOrders)
            {
                var card = new ucKdsCard();
                card.SetData(order);
                // Có thể gọi card.HideFinishButton() nếu bạn đã viết hàm này
                card.HideFinishButton();
                flpCompletedOrders.Controls.Add(card);
            }
        }
    }



    
}
