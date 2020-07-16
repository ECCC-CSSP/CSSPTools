using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPSQLiteServices.Services
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> DoCSSPFilesManagementDBIsEmpty()
        {
            List<string> ExistingTableList = new List<string>() { "CSSPFiles" };

            using (var command = dbFM.Database.GetDbConnection().CreateCommand())
            {
                foreach (string tableName in ExistingTableList)
                {
                    command.CommandText = $"SELECT * FROM { tableName }";
                    dbFM.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
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
