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
        private async Task FillTVItemModelLocal(TVItemModel TVItemModel, TVItem TVItem)
        {

            TVItemModel.TVItem = TVItem;
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(TVItem.TVItemID);
            List<TVItemStat> TVItemStatList = await GetTVItemStatListWithTVItemID(TVItem.TVItemID);
            List<MapInfo> MapInfoList = await GetMapInfoListWithTVItemID(TVItem.TVItemID);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointListWithTVItemID(TVItem.TVItemID);
            List<TVFile> TVFileList = await GetTVFileListWithTVItemID(TVItem.TVItemID);
            List<TVFileLanguage> TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(TVItem.TVItemID);

            TVItemModel.TVItemLanguageList = new List<TVItemLanguage>() {
                TVItemLanguageList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault(),
                TVItemLanguageList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault(),
                TVItemLanguageList.Where(c => c.Language == LanguageEnum.fr).FirstOrDefault()
            };
            TVItemModel.TVItemStatList = TVItemStatList.Select(c => c).ToList();

            foreach (MapInfo MapInfo in MapInfoList)
            {
                MapInfoModel MapInfoModel = new MapInfoModel();
                MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();
                MapInfoModel.MapInfo = MapInfo;
                TVItemModel.MapInfoModelList.Add(MapInfoModel);
            }

            foreach (TVFile TVFile in TVFileList)
            {
                TVItemModel.TVFileModelList.Add(new TVFileModel()
                {
                    ParentTVItemID = TVItem.TVItemID,
                    TVFile = TVFile,
                    TVFileLanguageList = new List<TVFileLanguage>() {
                        TVFileLanguageList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault(),
                        TVFileLanguageList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault(),
                        TVFileLanguageList.Where(c => c.Language == LanguageEnum.fr).FirstOrDefault()
                    }
                });
            }
        }
    }
}