using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService
    {
        private async Task<bool> DoCreateAllRequiredDirectories()
        {

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            AppDataPath = appDataPath + "\\cssp\\";
            StartUrl = "https://localhost:4447/";
            CSSPWebAPIsExeFullPath = AppDataPath + "csspdesktop\\CSSPWebAPIs.exe";

            FileInfo fi = new FileInfo(CSSPWebAPIsExeFullPath);
            if (!fi.Exists)
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotFindFile_, fi.FullName)));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
