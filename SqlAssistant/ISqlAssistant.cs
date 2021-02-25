using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SqlAssistant
{
    /// <summary>
    /// Base assistant interface
    /// </summary>
    public interface ISqlAssistant
    {
        /// <summary>
        /// Get new connection with custom config
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IDbConnection GetConnection(ISqlConfig value);
        /// <summary>
        /// Get new connection
        /// </summary>
        /// <returns></returns>
        IDbConnection GetConnection();
        /// <summary>
        /// Open and return new connection
        /// </summary>
        /// <returns></returns>
        IDbConnection GetOpenConnection();
        /// <summary>
        /// Open and return new connection
        /// </summary>
        /// <returns></returns>
        Task<IDbConnection> GetOpenConnectionAsync(CancellationToken cancellationToken = default);
    }
}
