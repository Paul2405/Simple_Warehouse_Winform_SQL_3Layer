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
    public partial class HistoryImport : Form
    {
        DataTable table;
        string userID;
        public HistoryImport()
        {
            InitializeComponent();
            dgvHistory.Enabled = false;
        }
        public HistoryImport(string username) : this()
        {
            userID = username;
        }
        public void loadData(DataTable t)
        {
            DataTable view = new DataTable();

            view.Columns.Add("ProductID", typeof(string));
            view.Columns.Add("ProductName", typeof(string));
            view.Columns.Add("DateImport", typeof(string));
            view.Columns.Add("ImportFrom", typeof(string));
            view.Columns.Add("NumberPackImport", typeof(string));
            view.Columns.Add("Price", typeof(string));
            float sum = 0;
            for (int i = 0; i < t.Rows.Count; i++)
            {
                sum += float.Parse(t.Rows[i]["PriceImport"].ToString());
                view.Rows.Add(t.Rows[i]["ProductID"].ToString(), ProDAO.getNameByID(t.Rows[i]["ProductID"].ToString().Trim()), t.Rows[i]["DateImport"].ToString(),
                     t.Rows[i]["ImportFrom"].ToString(), t.Rows[i]["NumberPackageImport"].ToString(), float.Parse(t.Rows[i]["PriceImport"].ToString()).ToString("N", CultureInfo.CreateSpecificCulture("es-ES")));
            }
            view.Rows.Add("Total: ", "","","","", sum.ToString("N", CultureInfo.CreateSpecificCulture("es-ES")) + "VND");
            dgvHistory.DataSource = view;
        }

        private void HistoryImport_Load(object sender, EventArgs e)
        {
            table = importDAO.getListImport();
            loadData(table);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            table = importDAO.seacrhLikedate(dtSeacrh.Value.ToString("yyyy-MM-dd").Trim() + " 00:00:00 AM", dtSeacrh.Value.ToString("yyyy-MM-dd").Trim() + " 23:59:59 PM");
            loadData(table);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fuction fc = new Fuction(userID);
            fc.ShowDialog();
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
