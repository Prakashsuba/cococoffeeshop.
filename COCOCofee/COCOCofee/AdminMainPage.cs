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
    public partial class AdminMainPage : Form
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }

        private void customerOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderView OV = new OrderView();
            OV.Show();
            this.Hide();
        }

        private void employeeUpdateDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeUpdateDelete EUD = new EmployeeUpdateDelete();
            EUD.Show();
            this.Hide();
        }

        private void employeeSalaryDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeSalary ES = new EmployeeSalary();
            ES.Show();
            this.Hide();
        }

        private void customerFeedbackReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeedbackView FBV = new FeedbackView();
            FBV.Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Log Out !! Confirm?", "Log Out", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
                AdminLogin AL = new AdminLogin();
                AL.Show();
            }
        }

        private void exitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will close Your application.confirm?", "CLOSE", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Application.Exit();

            }
            else
            {
                MessageBox.Show("Welcome Back", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
