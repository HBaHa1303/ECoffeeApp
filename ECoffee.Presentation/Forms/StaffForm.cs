using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Services;
using ECoffee.Application.ValueObjects;
using ECoffee.Presentation.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECoffee.Presentation.Forms
{
    public partial class StaffForm : Form
    {
        private readonly FormMode _mode;
        private readonly long? _userId;
        private readonly UserService _userService;
        private readonly RoleService _roleService;

        public StaffForm(UserService userService, RoleService roleService, FormMode mode, long? userId)
        {
            InitializeComponent();
            _mode = mode;
            _userId = userId;
            _userService = userService;
            _roleService = roleService;
        }

        private async void StaffForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<RoleResponse> roles = await _roleService.FindAllAsync();

                clbRoles.DataSource = roles;
                clbRoles.DisplayMember = "Name";
                clbRoles.ValueMember = "Name";

                if (_mode == FormMode.Create)
                {
                    lHeader.Text = "Tạo người dùng";
                    bSubmit.Text = "Tạo";
                }
                if (_mode == FormMode.Edit)
                {
                    lHeader.Text = "Sửa người dùng";
                    bSubmit.Text = "Sửa";
                    tbPassword.Enabled = false;
                    tbEmail.Enabled = false;
                    if (_userId is null)
                    {
                        throw new BadRequestException("Sửa thông tin cần thông tin user id");
                    }
                    UserResponse userResponse = _userService.FindUserById(_userId.Value);

                    tbAddress.Text = userResponse.Address;
                    tbEmail.Text = userResponse.Email;
                    tbFullName.Text = userResponse.FullName;
                    dtpDateOfBirth.Value = userResponse.DateOfBirth.ToDateTime(TimeOnly.MinValue);

                    var userRoles = userResponse.Roles;

                    for (int i = 0; i < clbRoles.Items.Count; i++)
                    {
                        var roleItem = (RoleResponse)clbRoles.Items[i];
                        if (userRoles.Contains(roleItem.Name))
                        {
                            clbRoles.SetItemChecked(i, true);
                        }
                    }
                }
            }
            catch (BadRequestException ex)
            {
                MessageBox.Show(ex.Message, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi không mong muốn. Vui lòng thử lại.", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void bSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tbEmail.Text;
                string fullName = tbFullName.Text;
                string password = tbPassword.Text;
                string address = tbAddress.Text;
                DateOnly dateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value);
                List<string> selectedRoles = GetSelectedRoles();
                string message = string.Empty;
                if (_mode == FormMode.Create)
                {
                    await CreateUser(email, fullName, password, address, dateOfBirth, selectedRoles);
                    message = "Tạo nhân viên thành công";
                }
                if (_mode == FormMode.Edit)
                {
                    if (_userId is null)
                    {
                        throw new BadRequestException("Sửa thông tin cần thông tin user id");
                    }
                    await UpdateUser(_userId.Value, fullName, address, dateOfBirth, selectedRoles);
                    message = "Cập nhật nhân viên thành công";
                }
                MessageBox.Show(message, "Thành công", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
            }
            catch (BadRequestException ex)
            {
                MessageBox.Show(ex.Message, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ConflictException ex)
            {
                MessageBox.Show(ex.Message, "Thông tin người dùng đã tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi không mong muốn. Vui lòng thử lại.", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdateUser(long id, string fullName, string address, DateOnly dateOfBirth, List<string> roles) 
        {
            UpdateUserRequest request = new UpdateUserRequest
            {
                FullName = fullName,
                Address = address,
                DayOfBirth = dateOfBirth,
                Roles = roles
            };

            await _userService.UpdateUserAsync(id, request);
        }

        private async Task CreateUser (string email, string fullName, string password, string address, DateOnly dateOfBirth, List<string> roles)
        {
            CreateUserRequest request = new CreateUserRequest
            {
                Email = email,
                FullName = fullName,
                Password = password,
                Address = address,
                DayOfBirth = dateOfBirth,
                Roles = roles
            };

            await _userService.CreateUserAsync(request);

        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<string> GetSelectedRoles()
        {
            return clbRoles.CheckedItems
                           .Cast<RoleResponse>()
                           .Select(r => r.Name)
                           .ToList();
        }
    }
}
