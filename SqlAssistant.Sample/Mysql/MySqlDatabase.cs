using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SqlAssistant.Sample.Mysql
{
    public class MySqlDatabase : MySql.MySqlAssistant
    {
        public MySqlDatabase(ISqlConfig config)
            : base(config) { }

        public DataSet Query(string query)
        {
            using var connection = GetOpenConnection() as MySqlConnection;
            using MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataSet data = new DataSet();
            adapter.Fill(data);
            return data;
        }
    }
}
