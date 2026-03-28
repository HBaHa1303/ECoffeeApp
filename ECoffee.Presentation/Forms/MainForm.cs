using ECoffee.Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ECoffee.Presentation.Forms
{
    public partial class MainForm : Form
    {
        private readonly StaffManagementForm _staffManagementForm;
        private readonly IUserContext _userContext;
        private readonly LoginForm _loginForm;

        public MainForm(
            StaffManagementForm staffManagementForm, 
            IUserContext userContext,
            LoginForm loginForm)
        {
            InitializeComponent();
            _staffManagementForm = staffManagementForm;
            _userContext = userContext;
            _loginForm = loginForm;
        }

        private void tsmiStaffManagement_Click(object sender, EventArgs e)
        {
            _staffManagementForm.ShowDialog(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
