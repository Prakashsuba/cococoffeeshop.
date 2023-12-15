using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COCOCofee
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UsersLogin uln = new UsersLogin();
            uln.Show();
            this.Hide();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string projectConnection = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(projectConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Coffee_Register", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar);
            cmd.Parameters.Add(param1).Value = txt_name.Text;
            SqlParameter param2 = new SqlParameter("@Email", SqlDbType.VarChar);
            cmd.Parameters.Add(param2).Value = txt_email.Text;
            SqlParameter param3 = new SqlParameter("@Username", SqlDbType.VarChar);
            cmd.Parameters.Add(param3).Value = txt_uname.Text;
            SqlParameter param4 = new SqlParameter("@Password", SqlDbType.VarChar);
            cmd.Parameters.Add(param4).Value = txt_pwd.Text;
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Registration Successfully...");
                UsersLogin Ul = new UsersLogin();
                Ul.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Please Enter Valid Data");
            }

            con.Close();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_email.Clear();
            txt_uname.Clear();
            txt_pwd.Clear();
        }

        private void txt_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_checkBox.Checked)
            {
                txt_pwd.PasswordChar = '\0';
            }
            else
            {
                txt_pwd.PasswordChar = '*';

            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
