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
    public partial class Fuction : Form
    {
        string userID;
        public Fuction()
        {
            InitializeComponent();
        }
        public Fuction(string username) : this()
        {
            userID = username;
        }
        private void BtnImport_Click(object sender, EventArgs e)
        {
            this.Hide();
            ImportFrom ip = new ImportFrom(userID);
            ip.ShowDialog();
            this.Close();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmExport ex = new FrmExport(userID);
            ex.ShowDialog();
            this.Close();
        }

        private void BtnManage_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageProduct mg = new ManageProduct(userID);
            mg.ShowDialog();
            this.Close();
        }

        private void BtnStatistic_Click(object sender, EventArgs e)
        {
            this.Hide();
            Statistic sta = new Statistic(userID);
            sta.ShowDialog();
            sta.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HistoryImport sta = new HistoryImport(userID);
            sta.ShowDialog();
            sta.Close();
        }
    }
}
