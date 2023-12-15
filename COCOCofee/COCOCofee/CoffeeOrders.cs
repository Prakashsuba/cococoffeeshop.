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
    public partial class CoffeeOrders : Form
    {
        public CoffeeOrders()
        {
            InitializeComponent();
        }
        string projectConnection = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        private void btn_AddItems_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(projectConnection);
                SqlCommand cmd = new SqlCommand("SP_Inser_Coffeeorder", con);
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@Items", SqlDbType.VarChar);
                cmd.Parameters.Add(param1).Value = txt_comboBoxItems.SelectedItem.ToString();
                SqlParameter param3 = new SqlParameter("@Prices", SqlDbType.VarChar);
                cmd.Parameters.Add(param3).Value = txt_Prices.Text;
                SqlParameter param5 = new SqlParameter("@Datetimepicker", SqlDbType.VarChar);
                cmd.Parameters.Add(param5).Value = dateTimePicker_Date.Text;
                SqlParameter param6 = new SqlParameter("@Quanity", SqlDbType.VarChar);
                cmd.Parameters.Add(param6).Value = txt_Quantity.Text;
                SqlParameter param7 = new SqlParameter("@Total", SqlDbType.VarChar);
                cmd.Parameters.Add(param7).Value = txt_Total.Text;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Your Order saved Successfully...");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txt_comboBoxItems.Items.Clear();
            txt_Prices.Text = "";
            txt_Quantity.Text = "";
        }

        private void radio_CofeeChanged_CheckedChanged(object sender, EventArgs e)
        {
            radio_CofeeChanged.ForeColor = System.Drawing.Color.BlueViolet;
            radioButton_Dessert.ForeColor = System.Drawing.Color.RosyBrown;
            txt_comboBoxItems.Items.Clear();
            txt_comboBoxItems.Items.Add("CAPPUCCINO");
            txt_comboBoxItems.Items.Add("BLACK COFFEE");
            txt_comboBoxItems.Items.Add("BLACK COFFEE WITH MILK");
            txt_comboBoxItems.Items.Add("AMERICANO");
            txt_comboBoxItems.Items.Add("ICED COFFEE");
            txt_comboBoxItems.Items.Add("BLACK EYE");
            txt_comboBoxItems.Items.Add("RED EYE");
        }

        private void radioButton_Dessert_CheckedChanged(object sender, EventArgs e)
        {
            radio_CofeeChanged.ForeColor = System.Drawing.Color.RosyBrown;
            radioButton_Dessert.ForeColor = System.Drawing.Color.BlueViolet;
            txt_comboBoxItems.Items.Clear();
            txt_comboBoxItems.Items.Add("Gulab Jamun-1kg");
            txt_comboBoxItems.Items.Add("Rasagulla-1kg");
            txt_comboBoxItems.Items.Add("RasaMalai-1kg");
            txt_comboBoxItems.Items.Add("Rice Pudding-1kg");
            txt_comboBoxItems.Items.Add("Normal Pudding-1kg");
            txt_comboBoxItems.Items.Add("Basundi-1kg");
            txt_comboBoxItems.Items.Add("Banana Pudding-1kg");
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_BACK_Click(object sender, EventArgs e)
        {
            UsersMainPage UMP = new UsersMainPage();
            UMP.Show();
            this.Hide();
        }

        private void txt_comboBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_comboBoxItems.SelectedItem.ToString() == "CAPPUCCINO")
            {
                txt_Prices.Text = "100";
            }
            else if (txt_comboBoxItems.SelectedItem.ToString() == "BLACK COFFEE")
            {
                txt_Prices.Text = "30";
            }
            else if (txt_comboBoxItems.SelectedItem.ToString() == "BLACK COFFEE WITH MILK")
            {
                txt_Prices.Text = "50";
            }
            else if (txt_comboBoxItems.SelectedItem.ToString() == "AMERICANO")
            {
                txt_Prices.Text = "200";
            }
            else if (txt_comboBoxItems.SelectedItem.ToString() == "ICED COFFEE")
            {
                txt_Prices.Text = "150";
            }
            else if (txt_comboBoxItems.SelectedItem.ToString() == "BLACK EYE")
            {
                txt_Prices.Text = "200";
            }
            else if (txt_comboBoxItems.SelectedItem.ToString() == "RED EYE")
            {
                txt_Prices.Text = "200";
            }
            else if (txt_comboBoxItems.SelectedItem.ToString() == "Gulab Jamun-1kg")
            {
                txt_Prices.Text = "300";
            }
            else if (txt_comboBoxItems.SelectedItem.ToString() == "Rasagulla-1kg")
            {
                txt_Prices.Text = "350";
            }
            else if (txt_comboBoxItems.SelectedItem.ToString() == "RasaMalai-1kg")
            {
                txt_Prices.Text = "300";
            }
            else if (txt_comboBoxItems.SelectedItem.ToString() == "Rice Pudding-1kg")
            {
                txt_Prices.Text = "280";
            }
            else if (txt_comboBoxItems.SelectedItem.ToString() == "Normal Pudding-1kg")
            {
                txt_Prices.Text = "250";
            }
            else if (txt_comboBoxItems.SelectedItem.ToString() == "Basundi-1kg")
            {
                txt_Prices.Text = "400";
            }
            else if (txt_comboBoxItems.SelectedItem.ToString() == "Banana Pudding-1kg")
            {
                txt_Prices.Text = "380";
            }
            else
            {
                txt_Prices.Text = "0";
            }
            txt_Quantity.Text = "";
        }

        private void txt_Quantity_TextChanged(object sender, EventArgs e)
        {
            if (txt_Quantity.Text.Length > 0)
            {
                txt_Total.Text = (Convert.ToInt64(txt_Prices.Text) * Convert.ToInt64(txt_Quantity.Text)).ToString();
            }
        }
    }
}
