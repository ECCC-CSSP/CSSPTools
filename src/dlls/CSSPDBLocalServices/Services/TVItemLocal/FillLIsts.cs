/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CSSPDBLocalServices
{
    public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
    {
        private GzObjectList FillPostLists(PostTVItemModel postTVItemModel)
        {
            GzObjectList gzObjectList = new GzObjectList();

            switch (postTVItemModel.TVType)
            {
                case TVTypeEnum.Address:
                    {
                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebAllAddresses == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllAddresses = ReadGzFileService.GetUncompressJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebAllAddresses.TVItemAllAddressList;
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebProvince.TVItemAreaList;
                    }
                    break;
                case TVTypeEnum.Classification:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemClassificationList;
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            ReadGzFileService.webAppLoaded.WebClimateSite = ReadGzFileService.GetUncompressJSON<WebClimateSite>(WebTypeEnum.WebClimateSite, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebClimateSite.TVItemClimateSiteList;
                    }
                    break;
                case TVTypeEnum.Contact:
                    {
                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebAllContacts == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllContacts = ReadGzFileService.GetUncompressJSON<WebAllContacts>(WebTypeEnum.WebAllContacts, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebAllContacts.TVItemAllContactList;
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList;
                    }
                    break;
                case TVTypeEnum.File:
                    {
                        switch (postTVItemModel.ParentTVType)
                        {
                            case TVTypeEnum.Area:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebArea == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemParentList;
                                    gzObjectList.tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebArea.TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.Country:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebCountry == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                                    gzObjectList.tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebCountry.TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.Infrastructure:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                                    WebBase TVItemModelInfrastructure = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemInfrastructureList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID).FirstOrDefault();
                                    gzObjectList.tvItemParentList.Add(TVItemModelInfrastructure);
                                    foreach (InfrastructureModel infrastructureModel in ReadGzFileService.webAppLoaded.WebMunicipality.InfrastructureModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID))
                                    {
                                        gzObjectList.tvItemFileSiblingList.AddRange(infrastructureModel.TVItemFileList);
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemInfrastructureList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID).FirstOrDefault().TVItemModel.TVItem;
                                }
                                break;
                            case TVTypeEnum.MikeScenario:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                                    gzObjectList.tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.Municipality:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                                    gzObjectList.tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.MWQMSite:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebMWQMSite == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMWQMSite = ReadGzFileService.GetUncompressJSON<WebMWQMSite>(WebTypeEnum.WebMWQMSite, (int)postTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMWQMSite.TVItemParentList;
                                    WebBase TVItemModelMWQMSite = ReadGzFileService.webAppLoaded.WebMWQMSite.MWQMSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID).FirstOrDefault();
                                    gzObjectList.tvItemParentList.Add(TVItemModelMWQMSite);
                                    foreach (MWQMSiteModel mwqmSiteModel in ReadGzFileService.webAppLoaded.WebMWQMSite.MWQMSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID))
                                    {
                                        gzObjectList.tvItemFileSiblingList.AddRange(mwqmSiteModel.TVItemFileList);
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMWQMSite.MWQMSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID).FirstOrDefault().TVItemModel.TVItem;
                                }
                                break;
                            case TVTypeEnum.PolSourceSite:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebPolSourceSite == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebPolSourceSite = ReadGzFileService.GetUncompressJSON<WebPolSourceSite>(WebTypeEnum.WebPolSourceSite, (int)postTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebPolSourceSite.TVItemParentList;
                                    WebBase TVItemModelPolSourceSite = ReadGzFileService.webAppLoaded.WebPolSourceSite.PolSourceSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID).FirstOrDefault();
                                    gzObjectList.tvItemParentList.Add(TVItemModelPolSourceSite);
                                    foreach (PolSourceSiteModel polSourceSiteModel in ReadGzFileService.webAppLoaded.WebPolSourceSite.PolSourceSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID))
                                    {
                                        gzObjectList.tvItemFileSiblingList.AddRange(polSourceSiteModel.TVItemFileList);
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebPolSourceSite.PolSourceSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID).FirstOrDefault().TVItemModel.TVItem;
                                }
                                break;
                            case TVTypeEnum.Province:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebProvince == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                                    gzObjectList.tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebProvince.TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.Root:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebRoot == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                                    gzObjectList.tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebRoot.TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.Sector:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebSector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemParentList;
                                    gzObjectList.tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebSector.TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.Subsector:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                                    gzObjectList.tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemFileList;
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
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebAllEmails == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllEmails = ReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebAllEmails.TVItemAllEmailList;
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            ReadGzFileService.webAppLoaded.WebHydrometricSite = ReadGzFileService.GetUncompressJSON<WebHydrometricSite>(WebTypeEnum.WebHydrometricSite, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebHydrometricSite.TVItemHydrometricSiteList;
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemInfrastructureList;
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeBoundaryConditionMeshList;
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeBoundaryConditionWebTideList;
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemMikeScenarioList;
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeSourceList;
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            ReadGzFileService.webAppLoaded.WebMunicipalities = ReadGzFileService.GetUncompressJSON<WebMunicipalities>(WebTypeEnum.WebMunicipalities, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebMunicipalities.TVItemMunicipalityList;
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMRunList;
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMSiteList;
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemPolSourceSiteList;
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebCountry.TVItemProvinceList;
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebCountry.TVItemRainExceedanceList;
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
                            ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebArea.TVItemSectorList;
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebSector.TVItemSubsectorList;
                    }
                    break;
                case TVTypeEnum.Tel:
                    {
                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebAllTels == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllTels = ReadGzFileService.GetUncompressJSON<WebAllTels>(WebTypeEnum.WebAllTels, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                        gzObjectList.tvItemSiblingList = ReadGzFileService.webAppLoaded.WebAllTels.TVItemAllTelList;
                    }
                    break;
                default:
                    break;
            }

            return gzObjectList;
        }

        private GzObjectList FillDeleteLists(DeleteTVItemModel deleteTVItemModel)
        {
            LanguageEnum langEnum = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;

            GzObjectList gzObjectList = new GzObjectList();

            switch (deleteTVItemModel.TVType)
            {
                case TVTypeEnum.Address:
                    {
                        if (ReadGzFileService.webAppLoaded.WebAllAddresses == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllAddresses = ReadGzFileService.GetUncompressJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses, deleteTVItemModel.TVItemID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, deleteTVItemModel.TVItemID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebAllAddresses.TVItemAllAddressList;
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        if (ReadGzFileService.webAppLoaded.WebArea == null)
                        {
                            ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, deleteTVItemModel.TVItemID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebArea.TVItemSectorList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Sectors), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebArea.TVItemFileList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebProvince.TVItemAreaList;
                    }
                    break;
                case TVTypeEnum.Classification:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemClassificationList;
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebClimateSite == null)
                        {
                            ReadGzFileService.webAppLoaded.WebClimateSite = ReadGzFileService.GetUncompressJSON<WebClimateSite>(WebTypeEnum.WebClimateSite, deleteTVItemModel.TVItemID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebClimateSite.TVItemClimateSiteList;
                    }
                    break;
                case TVTypeEnum.Contact:
                    {
                        if (ReadGzFileService.webAppLoaded.WebAllContacts == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllContacts = ReadGzFileService.GetUncompressJSON<WebAllContacts>(WebTypeEnum.WebAllContacts, deleteTVItemModel.TVItemID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, deleteTVItemModel.TVItemID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebAllContacts.TVItemAllContactList;
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, deleteTVItemModel.TVItemID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebCountry.TVItemProvinceList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Provinces), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebCountry.TVItemFileList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList;
                    }
                    break;
                case TVTypeEnum.File:
                    {
                        switch (deleteTVItemModel.ParentTVType)
                        {
                            case TVTypeEnum.Area:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebArea == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemParentList;
                                    gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebArea.TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.Country:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebCountry == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                                    gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebCountry.TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.Infrastructure:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)deleteTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                                    gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebMunicipality.InfrastructureModelList.Where(c => c.TVItemModel.TVItem.TVItemID == deleteTVItemModel.TVItemID).First().TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.MikeScenario:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                                    gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.Municipality:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                                    gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.MWQMSite:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebMWQMSite == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMWQMSite = ReadGzFileService.GetUncompressJSON<WebMWQMSite>(WebTypeEnum.WebMWQMSite, (int)deleteTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMWQMSite.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMWQMSite.TVItemParentList;
                                    gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebMWQMSite.MWQMSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == deleteTVItemModel.TVItemID).First().TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.PolSourceSite:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebPolSourceSite == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebPolSourceSite = ReadGzFileService.GetUncompressJSON<WebPolSourceSite>(WebTypeEnum.WebPolSourceSite, (int)deleteTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebPolSourceSite.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebPolSourceSite.TVItemParentList;
                                    gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebPolSourceSite.PolSourceSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == deleteTVItemModel.TVItemID).First().TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.Province:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebProvince == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                                    gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebProvince.TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.Root:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebRoot == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                                    gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebRoot.TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.Sector:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebSector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemParentList;
                                    gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebSector.TVItemFileList;
                                }
                                break;
                            case TVTypeEnum.Subsector:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                                    gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemFileList;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case TVTypeEnum.Email:
                    {
                        if (ReadGzFileService.webAppLoaded.WebAllEmails == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllEmails = ReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, deleteTVItemModel.TVItemID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, deleteTVItemModel.TVItemID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebAllEmails.TVItemAllEmailList;
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebHydrometricSite == null)
                        {
                            ReadGzFileService.webAppLoaded.WebHydrometricSite = ReadGzFileService.GetUncompressJSON<WebHydrometricSite>(WebTypeEnum.WebHydrometricSite, deleteTVItemModel.TVItemID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebHydrometricSite.TVItemHydrometricSiteList;
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemInfrastructureList;
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeBoundaryConditionMeshList;
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeBoundaryConditionWebTideList;
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, deleteTVItemModel.TVItemID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemMikeScenarioList;
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeSourceList;
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, deleteTVItemModel.TVItemID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebMunicipality.TVItemInfrastructureList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Infrastructures), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebMunicipality.MIKEScenarioModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MIKEScenarios), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebMunicipality.MunicipalityContactModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MunicipalityContacts), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebMunicipality.TVItemFileList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebMunicipalities == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipalities = ReadGzFileService.GetUncompressJSON<WebMunicipalities>(WebTypeEnum.WebMunicipalities, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebMunicipalities.TVItemMunicipalityList;
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMWQMRun == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMWQMRun = ReadGzFileService.GetUncompressJSON<WebMWQMRun>(WebTypeEnum.WebMWQMRun, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMRunList;
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMWQMSite == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMWQMSite = ReadGzFileService.GetUncompressJSON<WebMWQMSite>(WebTypeEnum.WebMWQMSite, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMWQMSite.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMSiteList;
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebPolSourceSite == null)
                        {
                            ReadGzFileService.webAppLoaded.WebPolSourceSite = ReadGzFileService.GetUncompressJSON<WebPolSourceSite>(WebTypeEnum.WebPolSourceSite, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebPolSourceSite.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemPolSourceSiteList;
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebProvince.TVItemAreaList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Areas), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebProvince.TVItemFileList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebCountry.TVItemProvinceList;
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebCountry.TVItemRainExceedanceList;
                    }
                    break;
                case TVTypeEnum.Root:
                    {
                        // this should not happen for now
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, deleteTVItemModel.TVItemID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSector.TVItemSubsectorList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Subsectors), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSector.TVItemFileList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebArea == null)
                        {
                            ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebArea.TVItemSectorList;
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, deleteTVItemModel.TVItemID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector.LabSheetModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.LabSheets), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMSiteList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MWQMSites), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMRunList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MWQMRuns), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector.TVItemPolSourceSiteList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.PolSourceSites), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector.TVItemClassificationList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Classifications), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector.MWQMAnalysisReportParameterList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MWQMAnalysisReportParameters), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector.TVItemFileList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebSector.TVItemSubsectorList;
                    }
                    break;
                case TVTypeEnum.Tel:
                    {
                        if (ReadGzFileService.webAppLoaded.WebAllTels == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllTels = ReadGzFileService.GetUncompressJSON<WebAllTels>(WebTypeEnum.WebAllTels, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, deleteTVItemModel.TVItemID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                        gzObjectList.tvItemList = ReadGzFileService.webAppLoaded.WebAllTels.TVItemAllTelList;
                    }
                    break;
                default:
                    break;
            }

            return gzObjectList;
        }
    }
}