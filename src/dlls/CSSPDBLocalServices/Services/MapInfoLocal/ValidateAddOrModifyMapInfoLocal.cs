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
        private bool ValidateAddOrModifyMapInfoLocal(PostMapInfoModel postMapInfoModel)
        {
            string retStr = "";
            TVItem ParentTVItem = new TVItem();
            List<WebBase> tvItemParentList = new List<WebBase>();
            List<WebBase> tvItemSiblingList = new List<WebBase>();

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
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.TVItem.TVItemID"), new[] { "TVItemID" }));
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)postMapInfoModel.TVItem.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.TVItem.TVType"), new[] { "TVType" }));
            }

            // --------------------------------------------------------
            // Verifying postMapInfoModel.ParentTVItem
            //
            // don't need to check DBCommand, TVLevel, TVPath, ParentID or IsActive will only be using TVItemID and TVType
            // --------------------------------------------------------
            if (postMapInfoModel.ParentTVItem.TVItemID == 0)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.ParentTVItem.TVItemID"), new[] { "TVItemID" }));
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)postMapInfoModel.ParentTVItem.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.ParentTVItem.TVType"), new[] { "TVType" }));
            }

            // --------------------------------------------------------
            // Verifying postMapInfoModel.MapInfo
            // --------------------------------------------------------
            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)postMapInfoModel.MapInfo.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfo.DBCommand"), new[] { "DBCommand" }));
            }

            if (postMapInfoModel.MapInfo.TVItemID == 0)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfo.TVItemID"), new[] { "TVItemID" }));
            }

            if (!AllowableTVTypes.Contains(postMapInfoModel.MapInfo.TVType))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVType", AllowableTVTypesStr), new[] { "TVType" }));
            }

            // LatMin, LatMax, LngMin, LngMax should all be recalculated

            retStr = enums.EnumTypeOK(typeof(MapInfoDrawTypeEnum), (int?)postMapInfoModel.MapInfo.MapInfoDrawType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfoDrawType"), new[] { "MapInfoDrawType" }));
            }

            // MapInfo.TVType should not have Infrastructure it should have WWTP, LS, LineOverflow, SeeOtherWWTP
            if (postMapInfoModel.MapInfo.TVType == TVTypeEnum.Infrastructure)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "MapInfo.TVType", TVTypeEnum.Infrastructure.ToString()), new[] { "TVType" }));
            }

            // --------------------------------------------------------
            // Verifying postMapInfoModel.MapInfoPointList
            // --------------------------------------------------------
            if (postMapInfoModel.MapInfoPointList.Count == 0)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.MapInfoPointList"), new[] { "MapInfoPointList" }));
            }

            // Does every MapInfoPoint item has all the right info
            foreach (MapInfoPoint mapInfoPoint in postMapInfoModel.MapInfoPointList)
            {
                if (mapInfoPoint.MapInfoID == 0)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.MapInfoPoint.MapInfoID"), new[] { "MapInfoID" }));
                }

                if (mapInfoPoint.Ordinal > 100000)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldBeBelow_, "postMapInfoModel.MapInfoPoint.Ordinal", 10000), new[] { "Ordinal" }));
                }

                if (mapInfoPoint.Lat < -90.0 || mapInfoPoint.Lng > 90.0)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "postMapInfoModel.MapInfoPoint.Lat", "-90.0", "90.0"), new[] { "Lat" }));
                }

                if (mapInfoPoint.Lat < -180.0 || mapInfoPoint.Lng > 180.0)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "postMapInfoModel.MapInfoPoint.Lng", "-180.0", "180.0"), new[] { "Lat" }));
                }
            }

            return ValidationResults.Count == 0 ? true : false;
        }
    }
}
