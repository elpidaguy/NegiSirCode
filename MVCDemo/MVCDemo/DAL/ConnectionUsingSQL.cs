using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCDemo.DAL
{

    public class ConnectionUsingSQL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CustomerDBConnectionString"].ConnectionString;
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\MS.net\PriMayDay4\WebApplication\PHP\MVCDemo\MVCDemo\App_Data\CustomerDB.mdf;Integrated Security=True";
        public SqlDataReader GetAllCustomers()
        {
            SqlDataReader dr = null;
            SqlConnection con = new SqlConnection(connectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string command = "select * from tbl_Customers";
            SqlCommand sqlCmd = new SqlCommand(command, con);
            dr = sqlCmd.ExecuteReader();//connection oriented
            //using ()
            //{

            //}
            return dr;
        }

        public SqlDataReader GetAllCustomersUsingProcedure()
        {
            SqlDataReader dr = null;
            SqlConnection con = new SqlConnection(connectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string command = "GetAllCustomers";
            SqlCommand sqlCmd = new SqlCommand(command, con);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            dr = sqlCmd.ExecuteReader();//connection oriented
            //using ()
            //{

            //}
            return dr;
        }
    }
}