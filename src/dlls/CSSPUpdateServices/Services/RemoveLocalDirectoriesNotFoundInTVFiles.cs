/*
 * Manually edited
 * 
 */
using CSSPCreateGzFileServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        public async Task<ActionResult<bool>> RemoveLocalDirectoriesNotFoundInTVFiles()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            DirectoryInfo diLocal = new DirectoryInfo(Configuration["LocalAppDataPath"]);
            if (!diLocal.Exists)
            {
                CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.LocalAppDataPathDoesNotExist_, diLocal.FullName) }");

                CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);
                

                return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
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

            List<DirectoryInfo> diLocalSubList = diLocal.GetDirectories().OrderBy(c => c.Name).ToList();

            foreach (DirectoryInfo diSub in diLocalSubList)
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

                    CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.DeletingNationalDirectory_, diSub.Name) }");

                    try
                    {
                        diSub.Delete(true);
                    }
                    catch (Exception)
                    {
                        CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.ErrorDeletingNationalDirectory_, diSub.Name) }");

                        CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);
                        

                        return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
                    }
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);            

            return await Task.FromResult(Ok(true));
        }
    }
}
