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
    public partial class ucOrderItem : UserControl
    {
        public event EventHandler? OnSelect;
        public ucOrderItem()
        {
            InitializeComponent();
        }
        public void UpdateItemTotal(int quantity, decimal price)
        {
            // Giả sử tên NumericUpDown của bạn là nmrSoLuong
            nmrSoLuong.Value = (decimal)quantity;

            labelGiaMon.Text = price.ToString("N0");

            // Tính tổng tiền cho dòng này
            decimal totalRow = nmrSoLuong.Value * price;
            labelTongTienItem.Text = totalRow.ToString("N0");
        }
        private void nmrSoLuong_ValueChanged(object sender, EventArgs e)
        {
            // 1. Lấy đơn giá từ label (xóa dấu chấm phân cách)
            decimal price = 0;
            string priceText = labelGiaMon.Text.Replace(".", "").Replace(",", "");
            decimal.TryParse(priceText, out price);

            // 2. Tính thành tiền của dòng này
            // nmrSoLuong.Value là decimal nên kết quả totalRow sẽ là decimal (Chuẩn!)
            decimal totalRow = nmrSoLuong.Value * price;
            labelTongTienItem.Text = totalRow.ToString("N0");

            // 3. Gọi Form chính tính lại tổng cộng
            // OnSelect là event bạn đã tạo ở các bước trước
            OnSelect?.Invoke(this, e);
        }
    }
}
