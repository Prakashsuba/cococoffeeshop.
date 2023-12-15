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
    public partial class EmployeeSalary : Form
    {
        public EmployeeSalary()
        {
            InitializeComponent();
        }
        string projectConnection = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        private void FilterByName()
        {
            try
            {
                SqlConnection con = new SqlConnection(projectConnection);
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Employee_Payments_Search_Views", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PMember", txt_MemberList.Text.Trim());
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DA.Fill(dt);
                Pay_dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Viewdata()
        {
            SqlConnection con = new SqlConnection(projectConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("exec SP_Employee_Payments_Views ", con);
            cmd.Connection = con;
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            Pay_dataGridView1.DataSource = DS.Tables[0];
            con.Close();
        }
        private void FillName() 
        {
            SqlConnection con = new SqlConnection(projectConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Employee_Payments_Names_Views", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Load(dr);
            txt_Name.ValueMember = "Name";
            txt_Name.DataSource = dt;
            con.Close();
        }
        private void btn_pay_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text == "" || txt_Amount.Text == "")
            {
                MessageBox.Show("Missing Informations");
            }
            else
            {
                SqlConnection con = new SqlConnection(projectConnection);
                con.Open();
                SqlCommand cmd1 = new SqlCommand("SP_Employee_Payments_Details_Views", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@PMonth", SqlDbType.VarChar);
                cmd1.Parameters.Add(param1).Value = Period_dateTimePicker1.Value.Month.ToString() + Period_dateTimePicker1.Value.Year.ToString();
                SqlParameter param2 = new SqlParameter("@PMember", SqlDbType.VarChar);
                cmd1.Parameters.Add(param2).Value = txt_Name.SelectedValue.ToString();
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("This Member Already Paid For This Month...");
                }
                else
                {
                    try
                    {
                        SqlCommand cmd2 = new SqlCommand("SP_Employee_Payments_Details", con);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        SqlParameter param3 = new SqlParameter("@PMonth", SqlDbType.VarChar);
                        cmd2.Parameters.Add(param3).Value = Period_dateTimePicker1.Value.Month.ToString() + Period_dateTimePicker1.Value.Year.ToString();
                        SqlParameter param4 = new SqlParameter("@PMember", SqlDbType.VarChar);
                        cmd2.Parameters.Add(param4).Value = txt_Name.SelectedValue.ToString();
                        SqlParameter param5 = new SqlParameter("@PAmount", SqlDbType.VarChar);
                        cmd2.Parameters.Add(param5).Value = txt_Amount.Text;
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Amount Paid Successfully...");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                con.Close();
                Viewdata();
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txt_Amount.Text = "";
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            FilterByName();
        }

        private void btb_Refresh_Click(object sender, EventArgs e)
        {
            Viewdata();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            AdminMainPage amp = new AdminMainPage();
            amp.Show();
            this.Hide();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Pay_dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EmployeeSalary_Load(object sender, EventArgs e)
        {
            FillName();
            Viewdata();
        }
    }
}
