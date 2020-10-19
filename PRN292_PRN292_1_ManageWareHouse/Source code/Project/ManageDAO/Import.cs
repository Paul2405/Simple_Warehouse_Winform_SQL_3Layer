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
   
    public class importDAO
    {
        static string connStr = "server=.;database=PRN_DB;uid=sa;pwd=123";
        //get import list
        public static DataTable getListImport()
        {
            DataTable result = new DataTable();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Select * from Import", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(result);
            conn.Close();
            return result;
        }
        //searchby date
        public static DataTable seacrhLikedate(string start, string end)
        {
            DataTable result = new DataTable();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Select * from Import Where DateImport BETWEEN @Start AND @End", conn);
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
        public static bool removeImportByDateTime(string dt)
        {
            bool check = false;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Delete Import where DateImport = @DateImport", conn);
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
        public static bool checkImportID(string id)
        {
            Boolean check = false;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Select ImportID From Import", conn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (id.Equals(rd.GetString(0).Trim()))
                {
                    check = true;
                }
            }
            conn.Close();
            return check;
        }
        public static bool insertImport(Import import)
        {
            bool check = false;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Insert into Import values(@ImportID, @ProductID, @DateImport, @ImportFrom, @NumberPackageImport, @PricePackage)", conn);
            cmd.Parameters.AddWithValue("@ImportID", import.ImportID);
            cmd.Parameters.AddWithValue("@ProductID", import.ProductID);
            cmd.Parameters.AddWithValue("@DateImport", import.DateImport);
            cmd.Parameters.AddWithValue("@ImportFrom", import.ImportFrom);
            cmd.Parameters.AddWithValue("@NumberPackageImport", import.NumberPackageImport);
            cmd.Parameters.AddWithValue("@PricePackage", import.PriceImport);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            check = cmd.ExecuteNonQuery() > 0;
            conn.Close();
            return check;
        }
        public static bool updateImport(Import import)
        {
            bool check = false;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("update Import set ProductID = @ProductID, DateImport=@DateImport, ImportFrom = @ImportFrom, NumberPackageImport = @NumberPackageImport  where ImportID = @ImportID", conn);
            cmd.Parameters.AddWithValue("@ImportID", import.ImportID);
            cmd.Parameters.AddWithValue("@ProductID", import.ProductID);
            cmd.Parameters.AddWithValue("@DateImport", import.DateImport);
            cmd.Parameters.AddWithValue("@ImportFrom", import.ImportFrom);
            cmd.Parameters.AddWithValue("@NumberPackageImport", import.NumberPackageImport);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            check = cmd.ExecuteNonQuery() > 0;
            conn.Close();
            return check;
        }
    }
}
