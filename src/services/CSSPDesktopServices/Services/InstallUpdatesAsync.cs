using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.Extensions.Configuration;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using CSSPHelperModels;
using ManageServices;
using CSSPLocalLoggedInServices;
using CSSPCultureServices.Resources;
using CSSPScrambleServices;
using CSSPLogServices;
using System.Linq;
using System.IO;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        public async Task<bool> InstallUpdatesAsync()
        {
            // need to stop CSSPWebAPIsLocal so we can copy over some files 
            foreach (var process in Process.GetProcessesByName("CSSPWebAPIsLocal"))
            {
                process.Kill();
            }

            if (!await StopAsync()) await Task.FromResult(false);

            if (!await CSSPLocalLoggedInService.SetLocalLoggedInContactInfo()) return await Task.FromResult(false);

            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.InstallUpdates));

            DirectoryInfo di = new DirectoryInfo(Configuration["CSSPDesktopPath"]);

            if (!di.Exists)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Directory_ShouldExist, di.FullName)));
                return await Task.FromResult(false);
            }

            int zipCount = 0;
            InstallingStatus(new InstallingEventArgs(10));
            foreach (string zipFileName in await GetZipFileNameListAsync())
            {
                zipCount += 1;
                InstallingStatus(new InstallingEventArgs(10 + (10 * zipCount)));
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Downloading_, zipFileName)));

                if (!await DownloadZipFilesFromAzure(zipFileName)) return await Task.FromResult(false);
            }

            int jsonCount = 0;
            foreach (string jsonFileName in await GetJsonFileNameListAsync())
            {
                jsonCount += 1;
                InstallingStatus(new InstallingEventArgs(40 + (3 * jsonCount)));
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Downloading_, jsonFileName)));

                if (!await DownloadJsonFilesFromAzure(jsonFileName)) return await Task.FromResult(false);
            }

            InstallingStatus(new InstallingEventArgs(100));
            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
