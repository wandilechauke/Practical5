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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();

        private void chkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
                var checkBox = (CheckBox)sender;
                checkBox.Text = "View";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                var checkBox = (CheckBox)sender;
                checkBox.Text = "Hide";

            }
                    
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = bll.GetLogin(txtEmail.Text, txtPassword.Text);

            if(dt.Rows.Count > 0)
            {
                frmPhoto form = new frmPhoto();
                form.Show();
                this.Hide();
            }
            else 
            {
                panel1.Visible = true;
            }
        }

        private void lblWrong_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void txtEmail_TextChanged(object sender, EventArgs e)
        //{
        //    if(string .IsNullOrEmpty(txtEmail.Text) || (!Regex.IsMatch(txtEmail.Text, @"^([\w\-\-]+)@(\w\)"))
        //    {
        //        errorProvider1.SetError(txtEmail, "Please enter correct email");
        //    }


    }
}
