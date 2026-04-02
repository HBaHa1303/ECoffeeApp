using ECoffee.Application.Services;

namespace ECoffee.Presentation.Forms
{
    public partial class MainForm : Form
    {
        private readonly StaffManagementForm _staffManagementForm;
        private readonly AuthService _authService;
        private readonly ReportForm _reportForm;
        private readonly PromotionManagementForm _promotionManagementForm;
        private readonly CategoryManagementForm _categoryManagementForm;
        private readonly MenuManagementForm _menuManagementForm;
        private readonly PaymentManagementForm _paymentManagementForm;

        public MainForm(
            StaffManagementForm staffManagementForm,
            AuthService authService,
            ReportForm reportForm,
            PromotionManagementForm promotionManagementForm,
            CategoryManagementForm categoryManagementForm,
            MenuManagementForm menuManagementForm,
            PaymentManagementForm paymentManagementForm)
        {
            InitializeComponent();
            _staffManagementForm = staffManagementForm;
            _authService = authService;
            _reportForm = reportForm;
            _promotionManagementForm = promotionManagementForm;
            _categoryManagementForm = categoryManagementForm;
            _menuManagementForm = menuManagementForm;
            _paymentManagementForm = paymentManagementForm;
        }

        private void tsmiStaffManagement_Click(object sender, EventArgs e)
        {
            _staffManagementForm.ShowDialog(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void tsmiLogout_Click(object sender, EventArgs e)
        {
            _authService.Logout();
            MessageBox.Show("Bạn đã đăng xuất thành công khỏi hệ thống.", "Thành công");
            Close();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void tsmiReportOrder_Click(object sender, EventArgs e)
        {
            try
            {
                _reportForm.ShowDialog(this);
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi không mong muốn. Vui lòng thử lại.", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmiPromotion_Click(object sender, EventArgs e)
        {
            _promotionManagementForm.ShowDialog(this);
        }

        private void tsmiCategoryManagement_Click(object sender, EventArgs e)
        {
            try
            {
                _categoryManagementForm.ShowDialog(this);
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi không mong muốn. Vui lòng thử lại.", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _paymentManagementForm.ShowDialog(this);
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _menuManagementForm.ShowDialog(this);
        }

        private void chỉnhSửaThựcĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new MenuEditForm();
            form.ShowDialog(this);
        }
    }
}
