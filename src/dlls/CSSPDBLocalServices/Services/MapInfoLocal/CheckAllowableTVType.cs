/*
 * Manually edited
 *
 */

using CSSPCreateGzFileServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using CSSPWebModels;
using CSSPLocalLoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPDBLocalServices
{
    public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
    {
        public void CheckAllowableTVType(MapInfoModel mapInfoModel)
        {
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
                TVTypeEnum.TideSite,
                TVTypeEnum.WasteWaterTreatmentPlant,
            };

            if (!AllowableTVTypes.Contains(mapInfoModel.MapInfo.TVType))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVType", string.Join(",", AllowableTVTypes)));
            }
        }
    }
}
