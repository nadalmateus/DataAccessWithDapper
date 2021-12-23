using System;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace data_access_dapper
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True";
        static void Main(string[] args)
        {
            // ReadUsers();
            // ReadUser();
            // CreateUser();
            // UpdateUser();
            // DeleteUser();
        }
        static void ReadUsers()
        {
            using var connection = new SqlConnection(CONNECTION_STRING);
            var users = connection.GetAll<User>();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }
        static void ReadUser()
        {
            using var connection = new SqlConnection(CONNECTION_STRING);
            var user = connection.Get<User>(1);

            Console.WriteLine(user.Name);

        }

        static void CreateUser()
        {
            var user = new User()
            {
                Bio = "Software Enginner",
                Email = "nadal@nadal.com",
                Image = "https",
                Name = "Nadal",
                PasswordHash = "HASH",
                Slug = "Staff"
            };

            using var connection = new SqlConnection(CONNECTION_STRING);
            connection.Insert<User>(user);

            Console.WriteLine("Cadastro realizado com sucesso");

        }

        static void UpdateUser()
        {
            var user = new User()
            {
                Id = 2,
                Bio = "Software Developer",
                Email = "supp@nadal.com",
                Image = "https",
                Name = "Nadal",
                PasswordHash = "HASH",
                Slug = "Staff"
            };

            using var connection = new SqlConnection(CONNECTION_STRING);
            connection.Update<User>(user);

            Console.WriteLine("Atualização realizada com sucesso");

        }

        static void DeleteUser()
        {
            using var connection = new SqlConnection(CONNECTION_STRING);

            var user = connection.Get<User>(2);
            connection.Delete<User>(user);

            Console.WriteLine("Deleção realizada com sucesso");

        }
    }
}
