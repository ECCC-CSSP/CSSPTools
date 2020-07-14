using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> CreateCSSPDBLocal(FileInfo fiCSSPDBLocal)
        {
            List<string> ListTableToDelete = new List<string>();
            List<string> ListTableToCreate = new List<string>();
            List<string> ExistingTableList = new List<string>();
            using (SqliteConnection db = new SqliteConnection($"Data Source={fiCSSPDBLocal.FullName}"))
            {
                db.Open();

                if (!await FillExistingTableList(ExistingTableList, db)) return await Task.FromResult(false);
                if (!await FillListTableToDelete(ListTableToDelete)) return await Task.FromResult(false);
                if (!await DeleteTables(ListTableToDelete, ExistingTableList, db)) return await Task.FromResult(false);
                if (!await FillListTableToCreate(ListTableToCreate, ListTableToDelete)) return await Task.FromResult(false);
                if (!await CreateAllTables(ListTableToCreate, db)) return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
