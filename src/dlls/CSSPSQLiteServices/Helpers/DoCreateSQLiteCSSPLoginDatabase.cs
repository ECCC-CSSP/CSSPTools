using CultureServices.Resources;
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
        private async Task<bool> DoCreateSQLiteCSSPLoginDatabase()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string CSSPLoginDB = Configuration.GetValue<string>("CSSPLoginDB");
            if (string.IsNullOrWhiteSpace(CSSPLoginDB))
            {
                Error = string.Format(CultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, "CSSPLoginDB");
                return await Task.FromResult(false);
            }

            FileInfo fiCSSPLoginDB = new FileInfo(CSSPLoginDB.Replace("{AppDataPath}", appDataPath));

            if (!await CSSPLoginDBIsEmpty())
            {
                Error = string.Format(CultureServicesRes.Database_ContainsInfo, fiCSSPLoginDB.FullName);
                return await Task.FromResult(false);
            }

            if (!await CheckAndCreateMissingDirectoriesAndFiles(new List<FileInfo>() { fiCSSPLoginDB })) return await Task.FromResult(false);

            if (!await CreateCSSPLoginDB(fiCSSPLoginDB)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
