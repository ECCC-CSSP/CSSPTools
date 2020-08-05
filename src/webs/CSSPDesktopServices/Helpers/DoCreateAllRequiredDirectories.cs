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
            List<string> DirectoryToCreateList = new List<string>()
            {
                CSSPDBLocal, LocalCSSPWebAPIsPath, LocalCSSPJSONPath, LocalCSSPFilesPath, LocalCSSPHelpPath
            };

            foreach (string dirStr in DirectoryToCreateList)
            {
                DirectoryInfo di = new DirectoryInfo(dirStr);
                if (!di.Exists)
                {
                    try
                    {
                        di.Create();
                    }
                    catch (Exception ex)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotCreateDirectory_Error_, di.FullName, ex.Message)));
                        return await Task.FromResult(false);
                    }
                }
            }

            return await Task.FromResult(true);
        }
    }
}
