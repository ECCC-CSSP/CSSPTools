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
        private async Task<bool> FillTVItemModelAndParentTVItemModelList(TVItemModel TVItemModel, List<TVItemModel> TVItemParentList, TVItem TVItem)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(TVItemModel TVItemModel, List<TVItemModel> TVItemParentList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }";
            CSSPLogService.FunctionLog(FunctionName);

            List<TVItem> TVItemList = await GetTVItemParentListWithTVItem(TVItem);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageParentListWithTVItem(TVItem);
            List<TVItemStat> TVItemStatList = await GetTVItemStatParentListWithTVItem(TVItem);
            List<MapInfo> MapInfoList = await GetMapInfoParentListWithTVItem(TVItem);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointParentListWithTVItem(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                TVItemModel tvItemModelParent = new TVItemModel();
                tvItemModelParent.TVItem = tvItem;
                tvItemModelParent.TVItemLanguageList = (from c in TVItemLanguageList 
                                                        where c.TVItemID == tvItem.TVItemID 
                                                        orderby c.Language 
                                                        select c).ToList();

                foreach (TVItemLanguage tvItemLanguage in tvItemModelParent.TVItemLanguageList)
                {
                    tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                    RegexOptions options = RegexOptions.None;
                    Regex regex = new Regex("[ ]{2,}", options);
                    tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
                }

                tvItemModelParent.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                TVItemParentList.Add(tvItemModelParent);
            }
            
            TVItemModel.TVItem = TVItemParentList[TVItemParentList.Count - 1].TVItem;
            TVItemModel.TVItemLanguageList = TVItemParentList[TVItemParentList.Count - 1].TVItemLanguageList;

            foreach (TVItemLanguage tvItemLanguage in TVItemModel.TVItemLanguageList)
            {
                tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);
                tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
            }

            TVItemModel.TVItemStatList = TVItemParentList[TVItemParentList.Count - 1].TVItemStatList;

            foreach (MapInfo MapInfo in MapInfoList.Where(c => c.TVItemID == TVItem.TVItemID))
            {
                    MapInfoModel MapInfoModel = new MapInfoModel();
                    MapInfoModel.MapInfo = MapInfo;
                    MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                TVItemModel.MapInfoModelList.Add(MapInfoModel);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}