using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup
{
    public class Database
    {
        System.Data.SqlClient.SqlConnection con;
        SqlCommand cmd;        
        SqlDataReader dr;
        public Database()
        {
            Connect();
        }
       public bool Connect()
        {
            try
            {
                con = new System.Data.SqlClient.SqlConnection();
                con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename =D:\\191\\KiemthuPhanmem\\BTL_Temp\\drive-download-20191104T153806Z-001\\WorldCup\\WC_Database.mdf;Integrated Security=True;";
                con.Open();
                //Console.Write("Connection opened\n");
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
       }
        public void exeSQL(string sql)
        {
            cmd = new SqlCommand(sql, con);
            Console.Write("sql: " + sql);
            cmd.ExecuteNonQuery();  // dùng khi có insert, update gì đó, nếu chỉ select thôi thì ko cần
        }
        public SqlDataReader readSQL(String sql)
        {
            cmd = new SqlCommand(sql, con);           
            dr = cmd.ExecuteReader();
            return dr;
        }
        public void DisConnect()
        {
            con.Close();
        }
    }
}
