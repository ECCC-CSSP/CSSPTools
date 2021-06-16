﻿using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPSQLiteServices
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> DoCSSPDBManageIsEmpty()
        {
            List<string> ExistingTableList = new List<string>();

            using (var command = dbManage.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%'";
                dbManage.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        ExistingTableList.Add(result.GetString(0));
                    }
                }
                dbManage.Database.CloseConnection();

                foreach (string tableName in ExistingTableList)
                {
                    command.CommandText = $"SELECT * FROM { tableName }";
                    dbManage.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            return await Task.FromResult(false);
                        }
                    }
                    dbManage.Database.CloseConnection();
                }
            }

            return await Task.FromResult(true);
        }
    }
}
