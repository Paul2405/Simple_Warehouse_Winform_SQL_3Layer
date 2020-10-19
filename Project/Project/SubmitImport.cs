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
    public partial class SubmitImport : Form
    {
        int flag = -1;
        string userID, importFrom;
        List<Import> listImport;
        public SubmitImport()
        {
            InitializeComponent();
            dgvSubmit.ReadOnly = true;
        }
        public SubmitImport(string username, string ipFrom, List<Import> listIp) : this()
        {
            userID = username;
            importFrom = ipFrom;
            listImport = listIp;
            loadData(listImport);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmImport import = new frmImport(userID, importFrom, listImport);
            import.ShowDialog();
            this.Close();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fuction func = new Fuction(userID);
            func.ShowDialog();
            this.Close();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if ((dgvSubmit.RowCount - 1) == 0)
            {
                MessageBox.Show("List import is empty");
            }
            else
            {
                flag = dgvSubmit.CurrentCell.RowIndex;
                if (flag != -1)
                {
                    string id = listImport.ElementAt(flag).ProductID;
                    float lastPrice = listImport.ElementAt(flag).lastPrice;
                    string date = listImport.ElementAt(flag).DateImport;
                    int currentNumberPackage = ProDAO.getNumberPackageByID(id);
                    int currentNumSub = ProDAO.getNumSub(id);
                    int numberImport = listImport.ElementAt(flag).NumberPackageImport;
                    int numSubImport = listImport.ElementAt(flag).numSub;
                    listImport.RemoveAt(flag);
                    bool check = importDAO.removeImportByDateTime(date);
                    bool checkReset = ProDAO.updateProduct(currentNumberPackage-numberImport, currentNumSub - numSubImport, lastPrice, id);
                    if (check && checkReset)
                    {
                        MessageBox.Show("Remove successful");
                        loadData(listImport);
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
                    MessageBox.Show("Please choose product to Remove");
                }
            }
        }

        public void loadData(List<Import> listIp)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductID", typeof(string));
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("NumberPackage", typeof(int));
            table.Columns.Add("PriceImport", typeof(float));
            table.Columns.Add("TotalPrice", typeof(string));

            if (listImport.Count != 0)
            {
                float sum = 0;
                foreach (var x in listImport)
                {
                    Single value = x.PriceImport;
                    table.Rows.Add(x.ProductID, x.ProductName, x.NumberPackageImport, x.PriceOneImport, value.ToString("N", CultureInfo.CreateSpecificCulture("es-ES")));
                    sum += x.PriceImport;
                }
                table.Rows.Add("Total: ", "", null, null, sum.ToString("N", CultureInfo.CreateSpecificCulture("es-ES")));
            }
            dgvSubmit.DataSource = table;

        }
    }
}
