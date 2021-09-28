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

            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "AWS";
            category.Url = "aws.com";
            category.Description = "Cloud";
            category.Order = 8;
            category.Summary = "AWL Cloud";
            category.Featured = false;

            var insertSql = @"INSERT INTO [Category] VALUES(NEWID(), title, url, summary, order, description, featured)";

            using var connection = new SqlConnection(connectionString);

            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id},{item.Title}");
            }
        }
    }
}