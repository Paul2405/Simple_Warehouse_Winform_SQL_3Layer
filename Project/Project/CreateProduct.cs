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
    public partial class CreateProduct : Form
    {
        string userID;
        string importFrom;
        List<Import> listImport;
        public CreateProduct()
        {
            InitializeComponent();
            txtSubpacakge.Enabled = false;
            errorProvider.SetError(txtSubpacakge, null);

        }
        public CreateProduct(string username, string ipFrom, List<Import> listIp) : this()
        {
            userID = username;
            importFrom = ipFrom;
            listImport = listIp;
        }



        private void ChCheckSub_Click(object sender, EventArgs e)
        {
            if (chCheckSub.Checked)
            {
                txtSubpacakge.Enabled = true;
            }
            else
            {
                txtSubpacakge.Enabled = false;
                txtSubpacakge.Text = "";
                errorProvider.SetError(txtSubpacakge, null);
            }
        }



        // start add
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                Product pro = new Product();
                pro.ProductID = txtProductID.Text.Trim();
                pro.ProductName = txtProductName.Text;
                pro.Description = txtDescription.Text;
                pro.Package = txtPackage.Text;
                pro.NumberPackage = 0;
                pro.Subpackage = txtSubpacakge.Text;
                pro.NumberSub = 0;
                pro.PricePackage = 0;
                pro.PriceToExportPackage = 0;
                pro.PriceToExportSub = 0;
                pro.CountSubExport = 0;
                bool check = ProDAO.insertProduct(pro);
                if (check)
                {
                    MessageBox.Show("Create product successful");
                    this.Hide();
                    frmImport ip = new frmImport(userID, importFrom, listImport);
                    ip.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Create product fail");
                    this.Hide();
                    frmImport ip = new frmImport(userID, importFrom, listImport);
                    ip.ShowDialog();
                    this.Close();
                }
            }
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmImport ip = new frmImport(userID, importFrom, listImport);
            ip.ShowDialog();
            this.Close();
        }





        private void TxtSubpacakge_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtProductID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtProductID, "Please input productID");
            }
            else if (ProDAO.checkProductID(txtProductID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtProductID, "ProductID is existed");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtProductID, null);
            }
        }

        private void TxtProductName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtProductName, "Please input product name");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtProductName, null);
            }
        }

        private void TxtPackage_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtPackage.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPackage, "Please input package name");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtPackage, null);
            }
        }

        private void TxtSubpacakge_Validating(object sender, CancelEventArgs e)
        {
            if (chCheckSub.Checked)
            {
                if (string.IsNullOrEmpty(txtSubpacakge.Text))
                {
                    e.Cancel = true;
                    errorProvider.SetError(txtSubpacakge, "Please input sub package name");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtSubpacakge, null);
                }
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtSubpacakge, null);
            }
        }
    }
}
