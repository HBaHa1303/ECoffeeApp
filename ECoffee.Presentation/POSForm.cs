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
        private readonly IMenuRepository _menuRepository;
        private readonly OrderService _orderService;
        public POSForm(IServiceProvider serviceProvider, IMenuRepository menuRepository, OrderService orderService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _menuRepository = menuRepository;
            _orderService = orderService;
            btCaPhe.Click += CategoryButton_Click;
            btTraTraiCay.Click += CategoryButton_Click;
            btTraSua.Click += CategoryButton_Click;
            btSinhTo.Click += CategoryButton_Click;
            btKem.Click += CategoryButton_Click;
            btBanhNgot.Click += CategoryButton_Click;
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

        private void POSForm_Load(object sender, EventArgs e)
        {
            //UpdateNextOrderIdDisplay();
            LoadAllProducts();
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
    }
}
