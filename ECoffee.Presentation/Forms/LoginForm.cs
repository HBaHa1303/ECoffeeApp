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
        public LoginForm(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
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
                DialogResult = DialogResult.OK;
                Close();
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
    }
}
