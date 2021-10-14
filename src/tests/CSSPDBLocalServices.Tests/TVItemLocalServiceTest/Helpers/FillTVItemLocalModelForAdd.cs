/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task<TVItemLocalModel> FillTVItemLocalModelForAdd2(TVItemModel tvItemModelParent, TVTypeEnum tvType, string TVTextEN, string TVTextFR)
        {
            //await LoadWebType(WebTypeTVItemID, webType);

            //List<TVItemModel> tvItemModelParentList = await GetTVItemModelParentList(webType);
            //Assert.NotNull(tvItemModelParentList);

            //TVItemModel tvItemModelParent = tvItemModelParentList.Where(c => c.TVItem.TVItemID == WebTypeTVItemID).FirstOrDefault();
            //Assert.NotNull(tvItemModelParent);

            //string TVTextEN = "New item";
            //string TVTextFR = "Nouveau item";

            //switch (tvType)
            //{
            //    case TVTypeEnum.MikeBoundaryConditionMesh:
            //    case TVTypeEnum.MikeBoundaryConditionWebTide:
            //    case TVTypeEnum.MikeSource:
            //        {
            //            tvItemModelParent = webMikeScenarios.MikeScenarioModelList[0].TVItemModel;
            //            Assert.NotNull(tvItemModelParent);
            //        }
            //        break;
            //    case TVTypeEnum.File:
            //        {
            //            switch (tvTypeParent)
            //            {
            //                case TVTypeEnum.Infrastructure:
            //                    {
            //                        tvItemModelParent = webMunicipality.InfrastructureModelList[0].TVItemModel;
            //                        Assert.NotNull(tvItemModelParent);
            //                    }
            //                    break;
            //                case TVTypeEnum.MikeScenario:
            //                    {
            //                        await LoadWebType(WebTypeTVItemID, WebTypeEnum.WebMikeScenarios);
            //                        Assert.NotNull(webMikeScenarios);

            //                        tvItemModelParent = webMikeScenarios.MikeScenarioModelList[0].TVItemModel;
            //                        Assert.NotNull(tvItemModelParent);
            //                    }
            //                    break;
            //                case TVTypeEnum.MWQMSite:
            //                    {
            //                        await LoadWebType(WebTypeTVItemID, WebTypeEnum.WebMWQMSites);
            //                        Assert.NotNull(webMWQMSites);

            //                        tvItemModelParent = webMWQMSites.MWQMSiteModelList[0].TVItemModel;
            //                        Assert.NotNull(tvItemModelParent);
            //                    }
            //                    break;
            //                case TVTypeEnum.PolSourceSite:
            //                    {
            //                        await LoadWebType(WebTypeTVItemID, WebTypeEnum.WebPolSourceSites);
            //                        Assert.NotNull(webPolSourceSites);

            //                        tvItemModelParent = webPolSourceSites.PolSourceSiteModelList[0].TVItemModel;
            //                        Assert.NotNull(tvItemModelParent);
            //                    }
            //                    break;
            //                default:
            //                    break;
            //            }
            //        }
            //        break;
            //    default:
            //        break;
            //}

            TVItem tvItem = new TVItem();
            List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();

            tvItem.DBCommand = tvItemModelParent.TVItem.DBCommand;
            tvItem.IsActive = tvItemModelParent.TVItem.IsActive;
            tvItem.LastUpdateContactTVItemID = tvItemModelParent.TVItem.LastUpdateContactTVItemID;
            tvItem.LastUpdateDate_UTC = tvItemModelParent.TVItem.LastUpdateDate_UTC;
            tvItem.ParentID = tvItemModelParent.TVItem.TVItemID;
            tvItem.TVItemID = 0;
            tvItem.TVLevel = tvItemModelParent.TVItem.TVLevel + 1;
            tvItem.TVPath = tvItemModelParent.TVItem.TVPath + "p-10000";
            tvItem.TVType = tvType;

            tvItemLanguageList.Add(new TVItemLanguage()
            {
                DBCommand = tvItem.DBCommand,
                Language = LanguageEnum.en,
                LastUpdateContactTVItemID = tvItem.LastUpdateContactTVItemID,
                LastUpdateDate_UTC = tvItem.LastUpdateDate_UTC,
                TranslationStatus = TranslationStatusEnum.Translated,
                TVItemID = 0,
                TVItemLanguageID = 0,
                TVText = TVTextEN,
            });
            tvItemLanguageList.Add(new TVItemLanguage()
            {
                DBCommand = tvItem.DBCommand,
                Language = LanguageEnum.fr,
                LastUpdateContactTVItemID = tvItem.LastUpdateContactTVItemID,
                LastUpdateDate_UTC = tvItem.LastUpdateDate_UTC,
                TranslationStatus = TranslationStatusEnum.Translated,
                TVItemID = 0,
                TVItemLanguageID = 0,
                TVText = TVTextFR,
            });

            return await Task.FromResult(new TVItemLocalModel()
            {
                TVItem = tvItem,
                TVItemLanguageList = tvItemLanguageList,
                TVItemParent = tvItemModelParent.TVItem,
            });
        }
        private async Task<TVItemLocalModel> FillTVItemLocalModelForAdd(int WebTypeTVItemID, WebTypeEnum webType, TVTypeEnum tvType, TVTypeEnum tvTypeParent)
        {
            await LoadWebType(WebTypeTVItemID, webType);

            List<TVItemModel> tvItemModelParentList = await GetTVItemModelParentList(webType);
            Assert.NotNull(tvItemModelParentList);

            TVItemModel tvItemModelParent = tvItemModelParentList.Where(c => c.TVItem.TVItemID == WebTypeTVItemID).FirstOrDefault();
            Assert.NotNull(tvItemModelParent);

            string TVTextEN = "New item";
            string TVTextFR = "Nouveau item";

            switch (tvType)
            {
                case TVTypeEnum.MikeBoundaryConditionMesh:
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                case TVTypeEnum.MikeSource:
                    {
                        tvItemModelParent = webMikeScenarios.MikeScenarioModelList[0].TVItemModel;
                        Assert.NotNull(tvItemModelParent);
                    }
                    break;
                case TVTypeEnum.File:
                    {
                        switch (tvTypeParent)
                        {
                            case TVTypeEnum.Infrastructure:
                                {
                                    tvItemModelParent = webMunicipality.InfrastructureModelList[0].TVItemModel;
                                    Assert.NotNull(tvItemModelParent);
                                }
                                break;
                            case TVTypeEnum.MikeScenario:
                                {
                                    await LoadWebType(WebTypeTVItemID, WebTypeEnum.WebMikeScenarios);
                                    Assert.NotNull(webMikeScenarios);

                                    tvItemModelParent = webMikeScenarios.MikeScenarioModelList[0].TVItemModel;
                                    Assert.NotNull(tvItemModelParent);
                                }
                                break;
                            case TVTypeEnum.MWQMSite:
                                {
                                    await LoadWebType(WebTypeTVItemID, WebTypeEnum.WebMWQMSites);
                                    Assert.NotNull(webMWQMSites);

                                    tvItemModelParent = webMWQMSites.MWQMSiteModelList[0].TVItemModel;
                                    Assert.NotNull(tvItemModelParent);
                                }
                                break;
                            case TVTypeEnum.PolSourceSite:
                                {
                                    await LoadWebType(WebTypeTVItemID, WebTypeEnum.WebPolSourceSites);
                                    Assert.NotNull(webPolSourceSites);

                                    tvItemModelParent = webPolSourceSites.PolSourceSiteModelList[0].TVItemModel;
                                    Assert.NotNull(tvItemModelParent);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }

            TVItem tvItem = new TVItem();
            List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();

            tvItem.DBCommand = tvItemModelParent.TVItem.DBCommand;
            tvItem.IsActive = tvItemModelParent.TVItem.IsActive;
            tvItem.LastUpdateContactTVItemID = tvItemModelParent.TVItem.LastUpdateContactTVItemID;
            tvItem.LastUpdateDate_UTC = tvItemModelParent.TVItem.LastUpdateDate_UTC;
            tvItem.ParentID = tvItemModelParent.TVItem.TVItemID;
            tvItem.TVItemID = 0;
            tvItem.TVLevel = tvItemModelParent.TVItem.TVLevel + 1;
            tvItem.TVPath = tvItemModelParent.TVItem.TVPath + "p-10000";
            tvItem.TVType = tvType;

            tvItemLanguageList.Add(new TVItemLanguage()
            {
                DBCommand = tvItem.DBCommand,
                Language = LanguageEnum.en,
                LastUpdateContactTVItemID = tvItem.LastUpdateContactTVItemID,
                LastUpdateDate_UTC = tvItem.LastUpdateDate_UTC,
                TranslationStatus = TranslationStatusEnum.Translated,
                TVItemID = 0,
                TVItemLanguageID = 0,
                TVText = TVTextEN,
            });
            tvItemLanguageList.Add(new TVItemLanguage()
            {
                DBCommand = tvItem.DBCommand,
                Language = LanguageEnum.fr,
                LastUpdateContactTVItemID = tvItem.LastUpdateContactTVItemID,
                LastUpdateDate_UTC = tvItem.LastUpdateDate_UTC,
                TranslationStatus = TranslationStatusEnum.Translated,
                TVItemID = 0,
                TVItemLanguageID = 0,
                TVText = TVTextFR,
            });

            return new TVItemLocalModel()
            {
                TVItem = tvItem,
                TVItemLanguageList = tvItemLanguageList,
                TVItemParent = tvItemModelParent.TVItem,
            };
        }
    }
}
