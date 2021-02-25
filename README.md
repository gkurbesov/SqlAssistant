# SqlAssistant
Sql connection builder and helpers
SqlAssistant is a connection factory for instances of various types of SQL connectors

## Quick start
Inherit from one of the assistant

```C#
public class MySqlDatabase : SqlAssistant.MySql.MySqlAssistant
{
      public MySqlDatabase(ISqlConfig config)
          : base(config) { }
          
      // your code ...
}
```

And use  `GetConnection()` or `GetOpenConnection()` to get the connection instance

## Fluent connection string builder
SqlAssistant has an interface to easily create settings

```C#
var config = new MySqlConfig("localhost", "3306")
    .SetDatabase("DATABASE_NAME")
    .SetUser("USER")
    .SetPassword("PASSWORD");
var database = new MySqlDatabase(config);
```
