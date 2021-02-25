using System;
using System.Collections.Generic;
using System.Text;

namespace SqlAssistant.SQLite.Constants
{
    public class JournalModeType
    {
        public const string DELETE = "DELETE";
        public const string TRUNCATE = "TRUNCATE";
        public const string PERSIST = "PERSIST";
        public const string MEMORY = "MEMORY";
        public const string WAL = "WAL";
        public const string OFF = "OFF";
    }
}
