using CSSPCultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        private async Task<bool> ReadConfiguration()
        {
            bool ReadOK = true;

            AzureStore = LoggedInService.Descramble(Configuration.GetValue<string>("AzureStore"));
            if (string.IsNullOrWhiteSpace(AzureStore))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureUpdateRes._CouldNotBeFoundInConfigurationFile_, "AzureStore", "appsettings_csspupdate.json"), new[] { "" }));
                ReadOK = false;
            }

            AzureStoreCSSPFilesPath = Configuration.GetValue<string>("AzureStoreCSSPFilesPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPFilesPath))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureUpdateRes._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPFilesPath", "appsettings_csspupdate.json"), new[] { "" }));
                ReadOK = false;
            }

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPJSONPath))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureUpdateRes._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPJSONPath", "appsettings_csspupdate.json"), new[] { "" }));
                ReadOK = false;
            }

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            if (string.IsNullOrWhiteSpace(CSSPAzureUrl))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureUpdateRes._CouldNotBeFoundInConfigurationFile_, "CSSPAzureUrl", "appsettings_csspdesktop.json"), new[] { "" }));
                ReadOK = false;
            }

            CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
            if (string.IsNullOrWhiteSpace(CSSPFilesPath))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureUpdateRes._CouldNotBeFoundInConfigurationFile_, "CSSPFilesPath", "appsettings_csspdesktop.json"), new[] { "" }));
                ReadOK = false;
            }

            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            if (string.IsNullOrWhiteSpace(CSSPJSONPath))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureUpdateRes._CouldNotBeFoundInConfigurationFile_, "CSSPJSONPath", "appsettings_csspupdate.json"), new[] { "" }));
                ReadOK = false;
            }

            CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
            if (string.IsNullOrWhiteSpace(CSSPJSONPathLocal))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureUpdateRes._CouldNotBeFoundInConfigurationFile_, "CSSPJSONPathLocal", "appsettings_csspupdate.json"), new[] { "" }));
                ReadOK = false;
            }

            LocalAppDataPath = Configuration.GetValue<string>("LocalAppDataPath");
            if (string.IsNullOrWhiteSpace(LocalAppDataPath))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureUpdateRes._CouldNotBeFoundInConfigurationFile_, "LocalAppDataPath", "appsettings_csspupdate.json"), new[] { "" }));
                ReadOK = false;
            }

            NationalBackupAppDataPath = Configuration.GetValue<string>("NationalBackupAppDataPath");
            if (string.IsNullOrWhiteSpace(NationalBackupAppDataPath))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureUpdateRes._CouldNotBeFoundInConfigurationFile_, "NationalBackupAppDataPath", "appsettings_csspupdate.json"), new[] { "" }));
                ReadOK = false;
            }

            ComputerName = Configuration.GetValue<string>("ComputerName");
            if (string.IsNullOrWhiteSpace(ComputerName))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureUpdateRes._CouldNotBeFoundInConfigurationFile_, "ComputerName", "appsettings_csspupdate.json"), new[] { "" }));
                ReadOK = false;
            }

            azure_csspjson_backup_uncompress = Configuration.GetValue<string>("azure_csspjson_backup_uncompress");
            if (string.IsNullOrWhiteSpace(azure_csspjson_backup_uncompress))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureUpdateRes._CouldNotBeFoundInConfigurationFile_, "azure_csspjson_backup_uncompress", "appsettings_csspupdate.json"), new[] { "" }));
                ReadOK = false;
            }

            azure_csspjson_backup = Configuration.GetValue<string>("azure_csspjson_backup");
            if (string.IsNullOrWhiteSpace(azure_csspjson_backup))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureUpdateRes._CouldNotBeFoundInConfigurationFile_, "azure_csspjson_backup", "appsettings_csspupdate.json"), new[] { "" }));
                ReadOK = false;
            }

            return ReadOK ? await Task.FromResult(true) : await Task.FromResult(false);
        }
    }
}
