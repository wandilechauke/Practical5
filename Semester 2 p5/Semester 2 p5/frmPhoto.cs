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
    public partial class frmPhoto : Form
    {
        public frmPhoto()
        {
            InitializeComponent();
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            User U = new User();

            U.RoleDescription = txtDesc.Text;

            int x = bll.InsertRole(U);
            {
                MessageBox.Show(x + "Role is Added!!");
            }

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvRole.DataSource = bll.GetRole();
        }

        private void dgvRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRole.SelectedRows.Count > 0)
            {
                txtID.Text = dgvRole.SelectedRows[0].Cells["RoleID"].Value.ToString();
                txtDesc.Text = dgvRole.SelectedRows[0].Cells["RoleDescription"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmUser form = new frmUser();
            form.Show();
            this.Hide();
        }

        private void frmPhoto_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
        }
    }
}
