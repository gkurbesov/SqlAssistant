using Microsoft.Data.Sqlite;
using SqlAssistant.SQLite.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlAssistant.SQLite
{
    public class SQLiteConfig : ISqlConfig
    {
        public string FilePath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string Synchronous { get; set; } = SynchronousType.OFF;
        public string JournalMode { get; set; } = JournalModeType.OFF;
        public string AutoVacuum { get; set; } = AutoVacuumType.NONE;
        public Dictionary<string, string> Other { get; set; } = new Dictionary<string, string>();

        public SQLiteConfig() { }

        public SQLiteConfig(string filePath, string fileName)
        {
            SetPath(filePath);
            SetFileName(fileName);
        }

        public SQLiteConfig SetPath(string value)
        {
            FilePath = value.TrimEnd('\\').TrimEnd('/');
            return this;
        }

        public SQLiteConfig SetFileName(string value)
        {
            FileName = value;
            return this;
        }

        public SQLiteConfig SetSynchronous(string value)
        {
            Synchronous = value;
            return this;
        }

        public SQLiteConfig SetJournalMode(string value)
        {
            JournalMode = value;
            return this;
        }

        public SQLiteConfig SetAutoVacuum(string value)
        {
            AutoVacuum = value;
            return this;
        }

        private string GetPathFile()
        {
            return System.IO.Path.Combine(FilePath, FileName);
        }


        public SQLiteConfig SetOtherParam(string key, string value)
        {
            Other.Add(key, value);
            return this;
        }

        public string GetConnectionString()
        {
            var builder = new SqliteConnectionStringBuilder();
            builder.DataSource = GetPathFile();

            builder.Add("synchronous", Synchronous);
            builder.Add("journal_mode", JournalMode);
            builder.Add("auto_vacuum", AutoVacuum);

            foreach (var item in Other)
                builder.Add(item.Key, item.Value);

            return builder.ToString();
        }
    }
}
