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
    public partial class ItemBox : UserControl
    {
        public event EventHandler OnSelect;
        public ItemBox()
        {
            InitializeComponent();
            this.Click += ItemBox_Click;

            // 2. Gắn sự kiện click cho các thành phần con bên trong
            // Thay 'labelNameItem' và 'labelPrice' bằng tên thật của bạn ở Design
            if (labelNameItem != null) labelNameItem.Click += ItemBox_Click;
            if (labelPrice != null) labelPrice.Click += ItemBox_Click;
        }


        private void ItemBox_Click(object sender, EventArgs e)
        {
            
            OnSelect?.Invoke(this, e);
        }
    }
}
