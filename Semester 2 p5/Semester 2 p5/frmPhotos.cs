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
using System.IO;
using System.Data.SqlClient;


namespace Semester_2_p5
{
    public partial class frmPhotos : Form
    {
        public frmPhotos()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source = .; Initial Catalog = Semester 2 prac5; Integrated Security = true;");
        SqlCommand dbComm;
        SqlDataAdapter dbAdapter;


        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void btnUpload_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "select image(*.JpG; *.Gif) |*.JpG; *.png; *.Gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            User U = new User();

            //dbComm = new SqlCommand("Insert into tblPhoto(UploadData,Image)Values(@UploadData,@Image)", conn);
            //dbComm.Parameters.AddWithValue("UploadData", pictureBox1.Text);
            ////MemoryStream memstr = new MemoryStream();
            //pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
            //dbComm.Parameters.AddWithValue("Image", memstr.ToArray());
            //conn.Open();
            //dbComm.ExecuteNonQuery();
            //conn.Close();

            //U.PhotoID = int.Parse(txtPhoto.Text);
            U.Name = txtName.Text;
            U.ContentType = txtContent.Text;
            U.Date = dtaPhoto.Value.ToString();
           
            U.Title = txtTitle.Text;
            U.UserID = int.Parse(cmbUser.SelectedValue.ToString());
            U.CategoryID = int.Parse(cmbCategory.SelectedValue.ToString());
            U.Status = cmbStatus.SelectedItem.ToString();

            int x = bll.InsertPhoto(U);
            {
                MessageBox.Show(x + "Photo Added!!");
            }

            //load_data();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            User U = new User();

            U.PhotoID = int.Parse(txtPhoto.Text);
            U.Status = cmbStatus.SelectedItem.ToString();

            int x = bll.UpdatePhoto(U);
            {
                MessageBox.Show(x + "Photo is updated!!");

            }

        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            dgvPhotos.DataSource = bll.GetPhoto();
        }

        private void dgvPhotos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhotos.SelectedRows.Count > 0)
            {
                txtPhoto.Text = dgvPhotos.SelectedRows[0].Cells["PhotoID"].Value.ToString();
                txtName.Text = dgvPhotos.SelectedRows[0].Cells["Name"].Value.ToString();
                txtContent.Text = dgvPhotos.SelectedRows[0].Cells["ContentType"].Value.ToString();
                dtaPhoto.Text = dgvPhotos.SelectedRows[0].Cells["Date"].Value.ToString();
                txtTitle.Text = dgvPhotos.SelectedRows[0].Cells["Title"].Value.ToString();
                cmbUser.SelectedValue = dgvPhotos.SelectedRows[0].Cells["UserID"].Value.ToString();
                cmbCategory.SelectedValue = dgvPhotos.SelectedRows[0].Cells["CategoryID"].Value.ToString();
                cmbStatus.SelectedItem = dgvPhotos.SelectedRows[0].Cells["Status"].Value.ToString();
            }
        }

        private void frmPhotos_Load(object sender, EventArgs e)
        {
            txtPhoto.Enabled = false;

            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("In-active");

            cmbCategory.DataSource = bll.GetCategory();

            cmbCategory.DisplayMember = "CategoryDescription";
            cmbCategory.ValueMember = "CategoryID";

            cmbUser.DataSource = bll.GetUser();

            cmbUser.DisplayMember = "Name";
            cmbUser.ValueMember = "UserID";

            //load_data();
        }

        //private void btnNext_Click(object sender, EventArgs e)
        //{
        //    Category form = new Category();
        //    form.Show();
        //    this.Hide();
        //}
        //public void load_data()
        //{
        //    dbComm = new SqlCommand("Select * from tblPhoto order by PhotoID  desc ", conn);
        //    SqlDataAdapter dbAdapter = new SqlDataAdapter();

        //    dbAdapter.SelectCommand = dbComm;
        //    DataTable dt = new DataTable();
        //    dt.Clear();
        //    dbAdapter.Fill(dt);
        //    dgvPhotos.RowTemplate.Height = 75;
        //    dgvPhotos.DataSource = dt;
        //    DataGridViewImageColumn pic1 = new DataGridViewImageColumn();
        //    pic1 = (DataGridViewImageColumn)dgvPhotos.Columns[2];
        //    pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
        //}
    }
}
