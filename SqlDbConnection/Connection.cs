using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NimapInfotechMachineTest.SqlDbConnection
{
    public class Connection
    {
        SqlCommand Cmd;
        SqlDataAdapter Da;
        SqlConnection Con = null;
        public static string connectionString = @"Data Source=SHREE; Initial Catalog=DBNimapMumbai ; User Id=sa;Password=Game@123";

        public SqlConnection Connect()
        {
            try
            {

                Con = new SqlConnection(connectionString);
                Con.Close();
                if (Con.State == ConnectionState.Open)
                    Con.Close();
                    Con.Open();
            }
            catch (Exception ex)
            {

            }

            return Con;
        }
        public DataTable FillCombo(string query)
        {
            DataTable dt = new DataTable();

            Con = Connect();
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Da = new SqlDataAdapter(query,Con);
            Da.Fill(dt);


            return dt;
        }
    }
}