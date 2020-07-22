using CSSPCultureServices.Resources;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> DoCreateSQLiteCSSPFileManagementDatabase()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string CSSPFilesManagementDB = Configuration.GetValue<string>("CSSPFilesManagementDB");
            if (string.IsNullOrWhiteSpace(CSSPFilesManagementDB))
            {
                Error = string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, "CSSPFilesManagementDB");
                return await Task.FromResult(false);
            }

            FileInfo fiCSSPFilesManagementDB = new FileInfo(CSSPFilesManagementDB.Replace("{AppDataPath}", appDataPath));

            if (!await CSSPFilesManagementDBIsEmpty())
            {
                Error = string.Format(CSSPCultureServicesRes.Database_ContainsInfo, fiCSSPFilesManagementDB.FullName);
                return await Task.FromResult(false);
            }

            if (!await CheckAndCreateMissingDirectoriesAndFiles(new List<FileInfo>() { fiCSSPFilesManagementDB })) return await Task.FromResult(false);

            if (!await CreateCSSPFilesManagementDB(fiCSSPFilesManagementDB)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
