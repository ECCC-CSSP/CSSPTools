using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
    {
        public async Task<bool> DoRemoveLocalDirectoriesNotFoundInTVFiles()
        {
            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.Starting } DoRemoveLocalDirectoriesNotFoundInTVFiles ...");

            if (!await CheckComputerName()) return await Task.FromResult(false);

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.RunningOn } { Environment.MachineName.ToString().ToLower() }");

            DirectoryInfo di = new DirectoryInfo(LocalAppDataPath);
            if (!di.Exists)
            {
                CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.LocalAppDataPathDoesNotExist_, di.FullName) }");

                await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.RemoveLocalDirectoriesNotFoundInTVFiles);

                return await Task.FromResult(false);
            }

            List<TVItem> TVItemList = (from c in db.TVItems
                                       where c.TVType == TVTypeEnum.File
                                       orderby c.TVLevel
                                       select c).AsNoTracking().ToList();


            List<int> ParentIDList = (from c in TVItemList
                                      orderby c.ParentID
                                      select (int)c.ParentID).Distinct().ToList();

            // ---------------------------------------------
            // Cleaning Local drive
            //----------------------------------------------
            
            List<DirectoryInfo> diSubList = di.GetDirectories().OrderBy(c => c.Name).ToList();

            foreach (DirectoryInfo diSub in diSubList)
            {
                int? ParentIDExist = (from c in ParentIDList
                                      where c.ToString() == diSub.Name
                                      select c).FirstOrDefault();

                if (ParentIDExist == 0)
                {
                    if (diSub.Name == "WebTide")
                    {
                        continue;
                    }

                    CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.DeletingLocalDirectory_, diSub.Name) }");

                    List<FileInfo> fiList = diSub.GetFiles().ToList();

                    foreach(FileInfo fiDel in fiList)
                    {
                        try
                        {
                            CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.DeletingLocalFile_, fiDel.FullName) }");

                            fiDel.Delete();
                        }
                        catch (Exception ex)
                        {
                            CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.ErrorDeletingLocalFile_Error_, fiDel.FullName, ex.Message) }");
                        }
                    }

                    try
                    {
                        diSub.Delete();
                    }
                    catch (Exception ex)
                    {
                        CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.ErrorDeletingLocalDirectory_Error_, diSub.FullName, ex.Message) }");
                    }

                }
            }

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.End } DoRemoveLocalDirectoriesNotFoundInTVFiles ...");

            await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.RemoveLocalDirectoriesNotFoundInTVFiles);

            return await Task.FromResult(true);
        }
    }
}
