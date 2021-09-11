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
using System.Text.RegularExpressions;
using System.Reflection;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> FillMWQMSiteModelList(List<MWQMSiteModel> MWQMSiteModelList, TVItem TVItem, TVTypeEnum TVType)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<MWQMSiteModel> MWQMSiteModelList, TVItem TVItem, TVTypeEnum TVType) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }  TVType: { TVType }";
            CSSPLogService.FunctionLog(FunctionName);

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

                TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo MapInfo in MapInfoList.Where(c => c.TVItemID == tvItem.TVItemID))
                {
                    MapInfoModel MapInfoModel = new MapInfoModel();
                    MapInfoModel.MapInfo = MapInfo;
                    MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                    TVItemModel.MapInfoModelList.Add(MapInfoModel);
                }

                mwqmSiteModel.TVItemModel = TVItemModel;

                // doing MWQMSiteModel.TVItemFileList
                foreach (TVItem tvItemFile in TVItemFileListAll.Where(c => c.ParentID == tvItem.TVItemID))
                {
                    TVFileModel tvFileModel = new TVFileModel();
                    tvFileModel.TVItem = tvItemFile;
                    tvFileModel.TVItemLanguageList = TVItemLanguageFileListAll.Where(c => c.TVItemID == tvItemFile.TVItemID).ToList();
                    tvFileModel.TVFile = TVFileListAll.Where(c => c.TVFileTVItemID == tvItemFile.TVItemID).FirstOrDefault();
                    
                    if (tvFileModel.TVFile != null)
                    {
                        tvFileModel.TVFileLanguageList = TVFileLanguageListAll.Where(c => c.TVFileID == tvFileModel.TVFile.TVFileID).ToList();

                        mwqmSiteModel.TVFileModelList.Add(tvFileModel);
                    }                       
                }

                mwqmSiteModel.MWQMSite = MWQMSiteList.Where(c => c.MWQMSiteTVItemID == tvItem.TVItemID).FirstOrDefault();

                MWQMSiteModelList.Add(mwqmSiteModel);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}