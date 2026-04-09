using ECoffee.Application.DTOs.Request;
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
    public partial class ucKdsCard : UserControl
    {
        public event EventHandler OnFinishClicked;
        public ucKdsCard()
        {
            InitializeComponent();
        }
        public void SetData(KdsOrderDto data)
        {
            // 1. Gán thông tin Header
            lblOrderNumber.Text = $"#{data.OrderId}";
            lblTimeAgo.Text = $"{(int)(DateTime.Now - data.CreatedAt).TotalMinutes} phút";

            // 2. Nạp danh sách món ăn (Chỉ hiện Tên, Số lượng và Size)
            flpItems.Controls.Clear();
            foreach (var item in data.Items)
            {
                string itemText = $"{item.ProductName} x{item.Quantity}";

                // Thêm Size nếu có
                if (!string.IsNullOrEmpty(item.SizeName))
                {
                    itemText += $"\n- Size: {item.SizeName}";
                }

                // --- ĐÃ BỎ ĐOẠN HIỆN NOTE RIÊNG Ở ĐÂY ---

                Label lblItem = new Label
                {
                    Text = itemText,
                    AutoSize = true,
                    Width = 230,
                    Margin = new Padding(5, 5, 5, 5),
                    Font = new Font("Segoe UI", 9F)
                };
                flpItems.Controls.Add(lblItem);
            }

            // 3. Xử lý Ghi chú tổng của đơn hàng (Cái bảng màu vàng bạn muốn giữ)
            var orderNote = data.Items.FirstOrDefault(x => !string.IsNullOrEmpty(x.Note))?.Note;

            if (!string.IsNullOrEmpty(orderNote))
            {
                lblNote.Text = $"* Ghi chú: {orderNote}";
                lblNote.Visible = true;
                panel1.Visible = true;
                panel1.Height = lblNote.Height + 10;
            }
            else
            {
                panel1.Visible = false;
                panel1.Height = 0;
            }

            // 4. Cập nhật lại giao diện
            this.AutoSize = false;
            this.AutoSize = true;
            this.PerformLayout();

            if (this.Height < this.PreferredSize.Height)
            {
                this.Height = this.PreferredSize.Height;
            }
        }
        private void btnAction_Click(object sender, EventArgs e)
        {
            OnFinishClicked?.Invoke(this, e);
        }

        public void HideFinishButton()
        {
            btnAction.Visible = false;
        }
    }
}
