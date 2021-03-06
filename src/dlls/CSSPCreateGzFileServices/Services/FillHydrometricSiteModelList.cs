﻿/*
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
using System.Text.RegularExpressions;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillHydrometricSiteModelList(List<HydrometricSiteModel> HydrometricSiteModelList, TVItem TVItem)
        {
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.HydrometricSite);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.HydrometricSite);
            List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemID(TVItem, TVTypeEnum.HydrometricSite);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVTypeEnum.HydrometricSite);

            List<HydrometricSite> HydrometricSiteList = await GetHydrometricSiteListUnderProvince(TVItem);
            List<HydrometricDataValue> HydrometricDataValueList = await GetHydrometricDataValueListUnderProvince(TVItem);

            List<RatingCurve> RatingCurveList = await GetRatingCurveListUnderProvince(TVItem);
            List<RatingCurveValue> RatingCurveValueList = await GetRatingCurveValueListUnderProvince(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                HydrometricSiteModel hydrometricModel = new HydrometricSiteModel();

                TVItemModel TVItemModel = new TVItemModel();
                TVItemModel.TVItem = tvItem;
                TVItemModel.TVItemLanguageList = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (TVItemLanguage tvItemLanguage in TVItemModel.TVItemLanguageList)
                {
                    tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                    RegexOptions options = RegexOptions.None;
                    Regex regex = new Regex("[ ]{2,}", options);
                    tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
                }

                foreach (MapInfo MapInfo in MapInfoList.Where(c => c.TVItemID == tvItem.TVItemID))
                {
                    MapInfoModel MapInfoModel = new MapInfoModel();
                    MapInfoModel.MapInfo = MapInfo;
                    MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                    TVItemModel.MapInfoModelList.Add(MapInfoModel);
                }

                hydrometricModel.TVItemModel = TVItemModel;
                hydrometricModel.HydrometricSite = HydrometricSiteList.Where(c => c.HydrometricSiteTVItemID == tvItem.TVItemID).FirstOrDefault();
                hydrometricModel.HydrometricDataValueList = HydrometricDataValueList.Where(c => c.HydrometricSiteID == hydrometricModel.HydrometricSite.HydrometricSiteID).ToList();

                List<RatingCurveModel> ratingCurveModelList = new List<RatingCurveModel>();

                foreach (RatingCurve ratingCurve in RatingCurveList.Where(c => c.HydrometricSiteID == hydrometricModel.HydrometricSite.HydrometricSiteID))
                {
                    ratingCurveModelList.Add(new RatingCurveModel()
                    {
                        RatingCurve = ratingCurve,
                        RatingCurveValueList = RatingCurveValueList.Where(c => c.RatingCurveID == ratingCurve.RatingCurveID).ToList(),
                    });
                }

                hydrometricModel.RatingCurveModelList = ratingCurveModelList;

                HydrometricSiteModelList.Add(hydrometricModel);
            }
        }
    }
}