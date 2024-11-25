using System;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace ADO.net
{
    //Connecting Database
    //Data Source = . means Localhost
    //Initial Catalog = Database name (SchoolDB)
    //Integrated Security = True means not typing any password while logging into sql server
public class Program
    {
        public static void Main(String[] args)
        {
            string connectionString = "Data Source=.;Initial Catalog=SchoolDB;Integrated Security=True";
            string query = "SELECT * FROM Student";
    
            using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();//To get Data
                                                               // ExecuteNonQuery();// To insert Data
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Id"] + " " + reader["Name"] + " " + reader["Email"]);
                    }
                    connection.Close();
                }
        }
    }
}