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
   public partial interface IPolSourceSiteService
    {
       Task<ActionResult<bool>> Delete(int PolSourceSiteID);
       Task<ActionResult<List<PolSourceSite>>> GetPolSourceSiteList(int skip = 0, int take = 100);
       Task<ActionResult<PolSourceSite>> GetPolSourceSiteWithPolSourceSiteID(int PolSourceSiteID);
       Task<ActionResult<PolSourceSite>> Post(PolSourceSite polsourcesite);
       Task<ActionResult<PolSourceSite>> Put(PolSourceSite polsourcesite);
    }
    public partial class PolSourceSiteService : ControllerBase, IPolSourceSiteService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBInMemoryContext dbIM { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal = null, CSSPDBInMemoryContext dbIM = null)
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
        public async Task<ActionResult<PolSourceSite>> GetPolSourceSiteWithPolSourceSiteID(int PolSourceSiteID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                PolSourceSite polSourceSite = (from c in dbIM.PolSourceSites.AsNoTracking()
                                   where c.PolSourceSiteID == PolSourceSiteID
                                   select c).FirstOrDefault();

                if (polSourceSite == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(polSourceSite));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                PolSourceSite polSourceSite = (from c in dbLocal.PolSourceSites.AsNoTracking()
                        where c.PolSourceSiteID == PolSourceSiteID
                        select c).FirstOrDefault();

                if (polSourceSite == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(polSourceSite));
            }
            else
            {
                PolSourceSite polSourceSite = (from c in db.PolSourceSites.AsNoTracking()
                        where c.PolSourceSiteID == PolSourceSiteID
                        select c).FirstOrDefault();

                if (polSourceSite == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(polSourceSite));
            }
        }
        public async Task<ActionResult<List<PolSourceSite>>> GetPolSourceSiteList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<PolSourceSite> polSourceSiteList = (from c in dbIM.PolSourceSites.AsNoTracking() orderby c.PolSourceSiteID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(polSourceSiteList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<PolSourceSite> polSourceSiteList = (from c in dbLocal.PolSourceSites.AsNoTracking() orderby c.PolSourceSiteID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(polSourceSiteList));
            }
            else
            {
                List<PolSourceSite> polSourceSiteList = (from c in db.PolSourceSites.AsNoTracking() orderby c.PolSourceSiteID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(polSourceSiteList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int PolSourceSiteID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                PolSourceSite polSourceSite = (from c in dbIM.PolSourceSites
                                   where c.PolSourceSiteID == PolSourceSiteID
                                   select c).FirstOrDefault();
            
                if (polSourceSite == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSiteID", PolSourceSiteID.ToString())));
                }
            
                try
                {
                    dbIM.PolSourceSites.Remove(polSourceSite);
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
                PolSourceSite polSourceSite = (from c in dbLocal.PolSourceSites
                                   where c.PolSourceSiteID == PolSourceSiteID
                                   select c).FirstOrDefault();
                
                if (polSourceSite == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSiteID", PolSourceSiteID.ToString())));
                }

                try
                {
                   dbLocal.PolSourceSites.Remove(polSourceSite);
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
                PolSourceSite polSourceSite = (from c in db.PolSourceSites
                                   where c.PolSourceSiteID == PolSourceSiteID
                                   select c).FirstOrDefault();
                
                if (polSourceSite == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSiteID", PolSourceSiteID.ToString())));
                }

                try
                {
                   db.PolSourceSites.Remove(polSourceSite);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<PolSourceSite>> Post(PolSourceSite polSourceSite)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceSite), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.PolSourceSites.Add(polSourceSite);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceSite));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.PolSourceSites.Add(polSourceSite);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceSite));
            }
            else
            {
                try
                {
                   db.PolSourceSites.Add(polSourceSite);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceSite));
            }
        }
        public async Task<ActionResult<PolSourceSite>> Put(PolSourceSite polSourceSite)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceSite), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.PolSourceSites.Update(polSourceSite);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceSite));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.PolSourceSites.Update(polSourceSite);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceSite));
            }
            else
            {
            try
            {
               db.PolSourceSites.Update(polSourceSite);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceSite));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            PolSourceSite polSourceSite = validationContext.ObjectInstance as PolSourceSite;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceSite.PolSourceSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceSiteID"), new[] { nameof(polSourceSite.PolSourceSiteID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.PolSourceSites select c).Where(c => c.PolSourceSiteID == polSourceSite.PolSourceSiteID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSiteID", polSourceSite.PolSourceSiteID.ToString()), new[] { nameof(polSourceSite.PolSourceSiteID) });
                    }
                }
                else
                {
                    if (!(from c in db.PolSourceSites select c).Where(c => c.PolSourceSiteID == polSourceSite.PolSourceSiteID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSiteID", polSourceSite.PolSourceSiteID.ToString()), new[] { nameof(polSourceSite.PolSourceSiteID) });
                    }
                }
            }

            TVItem TVItemPolSourceSiteTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemPolSourceSiteTVItemID = (from c in dbLocal.TVItems where c.TVItemID == polSourceSite.PolSourceSiteTVItemID select c).FirstOrDefault();
                if (TVItemPolSourceSiteTVItemID == null)
                {
                    TVItemPolSourceSiteTVItemID = (from c in dbIM.TVItems where c.TVItemID == polSourceSite.PolSourceSiteTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemPolSourceSiteTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSite.PolSourceSiteTVItemID select c).FirstOrDefault();
            }

            if (TVItemPolSourceSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceSiteTVItemID", polSourceSite.PolSourceSiteTVItemID.ToString()), new[] { nameof(polSourceSite.PolSourceSiteTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.PolSourceSite,
                };
                if (!AllowableTVTypes.Contains(TVItemPolSourceSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "PolSourceSiteTVItemID", "PolSourceSite"), new[] { nameof(polSourceSite.PolSourceSiteTVItemID) });
                }
            }

            if (!string.IsNullOrWhiteSpace(polSourceSite.Temp_Locator_CanDelete) && polSourceSite.Temp_Locator_CanDelete.Length > 50)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Temp_Locator_CanDelete", "50"), new[] { nameof(polSourceSite.Temp_Locator_CanDelete) });
            }

            if (polSourceSite.Oldsiteid != null)
            {
                if (polSourceSite.Oldsiteid < 0 || polSourceSite.Oldsiteid > 1000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Oldsiteid", "0", "1000"), new[] { nameof(polSourceSite.Oldsiteid) });
                }
            }

            if (polSourceSite.Site != null)
            {
                if (polSourceSite.Site < 0 || polSourceSite.Site > 1000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Site", "0", "1000"), new[] { nameof(polSourceSite.Site) });
                }
            }

            if (polSourceSite.SiteID != null)
            {
                if (polSourceSite.SiteID < 0 || polSourceSite.SiteID > 1000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SiteID", "0", "1000"), new[] { nameof(polSourceSite.SiteID) });
                }
            }

            if (polSourceSite.InactiveReason != null)
            {
                retStr = enums.EnumTypeOK(typeof(PolSourceInactiveReasonEnum), (int?)polSourceSite.InactiveReason);
                if (polSourceSite.InactiveReason == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "InactiveReason"), new[] { nameof(polSourceSite.InactiveReason) });
                }
            }

            if (polSourceSite.CivicAddressTVItemID != null)
            {
                TVItem TVItemCivicAddressTVItemID = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    TVItemCivicAddressTVItemID = (from c in dbLocal.TVItems where c.TVItemID == polSourceSite.CivicAddressTVItemID select c).FirstOrDefault();
                    if (TVItemCivicAddressTVItemID == null)
                    {
                        TVItemCivicAddressTVItemID = (from c in dbIM.TVItems where c.TVItemID == polSourceSite.CivicAddressTVItemID select c).FirstOrDefault();
                    }
                }
                else
                {
                    TVItemCivicAddressTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSite.CivicAddressTVItemID select c).FirstOrDefault();
                }

                if (TVItemCivicAddressTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "CivicAddressTVItemID", (polSourceSite.CivicAddressTVItemID == null ? "" : polSourceSite.CivicAddressTVItemID.ToString())), new[] { nameof(polSourceSite.CivicAddressTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Address,
                    };
                    if (!AllowableTVTypes.Contains(TVItemCivicAddressTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "CivicAddressTVItemID", "Address"), new[] { nameof(polSourceSite.CivicAddressTVItemID) });
                    }
                }
            }

            if (polSourceSite.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(polSourceSite.LastUpdateDate_UTC) });
            }
            else
            {
                if (polSourceSite.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(polSourceSite.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == polSourceSite.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == polSourceSite.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSite.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceSite.LastUpdateContactTVItemID.ToString()), new[] { nameof(polSourceSite.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(polSourceSite.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
