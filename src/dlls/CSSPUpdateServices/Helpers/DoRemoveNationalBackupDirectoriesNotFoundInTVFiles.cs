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
        public async Task<ActionResult<bool>> DoRemoveNationalBackupDirectoriesNotFoundInTVFiles()
        {
            await CSSPLogService.FunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            DirectoryInfo diNat = new DirectoryInfo(NationalBackupAppDataPath);
            if (!diNat.Exists)
            {
                await CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.LocalAppDataPathDoesNotExist_, diNat.FullName) }", new[] { "" }));

                await CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

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
            // Cleaning National drive
            //----------------------------------------------

            List<DirectoryInfo> diNatSubList = diNat.GetDirectories().OrderBy(c => c.Name).ToList();

            foreach (DirectoryInfo diSub in diNatSubList)
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

                    await CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.DeletingNationalDirectory_, diSub.Name) }");

                    try
                    {
                        diSub.Delete(true);
                    }
                    catch (Exception ex)
                    {
                        await CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.ErrorDeletingNationalDirectory_, diSub.Name) }", new[] { "" }));

                        await CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                        await CSSPLogService.Save();

                        return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
                    }
                }
            }

            await CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(Ok(true));
        }
    }
}
