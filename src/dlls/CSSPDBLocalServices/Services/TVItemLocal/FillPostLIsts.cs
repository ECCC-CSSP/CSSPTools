﻿/*
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
        private GzObjectList FillPostLists(PostTVItemModel postTVItemModel)
        {
            GzObjectList gzObjectList = new GzObjectList();

            switch (postTVItemModel.TVItem.TVType)
            {
                case TVTypeEnum.Address:
                    {
                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebAllAddresses == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllAddresses = ReadGzFileService.GetUncompressJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebAllAddresses.AddressModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebProvince.TVItemStatMapAreaList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Classification:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModelClassificationList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebClimateSites == null)
                        {
                            ReadGzFileService.webAppLoaded.WebClimateSites = ReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebClimateSites.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebClimateSites.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebClimateSites.ClimateSiteModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemMapModel.TVItem,
                                                              TVItemLanguageList = c.TVItemMapModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Contact:
                    {
                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebAllContacts == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllContacts = ReadGzFileService.GetUncompressJSON<WebAllContacts>(WebTypeEnum.WebAllContacts, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebAllContacts.ContactModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebRoot.TVItemStatMapModelCountryList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.File:
                    {
                        switch (postTVItemModel.TVItemParent.TVType)
                        {
                            case TVTypeEnum.Area:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebArea == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebArea.TVItemStatMapModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemStatModelParentList;
                                    gzObjectList.tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebArea.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Country:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebCountry == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatMapModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatModelParentList;
                                    gzObjectList.tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebCountry.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Infrastructure:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatMapModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatModelParentList;

                                    InfrastructureModel infrastructureModel = (from c in ReadGzFileService.webAppLoaded.WebMunicipality.InfrastructureModelList
                                                                               where c.TVItemMapModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemFileSiblingList = infrastructureModel.TVFileModelList;

                                }
                                break;
                            case TVTypeEnum.MikeScenario:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebMikeScenarios == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemStatMapModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemStatModelParentList;

                                    MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                                           where c.TVItemStatMapModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                                           select c).FirstOrDefault();

                                    gzObjectList.tvItemFileSiblingList = mikeScenarioModel.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Municipality:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatMapModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatModelParentList;
                                    gzObjectList.tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebMunicipality.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.MWQMSite:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                                    }

                                    if (ReadGzFileService.webAppLoaded.WebMWQMSites == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMWQMSites = ReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList;

                                    MWQMSiteModel mwqmSiteModel = (from c in ReadGzFileService.webAppLoaded.WebMWQMSites.MWQMSiteModelList
                                                                   where c.TVItemStatMapModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                                   select c).FirstOrDefault();

                                    gzObjectList.tvItemFileSiblingList = mwqmSiteModel.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.PolSourceSite:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                                    }

                                    if (ReadGzFileService.webAppLoaded.WebPolSourceSites == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebPolSourceSites = ReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList;

                                    PolSourceSiteModel polSourceSiteModel = (from c in ReadGzFileService.webAppLoaded.WebPolSourceSites.PolSourceSiteModelList
                                                                             where c.TVItemStatMapModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                                             select c).FirstOrDefault();

                                    gzObjectList.tvItemFileSiblingList = polSourceSiteModel.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Province:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebProvince == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemStatMapModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemStatModelParentList;
                                    gzObjectList.tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebProvince.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Root:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebRoot == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatMapModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList;
                                    gzObjectList.tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebRoot.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Sector:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebSector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSector.TVItemStatMapModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemStatModelParentList;
                                    gzObjectList.tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebSector.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Subsector:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList;
                                    gzObjectList.tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebSubsector.TVFileModelList;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case TVTypeEnum.Email:
                    {
                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebAllEmails == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllEmails = ReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebAllEmails.EmailModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebHydrometricSites == null)
                        {
                            ReadGzFileService.webAppLoaded.WebHydrometricSites = ReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebHydrometricSites.HydrometricSiteModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemMapModel.TVItem,
                                                              TVItemLanguageList = c.TVItemMapModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebMunicipality.InfrastructureModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemMapModel.TVItem,
                                                              TVItemLanguageList = c.TVItemMapModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenarios == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemStatModelParentList;

                        MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                               where c.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItem.ParentID
                                                               select c).FirstOrDefault();

                        gzObjectList.tvItemSiblingList = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                                          where c.TVItemMapModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemMapModel.TVItem,
                                                              TVItemLanguageList = c.TVItemMapModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenarios == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemStatModelParentList;

                        MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                               where c.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItem.ParentID
                                                               select c).FirstOrDefault();

                        gzObjectList.tvItemSiblingList = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                                          where c.TVItemMapModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionWebTide
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemMapModel.TVItem,
                                                              TVItemLanguageList = c.TVItemMapModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenarios == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemStatMapModel.TVItem,
                                                              TVItemLanguageList = c.TVItemStatMapModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenarios == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemStatModelParentList;

                        MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                               where c.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItem.ParentID
                                                               select c).FirstOrDefault();

                        gzObjectList.tvItemSiblingList = (from c in mikeScenarioModel.MikeSourceModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemMapModel.TVItem,
                                                              TVItemLanguageList = c.TVItemMapModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebProvince.TVItemStatMapMunicipalityList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMWQMRuns == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMWQMRuns = ReadGzFileService.GetUncompressJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebMWQMRuns.MWQMRunModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemStatModel.TVItem,
                                                              TVItemLanguageList = c.TVItemStatModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMWQMSites == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMWQMSites = ReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebMWQMSites.MWQMSiteModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemStatMapModel.TVItem,
                                                              TVItemLanguageList = c.TVItemStatMapModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebPolSourceSites == null)
                        {
                            ReadGzFileService.webAppLoaded.WebPolSourceSites = ReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebPolSourceSites.PolSourceSiteModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItemStatMapModel.TVItem,
                                                              TVItemLanguageList = c.TVItemStatMapModel.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebCountry.TVItemStatMapModelProvinceList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebCountry.RainExceedanceModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
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
                        if (ReadGzFileService.webAppLoaded.WebArea == null)
                        {
                            ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebArea.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebArea.TVItemStatMapModelSectorList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSector.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebSector.TVItemStatMapModelSubsectorList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
                                                          }).ToList();
                    }
                    break;
                case TVTypeEnum.Tel:
                    {
                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebAllTels == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllTels = ReadGzFileService.GetUncompressJSON<WebAllTels>(WebTypeEnum.WebAllTels, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatMapModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList;
                        gzObjectList.tvItemSiblingList = (from c in ReadGzFileService.webAppLoaded.WebAllTels.TelModelList
                                                          select new TVItemModel
                                                          {
                                                              TVItem = c.TVItem,
                                                              TVItemLanguageList = c.TVItemLanguageList,
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