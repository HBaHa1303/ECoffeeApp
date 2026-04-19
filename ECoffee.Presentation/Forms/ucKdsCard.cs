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
            string allItemNotes = "";
            foreach (var item in data.Items)
            {
                string itemText = $"{item.ProductName} x{item.Quantity}";

                // Thêm Size nếu có
                if (!string.IsNullOrEmpty(item.SizeName))
                {
                    itemText += $"\n- Size: {item.SizeName}";
                }

                if (!string.IsNullOrEmpty(item.Note))
                {
                    // Gom ghi chú lại để hiện ở bảng tổng phía dưới
                    allItemNotes += $"{item.Note}; ";
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
            var finalNote = !string.IsNullOrEmpty(allItemNotes) ? allItemNotes.TrimEnd(' ', ';') : data.OrderNote;

            if (!string.IsNullOrEmpty(finalNote))
            {
                lblNote.Text = $"* Ghi chú: {finalNote}";
                lblNote.Visible = true;
                panel1.Visible = true;
                // Để label tự giãn độ cao theo chữ
                lblNote.AutoSize = true;
                panel1.Height = lblNote.Height + 15;
            }
            else
            {
                panel1.Visible = false;
                panel1.Height = 0;
            }

            // 4. Cập nhật lại giao diện
            this.Refresh();
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
