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
        private async Task<bool> DoCreateSQLiteCSSPDBFileManagement()
        {
            string CSSPDBFilesManagement = Configuration.GetValue<string>("CSSPDBFilesManagement");
            if (string.IsNullOrWhiteSpace(CSSPDBFilesManagement))
            {
                Error = string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, "CSSPDBFilesManagement");
                return await Task.FromResult(false);
            }

            FileInfo fiCSSPDBFilesManagement = new FileInfo(CSSPDBFilesManagement);

            if (!await CSSPDBFilesManagementIsEmpty())
            {
                Error = string.Format(CSSPCultureServicesRes.Database_ContainsInfo, fiCSSPDBFilesManagement.FullName);
                return await Task.FromResult(false);
            }

            if (!await CheckAndCreateMissingDirectoriesAndFiles(new List<FileInfo>() { fiCSSPDBFilesManagement })) return await Task.FromResult(false);

            if (!await CreateCSSPDBFilesManagement(fiCSSPDBFilesManagement)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
