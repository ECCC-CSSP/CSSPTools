using CSSPModels;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> CreateCSSPDBFilesManagement()
        {
            List<string> ExistingTableList = new List<string>();

            using (var command = dbFM.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%'";
                dbFM.Database.OpenConnection();
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
                    dbFM.Database.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }

            string CreateTable = "CREATE TABLE CSSPFiles (" +
                "CSSPFileID INTEGER  NOT NULL UNIQUE, " +
                "AzureStorage TEXT NOT NULL, " +
                "AzureFileName TEXT NOT NULL, " +
                "AzureETag TEXT NOT NULL, " +
                "AzureCreationTime TEXT NOT NULL, " +
                "LocalExist INTEGER NOT NULL, " +
                "LocalOld INTEGER NOT NULL)";

            using (var command = dbFM.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = CreateTable;
                dbFM.Database.OpenConnection();
                command.ExecuteNonQuery();
            }

            return await Task.FromResult(true);
        }
    }
}
