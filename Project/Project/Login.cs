using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManageDAO;
using ManageDTO;
namespace Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtConCat.Text = "If you have any problems, please call: 1111-1111-1111";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            bool check = UserDAO.checkLogin(username, password);
            if (check)
            {
                this.Hide();
                Fuction fc = new Fuction(username);
                fc.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login fail");
                txtUsername.Text = "";
                txtPassword.Text = "";
            }
        }
    }
}
