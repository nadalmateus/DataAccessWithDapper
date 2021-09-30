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
            const string connectionString = "Server=localhost,1433;Database=Data;User ID=sa;Password=1q2w3e4r@#$";
            using var connection = new SqlConnection(connectionString);
            UpdateCategory(connection);

            ListCategories(connection);
            // CreateCategory(connection);
        }

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id},{item.Title}");
            }
        }

        static void CreateCategory(SqlConnection connection)
        {
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

        }

        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title]=@title WHERE [Id]=@id ";
            var rows = connection.Execute(updateQuery, new
            {
                id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                title = "Front-end 2021"
            });

            Console.WriteLine($"{rows} linhas atualizadas");

        }
    }
}