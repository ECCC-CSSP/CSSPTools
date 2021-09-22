using CSSPCultureServices.Resources;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPSQLiteServices
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> DoCreateSQLiteCSSPDBLocal()
        {
            FileInfo fiCSSPDBLocal = new FileInfo(Configuration["CSSPDBLocal"]);

            if (!await CheckAndCreateMissingDirectoriesAndFiles(new List<FileInfo>() { fiCSSPDBLocal })) return await Task.FromResult(false);

            if (!await CSSPDBLocalIsEmpty())
            {
                Error = string.Format(CSSPCultureServicesRes.Database_ContainsInfo, fiCSSPDBLocal.FullName);
                return await Task.FromResult(false);
            }

            if (!await CreateCSSPDBLocal()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
