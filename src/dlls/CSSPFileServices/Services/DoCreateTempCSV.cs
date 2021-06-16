/*
 * Manually edited
 * 
 */
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace FileServices
{
    public partial class FileService : ControllerBase, IFileService
    {
        private async Task<ActionResult> DoCreateTempCSV(TableConvertToCSVModel tableConvertToCSVModel)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            FileInfo fi = new FileInfo($"{CSSPTempFilesPath}\\{tableConvertToCSVModel.TableFileName}");

            System.IO.File.WriteAllText(fi.FullName, tableConvertToCSVModel.CSVString);

            fi = new FileInfo($"{CSSPTempFilesPath}\\{tableConvertToCSVModel.TableFileName}");

            if (!fi.Exists)
            {
                return await Task.FromResult(Ok(false));
            }

            return await Task.FromResult(Ok(true));
        }
    }
}
