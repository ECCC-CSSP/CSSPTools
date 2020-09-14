using CSSPCultureServices.Resources;
using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCreateAllRequiredDirectories()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CreatingAllRequiredDirectories));

            List<string> DirectoryToCreateList = new List<string>()
            {
               CSSPDesktopPath, CSSPDatabasesPath, CSSPWebAPIsLocalPath, CSSPJSONPath, CSSPFilesPath
            };

            foreach (string dirStr in DirectoryToCreateList)
            {
                DirectoryInfo di = new DirectoryInfo(dirStr);
                if (!di.Exists)
                {
                    try
                    {
                        di.Create();
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.DirectoryCreated_, di.FullName)));
                    }
                    catch (Exception ex)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotCreateDirectory_Error_, di.FullName, ex.Message)));
                        return await Task.FromResult(false);
                    }
                }
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
