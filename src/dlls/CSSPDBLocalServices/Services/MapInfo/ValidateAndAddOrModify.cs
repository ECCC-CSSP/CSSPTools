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

    public partial class MapInfoService : ControllerBase, IMapInfoService
    {
        private IEnumerable<ValidationResult> ValidateAndAddOrModify(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            string MapInfoErrorMessage = "";
            TVItem ParentTVItem = new TVItem();
            List<WebBase> tvItemParentList = new List<WebBase>();
            List<WebBase> tvItemSiblingList = new List<WebBase>();
            bool HasError = false;
            PostMapInfoModel postMapInfoModel = validationContext.ObjectInstance as PostMapInfoModel;
            List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
            {
                TVTypeEnum.Address,
                TVTypeEnum.Approved,
                TVTypeEnum.Area,
                TVTypeEnum.Classification,
                TVTypeEnum.ClimateSite,
                TVTypeEnum.ConditionallyApproved,
                TVTypeEnum.ConditionallyRestricted,
                TVTypeEnum.Country,
                TVTypeEnum.File,
                TVTypeEnum.HydrometricSite,
                TVTypeEnum.Infrastructure,
                TVTypeEnum.LiftStation,
                TVTypeEnum.LineOverflow,
                TVTypeEnum.MikeBoundaryConditionMesh,
                TVTypeEnum.MikeBoundaryConditionWebTide,
                TVTypeEnum.MikeSource,
                TVTypeEnum.Municipality,
                TVTypeEnum.MWQMSite,
                TVTypeEnum.OtherInfrastructure,
                TVTypeEnum.Outfall,
                TVTypeEnum.PolSourceSite,
                TVTypeEnum.Prohibited,
                TVTypeEnum.Province,
                TVTypeEnum.RainExceedance,
                TVTypeEnum.Restricted,
                TVTypeEnum.Root,
                TVTypeEnum.Sector,
                TVTypeEnum.SeeOtherMunicipality,
                TVTypeEnum.Spill,
                TVTypeEnum.Subsector,
                TVTypeEnum.Tel,
                TVTypeEnum.TideSite,
                TVTypeEnum.WasteWaterTreatmentPlant,

                /// need to add more
            };
            string AllowableTVTypesStr = "Address,Approved,Area,Classification,ClimateSite,ConditionallyApproved,ConditionallyRestricted,Country,File," +
                    "Infrastructure,HydrometricSite,LiftStation,LineOverflow,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeSource," +
                    "Municipality,MWQMSite,OtherInfrastructure,Outfall,PolSourceSite,Prohibited,Province,RainExceedance,Restricted," +
                    "Root,Sector,SeeOtherMunicipality,Spill,Subsector,Tel,TideSite,WasteWaterTreatmentPlant";

            // --------------------------------------------------------
            // Verifying postMapInfoModel.TVItem
            //
            // don't need to check DBCommand, TVLevel, TVPath, ParentID or IsActive will only be using TVItemID and TVType
            // --------------------------------------------------------
            if (postMapInfoModel.TVItem.TVItemID == 0)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.TVItem.TVItemID"), new[] { "TVItemID" });
                HasError = true;
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)postMapInfoModel.TVItem.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.TVItem.TVType"), new[] { "TVType" });
                HasError = true;
            }

            // --------------------------------------------------------
            // Verifying postMapInfoModel.ParentTVItem
            //
            // don't need to check DBCommand, TVLevel, TVPath, ParentID or IsActive will only be using TVItemID and TVType
            // --------------------------------------------------------
            if (postMapInfoModel.ParentTVItem.TVItemID == 0)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.ParentTVItem.TVItemID"), new[] { "TVItemID" });
                HasError = true;
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)postMapInfoModel.ParentTVItem.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.ParentTVItem.TVType"), new[] { "TVType" });
                HasError = true;
            }

            // --------------------------------------------------------
            // Verifying postMapInfoModel.MapInfo
            // --------------------------------------------------------
            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)postMapInfoModel.MapInfo.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfo.DBCommand"), new[] { "DBCommand" });
                HasError = true;
            }

            if (postMapInfoModel.MapInfo.TVItemID == 0)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfo.TVItemID"), new[] { "TVItemID" });
                HasError = true;
            }

            if (!AllowableTVTypes.Contains(postMapInfoModel.MapInfo.TVType))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVType", AllowableTVTypesStr), new[] { "TVType" });
                HasError = true;
            }

            // LatMin, LatMax, LngMin, LngMax should all be recalculated

            retStr = enums.EnumTypeOK(typeof(MapInfoDrawTypeEnum), (int?)postMapInfoModel.MapInfo.MapInfoDrawType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfoDrawType"), new[] { "MapInfoDrawType" });
                HasError = true;
            }

            // MapInfo.TVType should not have Infrastructure it should have WWTP, LS, LineOverflow, SeeOtherWWTP
            if (postMapInfoModel.MapInfo.TVType == TVTypeEnum.Infrastructure)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "MapInfo.TVType", TVTypeEnum.Infrastructure.ToString()), new[] { "TVType" });
                HasError = true;
            }

            // --------------------------------------------------------
            // Verifying postMapInfoModel.MapInfoPointList
            // --------------------------------------------------------
            if (postMapInfoModel.MapInfoPointList.Count == 0)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.MapInfoPointList"), new[] { "MapInfoPointList" });
                HasError = true;
            }

            // Does every MapInfoPoint item has all the right info
            foreach (MapInfoPoint mapInfoPoint in postMapInfoModel.MapInfoPointList)
            {
                if (mapInfoPoint.MapInfoID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.MapInfoPoint.MapInfoID"), new[] { "MapInfoID" });
                    HasError = true;
                }

                if (mapInfoPoint.Ordinal > 100000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldBeBelow_, "postMapInfoModel.MapInfoPoint.Ordinal", 10000), new[] { "Ordinal" });
                    HasError = true;
                }

                if (mapInfoPoint.Lat < -90.0 || mapInfoPoint.Lng > 90.0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "postMapInfoModel.MapInfoPoint.Lat", "-90.0", "90.0"), new[] { "Lat" });
                    HasError = true;
                }

                if (mapInfoPoint.Lat < -180.0 || mapInfoPoint.Lng > 180.0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "postMapInfoModel.MapInfoPoint.Lng", "-180.0", "180.0"), new[] { "Lat" });
                    HasError = true;
                }
            }


            if (!HasError)
            {
                switch (postMapInfoModel.MapInfo.TVType)
                {
                    case TVTypeEnum.Address:
                        {
                            if (ReadGzFileService.webAppLoaded.WebRoot == null)
                            {
                                ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.Approved:
                        {
                            if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                            {
                                ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.Area:
                        {
                            if (ReadGzFileService.webAppLoaded.WebProvince == null)
                            {
                                ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
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

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebClimateSite.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebClimateSite.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.ConditionallyApproved:
                        {
                            if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                            {
                                ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.ConditionallyRestricted:
                        {
                            if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                            {
                                ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.Country:
                        {
                            if (ReadGzFileService.webAppLoaded.WebCountry == null)
                            {
                                ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
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

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebHydrometricSite.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebHydrometricSite.TVItemParentList;
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

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.LineOverflow:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.MikeBoundaryConditionMesh:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.MikeBoundaryConditionWebTide:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.MikeSource:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.Municipality:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.MWQMSite:
                        {
                            if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                            {
                                ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.OtherInfrastructure:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.Outfall:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.PolSourceSite:
                        {
                            if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                            {
                                ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.Prohibited:
                        {
                            if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                            {
                                ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.Province:
                        {
                            if (ReadGzFileService.webAppLoaded.WebCountry == null)
                            {
                                ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.RainExceedance:
                        {
                            if (ReadGzFileService.webAppLoaded.WebCountry == null)
                            {
                                ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.Restricted:
                        {
                            if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                            {
                                ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.Root:
                        {
                            if (ReadGzFileService.webAppLoaded.WebRoot == null)
                            {
                                ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.Sector:
                        {
                            if (ReadGzFileService.webAppLoaded.WebArea == null)
                            {
                                ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.SeeOtherMunicipality:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.Spill:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.Subsector:
                        {
                            if (ReadGzFileService.webAppLoaded.WebSector == null)
                            {
                                ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.TideSite:
                        {
                            if (ReadGzFileService.webAppLoaded.WebTideSite == null)
                            {
                                ReadGzFileService.webAppLoaded.WebTideSite = ReadGzFileService.GetUncompressJSON<WebTideSite>(WebTypeEnum.WebTideSite, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebTideSite.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebTideSite.TVItemParentList;
                        }
                        break;
                    case TVTypeEnum.WasteWaterTreatmentPlant:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postMapInfoModel.TVItem.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                        }
                        break;
                    default:
                        break;
                }

                #region Writting to DBLocal

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
                            AppendToRecreate(ToRecreateList, webBaseToAdd.TVItemModel.TVItem, 1982);
                        }
                        catch (Exception ex)
                        {
                            MapInfoErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message);
                        }

                        if (!string.IsNullOrWhiteSpace(MapInfoErrorMessage))
                        {
                            yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", MapInfoErrorMessage), new[] { "TVItem" });
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
                                }
                            }
                        }
                    }
                }

                double LatMin = 91.0;
                double LatMax = -91.0;
                double LngMin = 181.0;
                double LngMax = -181.0;
                if (postMapInfoModel.MapInfo.MapInfoDrawType == MapInfoDrawTypeEnum.Point)
                {
                    // might need to change the +/- 0.001 for different TVType or MapInfoDrawType
                    LatMin = (from c in postMapInfoModel.MapInfoPointList select c.Lat).Min() - 0.001;
                    LatMax = (from c in postMapInfoModel.MapInfoPointList select c.Lat).Max() + 0.001;
                    LngMin = (from c in postMapInfoModel.MapInfoPointList select c.Lng).Min() - 0.001;
                    LngMax = (from c in postMapInfoModel.MapInfoPointList select c.Lng).Max() + 0.001;
                }
                else
                {
                    // might need to change the +/- 0.001 for different TVType or MapInfoDrawType
                    LatMin = (from c in postMapInfoModel.MapInfoPointList select c.Lat).Min() - 0.001;
                    LatMax = (from c in postMapInfoModel.MapInfoPointList select c.Lat).Max() + 0.001;
                    LngMin = (from c in postMapInfoModel.MapInfoPointList select c.Lng).Min() - 0.001;
                    LngMax = (from c in postMapInfoModel.MapInfoPointList select c.Lng).Max() + 0.001;
                }

                int MapInfoIDNew = (from c in dbLocal.MapInfos
                                    where c.MapInfoID < 0
                                    orderby c.MapInfoID descending
                                    select c.MapInfoID).FirstOrDefault() - 1;

                if (postMapInfoModel.MapInfo.MapInfoID == 0)
                {
                    // trying to add a new MapInfo
                    MapInfo mapInfo = (from c in dbLocal.MapInfos
                                       where c.TVItemID == postMapInfoModel.TVItem.TVItemID
                                       && c.TVType == postMapInfoModel.MapInfo.TVType
                                       && c.MapInfoDrawType == postMapInfoModel.MapInfo.MapInfoDrawType
                                       select c).FirstOrDefault();

                    if (mapInfo != null)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._AlreadyExists, "postMapInfoModel.MapInfo"), new[] { "MapInfo" });
                        HasError = true;
                    }

                    MapInfo mapInfoNew = new MapInfo()
                    {
                        MapInfoID = MapInfoIDNew,
                        DBCommand = DBCommandEnum.Created,
                        TVItemID = postMapInfoModel.MapInfo.TVItemID,
                        TVType = postMapInfoModel.MapInfo.TVType,
                        MapInfoDrawType = postMapInfoModel.MapInfo.MapInfoDrawType,
                        LatMin = LatMin,
                        LatMax = LatMax,
                        LngMin = LngMin,
                        LngMax = LngMax,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID,
                    };

                    if (!HasError)
                    {
                        try
                        {
                            dbLocal.MapInfos.Add(mapInfoNew);
                            dbLocal.SaveChanges();
                            AppendToRecreate(ToRecreateList, postMapInfoModel.TVItem, 1982);
                        }
                        catch (Exception ex)
                        {
                            MapInfoErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "MapInfo", ex.Message);
                        }

                        if (!string.IsNullOrWhiteSpace(MapInfoErrorMessage))
                        {
                            yield return new ValidationResult(MapInfoErrorMessage, new[] { "MapInfo" });
                            HasError = true;
                        }
                    }

                    if (!HasError)
                    {
                        int MapInfoPointIDNew = (from c in dbLocal.MapInfoPoints
                                                 where c.MapInfoPointID < 0
                                                 orderby c.MapInfoPointID descending
                                                 select c.MapInfoPointID).FirstOrDefault() - 1;

                        int countOrdinal = 0;
                        foreach (MapInfoPoint mapInfoPoint in postMapInfoModel.MapInfoPointList)
                        {
                            MapInfoPoint mapInfoPointNew = new MapInfoPoint()
                            {
                                MapInfoPointID = MapInfoPointIDNew,
                                DBCommand = DBCommandEnum.Created,
                                MapInfoID = mapInfoNew.MapInfoID,
                                Ordinal = countOrdinal,
                                Lat = mapInfoPoint.Lat,
                                Lng = mapInfoPoint.Lng,
                                LastUpdateDate_UTC = DateTime.UtcNow,
                                LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID,
                            };

                            dbLocal.MapInfoPoints.Add(mapInfoPointNew);

                            countOrdinal += 1;
                            MapInfoPointIDNew -= 1;
                        }


                        try
                        {
                            dbLocal.SaveChanges();
                            AppendToRecreate(ToRecreateList, postMapInfoModel.TVItem, 1982);
                        }
                        catch (Exception ex)
                        {
                            MapInfoErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "MapInfoPoint", ex.Message);
                        }

                        if (!string.IsNullOrWhiteSpace(MapInfoErrorMessage))
                        {
                            yield return new ValidationResult(MapInfoErrorMessage, new[] { "MapInfoPoint" });
                            HasError = true;
                        }

                    }
                }
                else
                {
                    MapInfo mapInfo = (from c in dbLocal.MapInfos
                                       where c.MapInfoID == postMapInfoModel.MapInfo.MapInfoID
                                       select c).FirstOrDefault();

                    MapInfo mapInfoNew = new MapInfo()
                    {
                        MapInfoID = postMapInfoModel.MapInfo.MapInfoID,
                        DBCommand = DBCommandEnum.Modified,
                        TVItemID = postMapInfoModel.MapInfo.TVItemID,
                        TVType = postMapInfoModel.MapInfo.TVType,
                        MapInfoDrawType = postMapInfoModel.MapInfo.MapInfoDrawType,
                        LatMin = LatMin,
                        LatMax = LatMax,
                        LngMin = LngMin,
                        LngMax = LngMax,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID,
                    };

                    if (!HasError)
                    {
                        if (mapInfo == null)
                        {
                            dbLocal.MapInfos.Add(mapInfoNew);
                        }

                        try
                        {
                            dbLocal.SaveChanges();
                            AppendToRecreate(ToRecreateList, postMapInfoModel.TVItem, 1982);
                        }
                        catch (Exception ex)
                        {
                            MapInfoErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "MapInfo", ex.Message);
                        }

                        if (!string.IsNullOrWhiteSpace(MapInfoErrorMessage))
                        {
                            yield return new ValidationResult(MapInfoErrorMessage, new[] { "MapInfo" });
                            HasError = true;
                        }
                    }

                    if (!HasError)
                    {
                        // delete all MapInfoPoints associated with the mapInfoNew.MapInfoID
                        List<MapInfoPoint> mapInfoPointInLocal = (from c in dbLocal.MapInfoPoints
                                                                  where c.MapInfoID == mapInfoNew.MapInfoID
                                                                  orderby c.Ordinal
                                                                  select c).ToList();
                        if (mapInfoPointInLocal.Count > 0)
                        {
                            dbLocal.RemoveRange(mapInfoPointInLocal);
                        }

                        try
                        {
                            dbLocal.SaveChanges();
                            AppendToRecreate(ToRecreateList, postMapInfoModel.TVItem, 1982);
                        }
                        catch (Exception ex)
                        {
                            MapInfoErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "MapInfoPoint", ex.Message);
                        }

                        if (!string.IsNullOrWhiteSpace(MapInfoErrorMessage))
                        {
                            yield return new ValidationResult(MapInfoErrorMessage, new[] { "MapInfoPoint" });
                            HasError = true;
                        }

                        // adding all MapInfoPoints 
                        int MapInfoPointIDNew = (from c in dbLocal.MapInfoPoints
                                                 where c.MapInfoPointID < 0
                                                 orderby c.MapInfoPointID descending
                                                 select c.MapInfoPointID).FirstOrDefault() - 1;

                        int countOrdinal = 0;
                        foreach (MapInfoPoint mapInfoPoint in postMapInfoModel.MapInfoPointList)
                        {
                            MapInfoPoint mapInfoPointNew = new MapInfoPoint()
                            {
                                MapInfoPointID = MapInfoPointIDNew,
                                DBCommand = DBCommandEnum.Modified,
                                MapInfoID = mapInfoNew.MapInfoID,
                                Ordinal = countOrdinal,
                                Lat = mapInfoPoint.Lat,
                                Lng = mapInfoPoint.Lng,
                                LastUpdateDate_UTC = DateTime.UtcNow,
                                LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID,
                            };

                            dbLocal.MapInfoPoints.Add(mapInfoPointNew);

                            countOrdinal += 1;
                            MapInfoPointIDNew -= 1;
                        }

                        try
                        {
                            dbLocal.SaveChanges();
                            AppendToRecreate(ToRecreateList, postMapInfoModel.TVItem, 1982);
                        }
                        catch (Exception ex)
                        {
                            MapInfoErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "MapInfoPoint", ex.Message);
                        }

                        if (!string.IsNullOrWhiteSpace(MapInfoErrorMessage))
                        {
                            yield return new ValidationResult(MapInfoErrorMessage, new[] { "MapInfoPoint" });
                            HasError = true;
                        }

                    }
                }

                foreach (ToRecreate toRecreate in ToRecreateList)
                {
                    CreateGzFileLocalService.CreateGzFileLocal(toRecreate.WebType, toRecreate.TVItemID, toRecreate.WebTypeYear);
                }
                #endregion Writting to DBLocal
            }
        }
    }
}
