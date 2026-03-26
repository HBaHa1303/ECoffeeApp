using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Enums;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECoffee.Presentation.Forms
{
    public partial class StaffManagementForm : Form
    {
        private readonly UserService _userService;
        private readonly RoleService _roleService;
        public StaffManagementForm(UserService userService, RoleService roleService)
        {
            InitializeComponent();
            _userService = userService;
            _roleService = roleService;
        }

        private async void bCreate_Click(object sender, EventArgs e)
        {
            var form = new StaffForm(_userService, _roleService, FormMode.Create, null);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                await LoadStaffAsync();
            }
        }

        private async void StaffManagementForm_Load(object sender, EventArgs e)
        {
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.Columns["Id"].DataPropertyName = "Id";
            dgvStaff.Columns["Email"].DataPropertyName = "Email";
            dgvStaff.Columns["FullName"].DataPropertyName = "FullName";
            dgvStaff.Columns["Status"].DataPropertyName = "StatusText";
            dgvStaff.Columns["Address"].DataPropertyName = "Address";
            dgvStaff.Columns["DateOfBirth"].DataPropertyName = "DateOfBirth";
            dgvStaff.Columns["DateOfBirth"].DefaultCellStyle.Format = "yyyy-MM-dd";
            ((DataGridViewButtonColumn)dgvStaff.Columns["Edit"]).UseColumnTextForButtonValue = true;
            ((DataGridViewButtonColumn)dgvStaff.Columns["ToggleStatus"]).UseColumnTextForButtonValue = false;
            await LoadStaffAsync();
        }

        private async Task LoadStaffAsync()
        {
            List<UserResponse> userResponses = await _userService.FindAllAsync();
            dgvStaff.DataSource = null;
            dgvStaff.DataSource = userResponses;
        }

        private void dgvStaff_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStaff.Columns[e.ColumnIndex].Name == "ToggleStatus")
            {
                var user = dgvStaff.Rows[e.RowIndex].DataBoundItem as UserResponse;

                e.Value = user.Status == UserStatus.Activate ? "Khóa" : "Mở Khóa";
            }
        }

        private async void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var user = (UserResponse)dgvStaff.Rows[e.RowIndex].DataBoundItem;
            var column = dgvStaff.Columns[e.ColumnIndex].Name;

            switch (column)
            {
                case "Edit":
                    StaffForm form = new StaffForm(_userService, _roleService, FormMode.Edit, user.Id);
                    if (form.ShowDialog(this) == DialogResult.OK)
                        await LoadStaffAsync();
                    break;

                case "ToggleStatus":
                    if (user.Status == UserStatus.Activate)
                        await _userService.LockAsync(user.Id);
                    else
                        await _userService.UnlockAsync(user.Id);

                    await LoadStaffAsync();
                    break;
            }
        }
    }
}
