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
        private GzObjectList FillDeleteLists(PostTVItemModel postTVItemModel)
        {
            LanguageEnum langEnum = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;

            GzObjectList gzObjectList = new GzObjectList();

            switch (postTVItemModel.TVItem.TVType)
            {
                case TVTypeEnum.Address:
                    {
                        if (ReadGzFileService.webAppLoaded.WebAllAddresses == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllAddresses = ReadGzFileService.GetUncompressJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses, 0).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList;

                        AddressModel addressModel = (from c in ReadGzFileService.webAppLoaded.WebAllAddresses.AddressModelList
                                                     where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                     select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = addressModel.TVItem,
                            TVItemLanguageList = addressModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        if (ReadGzFileService.webAppLoaded.WebArea == null)
                        {
                            ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, postTVItemModel.TVItem.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebArea.TVItemStatMapModelSectorList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebArea.TVItemStatMapModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Sectors), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebArea.TVFileModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebArea.TVItemStatMapModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemStatModelParentList;
                    }
                    break;
                case TVTypeEnum.Classification:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList;

                        TVItemStatMapModel tvItemStatMapModel = (from c in ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModelClassificationList
                                                                 where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                                 select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = tvItemStatMapModel.TVItem,
                            TVItemLanguageList = tvItemStatMapModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebClimateSites == null)
                        {
                            ReadGzFileService.webAppLoaded.WebClimateSites = ReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemStatModelParentList;

                        ClimateSiteModel climateSiteModel = (from c in ReadGzFileService.webAppLoaded.WebClimateSites.ClimateSiteModelList
                                                             where c.ClimateSite.ClimateSiteTVItemID == postTVItemModel.TVItem.TVItemID
                                                             select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = climateSiteModel.TVItemMapModel.TVItem,
                            TVItemLanguageList = climateSiteModel.TVItemMapModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.Contact:
                    {
                        if (ReadGzFileService.webAppLoaded.WebAllContacts == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllContacts = ReadGzFileService.GetUncompressJSON<WebAllContacts>(WebTypeEnum.WebAllContacts, 0).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList;


                        ContactModel contactModel = (from c in ReadGzFileService.webAppLoaded.WebAllContacts.ContactModelList
                                                     where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                     select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = contactModel.TVItem,
                            TVItemLanguageList = contactModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, postTVItemModel.TVItem.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebCountry.TVItemStatMapModelProvinceList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebCountry.TVItemStatMapModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Provinces), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebCountry.TVFileModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebCountry.TVItemStatMapModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatModelParentList;
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
                                        ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemStatModelParentList;

                                    TVFileModel tvFileModel = (from c in ReadGzFileService.webAppLoaded.WebArea.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.Country:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebCountry == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatModelParentList;

                                    TVFileModel tvFileModel = (from c in ReadGzFileService.webAppLoaded.WebCountry.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.Infrastructure:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatModelParentList;

                                    InfrastructureModel infrastructureModel = (from c in ReadGzFileService.webAppLoaded.WebMunicipality.InfrastructureModelList
                                                                               where c.Infrastructure.InfrastructureTVItemID == postTVItemModel.TVItemParent.TVItemID
                                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                                    {
                                        TVItem = infrastructureModel.TVItemMapModel.TVItem,
                                        TVItemLanguageList = infrastructureModel.TVItemMapModel.TVItemLanguageList,
                                    });


                                    TVFileModel tvFileModel = (from c in infrastructureModel.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.MikeScenario:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebMikeScenarios == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemStatModelParentList;

                                    MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                                           where c.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItemParent.TVItemID
                                                                           select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                                    {
                                        TVItem = mikeScenarioModel.TVItemStatMapModel.TVItem,
                                        TVItemLanguageList = mikeScenarioModel.TVItemStatMapModel.TVItemLanguageList,
                                    });

                                    TVFileModel tvFileModel = (from c in mikeScenarioModel.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.Municipality:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatModelParentList;

                                    TVFileModel tvFileModel = (from c in ReadGzFileService.webAppLoaded.WebMunicipality.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.MWQMSite:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebMWQMSites == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMWQMSites = ReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                                    }

                                    if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList;

                                    MWQMSiteModel mwqmSiteModel = (from c in ReadGzFileService.webAppLoaded.WebMWQMSites.MWQMSiteModelList
                                                                   where c.TVItemStatMapModel.TVItem.TVItemID == postTVItemModel.TVItemParent.TVItemID
                                                                   select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                                    {
                                        TVItem = mwqmSiteModel.TVItemStatMapModel.TVItem,
                                        TVItemLanguageList = mwqmSiteModel.TVItemStatMapModel.TVItemLanguageList,
                                    });

                                    TVFileModel tvFileModel = (from c in mwqmSiteModel.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.PolSourceSite:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebPolSourceSites == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebPolSourceSites = ReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                                    }

                                    if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList;

                                    PolSourceSiteModel polSourceSiteModel = (from c in ReadGzFileService.webAppLoaded.WebPolSourceSites.PolSourceSiteModelList
                                                                             where c.TVItemStatMapModel.TVItem.TVItemID == postTVItemModel.TVItemParent.TVItemID
                                                                             select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                                    {
                                        TVItem = polSourceSiteModel.TVItemStatMapModel.TVItem,
                                        TVItemLanguageList = polSourceSiteModel.TVItemStatMapModel.TVItemLanguageList,
                                    });

                                    TVFileModel tvFileModel = (from c in polSourceSiteModel.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.Province:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebProvince == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemStatModelParentList;

                                    TVFileModel tvFileModel = (from c in ReadGzFileService.webAppLoaded.WebProvince.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.Root:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebRoot == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList;


                                    TVFileModel tvFileModel = (from c in ReadGzFileService.webAppLoaded.WebRoot.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.Sector:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebSector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemStatModelParentList;


                                    TVFileModel tvFileModel = (from c in ReadGzFileService.webAppLoaded.WebSector.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                                    {
                                        TVItem = tvFileModel.TVItem,
                                        TVItemLanguageList = tvFileModel.TVItemLanguageList,
                                    });
                                }
                                break;
                            case TVTypeEnum.Subsector:
                                {
                                    if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList;


                                    TVFileModel tvFileModel = (from c in ReadGzFileService.webAppLoaded.WebSubsector.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemStatModel()
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
                        if (ReadGzFileService.webAppLoaded.WebAllEmails == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllEmails = ReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, 0).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList;

                        EmailModel emailModel = (from c in ReadGzFileService.webAppLoaded.WebAllEmails.EmailModelList
                                                 where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                 select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = emailModel.TVItem,
                            TVItemLanguageList = emailModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebHydrometricSites == null)
                        {
                            ReadGzFileService.webAppLoaded.WebHydrometricSites = ReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemStatModelParentList;

                        HydrometricSiteModel hydrometricSiteModel = (from c in ReadGzFileService.webAppLoaded.WebHydrometricSites.HydrometricSiteModelList
                                                                     where c.HydrometricSite.HydrometricSiteTVItemID == postTVItemModel.TVItem.TVItemID
                                                                     select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = hydrometricSiteModel.TVItemMapModel.TVItem,
                            TVItemLanguageList = hydrometricSiteModel.TVItemMapModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatModelParentList;

                        InfrastructureModel infrastructureModel = (from c in ReadGzFileService.webAppLoaded.WebMunicipality.InfrastructureModelList
                                                                   where c.TVItemMapModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                                   select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = infrastructureModel.TVItemMapModel.TVItem,
                            TVItemLanguageList = infrastructureModel.TVItemMapModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenarios == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemStatModelParentList;

                        MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                               where c.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItemParent.TVItemID
                                                               select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = mikeScenarioModel.TVItemStatMapModel.TVItem,
                            TVItemLanguageList = mikeScenarioModel.TVItemStatMapModel.TVItemLanguageList,
                        });

                        MikeBoundaryConditionModel mikeBoundaryConditionModel = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                                                                 where c.TVItemMapModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                                                 select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = mikeBoundaryConditionModel.TVItemMapModel.TVItem,
                            TVItemLanguageList = mikeBoundaryConditionModel.TVItemMapModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenarios == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemStatModelParentList;

                        MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                               where c.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItem.TVItemID
                                                               select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = mikeScenarioModel.TVItemStatMapModel.TVItem,
                            TVItemLanguageList = mikeScenarioModel.TVItemStatMapModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenarios == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemStatModelParentList;

                        MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                               where c.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItemParent.TVItemID
                                                               select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = mikeScenarioModel.TVItemStatMapModel.TVItem,
                            TVItemLanguageList = mikeScenarioModel.TVItemStatMapModel.TVItemLanguageList,
                        });

                        MikeSourceModel mikeSourceModel = (from c in mikeScenarioModel.MikeSourceModelList
                                                           where c.TVItemMapModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                           select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = mikeSourceModel.TVItemMapModel.TVItem,
                            TVItemLanguageList = mikeSourceModel.TVItemMapModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.TVItem.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebMunicipality.MunicipalityContactModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatMapModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MunicipalityContacts), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebMunicipality.TVFileModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatMapModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatModelParentList;
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMWQMRuns == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMWQMRuns = ReadGzFileService.GetUncompressJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList;

                        MWQMRunModel mwqmRunModel = (from c in ReadGzFileService.webAppLoaded.WebMWQMRuns.MWQMRunModelList
                                                     where c.TVItemStatModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                     select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = mwqmRunModel.TVItemStatModel.TVItem,
                            TVItemLanguageList = mwqmRunModel.TVItemStatModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMWQMSites == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMWQMSites = ReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList;

                        MWQMSiteModel mwqmSiteModel = (from c in ReadGzFileService.webAppLoaded.WebMWQMSites.MWQMSiteModelList
                                                       where c.TVItemStatMapModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                       select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = mwqmSiteModel.TVItemStatMapModel.TVItem,
                            TVItemLanguageList = mwqmSiteModel.TVItemStatMapModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebPolSourceSites == null)
                        {
                            ReadGzFileService.webAppLoaded.WebPolSourceSites = ReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList;

                        PolSourceSiteModel polSourceSiteModel = (from c in ReadGzFileService.webAppLoaded.WebPolSourceSites.PolSourceSiteModelList
                                                                 where c.TVItemStatMapModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                                 select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = polSourceSiteModel.TVItemStatMapModel.TVItem,
                            TVItemLanguageList = polSourceSiteModel.TVItemStatMapModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.TVItem.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebProvince.TVItemStatMapAreaList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebProvince.TVItemStatMapModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Areas), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebProvince.TVFileModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebProvince.TVItemStatMapModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatModelParentList;
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatModelParentList;

                        RainExceedanceModel rainExceedanceModel = (from c in ReadGzFileService.webAppLoaded.WebCountry.RainExceedanceModelList
                                                                 where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                                 select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = rainExceedanceModel.TVItem,
                            TVItemLanguageList = rainExceedanceModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.Root:
                    {
                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.TVItem.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebRoot.TVItemStatMapModelCountryList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebRoot.TVItemStatMapModelCountryList[0].TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Areas), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebRoot.TVFileModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebRoot.TVFileModelList[0].TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, postTVItemModel.TVItem.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSector.TVItemStatMapModelSubsectorList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSector.TVItemStatMapModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Subsectors), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSector.TVFileModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSector.TVItemStatMapModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebArea == null)
                        {
                            ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemStatModelParentList;
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.TVItem.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModelClassificationList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Classifications), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector.MWQMAnalysisReportParameterList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MWQMAnalysisReportParameters), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector.TVFileModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatModelParentList;
                    }
                    break;
                case TVTypeEnum.Tel:
                    {
                        if (ReadGzFileService.webAppLoaded.WebAllTels == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllTels = ReadGzFileService.GetUncompressJSON<WebAllTels>(WebTypeEnum.WebAllTels, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.TVItem.TVItemID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList;

                        TelModel telModel = (from c in ReadGzFileService.webAppLoaded.WebAllTels.TelModelList
                                                     where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                     select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemStatModel()
                        {
                            TVItem = telModel.TVItem,
                            TVItemLanguageList = telModel.TVItemLanguageList,
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