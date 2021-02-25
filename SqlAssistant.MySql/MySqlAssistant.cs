using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SqlAssistant.MySql
{
    public class MySqlAssistant : ISqlAssistant
    {
        private readonly ISqlConfig config;

        public MySqlAssistant(ISqlConfig config)
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
            if (config == null)
                throw new ArgumentNullException(nameof(config), "Config cannot be null");
            var connectionString = value.GetConnectionString();
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new NullReferenceException("Config return null or emty Connection String");
            var connection = new MySqlConnection(connectionString);
            return connection;
        }

        public IDbConnection GetConnection() =>
            new MySqlConnection(GetConnectionString());

        public IDbConnection GetOpenConnection()
        {
            var connection = new MySqlConnection(GetConnectionString());
            connection.Open();
            return connection;
        }

        public async Task<IDbConnection> GetOpenConnectionAsync()
        {
            var connection = new MySqlConnection(GetConnectionString());
            await connection.OpenAsync();
            return connection;
        }
    }
}
