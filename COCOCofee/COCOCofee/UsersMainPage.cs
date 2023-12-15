using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COCOCofee
{
    public partial class UsersMainPage : Form
    {
        public UsersMainPage()
        {
            InitializeComponent();
        }

        private void btn_Order_Click(object sender, EventArgs e)
        {
            CoffeeOrders CO = new CoffeeOrders();
            CO.Show();
            this.Hide();
        }

        private void btn_Feedback_Click(object sender, EventArgs e)
        {
            FeedbackPage FP = new FeedbackPage();
            FP.Show();
            this.Hide();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Log Out !! Confirm?", "Log Out", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
                Index i = new Index();
                i.Show();
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
