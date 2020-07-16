using CSSPModels;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPSQLiteServices.Services
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> FillExistingTableList(List<string> ExistingTableList)
        {
            using (var command = dbLocal.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%'";
                dbLocal.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        ExistingTableList.Add(result.GetString(0));
                    }
                }
            }

            return await Task.FromResult(true);
        }
    }
}
