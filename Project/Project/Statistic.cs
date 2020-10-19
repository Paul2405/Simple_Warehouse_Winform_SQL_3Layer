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
    public partial class Statistic : Form
    {
        DataTable table;
        string userID;
        public Statistic()
        {
            InitializeComponent();
            dgvHistory.ReadOnly = true;
        }
        public Statistic(string username) : this()
        {
            userID = username;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            table = exportDAO.SearchLikeDate(dtSearch.Value.ToString("yyyy-MM-dd").Trim() + " 00:00:00 AM", dtSearch.Value.ToString("yyyy-MM-dd").Trim()+ " 23:59:59 PM");
            loadData(table);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fuction fc = new Fuction(userID);
            fc.ShowDialog();
            this.Close();
        }
        public void loadData( DataTable t)
        {
            DataTable view = new DataTable();

            view.Columns.Add("ProductID", typeof(string));
            view.Columns.Add("ProductName", typeof(string));
            view.Columns.Add("DateExport", typeof(string));
            view.Columns.Add("NumberPackage", typeof(string));
            view.Columns.Add("NumberSub", typeof(string));
            view.Columns.Add("Price", typeof(string));

            for (int i = 0; i < t.Rows.Count; i++)
            {
                view.Rows.Add(t.Rows[i]["ProductID"].ToString(), ProDAO.getNameByID(t.Rows[i]["ProductID"].ToString().Trim()), t.Rows[i]["DateExport"].ToString(),
                     t.Rows[i]["NumberPackageExport"].ToString(), t.Rows[i]["NumberSubpackageExport"].ToString(), t.Rows[i]["PriceExport"].ToString());
            }
            dgvHistory.DataSource = view;
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            table = exportDAO.getExport();
            loadData(table);
        }
    }
}
