using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Repositories;
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
    public partial class SelectRoleForm : Form
    {
        private readonly IUserContext _userContext;
        public SelectRoleForm(IUserContext userContext)
        {
            InitializeComponent();
            _userContext = userContext;
        }

        private void SelectRoleForm_Load(object sender, EventArgs e)
        {
            var roles = _userContext.Roles;
            cbRoles.DataSource = roles;
            if (roles.Count > 0)
                cbRoles.SelectedIndex = 0;
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            if (cbRoles.SelectedItem is string selectedRole)
            {
                var session = new UserSession(
                    _userContext.UserId,
                    _userContext.Email,
                    selectedRole,
                    _userContext.Roles
                );
                _userContext.Set(session);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 role để tiếp tục.");
            }
        }
    }
}




    //private void btnOk_Click(object sender, EventArgs e)
    //{
    //    
    //}
