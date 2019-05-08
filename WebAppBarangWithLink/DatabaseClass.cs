using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebAppBarangWithLink
{
    public class DatabaseClass
    {
        public SqlConnection conn;
        public SqlCommand command;

        public DatabaseClass() { }

        public void openDb()
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error :" + ex);
            }
        }

        public void execute(string queryString)
        {
            try
            {
                command = new SqlCommand(queryString, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error :" + ex);

            }
        }

        public DataTable read(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(sql, conn);
                adapter.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error :" + ex);

            }

            return null;
        }

        public void closeDB()
        {
            conn.Close();
        }
    }
}