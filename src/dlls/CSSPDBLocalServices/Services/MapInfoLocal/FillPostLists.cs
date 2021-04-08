/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CSSPDBLocalServices
{

    public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
    {
        private GzObjectList FillPostLists(PostMapInfoModel postMapInfoModel)
        {
            LanguageEnum langEnum = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;

            GzObjectList gzObjectList = new GzObjectList();

            switch (postMapInfoModel.MapInfo.TVType)
            {
                case TVTypeEnum.Address:
                    {
                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.Approved:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                        {
                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.Classification:
                    {
                        // there are no official MapInfo item with TVType Classification (See. Approved, Restricted, Prohibited, ConditionallyApproved, ConditionallyRestricted)
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebClimateSite == null)
                        {
                            ReadGzFileService.webAppLoaded.WebClimateSite = ReadGzFileService.GetUncompressJSON<WebClimateSite>(WebTypeEnum.WebClimateSite, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebClimateSite.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebClimateSite.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.ConditionallyApproved:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.ConditionallyRestricted:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.File:
                    {
                        // nothing for now
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebHydrometricSite == null)
                        {
                            ReadGzFileService.webAppLoaded.WebHydrometricSite = ReadGzFileService.GetUncompressJSON<WebHydrometricSite>(WebTypeEnum.WebHydrometricSite, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebHydrometricSite.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebHydrometricSite.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        // there are no official MapInfo item with TVType Infrastructure (See. WasteWaterTreatmentPlant, LiftStation, LineOverflow, Outfall, OtherInfrastructure, SeeOtherMunicipality)
                    }
                    break;
                case TVTypeEnum.LiftStation:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.LineOverflow:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.OtherInfrastructure:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.Outfall:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.Prohibited:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                        {
                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.Restricted:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.Root:
                    {
                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                        {
                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        if (ReadGzFileService.webAppLoaded.WebArea == null)
                        {
                            ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.SeeOtherMunicipality:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.Spill:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        if (ReadGzFileService.webAppLoaded.WebSector == null)
                        {
                            ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.TideSite:
                    {
                        if (ReadGzFileService.webAppLoaded.WebTideSite == null)
                        {
                            ReadGzFileService.webAppLoaded.WebTideSite = ReadGzFileService.GetUncompressJSON<WebTideSite>(WebTypeEnum.WebTideSite, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebTideSite.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebTideSite.TVItemParentList;
                    }
                    break;
                case TVTypeEnum.WasteWaterTreatmentPlant:
                    {
                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                        {
                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                        }

                        gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                        gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                    }
                    break;
                default:
                    break;
            }

            return gzObjectList;
        }
    }
}
