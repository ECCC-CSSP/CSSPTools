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
    public partial interface ILocalTideSiteDBService
    {
        Task<ActionResult<bool>> Delete(int LocalTideSiteID);
        Task<ActionResult<List<LocalTideSite>>> GetLocalTideSiteList(int skip = 0, int take = 100);
        Task<ActionResult<LocalTideSite>> GetLocalTideSiteWithTideSiteID(int TideSiteID);
        Task<ActionResult<LocalTideSite>> Post(LocalTideSite localtidesite);
        Task<ActionResult<LocalTideSite>> Put(LocalTideSite localtidesite);
    }
    public partial class LocalTideSiteDBService : ControllerBase, ILocalTideSiteDBService
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
        public LocalTideSiteDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<LocalTideSite>> GetLocalTideSiteWithTideSiteID(int TideSiteID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalTideSite localTideSite = (from c in db.LocalTideSites.AsNoTracking()
                    where c.TideSiteID == TideSiteID
                    select c).FirstOrDefault();

            if (localTideSite == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localTideSite));
        }
        public async Task<ActionResult<List<LocalTideSite>>> GetLocalTideSiteList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalTideSite> localTideSiteList = (from c in db.LocalTideSites.AsNoTracking() orderby c.TideSiteID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localTideSiteList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalTideSiteID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalTideSite localTideSite = (from c in db.LocalTideSites
                    where c.TideSiteID == LocalTideSiteID
                    select c).FirstOrDefault();

            if (localTideSite == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTideSite", "LocalTideSiteID", LocalTideSiteID.ToString())));
            }

            try
            {
                db.LocalTideSites.Remove(localTideSite);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalTideSite>> Post(LocalTideSite localTideSite)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localTideSite), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalTideSites.Add(localTideSite);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localTideSite));
        }
        public async Task<ActionResult<LocalTideSite>> Put(LocalTideSite localTideSite)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localTideSite), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalTideSites.Update(localTideSite);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localTideSite));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalTideSite localTideSite = validationContext.ObjectInstance as LocalTideSite;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localTideSite.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localTideSite.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localTideSite.TideSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TideSiteID"), new[] { nameof(localTideSite.TideSiteID) });
                }

                if (!(from c in db.LocalTideSites.AsNoTracking() select c).Where(c => c.TideSiteID == localTideSite.TideSiteID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TideSite", "TideSiteID", localTideSite.TideSiteID.ToString()), new[] { nameof(localTideSite.TideSiteID) });
                }
            }

            LocalTVItem localTVItemTideSiteTVItemID = null;
            localTVItemTideSiteTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localTideSite.TideSiteTVItemID select c).FirstOrDefault();

            if (localTVItemTideSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "TideSiteTVItemID", localTideSite.TideSiteTVItemID.ToString()), new[] { nameof(localTideSite.TideSiteTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.TideSite,
                };
                if (!AllowableTVTypes.Contains(localTVItemTideSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TideSiteTVItemID", "TideSite"), new[] { nameof(localTideSite.TideSiteTVItemID) });
                }
            }

            if (string.IsNullOrWhiteSpace(localTideSite.TideSiteName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TideSiteName"), new[] { nameof(localTideSite.TideSiteName) });
            }

            if (!string.IsNullOrWhiteSpace(localTideSite.TideSiteName) && localTideSite.TideSiteName.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TideSiteName", "100"), new[] { nameof(localTideSite.TideSiteName) });
            }

            if (string.IsNullOrWhiteSpace(localTideSite.Province))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Province"), new[] { nameof(localTideSite.Province) });
            }

            if (!string.IsNullOrWhiteSpace(localTideSite.Province) && (localTideSite.Province.Length < 2 || localTideSite.Province.Length > 2))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Province", "2", "2"), new[] { nameof(localTideSite.Province) });
            }

            if (localTideSite.sid < 0 || localTideSite.sid > 10000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "sid", "0", "10000"), new[] { nameof(localTideSite.sid) });
            }

            if (localTideSite.Zone < 0 || localTideSite.Zone > 10000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Zone", "0", "10000"), new[] { nameof(localTideSite.Zone) });
            }

            if (localTideSite.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localTideSite.LastUpdateDate_UTC) });
            }
            else
            {
                if (localTideSite.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localTideSite.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localTideSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localTideSite.LastUpdateContactTVItemID.ToString()), new[] { nameof(localTideSite.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localTideSite.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}