/*
 * Manually edited
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

namespace CSSPDBLocalServices
{
    public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
    {
        private GzObjectList FillDeleteLists(TVItemLocalModel tvItemLocalModel)
        {
            LanguageEnum langEnum = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;

            GzObjectList gzObjectList = new GzObjectList();

            switch (tvItemLocalModel.TVItem.TVType)
            {
                case TVTypeEnum.Address:
                    {
                        WebRoot webRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 1).GetAwaiter().GetResult();

                        gzObjectList.tvItemParentList = webRoot.TVItemModelParentList;
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        WebArea webArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, tvItemLocalModel.TVItem.TVItemID).GetAwaiter().GetResult();

                        if (webArea.TVItemModelSectorList.Count > 0)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                webArea.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Sectors));
                        }

                        if (webArea.TVFileModelList.Count > 0)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                webArea.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files));
                        }

                        gzObjectList.tvItemParentList = webArea.TVItemModelParentList;
                    }
                    break;
                case TVTypeEnum.Classification:
                    {
                        WebSubsector webSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                        gzObjectList.tvItemParentList = webSubsector.TVItemModelParentList;

                        TVItemModel tvItemModel = (from c in webSubsector.TVItemModelClassificationList
                                                   where c.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                   select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = tvItemModel.TVItem,
                            TVItemLanguageList = tvItemModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        WebClimateSites webClimateSites = ReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                        WebProvince webProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                        gzObjectList.tvItemParentList = webProvince.TVItemModelParentList;

                        ClimateSiteModel climateSiteModel = (from c in webClimateSites.ClimateSiteModelList
                                                             where c.ClimateSite.ClimateSiteTVItemID == tvItemLocalModel.TVItem.TVItemID
                                                             select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = climateSiteModel.TVItemModel.TVItem,
                            TVItemLanguageList = climateSiteModel.TVItemModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.Contact:
                    {
                        WebAllContacts webAllContacts = ReadGzFileService.GetUncompressJSON<WebAllContacts>(WebTypeEnum.WebAllContacts, 1).GetAwaiter().GetResult();

                        WebRoot webRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 1).GetAwaiter().GetResult();

                        gzObjectList.tvItemParentList = webRoot.TVItemModelParentList;


                        ContactModel contactModel = (from c in webAllContacts.ContactModelList
                                                     where c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                     select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = contactModel.TVItemModel.TVItem,
                            TVItemLanguageList = contactModel.TVItemModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        WebCountry webCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, tvItemLocalModel.TVItem.TVItemID).GetAwaiter().GetResult();

                        if (webCountry.TVItemModelProvinceList.Count > 0)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                webCountry.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Provinces));
                        }

                        if (webCountry.TVFileModelList.Count > 0)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                webCountry.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files));
                        }

                        gzObjectList.tvItemParentList = webCountry.TVItemModelParentList;
                    }
                    break;
                case TVTypeEnum.File:
                    {
                        switch (tvItemLocalModel.TVItemParent.TVType)
                        {
                            case TVTypeEnum.Area:
                                {
                                    WebArea webArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                                    gzObjectList.tvItemParentList = webArea.TVItemModelParentList;

                                    TVFileModel tvFileModel = (from c in webArea.TVFileModelList
                                                               where c.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.Country:
                                {
                                    WebCountry webCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                                    gzObjectList.tvItemParentList = webCountry.TVItemModelParentList;

                                    TVFileModel tvFileModel = (from c in webCountry.TVFileModelList
                                                               where c.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.Infrastructure:
                                {
                                    WebMunicipality webMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                                    gzObjectList.tvItemParentList = webMunicipality.TVItemModelParentList;

                                    InfrastructureModel infrastructureModel = (from c in webMunicipality.InfrastructureModelList
                                                                               where c.Infrastructure.InfrastructureTVItemID == tvItemLocalModel.TVItemParent.TVItemID
                                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = infrastructureModel.TVItemModel.TVItem,
                                        TVItemLanguageList = infrastructureModel.TVItemModel.TVItemLanguageList,
                                    });


                                    TVFileModel tvFileModel = (from c in infrastructureModel.TVFileModelList
                                                               where c.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.MikeScenario:
                                {
                                    WebMikeScenarios webMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                                    gzObjectList.tvItemParentList = webMikeScenarios.TVItemModelParentList;

                                    MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                                           where c.MikeScenario.MikeScenarioTVItemID == tvItemLocalModel.TVItemParent.TVItemID
                                                                           select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = mikeScenarioModel.TVItemModel.TVItem,
                                        TVItemLanguageList = mikeScenarioModel.TVItemModel.TVItemLanguageList,
                                    });

                                    TVFileModel tvFileModel = (from c in mikeScenarioModel.TVFileModelList
                                                               where c.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.Municipality:
                                {
                                    WebMunicipality webMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                                    gzObjectList.tvItemParentList = webMunicipality.TVItemModelParentList;

                                    TVFileModel tvFileModel = (from c in webMunicipality.TVFileModelList
                                                               where c.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.MWQMSite:
                                {
                                    WebMWQMSites webMWQMSites = ReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                                    WebSubsector webSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                                    gzObjectList.tvItemParentList = webSubsector.TVItemModelParentList;

                                    MWQMSiteModel mwqmSiteModel = (from c in webMWQMSites.MWQMSiteModelList
                                                                   where c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItemParent.TVItemID
                                                                   select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = mwqmSiteModel.TVItemModel.TVItem,
                                        TVItemLanguageList = mwqmSiteModel.TVItemModel.TVItemLanguageList,
                                    });

                                    TVFileModel tvFileModel = (from c in mwqmSiteModel.TVFileModelList
                                                               where c.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.PolSourceSite:
                                {
                                    WebPolSourceSites webPolSourceSites = ReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                                        WebSubsector webSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                                    gzObjectList.tvItemParentList = webSubsector.TVItemModelParentList;

                                    PolSourceSiteModel polSourceSiteModel = (from c in webPolSourceSites.PolSourceSiteModelList
                                                                             where c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItemParent.TVItemID
                                                                             select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = polSourceSiteModel.TVItemModel.TVItem,
                                        TVItemLanguageList = polSourceSiteModel.TVItemModel.TVItemLanguageList,
                                    });

                                    TVFileModel tvFileModel = (from c in polSourceSiteModel.TVFileModelList
                                                               where c.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.Province:
                                {
                                    WebProvince webProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                                    gzObjectList.tvItemParentList = webProvince.TVItemModelParentList;

                                    TVFileModel tvFileModel = (from c in webProvince.TVFileModelList
                                                               where c.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.Root:
                                {
                                    WebRoot webRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                                    gzObjectList.tvItemParentList = webRoot.TVItemModelParentList;


                                    TVFileModel tvFileModel = (from c in webRoot.TVFileModelList
                                                               where c.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.Sector:
                                {
                                    WebSector webSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                                    gzObjectList.tvItemParentList = webSector.TVItemModelParentList;


                                    TVFileModel tvFileModel = (from c in webSector.TVFileModelList
                                                               where c.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.Subsector:
                                {
                                    WebSubsector webSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                                    gzObjectList.tvItemParentList = webSubsector.TVItemModelParentList;


                                    TVFileModel tvFileModel = (from c in webSubsector.TVFileModelList
                                                               where c.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case TVTypeEnum.Email:
                    {
                        WebAllEmails webAllEmails = ReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, 1).GetAwaiter().GetResult();

                        WebRoot webRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 1).GetAwaiter().GetResult();

                        gzObjectList.tvItemParentList = webRoot.TVItemModelParentList;

                        EmailModel emailModel = (from c in webAllEmails.EmailModelList
                                                 where c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                 select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = emailModel.TVItemModel.TVItem,
                            TVItemLanguageList = emailModel.TVItemModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        WebHydrometricSites webHydrometricSites = ReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                        WebProvince webProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                        gzObjectList.tvItemParentList = webProvince.TVItemModelParentList;

                        HydrometricSiteModel hydrometricSiteModel = (from c in webHydrometricSites.HydrometricSiteModelList
                                                                     where c.HydrometricSite.HydrometricSiteTVItemID == tvItemLocalModel.TVItem.TVItemID
                                                                     select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = hydrometricSiteModel.TVItemModel.TVItem,
                            TVItemLanguageList = hydrometricSiteModel.TVItemModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        WebMunicipality webMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                        gzObjectList.tvItemParentList = webMunicipality.TVItemModelParentList;

                        InfrastructureModel infrastructureModel = (from c in webMunicipality.InfrastructureModelList
                                                                   where c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                                   select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = infrastructureModel.TVItemModel.TVItem,
                            TVItemLanguageList = infrastructureModel.TVItemModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    {
                        WebMikeScenarios webMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                        gzObjectList.tvItemParentList = webMikeScenarios.TVItemModelParentList;

                        MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                               where c.MikeScenario.MikeScenarioTVItemID == tvItemLocalModel.TVItemParent.TVItemID
                                                               select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = mikeScenarioModel.TVItemModel.TVItem,
                            TVItemLanguageList = mikeScenarioModel.TVItemModel.TVItemLanguageList,
                        });

                        MikeBoundaryConditionModel mikeBoundaryConditionModel = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                                                                 where c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                                                 select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = mikeBoundaryConditionModel.TVItemModel.TVItem,
                            TVItemLanguageList = mikeBoundaryConditionModel.TVItemModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        WebMikeScenarios webMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                        gzObjectList.tvItemParentList = webMikeScenarios.TVItemModelParentList;

                        MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                               where c.MikeScenario.MikeScenarioTVItemID == tvItemLocalModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = mikeScenarioModel.TVItemModel.TVItem,
                            TVItemLanguageList = mikeScenarioModel.TVItemModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                            WebMikeScenarios webMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemLocalModel.TVItemParent.ParentID).GetAwaiter().GetResult();

                        gzObjectList.tvItemParentList = webMikeScenarios.TVItemModelParentList;

                        MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                               where c.MikeScenario.MikeScenarioTVItemID == tvItemLocalModel.TVItemParent.TVItemID
                                                               select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = mikeScenarioModel.TVItemModel.TVItem,
                            TVItemLanguageList = mikeScenarioModel.TVItemModel.TVItemLanguageList,
                        });

                        MikeSourceModel mikeSourceModel = (from c in mikeScenarioModel.MikeSourceModelList
                                                           where c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                           select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = mikeSourceModel.TVItemModel.TVItem,
                            TVItemLanguageList = mikeSourceModel.TVItemModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        WebMunicipality webMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItemLocalModel.TVItem.TVItemID).GetAwaiter().GetResult();

                        if (webMunicipality.MunicipalityContactModelList.Count > 0)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                webMunicipality.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MunicipalityContacts));
                        }

                        if (webMunicipality.TVFileModelList.Count > 0)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                webMunicipality.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files));
                        }

                        gzObjectList.tvItemParentList = webMunicipality.TVItemModelParentList;
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        WebMWQMRuns webMWQMRuns = ReadGzFileService.GetUncompressJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                        WebSubsector webSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                        gzObjectList.tvItemParentList = webSubsector.TVItemModelParentList;

                        MWQMRunModel mwqmRunModel = (from c in webMWQMRuns.MWQMRunModelList
                                                     where c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                     select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = mwqmRunModel.TVItemModel.TVItem,
                            TVItemLanguageList = mwqmRunModel.TVItemModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        WebMWQMSites webMWQMSites = ReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                        WebSubsector webSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                        gzObjectList.tvItemParentList = webSubsector.TVItemModelParentList;

                        MWQMSiteModel mwqmSiteModel = (from c in webMWQMSites.MWQMSiteModelList
                                                       where c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                       select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = mwqmSiteModel.TVItemModel.TVItem,
                            TVItemLanguageList = mwqmSiteModel.TVItemModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        WebPolSourceSites webPolSourceSites = ReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                        WebSubsector webSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, tvItemLocalModel.TVItemParent.TVItemID).GetAwaiter().GetResult();

                        gzObjectList.tvItemParentList = webSubsector.TVItemModelParentList;

                        PolSourceSiteModel polSourceSiteModel = (from c in webPolSourceSites.PolSourceSiteModelList
                                                                 where c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                                 select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = polSourceSiteModel.TVItemModel.TVItem,
                            TVItemLanguageList = polSourceSiteModel.TVItemModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        WebProvince webProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, tvItemLocalModel.TVItem.TVItemID).GetAwaiter().GetResult();

                        WebCountry webCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (webProvince.TVItemModelAreaList.Count > 0)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                webProvince.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Areas));
                        }

                        if (webProvince.TVFileModelList.Count > 0)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                webProvince.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files));
                        }


                        gzObjectList.tvItemParentList = webCountry.TVItemModelParentList;
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        WebCountry webCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        gzObjectList.tvItemParentList = webCountry.TVItemModelParentList;

                        RainExceedanceModel rainExceedanceModel = (from c in webCountry.RainExceedanceModelList
                                                                   where c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                                   select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = rainExceedanceModel.TVItemModel.TVItem,
                            TVItemLanguageList = rainExceedanceModel.TVItemModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.Root:
                    {
                        WebRoot webRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, tvItemLocalModel.TVItem.TVItemID).GetAwaiter().GetResult();

                        if (webRoot.TVItemModelCountryList.Count > 0)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                webRoot.TVItemModelCountryList[0].TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Areas));
                        }

                        if (webRoot.TVFileModelList.Count > 0)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                webRoot.TVFileModelList[0].TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files));
                        }

                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        WebSector webSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, tvItemLocalModel.TVItem.TVItemID).GetAwaiter().GetResult();

                        WebArea webArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (webSector.TVItemModelSubsectorList.Count > 0)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                webSector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Subsectors));
                        }

                        if (webSector.TVFileModelList.Count > 0)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                webSector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files));
                        }

                        gzObjectList.tvItemParentList = webSector.TVItemModelParentList;
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        WebSubsector webSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, tvItemLocalModel.TVItem.TVItemID).GetAwaiter().GetResult();

                        WebSector webSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        if (webSubsector.TVItemModelClassificationList.Count > 0)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                webSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Classifications));
                        }

                        if (webSubsector.MWQMAnalysisReportParameterList.Count > 0)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                webSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MWQMAnalysisReportParameters));
                        }

                        if (webSubsector.TVFileModelList.Count > 0)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                webSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files));
                        }

                        gzObjectList.tvItemParentList = webSubsector.TVItemModelParentList;
                    }
                    break;
                case TVTypeEnum.Tel:
                    {
                        WebAllTels webAllTels = ReadGzFileService.GetUncompressJSON<WebAllTels>(WebTypeEnum.WebAllTels, (int)tvItemLocalModel.TVItem.ParentID).GetAwaiter().GetResult();

                        WebRoot webRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, tvItemLocalModel.TVItem.TVItemID).GetAwaiter().GetResult();

                        gzObjectList.tvItemParentList = webRoot.TVItemModelParentList;

                        TelModel telModel = (from c in webAllTels.TelModelList
                                             where c.TVItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                             select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = telModel.TVItemModel.TVItem,
                            TVItemLanguageList = telModel.TVItemModel.TVItemLanguageList,
                        });
                    }
                    break;
                default:
                    break;
            }

            return gzObjectList;
        }
    }
}