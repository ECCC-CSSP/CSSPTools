/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
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

            try
            {
                FileInfo fi = new FileInfo($"{CSSPTempFilesPath}\\{tableConvertToCSVModel.TableFileName}");

                System.IO.File.WriteAllText(fi.FullName, tableConvertToCSVModel.CSVString);

                fi = new FileInfo($"{CSSPTempFilesPath}\\{tableConvertToCSVModel.TableFileName}");

                if (!fi.Exists)
                {
                    return await Task.FromResult(Ok(false));
                }
            }
            catch (Exception ex)
            {
                string ErrorText = ex.Message + (ex.InnerException == null ? "" : " InnerExcecption: " + ex.InnerException.Message);
                return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.CouldNotCreateTemp_FileError_, "CSV", ErrorText)));
            }


            return await Task.FromResult(Ok(true));
        }
    }
}
