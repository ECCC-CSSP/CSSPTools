/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LocalServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBLocalServices
{
    public partial interface IMapInfoDBLocalService
    {
        Task<ActionResult<bool>> Delete(int MapInfoID);
        Task<ActionResult<List<MapInfo>>> GetMapInfoList(int skip = 0, int take = 100);
        Task<ActionResult<MapInfo>> GetMapInfoWithMapInfoID(int MapInfoID);
        Task<ActionResult<MapInfo>> Post(MapInfo mapinfo);
        Task<ActionResult<MapInfo>> Put(MapInfo mapinfo);
    }
    public partial class MapInfoDBLocalService : ControllerBase, IMapInfoDBLocalService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBInMemoryContext dbLocalIM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoDBLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext dbLocal,
           CSSPDBInMemoryContext dbLocalIM)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.dbLocal = dbLocal;
            this.dbLocalIM = dbLocalIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<MapInfo>> GetMapInfoWithMapInfoID(int MapInfoID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            MapInfo mapInfo = (from c in dbLocal.MapInfos.AsNoTracking()
                    where c.MapInfoID == MapInfoID
                    select c).FirstOrDefault();

            if (mapInfo == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(mapInfo));
        }
        public async Task<ActionResult<List<MapInfo>>> GetMapInfoList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<MapInfo> mapInfoList = (from c in dbLocal.MapInfos.AsNoTracking() orderby c.MapInfoID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(mapInfoList));
        }
        public async Task<ActionResult<bool>> Delete(int MapInfoID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            MapInfo mapInfo = (from c in dbLocal.MapInfos.Local
                    where c.MapInfoID == MapInfoID
                    select c).FirstOrDefault();

            if (mapInfo == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MapInfo", "MapInfoID", MapInfoID.ToString())));
            }

            try
            {
                dbLocal.MapInfos.Remove(mapInfo);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<MapInfo>> Post(MapInfo mapInfo)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mapInfo), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (mapInfo.MapInfoID == 0)
            {
                int LastMapInfoID = (from c in dbLocal.MapInfos.AsNoTracking()
                          orderby c.MapInfoID descending
                          select c.MapInfoID).FirstOrDefault();

                mapInfo.MapInfoID = LastMapInfoID + 1;
            }

            try
            {
                dbLocal.MapInfos.Add(mapInfo);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mapInfo));
        }
        public async Task<ActionResult<MapInfo>> Put(MapInfo mapInfo)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mapInfo), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocal.MapInfos.Update(mapInfo);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mapInfo));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MapInfo mapInfo = validationContext.ObjectInstance as MapInfo;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mapInfo.MapInfoID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfoID"), new[] { nameof(mapInfo.MapInfoID) });
                }

                if (!(from c in dbLocal.MapInfos.AsNoTracking() select c).Where(c => c.MapInfoID == mapInfo.MapInfoID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MapInfo", "MapInfoID", mapInfo.MapInfoID.ToString()), new[] { nameof(mapInfo.MapInfoID) });
                }
            }

            TVItem TVItemTVItemID = null;
            TVItemTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == mapInfo.TVItemID select c).FirstOrDefault();

            if (TVItemTVItemID == null)
            {
                TVItemTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == mapInfo.TVItemID select c).FirstOrDefault();

                if (TVItemTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", mapInfo.TVItemID.ToString()), new[] { nameof(mapInfo.TVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Root,
                        TVTypeEnum.Address,
                        TVTypeEnum.Area,
                        TVTypeEnum.ClimateSite,
                        TVTypeEnum.Country,
                        TVTypeEnum.File,
                        TVTypeEnum.HydrometricSite,
                        TVTypeEnum.MikeBoundaryConditionWebTide,
                        TVTypeEnum.MikeBoundaryConditionMesh,
                        TVTypeEnum.MikeSource,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.MWQMSite,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.Province,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.TideSite,
                        TVTypeEnum.WasteWaterTreatmentPlant,
                        TVTypeEnum.LiftStation,
                        TVTypeEnum.Spill,
                        TVTypeEnum.Outfall,
                        TVTypeEnum.OtherInfrastructure,
                        TVTypeEnum.SeeOtherMunicipality,
                        TVTypeEnum.LineOverflow,
                        TVTypeEnum.RainExceedance,
                        TVTypeEnum.Classification,
                        TVTypeEnum.Approved,
                        TVTypeEnum.Restricted,
                        TVTypeEnum.Prohibited,
                        TVTypeEnum.ConditionallyApproved,
                        TVTypeEnum.ConditionallyRestricted,
                    };
                    if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVItemID", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOtherMunicipality,LineOverflow,RainExceedance,Classification,Approved,Restricted,Prohibited,ConditionallyApproved,ConditionallyRestricted"), new[] { nameof(mapInfo.TVItemID) });
                    }
                }

            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Address,
                    TVTypeEnum.Area,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.Country,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.Province,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.TideSite,
                    TVTypeEnum.WasteWaterTreatmentPlant,
                    TVTypeEnum.LiftStation,
                    TVTypeEnum.Spill,
                    TVTypeEnum.Outfall,
                    TVTypeEnum.OtherInfrastructure,
                    TVTypeEnum.SeeOtherMunicipality,
                    TVTypeEnum.LineOverflow,
                    TVTypeEnum.RainExceedance,
                    TVTypeEnum.Classification,
                    TVTypeEnum.Approved,
                    TVTypeEnum.Restricted,
                    TVTypeEnum.Prohibited,
                    TVTypeEnum.ConditionallyApproved,
                    TVTypeEnum.ConditionallyRestricted,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVItemID", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOtherMunicipality,LineOverflow,RainExceedance,Classification,Approved,Restricted,Prohibited,ConditionallyApproved,ConditionallyRestricted"), new[] { nameof(mapInfo.TVItemID) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)mapInfo.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), new[] { nameof(mapInfo.TVType) });
            }

            if (mapInfo.LatMin < -90 || mapInfo.LatMin > 90)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "LatMin", "-90", "90"), new[] { nameof(mapInfo.LatMin) });
            }

            if (mapInfo.LatMax < -90 || mapInfo.LatMax > 90)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "LatMax", "-90", "90"), new[] { nameof(mapInfo.LatMax) });
            }

            if (mapInfo.LngMin < -180 || mapInfo.LngMin > 180)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "LngMin", "-180", "180"), new[] { nameof(mapInfo.LngMin) });
            }

            if (mapInfo.LngMax < -180 || mapInfo.LngMax > 180)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "LngMax", "-180", "180"), new[] { nameof(mapInfo.LngMax) });
            }

            retStr = enums.EnumTypeOK(typeof(MapInfoDrawTypeEnum), (int?)mapInfo.MapInfoDrawType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfoDrawType"), new[] { nameof(mapInfo.MapInfoDrawType) });
            }

            if (mapInfo.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mapInfo.LastUpdateDate_UTC) });
            }
            else
            {
                if (mapInfo.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mapInfo.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == mapInfo.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == mapInfo.LastUpdateContactTVItemID select c).FirstOrDefault();

                if (TVItemLastUpdateContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mapInfo.LastUpdateContactTVItemID.ToString()), new[] { nameof(mapInfo.LastUpdateContactTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mapInfo.LastUpdateContactTVItemID) });
                    }
                }

            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mapInfo.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
