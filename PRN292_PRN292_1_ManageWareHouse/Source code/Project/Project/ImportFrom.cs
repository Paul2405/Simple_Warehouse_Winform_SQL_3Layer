using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManageDTO;
namespace Project
{
    public partial class ImportFrom : Form
    {
        string userID;
        public ImportFrom()
        {
            InitializeComponent();
        }
        public ImportFrom(string username) : this()
        {
            userID = username;

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                string ip = txtImportFrom.Text;
                this.Hide();
                frmImport dt = new frmImport(userID, ip);
                dt.ShowDialog();
                this.Close();
            }
            
        }

        private void TxtImportFrom_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtImportFrom.Text))
            {
                e.Cancel = true;
                txtImportFrom.Focus();
                errorProvider.SetError(txtImportFrom, "Please input where you import from");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtImportFrom, null);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fuction fc = new Fuction(userID);
            fc.ShowDialog();
            this.Close();
        }
    }
}
