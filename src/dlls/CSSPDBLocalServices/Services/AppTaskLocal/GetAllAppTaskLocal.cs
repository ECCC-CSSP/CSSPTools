/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSSPLocalLoggedInServices;
using Microsoft.Extensions.Configuration;
using CSSPWebModels;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using CSSPHelperModels;
using CSSPLogServices;
using System.Reflection;
using System.Security.Cryptography;

namespace CSSPDBLocalServices
{
    public partial class AppTaskLocalService : ControllerBase, IAppTaskLocalService
    {
        public async Task<ActionResult<List<AppTaskLocalModel>>> GetAllAppTaskLocal()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            List<AppTaskLocalModel> appTaskModelList = new List<AppTaskLocalModel>();

            List<AppTask> appTaskList = (from c in dbLocal.AppTasks select c).ToList();
            List<AppTaskLanguage> appTaskLanguageList = (from c in dbLocal.AppTaskLanguages select c).ToList();

            foreach (AppTask appTask in appTaskList)
            {
                appTaskModelList.Add(new AppTaskLocalModel()
                {
                    AppTask = appTask,
                    AppTaskLanguageList = (from c in appTaskLanguageList
                                           where c.AppTaskID == appTask.AppTaskID
                                           select c).ToList()
                });
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(appTaskModelList));
        }
    }
}