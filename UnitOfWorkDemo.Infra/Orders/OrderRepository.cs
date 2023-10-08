using Dapper;
using System.Data;
using UnitOfWorkDemo.Core.Orders;

namespace UnitOfWorkDemo.Infra.Orders
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection dbConnection;

        public OrderRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public void Add(Order order)
        {
            string sql = "INSERT INTO [dbo].[Order] " +
                "([PersonId], [ProductId], [Count], [Price], [PriceCurrencyId], [CreateDate]) " +
                "VALUES (@PersonId, @ProductId, @Count, @Price, @PriceCurrencyId, @CreateDate)";
            dbConnection.Execute(sql, order);
        }
    }
}
