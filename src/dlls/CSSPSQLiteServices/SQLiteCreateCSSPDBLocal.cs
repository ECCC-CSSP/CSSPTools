using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPSQLiteServices
{
    public partial class SQLiteCreateCSSPDBLocal
    {
        public async Task<bool> CreateSQLiteCSSPDBLocal()
        {
            List<string> ListTableToDelete = new List<string>();
            List<string> ListTableToCreate = new List<string>();
            List<string> ExistingTableList = new List<string>();
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo($@"{appDataPath}\CSSP\CSSPDBLocal.db");

            if (! await CheckAndCreateMissingDirectoryAndFile(fiAppDataPath)) return await Task.FromResult(false);

            using (SqliteConnection db = new SqliteConnection($"Data Source={fiAppDataPath.FullName}"))
            {
                db.Open();

                if (!await FillExistingTableList(ExistingTableList, db)) return await Task.FromResult(false);
                if (!await FillListTableToDelete(ListTableToDelete)) return await Task.FromResult(false);
                if (!await DeleteTables(ListTableToDelete, ExistingTableList, db)) return await Task.FromResult(false);
                if (!await FillListTableToCreate(ListTableToCreate, ListTableToDelete)) return await Task.FromResult(false);
                if (!await CreateAllTables(ListTableToCreate, db)) return await Task.FromResult(false);              
            }

            return true;
        }
    }
}
