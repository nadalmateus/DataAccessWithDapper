using System;
using Microsoft.Data.SqlClient;

namespace data_access_dapper
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=data;User ID=sa;Password=1q2w3e4r@#$";

            using var connection = new SqlConnection(connectionString);
            Console.WriteLine("Conectado");
        }
    }
}