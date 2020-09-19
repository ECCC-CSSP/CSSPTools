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
        private async Task<bool> DoCreateSQLiteCSSPDBCommandLog()
        {
            string CSSPDBCommandLog = Configuration.GetValue<string>("CSSPDBCommandLog");
            if (string.IsNullOrWhiteSpace(CSSPDBCommandLog))
            {
                Error = string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, "CSSPDBCommandLog");
                return await Task.FromResult(false);
            }

            FileInfo fiCSSPDBCommandLog = new FileInfo(CSSPDBCommandLog);

            if (!await CheckAndCreateMissingDirectoriesAndFiles(new List<FileInfo>() { fiCSSPDBCommandLog })) return await Task.FromResult(false);

            if (!await CSSPDBCommandLogIsEmpty())
            {
                Error = string.Format(CSSPCultureServicesRes.Database_ContainsInfo, fiCSSPDBCommandLog.FullName);
                return await Task.FromResult(false);
            }

            if (!await CreateCSSPDBCommandLog()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
