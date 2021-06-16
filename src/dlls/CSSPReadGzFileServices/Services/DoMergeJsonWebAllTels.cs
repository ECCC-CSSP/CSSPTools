/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebAllTels(WebAllTels WebAllTels, WebAllTels WebAllTelsLocal)
        {
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
        }
    }
}
