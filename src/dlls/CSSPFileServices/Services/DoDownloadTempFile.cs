/*
 * Manually edited
 * 
 */
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace FileServices
{
    public partial class FileService : ControllerBase, IFileService
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
