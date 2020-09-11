using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopInstallPostBuild
{
    public partial class Startup
    {
        private async Task<bool> FillVariables()
        {
            AzureStoreConnectionString = Configuration.GetValue<string>("AzureStoreConnectionString");
            if (string.IsNullOrWhiteSpace(AzureStoreConnectionString))
            {
                Console.WriteLine("Could not read AzureStoreConnectionString from Configuration");
                return await Task.FromResult(false);
            }

            AzureStoreCSSPWebAPIsLocalPath = Configuration.GetValue<string>("AzureStoreCSSPWebAPIsLocalPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPWebAPIsLocalPath))
            {
                Console.WriteLine("Could not read AzureStoreCSSPWebAPIsLocalPath from Configuration");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }

    }
}
