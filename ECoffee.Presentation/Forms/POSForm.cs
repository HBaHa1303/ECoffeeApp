using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using ECoffee.Application.Services;
using ECoffee.Application.Enums; // Thêm nếu cần cho MenuSize
using ECoffee.Infrastructure.Repositories;
using ECoffee.Presentation.Forms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECoffee.Presentation.Forms
{
    public partial class POSForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly CategoryService _categoryService;
        private readonly IMenuRepository _menuRepository;
        private readonly OrderService _orderService;
        private readonly KdsService _kdsService;
        private readonly ShiftService _shiftService;
        private readonly AuthService _authService;
        private readonly UserService _userService;

        private long currentUserId;
        private long currentShiftId;
        public POSForm(IServiceProvider serviceProvider,
            IMenuRepository menuRepository,
            OrderService orderService,
            KdsService kdsService,
            CategoryService categoryService,
            ShiftService shiftService,
            AuthService authService,
            UserService userService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _menuRepository = menuRepository;
            _orderService = orderService;
            _kdsService = kdsService;
            _categoryService = categoryService;
            _shiftService = shiftService;
            _authService = authService;
            _userService = userService;
        }


        private async void POSForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Tự động lấy User đầu tiên có trong bảng Users của máy đó
                var loggedInUserId = _serviceProvider.GetRequiredService<IUserContext>().Id;
                if (loggedInUserId != 0)
                {
                    currentUserId = loggedInUserId;
                }
                else
                {
                    // Nếu Context chưa có ID, ta mới dùng phương án dự phòng (hoặc báo lỗi)
                    var allUsers = await _userService.FindAllAsync();
                    currentUserId = allUsers.First().Id;
                }
                // 2. Tự động lấy hoặc tạo Ca làm việc (Shift)
                // Gọi hàm kiểm tra ca dựa trên giờ hệ thống
                currentShiftId = _kdsService.GetCurrentShiftId();

                // Load dữ liệu lên giao diện
                LoadAllProducts();
                await LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đồng bộ dữ liệu ban đầu: " + ex.Message);
            }
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
                newItem.Tag = item.Id; // LƯU ID MÓN ĂN VÀO ĐÂY
                newItem.UpdateItemTotal(1, item.Price);
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
                            Size = ECoffee.Application.Models.MenuSize.Medium 
                        });
                    }
                }

                var request = new CreateOrderRequest { Items = orderItems };

                if (!long.TryParse(lbOrderId.Text, out long currentIdOnUI))
                {
                    currentIdOnUI = 0;
                }

                long orderId = _orderService.Create(request, _shiftService.GetOpenShift()!.UserId, openShift.Id,currentIdOnUI);

                MessageBox.Show($"Đặt hàng thành công! Mã đơn: {orderId}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                flpOrderList.Controls.Clear();
                UpdateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            _authService.Logout();
            Close();
        }

        
    }
}
