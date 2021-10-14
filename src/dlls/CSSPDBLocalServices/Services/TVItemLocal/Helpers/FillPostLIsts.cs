/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CSSPDBLocalServices
{
    public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
    {
        private GzObjectList FillPostLists(TVItemLocalModel tvItemLocalModel)
        {
            GzObjectList gzObjectList = new GzObjectList();

            switch (tvItemLocalModel.TVItem.TVType)
            {
                case TVTypeEnum.Address:
                    {
                        WebRoot webRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        WebAllAddresses webAllAddresses = ReadGzFileService.GetUncompressJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webRoot.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webAllAddresses.AddressModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemModel.TVItem,
                                                              TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        WebProvince webProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webProvince.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webProvince.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webProvince.TVItemModelAreaList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Classification:
                    {
                        WebSubsector webSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webSubsector.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webSubsector.TVItemModelClassificationList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        WebClimateSites webClimateSites = ReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webClimateSites.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webClimateSites.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webClimateSites.ClimateSiteModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemModel.TVItem,
                                                              TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Contact:
                    {
                        WebRoot webRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        WebAllContacts webAllContacts = ReadGzFileService.GetUncompressJSON<WebAllContacts>(WebTypeEnum.WebAllContacts, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webRoot.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webAllContacts.ContactModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemModel.TVItem,
                                                              TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        WebRoot webRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webRoot.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webRoot.TVItemModelCountryList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.File:
                    {
                        switch (tvItemLocalModel.TVItemParent.TVType)
                        {
                            case TVTypeEnum.Area:
                                {
                                    WebArea webArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                                    if (CSSPLogService.ErrRes.ErrList.Count > 0)
                                    {
                                        return new GzObjectList();
                                    }

                                    gzObjectList.ParentTVItem = webArea.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = webArea.TVItemModelParentList;
                                    gzObjectList.tvItemFileSiblingList = webArea.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Country:
                                {
                                    WebCountry webCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                                    if (CSSPLogService.ErrRes.ErrList.Count > 0)
                                    {
                                        return new GzObjectList();
                                    }

                                    gzObjectList.ParentTVItem = webCountry.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = webCountry.TVItemModelParentList;
                                    gzObjectList.tvItemFileSiblingList = webCountry.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Infrastructure:
                                {
                                    WebMunicipality webMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                                    if (CSSPLogService.ErrRes.ErrList.Count > 0)
                                    {
                                        return new GzObjectList();
                                    }

                                    gzObjectList.ParentTVItem = webMunicipality.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = webMunicipality.TVItemModelParentList;
                                    gzObjectList.tvItemFileSiblingList = (from c in webMunicipality.InfrastructureModelList
                                                                               where c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                                               select c.TVFileModelList).FirstOrDefault() ?? new List<TVFileModel>();

                                }
                                break;
                            case TVTypeEnum.MikeScenario:
                                {
                                    WebMikeScenarios webMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                                    if (CSSPLogService.ErrRes.ErrList.Count > 0)
                                    {
                                        return new GzObjectList();
                                    }

                                    MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList.Where(c => c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.ParentID).FirstOrDefault();

                                    if (CSSPLogService.ErrRes.ErrList.Count > 0)
                                    {
                                        return new GzObjectList();
                                    }

                                    gzObjectList.ParentTVItem = mikeScenarioModel.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = mikeScenarioModel.TVItemModelParentList;
                                    gzObjectList.tvItemFileSiblingList = mikeScenarioModel.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Municipality:
                                {
                                    WebMunicipality webMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                                    if (CSSPLogService.ErrRes.ErrList.Count > 0)
                                    {
                                        return new GzObjectList();
                                    }

                                    gzObjectList.ParentTVItem = webMunicipality.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = webMunicipality.TVItemModelParentList;
                                    gzObjectList.tvItemFileSiblingList = webMunicipality.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.MWQMSite:
                                {
                                    WebSubsector webSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                                    if (CSSPLogService.ErrRes.ErrList.Count > 0)
                                    {
                                        return new GzObjectList();
                                    }

                                    WebMWQMSites webMWQMSites = ReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                                    if (CSSPLogService.ErrRes.ErrList.Count > 0)
                                    {
                                        return new GzObjectList();
                                    }

                                    gzObjectList.ParentTVItem = webSubsector.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = webSubsector.TVItemModelParentList;
                                    gzObjectList.tvItemFileSiblingList = (from c in webMWQMSites.MWQMSiteModelList
                                                                   where c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                                   select c.TVFileModelList).FirstOrDefault() ?? new List<TVFileModel>();
                                }
                                break;
                            case TVTypeEnum.PolSourceSite:
                                {
                                    WebSubsector webSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                                    if (CSSPLogService.ErrRes.ErrList.Count > 0)
                                    {
                                        return new GzObjectList();
                                    }

                                    WebPolSourceSites webPolSourceSites = ReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                                    if (CSSPLogService.ErrRes.ErrList.Count > 0)
                                    {
                                        return new GzObjectList();
                                    }

                                    gzObjectList.ParentTVItem = webSubsector.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = webSubsector.TVItemModelParentList;
                                    gzObjectList.tvItemFileSiblingList = (from c in webPolSourceSites.PolSourceSiteModelList
                                                                          where c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                                          select c.TVFileModelList).FirstOrDefault() ?? new List<TVFileModel>();
                                }
                                break;
                            case TVTypeEnum.Province:
                                {
                                    WebProvince webProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                                    if (CSSPLogService.ErrRes.ErrList.Count > 0)
                                    {
                                        return new GzObjectList();
                                    }

                                    gzObjectList.ParentTVItem = webProvince.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = webProvince.TVItemModelParentList;
                                    gzObjectList.tvItemFileSiblingList = webProvince.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Root:
                                {
                                    WebRoot webRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                                    if (CSSPLogService.ErrRes.ErrList.Count > 0)
                                    {
                                        return new GzObjectList();
                                    }

                                    gzObjectList.ParentTVItem = webRoot.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = webRoot.TVItemModelParentList;
                                    gzObjectList.tvItemFileSiblingList = webRoot.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Sector:
                                {
                                    WebSector webSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                                    if (CSSPLogService.ErrRes.ErrList.Count > 0)
                                    {
                                        return new GzObjectList();
                                    }

                                    gzObjectList.ParentTVItem = webSector.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = webSector.TVItemModelParentList;
                                    gzObjectList.tvItemFileSiblingList = webSector.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Subsector:
                                {
                                    WebSubsector webSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                                    if (CSSPLogService.ErrRes.ErrList.Count > 0)
                                    {
                                        return new GzObjectList();
                                    }

                                    gzObjectList.ParentTVItem = webSubsector.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = webSubsector.TVItemModelParentList;
                                    gzObjectList.tvItemFileSiblingList = webSubsector.TVFileModelList;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case TVTypeEnum.Email:
                    {
                        WebRoot webRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        WebAllEmails webAllEmails = ReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webRoot.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webAllEmails.EmailModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemModel.TVItem,
                                                              TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        WebProvince webProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        WebHydrometricSites webHydrometricSites = ReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webProvince.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webProvince.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webHydrometricSites.HydrometricSiteModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemModel.TVItem,
                                                              TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        WebMunicipality webMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webMunicipality.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webMunicipality.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webMunicipality.InfrastructureModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemModel.TVItem,
                                                              TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                    {
                        WebMikeScenarios webMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList.Where(c => c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItemParent.TVItemID).FirstOrDefault();
                        if (mikeScenarioModel == null)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = mikeScenarioModel.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = mikeScenarioModel.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                                          where c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemModel.TVItem,
                                                              TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    {
                        WebMikeScenarios webMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList.Where(c => c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItemParent.TVItemID).FirstOrDefault();

                        if (mikeScenarioModel == null)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = mikeScenarioModel.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = mikeScenarioModel.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                                          where c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionWebTide
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemModel.TVItem,
                                                              TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        WebMikeScenarios webMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webMikeScenarios.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webMikeScenarios.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webMikeScenarios.MikeScenarioModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemModel.TVItem,
                                                              TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        WebMikeScenarios webMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList.Where(c => c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItemParent.TVItemID).FirstOrDefault();
                        if (mikeScenarioModel == null)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = mikeScenarioModel.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = mikeScenarioModel.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in mikeScenarioModel.MikeSourceModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemModel.TVItem,
                                                              TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        WebProvince webProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webProvince.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webProvince.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webProvince.TVItemModelMunicipalityList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        WebMWQMRuns webMWQMRuns = ReadGzFileService.GetUncompressJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        WebSubsector webSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webSubsector.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webMWQMRuns.MWQMRunModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemModel.TVItem,
                                                              TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        WebMWQMSites webMWQMSites = ReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        WebSubsector webSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webSubsector.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webMWQMSites.MWQMSiteModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemModel.TVItem,
                                                              TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        WebPolSourceSites webPolSourceSites = ReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        WebSubsector webSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webSubsector.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webPolSourceSites.PolSourceSiteModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemModel.TVItem,
                                                              TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        WebCountry webCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webCountry.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webCountry.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webCountry.TVItemModelProvinceList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        WebCountry webCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webCountry.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webCountry.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webCountry.RainExceedanceModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemModel.TVItem,
                                                              TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Root:
                    {
                        // this should not happen for now
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        WebArea webArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webArea.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webArea.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webArea.TVItemModelSectorList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        WebSector webSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webSector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webSector.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webSector.TVItemModelSubsectorList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Tel:
                    {
                        WebRoot webRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        WebAllTels webAllTels = ReadGzFileService.GetUncompressJSON<WebAllTels>(WebTypeEnum.WebAllTels, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (CSSPLogService.ErrRes.ErrList.Count > 0)
                        {
                            return new GzObjectList();
                        }

                        gzObjectList.ParentTVItem = webRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = webRoot.TVItemModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in webAllTels.TelModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemModel.TVItem,
                                                              TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                default:
                    break;
            }

            return gzObjectList;
        }
    }
}