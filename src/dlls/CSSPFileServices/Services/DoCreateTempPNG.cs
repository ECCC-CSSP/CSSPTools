/*
 * Manually edited
 * 
 */
using Azure.Core;
using CSSPCultureServices.Resources;
using CSSPWebModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace FileServices
{
    public partial class FileService : ControllerBase, IFileService
    {
        private async Task<ActionResult> DoCreateTempPNG(HttpRequest request)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            try
            {
                IFormFile file = request.Form.Files[0];

                if (file.Length > 0)
                {
                    FileInfo fi = new FileInfo($"{CSSPTempFilesPath}{file.FileName}");

                    using (FileStream stream = new FileStream(fi.FullName, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return await Task.FromResult(Ok(true));
                }
                else
                {
                    return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.File_LengthIs0, file.FileName)));
                }
            }
            catch (Exception ex)
            {
                string ErrorText = ex.Message + (ex.InnerException == null ? "" : " InnerExcecption: " + ex.InnerException.Message);
                return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.CouldNotCreateTemp_FileError_, ErrorText)));
            }
        }
    }
}
