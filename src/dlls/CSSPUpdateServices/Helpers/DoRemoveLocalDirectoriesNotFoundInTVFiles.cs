using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        public async Task<ActionResult<bool>> DoRemoveLocalDirectoriesNotFoundInTVFiles()
        {
            CSSPLogService.FunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            DirectoryInfo di = new DirectoryInfo(LocalAppDataPath);
            if (!di.Exists)
            {
                CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.LocalAppDataPathDoesNotExist_, di.FullName) }", new[] { "" }));

                CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                await CSSPLogService.Save();

                return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
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
                            CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.ErrorDeletingLocalFile_Error_, fiDel.FullName, ex.Message) }", new[] { "" }));
                        }
                    }

                    try
                    {
                        diSub.Delete();
                    }
                    catch (Exception ex)
                    {
                        CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.ErrorDeletingLocalDirectory_Error_, diSub.FullName, ex.Message) }", new[] { "" }));

                        CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                        await CSSPLogService.Save();

                        return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
                    }

                }
            }

            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(Ok(true));
        }
    }
}
