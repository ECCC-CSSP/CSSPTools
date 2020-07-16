/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Resources;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
   public partial interface ITVTypeUserAuthorizationService
    {
       Task<ActionResult<bool>> Delete(int TVTypeUserAuthorizationID);
       Task<ActionResult<List<TVTypeUserAuthorization>>> GetTVTypeUserAuthorizationList(int skip = 0, int take = 100);
       Task<ActionResult<TVTypeUserAuthorization>> GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(int TVTypeUserAuthorizationID);
       Task<ActionResult<TVTypeUserAuthorization>> Post(TVTypeUserAuthorization tvtypeuserauthorization);
       Task<ActionResult<TVTypeUserAuthorization>> Put(TVTypeUserAuthorization tvtypeuserauthorization);
    }
    public partial class TVTypeUserAuthorizationService : ControllerBase, ITVTypeUserAuthorizationService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<TVTypeUserAuthorization>> GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(int TVTypeUserAuthorizationID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                TVTypeUserAuthorization tvTypeUserAuthorization = (from c in dbIM.TVTypeUserAuthorizations.AsNoTracking()
                                   where c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID
                                   select c).FirstOrDefault();

                if (tvTypeUserAuthorization == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvTypeUserAuthorization));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVTypeUserAuthorization tvTypeUserAuthorization = (from c in dbLocal.TVTypeUserAuthorizations.AsNoTracking()
                        where c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID
                        select c).FirstOrDefault();

                if (tvTypeUserAuthorization == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvTypeUserAuthorization));
            }
            else
            {
                TVTypeUserAuthorization tvTypeUserAuthorization = (from c in db.TVTypeUserAuthorizations.AsNoTracking()
                        where c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID
                        select c).FirstOrDefault();

                if (tvTypeUserAuthorization == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvTypeUserAuthorization));
            }
        }
        public async Task<ActionResult<List<TVTypeUserAuthorization>>> GetTVTypeUserAuthorizationList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = (from c in dbIM.TVTypeUserAuthorizations.AsNoTracking() orderby c.TVTypeUserAuthorizationID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(tvTypeUserAuthorizationList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = (from c in dbLocal.TVTypeUserAuthorizations.AsNoTracking() orderby c.TVTypeUserAuthorizationID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(tvTypeUserAuthorizationList));
            }
            else
            {
                List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = (from c in db.TVTypeUserAuthorizations.AsNoTracking() orderby c.TVTypeUserAuthorizationID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(tvTypeUserAuthorizationList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int TVTypeUserAuthorizationID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                TVTypeUserAuthorization tvTypeUserAuthorization = (from c in dbIM.TVTypeUserAuthorizations
                                   where c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID
                                   select c).FirstOrDefault();
            
                if (tvTypeUserAuthorization == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVTypeUserAuthorization", "TVTypeUserAuthorizationID", TVTypeUserAuthorizationID.ToString())));
                }
            
                try
                {
                    dbIM.TVTypeUserAuthorizations.Remove(tvTypeUserAuthorization);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }
            
                return await Task.FromResult(Ok(true));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVTypeUserAuthorization tvTypeUserAuthorization = (from c in dbLocal.TVTypeUserAuthorizations
                                   where c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID
                                   select c).FirstOrDefault();
                
                if (tvTypeUserAuthorization == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVTypeUserAuthorization", "TVTypeUserAuthorizationID", TVTypeUserAuthorizationID.ToString())));
                }

                try
                {
                   dbLocal.TVTypeUserAuthorizations.Remove(tvTypeUserAuthorization);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
            else
            {
                TVTypeUserAuthorization tvTypeUserAuthorization = (from c in db.TVTypeUserAuthorizations
                                   where c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID
                                   select c).FirstOrDefault();
                
                if (tvTypeUserAuthorization == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVTypeUserAuthorization", "TVTypeUserAuthorizationID", TVTypeUserAuthorizationID.ToString())));
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
        }
        public async Task<ActionResult<TVTypeUserAuthorization>> Post(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvTypeUserAuthorization), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.TVTypeUserAuthorizations.Add(tvTypeUserAuthorization);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvTypeUserAuthorization));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.TVTypeUserAuthorizations.Add(tvTypeUserAuthorization);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvTypeUserAuthorization));
            }
            else
            {
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
        }
        public async Task<ActionResult<TVTypeUserAuthorization>> Put(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvTypeUserAuthorization), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.TVTypeUserAuthorizations.Update(tvTypeUserAuthorization);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvTypeUserAuthorization));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.TVTypeUserAuthorizations.Update(tvTypeUserAuthorization);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvTypeUserAuthorization));
            }
            else
            {
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
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TVTypeUserAuthorizationID"), new[] { "TVTypeUserAuthorizationID" });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.TVTypeUserAuthorizations select c).Where(c => c.TVTypeUserAuthorizationID == tvTypeUserAuthorization.TVTypeUserAuthorizationID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVTypeUserAuthorization", "TVTypeUserAuthorizationID", tvTypeUserAuthorization.TVTypeUserAuthorizationID.ToString()), new[] { "TVTypeUserAuthorizationID" });
                    }
                }
                else
                {
                    if (!(from c in db.TVTypeUserAuthorizations select c).Where(c => c.TVTypeUserAuthorizationID == tvTypeUserAuthorization.TVTypeUserAuthorizationID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVTypeUserAuthorization", "TVTypeUserAuthorizationID", tvTypeUserAuthorization.TVTypeUserAuthorizationID.ToString()), new[] { "TVTypeUserAuthorizationID" });
                    }
                }
            }

            TVItem TVItemContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tvTypeUserAuthorization.ContactTVItemID select c).FirstOrDefault();
                if (TVItemContactTVItemID == null)
                {
                    TVItemContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == tvTypeUserAuthorization.ContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == tvTypeUserAuthorization.ContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactTVItemID", tvTypeUserAuthorization.ContactTVItemID.ToString()), new[] { "ContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "ContactTVItemID", "Contact"), new[] { "ContactTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvTypeUserAuthorization.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TVType"), new[] { "TVType" });
            }

            retStr = enums.EnumTypeOK(typeof(TVAuthEnum), (int?)tvTypeUserAuthorization.TVAuth);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TVAuth"), new[] { "TVAuth" });
            }

            if (tvTypeUserAuthorization.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvTypeUserAuthorization.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tvTypeUserAuthorization.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == tvTypeUserAuthorization.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvTypeUserAuthorization.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvTypeUserAuthorization.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions private

    }
}
