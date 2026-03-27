using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Services;
using ECoffee.Presentation.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace ECoffee.Presentation
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        private readonly IServiceProvider _services;
        public LoginForm(AuthService authService, IServiceProvider Services)
        {
            InitializeComponent();
            _authService = authService;
            _services = Services;
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

                MessageBox.Show("Đăng nhập thành công", "Thành công");
                var form = _services.GetRequiredService<StaffManagementForm>();
                form.ShowDialog(this);
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
    }
}
