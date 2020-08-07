using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoUnzipHelp()
        {
            string zipPath = $@"{ AzureStoreCSSPHelpPath }.\cssphelp.zip";
            string extractPath = $@"{ AzureStoreCSSPHelpPath }"; ;

            ZipFile.ExtractToDirectory(zipPath, extractPath);

            return await Task.FromResult(true);
        }
    }
}
