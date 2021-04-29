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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillClimateSiteModelList(List<ClimateSiteModel> ClimateSiteModelList, TVItem TVItem)
        {
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.ClimateSite);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.ClimateSite);
            List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemID(TVItem, TVTypeEnum.ClimateSite);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVTypeEnum.ClimateSite);

            List<ClimateSite> ClimateSiteList = await GetClimateSiteListUnderProvince(TVItem);
            List<ClimateDataValue> ClimateDataValueList = await GetClimateDataValueListUnderProvince(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                ClimateSiteModel climateSiteModel = new ClimateSiteModel();

                TVItemMapModel tvItemMapModel = new TVItemMapModel();
                tvItemMapModel.TVItem = tvItem;
                tvItemMapModel.TVItemLanguageList = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo MapInfo in MapInfoList.Where(c => c.TVItemID == tvItem.TVItemID))
                {
                    MapInfoModel MapInfoModel = new MapInfoModel();
                    MapInfoModel.MapInfo = MapInfo;
                    MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                    tvItemMapModel.MapInfoModelList.Add(MapInfoModel);
                }

                climateSiteModel.TVItemMapModel = tvItemMapModel;
                climateSiteModel.ClimateSite = ClimateSiteList.Where(c => c.ClimateSiteTVItemID == tvItem.TVItemID).FirstOrDefault();
                climateSiteModel.ClimateDataValueList = ClimateDataValueList.Where(c => c.ClimateSiteID == climateSiteModel.ClimateSite.ClimateSiteID).ToList();

                ClimateSiteModelList.Add(climateSiteModel);
            }
        }
    }
}