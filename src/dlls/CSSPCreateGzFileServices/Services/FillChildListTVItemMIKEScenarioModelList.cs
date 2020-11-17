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
        private async Task FillChildListTVItemMIKEScenarioModelList(List<MIKEScenarioModel> MIKEScenarioModelList, TVItem TVItem, TVTypeEnum TVType)
        {
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVType);

            List<MikeScenario> MIKEScenarioList = await GetMikeScenarioListUnderMunicipality(TVItem);
            List<MikeSource> MIKESourceList = await GetMikeSourceListUnderMunicipality(TVItem);
            List<MikeSourceStartEnd> MIKESourceStartEndList = await GetMikeSourceStartEndListUnderMunicipality(TVItem);
            List<TVItem> TVItemMikeSourceList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeSource);
            List<TVItemLanguage> TVItemLanguageMikeSourceList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeSource);

            foreach (TVItem tvItem in TVItemList)
            {
                MIKEScenarioModel mikeScenarioModel = new MIKEScenarioModel();
                mikeScenarioModel.TVItemModel.TVItem = tvItem;
                mikeScenarioModel.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                {
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault()
                };

                mikeScenarioModel.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo mapInfo in MapInfoList)
                {
                    if (mapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel mapInfoModel = new MapInfoModel();
                        mapInfoModel.MapInfo = mapInfo;
                        mapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == mapInfo.MapInfoID).Select(c => c).ToList();
                        mikeScenarioModel.TVItemModel.MapInfoModelList.Add(mapInfoModel);
                    }
                }

                mikeScenarioModel.MikeScenario = MIKEScenarioList.Where(c => c.MikeScenarioTVItemID == tvItem.TVItemID).FirstOrDefault();

                List<MikeSourceModel> MIKESourceModelList = new List<MikeSourceModel>();

                foreach (TVItem tvItemMikeSource in TVItemMikeSourceList)
                {
                    MikeSourceModel mikeSourceModel = new MikeSourceModel();
                    if (tvItemMikeSource.ParentID == tvItem.TVItemID)
                    {
                        mikeSourceModel.TVItemModel.TVItem = tvItemMikeSource;
                        mikeSourceModel.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                        {
                            TVItemLanguageMikeSourceList.Where(c => c.TVItemID == tvItemMikeSource.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                            TVItemLanguageMikeSourceList.Where(c => c.TVItemID == tvItemMikeSource.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                            TVItemLanguageMikeSourceList.Where(c => c.TVItemID == tvItemMikeSource.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault()
                        };

                        mikeSourceModel.MikeSource = MIKESourceList.Where(c => c.MikeSourceTVItemID == tvItemMikeSource.TVItemID).FirstOrDefault();
                        mikeSourceModel.MikeSourceStartEndList = MIKESourceStartEndList.Where(c => c.MikeSourceID == mikeSourceModel.MikeSource.MikeSourceID).ToList();
                    }

                    mikeScenarioModel.MikeSourceModelList.Add(mikeSourceModel);
                }

                MIKEScenarioModelList.Add(mikeScenarioModel);
            }
        }
    }
}