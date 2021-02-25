using System;
using SqlAssistant.MySql;
using SqlAssistant.Sample.Mysql;

namespace SqlAssistant.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MySqlConfig("localhost", "3306")
                .SetDatabase("DATABASE_NAME")
                .SetUser("USER")            // set your login
                .SetPassword("PASSWORD");    // set your password
            var database = new MySqlDatabase(config);
            var dataSet = database.Query("SELECT * FROM user"); // request for example
        }
    }
}
