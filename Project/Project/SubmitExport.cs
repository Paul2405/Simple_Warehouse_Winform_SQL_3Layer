using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManageDAO;
using ManageDTO;
namespace Project
{
    public partial class SubmitExport : Form
    {
        int flag = -1;
        string userID;
        List<Export> listExport;
        public SubmitExport()
        {
            InitializeComponent();
            dgvSubmitExport.ReadOnly = true;
        }
        public SubmitExport(string username, List<Export> listEp) : this()
        {
            userID = username;
            listExport = listEp;
            loadData(listExport);
        }
        public void loadData(List<Export> listEp)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductID", typeof(string));
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("NumberPackage", typeof(string));
            table.Columns.Add("NumberSub", typeof(string));
            table.Columns.Add("PriceOfPackage", typeof(string));
            table.Columns.Add("PriceOfSubPackage", typeof(string));
            table.Columns.Add("PriceExport", typeof(string));

            if (listExport.Count != 0)
            {
                float sum = 0;
                foreach (var x in listEp)
                {
                    sum += x.PriceExport;
                    table.Rows.Add(x.ProductID, x.ProductName, x.NumberPackageExport, x.NumberSubExport, x.PricePackageExport, x.PriceSubPackageExport, x.PriceExport.ToString("N", CultureInfo.CreateSpecificCulture("es-ES")));

                }
                table.Rows.Add("Total: ", "", "", "", "", "", sum.ToString("N", CultureInfo.CreateSpecificCulture("es-ES")));
            }
            dgvSubmitExport.DataSource = table;
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmExport exp = new FrmExport(userID, listExport);
            exp.ShowDialog();
            this.Close();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fuction fc = new Fuction(userID);
            fc.ShowDialog();
            this.Close();
        }

        private void SubmitExport_Load(object sender, EventArgs e)
        {
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if ((dgvSubmitExport.RowCount - 1) == 0)
            {
                MessageBox.Show("List export is empty");
            }
            else
            {
                flag = dgvSubmitExport.CurrentCell.RowIndex;
                if (flag != -1)
                {
                    string productID = listExport.ElementAt(flag).ProductID;
                    string dateExport = listExport.ElementAt(flag).DateExport;
                    int oldNumPack = listExport.ElementAt(flag).NumberPackageExport;
                    int oldNumSub = listExport.ElementAt(flag).NumberSubExport;
                    int oldCount = listExport.ElementAt(flag).CountExport;
                    int currentPackage = ProDAO.getNumberPackageByID(productID);
                    int currentSub = ProDAO.getNumSub(productID);

                    listExport.RemoveAt(flag);
                    if (oldNumSub != 0)
                    {
                        if (oldCount + oldNumSub >= currentSub)
                        {
                            bool checkUpdatePro = ProDAO.updateProductAtCountExport(oldCount, currentPackage + 1 + oldNumPack, productID);
                            bool checkDelete = exportDAO.removeExportByDateTime(dateExport);
                            if (checkUpdatePro)
                            {
                                MessageBox.Show("Remove successful");
                                loadData(listExport);
                                flag = -1;
                            }
                            else
                            {
                                MessageBox.Show("Remove fail");
                                flag = -1;
                            }

                        }
                        else
                        {
                            bool checkUpdatePro = ProDAO.updateProductAtCountExport(oldCount, currentPackage + oldNumPack, productID);
                            bool checkDelete = exportDAO.removeExportByDateTime(dateExport);
                            if (checkUpdatePro)
                            {
                                MessageBox.Show("Remove successful");
                                loadData(listExport);
                                flag = -1;
                            }
                            else
                            {
                                MessageBox.Show("Remove fail");
                                flag = -1;

                            }
                        }
                    }
                    else
                    {
                        bool checkUpdatePro = ProDAO.updateProductAtCountExport(oldCount, currentPackage + oldNumPack, productID);
                        bool checkDelete = exportDAO.removeExportByDateTime(dateExport);
                        if (checkUpdatePro)
                        {
                            MessageBox.Show("Remove successful");
                            loadData(listExport);
                            flag = -1;
                        }
                        else
                        {
                            MessageBox.Show("Remove fail");
                            flag = -1;

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please choose product to Remove");
                }
            }
        }
    }
}
