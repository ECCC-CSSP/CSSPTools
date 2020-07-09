using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPSQLiteServices.Services
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> CreateAllTables(List<string> ListTableToCreate, SqliteConnection db)
        {
            foreach (string TableName in ListTableToCreate)
            {
                if (! await CreateTableBuilder(TableName, db)) return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
