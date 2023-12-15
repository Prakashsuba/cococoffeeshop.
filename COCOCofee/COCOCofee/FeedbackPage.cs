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
    public partial class FeedbackPage : Form
    {
        public FeedbackPage()
        {
            InitializeComponent();
        }
        string projectConnection = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text == "" || txt_Email.Text == "" || txt_Comments.Text == "")
            {
                MessageBox.Show("Missing Informations");
            }
            else
            {
                try
                {
                    string projectConnection = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(projectConnection);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_Feedbacks", con);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar);
                    cmd.Parameters.Add(param1).Value = txt_Name.Text;
                    SqlParameter param3 = new SqlParameter("@Email", SqlDbType.VarChar);
                    cmd.Parameters.Add(param3).Value = txt_Email.Text;
                    SqlParameter param4 = new SqlParameter("@Comments", SqlDbType.VarChar);
                    cmd.Parameters.Add(param4).Value = txt_Comments.Text;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Thanks For Your FeedBacks....");
                    }
                    con.Close();
                    txt_Name.Text = "";
                    txt_Email.Text = "";
                    txt_Comments.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txt_Name.Text = "";
            txt_Email.Text = "";
            txt_Comments.Text = "";
        }

        private void txt_Back_Click(object sender, EventArgs e)
        {
            UsersMainPage UMP = new UsersMainPage();
            UMP.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
