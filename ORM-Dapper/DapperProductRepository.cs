using System;
using System.Data;
using Dapper;
using System.Collections.Generic;
namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection; // protects field from outside world

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct( string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryId);",
                new {name = name, price = price, categoryID = categoryID});
        }

        public IEnumerable<Product> GetAllProducts()
        {
           return  _connection.Query<Product>("SELECT * FROM PRODUCTS;");
           
        }

        public void UpdateProductName( int productID, string updatedName)
        {
            _connection.Execute("UPDATE products SET Name = @updatedName Where ProductID = @productID;",
                new { updatedName = updatedName, productID = productID });
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM products WHERE ProductID = @productID",
                new { productID = productID });

            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID",
                new { productID = productID });

            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID",
                new { productID = productID });

            

        }
    }
}

