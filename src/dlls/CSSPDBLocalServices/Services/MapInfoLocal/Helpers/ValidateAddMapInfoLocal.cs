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
using System.Threading.Tasks;

namespace CSSPDBLocalServices
{

    public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
    {
        private async Task<bool> ValidateAddMapInfoLocal(MapInfoLocalModel mapInfoLocalModel)
        {
            string retStr = "";
            TVItem ParentTVItem = new TVItem();
            List<TVItemModel> tvItemParentList = new List<TVItemModel>();
            List<TVItemModel> tvItemSiblingList = new List<TVItemModel>();

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
            // Verifying mapInfoLocalModel.TVItem
            //
            // don't need to check DBCommand, TVLevel, TVPath, ParentID or IsActive will only be using TVItemID and TVType
            // --------------------------------------------------------
            if (mapInfoLocalModel.TVItem.TVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "mapInfoLocalModel.TVItem.TVItemID"));
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)mapInfoLocalModel.TVItem.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "mapInfoLocalModel.TVItem.TVType"));
            }

            // --------------------------------------------------------
            // Verifying mapInfoLocalModel.ParentTVItem
            //
            // don't need to check DBCommand, TVLevel, TVPath, ParentID or IsActive will only be using TVItemID and TVType
            // --------------------------------------------------------
            if (mapInfoLocalModel.ParentTVItem.TVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "mapInfoLocalModel.ParentTVItem.TVItemID"));
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)mapInfoLocalModel.ParentTVItem.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "mapInfoLocalModel.ParentTVItem.TVType"));
            }

            // --------------------------------------------------------
            // Verifying mapInfoLocalModel.MapInfo
            // --------------------------------------------------------
            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)mapInfoLocalModel.MapInfo.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfo.DBCommand"));
            }

            if (mapInfoLocalModel.MapInfo.TVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfo.TVItemID"));
            }

            if (!AllowableTVTypes.Contains(mapInfoLocalModel.MapInfo.TVType))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVType", AllowableTVTypesStr));
            }

            // LatMin, LatMax, LngMin, LngMax should all be recalculated

            retStr = enums.EnumTypeOK(typeof(MapInfoDrawTypeEnum), (int?)mapInfoLocalModel.MapInfo.MapInfoDrawType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfoDrawType"));
            }

            // MapInfo.TVType should not have Infrastructure it should have WWTP, LS, LineOverflow, SeeOtherWWTP
            if (mapInfoLocalModel.MapInfo.TVType == TVTypeEnum.Infrastructure)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "MapInfo.TVType", TVTypeEnum.Infrastructure.ToString()));
            }

            // --------------------------------------------------------
            // Verifying mapInfoLocalModel.MapInfoPointList
            // --------------------------------------------------------
            if (mapInfoLocalModel.MapInfoPointList.Count == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "mapInfoLocalModel.MapInfoPointList"));
            }

            // Does every MapInfoPoint item has all the right info
            foreach (MapInfoPoint mapInfoPoint in mapInfoLocalModel.MapInfoPointList)
            {
                if (mapInfoPoint.MapInfoID == 0)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "mapInfoLocalModel.MapInfoPoint.MapInfoID"));
                }

                if (mapInfoPoint.Ordinal > 100000)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeBelow_, "mapInfoLocalModel.MapInfoPoint.Ordinal", 10000));
                }

                if (mapInfoPoint.Lat < -90.0 || mapInfoPoint.Lng > 90.0)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "mapInfoLocalModel.MapInfoPoint.Lat", "-90.0", "90.0"));
                }

                if (mapInfoPoint.Lat < -180.0 || mapInfoPoint.Lng > 180.0)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "mapInfoLocalModel.MapInfoPoint.Lng", "-180.0", "180.0"));
                }
            }

            return CSSPLogService.ErrRes.ErrList.Count == 0 ? await Task.FromResult(true) : await Task.FromResult(false);
        }
    }
}
