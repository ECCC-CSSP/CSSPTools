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
        private async Task<bool> CreateCSSPDBSearch()
        {
            List<string> ExistingTableList = new List<string>();
            List<string> ListTableToCreate = new List<string>()
            {
                "TVItems", "TVItemLanguages"
            };

            using (var command = dbSearch.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%'";
                dbSearch.Database.OpenConnection();
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
                    dbSearch.Database.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }          
            
            if (!await CreateAllTables(ListTableToCreate, true)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
