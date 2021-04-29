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
        private async Task FillMWQMSiteModelList(List<MWQMSiteModel> MWQMSiteModelList, TVItem TVItem, TVTypeEnum TVType)
        {
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVType);

            List<MWQMSite> MWQMSiteList = await GetMWQMSiteListFromSubsector(TVItem);

            List<TVFile> TVFileListAll = await GetAllTVFileListUnder(TVItem);
            List<TVFileLanguage> TVFileLanguageListAll = await GetAllTVFileLanguageListUnder(TVItem);

            List<TVItem> TVItemFileListAll = await GetTVItemListFileUnderMunicipality(TVItem);
            List<TVItemLanguage> TVItemLanguageFileListAll = await GetTVItemLanguageListFileUnderMunicipality(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                MWQMSiteModel mwqmSiteModel = new MWQMSiteModel();

                TVItemStatMapModel tvItemStatMapModel = new TVItemStatMapModel();
                tvItemStatMapModel.TVItem = tvItem;
                tvItemStatMapModel.TVItemLanguageList = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();
                tvItemStatMapModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo MapInfo in MapInfoList.Where(c => c.TVItemID == tvItem.TVItemID))
                {
                    MapInfoModel MapInfoModel = new MapInfoModel();
                    MapInfoModel.MapInfo = MapInfo;
                    MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                    tvItemStatMapModel.MapInfoModelList.Add(MapInfoModel);
                }

                mwqmSiteModel.TVItemStatMapModel = tvItemStatMapModel;

                // doing MWQMSiteModel.TVItemFileList
                foreach (TVItem tvItemFile in TVItemFileListAll.Where(c => c.ParentID == tvItem.TVItemID))
                {
                    TVFileModel tvFileModel = new TVFileModel();
                    tvFileModel.TVItem = tvItem;
                    tvFileModel.TVItemLanguageList = TVItemLanguageFileListAll.Where(c => c.TVItemID == tvItem.TVItemID).ToList();
                    tvFileModel.TVFile = TVFileListAll.Where(c => c.TVFileTVItemID == tvItem.TVItemID).FirstOrDefault();
                    
                    if (tvFileModel.TVFile != null)
                    {
                        tvFileModel.TVFileLanguageList = TVFileLanguageListAll.Where(c => c.TVFileID == tvFileModel.TVFile.TVFileID).ToList();

                        mwqmSiteModel.TVFileModelList.Add(tvFileModel);
                    }                       
                }

                mwqmSiteModel.MWQMSite = MWQMSiteList.Where(c => c.MWQMSiteTVItemID == tvItem.TVItemID).FirstOrDefault();

                MWQMSiteModelList.Add(mwqmSiteModel);
            }
        }
    }
}