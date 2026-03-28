using ECoffee.Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ECoffee.Presentation.Forms
{
    public partial class MainForm : Form
    {
        private readonly StaffManagementForm _staffManagementForm;

        public MainForm(
            StaffManagementForm staffManagementForm)
        {
            InitializeComponent();
            _staffManagementForm = staffManagementForm;
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
