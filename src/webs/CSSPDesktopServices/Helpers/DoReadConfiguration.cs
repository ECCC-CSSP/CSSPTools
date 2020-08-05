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
    public partial class CSSPDesktopService
    {
        private async Task<bool> DoReadConfiguration()
        {
            CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            if (string.IsNullOrWhiteSpace(CSSPDBLocal))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPDBLocal", "appsettings_csspdesktop.json")));
                return false;
            }

            CSSPDBFilesManagement = Configuration.GetValue<string>("CSSPDBFilesManagement");
            if (string.IsNullOrWhiteSpace(CSSPDBFilesManagement))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPDBFilesManagement", "appsettings_csspdesktop.json")));
                return false;
            }

            CSSPDBLogin = Configuration.GetValue<string>("CSSPDBLogin");
            if (string.IsNullOrWhiteSpace(CSSPDBLogin))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPDBLogin", "appsettings_csspdesktop.json")));
                return false;
            }

            StoreLocal = Configuration.GetValue<bool>("StoreLocal");
            if (StoreLocal == null)
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "StoreLocal", "appsettings_csspdesktop.json")));
                return false;
            }

            StoreInAzure = Configuration.GetValue<bool>("StoreInAzure");
            if (StoreInAzure == null)
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "StoreInAzure", "appsettings_csspdesktop.json")));
                return false;
            }

            LocalCSSPWebAPIsPath = Configuration.GetValue<string>("LocalCSSPWebAPIsPath");
            if (string.IsNullOrWhiteSpace(LocalCSSPWebAPIsPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "LocalCSSPWebAPIsPath", "appsettings_csspdesktop.json")));
                return false;
            }

            LocalCSSPJSONPath = Configuration.GetValue<string>("LocalCSSPJSONPath");
            if (string.IsNullOrWhiteSpace(LocalCSSPJSONPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "LocalCSSPJSONPath", "appsettings_csspdesktop.json")));
                return false;
            }

            LocalCSSPFilesPath = Configuration.GetValue<string>("LocalCSSPFilesPath");
            if (string.IsNullOrWhiteSpace(LocalCSSPFilesPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "LocalCSSPFilesPath", "appsettings_csspdesktop.json")));
                return false;
            }

            LocalCSSPHelpPath = Configuration.GetValue<string>("LocalCSSPHelpPath");
            if (string.IsNullOrWhiteSpace(LocalCSSPHelpPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "LocalCSSPHelpPath", "appsettings_csspdesktop.json")));
                return false;
            }

            AzureStoreCSSPWebAPIsPath = Configuration.GetValue<string>("AzureStoreCSSPWebAPIsPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPWebAPIsPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPWebAPIsPath", "appsettings_csspdesktop.json")));
                return false;
            }

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPJSONPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPJSONPath", "appsettings_csspdesktop.json")));
                return false;
            }

            AzureStoreCSSPFilesPath = Configuration.GetValue<string>("AzureStoreCSSPFilesPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPFilesPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPFilesPath", "appsettings_csspdesktop.json")));
                return false;
            }

            AzureStoreCSSPHelpPath = Configuration.GetValue<string>("AzureStoreCSSPHelpPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPHelpPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPHelpPath", "appsettings_csspdesktop.json")));
                return false;
            }

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            if (string.IsNullOrWhiteSpace(CSSPAzureUrl))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPAzureUrl", "appsettings_csspdesktop.json")));
                return false;
            }

            CSSPLocalUrl = Configuration.GetValue<string>("CSSPLocalUrl");
            if (string.IsNullOrWhiteSpace(CSSPLocalUrl))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPLocalUrl", "appsettings_csspdesktop.json")));
                return false;
            }

            return await Task.FromResult(true);
        }
    }
}
