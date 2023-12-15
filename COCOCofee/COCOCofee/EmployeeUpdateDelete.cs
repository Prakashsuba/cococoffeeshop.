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
    public partial class EmployeeUpdateDelete : Form
    {
        public EmployeeUpdateDelete()
        {
            InitializeComponent();
        }
        string projectConnection = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        private void GridViewdata()
        {
            SqlConnection con = new SqlConnection(projectConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("exec SP_View_Employee", con);
            cmd.Connection = con;
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            con.Close();
        }
        private void FilterByName()
        {
            try
            {
                SqlConnection con = new SqlConnection(projectConnection);
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Search_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", txt_name.Text.Trim());
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DA.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearFields()
        {
            txt_id.Text = "";
            txt_name.Text = "";
            txt_GendercomboBox1.Text = "";
            dateTimePicker_DOB.Text = "";
            txt_Mobile.Text = "";
            txt_Email.Text = "";
            dateTimePicker_JoinDate.Text = "";
            txt_City.Text = "";
            txt_State.Text = "";
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            AdminMainPage AMP = new AdminMainPage();
            AMP.Show();
            this.Hide();
        }

        private void btn_Id_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "")
            {
                MessageBox.Show("Please Enter Your Employee ID!!.");
            }

            SqlConnection con = new SqlConnection(projectConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Enter_Employee_ID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(txt_id.Text));
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txt_name.Text = dr["name"].ToString();
                txt_GendercomboBox1.Text = dr["gender"].ToString();
                dateTimePicker_DOB.Text = dr["dob"].ToString();
                txt_Mobile.Text = dr["mobile"].ToString();
                txt_Email.Text = dr["email"].ToString();
                dateTimePicker_JoinDate.Text = dr["joindate"].ToString();
                txt_State.Text = dr["State"].ToString();
                txt_City.Text = dr["city"].ToString();

            }
            else
            {
                ClearFields();
            }
            con.Close();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "" || txt_name.Text == "" || txt_GendercomboBox1.Text == "" || dateTimePicker_DOB.Text == "" || txt_Mobile.Text == "" || txt_Email.Text == "" || dateTimePicker_JoinDate.Text == "" || txt_State.Text == "" || txt_City.Text == "")
            {
                MessageBox.Show("Missing Informations");
            }
            else
            {
                try
                {
                    int memberId = Convert.ToInt32(txt_id.Text);
                    string MemName = txt_name.Text;
                    String Gender = txt_GendercomboBox1.Text;
                    string DOB = dateTimePicker_DOB.Text;
                    string Mobile = txt_Mobile.Text;
                    string JoinDate = dateTimePicker_JoinDate.Text;
                    string State = txt_State.Text;
                    string Email = txt_Email.Text;
                    string City = txt_City.Text;
                    SqlConnection con = new SqlConnection(projectConnection);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_Update_Employee", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", memberId);
                    cmd.Parameters.AddWithValue("@Name", MemName);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@DOB", DOB);
                    cmd.Parameters.AddWithValue("@Mobile", Mobile);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@JoinDate", JoinDate);
                    cmd.Parameters.AddWithValue("@State", State);
                    cmd.Parameters.AddWithValue("@City", City);
                    ClearFields();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Members Information Updated Successfully...");
                    }
                    else
                    {
                        MessageBox.Show("Failed to Update Member Informations...");
                    }

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "")
            {
                MessageBox.Show("Please Enter Member ID");
            }
            else
            {
                try
                {
                    int MemberId = int.Parse(txt_id.Text);
                    SqlConnection con = new SqlConnection(projectConnection);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_Delete_Employee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", MemberId);
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Member Successfully Deleted....");
                        txt_id.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Member Not Found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            FilterByName();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(projectConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("exec SP_View_Employee", con);
            cmd.Connection = con;
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            con.Close();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txt_id.Text = "";
            txt_name.Text = "";
            txt_GendercomboBox1.Text = "";
            dateTimePicker_DOB.Text = "";
            txt_Mobile.Text = "";
            txt_Email.Text = "";
            dateTimePicker_JoinDate.Text = "";
            txt_City.Text = "";
            txt_State.Text = "";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EmployeeUpdateDelete_Load(object sender, EventArgs e)
        {
            GridViewdata();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
