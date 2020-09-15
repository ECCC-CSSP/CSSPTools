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
        private async Task<ActionResult<bool>> DoCreateWebRootGzFile()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItemRoot = await GetTVItemRoot();

            if (tvItemRoot == null)
            {
                return await Task.FromResult(BadRequest(CSSPCultureServicesRes.TVItemRootCouldNotBeFound));
            }

            int TVItemID = tvItemRoot.TVItemID;

            WebRoot webRoot = new WebRoot();

            try
            {
                webRoot.TVItemModel.TVItem = tvItemRoot;
                List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(TVItemID);
                List<TVItemStat> TVItemStatList = await GetTVItemStatListWithTVItemID(TVItemID);
                List<MapInfo> MapInfoList = await GetMapInfoListWithTVItemID(TVItemID);
                List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointListWithTVItemID(TVItemID);
                List<TVFile> TVFileList = await GetTVFileListWithTVItemID(TVItemID);
                List<TVFileLanguage> TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(TVItemID);

                webRoot.TVItemModel.TVItemLanguageEN = TVItemLanguageList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault();
                webRoot.TVItemModel.TVItemLanguageFR = TVItemLanguageList.Where(c => c.Language == LanguageEnum.fr).FirstOrDefault();
                webRoot.TVItemModel.TVItemStatList = TVItemStatList.Select(c => c).ToList();

                foreach (MapInfo mapInfo in MapInfoList)
                {
                    webRoot.TVItemModel.MapInfoModelList.Add(new MapInfoModel() { MapInfo = mapInfo });
                    foreach(MapInfoPoint mapInfoPoint in MapInfoPointList)
                    {
                        webRoot.TVItemModel.MapInfoModelList[webRoot.TVItemModel.MapInfoModelList.Count - 1].MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == mapInfo.MapInfoID).Select(c => c).ToList();
                    }
                }

                foreach (TVFile tvFile in TVFileList)
                {
                    TVFileLanguage tvFileLanguageEN = TVFileLanguageList.Where(c => c.Language == LanguageEnum.en).FirstOrDefault();
                    TVFileLanguage tvFileLanguageFR = TVFileLanguageList.Where(c => c.Language == LanguageEnum.fr).FirstOrDefault();
                    webRoot.TVItemModel.TVFileModelList.Add(new TVFileModel() { TVFile = tvFile, TVFileLanguageEN = tvFileLanguageEN, TVFileLanguageFR = tvFileLanguageFR });
                }

                List<TVItem> TVItemCountryList = await GetTVItemChildrenListWithTVItemID(tvItemRoot, TVTypeEnum.Country);
                List<TVItemLanguage> TVItemLanguageCountryList = await GetTVItemLanguageChildrenListWithTVItemID(tvItemRoot, TVTypeEnum.Country);
                List<TVItemStat> TVItemStatCountryList = await GetTVItemStatChildrenListWithTVItemID(tvItemRoot, TVTypeEnum.Country);
                List<MapInfo> MapInfoCountryList = await GetMapInfoChildrenListWithTVItemID(tvItemRoot, TVTypeEnum.Country);
                List<MapInfoPoint> MapInfoPointCountryList = await GetMapInfoPointChildrenListWithTVItemID(tvItemRoot, TVTypeEnum.Country);

                foreach(TVItem tvItem in TVItemCountryList)
                {
                    WebBase webBase = new WebBase();
                    webBase.TVItemModel.TVItem = tvItem;
                    webBase.TVItemModel.TVItemLanguageEN = TVItemLanguageCountryList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
                    webBase.TVItemModel.TVItemLanguageFR = TVItemLanguageCountryList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();

                    webBase.TVItemModel.TVItemStatList = TVItemStatCountryList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                    foreach (MapInfo mapInfo in MapInfoCountryList)
                    {
                        if (mapInfo.TVItemID == tvItem.TVItemID)
                        {
                            MapInfoModel mapInfoModel = new MapInfoModel();
                            mapInfoModel.MapInfo = mapInfo;
                            mapInfoModel.MapInfoPointList = MapInfoPointCountryList.Where(c => c.MapInfoID == mapInfo.MapInfoID).Select(c => c).ToList();
                            webBase.TVItemModel.MapInfoModelList.Add(mapInfoModel);
                        }
                    }

                    webRoot.TVItemCountryList.Add(webBase);
                }

                await DoStore<WebRoot>(webRoot, "WebRoot.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return await Task.FromResult(BadRequest($"{ ex.Message } { inner }"));
            }

            return await Task.FromResult(Ok(true));
        }
    }
}