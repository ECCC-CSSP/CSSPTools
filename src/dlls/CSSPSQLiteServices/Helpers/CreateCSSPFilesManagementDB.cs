using Microsoft.Data.Sqlite;
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
            List<string> ListTableToDelete = new List<string>();
            List<string> ExistingTableList = new List<string>();
            using (SqliteConnection db = new SqliteConnection($"Data Source={fiCSSPFilesManagementDB.FullName}"))
            {
                db.Open();

                if (!await FillExistingTableList(ExistingTableList, db)) return await Task.FromResult(false);
                ListTableToDelete.Add("CSSPFiles");
                if (!await DeleteTables(ListTableToDelete, ExistingTableList, db)) return await Task.FromResult(false);

                string CreateTable = "CREATE TABLE CSSPFiles (" +
                    "CSSPFileID INTEGER  NOT NULL UNIQUE, " +
                    "AzureStorage TEXT NOT NULL, " +
                    "AzureFileName TEXT NOT NULL, " +
                    "AzureETag TEXT NOT NULL, " +
                    "AzureCreationTime TEXT NOT NULL, " +
                    "LocalExist INTEGER NOT NULL, " +
                    "LocalOld INTEGER NOT NULL)";

                SqliteCommand createUsersTableCmd = new SqliteCommand(CreateTable, db);

                createUsersTableCmd.ExecuteReader();
            }

            return await Task.FromResult(true);
        }
    }
}
