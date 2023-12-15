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
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void btn_AdminLogin_Click(object sender, EventArgs e)
        {
            AdminLogin AL = new AdminLogin();
            AL.Show();
            this.Hide();
        }

        private void btn_UserLogin_Click(object sender, EventArgs e)
        {
            UsersLogin Ul = new UsersLogin();
            Ul.Show();
            this.Hide();
        }

        private void btn_Employee_Click(object sender, EventArgs e)
        {
            EmployeeDetails ED = new EmployeeDetails();
            ED.Show();
            this.Hide();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
