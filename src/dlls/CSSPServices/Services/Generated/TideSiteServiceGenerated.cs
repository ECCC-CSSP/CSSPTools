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

namespace CSSPServices
{
   public partial interface ITideSiteService
    {
       Task<ActionResult<bool>> Delete(int TideSiteID);
       Task<ActionResult<List<TideSite>>> GetTideSiteList(int skip = 0, int take = 100);
       Task<ActionResult<TideSite>> GetTideSiteWithTideSiteID(int TideSiteID);
       Task<ActionResult<TideSite>> Post(TideSite tidesite);
       Task<ActionResult<TideSite>> Put(TideSite tidesite);
    }
    public partial class TideSiteService : ControllerBase, ITideSiteService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public TideSiteService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<TideSite>> GetTideSiteWithTideSiteID(int TideSiteID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                TideSite tideSite = (from c in dbIM.TideSites.AsNoTracking()
                                   where c.TideSiteID == TideSiteID
                                   select c).FirstOrDefault();

                if (tideSite == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tideSite));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TideSite tideSite = (from c in dbLocal.TideSites.AsNoTracking()
                        where c.TideSiteID == TideSiteID
                        select c).FirstOrDefault();

                if (tideSite == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tideSite));
            }
            else
            {
                TideSite tideSite = (from c in db.TideSites.AsNoTracking()
                        where c.TideSiteID == TideSiteID
                        select c).FirstOrDefault();

                if (tideSite == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tideSite));
            }
        }
        public async Task<ActionResult<List<TideSite>>> GetTideSiteList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<TideSite> tideSiteList = (from c in dbIM.TideSites.AsNoTracking() orderby c.TideSiteID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(tideSiteList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<TideSite> tideSiteList = (from c in dbLocal.TideSites.AsNoTracking() orderby c.TideSiteID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(tideSiteList));
            }
            else
            {
                List<TideSite> tideSiteList = (from c in db.TideSites.AsNoTracking() orderby c.TideSiteID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(tideSiteList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int TideSiteID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                TideSite tideSite = (from c in dbIM.TideSites
                                   where c.TideSiteID == TideSiteID
                                   select c).FirstOrDefault();
            
                if (tideSite == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TideSite", "TideSiteID", TideSiteID.ToString())));
                }
            
                try
                {
                    dbIM.TideSites.Remove(tideSite);
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
                TideSite tideSite = (from c in dbLocal.TideSites
                                   where c.TideSiteID == TideSiteID
                                   select c).FirstOrDefault();
                
                if (tideSite == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TideSite", "TideSiteID", TideSiteID.ToString())));
                }

                try
                {
                   dbLocal.TideSites.Remove(tideSite);
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
                TideSite tideSite = (from c in db.TideSites
                                   where c.TideSiteID == TideSiteID
                                   select c).FirstOrDefault();
                
                if (tideSite == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TideSite", "TideSiteID", TideSiteID.ToString())));
                }

                try
                {
                   db.TideSites.Remove(tideSite);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<TideSite>> Post(TideSite tideSite)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.TideSites.Add(tideSite);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tideSite));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.TideSites.Add(tideSite);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tideSite));
            }
            else
            {
                try
                {
                   db.TideSites.Add(tideSite);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tideSite));
            }
        }
        public async Task<ActionResult<TideSite>> Put(TideSite tideSite)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.TideSites.Update(tideSite);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tideSite));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.TideSites.Update(tideSite);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tideSite));
            }
            else
            {
            try
            {
               db.TideSites.Update(tideSite);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tideSite));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            TideSite tideSite = validationContext.ObjectInstance as TideSite;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tideSite.TideSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TideSiteID"), new[] { nameof(tideSite.TideSiteID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.TideSites select c).Where(c => c.TideSiteID == tideSite.TideSiteID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TideSite", "TideSiteID", tideSite.TideSiteID.ToString()), new[] { nameof(tideSite.TideSiteID) });
                    }
                }
                else
                {
                    if (!(from c in db.TideSites select c).Where(c => c.TideSiteID == tideSite.TideSiteID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TideSite", "TideSiteID", tideSite.TideSiteID.ToString()), new[] { nameof(tideSite.TideSiteID) });
                    }
                }
            }

            TVItem TVItemTideSiteTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemTideSiteTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tideSite.TideSiteTVItemID select c).FirstOrDefault();
                if (TVItemTideSiteTVItemID == null)
                {
                    TVItemTideSiteTVItemID = (from c in dbIM.TVItems where c.TVItemID == tideSite.TideSiteTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemTideSiteTVItemID = (from c in db.TVItems where c.TVItemID == tideSite.TideSiteTVItemID select c).FirstOrDefault();
            }

            if (TVItemTideSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TideSiteTVItemID", tideSite.TideSiteTVItemID.ToString()), new[] { nameof(tideSite.TideSiteTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.TideSite,
                };
                if (!AllowableTVTypes.Contains(TVItemTideSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TideSiteTVItemID", "TideSite"), new[] { nameof(tideSite.TideSiteTVItemID) });
                }
            }

            if (string.IsNullOrWhiteSpace(tideSite.TideSiteName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TideSiteName"), new[] { nameof(tideSite.TideSiteName) });
            }

            if (!string.IsNullOrWhiteSpace(tideSite.TideSiteName) && tideSite.TideSiteName.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TideSiteName", "100"), new[] { nameof(tideSite.TideSiteName) });
            }

            if (string.IsNullOrWhiteSpace(tideSite.Province))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Province"), new[] { nameof(tideSite.Province) });
            }

            if (!string.IsNullOrWhiteSpace(tideSite.Province) && (tideSite.Province.Length < 2 || tideSite.Province.Length > 2))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Province", "2", "2"), new[] { nameof(tideSite.Province) });
            }

            if (tideSite.sid < 0 || tideSite.sid > 10000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "sid", "0", "10000"), new[] { nameof(tideSite.sid) });
            }

            if (tideSite.Zone < 0 || tideSite.Zone > 10000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Zone", "0", "10000"), new[] { nameof(tideSite.Zone) });
            }

            if (tideSite.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(tideSite.LastUpdateDate_UTC) });
            }
            else
            {
                if (tideSite.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(tideSite.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tideSite.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == tideSite.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tideSite.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tideSite.LastUpdateContactTVItemID.ToString()), new[] { nameof(tideSite.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(tideSite.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}