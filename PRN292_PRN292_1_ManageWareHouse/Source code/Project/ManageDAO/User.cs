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
   
    public class UserDAO
    {
        static string  connStr = "server=.;database=PRN_DB;uid=sa;pwd=123";
        public static bool checkLogin(String username, String password)
        {
            bool check = false;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Select Status From UserApp where" +
                " Username = @Username and Password = @Password", conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                check = dr.GetBoolean(0);
            }
            conn.Close();
            return check;
        }
    }
}
