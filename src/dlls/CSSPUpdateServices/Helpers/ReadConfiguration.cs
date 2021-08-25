﻿using CSSPCultureServices.Resources;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
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

            AzureStoreCSSPFilesPath = Configuration.GetValue<string>("AzureStoreCSSPFilesPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPFilesPath))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPFilesPath", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPJSONPath))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPJSONPath", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            if (string.IsNullOrWhiteSpace(CSSPAzureUrl))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPAzureUrl", "appsettings_csspdesktop.json"));
                ReadOK = false;
            }

            CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
            if (string.IsNullOrWhiteSpace(CSSPFilesPath))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPFilesPath", "appsettings_csspdesktop.json"));
                ReadOK = false;
            }

            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            if (string.IsNullOrWhiteSpace(CSSPJSONPath))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPJSONPath", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
            if (string.IsNullOrWhiteSpace(CSSPJSONPathLocal))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPJSONPathLocal", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            LocalAppDataPath = Configuration.GetValue<string>("LocalAppDataPath");
            if (string.IsNullOrWhiteSpace(LocalAppDataPath))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "LocalAppDataPath", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            NationalBackupAppDataPath = Configuration.GetValue<string>("NationalBackupAppDataPath");
            if (string.IsNullOrWhiteSpace(NationalBackupAppDataPath))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "NationalBackupAppDataPath", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            ComputerName = Configuration.GetValue<string>("ComputerName");
            if (string.IsNullOrWhiteSpace(ComputerName))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "ComputerName", "appsettings_csspupdate.json"));
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