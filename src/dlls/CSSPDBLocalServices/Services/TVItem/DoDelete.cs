/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CSSPDBLocalServices
{

    public partial class TVItemService : ControllerBase, ITVItemService
    {
        private IEnumerable<ValidationResult> DoDelete(ValidationContext validationContext)
        {
            LanguageEnum langEnum = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;

            string retStr = "";
            string TVItemErrorMessage = "";
            bool HasError = false;
            TVItem ParentTVItem = new TVItem();
            List<WebBase> tvItemParentList = new List<WebBase>();
            List<WebBase> tvItemList = new List<WebBase>();
            List<WebBase> tvItemFileList = new List<WebBase>();
            DeleteTVItemModel deleteTVItemModel = validationContext.ObjectInstance as DeleteTVItemModel;

            if (deleteTVItemModel.TVItemID == 0)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), new[] { "TVItemID" });
                HasError = true;
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)deleteTVItemModel.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), new[] { "TVType" });
            }

            if (deleteTVItemModel.ParentID == 0)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ParentID"), new[] { "ParentID" });
                HasError = true;
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)deleteTVItemModel.ParentTVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ParentTVType"), new[] { "ParentTVType" });
            }

            if (deleteTVItemModel.TVType == TVTypeEnum.File)
            {
                if (deleteTVItemModel.ParentTVType == TVTypeEnum.Infrastructure)
                {
                    if (deleteTVItemModel.GrandParentID == null || deleteTVItemModel.GrandParentID == 0)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" });
                        HasError = true;
                    }

                    if (deleteTVItemModel.GrandParentTVType != TVTypeEnum.Municipality)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Municipality.ToString()), new[] { "GrandParentTVType" });
                        HasError = true;
                    }
                }

                if (deleteTVItemModel.ParentTVType == TVTypeEnum.MWQMSite)
                {
                    if (deleteTVItemModel.GrandParentID == null || deleteTVItemModel.GrandParentID == 0)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" });
                        HasError = true;
                    }

                    if (deleteTVItemModel.GrandParentTVType != TVTypeEnum.Subsector)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Subsector.ToString()), new[] { "GrandParentTVType" });
                        HasError = true;
                    }
                }
                else if (deleteTVItemModel.ParentTVType == TVTypeEnum.PolSourceSite)
                {
                    if (deleteTVItemModel.GrandParentID == null || deleteTVItemModel.GrandParentID == 0)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" });
                        HasError = true;
                    }

                    if (deleteTVItemModel.GrandParentTVType != TVTypeEnum.Subsector)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Subsector.ToString()), new[] { "GrandParentTVType" });
                        HasError = true;
                    }
                }
                else if (deleteTVItemModel.ParentTVType == TVTypeEnum.TideSite)
                {
                    if (deleteTVItemModel.GrandParentID == null || deleteTVItemModel.GrandParentID == 0)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" });
                        HasError = true;
                    }

                    if (deleteTVItemModel.GrandParentTVType != TVTypeEnum.Subsector)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Subsector.ToString()), new[] { "GrandParentTVType" });
                        HasError = true;
                    }
                }
                else
                {
                    if (deleteTVItemModel.GrandParentID == null)
                    {
                        deleteTVItemModel.GrandParentID = 1;
                    }
                    if (deleteTVItemModel.GrandParentTVType == null)
                    {
                        deleteTVItemModel.GrandParentTVType = TVTypeEnum.Root;
                    }
                }
            }
            else
            {
                if (deleteTVItemModel.GrandParentID == null)
                {
                    deleteTVItemModel.GrandParentID = 1;
                }
                if (deleteTVItemModel.GrandParentTVType == null)
                {
                    deleteTVItemModel.GrandParentTVType = TVTypeEnum.Root;
                }
            }

            List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Root,
                        TVTypeEnum.Address,
                        TVTypeEnum.Area,
                        TVTypeEnum.Classification,
                        TVTypeEnum.ClimateSite,
                        TVTypeEnum.Contact,
                        TVTypeEnum.Country,
                        TVTypeEnum.Email,
                        TVTypeEnum.File,
                        TVTypeEnum.HydrometricSite,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeBoundaryConditionMesh,
                        TVTypeEnum.MikeBoundaryConditionWebTide,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.MikeSource,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.MWQMRun,
                        TVTypeEnum.MWQMSite,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.Province,
                        TVTypeEnum.RainExceedance,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.Tel,
                    };

            if (!AllowableTVTypes.Contains(deleteTVItemModel.TVType))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVType",
                    "Root,Address,Area,Classification,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure," +
                    "MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite," +
                    "PolSourceSite,Province,RainExceedance,Sector,Subsector,Tel"), new[] { "TVType" });
                HasError = true;
            }

            if (!AllowableTVTypes.Contains(deleteTVItemModel.ParentTVType))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ParentTVType",
                    "Root,Address,Area,Classification,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure," +
                    "MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite," +
                    "PolSourceSite,Province,RainExceedance,Sector,Subsector,Tel"), new[] { "ParentTVType" });
                HasError = true;
            }

            if (!HasError)
            {
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

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebAllAddresses.TVItemAllAddressList;
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
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Sectors), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebArea.TVItemFileList.Count > 0)
                            {
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebProvince == null)
                            {
                                ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebProvince.TVItemAreaList;
                        }
                        break;
                    case TVTypeEnum.Classification:
                        {
                            if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                            {
                                ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemClassificationList;
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

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebClimateSite.TVItemClimateSiteList;
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

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebAllContacts.TVItemAllContactList;
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
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Provinces), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebCountry.TVItemFileList.Count > 0)
                            {
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebRoot == null)
                            {
                                ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList;
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

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemParentList;
                                        tvItemList = ReadGzFileService.webAppLoaded.WebArea.TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.Country:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                                        tvItemList = ReadGzFileService.webAppLoaded.WebCountry.TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.Infrastructure:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)deleteTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                                        tvItemFileList = ReadGzFileService.webAppLoaded.WebMunicipality.InfrastructureModelList.Where(c => c.TVItemModel.TVItem.TVItemID == deleteTVItemModel.TVItemID).First().TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.MikeScenario:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                                        tvItemList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.Municipality:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                                        tvItemList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.MWQMSite:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebMWQMSite == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebMWQMSite = ReadGzFileService.GetUncompressJSON<WebMWQMSite>(WebTypeEnum.WebMWQMSite, (int)deleteTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebMWQMSite.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebMWQMSite.TVItemParentList;
                                        tvItemFileList = ReadGzFileService.webAppLoaded.WebMWQMSite.MWQMSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == deleteTVItemModel.TVItemID).First().TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.PolSourceSite:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebPolSourceSite == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebPolSourceSite = ReadGzFileService.GetUncompressJSON<WebPolSourceSite>(WebTypeEnum.WebPolSourceSite, (int)deleteTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebPolSourceSite.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebPolSourceSite.TVItemParentList;
                                        tvItemFileList = ReadGzFileService.webAppLoaded.WebPolSourceSite.PolSourceSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == deleteTVItemModel.TVItemID).First().TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.Province:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                                        tvItemList = ReadGzFileService.webAppLoaded.WebProvince.TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.Root:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                                        tvItemList = ReadGzFileService.webAppLoaded.WebRoot.TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.Sector:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebSector == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemParentList;
                                        tvItemList = ReadGzFileService.webAppLoaded.WebSector.TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.Subsector:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                                        tvItemList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemFileList;
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

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebAllEmails.TVItemAllEmailList;
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

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebHydrometricSite.TVItemHydrometricSiteList;
                        }
                        break;
                    case TVTypeEnum.Infrastructure:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemInfrastructureList;
                        }
                        break;
                    case TVTypeEnum.MikeBoundaryConditionMesh:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeBoundaryConditionMeshList;
                        }
                        break;
                    case TVTypeEnum.MikeBoundaryConditionWebTide:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeBoundaryConditionWebTideList;
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

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemMikeScenarioList;
                        }
                        break;
                    case TVTypeEnum.MikeSource:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeSourceList;
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
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Infrastructures), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebMunicipality.MIKEScenarioModelList.Count > 0)
                            {
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MIKEScenarios), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebMunicipality.MunicipalityContactModelList.Count > 0)
                            {
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MunicipalityContacts), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebMunicipality.TVItemFileList.Count > 0)
                            {
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebMunicipalities == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMunicipalities = ReadGzFileService.GetUncompressJSON<WebMunicipalities>(WebTypeEnum.WebMunicipalities, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            if (ReadGzFileService.webAppLoaded.WebProvince == null)
                            {
                                ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebMunicipalities.TVItemMunicipalityList;
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

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMRunList;
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

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMWQMSite.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMSiteList;
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

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebPolSourceSite.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemPolSourceSiteList;
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
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Areas), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebProvince.TVItemFileList.Count > 0)
                            {
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebCountry == null)
                            {
                                ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebCountry.TVItemProvinceList;
                        }
                        break;
                    case TVTypeEnum.RainExceedance:
                        {
                            if (ReadGzFileService.webAppLoaded.WebCountry == null)
                            {
                                ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebCountry.TVItemRainExceedanceList;
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
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Subsectors), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebSector.TVItemFileList.Count > 0)
                            {
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebArea == null)
                            {
                                ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebArea.TVItemSectorList;
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
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.LabSheets), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMSiteList.Count > 0)
                            {
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MWQMSites), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMRunList.Count > 0)
                            {
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MWQMRuns), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebSubsector.TVItemPolSourceSiteList.Count > 0)
                            {
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.PolSourceSites), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebSubsector.TVItemClassificationList.Count > 0)
                            {
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Classifications), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebSubsector.MWQMAnalysisReportParameterList.Count > 0)
                            {
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.MWQMAnalysisReportParameters), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebSubsector.TVItemFileList.Count > 0)
                            {
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CantRemove_BecauseThereAre_Underneath,
                                    ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItemLanguageList[(int)langEnum].TVText, CSSPCultureServicesRes.Files), new[] { "" });

                                HasError = true;
                            }

                            if (ReadGzFileService.webAppLoaded.WebSector == null)
                            {
                                ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, deleteTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebSector.TVItemSubsectorList;
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

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                            tvItemList = ReadGzFileService.webAppLoaded.WebAllTels.TVItemAllTelList;
                        }
                        break;
                    default:
                        break;
                }

                #region Writting to DBLocal

                if (!HasError)
                {
                    // filling all parent TVItem in the DBLocal
                    foreach (WebBase webBaseToAdd in tvItemParentList.OrderBy(c => c.TVItemModel.TVItem.TVLevel))
                    {
                        if (!(from c in dbLocal.TVItems
                              where c.TVItemID == webBaseToAdd.TVItemModel.TVItem.TVItemID
                              select c).Any())
                        {
                            try
                            {
                                dbLocal.TVItems.Add(webBaseToAdd.TVItemModel.TVItem);
                                dbLocal.SaveChanges();
                                AppendToRecreate(webBaseToAdd.TVItemModel.TVItem, 1982, deleteTVItemModel.ParentTVType, (int)deleteTVItemModel.GrandParentID);
                            }
                            catch (Exception ex)
                            {
                                TVItemErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message);
                            }

                            if (!string.IsNullOrWhiteSpace(TVItemErrorMessage))
                            {
                                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", TVItemErrorMessage), new[] { "TVItem" });
                                HasError = true;
                            }

                            foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                            {
                                if (!(from c in dbLocal.TVItemLanguages
                                      where c.TVItemID == webBaseToAdd.TVItemModel.TVItem.TVItemID
                                      && c.Language == lang
                                      select c).Any())
                                {

                                    string TVItemLanguageErrorMessage = "";
                                    try
                                    {
                                        dbLocal.TVItemLanguages.Add(webBaseToAdd.TVItemModel.TVItemLanguageList[(int)lang]);
                                        dbLocal.SaveChanges();
                                    }
                                    catch (Exception ex)
                                    {
                                        TVItemLanguageErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, $"TVItemLanguage_{ lang }", ex.Message);
                                    }

                                    if (!string.IsNullOrWhiteSpace(TVItemLanguageErrorMessage))
                                    {
                                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", TVItemLanguageErrorMessage), new[] { "TVItem" });
                                        HasError = true;
                                    }
                                }
                            }
                        }
                    }

                    TVItem tvItemToMarkDeleted = (from c in dbLocal.TVItems
                                                  where c.TVItemID == deleteTVItemModel.TVItemID
                                                  select c).FirstOrDefault();

                    if (tvItemToMarkDeleted != null)
                    {
                        tvItemToMarkDeleted.DBCommand = DBCommandEnum.Deleted;
                        tvItemToMarkDeleted.LastUpdateDate_UTC = DateTime.UtcNow;
                        tvItemToMarkDeleted.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                        try
                        {
                            dbLocal.SaveChanges();
                            AppendToRecreate(tvItemToMarkDeleted, 1982, deleteTVItemModel.ParentTVType, (int)deleteTVItemModel.GrandParentID);
                        }
                        catch (Exception ex)
                        {
                            TVItemErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message);
                        }

                        if (!string.IsNullOrWhiteSpace(TVItemErrorMessage))
                        {
                            yield return new ValidationResult(TVItemErrorMessage, new[] { "TVItem" });
                            HasError = true;
                        }

                        foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                        {
                            List<TVItemLanguage> TVItemLanguageToDeleteList = (from c in dbLocal.TVItemLanguages
                                                                               where c.TVItemID == deleteTVItemModel.TVItemID
                                                                               select c).ToList();

                            foreach (TVItemLanguage tvItemLanguage in TVItemLanguageToDeleteList)
                            {
                                tvItemLanguage.DBCommand = DBCommandEnum.Deleted;
                                tvItemLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                                tvItemLanguage.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                                TVItemErrorMessage = "";
                                try
                                {
                                    dbLocal.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    TVItemErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "TVItemLanguage", ex.Message);
                                }

                                if (!string.IsNullOrWhiteSpace(TVItemErrorMessage))
                                {
                                    yield return new ValidationResult(TVItemErrorMessage, new[] { "TVItemLanguage" });
                                    HasError = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        WebBase WebBaseToChange = new WebBase();
                        foreach (WebBase webBase in tvItemList)
                        {
                            if (webBase.TVItemModel.TVItem.TVItemID == deleteTVItemModel.TVItemID)
                            {
                                WebBaseToChange = webBase;
                                break;
                            }
                        }

                        TVItem tvItem = (from c in dbLocal.TVItems
                                         where c.TVItemID == WebBaseToChange.TVItemModel.TVItem.TVItemID
                                         select c).FirstOrDefault();

                        if (tvItem == null)
                        {
                            tvItem = WebBaseToChange.TVItemModel.TVItem;
                            tvItem.DBCommand = DBCommandEnum.Deleted;

                            dbLocal.TVItems.Add(tvItem);
                            AppendToRecreate(tvItem, 1982, deleteTVItemModel.ParentTVType, (int)deleteTVItemModel.GrandParentID);
                        }
                        else
                        {
                            tvItem.IsActive = WebBaseToChange.TVItemModel.TVItem.IsActive;
                            tvItem.DBCommand = DBCommandEnum.Deleted;
                        }

                        try
                        {
                            dbLocal.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            TVItemErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message);
                        }

                        if (!string.IsNullOrWhiteSpace(TVItemErrorMessage))
                        {
                            yield return new ValidationResult(TVItemErrorMessage, new[] { "TVItem" });
                            HasError = true;
                        }

                        foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                        {
                            TVItemLanguage tvItemLanguage = (from c in dbLocal.TVItemLanguages
                                                             where c.TVItemLanguageID == WebBaseToChange.TVItemModel.TVItemLanguageList[(int)lang].TVItemLanguageID
                                                             select c).FirstOrDefault();

                            if (tvItemLanguage == null)
                            {
                                tvItemLanguage = WebBaseToChange.TVItemModel.TVItemLanguageList[(int)lang];
                                tvItemLanguage.DBCommand = DBCommandEnum.Deleted;
                                tvItemLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                                tvItemLanguage.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                                dbLocal.TVItemLanguages.Add(tvItemLanguage);
                                AppendToRecreate(tvItem, 1982, deleteTVItemModel.ParentTVType, (int)deleteTVItemModel.GrandParentID);
                            }
                            else
                            {
                                tvItemLanguage.DBCommand = DBCommandEnum.Deleted;
                                tvItemLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                                tvItemLanguage.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
                                AppendToRecreate(tvItem, 1982, deleteTVItemModel.ParentTVType, (int)deleteTVItemModel.GrandParentID);
                            }

                            TVItemErrorMessage = "";
                            try
                            {
                                dbLocal.SaveChanges();
                                AppendToRecreate(tvItem, 1982, deleteTVItemModel.ParentTVType, (int)deleteTVItemModel.GrandParentID);
                            }
                            catch (Exception ex)
                            {
                                TVItemErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message);
                            }

                            if (!string.IsNullOrWhiteSpace(TVItemErrorMessage))
                            {
                                yield return new ValidationResult(TVItemErrorMessage, new[] { "TVItemLanguage" });
                                HasError = true;
                            }

                        }
                    }

                    foreach (ToRecreate toRecreate in ToRecreateList)
                    {
                        CreateGzFileLocalService.CreateGzFileLocal(toRecreate.WebType, toRecreate.TVItemID, toRecreate.WebTypeYear);
                    }
                }
            }
            #endregion Writting to DBLocal
        }
    }
}