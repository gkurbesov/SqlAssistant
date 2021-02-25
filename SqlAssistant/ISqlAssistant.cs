using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SqlAssistant
{
    public interface ISqlAssistant
    {
        IDbConnection GetConnection(ISqlConfig value);
        IDbConnection GetConnection();
        IDbConnection GetOpenConnection();
        Task<IDbConnection> GetOpenConnectionAsync();

    }
}
