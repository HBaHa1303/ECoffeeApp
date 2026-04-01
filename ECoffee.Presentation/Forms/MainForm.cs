using ECoffee.Application.Repositories;
using ECoffee.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ECoffee.Presentation.Forms
{
    public partial class MainForm : Form
    {
        private readonly StaffManagementForm _staffManagementForm;
        private readonly AuthService _authService;

        public MainForm(
            StaffManagementForm staffManagementForm,
            AuthService authService)
        {
            InitializeComponent();
            _staffManagementForm = staffManagementForm;
            _authService = authService;
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
    }
}
