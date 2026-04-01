using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Repositories;
using ECoffee.Application.Services;
using ECoffee.Presentation.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace ECoffee.Presentation
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        private readonly IUserContext _userContext;
        private readonly IServiceProvider _serviceProvider;
        public LoginForm(AuthService authService, IUserContext userContext, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _authService = authService;
            _userContext = userContext;
            _serviceProvider = serviceProvider;
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tbEmail.Text;
                string password = tbPassword.Text;

                LoginRequest loginRequest = new LoginRequest
                {
                    Email = email,
                    Password = password
                };
                _authService.Login(loginRequest);

                if (_userContext.Roles.Count > 1)
                {
                    var selectRole = new SelectRoleForm(_userContext);
                    if (selectRole.ShowDialog(this) == DialogResult.OK)
                    {
                        this.Hide(); // Ẩn Login trước
                        OpenFormByRole(_userContext.ActiveRole);
                    }
                }
                // Trường hợp 2: Chỉ có 1 Role -> Tự động chuyển Form luôn
                else if (_userContext.Roles.Count == 1)
                {
                    string role = _userContext.Roles.First();
                    OpenFormByRole(role);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tài khoản này chưa được cấp quyền!", "Thông báo");
                }
            }
            catch (BadRequestException ex)
            {
                MessageBox.Show(ex.Message, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (UnauthorizedException ex)
            {
                MessageBox.Show(ex.Message, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi không mong muốn. Vui lòng thử lại.", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            tbEmail.Focus();
        }
        private void OpenFormByRole(string roleName)
        {
            Form targetForm;

            

            try {
                switch (roleName.ToLower())
                {
                    case "manager":
                        _serviceProvider.GetRequiredService<MainForm>().ShowDialog();
                        break;
                    case "cashier":
                        //targetForm = _serviceProvider.GetRequiredService<POSForm>();

                        _serviceProvider.GetRequiredService<POSForm>().ShowDialog() ;
                        break;
                    case "barista":
                        //targetForm = _serviceProvider.GetRequiredService<frmKdsDashboard>();
                        _serviceProvider.GetRequiredService<frmKdsDashboard>().ShowDialog();
                        break;
                    
                    default:
                        MessageBox.Show("Vai trò không hợp lệ!");
                        return;
                }

                //targetForm.Show();
                //targetForm.FormClosed += (s, args) => System.Windows.Forms.Application.Exit();
            }
            catch (Exception ex)
            {
                // Nếu mở Form mới bị lỗi, phải hiện Login lại để user biết
                this.Show();
                MessageBox.Show("Không thể mở màn hình chức năng: " + ex.Message);
            }
        }
    }
}
