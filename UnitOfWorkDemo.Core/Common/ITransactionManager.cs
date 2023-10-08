using System.Data;

namespace UnitOfWorkDemo.Core.Common
{
    public interface ITransactionManager
    {
        IDbTransaction? Transaction { get; }

        void Begin();

        void Commit();

        void Rollback();
    }
}
