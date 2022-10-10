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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            User U = new User();
            U.CategoryDescription = txtCategoryDesc.Text;

            int x = bll.InsertCategory(U);
            {
                MessageBox.Show(x + "Category Added!");
            }

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvCategory.DataSource = bll.GetCategory();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmPhotos form = new frmPhotos();
            form.Show();
            this.Hide();
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                txtId.Text = dgvCategory.SelectedRows[0].Cells["CategoryID"].Value.ToString();
                txtCategoryDesc.Text = dgvCategory.SelectedRows[0].Cells["CategoryDescription"].Value.ToString();
            }
        }

        private void Category_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false; 
        }
    }
}
