/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPWebServices.Services
{
    public partial class WebService : ControllerBase, IWebService
    {
        private async Task<bool> DoStoreFilesUndercsspfilesForSubsector(int TVItemID)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            DirectoryInfo dicsspfiles = new DirectoryInfo($@"{ appDataPath }\cssp\csspfiles\");

            if (!dicsspfiles.Exists)
            {
                return false;
            }

            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(false);
            }

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == TVItemID
                             select c).FirstOrDefault();

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Subsector)
            {
                return await Task.FromResult(false);
            }

            List<int> tvItemIDList = tvItem.TVPath.Split("p".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList().Select(c => int.Parse(c)).ToList();

            foreach (int tvItemID in tvItemIDList)
            {
                List<TVItem> tvItemFileList = (from c in db.TVItems
                                               where c.ParentID == tvItemID
                                               && c.TVType == TVTypeEnum.File
                                               select c).ToList();

                foreach (TVItem tvItemFile in tvItemFileList)
                {
                    TVFile tvFile = (from c in db.TVFiles
                                     where c.TVFileTVItemID == tvItemFile.TVItemID
                                     select c).FirstOrDefault();

                    if (tvFile != null)
                    {
                        FileInfo fiToCopy = new FileInfo($"{ tvFile.ServerFilePath }{ tvFile.ServerFileName}");

                        FileInfo fiCopyDestination = new FileInfo($@"{ dicsspfiles.FullName }{ tvItemID }\{ tvFile.ServerFileName }");

                        DirectoryInfo diCopyDestination = new DirectoryInfo($@"C:\Users\charl\AppData\Roaming\cssp\csspfiles\{ tvItemID }\");

                        if (!diCopyDestination.Exists)
                        {
                            try
                            {
                                diCopyDestination.Create();
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                        }

                        if (fiToCopy.Exists)
                        {
                            try
                            {
                                fiToCopy.CopyTo(fiCopyDestination.FullName, true);
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return await Task.FromResult(true);
        }
    }
}
