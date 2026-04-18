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

            // Gán cho chính cái UserControl (vùng nền xám)
            this.Click += ItemBox_Click;

            // Duyệt qua mọi control con (Label, Panel, v.v.) để gán sự kiện
            foreach (Control c in this.Controls)
            {
                c.Click += ItemBox_Click;
                // Thêm dòng này để người dùng biết là bấm được (hiện hình bàn tay)
                c.Cursor = Cursors.Hand;
            }
            this.Cursor = Cursors.Hand;
        }

        private void ItemBox_Click(object sender, EventArgs e)
        {
            
            OnSelect?.Invoke(this, e);
        }
    }
}
