/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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
    public partial interface ILocalMapInfoPointDBService
    {
        Task<ActionResult<bool>> Delete(int LocalMapInfoPointID);
        Task<ActionResult<List<LocalMapInfoPoint>>> GetLocalMapInfoPointList(int skip = 0, int take = 100);
        Task<ActionResult<LocalMapInfoPoint>> GetLocalMapInfoPointWithMapInfoPointID(int MapInfoPointID);
        Task<ActionResult<LocalMapInfoPoint>> Post(LocalMapInfoPoint localmapinfopoint);
        Task<ActionResult<LocalMapInfoPoint>> Put(LocalMapInfoPoint localmapinfopoint);
    }
    public partial class LocalMapInfoPointDBService : ControllerBase, ILocalMapInfoPointDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LocalMapInfoPointDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<LocalMapInfoPoint>> GetLocalMapInfoPointWithMapInfoPointID(int MapInfoPointID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalMapInfoPoint localMapInfoPoint = (from c in db.LocalMapInfoPoints.AsNoTracking()
                    where c.MapInfoPointID == MapInfoPointID
                    select c).FirstOrDefault();

            if (localMapInfoPoint == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localMapInfoPoint));
        }
        public async Task<ActionResult<List<LocalMapInfoPoint>>> GetLocalMapInfoPointList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalMapInfoPoint> localMapInfoPointList = (from c in db.LocalMapInfoPoints.AsNoTracking() orderby c.MapInfoPointID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localMapInfoPointList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalMapInfoPointID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalMapInfoPoint localMapInfoPoint = (from c in db.LocalMapInfoPoints
                    where c.MapInfoPointID == LocalMapInfoPointID
                    select c).FirstOrDefault();

            if (localMapInfoPoint == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalMapInfoPoint", "LocalMapInfoPointID", LocalMapInfoPointID.ToString())));
            }

            try
            {
                db.LocalMapInfoPoints.Remove(localMapInfoPoint);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalMapInfoPoint>> Post(LocalMapInfoPoint localMapInfoPoint)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localMapInfoPoint), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalMapInfoPoints.Add(localMapInfoPoint);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localMapInfoPoint));
        }
        public async Task<ActionResult<LocalMapInfoPoint>> Put(LocalMapInfoPoint localMapInfoPoint)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localMapInfoPoint), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalMapInfoPoints.Update(localMapInfoPoint);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localMapInfoPoint));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalMapInfoPoint localMapInfoPoint = validationContext.ObjectInstance as LocalMapInfoPoint;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localMapInfoPoint.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localMapInfoPoint.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localMapInfoPoint.MapInfoPointID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfoPointID"), new[] { nameof(localMapInfoPoint.MapInfoPointID) });
                }

                if (!(from c in db.LocalMapInfoPoints.AsNoTracking() select c).Where(c => c.MapInfoPointID == localMapInfoPoint.MapInfoPointID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MapInfoPoint", "MapInfoPointID", localMapInfoPoint.MapInfoPointID.ToString()), new[] { nameof(localMapInfoPoint.MapInfoPointID) });
                }
            }

            LocalMapInfo localMapInfoMapInfoID = null;
            localMapInfoMapInfoID = (from c in db.LocalMapInfos.AsNoTracking() where c.MapInfoID == localMapInfoPoint.MapInfoID select c).FirstOrDefault();

            if (localMapInfoMapInfoID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalMapInfo", "MapInfoID", localMapInfoPoint.MapInfoID.ToString()), new[] { nameof(localMapInfoPoint.MapInfoID) });
            }

            if (localMapInfoPoint.Ordinal < 0)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "Ordinal", "0"), new[] { nameof(localMapInfoPoint.Ordinal) });
            }

            if (localMapInfoPoint.Lat < -90 || localMapInfoPoint.Lat > 90)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lat", "-90", "90"), new[] { nameof(localMapInfoPoint.Lat) });
            }

            if (localMapInfoPoint.Lng < -180 || localMapInfoPoint.Lng > 180)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lng", "-180", "180"), new[] { nameof(localMapInfoPoint.Lng) });
            }

            if (localMapInfoPoint.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localMapInfoPoint.LastUpdateDate_UTC) });
            }
            else
            {
                if (localMapInfoPoint.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localMapInfoPoint.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localMapInfoPoint.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localMapInfoPoint.LastUpdateContactTVItemID.ToString()), new[] { nameof(localMapInfoPoint.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localMapInfoPoint.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}