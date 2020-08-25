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
            AppendStatus(new AppendEventArgs(appTextModel.ReadingConfiguration));

            CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            if (string.IsNullOrWhiteSpace(CSSPDBLocal))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPDBLocal", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPDBFilesManagement = Configuration.GetValue<string>("CSSPDBFilesManagement");
            if (string.IsNullOrWhiteSpace(CSSPDBFilesManagement))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPDBFilesManagement", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPDBLogin = Configuration.GetValue<string>("CSSPDBLogin");
            if (string.IsNullOrWhiteSpace(CSSPDBLogin))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPDBLogin", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            LocalCSSPDesktopPath = Configuration.GetValue<string>("LocalCSSPDesktopPath");
            if (string.IsNullOrWhiteSpace(LocalCSSPDesktopPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "LocalCSSPDesktopPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            LocalCSSPDatabasesPath = Configuration.GetValue<string>("LocalCSSPDatabasesPath");
            if (string.IsNullOrWhiteSpace(LocalCSSPDatabasesPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "LocalCSSPDatabasesPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            LocalCSSPWebAPIsPath = Configuration.GetValue<string>("LocalCSSPWebAPIsPath");
            if (string.IsNullOrWhiteSpace(LocalCSSPWebAPIsPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "LocalCSSPWebAPIsPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            LocalCSSPJSONPath = Configuration.GetValue<string>("LocalCSSPJSONPath");
            if (string.IsNullOrWhiteSpace(LocalCSSPJSONPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "LocalCSSPJSONPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            LocalCSSPFilesPath = Configuration.GetValue<string>("LocalCSSPFilesPath");
            if (string.IsNullOrWhiteSpace(LocalCSSPFilesPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "LocalCSSPFilesPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            AzureStoreCSSPWebAPIsPath = Configuration.GetValue<string>("AzureStoreCSSPWebAPIsPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPWebAPIsPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPWebAPIsPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPJSONPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPJSONPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            AzureStoreCSSPFilesPath = Configuration.GetValue<string>("AzureStoreCSSPFilesPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPFilesPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPFilesPath", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            if (string.IsNullOrWhiteSpace(CSSPAzureUrl))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPAzureUrl", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            CSSPLocalUrl = Configuration.GetValue<string>("CSSPLocalUrl");
            if (string.IsNullOrWhiteSpace(CSSPLocalUrl))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPLocalUrl", "appsettings_csspdesktop.json")));
                return await Task.FromResult(false);
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
