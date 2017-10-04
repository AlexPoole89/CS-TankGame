using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbUI
{
    class Database
    {   //TODO: ADD CONNECTION STRING
        static String connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\jacstudents\students\1795647\TankDB.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection conn;

        //open connection string
        public void OpenConnection()
        {
            conn = new SqlConnection(connString);
            conn.Open();
        }


        //method to execute queries
        public void ExecuteQueries(string Query_)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(Query_, conn);
               // cmd.Parameters.Add(new SqlParameter("Name", conn));
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.Write("EXCEPTION: " + ex.Message);
            }
        }
        //TODO: INSERT, SELECT STATEMENTS 



        //method to read data. datareader
        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
