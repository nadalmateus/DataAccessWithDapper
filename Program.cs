using System;
using Dapper;
using data_access_dapper.Models;
using Microsoft.Data.SqlClient;

namespace data_access_dapper
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=data;User ID=sa;Password=1q2w3e4r@#$";

            var category = new Category
            {
                Description = "Cloud",
                Id = Guid.NewGuid(),
                Title = "AWS",
                Url = "aws.com",
                Order = 8,
                Summary = "AWL Cloud",
                Featured = false
            };

            var insertSql = @"INSERT INTO [Category] VALUES(@id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

            using var connection = new SqlConnection(connectionString);
            var rows = connection.Execute(insertSql, new
            {
                category.Description,
                category.Id,
                category.Title,
                category.Url,
                category.Order,
                category.Summary,
                category.Featured
            });
            Console.WriteLine($"{rows} linhas inseridas");

            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id},{item.Title}");
            }
        }
    }
}