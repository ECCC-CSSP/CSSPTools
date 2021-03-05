using CSSPCultureServices.Resources;
using CSSPDesktopServices.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoReadConfiguration()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.ReadingConfiguration));

            CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            if (string.IsNullOrWhiteSpace(CSSPDBLocal))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPDBLocal", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPDBSearch = Configuration.GetValue<string>("CSSPDBSearch");
            if (string.IsNullOrWhiteSpace(CSSPDBSearch))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPDBSearch", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPDBCommandLog = Configuration.GetValue<string>("CSSPDBCommandLog");
            if (string.IsNullOrWhiteSpace(CSSPDBCommandLog))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPDBCommandLog", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPDBFilesManagement = Configuration.GetValue<string>("CSSPDBFilesManagement");
            if (string.IsNullOrWhiteSpace(CSSPDBFilesManagement))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPDBFilesManagement", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPDBPreference = Configuration.GetValue<string>("CSSPDBPreference");
            if (string.IsNullOrWhiteSpace(CSSPDBPreference))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPDBPreference", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPDesktopPath = Configuration.GetValue<string>("CSSPDesktopPath");
            if (string.IsNullOrWhiteSpace(CSSPDesktopPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPDesktopPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPDatabasesPath = Configuration.GetValue<string>("CSSPDatabasesPath");
            if (string.IsNullOrWhiteSpace(CSSPDatabasesPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPDatabasesPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPWebAPIsLocalPath = Configuration.GetValue<string>("CSSPWebAPIsLocalPath");
            if (string.IsNullOrWhiteSpace(CSSPWebAPIsLocalPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPWebAPIsLocalPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            if (string.IsNullOrWhiteSpace(CSSPJSONPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPJSONPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
            if (string.IsNullOrWhiteSpace(CSSPJSONPathLocal))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPJSONPathLocal", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
            if (string.IsNullOrWhiteSpace(CSSPFilesPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPFilesPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPOtherFilesPath = Configuration.GetValue<string>("CSSPOtherFilesPath");
            if (string.IsNullOrWhiteSpace(CSSPOtherFilesPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPOtherFilesPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            AzureStoreCSSPWebAPIsLocalPath = Configuration.GetValue<string>("AzureStoreCSSPWebAPIsLocalPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPWebAPIsLocalPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPWebAPIsLocalPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPJSONPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPJSONPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            AzureStoreCSSPFilesPath = Configuration.GetValue<string>("AzureStoreCSSPFilesPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPFilesPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPFilesPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            if (string.IsNullOrWhiteSpace(CSSPAzureUrl))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPAzureUrl", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPLocalUrl = Configuration.GetValue<string>("CSSPLocalUrl");
            if (string.IsNullOrWhiteSpace(CSSPLocalUrl))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPLocalUrl", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            AzureStore = ScrambleService.Descramble(Configuration.GetValue<string>("AzureStore"));
            if (string.IsNullOrWhiteSpace(AzureStore))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "AzureStore", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
