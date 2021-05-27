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

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList;

                        AddressModel addressModel = (from c in ReadGzFileService.webAppLoaded.WebAllAddresses.AddressModelList
                                                     where c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                     select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = addressModel.TVItemModel.TVItem,
                            TVItemLanguageList = addressModel.TVItemModel.TVItemLanguageList,
                        });
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        if (ReadGzFileService.webAppLoaded.WebArea == null)
                        {
                            ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, postTVItemModel.TVItem.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebArea.TVItemModelSectorList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Sectors), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebArea.TVFileModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemModelParentList;
                    }
                    break;
                case TVTypeEnum.Classification:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelParentList;

                        TVItemModel tvItemModel = (from c in ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelClassificationList
                                                                 where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                        if (ReadGzFileService.webAppLoaded.WebClimateSites == null)
                        {
                            ReadGzFileService.webAppLoaded.WebClimateSites = ReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemModelParentList;

                        ClimateSiteModel climateSiteModel = (from c in ReadGzFileService.webAppLoaded.WebClimateSites.ClimateSiteModelList
                                                             where c.ClimateSite.ClimateSiteTVItemID == postTVItemModel.TVItem.TVItemID
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
                        if (ReadGzFileService.webAppLoaded.WebAllContacts == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllContacts = ReadGzFileService.GetUncompressJSON<WebAllContacts>(WebTypeEnum.WebAllContacts, 0).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList;


                        ContactModel contactModel = (from c in ReadGzFileService.webAppLoaded.WebAllContacts.ContactModelList
                                                     where c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, postTVItemModel.TVItem.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebCountry.TVItemModelProvinceList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Provinces), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebCountry.TVFileModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemModelParentList;
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

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemModelParentList;

                                    TVFileModel tvFileModel = (from c in ReadGzFileService.webAppLoaded.WebArea.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                                    if (ReadGzFileService.webAppLoaded.WebCountry == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemModelParentList;

                                    TVFileModel tvFileModel = (from c in ReadGzFileService.webAppLoaded.WebCountry.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                                    if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModelParentList;

                                    InfrastructureModel infrastructureModel = (from c in ReadGzFileService.webAppLoaded.WebMunicipality.InfrastructureModelList
                                                                               where c.Infrastructure.InfrastructureTVItemID == postTVItemModel.TVItemParent.TVItemID
                                                                               select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = infrastructureModel.TVItemModel.TVItem,
                                        TVItemLanguageList = infrastructureModel.TVItemModel.TVItemLanguageList,
                                    });


                                    TVFileModel tvFileModel = (from c in infrastructureModel.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                                    if (ReadGzFileService.webAppLoaded.WebMikeScenarios == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemModelParentList;

                                    MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                                           where c.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItemParent.TVItemID
                                                                           select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = mikeScenarioModel.TVItemModel.TVItem,
                                        TVItemLanguageList = mikeScenarioModel.TVItemModel.TVItemLanguageList,
                                    });

                                    TVFileModel tvFileModel = (from c in mikeScenarioModel.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                                    if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModelParentList;

                                    TVFileModel tvFileModel = (from c in ReadGzFileService.webAppLoaded.WebMunicipality.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                                    if (ReadGzFileService.webAppLoaded.WebMWQMSites == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebMWQMSites = ReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                                    }

                                    if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelParentList;

                                    MWQMSiteModel mwqmSiteModel = (from c in ReadGzFileService.webAppLoaded.WebMWQMSites.MWQMSiteModelList
                                                                   where c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItemParent.TVItemID
                                                                   select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = mwqmSiteModel.TVItemModel.TVItem,
                                        TVItemLanguageList = mwqmSiteModel.TVItemModel.TVItemLanguageList,
                                    });

                                    TVFileModel tvFileModel = (from c in mwqmSiteModel.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                                    if (ReadGzFileService.webAppLoaded.WebPolSourceSites == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebPolSourceSites = ReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                                    }

                                    if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelParentList;

                                    PolSourceSiteModel polSourceSiteModel = (from c in ReadGzFileService.webAppLoaded.WebPolSourceSites.PolSourceSiteModelList
                                                                             where c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItemParent.TVItemID
                                                                             select c).FirstOrDefault();

                                    gzObjectList.tvItemParentList.Add(new TVItemModel()
                                    {
                                        TVItem = polSourceSiteModel.TVItemModel.TVItem,
                                        TVItemLanguageList = polSourceSiteModel.TVItemModel.TVItemLanguageList,
                                    });

                                    TVFileModel tvFileModel = (from c in polSourceSiteModel.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                                    if (ReadGzFileService.webAppLoaded.WebProvince == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemModelParentList;

                                    TVFileModel tvFileModel = (from c in ReadGzFileService.webAppLoaded.WebProvince.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                                    if (ReadGzFileService.webAppLoaded.WebRoot == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList;


                                    TVFileModel tvFileModel = (from c in ReadGzFileService.webAppLoaded.WebRoot.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                                    if (ReadGzFileService.webAppLoaded.WebSector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemModelParentList;


                                    TVFileModel tvFileModel = (from c in ReadGzFileService.webAppLoaded.WebSector.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                                    if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                                    {
                                        ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                                    }

                                    gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelParentList;


                                    TVFileModel tvFileModel = (from c in ReadGzFileService.webAppLoaded.WebSubsector.TVFileModelList
                                                               where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                        if (ReadGzFileService.webAppLoaded.WebAllEmails == null)
                        {
                            ReadGzFileService.webAppLoaded.WebAllEmails = ReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, 0).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList;

                        EmailModel emailModel = (from c in ReadGzFileService.webAppLoaded.WebAllEmails.EmailModelList
                                                 where c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                        if (ReadGzFileService.webAppLoaded.WebHydrometricSites == null)
                        {
                            ReadGzFileService.webAppLoaded.WebHydrometricSites = ReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemModelParentList;

                        HydrometricSiteModel hydrometricSiteModel = (from c in ReadGzFileService.webAppLoaded.WebHydrometricSites.HydrometricSiteModelList
                                                                     where c.HydrometricSite.HydrometricSiteTVItemID == postTVItemModel.TVItem.TVItemID
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
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModelParentList;

                        InfrastructureModel infrastructureModel = (from c in ReadGzFileService.webAppLoaded.WebMunicipality.InfrastructureModelList
                                                                   where c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                        if (ReadGzFileService.webAppLoaded.WebMikeScenarios == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemModelParentList;

                        MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                               where c.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItemParent.TVItemID
                                                               select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = mikeScenarioModel.TVItemModel.TVItem,
                            TVItemLanguageList = mikeScenarioModel.TVItemModel.TVItemLanguageList,
                        });

                        MikeBoundaryConditionModel mikeBoundaryConditionModel = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                                                                 where c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                        if (ReadGzFileService.webAppLoaded.WebMikeScenarios == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemModelParentList;

                        MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                               where c.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItem.TVItemID
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
                        if (ReadGzFileService.webAppLoaded.WebMikeScenarios == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenarios = ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)postTVItemModel.TVItemParent.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenarios.TVItemModelParentList;

                        MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                               where c.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItemParent.TVItemID
                                                               select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
                        {
                            TVItem = mikeScenarioModel.TVItemModel.TVItem,
                            TVItemLanguageList = mikeScenarioModel.TVItemModel.TVItemLanguageList,
                        });

                        MikeSourceModel mikeSourceModel = (from c in mikeScenarioModel.MikeSourceModelList
                                                           where c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.TVItem.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebMunicipality.MunicipalityContactModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MunicipalityContacts), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebMunicipality.TVFileModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModelParentList;
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

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelParentList;

                        MWQMRunModel mwqmRunModel = (from c in ReadGzFileService.webAppLoaded.WebMWQMRuns.MWQMRunModelList
                                                     where c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                        if (ReadGzFileService.webAppLoaded.WebMWQMSites == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMWQMSites = ReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelParentList;

                        MWQMSiteModel mwqmSiteModel = (from c in ReadGzFileService.webAppLoaded.WebMWQMSites.MWQMSiteModelList
                                                       where c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                        if (ReadGzFileService.webAppLoaded.WebPolSourceSites == null)
                        {
                            ReadGzFileService.webAppLoaded.WebPolSourceSites = ReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.TVItemParent.TVItemID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelParentList;

                        PolSourceSiteModel polSourceSiteModel = (from c in ReadGzFileService.webAppLoaded.WebPolSourceSites.PolSourceSiteModelList
                                                                 where c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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
                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.TVItem.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebProvince.TVItemModelAreaList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Areas), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebProvince.TVFileModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemModelParentList;
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemModelParentList;

                        RainExceedanceModel rainExceedanceModel = (from c in ReadGzFileService.webAppLoaded.WebCountry.RainExceedanceModelList
                                                                 where c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                                                                 select c).FirstOrDefault();

                        gzObjectList.tvItemParentList.Add(new TVItemModel()
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

                        if (ReadGzFileService.webAppLoaded.WebRoot.TVItemModelCountryList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebRoot.TVItemModelCountryList[0].TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Areas), new[] { "" }));
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

                        if (ReadGzFileService.webAppLoaded.WebSector.TVItemModelSubsectorList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Subsectors), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSector.TVFileModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebArea == null)
                        {
                            ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemModelParentList;
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.TVItem.TVItemID).GetAwaiter().GetResult();
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelClassificationList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Classifications), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector.MWQMAnalysisReportParameterList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MWQMAnalysisReportParameters), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSubsector.TVFileModelList.Count > 0)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" }));
                        }

                        if (ReadGzFileService.webAppLoaded.WebSector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, (int)postTVItemModel.TVItem.ParentID).GetAwaiter().GetResult();
                        }

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelParentList;
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

                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemModelParentList;

                        TelModel telModel = (from c in ReadGzFileService.webAppLoaded.WebAllTels.TelModelList
                                                     where c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
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