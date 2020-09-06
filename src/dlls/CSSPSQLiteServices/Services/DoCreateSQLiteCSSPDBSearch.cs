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
        private async Task<bool> DoCreateSQLiteCSSPDBSearch()
        {
            string CSSPDBSearchText = Configuration.GetValue<string>("CSSPDBSearch");
            if (string.IsNullOrWhiteSpace(CSSPDBSearchText))
            {
                Error = string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, "CSSPDBSearch");
                return await Task.FromResult(false);
            }

            FileInfo fiCSSPDBSearch = new FileInfo(CSSPDBSearchText);

            if (!await CSSPDBSearchIsEmpty())
            {
                Error = string.Format(CSSPCultureServicesRes.Database_ContainsInfo, fiCSSPDBSearch.FullName);
                return await Task.FromResult(false);
            }

            if (!await CheckAndCreateMissingDirectoriesAndFiles(new List<FileInfo>() { fiCSSPDBSearch })) return await Task.FromResult(false);

            if (!await CreateCSSPDBSearch()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
