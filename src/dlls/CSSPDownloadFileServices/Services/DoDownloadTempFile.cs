/*
 * Manually edited
 * 
 */
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace DownloadFileServices
{
    public partial class DownloadFileService : ControllerBase, IDownloadFileService
    {
        private async Task<ActionResult> DoDownloadTempFile(string FileName)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            FileInfo fi = new FileInfo($"{CSSPTempFilesPath}\\{FileName}");

            FileStream fileStream = fi.OpenRead();

            if (fileStream == null)
            {
                return NotFound($"Could not find file [{fi.FullName}]");
            }

            return File(fileStream, "application/octet-stream");
        }
    }
}
