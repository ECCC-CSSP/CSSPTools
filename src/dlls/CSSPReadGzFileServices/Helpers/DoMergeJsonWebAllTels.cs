/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
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
            List<TelModel> telModelLocalList = (from c in webAllTelsLocal.TelModelList
                                                where c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                || c.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                || c.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                select c).ToList();

            foreach (TelModel telModelLocal in telModelLocalList)
            {
                TelModel telModelOriginal = webAllTels.TelModelList.Where(c => c.TVItemModel.TVItem.TVItemID == telModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (telModelOriginal == null)
                {
                    webAllTels.TelModelList.Add(telModelLocal);
                }
                else
                {
                    SyncTel(telModelOriginal.Tel, telModelLocal.Tel);
                    SyncTVItemModel(telModelOriginal.TVItemModel, telModelLocal.TVItemModel);
                }
            }
        }
    }
}
