using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SqlAssistant.SQLite
{
    public class SQLiteAssistant : ISqlAssistant
    {
        private readonly ISqlConfig config;

        public SQLiteAssistant(ISqlConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config), "Config cannot be null");
            this.config = config;
        }

        protected string GetConnectionString()
        {
            var connectionString = config.GetConnectionString();
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new NullReferenceException("Config return null or emty Connection String");
            return connectionString;
        }

        public IDbConnection GetConnection(ISqlConfig value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(config), "Config cannot be null");
            var connectionString = config.GetConnectionString();
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new NullReferenceException("Config return null or emty Connection String");
            return new SqliteConnection(connectionString);
        }

        public IDbConnection GetConnection() => 
            new SqliteConnection(GetConnectionString());

        public IDbConnection GetOpenConnection()
        {
            var connection = new SqliteConnection(GetConnectionString());
            connection.Open();
            return connection;
        }

        public async Task<IDbConnection> GetOpenConnectionAsync(CancellationToken cancellationToken = default)
        {
            var connection = new SqliteConnection(GetConnectionString());
            await connection.OpenAsync(cancellationToken);
            return connection;
        }
    }
}
