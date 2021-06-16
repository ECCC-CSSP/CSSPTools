/*
 * Manually edited
 * 
 */
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebMonitoringOtherStatsProvince(WebMonitoringOtherStatsProvince WebMonitoringOtherStatsProvince, WebMonitoringOtherStatsProvince WebMonitoringOtherStatsProvinceLocal)
        {
        //    if (WebMonitoringOtherStatsByYearForCountryLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
        //      || WebMonitoringOtherStatsByYearForCountryLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
        //      || WebMonitoringOtherStatsByYearForCountryLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
        //    {
        //        WebMonitoringOtherStatsByYearForCountry.TVItemModel = WebMonitoringOtherStatsByYearForCountryLocal.TVItemModel;
        //    }

        //    if ((from c in WebMonitoringOtherStatsByYearForCountryLocal.TVItemModelParentList
        //         where c.TVItem.DBCommand != DBCommandEnum.Original
        //         || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
        //         || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
        //         select c).Any())
        //    {
        //        WebMonitoringOtherStatsByYearForCountry.TVItemModelParentList = WebMonitoringOtherStatsByYearForCountryLocal.TVItemModelParentList;
        //    }

        //    List<ContactModel> ContactModelList = (from c in WebMonitoringOtherStatsByYearForCountryLocal.MunicipalityContactModelList
        //                                           where c.TVItem.DBCommand != DBCommandEnum.Original
        //                                           || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
        //                                           || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
        //                                           select c).ToList();

        //    foreach (ContactModel contactModel in ContactModelList)
        //    {
        //        ContactModel contactModelOriginal = WebMonitoringOtherStatsByYearForCountry.MunicipalityContactModelList.Where(c => c.TVItem.TVItemID == contactModel.TVItem.TVItemID).FirstOrDefault();
        //        if (contactModelOriginal == null)
        //        {
        //            WebMonitoringOtherStatsByYearForCountry.MunicipalityContactModelList.Add(contactModelOriginal);
        //        }
        //        else
        //        {
        //            contactModelOriginal = contactModel;
        //        }
        //    }

        //    List<TVFileModel> TVFileModelList = (from c in WebMonitoringOtherStatsByYearForCountryLocal.TVFileModelList
        //                                         where c.TVItem.DBCommand != DBCommandEnum.Original
        //                                         || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
        //                                         || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
        //                                         select c).ToList();

        //    foreach (TVFileModel tvFileModel in TVFileModelList)
        //    {
        //        TVFileModel tvFileModelOriginal = WebMonitoringOtherStatsByYearForCountry.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
        //        if (tvFileModelOriginal == null)
        //        {
        //            WebMonitoringOtherStatsByYearForCountry.TVFileModelList.Add(tvFileModel);
        //        }
        //        else
        //        {
        //            tvFileModelOriginal = tvFileModel;
        //        }
        //    }
        }
    }
}
