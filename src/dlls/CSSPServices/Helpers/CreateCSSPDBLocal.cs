using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> CreateCSSPDBLocal()
        {
            List<string> ListTableToDelete = new List<string>();
            List<string> ListTableToCreate = new List<string>();
            List<string> ExistingTableList = new List<string>();

            if (!await FillExistingTableList(ExistingTableList)) return await Task.FromResult(false);
            if (!await FillListTableToDelete(ListTableToDelete)) return await Task.FromResult(false);
            if (!await DeleteTables(ListTableToDelete, ExistingTableList)) return await Task.FromResult(false);
            if (!await FillListTableToCreate(ListTableToCreate, ListTableToDelete)) return await Task.FromResult(false);
            if (!await CreateAllTables(ListTableToCreate)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
