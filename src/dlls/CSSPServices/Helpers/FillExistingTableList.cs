using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> FillExistingTableList(List<string> ExistingTableList, SqliteConnection db)
        {
            SqliteCommand ExistingTableCommand = new SqliteCommand("SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%'", db);

            using (SqliteDataReader TableList = ExistingTableCommand.ExecuteReader())
            {
                while (TableList.Read())
                {
                    ExistingTableList.Add(TableList.GetString(0));
                }
            }

            return await Task.FromResult(true);
        }
    }
}
