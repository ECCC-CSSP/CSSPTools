/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillTVItemModel(TVItemModel TVItemModel, TVItem TVItem)
        {

            TVItemModel.TVItem = TVItem;
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(TVItem.TVItemID);
            List<TVItemStat> TVItemStatList = await GetTVItemStatListWithTVItemID(TVItem.TVItemID);
            List<MapInfo> MapInfoList = await GetMapInfoListWithTVItemID(TVItem.TVItemID);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointListWithTVItemID(TVItem.TVItemID);
            List<TVFile> TVFileList = await GetTVFileListWithTVItemID(TVItem.TVItemID);
            List<TVFileLanguage> TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(TVItem.TVItemID);

            TVItemModel.TVItemLanguageEN = TVItemLanguageList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault();
            TVItemModel.TVItemLanguageFR = TVItemLanguageList.Where(c => c.Language == LanguageEnum.fr).FirstOrDefault();
            TVItemModel.TVItemStatList = TVItemStatList.Select(c => c).ToList();

            foreach (MapInfo mapInfo in MapInfoList)
            {
                MapInfoModel mapInfoModel = new MapInfoModel();
                mapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == mapInfo.MapInfoID).Select(c => c).ToList();
                mapInfoModel.MapInfo = mapInfo;
                TVItemModel.MapInfoModelList.Add(mapInfoModel);
            }

            foreach (TVFile tvFile in TVFileList)
            {
                TVFileLanguage tvFileLanguageEN = TVFileLanguageList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault();
                TVFileLanguage tvFileLanguageFR = TVFileLanguageList.Where(c => c.Language == LanguageEnum.fr).FirstOrDefault();
                TVItemModel.TVFileModelList.Add(new TVFileModel() { ParentTVItemID = TVItem.TVItemID, TVFile = tvFile, TVFileLanguageEN = tvFileLanguageEN, TVFileLanguageFR = tvFileLanguageFR });
            }
        }
    }
}