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
        private async Task FillChildListOfChildTVItemModelListLocal(List<TVItemModel> tvItemChildList, TVItem tvItem, TVTypeEnum tvTypeParent, TVTypeEnum tvType)
        {
            List<TVItem> TVItemParentList = await GetTVItemChildrenListWithTVItemID(tvItem, tvTypeParent);

            foreach (TVItem tvItemParent in TVItemParentList)
            {
                List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(tvItemParent, tvType);
                List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(tvItemParent, tvType);
                List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemID(tvItemParent, tvType);
                List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemID(tvItemParent, tvType);
                List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(tvItemParent, tvType);

                foreach (TVItem tv in TVItemParentList)
                {

                    TVItemModel webBase = new TVItemModel();
                    webBase.TVItemModel.TVItem = tv;
                    webBase.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                {
                    TVItemLanguageList.Where(c => c.TVItemID == tv.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tv.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tv.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault()
                };

                    webBase.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tv.TVItemID).ToList();

                    foreach (MapInfo MapInfo in MapInfoList)
                    {
                        if (MapInfo.TVItemID == tv.TVItemID)
                        {
                            MapInfoModel MapInfoModel = new MapInfoModel();
                            MapInfoModel.MapInfo = MapInfo;
                            MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();
                            webBase.TVItemModel.MapInfoModelList.Add(MapInfoModel);
                        }
                    }

                    tvItemChildList.Add(webBase);
                }
            }
        }
    }
}