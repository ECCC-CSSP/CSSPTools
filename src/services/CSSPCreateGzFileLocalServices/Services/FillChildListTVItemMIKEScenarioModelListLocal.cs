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
        private async Task FillChildListTVItemMIKEScenarioModelListLocal(List<MikeScenarioModel> MIKEScenarioModelList, TVItem TVItem, TVTypeEnum TVType)
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
                MikeScenarioModel MikeScenarioModel = new MikeScenarioModel();
                MikeScenarioModel.TVItemModel.TVItem = tvItem;
                MikeScenarioModel.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                {
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault()
                };

                MikeScenarioModel.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo MapInfo in MapInfoList)
                {
                    if (MapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel MapInfoModel = new MapInfoModel();
                        MapInfoModel.MapInfo = MapInfo;
                        MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();
                        MikeScenarioModel.TVItemModel.MapInfoModelList.Add(MapInfoModel);
                    }
                }

                MikeScenarioModel.MikeScenario = MIKEScenarioList.Where(c => c.MikeScenarioTVItemID == tvItem.TVItemID).FirstOrDefault();

                List<MikeSourceModel> MIKESourceModelList = new List<MikeSourceModel>();

                foreach (TVItem TVItemMikeSource in TVItemMikeSourceList)
                {
                    MikeSourceModel MikeSourceModel = new MikeSourceModel();
                    if (TVItemMikeSource.ParentID == tvItem.TVItemID)
                    {
                        MikeSourceModel.TVItemModel.TVItem = TVItemMikeSource;
                        MikeSourceModel.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                        {
                            TVItemLanguageMikeSourceList.Where(c => c.TVItemID == TVItemMikeSource.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                            TVItemLanguageMikeSourceList.Where(c => c.TVItemID == TVItemMikeSource.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                            TVItemLanguageMikeSourceList.Where(c => c.TVItemID == TVItemMikeSource.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault()
                        };

                        MikeSourceModel.MikeSource = MIKESourceList.Where(c => c.MikeSourceTVItemID == TVItemMikeSource.TVItemID).FirstOrDefault();
                        MikeSourceModel.MikeSourceStartEndList = MIKESourceStartEndList.Where(c => c.MikeSourceID == MikeSourceModel.MikeSource.MikeSourceID).ToList();
                    }

                    MikeScenarioModel.MikeSourceModelList.Add(MikeSourceModel);
                }

                await FillChildListTVItemModelListLocal(MikeScenarioModel.TVItemFileList, tvItem, TVTypeEnum.File);

                MIKEScenarioModelList.Add(MikeScenarioModel);
            }
        }
    }
}