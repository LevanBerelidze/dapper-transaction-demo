using Dapper;
using System.Data;
using UnitOfWorkDemo.Core.Products;

namespace UnitOfWorkDemo.Infra.Products
{
    internal class ProductRepository : IProductRepository
    {
        private readonly IDbConnection dbConnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public void DecreaseStockAmount(int productId, int difference)
        {
            string sql = "UPDATE [dbo].[Product] " +
                "SET [LeftInStock] = [LeftInStock] - @Difference " +
                "WHERE Id = @ProductId";
            dbConnection.Execute(sql, new { ProductId = productId, Difference = difference });
        }

        public Product GetById(int id)
        {
            string sql = "SELECT [Id], [Title], [Price], [PriceCurrencyId], [LeftInStock] " +
                "FROM [dbo].[Product] " +
                "WHERE [Id] = @Id";
            Product result = dbConnection.QueryFirst<Product>(sql, new { Id = id });
            return result;
        }
    }
}
