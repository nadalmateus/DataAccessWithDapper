using System;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace data_access_dapper
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            ReadUsers(connection);
            ReadRoles(connection);

            connection.Close();

        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repositories = new UserRepository(connection);
            var users = repositories.Get();

            foreach (var user in users) Console.WriteLine(user.Name);

        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repositories = new RoleRepository(connection);
            var roles = repositories.Get();

            foreach (var role in roles) Console.WriteLine(role.Name);

        }
    }
}
