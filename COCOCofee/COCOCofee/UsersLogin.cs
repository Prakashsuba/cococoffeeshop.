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
    public partial class UsersLogin : Form
    {
        public UsersLogin()
        {
            InitializeComponent();
        }

        private void txt_btnLogin_Click(object sender, EventArgs e)
        {
            string projectConnection = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(projectConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Coffee_Login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@Username", SqlDbType.VarChar);
            cmd.Parameters.Add(param1).Value = txt_Uname.Text;
            SqlParameter param2 = new SqlParameter("@Password", SqlDbType.VarChar);
            cmd.Parameters.Add(param2).Value = txt_Password.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            string abc = ds.Tables[0].Rows[0][0].ToString();
            if (abc != "")
            {
                MessageBox.Show("Login Successfull...");
                UsersMainPage UMP = new UsersMainPage();
                UMP.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Enter Valid Username and Password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_Uname.Clear();
            txt_Password.Clear();
        }

        private void link_Login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register rg = new Register();
            rg.Show();
            this.Hide();
        }

        private void txt_ChBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_ChBoxShow.Checked)
            {
                txt_Password.PasswordChar = '\0';
            }
            else
            {
                txt_Password.PasswordChar = '*';

            }
        }

        private void txt_Back_Click(object sender, EventArgs e)
        {
            Index i = new Index();
            i.Show();
            this.Hide();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
