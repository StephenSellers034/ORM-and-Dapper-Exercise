using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            string connsString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            IDbConnection conns = new MySqlConnection(connString);

            var repo = new DapperDepartmentRepository(conn);
            var repo1 = new DapperProductRepository(conns);

            Console.WriteLine("Please Type the Name of your New product");
            var newName = Console.ReadLine();

            Console.WriteLine("Please type the price:");
            double newPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("Please tell us the CategoryID");
            var newCategoryID = int.Parse(Console.ReadLine());

           

           

            repo1.CreateProduct(newName, newPrice, newCategoryID);

            var products = repo1.GetAllProducts();

            foreach(var item in products)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.CategoryID);
                Console.WriteLine();
                
            }

            repo.InsertDepartment("Automotive");

            Console.WriteLine("Type a new Department name");
            var newDepartment = Console.ReadLine();

            repo.InsertDepartment(newDepartment);

            IEnumerable<Department> allDepartments = repo.GetAllDepartments();
            foreach(Department item in allDepartments)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.DepartmentID);
                Console.WriteLine();
                 
            }


        }
    }
}
