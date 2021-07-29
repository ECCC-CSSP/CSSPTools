using CSSPCultureServices.Resources;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
    {
        private async Task<bool> DoReadConfiguration()
        {
            bool ReadOK = true;
            LogAppend(sbLog, CSSPCultureDesktopRes.ReadingConfiguration);

            AzureStore = LoggedInService.Descramble(Configuration.GetValue<string>("AzureStore"));
            if (string.IsNullOrWhiteSpace(AzureStore))
            {
                ErrorAppend(sbError, string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "AzureStore", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            AzureStoreCSSPFilesPath = Configuration.GetValue<string>("AzureStoreCSSPFilesPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPFilesPath))
            {
                ErrorAppend(sbError, string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPFilesPath", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPJSONPath))
            {
                ErrorAppend(sbError, string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPJSONPath", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            if (string.IsNullOrWhiteSpace(CSSPAzureUrl))
            {
                ErrorAppend(sbError, string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPAzureUrl", "appsettings_csspdesktop.json"));
                ReadOK = false;
            }

            CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
            if (string.IsNullOrWhiteSpace(CSSPFilesPath))
            {
                ErrorAppend(sbError, string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPFilesPath", "appsettings_csspdesktop.json"));
                ReadOK = false;
            }

            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            if (string.IsNullOrWhiteSpace(CSSPJSONPath))
            {
                ErrorAppend(sbError, string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPJSONPath", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
            if (string.IsNullOrWhiteSpace(CSSPJSONPathLocal))
            {
                ErrorAppend(sbError, string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "CSSPJSONPathLocal", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            LocalAppDataPath = Configuration.GetValue<string>("LocalAppDataPath");
            if (string.IsNullOrWhiteSpace(LocalAppDataPath))
            {
                ErrorAppend(sbError, string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "LocalAppDataPath", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            NationalBackupAppDataPath = Configuration.GetValue<string>("NationalBackupAppDataPath");
            if (string.IsNullOrWhiteSpace(NationalBackupAppDataPath))
            {
                ErrorAppend(sbError, string.Format(CSSPCultureDesktopRes._CouldNotBeFoundInConfigurationFile_, "NationalBackupAppDataPath", "appsettings_csspupdate.json"));
                ReadOK = false;
            }

            LogAppend(sbLog, "");

            return ReadOK ? await Task.FromResult(true) : await Task.FromResult(false);
        }
    }
}
