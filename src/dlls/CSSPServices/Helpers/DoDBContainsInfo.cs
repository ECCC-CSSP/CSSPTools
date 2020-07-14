using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> DoDBContainsInfo(FileInfo fi)
        {
            List<string> ExistingTableList = new List<string>();
            using (SqliteConnection db = new SqliteConnection($"Data Source={fi.FullName}"))
            {
                db.Open();

                if (!await FillExistingTableList(ExistingTableList, db)) return await Task.FromResult(false);

                foreach(string tableName in ExistingTableList)
                {
                    SqliteCommand ExistingTableCommand = new SqliteCommand($"SELECT * FROM { tableName }", db);

                    if (tableName == "Addresses")
                    {
                        int selfij = 34;
                    }
                    using (SqliteDataReader ItemsInTable = ExistingTableCommand.ExecuteReader())
                    {
                        if (ItemsInTable.Read())
                        {

                        }
                        if (ItemsInTable.RecordsAffected > 0)
                        {
                            return await Task.FromResult(false);
                        }
                    }
                }
            }

            return await Task.FromResult(true);
        }
    }
}
