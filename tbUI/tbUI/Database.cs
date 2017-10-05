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
        static String connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\namel\OneDrive\Documents\TankDB.mdf;Integrated Security=True;Connect Timeout=30";
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
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.Write("EXCEPTION: " + ex.Message);
            }
        }
        //TODO: INSERT, SELECT STATEMENTS 

        public void AddUser(User u)
        {
            try {
                SqlCommand insertcmd = new SqlCommand("INSERT INTO Users (Username) VALUES (@Username)", conn);
                insertcmd.Parameters.Add(new SqlParameter("@Username", u.Username));
                insertcmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.Write("EXCEPTION: " + ex.Message);
            }

        }

        //create method for highscore board. 
        //SELECT Username, wins, losses, gamesPlayed FROM Users ORDER BY wins DESC

        //method to read data. datareader
        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
