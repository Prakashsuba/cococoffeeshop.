using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COCOCofee
{
    public partial class EmployeeDetails : Form
    {
        public EmployeeDetails()
        {
            InitializeComponent();
        }
        string projectConnection = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txt_Fname.Clear();
            txt_GendercomboBox1.Text = "";
            txt_Mobile.Clear();
            txt_State.Clear();
            txt_City.Clear();
            txt_Email.Clear();
            dateTimePickerDOB.Value = DateTime.Now;
            dateTimePickerJoinDate.Value = DateTime.Now;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Fname.Text == "" || txt_GendercomboBox1.Text == "" || dateTimePickerDOB.Text == "" || txt_Mobile.Text == "" || txt_Email.Text == "" || dateTimePickerJoinDate.Text == "" || txt_State.Text == "" || txt_City.Text == "")
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
                    SqlCommand cmd = new SqlCommand("SP_Insert_EmployeeDetails", con);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar);
                    cmd.Parameters.Add(param1).Value = txt_Fname.Text;
                    SqlParameter param3 = new SqlParameter("@Gender", SqlDbType.VarChar);
                    cmd.Parameters.Add(param3).Value = txt_GendercomboBox1.SelectedItem.ToString();
                    SqlParameter param4 = new SqlParameter("DOB", SqlDbType.VarChar);
                    cmd.Parameters.Add(param4).Value = dateTimePickerDOB.Text;
                    SqlParameter param5 = new SqlParameter("@Mobile", SqlDbType.VarChar);
                    cmd.Parameters.Add(param5).Value = txt_Mobile.Text;
                    SqlParameter param6 = new SqlParameter("@Email", SqlDbType.VarChar);
                    cmd.Parameters.Add(param6).Value = txt_Email.Text;
                    SqlParameter param7 = new SqlParameter("@JoinDate", SqlDbType.VarChar);
                    cmd.Parameters.Add(param7).Value = dateTimePickerJoinDate.Text;
                    SqlParameter param8 = new SqlParameter("@State", SqlDbType.VarChar);
                    cmd.Parameters.Add(param8).Value = txt_State.Text;
                    SqlParameter param9 = new SqlParameter("@City", SqlDbType.VarChar);
                    cmd.Parameters.Add(param9).Value = txt_City.Text;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Data Saved.");
                    }
                    con.Close();
                    txt_Fname.Text = "";
                    txt_GendercomboBox1.Text = "";
                    txt_Mobile.Text = "";
                    txt_State.Text = "";
                    txt_City.Text = "";
                    txt_Email.Text = "";
                    dateTimePickerDOB.Value = DateTime.Now;
                    dateTimePickerJoinDate.Value = DateTime.Now;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_backward_Click(object sender, EventArgs e)
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
