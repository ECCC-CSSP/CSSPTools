using CSSPCultureServices.Resources;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPSQLiteServices.Services
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> DoCreateSQLiteCSSPLocalDatabase()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string CSSPDBLocalText = Configuration.GetValue<string>("CSSPDBLocal");
            if (string.IsNullOrWhiteSpace(CSSPDBLocalText))
            {
                Error = string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, "CSSPDBLocal");
                return await Task.FromResult(false);
            }

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalText.Replace("{AppDataPath}", appDataPath));

            if (!await DBLocalIsEmpty())
            {
                Error = string.Format(CSSPCultureServicesRes.Database_ContainsInfo, fiCSSPDBLocal.FullName);
                return await Task.FromResult(false);
            }

            if (!await CheckAndCreateMissingDirectoriesAndFiles(new List<FileInfo>() { fiCSSPDBLocal })) return await Task.FromResult(false);

            if (!await CreateCSSPDBLocal()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
