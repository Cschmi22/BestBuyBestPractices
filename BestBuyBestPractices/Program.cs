using BestBuyBestPractices;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;


public class Program
{
    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        string connString = config.GetConnectionString("DefaultConnection");


        IDbConnection conn = new MySqlConnection(connString);



        #region Department
        //var departmentRepo = new DapperDepartmentRepository(conn);

        //departmentRepo.InsertDepartment("New Department");

        //var departments = departmentRepo.GetAllDepartments();
        //{
        //    foreach ( var department in departments)
        //    {
        //        Console.WriteLine(department.DepartmentID);
        //        Console.WriteLine(department.Name);
        //        Console.WriteLine();
        //        Console.WriteLine();
        //    }
        //}
        #endregion

        var productRepository = new DapperProductRepository(conn);
        var products = productRepository.GetAllProducts();
        foreach (var product in products)
        {
            Console.WriteLine(product.Name);
            Console.WriteLine(product.ProductID);
            Console.WriteLine(product.Price);
            Console.WriteLine(product.OnSale);
            Console.WriteLine(product.StockLevel);
            Console.WriteLine(product.CategoryID);
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}