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
        //private GzObjectList FillPostLists(PostMapInfoModel postMapInfoModel)
        //{
        //    LanguageEnum langEnum = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;

        //    GzObjectList gzObjectList = new GzObjectList();

        //    switch (postMapInfoModel.MapInfo.TVType)
        //    {
        //        case TVTypeEnum.Address:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebRoot == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatModelParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Approved:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebSubsector == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Area:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebProvince == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Classification:
        //            {
        //                // there are no official MapInfo item with TVType Classification (See. Approved, Restricted, Prohibited, ConditionallyApproved, ConditionallyRestricted)
        //            }
        //            break;
        //        case TVTypeEnum.ClimateSite:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebClimateSites == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebClimateSites = ReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebClimateSites.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebClimateSites.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.ConditionallyApproved:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebSubsector == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.ConditionallyRestricted:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebSubsector == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Country:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebCountry == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.File:
        //            {
        //                // nothing for now
        //            }
        //            break;
        //        case TVTypeEnum.HydrometricSite:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebHydrometricSites == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebHydrometricSites = ReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebHydrometricSites.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebHydrometricSites.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Infrastructure:
        //            {
        //                // there are no official MapInfo item with TVType Infrastructure (See. WasteWaterTreatmentPlant, LiftStation, LineOverflow, Outfall, OtherInfrastructure, SeeOtherMunicipality)
        //            }
        //            break;
        //        case TVTypeEnum.LiftStation:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.LineOverflow:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.MikeBoundaryConditionMesh:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.MikeBoundaryConditionWebTide:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.MikeSource:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Municipality:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.MWQMSite:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebSubsector == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.OtherInfrastructure:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Outfall:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.PolSourceSite:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebSubsector == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Prohibited:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebSubsector == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Province:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebCountry == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.RainExceedance:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebCountry == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Restricted:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebSubsector == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Root:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebRoot == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Sector:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebArea == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebArea.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemStatModelParentList;
        //            }
        //            break;
        //        case TVTypeEnum.SeeOtherMunicipality:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Spill:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Subsector:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebSector == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebSector.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.TideSite:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebTideSites == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebTideSites = ReadGzFileService.GetUncompressJSON<WebTideSites>(WebTypeEnum.WebTideSites, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebTideSites.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebTideSites.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.WasteWaterTreatmentPlant:
        //            {
        //                if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
        //                {
        //                    ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatMapModel.TVItem;
        //                gzObjectList.tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        default:
        //            break;
        //    }

        //    return gzObjectList;
        //}
    }
}
