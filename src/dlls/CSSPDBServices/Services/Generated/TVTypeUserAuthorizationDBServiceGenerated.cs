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
using LoggedInServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBServices
{
    public partial interface ITVTypeUserAuthorizationDBService
    {
        Task<ActionResult<bool>> Delete(int TVTypeUserAuthorizationID);
        Task<ActionResult<List<TVTypeUserAuthorization>>> GetTVTypeUserAuthorizationList(int skip = 0, int take = 100);
        Task<ActionResult<TVTypeUserAuthorization>> GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(int TVTypeUserAuthorizationID);
        Task<ActionResult<TVTypeUserAuthorization>> Post(TVTypeUserAuthorization tvtypeuserauthorization);
        Task<ActionResult<TVTypeUserAuthorization>> Put(TVTypeUserAuthorization tvtypeuserauthorization);
    }
    public partial class TVTypeUserAuthorizationDBService : ControllerBase, ITVTypeUserAuthorizationDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationDBService(ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<TVTypeUserAuthorization>> GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(int TVTypeUserAuthorizationID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            TVTypeUserAuthorization tvTypeUserAuthorization = (from c in db.TVTypeUserAuthorizations.AsNoTracking()
                    where c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID
                    select c).FirstOrDefault();

            if (tvTypeUserAuthorization == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(tvTypeUserAuthorization));
        }
        public async Task<ActionResult<List<TVTypeUserAuthorization>>> GetTVTypeUserAuthorizationList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = (from c in db.TVTypeUserAuthorizations.AsNoTracking() orderby c.TVTypeUserAuthorizationID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(tvTypeUserAuthorizationList));
        }
        public async Task<ActionResult<bool>> Delete(int TVTypeUserAuthorizationID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVTypeUserAuthorization tvTypeUserAuthorization = (from c in db.TVTypeUserAuthorizations
                    where c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID
                    select c).FirstOrDefault();

            if (tvTypeUserAuthorization == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVTypeUserAuthorization", "TVTypeUserAuthorizationID", TVTypeUserAuthorizationID.ToString())));
            }

            try
            {
                db.TVTypeUserAuthorizations.Remove(tvTypeUserAuthorization);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<TVTypeUserAuthorization>> Post(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvTypeUserAuthorization), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.TVTypeUserAuthorizations.Add(tvTypeUserAuthorization);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvTypeUserAuthorization));
        }
        public async Task<ActionResult<TVTypeUserAuthorization>> Put(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvTypeUserAuthorization), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.TVTypeUserAuthorizations.Update(tvTypeUserAuthorization);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvTypeUserAuthorization));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            TVTypeUserAuthorization tvTypeUserAuthorization = validationContext.ObjectInstance as TVTypeUserAuthorization;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvTypeUserAuthorization.TVTypeUserAuthorizationID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVTypeUserAuthorizationID"), new[] { nameof(tvTypeUserAuthorization.TVTypeUserAuthorizationID) });
                }

                if (!(from c in db.TVTypeUserAuthorizations select c).Where(c => c.TVTypeUserAuthorizationID == tvTypeUserAuthorization.TVTypeUserAuthorizationID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVTypeUserAuthorization", "TVTypeUserAuthorizationID", tvTypeUserAuthorization.TVTypeUserAuthorizationID.ToString()), new[] { nameof(tvTypeUserAuthorization.TVTypeUserAuthorizationID) });
                }
            }

            TVItem TVItemContactTVItemID = null;
            TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == tvTypeUserAuthorization.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactTVItemID", tvTypeUserAuthorization.ContactTVItemID.ToString()), new[] { nameof(tvTypeUserAuthorization.ContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ContactTVItemID", "Contact"), new[] { nameof(tvTypeUserAuthorization.ContactTVItemID) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvTypeUserAuthorization.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), new[] { nameof(tvTypeUserAuthorization.TVType) });
            }

            retStr = enums.EnumTypeOK(typeof(TVAuthEnum), (int?)tvTypeUserAuthorization.TVAuth);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVAuth"), new[] { nameof(tvTypeUserAuthorization.TVAuth) });
            }

            if (tvTypeUserAuthorization.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(tvTypeUserAuthorization.LastUpdateDate_UTC) });
            }
            else
            {
                if (tvTypeUserAuthorization.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(tvTypeUserAuthorization.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvTypeUserAuthorization.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvTypeUserAuthorization.LastUpdateContactTVItemID.ToString()), new[] { nameof(tvTypeUserAuthorization.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(tvTypeUserAuthorization.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
