using System.Data;
using UnitOfWorkDemo.Core.Common;

namespace UnitOfWorkDemo.Infra.Common.Persistence
{
    internal class TransactionManager : ITransactionManager, IDisposable
    {
        private readonly IDbConnection dbConnection;

        public TransactionManager(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public IDbTransaction? Transaction { get; private set; }

        public void Begin()
        {
            if (Transaction is not null)
            {
                throw new InvalidOperationException("Transaction has already been been opened");
            }

            Transaction = dbConnection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction?.Commit();
        }

        public void Rollback()
        {
            Transaction?.Rollback();
        }

        public void Dispose()
        {
            Transaction?.Dispose();
        }
    }
}
