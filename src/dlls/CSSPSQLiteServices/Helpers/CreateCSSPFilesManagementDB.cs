using CSSPModels;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPSQLiteServices.Services
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> CreateCSSPFilesManagementDB(FileInfo fiCSSPFilesManagementDB)
        {
            using (var command = dbFM.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"DROP TABLE CSSPFiles";
                dbFM.Database.OpenConnection();
                command.ExecuteNonQuery();
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
