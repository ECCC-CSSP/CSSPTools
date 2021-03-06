﻿using CSSPDBModels;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPSQLiteServices
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> CreateAllTables(List<string> ListTableToCreate, bool DoSearch)
        {
            foreach (string TableName in ListTableToCreate)
            {
                string tableName = TableName;

                if (! await CreateTableBuilder(tableName, DoSearch)) return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
