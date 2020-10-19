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
    public partial class frmImport : Form
    {
        float lastPrice = 0;
        List<Product> listProduct;
        List<Import> listImport = new List<Import>();
        string userID, importFrom;
        public frmImport()
        {
            InitializeComponent();
            dgvListProduct.ReadOnly = true;
            txtProductID.Enabled = false;
            txtProductName.Enabled = false;
            txtDescription.Enabled = false;
            txtPackage.Enabled = false;
            txtNumberPacakge.Enabled = false;
            txtSubPackage.Enabled = false;
            txtNumberSub.Enabled = false;
            txtPrice.Enabled = false;
        }
        public frmImport(string username, string ipFrom) : this()
        {
            userID = username;
            importFrom = ipFrom;
            lbInportFrom.Text = "Import from:  " + importFrom;
        }
        public frmImport(string username, string ipFrom, List<Import> listIp) : this()
        {
            userID = username;
            importFrom = ipFrom;
            listImport = listIp;
            lbInportFrom.Text = "Import from:  " + importFrom;
        }
        // load to dgv
        public void loadData(List<Product> lp)
        {
            DataTable dtable = new DataTable();
            dtable.Columns.Add("ProductID", typeof(string));
            dtable.Columns.Add("ProductName", typeof(string));
            for (int i = 0; i < lp.Count; i++)
            {
                dtable.Rows.Add(lp.ElementAt(i).ProductID, lp.ElementAt(i).ProductName);
            }
            dgvListProduct.DataSource = dtable;
        }


        private void DgvListProduct_Click(object sender, EventArgs e)
        {
            if ((dgvListProduct.Rows.Count - 1) == 0)
            {
                MessageBox.Show("List product is empty");
            }
            else
            {
                int index = dgvListProduct.CurrentCell.RowIndex;
                if (index < listProduct.Count)
                {
                    txtNumberPacakge.Enabled = true;
                    txtPrice.Enabled = true;
                    txtProductID.Text = listProduct[index].ProductID;
                    txtProductName.Text = listProduct[index].ProductName;
                    txtDescription.Text = listProduct[index].Description;
                    txtPackage.Text = listProduct[index].Package;
                    txtNumberPacakge.Text = "0";
                    string subpackage = listProduct[index].Subpackage.ToString();
                    if (string.IsNullOrEmpty(subpackage))
                    {
                        txtSubPackage.Text = listProduct[index].Subpackage.ToString();
                        txtSubPackage.Enabled = false;
                        txtNumberSub.Text = "0";
                        txtNumberSub.Enabled = false;
                    }
                    else
                    {
                        txtSubPackage.Text = listProduct[index].Subpackage.ToString();
                        txtSubPackage.Enabled = false;
                        txtNumberSub.Text = listProduct[index].NumberSub.ToString();
                        txtNumberSub.Enabled = false;
                    }
                    txtPrice.Text = listProduct[index].PricePackage.ToString();
                    lastPrice = listProduct[index].PricePackage;
                    txtProductID.Enabled = false;
                    txtProductName.Enabled = false;
                    txtPackage.Enabled = false;
                    txtSubPackage.Enabled = false;
                    txtDescription.Enabled = false;

                }
                else
                {
                    txtProductID.Text = "";
                    txtProductName.Text = "";
                    txtDescription.Text = "";
                    txtPackage.Text = "";
                    txtNumberPacakge.Text = "";
                    txtSubPackage.Text = "";
                    txtNumberSub.Text = "";
                    txtPrice.Text = "";
                }
            }

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string name = txtSearch.Text;
            listProduct = ProDAO.searchLikeName(name);
            loadData(listProduct);
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtPackage.Text = "";
            txtNumberPacakge.Text = "";
            txtSubPackage.Text = "";
            txtNumberSub.Text = "";
            txtPrice.Text = "";
        }

        private void CbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbAction.SelectedIndex;
            if (index == 0)
            {
                this.Hide();
                Fuction fc = new Fuction(userID);
                fc.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                Login lg = new Login();
                lg.ShowDialog();
                this.Close();
            }
        }



        private void BtnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text))
            {
                MessageBox.Show("Please choose a product to import!");
            }
            else if (ValidateChildren(ValidationConstraints.Enabled))
            {
                string id = txtProductID.Text;
                string dateImport = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                int numberPackage = int.Parse(txtNumberPacakge.Text);
                int numSub = int.Parse(txtNumberSub.Text);
                float price = float.Parse(txtPrice.Text);
                int numpackeLast = ProDAO.getNumberPackageByID(id);
                int numSubLast = ProDAO.getNumSub(id);
                //create iumportDTO
                Import ip = new Import();
                ip.ImportID = userID;
                ip.ProductID = id;
                ip.DateImport = dateImport;
                ip.ImportFrom = importFrom;
                ip.NumberPackageImport = numberPackage;
                ip.PriceImport = price * numberPackage;
                ip.PriceOneImport = price;
                ip.ProductName = txtProductName.Text;
                ip.lastPrice = lastPrice;
                ip.numSub = int.Parse(txtNumberSub.Text);

                bool checkUpdateProduct = ProDAO.updateProduct(numberPackage + numpackeLast, numSub + numSubLast, price, id);
                bool checkInsertIntoImport = importDAO.insertImport(ip);
                if (checkUpdateProduct && checkInsertIntoImport)
                {
                    MessageBox.Show("Import successfull");
                    listProduct = ProDAO.getListProduct();
                    listImport.Add(ip);
                    txtProductID.Text = "";
                    txtProductName.Text = "";
                    txtDescription.Text = "";
                    txtPackage.Text = "";
                    txtNumberPacakge.Text = "";
                    txtSubPackage.Text = "";
                    txtNumberSub.Text = "";
                    txtPrice.Text = "";
                }
                else
                {
                    MessageBox.Show("Import fail");

                }

            }
        }

        private void TxtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPrice, "Please input price of one package");
            }
            else if (!ProDAO.checkFloat(txtPrice.Text) || int.Parse(txtPrice.Text) <= 0)
            {
                e.Cancel = true;
                errorProvider.SetError(txtPrice, "Price must be number and greater than 0");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtPrice, null);
            }
        }

        private void TxtNumberPacakge_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumberPacakge.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtNumberPacakge, "Please input number package");
            }
            else if (!ProDAO.checkInt(txtNumberPacakge.Text) || int.Parse(txtNumberPacakge.Text) <= 0)
            {
                e.Cancel = true;
                errorProvider.SetError(txtNumberPacakge, "Number package must be number and greater than 0");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtNumberPacakge, null);
            }
        }

        private void TxtNumberSub_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSubPackage.Text))
            {
                if (string.IsNullOrEmpty(txtNumberSub.Text))
                {
                    e.Cancel = true;
                    errorProvider.SetError(txtNumberSub, "Please input number of sub package");
                }
                else if (!ProDAO.checkInt(txtNumberSub.Text) || int.Parse(txtNumberSub.Text) <= 0)
                {
                    e.Cancel = true;
                    errorProvider.SetError(txtNumberSub, "Number sub package must be number and greater than 0");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtNumberSub, null);
                }
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtNumberSub, null);
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateProduct crP = new CreateProduct(userID, importFrom, listImport);
            crP.ShowDialog();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SubmitImport submit = new SubmitImport(userID, importFrom, listImport);
            submit.ShowDialog();
            this.Close();
        }

        private void Import_Load(object sender, EventArgs e)
        {
            listProduct = ProDAO.getListProduct();
            loadData(listProduct);
        }
    }
}
