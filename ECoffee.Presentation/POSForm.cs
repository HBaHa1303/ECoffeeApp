using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using ECoffee.Application.Services;
using ECoffee.Infrastructure.Repositories;
using ECoffee.Presentation.Forms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECoffee.Presentation
{
    public partial class POSForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly CategoryService _categoryService;
        private readonly IMenuRepository _menuRepository;
        private readonly OrderService _orderService;
        private readonly KdsService _kdsService;
        private readonly ShiftService _shiftService;
        public POSForm(IServiceProvider serviceProvider, IMenuRepository menuRepository, OrderService orderService, KdsService kdsService, CategoryService categoryService, ShiftService shiftService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _menuRepository = menuRepository;
            _orderService = orderService;

            _kdsService = kdsService;
            _categoryService = categoryService;
            _shiftService = shiftService;
        }
        private void CategoryButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // Lấy ID từ Tag của nút bấm
            if (int.TryParse(btn.Tag?.ToString(), out int selectedCategoryId))
            {
                LoadProductsByCategoryId(selectedCategoryId);
            }
        }

        private void LoadProductsByCategoryId(int categoryId)
        {
            flbItems.Controls.Clear();
            var allProducts = _menuRepository.GetAllProducts();

            // Lọc lấy những món có CategoryId khớp với nút vừa bấm
            var filteredProducts = allProducts.Where(p => p.CategoryId == categoryId).ToList();

            foreach (var item in filteredProducts)
            {


                var priceInfo = item.Prices?.FirstOrDefault();
                if (priceInfo != null)
                {
                    item.Price = priceInfo.Price;
                }

                ItemBox uc = new ItemBox();
                uc.labelNameItem.Text = item.Name;
                uc.labelPrice.Text = item.Price.ToString("N0") + " VNĐ";

                // Sự kiện khi click vào món để nó bay vào bảng Order
                uc.OnSelect += (s, ev) => AddToOrder(item);

                flbItems.Controls.Add(uc);
            }
        }




        private void btOrderIcon_Click(object sender, EventArgs e)
        {
            //var posForm = _serviceProvider.GetRequiredService<POSForm>();
            //posForm.Show();

            LoadAllProducts();
        }

        private void btSettingIcon_Click(object sender, EventArgs e)
        {
            var shiftForm = _serviceProvider.GetRequiredService<ShiftForm>();
            shiftForm.ShowDialog(this);
        }

        private async void POSForm_Load(object sender, EventArgs e)
        {
            //UpdateNextOrderIdDisplay();
            LoadAllProducts();
            // load categories btn
            await LoadCategories();
        }

        private void LoadAllProducts()
        {
            var products = _menuRepository.GetAllProducts();
            flbItems.Controls.Clear(); // Xóa các món cũ

            foreach (var item in products)
            {

                var priceInfo = item.Prices?.FirstOrDefault();
                if (priceInfo != null)
                {
                    item.Price = priceInfo.Price;
                }

                // Tạo UserControl cho từng món
                ItemBox uc = new ItemBox();
                uc.labelNameItem.Text = item.Name;
                uc.labelPrice.Text = item.Price.ToString("N0") + " VNĐ";

                // Gắn sự kiện: Khi nhấn vào món này thì thêm vào Giỏ hàng bên phải
                uc.OnSelect += (s, ev) => AddToOrder(item);

                flbItems.Controls.Add(uc);
            }
        }
        private void AddToOrder(ECoffee.Application.Models.Menu item)
        {

            if (flpOrderList.Controls.Count == 0)
            {
                UpdateNextOrderIdDisplay(); // Hàm này sẽ lấy (Max ID trong DB + 1)
            }

            // 1. Kiểm tra xem món này đã có trong giỏ hàng (flpCheckOut) chưa
            ucOrderItem existingItem = null;
            foreach (Control ctrl in flpOrderList.Controls)
            {
                if (ctrl is ucOrderItem row && row.labelTenMon.Text == item.Name)
                {
                    existingItem = row;
                    break;
                }
            }

            if (existingItem != null)
            {
                // Nếu đã có: Tăng số lượng lên 1
                //int currentQty = (int)existingItem.nmrSoLuong.Value + 1;
                existingItem.nmrSoLuong.Value = (decimal)existingItem.nmrSoLuong.Value + 1;
                existingItem.UpdateItemTotal((int)existingItem.nmrSoLuong.Value, item.Price);
                //existingItem.UpdateItemTotal(currentQty, item.Price);
            }
            else
            {
                // Nếu chưa có: Tạo dòng mới
                ucOrderItem newItem = new ucOrderItem();
                newItem.labelTenMon.Text = item.Name;
                newItem.UpdateItemTotal(1, item.Price); // Số lượng mặc định là 1
                newItem.OnSelect += (s, ev) => UpdateTotalPrice();
                flpOrderList.Controls.Add(newItem);
            }

            // 2. Cuối cùng luôn gọi tính tổng tất cả các món để hiện ở labelTongTien
            UpdateTotalPrice();
        }


        private void UpdateTotalPrice()
        {
            decimal grandTotal = 0;

            foreach (Control ctrl in flpOrderList.Controls)
            {
                if (ctrl is ucOrderItem row)
                {
                    // Lấy giá trị từ labelThanhTien của từng dòng
                    //if (decimal.TryParse(row.labelTongTienItem.Text.Replace(".", "").Replace(",", ""), out decimal rowSum))
                    //{
                    //    grandTotal += rowSum;
                    //}
                    string cleanAmount = row.labelTongTienItem.Text.Replace("VND", "").Replace(".", "").Replace(",", "").Trim();
                    if (decimal.TryParse(cleanAmount, out decimal rowSum))
                    {
                        grandTotal += rowSum;
                    }
                }
            }

            // Hiển thị con số cuối cùng (ví dụ 70.000) lên Form chính
            lbThanhTien.Text = grandTotal.ToString("N0") + " VND";
        }


        private void UpdateNextOrderIdDisplay()
        {
            // Gọi service để lấy số Id tiếp theo
            long nextId = _orderService.GetNextOrderId();
            lbOrderId.Text = nextId.ToString();
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            string shiftName = _kdsService.GetCurrentShiftName();

            lblSystemDateTime.Text = $"{shiftName} - {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
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

        // tạo nút categories
        private async Task LoadCategories()
        {
            // Lấy danh sách từ Service mà đồng nghiệp bạn đã viết
            var categories = await _categoryService.FindAllActiveAsync();

            // flpCategories là cái FlowLayoutPanel chứa các nút Cafe, Trà sữa...
            flpCategories.Controls.Clear();

            foreach (var cat in categories)
            {
                Button btn = new Button();
                btn.Text = cat.Name;
                btn.Tag = cat.Id; // Cất ID vào đây để hàm Click của bạn lấy ra được
                btn.Size = new Size(110, 30); // Chỉnh kích thước cho đều
                btn.BackColor = Color.LightGray;
                btn.FlatStyle = FlatStyle.Flat;

                // Gắn sự kiện mà bạn đã viết ở trên
                btn.Click += CategoryButton_Click;

                flpCategories.Controls.Add(btn);
            }
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (flpOrderList.Controls.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm món vào đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var openShift = _shiftService.GetOpenShift();
                if (openShift == null)
                {
                    MessageBox.Show("Chưa có ca làm việc nào được mở. Vui lòng mở ca trước khi thanh toán.", "Chưa mở ca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var orderItems = new List<OrderItemRequest>();
                foreach (Control ctrl in flpOrderList.Controls)
                {
                    if (ctrl is ucOrderItem row)
                    {
                        string menuName = row.labelTenMon.Text;
                        int quantity = (int)row.nmrSoLuong.Value;

                        var product = _menuRepository.GetAllProducts().FirstOrDefault(p => p.Name == menuName);
                        if (product == null) continue;

                        var priceInfo = product.Prices?.FirstOrDefault();
                        if (priceInfo == null) continue;

                        orderItems.Add(new OrderItemRequest
                        {
                            MenuId = product.Id,
                            Quantity = quantity,
                            Size = ECoffee.Application.Models.MenuSize.Medium // TODO: lấy size thực tế từ UI
                        });
                    }
                }

                var request = new CreateOrderRequest { Items = orderItems };
                long orderId = _orderService.Create(request, _shiftService.GetOpenShift()!.UserId, openShift.Id);

                MessageBox.Show($"Đặt hàng thành công! Mã đơn: {orderId}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                flpOrderList.Controls.Clear();
                UpdateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
