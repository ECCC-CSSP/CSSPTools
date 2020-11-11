using CSSPDBModels;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPSQLiteServices
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> DeleteTables(List<string> ListTableToDelete, List<string> ExistingTableList)
        {
            foreach (string TableName in ListTableToDelete)
            {
                if (ExistingTableList.Contains(TableName))
                {
                    using (var command = dbLocal.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = $"DROP TABLE { TableName }";
                        dbLocal.Database.OpenConnection();
                        command.ExecuteNonQuery();
                    }
                }
            }

            return await Task.FromResult(true);
        }
    }
}
