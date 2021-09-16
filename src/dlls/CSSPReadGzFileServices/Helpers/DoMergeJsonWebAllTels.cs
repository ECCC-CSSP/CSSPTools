/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebAllTels(WebAllTels WebAllTels, WebAllTels WebAllTelsLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllTels WebAllTels, WebAllTels WebAllTelsLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            List<TelModel> telModelLocalList = (from c in WebAllTelsLocal.TelModelList
                                                    where c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                    || c.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                    || c.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                    select c).ToList();

            foreach (TelModel telModelLocal in telModelLocalList)
            {
                TelModel telModelOriginal = WebAllTels.TelModelList.Where(c => c.TVItemModel.TVItem.TVItemID == telModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (telModelOriginal == null)
                {
                    WebAllTels.TelModelList.Add(telModelLocal);
                }
                else
                {
                    telModelOriginal = telModelLocal;
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
