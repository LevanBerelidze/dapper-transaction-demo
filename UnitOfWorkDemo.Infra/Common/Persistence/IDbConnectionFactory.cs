using System.Data;

namespace UnitOfWorkDemo.Infra.Common.Persistence
{
    internal interface IDbConnectionFactory
    {
        IDbConnection Create(bool shouldOpen);
    }
}
