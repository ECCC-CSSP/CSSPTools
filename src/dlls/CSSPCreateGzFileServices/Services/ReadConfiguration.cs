/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> ReadConfiguration()
        {
            bool ReadOK = true;
            CSSPLogService.AppendLog(CSSPCultureDesktopRes.ReadingConfiguration);

            AzureStore = LoggedInService.Descramble(Configuration.GetValue<string>("AzureStore"));
            if (string.IsNullOrWhiteSpace(AzureStore))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "AzureStore", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPJSONPath))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPJSONPath", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
            if (string.IsNullOrWhiteSpace(CSSPJSONPathLocal))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPJSONPathLocal", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            azure_csspjson_backup_uncompress = Configuration.GetValue<string>("azure_csspjson_backup_uncompress");
            if (string.IsNullOrWhiteSpace(azure_csspjson_backup_uncompress))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "azure_csspjson_backup_uncompress", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            azure_csspjson_backup = Configuration.GetValue<string>("azure_csspjson_backup");
            if (string.IsNullOrWhiteSpace(azure_csspjson_backup))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "azure_csspjson_backup", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            CSSPLogService.AppendLog("");

            return ReadOK ? await Task.FromResult(true) : await Task.FromResult(false);
        }
    }
}
