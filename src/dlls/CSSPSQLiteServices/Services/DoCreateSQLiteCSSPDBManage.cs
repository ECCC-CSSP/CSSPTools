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
        private async Task<bool> DoCreateSQLiteCSSPDBManage()
        {
            string CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            if (string.IsNullOrWhiteSpace(CSSPDBManage))
            {
                Error = string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, "CSSPDBManage");
                return await Task.FromResult(false);
            }

            FileInfo fiCSSPDBManage = new FileInfo(CSSPDBManage);

            if (!await CheckAndCreateMissingDirectoriesAndFiles(new List<FileInfo>() { fiCSSPDBManage })) return await Task.FromResult(false);

            if (!await CSSPDBManageIsEmpty())
            {
                Error = string.Format(CSSPCultureServicesRes.Database_ContainsInfo, fiCSSPDBManage.FullName);
                return await Task.FromResult(false);
            }

            if (!await CreateCSSPDBManage()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
