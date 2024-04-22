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

            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);

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
