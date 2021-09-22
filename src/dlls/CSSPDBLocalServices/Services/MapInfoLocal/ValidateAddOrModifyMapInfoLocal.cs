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
        private async Task<bool> ValidateAddOrModifyMapInfoLocal(PostMapInfoModel postMapInfoModel)
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
            // Verifying postMapInfoModel.TVItem
            //
            // don't need to check DBCommand, TVLevel, TVPath, ParentID or IsActive will only be using TVItemID and TVType
            // --------------------------------------------------------
            if (postMapInfoModel.TVItem.TVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.TVItem.TVItemID"));
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)postMapInfoModel.TVItem.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.TVItem.TVType"));
            }

            // --------------------------------------------------------
            // Verifying postMapInfoModel.ParentTVItem
            //
            // don't need to check DBCommand, TVLevel, TVPath, ParentID or IsActive will only be using TVItemID and TVType
            // --------------------------------------------------------
            if (postMapInfoModel.ParentTVItem.TVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.ParentTVItem.TVItemID"));
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)postMapInfoModel.ParentTVItem.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.ParentTVItem.TVType"));
            }

            // --------------------------------------------------------
            // Verifying postMapInfoModel.MapInfo
            // --------------------------------------------------------
            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)postMapInfoModel.MapInfo.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfo.DBCommand"));
            }

            if (postMapInfoModel.MapInfo.TVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfo.TVItemID"));
            }

            if (!AllowableTVTypes.Contains(postMapInfoModel.MapInfo.TVType))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVType", AllowableTVTypesStr));
            }

            // LatMin, LatMax, LngMin, LngMax should all be recalculated

            retStr = enums.EnumTypeOK(typeof(MapInfoDrawTypeEnum), (int?)postMapInfoModel.MapInfo.MapInfoDrawType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfoDrawType"));
            }

            // MapInfo.TVType should not have Infrastructure it should have WWTP, LS, LineOverflow, SeeOtherWWTP
            if (postMapInfoModel.MapInfo.TVType == TVTypeEnum.Infrastructure)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "MapInfo.TVType", TVTypeEnum.Infrastructure.ToString()));
            }

            // --------------------------------------------------------
            // Verifying postMapInfoModel.MapInfoPointList
            // --------------------------------------------------------
            if (postMapInfoModel.MapInfoPointList.Count == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.MapInfoPointList"));
            }

            // Does every MapInfoPoint item has all the right info
            foreach (MapInfoPoint mapInfoPoint in postMapInfoModel.MapInfoPointList)
            {
                if (mapInfoPoint.MapInfoID == 0)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "postMapInfoModel.MapInfoPoint.MapInfoID"));
                }

                if (mapInfoPoint.Ordinal > 100000)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeBelow_, "postMapInfoModel.MapInfoPoint.Ordinal", 10000));
                }

                if (mapInfoPoint.Lat < -90.0 || mapInfoPoint.Lng > 90.0)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "postMapInfoModel.MapInfoPoint.Lat", "-90.0", "90.0"));
                }

                if (mapInfoPoint.Lat < -180.0 || mapInfoPoint.Lng > 180.0)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "postMapInfoModel.MapInfoPoint.Lng", "-180.0", "180.0"));
                }
            }

            return CSSPLogService.ErrRes.ErrList.Count == 0 ? await Task.FromResult(true) : await Task.FromResult(false);
        }
    }
}
