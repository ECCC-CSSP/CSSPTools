/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSSPWebModels;

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task FillChildListTVItemMWQMRunModelListLocal(List<MWQMRunModel> MWQMRunModelList, TVItem TVItem, TVTypeEnum TVType)
        {
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVType);

            List<MWQMRun> MWQMRunList = await GetMWQMRunListFromSubsector(TVItem);
            List<MWQMRunLanguage> MWQMRunLanguageList = await GetMWQMRunLanguageListFromSubsector(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                MWQMRunModel MWQMRunModel = new MWQMRunModel();
                MWQMRunModel.TVItemModel.TVItem = tvItem;
                MWQMRunModel.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                {
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault()
                };

                MWQMRunModel.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo MapInfo in MapInfoList)
                {
                    if (MapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel MapInfoModel = new MapInfoModel();
                        MapInfoModel.MapInfo = MapInfo;
                        MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();
                        MWQMRunModel.TVItemModel.MapInfoModelList.Add(MapInfoModel);
                    }
                }

                MWQMRunModel.MWQMRun = MWQMRunList.Where(c => c.MWQMRunTVItemID == tvItem.TVItemID).FirstOrDefault();
                if (MWQMRunModel.MWQMRun == null)
                {
                    MWQMRunModel.MWQMRunLanguageList = new List<MWQMRunLanguage>();
                }
                else
                {
                    MWQMRunModel.MWQMRunLanguageList = MWQMRunLanguageList.Where(c => c.MWQMRunID == MWQMRunModel.MWQMRun.MWQMRunID).ToList();
                }

                MWQMRunModelList.Add(MWQMRunModel);
            }
        }
    }
}