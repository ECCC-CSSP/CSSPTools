using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> DoCSSPLoginDBIsEmpty()
        {
            List<string> ExistingTableList = new List<string>() { "AspNetUsers", "Contacts", "Preferences" };

            using (var command = dbLogin.Database.GetDbConnection().CreateCommand())
            {
                foreach (string tableName in ExistingTableList)
                {
                    command.CommandText = $"SELECT * FROM { tableName }";
                    dbLogin.Database.OpenConnection();
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
