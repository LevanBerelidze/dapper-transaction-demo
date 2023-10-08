using Dapper;
using System.Data;
using UnitOfWorkDemo.Core.Common;
using UnitOfWorkDemo.Core.Persons;

namespace UnitOfWorkDemo.Infra.Persons
{
    internal class PersonRepository : IPersonRepository
    {
        private readonly IDbConnection dbConnection;
        private readonly ITransactionManager transactionManager;

        public PersonRepository(IDbConnection dbConnection, ITransactionManager transactionManager)
        {
            this.dbConnection = dbConnection;
            this.transactionManager = transactionManager;
        }

        public void UpdateBalance(int personId, int currencyId, decimal difference)
        {
            string sql = "UPDATE [dbo].[PersonBalance] " +
                "SET [Value] = [Value] - @Difference " +
                "WHERE PersonId = @PersonId AND CurrencyId = @CurrencyId";
            var queryParams = new { PersonId = personId, CurrencyId = currencyId, Difference = difference };
            dbConnection.Execute(sql, queryParams, transactionManager.Transaction);
        }
    }
}
