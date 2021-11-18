/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ICSSPReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebAllTels(WebAllTels webAllTels, WebAllTels webAllTelsLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllTels WebAllTels, WebAllTels WebAllTelsLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebAllTelsTelModelList(webAllTels, webAllTelsLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }

        private void DoMergeJsonWebAllTelsTelModelList(WebAllTels webAllTels, WebAllTels webAllTelsLocal)
        {
            List<Tel> telLocalList = (from c in webAllTelsLocal.TelList
                                                where c.DBCommand != DBCommandEnum.Original
                                                select c).ToList();

            foreach (Tel telLocal in telLocalList)
            {
                Tel telOriginal = webAllTels.TelList.Where(c => c.TelID == telLocal.TelID).FirstOrDefault();
                if (telOriginal == null)
                {
                    webAllTels.TelList.Add(telLocal);
                }
                else
                {
                    telOriginal = telLocal;
                }
            }
        }
    }
}
