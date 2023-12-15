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
    public partial class OrderView : Form
    {
        public OrderView()
        {
            InitializeComponent();
        }
        string projectConnection = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        private void Viewdata()
        {
            SqlConnection con = new SqlConnection(projectConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("exec SP_Customer_Orders_Views", con);
            cmd.Connection = con;
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView_Feedback_View.DataSource = DS.Tables[0];
            con.Close();
        }
        private void FilterByName()
        {
            try
            {
                SqlConnection con = new SqlConnection(projectConnection);
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Customer_Search_Orders", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", txt_Search.Text.Trim());
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DA.Fill(dt);
                dataGridView_Feedback_View.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            FilterByName();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Viewdata();
        }

        private void linkLabel_Payments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CoffeeOrderPay COP = new CoffeeOrderPay();
            COP.Show();
            this.Hide();
        }

        private void OrderView_Load(object sender, EventArgs e)
        {
            Viewdata();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            AdminMainPage AMP = new AdminMainPage();
            AMP.Show();
            this.Hide();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
