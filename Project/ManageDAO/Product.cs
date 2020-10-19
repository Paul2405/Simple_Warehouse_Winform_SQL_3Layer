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
    
    public class ProDAO
    {
        static string connStr = "server=.;database=PRN_DB;uid=sa;pwd=123";
        //get name by id
        public static string getNameByID(string id)
        {
            string result = null;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Select ProductName from Product where ProductID = @ProductID", conn);
            cmd.Parameters.AddWithValue("@ProductID", id);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = dr.GetString(0);
            }
            conn.Close();
            return result;
        }

        //setStatus product
        public static bool SetStatusByID(string id, bool status)
        {
            bool check = false;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Update Product set Status = @Status where ProductID = @ProductID", conn);
            cmd.Parameters.AddWithValue("@ProductID", id);
            cmd.Parameters.AddWithValue("@Status", status);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            check = cmd.ExecuteNonQuery() > 0;
            conn.Close();
            return check;
        }

        //Update price import at productID
        public static bool updatePriceExportByID(string id, float pricePackage, float priceSub)
        {
            bool check = false;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Update Product set PriceToExportPackage = @PriceToExportPackage, PriceToExportSub = @PriceToExportSub where ProductID = @ProductID", conn);
            cmd.Parameters.AddWithValue("@PriceToExportPackage", pricePackage);
            cmd.Parameters.AddWithValue("@PriceToExportSub", priceSub);
            cmd.Parameters.AddWithValue("@ProductID", id);
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            check = cmd.ExecuteNonQuery() > 0;
            conn.Close();
            return check;
        }

        //get countExport
        public static int getCountExport(string id)
        {
            int result = 0;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Select CountSubExport from Product where ProductID = @ProductID", conn);
            cmd.Parameters.AddWithValue("@ProductID", id);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = dr.GetInt32(0);
            }
            conn.Close();
            return result;
        }

        //reset import
        public static bool updateProductAtCountExport(int count, int numPack, string id)
        {
            bool check = false;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Update Product set NumbersPackage = @NumbersPackage, CountSubExport = @Count where ProductID = @id", conn);
            cmd.Parameters.AddWithValue("@Count", count);
            cmd.Parameters.AddWithValue("@NumbersPackage", numPack);
            cmd.Parameters.AddWithValue("@id", id);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            check = cmd.ExecuteNonQuery() > 0;
            conn.Close();
            return check;
        }
        //insert product
        public static bool insertProduct(Product pro)
        {
            bool check = false;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Insert into Product(ProductID, ProductName, Description, PackageID, NumbersPackage, SubPackage, NumberSubPackage, PriceOnePackage, PriceToExportPackage, PriceToExportSub,CountSubExport, Status) " +
                "values(@ProductID, @ProductName, @Description, @Pacakge,@Numberpackage,  @SubPackage, @NumberSub, @PriceOnePack, @PriceOnePackToExport, @PriceSubExport ,@CountSubExport, @Status)", conn);
            cmd.Parameters.AddWithValue("@ProductID", pro.ProductID);
            cmd.Parameters.AddWithValue("@ProductName", pro.ProductName);
            cmd.Parameters.AddWithValue("@Description", pro.Description);
            cmd.Parameters.AddWithValue("@Pacakge", pro.Package);
            cmd.Parameters.AddWithValue("@Numberpackage", pro.NumberPackage);
            cmd.Parameters.AddWithValue("@SubPackage", pro.Subpackage);
            cmd.Parameters.AddWithValue("@NumberSub", pro.NumberSub);
            cmd.Parameters.AddWithValue("@PriceOnePack", pro.PricePackage);
            cmd.Parameters.AddWithValue("@PriceOnePackToExport", pro.PriceToExportPackage);
            cmd.Parameters.AddWithValue("@PriceSubExport", pro.PriceToExportSub);
            cmd.Parameters.AddWithValue("@CountSubExport", pro.CountSubExport);
            cmd.Parameters.AddWithValue("@Status", true);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            check = cmd.ExecuteNonQuery() > 0;
            conn.Close();
            return check;
        }

        //get numberpackage
        public static int getNumberPackageByID(string id)
        {
            int result = 0;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Select NumbersPackage from Product where ProductID = @ProductID", conn);
            cmd.Parameters.AddWithValue("@ProductID", id);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = dr.GetInt32(0);
            }
            conn.Close();
            return result;
        }
        //getNumberSub
        public static int getNumSub(string id)
        {
            int result = 0;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Select NumberSubPackage from Product where ProductID = @ProductID", conn);
            cmd.Parameters.AddWithValue("@ProductID", id);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = dr.GetInt32(0);
            }
            conn.Close();
            return result;
        }

        //getData
        public static List<Product> getListProduct()
        {
            List<Product> result = new List<Product>();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Select * From Product Where Status = @Status", conn);
            cmd.Parameters.AddWithValue("@Status", true);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Product pro = new Product();
                pro.ProductID = dt.Rows[i]["ProductID"].ToString();
                pro.ProductName = dt.Rows[i]["ProductName"].ToString();
                pro.Description = dt.Rows[i]["Description"].ToString();
                pro.Package = dt.Rows[i]["PackageID"].ToString();
                pro.NumberPackage = Convert.ToInt32(dt.Rows[i]["NumbersPackage"]);
                pro.Subpackage = dt.Rows[i]["SubPackage"].ToString();
                pro.NumberSub = Convert.ToInt32(dt.Rows[i]["NumberSubPackage"]);
                pro.PricePackage = (float)Convert.ToDouble(dt.Rows[i]["PriceOnePackage"]);
                pro.PriceToExportPackage = (float)Convert.ToDouble(dt.Rows[i]["PriceToExportPackage"].ToString());
                pro.PriceToExportSub = (float)Convert.ToDouble(dt.Rows[i]["PriceToExportSub"].ToString());
                pro.CountSubExport = Convert.ToInt32(dt.Rows[i]["CountSubExport"]);
                result.Add(pro);

            }
            conn.Close();
            return result;
        }

        //search data by name

        public static List<Product> searchLikeName(String name)
        {
            List<Product> result = new List<Product>();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Select * From Product where ProductName like @ProductName and Status = @Status", conn);
            cmd.Parameters.AddWithValue("@Status", true);
            cmd.Parameters.AddWithValue("@ProductName", "%" + name + "%");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Product pro = new Product();
                pro.ProductID = dt.Rows[i]["ProductID"].ToString();
                pro.ProductName = dt.Rows[i]["ProductName"].ToString();
                pro.Description = dt.Rows[i]["Description"].ToString();
                pro.Package = dt.Rows[i]["PackageID"].ToString();
                pro.NumberPackage = Convert.ToInt32(dt.Rows[i]["NumbersPackage"]);
                pro.Subpackage = dt.Rows[i]["SubPackage"].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i]["NumberSubPackage"].ToString()))
                {
                    pro.NumberPackage = 0;
                }
                else
                {
                    pro.NumberPackage = Convert.ToInt32(dt.Rows[i]["NumberSubPackage"]);
                }
                pro.PricePackage = (float)Convert.ToDouble(dt.Rows[i]["PriceOnePackage"]);
                result.Add(pro);

            }
            conn.Close();
            return result;
        }

        //update after insert
        public static bool updateProduct(int numPackage, int numSub, float price, string id)
        {
            bool check = false;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Update Product set NumbersPackage = @NumberPackage, PriceOnePackage = @PriceOnepackage, NumberSubPackage = @NumSub where ProductID = @id", conn);
            cmd.Parameters.AddWithValue("@NumberPackage", numPackage);
            cmd.Parameters.AddWithValue("@PriceOnepackage", price);
            cmd.Parameters.AddWithValue("@NumSub", numSub);
            cmd.Parameters.AddWithValue("@id", id);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            check = cmd.ExecuteNonQuery() > 0;
            conn.Close();
            return check;
        }

        //checkID
        public static Boolean checkProductID(String id)
        {
            Boolean check = false;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Select ProductID From Product", conn);
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

        public static bool checkInt(string s)
        {
            try
            {
                int.Parse(s);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public static bool checkFloat(string s)
        {
            try
            {
                float.Parse(s);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
