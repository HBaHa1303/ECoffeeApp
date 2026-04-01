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
            // Hiển thị mã đơn hàng (Sử dụng thuộc tính OrderNumber bạn đã viết sẵn)
            lblOrderNumber.Text = data.OrderNumber;

            // Tính thời gian đã trôi qua
            var minutes = (int)(DateTime.Now - data.CreatedAt).TotalMinutes;
            lblTimeAgo.Text = $"{minutes} phút";

            // Xóa và nạp lại danh sách món ăn
            flpItems.Controls.Clear();
            foreach (var item in data.Items)
            {
                Label lblItem = new Label();
                // Hiển thị: Tên món xSố lượng (Ghi chú)
                lblItem.Text = $"{item.ProductName} x{item.Quantity} \n {item.Note}";
                lblItem.AutoSize = true;
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
