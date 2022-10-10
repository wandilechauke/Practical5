using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;

namespace Semester_2_p5
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();

        private void btnHard_Click(object sender, EventArgs e)
        {
            User U = new User();

            U.UserID = int.Parse(txtUserID.Text);

            bll.HardDeleteUser(U.UserID);
            dgvUser.DataSource = bll.GetUser();
        }

        private void btnSoft_Click(object sender, EventArgs e)
        {
            User U = new User();

            U.RoleID = int.Parse(cmbRole.SelectedValue.ToString());
            U.Status = cmbStatus.SelectedItem.ToString();
            bll.UpdateUser(U);
            dgvUser.DataSource = bll.GetUser();

        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            txtUserID.Enabled = false;

            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("In-active");

            cmbRole.DataSource = bll.GetRole();

            cmbRole.DisplayMember = "RoleDescription";
            cmbRole.ValueMember = "RoleID";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User U = new User();

            U.Name = txtName.Text;
            U.Surname = txtSurname.Text;
            U.Email = txtEmail.Text;
            U.Password = txtPassword.Text;
            U.RoleID = int.Parse(cmbRole.SelectedValue.ToString());
            U.Status = cmbStatus.SelectedItem.ToString();

            int x = bll.InsertUser(U);
            {
                MessageBox.Show(x + "User is Added!!");
            }
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUser.SelectedRows.Count > 0)
            {
                txtUserID.Text = dgvUser.SelectedRows[0].Cells["UserID"].Value.ToString();
                txtName.Text = dgvUser.SelectedRows[0].Cells["Name"].Value.ToString();
                txtSurname.Text = dgvUser.SelectedRows[0].Cells["Surname"].Value.ToString();
                txtEmail.Text = dgvUser.SelectedRows[0].Cells["Email"].Value.ToString();
                txtPassword.Text = dgvUser.SelectedRows[0].Cells["Password"].Value.ToString();
                cmbRole.SelectedValue = dgvUser.SelectedRows[0].Cells["RoleID"].Value.ToString();
                cmbStatus.SelectedItem = dgvUser.SelectedRows[0].Cells["Status"].Value.ToString();
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvUser.DataSource = bll.GetUser();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Category form = new Category();
            form.Show();
            this.Hide();

        }
    }
}
