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
        private async Task<bool> DoCreateSQLiteCSSPDBLogin()
        {
            string CSSPLoginDB = Configuration.GetValue<string>("CSSPDBLogin");
            if (string.IsNullOrWhiteSpace(CSSPLoginDB))
            {
                Error = string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, "CSSPDBLogin");
                return await Task.FromResult(false);
            }

            FileInfo fiCSSPLoginDB = new FileInfo(CSSPLoginDB);

            if (!await CheckAndCreateMissingDirectoriesAndFiles(new List<FileInfo>() { fiCSSPLoginDB })) return await Task.FromResult(false);

            if (!await CSSPDBLoginIsEmpty())
            {
                Error = string.Format(CSSPCultureServicesRes.Database_ContainsInfo, fiCSSPLoginDB.FullName);
                return await Task.FromResult(false);
            }

            if (!await CreateCSSPDBLogin()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
