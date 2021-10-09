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
        //private GzObjectList FillPostLists(PostMapInfoModel mapInfoLocalModel)
        //{
        //    LanguageEnum langEnum = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;

        //    GzObjectList gzObjectList = new GzObjectList();

        //    switch (mapInfoLocalModel.MapInfo.TVType)
        //    {
        //        case TVTypeEnum.Address:
        //            {
        //                if (WebRoot == null)
        //                {
        //                    WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebRoot.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebRoot.TVItemModelParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Approved:
        //            {
        //                if (WebSubsector == null)
        //                {
        //                    WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebSubsector.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebSubsector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Area:
        //            {
        //                if (WebProvince == null)
        //                {
        //                    WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebProvince.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebProvince.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Classification:
        //            {
        //                // there are no official MapInfo item with TVType Classification (See. Approved, Restricted, Prohibited, ConditionallyApproved, ConditionallyRestricted)
        //            }
        //            break;
        //        case TVTypeEnum.ClimateSite:
        //            {
        //                if (WebClimateSites == null)
        //                {
        //                    WebClimateSites = ReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebClimateSites.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebClimateSites.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.ConditionallyApproved:
        //            {
        //                if (WebSubsector == null)
        //                {
        //                    WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebSubsector.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebSubsector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.ConditionallyRestricted:
        //            {
        //                if (WebSubsector == null)
        //                {
        //                    WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebSubsector.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebSubsector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Country:
        //            {
        //                if (WebCountry == null)
        //                {
        //                    WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebCountry.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebCountry.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.File:
        //            {
        //                // nothing for now
        //            }
        //            break;
        //        case TVTypeEnum.HydrometricSite:
        //            {
        //                if (WebHydrometricSites == null)
        //                {
        //                    WebHydrometricSites = ReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebHydrometricSites.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebHydrometricSites.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Infrastructure:
        //            {
        //                // there are no official MapInfo item with TVType Infrastructure (See. WasteWaterTreatmentPlant, LiftStation, LineOverflow, Outfall, OtherInfrastructure, SeeOtherMunicipality)
        //            }
        //            break;
        //        case TVTypeEnum.LiftStation:
        //            {
        //                if (WebMunicipality == null)
        //                {
        //                    WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebMunicipality.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.LineOverflow:
        //            {
        //                if (WebMunicipality == null)
        //                {
        //                    WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebMunicipality.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.MikeBoundaryConditionMesh:
        //            {
        //                if (WebMikeScenario == null)
        //                {
        //                    WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebMikeScenario.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebMikeScenario.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.MikeBoundaryConditionWebTide:
        //            {
        //                if (WebMikeScenario == null)
        //                {
        //                    WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebMikeScenario.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebMikeScenario.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.MikeSource:
        //            {
        //                if (WebMikeScenario == null)
        //                {
        //                    WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebMikeScenario.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebMikeScenario.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Municipality:
        //            {
        //                if (WebMunicipality == null)
        //                {
        //                    WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebMunicipality.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.MWQMSite:
        //            {
        //                if (WebSubsector == null)
        //                {
        //                    WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebSubsector.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebSubsector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.OtherInfrastructure:
        //            {
        //                if (WebMunicipality == null)
        //                {
        //                    WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebMunicipality.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Outfall:
        //            {
        //                if (WebMunicipality == null)
        //                {
        //                    WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebMunicipality.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.PolSourceSite:
        //            {
        //                if (WebSubsector == null)
        //                {
        //                    WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebSubsector.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebSubsector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Prohibited:
        //            {
        //                if (WebSubsector == null)
        //                {
        //                    WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebSubsector.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebSubsector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Province:
        //            {
        //                if (WebCountry == null)
        //                {
        //                    WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebCountry.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebCountry.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.RainExceedance:
        //            {
        //                if (WebCountry == null)
        //                {
        //                    WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebCountry.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebCountry.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Restricted:
        //            {
        //                if (WebSubsector == null)
        //                {
        //                    WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebSubsector.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebSubsector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Root:
        //            {
        //                if (WebRoot == null)
        //                {
        //                    WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebRoot.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebRoot.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Sector:
        //            {
        //                if (WebArea == null)
        //                {
        //                    WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebArea.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebArea.TVItemModelParentList;
        //            }
        //            break;
        //        case TVTypeEnum.SeeOtherMunicipality:
        //            {
        //                if (WebMunicipality == null)
        //                {
        //                    WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebMunicipality.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Spill:
        //            {
        //                if (WebMunicipality == null)
        //                {
        //                    WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebMunicipality.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.Subsector:
        //            {
        //                if (WebSector == null)
        //                {
        //                    WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebSector.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebSector.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.TideSite:
        //            {
        //                if (WebTideSites == null)
        //                {
        //                    WebTideSites = ReadGzFileService.GetUncompressJSON<WebTideSites>(WebTypeEnum.WebTideSites, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebTideSites.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebTideSites.TVItemStatParentList;
        //            }
        //            break;
        //        case TVTypeEnum.WasteWaterTreatmentPlant:
        //            {
        //                if (WebMunicipality == null)
        //                {
        //                    WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)mapInfoLocalModel.TVItem.ParentID).GetAwaiter().GetResult();
        //                }

        //                gzObjectList.ParentTVItem = WebMunicipality.TVItemModel.TVItem;
        //                gzObjectList.tvItemParentList = WebMunicipality.TVItemStatParentList;
        //            }
        //            break;
        //        default:
        //            break;
        //    }

        //    return gzObjectList;
        //}
    }
}
