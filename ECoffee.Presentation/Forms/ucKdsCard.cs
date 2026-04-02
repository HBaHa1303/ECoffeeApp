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
            lblOrderNumber.Text = data.OrderNumber;

            var minutes = (int)(DateTime.Now - data.CreatedAt).TotalMinutes;
            lblTimeAgo.Text = $"{minutes} phút";

            flpItems.Controls.Clear();
            foreach (var item in data.Items)
            {
                Label lblItem = new Label();

                // --- ĐOẠN CẦN SỬA ---
                // Kiểm tra xem món có Size hay không (giả sử thuộc tính là item.SizeName)
                string sizeInfo = !string.IsNullOrEmpty(item.SizeName) ? $"Size: {item.SizeName}" : "";

                // Hiển thị: Tên món xSố lượng
                //           Size: Medium
                //           Note: ...
                lblItem.Text = $"{item.ProductName} x{item.Quantity}\n{sizeInfo}\n{item.Note}";
                // ---------------------

                lblItem.AutoSize = true;
                lblItem.Margin = new Padding(0, 0, 0, 5); // Thêm chút khoảng cách dưới mỗi món
                flpItems.Controls.Add(lblItem);
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
