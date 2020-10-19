using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ManageDTO;
namespace ManageDAO
{
    

    public class exportDAO
    {
        static string connStr = "server=.;database=PRN_DB;uid=sa;pwd=123";
        //search by date
        public static DataTable SearchLikeDate(string start, string end)
        {
            DataTable result = new DataTable();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Select * from Export Where DateExport BETWEEN @Start AND @End", conn);
            cmd.Parameters.AddWithValue("@Start", start);
            cmd.Parameters.AddWithValue("@End", end);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(result);
            conn.Close();
            return result;
        }

        //get export list 
        public static DataTable getExport()
        {
            DataTable result = new DataTable();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Select * from Export", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(result);
            conn.Close();
            return result;
        }
        //remove export
        public static bool removeExportByDateTime(string dt)
        {
            bool check = false;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Delete Export where DateExport = @DateImport", conn);
            cmd.Parameters.AddWithValue("@DateImport", dt);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            check = cmd.ExecuteNonQuery() > 0;
            conn.Close();
            return check;
            //end
        }
        //insert export
        public static bool insertExport(Export ep)
        {
            bool check = false;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("insert into Export values(@ID, @ProID,@Date, @NumPackage, @NumSub, @PriceExport)", conn);
            cmd.Parameters.AddWithValue("@ID",ep.ExportID);
            cmd.Parameters.AddWithValue("@ProID", ep.ProductID);
            cmd.Parameters.AddWithValue("@Date", ep.DateExport);
            cmd.Parameters.AddWithValue("@NumPackage", ep.NumberPackageExport);
            cmd.Parameters.AddWithValue("@NumSub", ep.NumberSubExport);
            cmd.Parameters.AddWithValue("@PriceExport", ep.PriceExport);
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            check = cmd.ExecuteNonQuery() > 0;
            conn.Close();
            return check;
        }
    }
}
