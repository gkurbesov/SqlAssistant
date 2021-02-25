using System;
using System.Collections.Generic;
using System.Text;

namespace SqlAssistant
{
    public interface ISqlConfig
    {
        /// <summary>
        /// Get connection string
        /// </summary>
        /// <returns></returns>
        string GetConnectionString();
    }
}
