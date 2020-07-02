using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPSQLiteServices
{
    public partial class SQLiteCreateCSSPDBLocal
    {
        private async Task<bool> DeleteTables(List<string> ListTableToDelete, List<string> ExistingTableList, SqliteConnection db)
        {
            foreach (string TableName in ListTableToDelete)
            {
                if (ExistingTableList.Contains(TableName))
                {
                    string DeleteTableCommand = $"DROP TABLE { TableName }";
                    SqliteCommand DeleteTable = new SqliteCommand(DeleteTableCommand, db);
                    SqliteDataReader ResDeleteTable = DeleteTable.ExecuteReader();
                }
            }

            return await Task.FromResult(true);
        }
    }
}
