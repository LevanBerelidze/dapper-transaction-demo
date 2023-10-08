using Dapper;
using System.Data;
using UnitOfWorkDemo.Core.Common;
using UnitOfWorkDemo.Core.Orders;

namespace UnitOfWorkDemo.Infra.Orders
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection dbConnection;
        private readonly ITransactionManager transactionManager;

        public OrderRepository(IDbConnection dbConnection, ITransactionManager transactionManager)
        {
            this.dbConnection = dbConnection;
            this.transactionManager = transactionManager;
        }

        public void Add(Order order)
        {
            string sql = "INSERT INTO [dbo].[Order] " +
                "([PersonId], [ProductId], [Count], [Price], [PriceCurrencyId], [CreateDate]) " +
                "VALUES (@PersonId, @ProductId, @Count, @Price, @PriceCurrencyId, @CreateDate)";
            dbConnection.Execute(sql, order, transactionManager.Transaction);
        }
    }
}
