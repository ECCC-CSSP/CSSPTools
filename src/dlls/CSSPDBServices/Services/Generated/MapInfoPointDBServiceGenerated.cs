/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPDBServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
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
using LoggedInServices;
using Microsoft.Extensions.Configuration;
using CSSPScrambleServices;

namespace CSSPDBServices
{
    public partial interface IMapInfoPointDBService
    {
        Task<ActionResult<bool>> Delete(int MapInfoPointID);
        Task<ActionResult<List<MapInfoPoint>>> GetMapInfoPointList(int skip = 0, int take = 100);
        Task<ActionResult<MapInfoPoint>> GetMapInfoPointWithMapInfoPointID(int MapInfoPointID);
        Task<ActionResult<MapInfoPoint>> Post(MapInfoPoint mapinfopoint);
        Task<ActionResult<MapInfoPoint>> Put(MapInfoPoint mapinfopoint);
    }
    public partial class MapInfoPointDBService : ControllerBase, IMapInfoPointDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IScrambleService ScrambleService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoPointDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ScrambleService = ScrambleService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<MapInfoPoint>> GetMapInfoPointWithMapInfoPointID(int MapInfoPointID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            MapInfoPoint mapInfoPoint = (from c in db.MapInfoPoints.AsNoTracking()
                    where c.MapInfoPointID == MapInfoPointID
                    select c).FirstOrDefault();

            if (mapInfoPoint == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(mapInfoPoint));
        }
        public async Task<ActionResult<List<MapInfoPoint>>> GetMapInfoPointList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<MapInfoPoint> mapInfoPointList = (from c in db.MapInfoPoints.AsNoTracking() orderby c.MapInfoPointID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(mapInfoPointList));
        }
        public async Task<ActionResult<bool>> Delete(int MapInfoPointID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            MapInfoPoint mapInfoPoint = (from c in db.MapInfoPoints
                    where c.MapInfoPointID == MapInfoPointID
                    select c).FirstOrDefault();

            if (mapInfoPoint == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MapInfoPoint", "MapInfoPointID", MapInfoPointID.ToString())));
            }

            try
            {
                db.MapInfoPoints.Remove(mapInfoPoint);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<MapInfoPoint>> Post(MapInfoPoint mapInfoPoint)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            ValidationResults = Validate(new ValidationContext(mapInfoPoint), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.MapInfoPoints.Add(mapInfoPoint);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mapInfoPoint));
        }
        public async Task<ActionResult<MapInfoPoint>> Put(MapInfoPoint mapInfoPoint)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            ValidationResults = Validate(new ValidationContext(mapInfoPoint), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.MapInfoPoints.Update(mapInfoPoint);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mapInfoPoint));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MapInfoPoint mapInfoPoint = validationContext.ObjectInstance as MapInfoPoint;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mapInfoPoint.MapInfoPointID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfoPointID"), new[] { nameof(mapInfoPoint.MapInfoPointID) });
                }

                if (!(from c in db.MapInfoPoints.AsNoTracking() select c).Where(c => c.MapInfoPointID == mapInfoPoint.MapInfoPointID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MapInfoPoint", "MapInfoPointID", mapInfoPoint.MapInfoPointID.ToString()), new[] { nameof(mapInfoPoint.MapInfoPointID) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)mapInfoPoint.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(mapInfoPoint.DBCommand) });
            }

            MapInfo MapInfoMapInfoID = null;
            MapInfoMapInfoID = (from c in db.MapInfos.AsNoTracking() where c.MapInfoID == mapInfoPoint.MapInfoID select c).FirstOrDefault();

            if (MapInfoMapInfoID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MapInfo", "MapInfoID", mapInfoPoint.MapInfoID.ToString()), new[] { nameof(mapInfoPoint.MapInfoID) });
            }

            if (mapInfoPoint.Ordinal < 0)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "Ordinal", "0"), new[] { nameof(mapInfoPoint.Ordinal) });
            }

            if (mapInfoPoint.Lat < -90 || mapInfoPoint.Lat > 90)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lat", "-90", "90"), new[] { nameof(mapInfoPoint.Lat) });
            }

            if (mapInfoPoint.Lng < -180 || mapInfoPoint.Lng > 180)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lng", "-180", "180"), new[] { nameof(mapInfoPoint.Lng) });
            }

            if (mapInfoPoint.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mapInfoPoint.LastUpdateDate_UTC) });
            }
            else
            {
                if (mapInfoPoint.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mapInfoPoint.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == mapInfoPoint.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mapInfoPoint.LastUpdateContactTVItemID.ToString()), new[] { nameof(mapInfoPoint.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mapInfoPoint.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
