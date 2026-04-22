using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Enums; // Thêm nếu cần cho MenuSize
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using ECoffee.Application.Services;
using ECoffee.Infrastructure.Entities;
using ECoffee.Infrastructure.Repositories;
using ECoffee.Presentation.Forms;
using ECoffee.Presentation.Services;
using ECoffee.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MenuSize = ECoffee.Application.Enums.MenuSize;

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
        private readonly PaymentModuleService _paymentModuleService;
        private readonly PromotionService _promotionService;
        private long currentUserId;
        private long currentShiftId;
        private long currentPendingOrderId;
        public POSForm(IServiceProvider serviceProvider,
            IMenuRepository menuRepository,
            OrderService orderService,
            KdsService kdsService,
            CategoryService categoryService,
            ShiftService shiftService,
            AuthService authService,
            UserService userService,
            PaymentModuleService paymentModuleService, PromotionService promotionService
             )
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
            _paymentModuleService = paymentModuleService;
            _promotionService = promotionService;
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


                cboTypeOrder.Items.Clear();
                cboTypeOrder.Items.Add("Cash");
                cboTypeOrder.Items.Add("Card");
                cboTypeOrder.SelectedIndex = 0;


                //currentPendingOrderId = _orderService.GetNextOrderId();
                lbOrderId.Text = "NEW";
                // Load dữ liệu lên giao diện
                LoadAllProducts();
                await LoadCategories();
                await LoadPromotions();
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

            lbOrderId.Text = "NEW";

            // 1. Kiểm tra trùng món (Giữ nguyên)
            foreach (Control ctrl in flpOrderList.Controls)
            {
                if (ctrl is ucOrderItem row && row.labelTenMon.Text == item.Name)
                {
                    row.nmrSoLuong.Value += 1;
                    decimal currentPrice = decimal.Parse(row.labelGiaMon.Text.Replace(".", "").Replace(",", ""));
                    row.UpdateItemTotal((int)row.nmrSoLuong.Value, currentPrice);
                    UpdateTotalPrice();
                    return;
                }
            }

            // 2. Tạo món mới
            ucOrderItem newItem = new ucOrderItem();
            newItem.labelTenMon.Text = item.Name;
            newItem.Tag = item.Id;

            // 3. Nạp dữ liệu vào ComboBox TRƯỚC
            newItem.cboSize.DataSource = Enum.GetValues(typeof(ECoffee.Application.Models.MenuSize));
            var defaultSize = ECoffee.Application.Models.MenuSize.Medium;
            newItem.cboSize.SelectedItem = defaultSize;

            // 4. Đăng ký sự kiện thay đổi Size/Số lượng (Sau khi đã có Data)
            newItem.OnDataChanged += (s, ev) =>
            {
                if (newItem.cboSize.SelectedItem != null)
                {
                    // Ép kiểu an toàn bằng Enum.Parse
                    var currentSize = (ECoffee.Application.Models.MenuSize)Enum.Parse(typeof(ECoffee.Application.Models.MenuSize), newItem.cboSize.SelectedItem.ToString());
                    decimal newPrice = _menuRepository.GetPrice(item.Id, currentSize);
                    newItem.UpdateItemTotal((int)newItem.nmrSoLuong.Value, newPrice);
                    UpdateTotalPrice();
                }
            };

            // 5. Sự kiện xóa món
            newItem.OnRemoveClicked += (s, ev) =>
            {
                flpOrderList.Controls.Remove(newItem);
                UpdateTotalPrice();
            };

            // 6. Tính giá mặc định ban đầu cho món mới
            decimal priceMedium = _menuRepository.GetPrice(item.Id, defaultSize);
            newItem.UpdateItemTotal(1, priceMedium);

            // 7. Thêm vào danh sách hiển thị
            flpOrderList.Controls.Add(newItem);
            UpdateTotalPrice();
        }


        private void UpdateTotalPrice()
        {
            decimal grandTotal = 0;

            foreach (Control ctrl in flpOrderList.Controls)
            {
                if (ctrl is ucOrderItem row)
                {
                    
                    string cleanAmount = row.labelTongTienItem.Text.Replace("VND", "").Replace(".", "").Replace(",", "").Trim();
                    if (decimal.TryParse(cleanAmount, out decimal rowSum))
                    {
                        grandTotal += rowSum;
                    }
                }
            }

            if (cboPromotion.SelectedItem is PromotionResponse selectedPromo)
            {
                decimal discount = 0;

                // Xử lý theo từng loại PromotionType (Dựa trên PromotionResponse của bạn)
                switch (selectedPromo.Type)
                {
                    case PromotionType.FixedAmount:
                        // Sử dụng .GetValueOrDefault() để tránh lỗi null sang decimal
                        discount = selectedPromo.DiscountAmount.GetValueOrDefault();
                        break;

                    case PromotionType.Percent:
                        decimal percent = selectedPromo.DiscountPercent.GetValueOrDefault();
                        discount = grandTotal * (percent / 100);
                        break;

                        // Bạn có thể thêm xử lý cho BuyXGetYFree ở đây nếu cần
                }
                discount = Math.Round(discount, 0);
                grandTotal -= discount;
            }

            // Đảm bảo tổng tiền không bị âm
            if (grandTotal < 0) grandTotal = 0;
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

        private async void btThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra giỏ hàng
                if (flpOrderList.Controls.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Kiểm tra ca làm việc
                var openShift = _shiftService.GetOpenShift();
                if (openShift == null)
                {
                    MessageBox.Show("Chưa mở ca làm việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Lấy phương thức thanh toán từ ComboBox bạn đã nạp ở Load
                string paymentMethodStr = cboTypeOrder.SelectedItem?.ToString() ?? "Cash";

                // 4. Tạo Request và GÁN TRẠNG THÁI PAID (3)
                long? selectedPromoId = null;
                if (cboPromotion.SelectedValue != null && cboPromotion.SelectedIndex != -1)
                {
                    selectedPromoId = Convert.ToInt64(cboPromotion.SelectedValue);
                }

                var request = new CreateOrderRequest
                {
                    Items = new List<OrderItemRequest>(),
                    Status = OrderStatus.Paid, // Đơn hàng sẽ có Status = 3 ngay khi tạo
                    Id = currentPendingOrderId,
                    //Note = txtNote.Text
                    PromotionId = selectedPromoId

                };
                string generalNote = txtNote.Text.Trim();
                
                foreach (Control ctrl in flpOrderList.Controls)
                {
                    if (ctrl is ucOrderItem row)
                    {
                        var menuName = row.labelTenMon.Text;
                        var product = _menuRepository.GetAllProducts().FirstOrDefault(p => p.Name == menuName);
                        if (product == null) continue;

                        var itemRequest = new OrderItemRequest
                        {
                            MenuId = product.Id,
                            Quantity = (int)row.nmrSoLuong.Value,
                            // Ép kiểu tường minh để tránh lỗi Ambiguous
                            Size = (ECoffee.Application.Models.MenuSize)row.cboSize.SelectedItem,
                            Note = generalNote
                        };
                        

                        request.Items.Add(itemRequest);
                    }
                }

                // 5. Lưu vào Database
                long orderId = _orderService.Create(request, currentUserId, openShift.Id);
                decimal finalAmount = 0;
                string rawAmount = lbThanhTien.Text.ToUpper().Replace("VND", "").Replace(".", "").Replace(",", "").Trim();
                decimal.TryParse(rawAmount, out finalAmount);

               
                // 6. Tạo thông tin thanh toán (Payment)
                var paymentModel = new PaymentCreateViewModel
                {
                    OrderId = orderId,
                    Method = paymentMethodStr == "Card" ? PaymentMethod.Card : PaymentMethod.Cash,
                    Amount = finalAmount,
                    Status = ECoffee.Infrastructure.Entities.PaymentStatus.Paid,
                    CreatedBy = currentUserId.ToString()
                };

                await _paymentModuleService.CreatePaymentAsync(paymentModel);
                lbOrderId.Text = $"{orderId}";
                MessageBox.Show($"Thanh toán thành công!\nĐơn hàng: {orderId}\nPhương thức: {paymentMethodStr}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 7. Làm sạch giao diện
                flpOrderList.Controls.Clear();
                cboPromotion.SelectedIndex = -1; // Reset lại khuyến mãi về trống
                txtNote.Clear(); // Xóa ghi chú cũ
                UpdateTotalPrice();

                //currentPendingOrderId = _orderService.GetNextOrderId();
                lbOrderId.Text = paymentModel.OrderId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            _authService.Logout();
            Close();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            // Lấy nội dung chữ đang gõ
            string keyword = txtTimKiem.Text.Trim();

            // Gọi hàm lọc món ăn
            SearchProducts(keyword);
        }


        private void SearchProducts(string keyword)
        {
            // 1. Lấy tất cả sản phẩm từ Repository
            var allProducts = _menuRepository.GetAllProducts();

            // 2. Lọc sản phẩm theo tên (không phân biệt hoa thường)
            var filteredProducts = allProducts
                .Where(p => string.IsNullOrEmpty(keyword) ||
                            p.Name.ToLower().Contains(keyword.ToLower()))
                .ToList();

            // 3. Xóa các món cũ trên giao diện
            flbItems.Controls.Clear();

            // 4. Nạp lại các món đã lọc
            foreach (var item in filteredProducts)
            {
                // Xử lý giá tiền (giống như hàm LoadAllProducts bạn đã viết)
                var priceInfo = item.Prices?.FirstOrDefault();
                if (priceInfo != null) item.Price = priceInfo.Price;

                ItemBox uc = new ItemBox();
                uc.labelNameItem.Text = item.Name;
                uc.labelPrice.Text = item.Price.ToString("N0") + " VNĐ";

                // Gắn lại sự kiện chọn món
                uc.OnSelect += (s, ev) => AddToOrder(item);

                flbItems.Controls.Add(uc);
            }
        }

        private async Task LoadPromotions()
        {
            try
            {
                // Truyền chuỗi rỗng "" để Service lấy tất cả các mã đang hoạt động
                var promos = await _promotionService.FindAllActiveAsync("");

                // Dòng này để bạn tự kiểm tra xem đã lấy được dữ liệu chưa
                //MessageBox.Show($"mã giảm giá promo.count ={promos.Count}");

                cboPromotion.DataSource = promos;
                cboPromotion.DisplayMember = "Name";
                cboPromotion.ValueMember = "Id";

                // Để ô chọn trống ban đầu, khách muốn dùng thì mới chọn
                cboPromotion.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // Tránh việc lỗi load mã làm treo cả ứng dụng
                MessageBox.Show("Lỗi thực sự là: " + ex.Message);
            }
        }

        private void cboPromotion_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }
    }
}
