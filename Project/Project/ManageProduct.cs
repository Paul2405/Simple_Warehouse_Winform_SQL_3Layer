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
    public partial class ManageProduct : Form
    {
        int index = -1;
        string userID;
        List<Product> listPro;
        public ManageProduct()
        {
            InitializeComponent();
            dgvView.ReadOnly = true;
        }
        public ManageProduct(string username) : this()
        {
            userID = username;
        }

        private void ManageProduct_Load(object sender, EventArgs e)
        {
            listPro = ProDAO.getListProduct();
            loadData(listPro);

        }
        public void loadData(List<Product> pro)
        {
            DataTable table = new DataTable();

            table.Columns.Add("ProductID", typeof(string));
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Package", typeof(string));
            table.Columns.Add("Subpackage", typeof(string));
            table.Columns.Add("NumPackage", typeof(int));
            table.Columns.Add("NumSub", typeof(int));
            table.Columns.Add("PricePackage", typeof(float));
            table.Columns.Add("PriceSub", typeof(float));
            table.Columns.Add("PricePackExport", typeof(float));
            table.Columns.Add("PriceSubExport", typeof(float));
            table.Columns.Add("SubRe", typeof(int));

            foreach (var x in pro)
            {
                if (x.CountSubExport == 0)
                {
                    table.Rows.Add(x.ProductID, x.ProductName, x.Description, x.Package, x.Subpackage, x.NumberPackage, x.NumberSub, x.PricePackage, x.PriceSub,
                    x.PriceToExportPackage, x.PriceToExportSub, 0);
                }
                else
                {
                    table.Rows.Add(x.ProductID, x.ProductName, x.Description, x.Package, x.Subpackage, x.NumberPackage, x.NumberSub, x.PricePackage, x.PriceSub,
                    x.PriceToExportPackage, x.PriceToExportSub, (x.NumberSub - x.CountSubExport));
                }

            }

            dgvView.DataSource = table;
        }

        private void DgvView_Click(object sender, EventArgs e)
        {
            if (dgvView.Rows.Count - 1 == 0)
            {
                MessageBox.Show("Data table is empty");
            }
            else
            {


                index = dgvView.CurrentCell.RowIndex;
                if (index < listPro.Count)
                {
                    lbInfor.Text = "Information of product have Id: " + listPro.ElementAt(index).ProductID;
                    txtPricePack.Text = listPro.ElementAt(index).PriceToExportPackage.ToString();
                    if (string.IsNullOrEmpty(listPro.ElementAt(index).Subpackage))
                    {
                        txtPriceSub.Text = listPro.ElementAt(index).PriceToExportSub.ToString();
                        txtPriceSub.Enabled = false;
                    }
                    else
                    {
                        txtPriceSub.Text = listPro.ElementAt(index).PriceToExportSub.ToString();
                        txtPriceSub.Enabled = true;
                    }
                }
                else
                {
                    index = -1;
                    txtPricePack.Text = "";
                    txtPriceSub.Text = "";
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fuction fc = new Fuction(userID);
            fc.ShowDialog();
            this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                MessageBox.Show("please choose a product by click to it to update");
            }
            else
            {

                if (string.IsNullOrEmpty(txtPricePack.Text))
                {
                    MessageBox.Show("please input price export a package to udpate");
                }
                else if (!ProDAO.checkFloat(txtPricePack.Text) || float.Parse(txtPricePack.Text) <= 0)
                {
                    MessageBox.Show("Price must be a possible number and greater than 0");
                }
                else if (string.IsNullOrEmpty(txtPriceSub.Text))
                {
                    MessageBox.Show("please input price export a package to udpate");
                }
                else if (!ProDAO.checkFloat(txtPriceSub.Text) || float.Parse(txtPriceSub.Text) < 0)
                {
                    MessageBox.Show("Price must be a possible number and greater than 0");
                }
                else
                {
                    bool check = ProDAO.updatePriceExportByID(listPro.ElementAt(index).ProductID, float.Parse(txtPricePack.Text), float.Parse(txtPriceSub.Text));
                    if (check)
                    {
                        MessageBox.Show("Update successfull");
                        loadData(listPro);
                        index = -1;
                        txtPricePack.Text = "";
                        txtPriceSub.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Update fail");
                        index = -1;
                        txtPricePack.Text = "";
                        txtPriceSub.Text = "";

                    }
                }
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                MessageBox.Show("please choose a product by click to it to update");
            }
            else
            {
                bool delete = ProDAO.SetStatusByID(listPro.ElementAt(index).ProductID, false);
                if (delete)
                {
                    listPro.RemoveAt(index);
                    MessageBox.Show("Delete successfull");
                    loadData(listPro);
                    index = -1;
                    txtPricePack.Text = "";
                    txtPriceSub.Text = "";
                }
                else
                {
                    MessageBox.Show("Delete fail");
                    index = -1;
                    txtPricePack.Text = "";
                    txtPriceSub.Text = "";

                }
            }
        }
    }
}
