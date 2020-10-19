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
    public partial class FrmExport : Form
    {
        string userID;
        int index = -1;
        List<Product> listProduct;
        List<Export> listExport = new List<Export>();
        public FrmExport()
        {
            InitializeComponent();
            dgvExport.ReadOnly = true;
            txtProductID.Enabled = false;
            txtProductName.Enabled = false;
            txtDesCription.Enabled = false;
            txtNumberPackage.Enabled = false;
            txtNumberSub.Enabled = false;
        }
        public FrmExport(string username) : this()
        {
            userID = username;
        }
        public FrmExport(string username, List<Export> listEp) : this()
        {
            userID = username;
            listExport = listEp;
        }
        //validate
        public bool validate()
        {
            bool valid = true;
            if (string.IsNullOrEmpty(txtNumberPackage.Text))
            {
                errorProvider.SetError(txtNumberPackage, "Please input number of one package");
                valid = false;
            }
            else if (!ProDAO.checkInt(txtNumberPackage.Text) || int.Parse(txtNumberPackage.Text) < 0)
            {
                errorProvider.SetError(txtNumberPackage, "Number package must be possible number");
                valid = false;
            }
            else if (!string.IsNullOrEmpty(lbSub.Text))
            {
                errorProvider.SetError(txtNumberPackage, null);
                if (string.IsNullOrEmpty(txtNumberSub.Text))
                {
                    valid = false;
                    errorProvider.SetError(txtNumberSub, "Please input number of sub package");
                }
                else if (!ProDAO.checkInt(txtNumberSub.Text) || int.Parse(txtNumberSub.Text) < 0)
                {
                    valid = false;
                    errorProvider.SetError(txtNumberSub, "Number sub package must be number and greater than 0");
                }
                else
                {
                    valid = true;
                    errorProvider.SetError(txtNumberSub, null);
                }
            }
            else
            {
                valid = true;
                errorProvider.SetError(txtNumberPackage, null);
                errorProvider.SetError(txtNumberSub, null);
            }
            return valid;
        }


        //load
        public void loadData(List<Product> lp)
        {
            DataTable dtable = new DataTable();
            dtable.Columns.Add("ProductID", typeof(string));
            dtable.Columns.Add("ProductName", typeof(string));
            for (int i = 0; i < lp.Count; i++)
            {
                dtable.Rows.Add(lp.ElementAt(i).ProductID, lp.ElementAt(i).ProductName);
            }
            dgvExport.DataSource = dtable;
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

        private void FrmExport_Load(object sender, EventArgs e)
        {
            listProduct = ProDAO.getListProduct();
            loadData(listProduct);
        }

        private void DgvExport_Click(object sender, EventArgs e)
        {
            errorProvider.SetError(txtNumberPackage, null);
            errorProvider.SetError(txtNumberSub, null);
            txtProductID.Enabled = false;
            txtProductName.Enabled = false;
            txtDesCription.Enabled = false;
            txtNumberPackage.Enabled = false;
            txtNumberSub.Enabled = false;
            if ((dgvExport.Rows.Count - 1) == 0)
            {
                MessageBox.Show("List Product is empty");
            }
            else
            {
                index = dgvExport.CurrentCell.RowIndex;
                if (index < listProduct.Count)
                {
                    txtProductID.Text = listProduct.ElementAt(index).ProductID;
                    txtProductName.Text = listProduct.ElementAt(index).ProductName;
                    txtDesCription.Text = listProduct.ElementAt(index).Description;
                    lbPackage.Text = listProduct.ElementAt(index).Package;
                    txtNumberPackage.Text = "0";
                    txtNumberPackage.Enabled = true;
                    if (string.IsNullOrEmpty(listProduct.ElementAt(index).Subpackage))
                    {
                        lbSub.Text = "";
                        txtNumberSub.Text = "";
                    }
                    else
                    {
                        txtNumberSub.Enabled = true;
                        lbSub.Text = listProduct.ElementAt(index).Subpackage;
                        txtNumberSub.Text = "0";
                    }
                }
                else
                {
                    index = -1;
                    txtProductID.Text = "";
                    txtProductName.Text = "";
                    txtDesCription.Text = "";
                    txtNumberPackage.Text = "";
                    txtNumberSub.Text = "";
                    lbPackage.Text = "";
                    lbSub.Text = "";
                }
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                MessageBox.Show("Please choose a product to export");
            }
            else
            {
                if (validate())
                {
                    string exportID = userID;
                    string productID = txtProductID.Text.Trim();
                    string productName = txtProductName.Text;
                    string dateExport = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    int numPack = int.Parse(txtNumberPackage.Text);
                    int numSub = 0;
                    if (!string.IsNullOrEmpty(txtNumberSub.Text))
                    {
                        numSub = int.Parse(txtNumberSub.Text);
                    }
                    float pricePackageExport = listProduct.ElementAt(index).PriceToExportPackage;
                    float priceSubExport = listProduct.ElementAt(index).PriceToExportSub;
                    int currentNumberPackage = ProDAO.getNumberPackageByID(productID);
                    int currentNumSub = ProDAO.getNumSub(productID);
                    int currentCount = ProDAO.getCountExport(productID);
                    if(numPack == 0 && numSub == 0)
                    {
                        MessageBox.Show("please input a number of package or dub package to export");
                        return;
                    }
                    if (pricePackageExport != 0)
                    {
                        if (numSub == 0)
                        {
                            if (numPack <= currentNumberPackage && numSub <= currentNumSub)
                            {
                                Export ep = new Export();
                                ep.ExportID = userID;
                                ep.ProductID = productID;
                                ep.ProductName = productName;
                                ep.DateExport = dateExport;
                                ep.NumberPackageExport = numPack;
                                ep.NumberSubExport = numSub;
                                ep.PricePackageExport = pricePackageExport;
                                ep.PriceSubPackageExport = priceSubExport;
                                ep.PriceExport = numPack * pricePackageExport;
                                ep.CountExport = currentCount;

                                bool checkUpdateProdutc = ProDAO.updateProductAtCountExport(0, currentNumberPackage - numPack, productID);
                                bool checkInsertExport = exportDAO.insertExport(ep);
                                if (checkUpdateProdutc && checkInsertExport)
                                {
                                    MessageBox.Show("Add to export list successful");
                                    listExport.Add(ep);
                                    index = -1;
                                    txtProductID.Text = "";
                                    txtProductName.Text = "";
                                    txtDesCription.Text = "";
                                    txtNumberPackage.Text = "";
                                    txtNumberSub.Text = "";
                                    lbPackage.Text = "";
                                    lbSub.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("Add to export list fail");
                                    index = -1;
                                    txtProductID.Text = "";
                                    txtProductName.Text = "";
                                    txtDesCription.Text = "";
                                    txtNumberPackage.Text = "";
                                    txtNumberSub.Text = "";
                                    lbPackage.Text = "";
                                    lbSub.Text = "";

                                }
                            }
                            else
                            {
                                MessageBox.Show("Number export greater than number produts have been, please inmput again");
                            }
                        }
                        else
                        {
                            if (priceSubExport != 0)
                            {
                                if (numSub < currentNumSub && numPack <= currentNumberPackage)
                                {
                                    Export ep = new Export();
                                    ep.ExportID = userID;
                                    ep.ProductID = productID;
                                    ep.ProductName = productName;
                                    ep.DateExport = dateExport;
                                    ep.NumberPackageExport = numPack;
                                    ep.NumberSubExport = numSub;
                                    ep.PricePackageExport = pricePackageExport;
                                    ep.PriceSubPackageExport = priceSubExport;
                                    ep.PriceExport = numPack * pricePackageExport + numSub * priceSubExport;
                                    ep.CountExport = currentCount;

                                    if (numSub + currentCount > currentNumSub)
                                    {
                                        bool checkUpdateProdutc = ProDAO.updateProductAtCountExport((numSub + currentCount - currentNumSub), currentNumberPackage - 1 - numPack, productID);
                                        bool checkInsertExport = exportDAO.insertExport(ep);
                                        if (checkUpdateProdutc && checkInsertExport)
                                        {
                                            MessageBox.Show("Add to export list successful");
                                            listExport.Add(ep);
                                            index = -1;
                                            txtProductID.Text = "";
                                            txtProductName.Text = "";
                                            txtDesCription.Text = "";
                                            txtNumberPackage.Text = "";
                                            txtNumberSub.Text = "";
                                            lbPackage.Text = "";
                                            lbSub.Text = "";
                                        }
                                        else
                                        {
                                            MessageBox.Show("Add to export list fail");
                                            index = -1;
                                            txtProductID.Text = "";
                                            txtProductName.Text = "";
                                            txtDesCription.Text = "";
                                            txtNumberPackage.Text = "";
                                            txtNumberSub.Text = "";
                                            lbPackage.Text = "";
                                            lbSub.Text = "";

                                        }
                                    }
                                    else if (numSub + currentCount == currentNumSub)
                                    {
                                        bool checkUpdateProdutc = ProDAO.updateProductAtCountExport(0, currentNumberPackage - 1 - numPack, productID);
                                        bool checkInsertExport = exportDAO.insertExport(ep);
                                        if (checkUpdateProdutc && checkInsertExport)
                                        {
                                            MessageBox.Show("Add to export list successful");
                                            listExport.Add(ep);
                                            index = -1;
                                            txtProductID.Text = "";
                                            txtProductName.Text = "";
                                            txtDesCription.Text = "";
                                            txtNumberPackage.Text = "";
                                            txtNumberSub.Text = "";
                                            lbPackage.Text = "";
                                            lbSub.Text = "";
                                        }
                                        else
                                        {
                                            MessageBox.Show("Add to export list fail");
                                            index = -1;
                                            txtProductID.Text = "";
                                            txtProductName.Text = "";
                                            txtDesCription.Text = "";
                                            txtNumberPackage.Text = "";
                                            txtNumberSub.Text = "";
                                            lbPackage.Text = "";
                                            lbSub.Text = "";

                                        }
                                    }
                                    else
                                    {
                                        bool checkUpdateProdutc = ProDAO.updateProductAtCountExport((numSub + currentCount), currentNumberPackage - numPack, productID);
                                        bool checkInsertExport = exportDAO.insertExport(ep);
                                        if (checkUpdateProdutc && checkInsertExport)
                                        {
                                            MessageBox.Show("Add to export list successful");
                                            listExport.Add(ep);
                                            index = -1;
                                            txtProductID.Text = "";
                                            txtProductName.Text = "";
                                            txtDesCription.Text = "";
                                            txtNumberPackage.Text = "";
                                            txtNumberSub.Text = "";
                                            lbPackage.Text = "";
                                            lbSub.Text = "";
                                        }
                                        else
                                        {
                                            MessageBox.Show("Add to export list fail");
                                            index = -1;
                                            txtProductID.Text = "";
                                            txtProductName.Text = "";
                                            txtDesCription.Text = "";
                                            txtNumberPackage.Text = "";
                                            txtNumberSub.Text = "";
                                            lbPackage.Text = "";
                                            lbSub.Text = "";

                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Please input number sub package less than number sub of one package or yout can export a package");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Price to export had not been input, please input at manage product function");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Price to export had not been input, please input at manage product function");
                    }
                }

            }

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string name = txtSearch.Text;
            listProduct = ProDAO.searchLikeName(name);
            loadData(listProduct);
            index = -1;
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtDesCription.Text = "";
            txtNumberPackage.Text = "";
            txtNumberSub.Text = "";
            lbPackage.Text = "";
            lbSub.Text = "";
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            this.Hide();
            SubmitExport exp = new SubmitExport(userID, listExport);
            exp.ShowDialog();
            this.Close();
        }
    }
}
