using System;
using System.Configuration;
using System.Data.SqlClient;

namespace AspMvcWithAdoSql_app.Models
{
    public class CarsDbUnityOfWork
    {
        //private string _connectionString = @"Data Source=.\MSSQLSERVER;Initial Catalog=CarsDb;Integrated Security=True";

        private static string _connectionString = ConfigurationManager.ConnectionStrings["CarsDbConnectionString"].ConnectionString;

        public string GetAllCars()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * From CarsDb.dbo.Cars");
                command.Connection = connection;

                var resalt = command.ExecuteScalar();

                if (resalt != null)
                {
                    return resalt.ToString();
                }
                return "empty";
            }


        }


    }
}