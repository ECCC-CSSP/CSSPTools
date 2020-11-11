using CSSPDBModels;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPSQLiteServices
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> CreateCSSPDBCommandLog()
        {
            List<string> ExistingTableList = new List<string>();

            using (var command = dbCommandLog.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%'";
                dbCommandLog.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        ExistingTableList.Add(result.GetString(0));
                    }
                }

                foreach (string tableName in ExistingTableList)
                {
                    command.CommandText = $"DROP TABLE { tableName }";
                    dbCommandLog.Database.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }

            string CreateTable = "CREATE TABLE CSSPCommandLogs (" +
                "CSSPCommandLogID INTEGER  NOT NULL UNIQUE, " +
                "AppName TEXT NOT NULL, " +
                "CommandName TEXT NOT NULL, " +
                "Successful INTEGER, " +
                "ErrorMessage TEXT NULL, " +
                "DateTimeUTC TEXT NOT NULL)";

            using (var command = dbCommandLog.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = CreateTable;
                dbCommandLog.Database.OpenConnection();
                command.ExecuteNonQuery();
            }

            return await Task.FromResult(true);
        }
    }
}
