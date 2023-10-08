using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace UnitOfWorkDemo.Infra.Common.Persistence
{
    internal class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IDbConnection Create(bool shouldOpen)
        {
            string? connectionString = configuration.GetConnectionString("Database");
            SqlConnection connection = new SqlConnection(connectionString);

            if (shouldOpen)
            {
                connection.Open();
            }

            return connection;
        }
    }
}
