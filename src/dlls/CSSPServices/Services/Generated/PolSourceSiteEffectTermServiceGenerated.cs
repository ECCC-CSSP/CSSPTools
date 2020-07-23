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
   public partial interface IPolSourceSiteEffectTermService
    {
       Task<ActionResult<bool>> Delete(int PolSourceSiteEffectTermID);
       Task<ActionResult<List<PolSourceSiteEffectTerm>>> GetPolSourceSiteEffectTermList(int skip = 0, int take = 100);
       Task<ActionResult<PolSourceSiteEffectTerm>> GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermID(int PolSourceSiteEffectTermID);
       Task<ActionResult<PolSourceSiteEffectTerm>> Post(PolSourceSiteEffectTerm polsourcesiteeffectterm);
       Task<ActionResult<PolSourceSiteEffectTerm>> Put(PolSourceSiteEffectTerm polsourcesiteeffectterm);
    }
    public partial class PolSourceSiteEffectTermService : ControllerBase, IPolSourceSiteEffectTermService
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
        public PolSourceSiteEffectTermService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<PolSourceSiteEffectTerm>> GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermID(int PolSourceSiteEffectTermID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                PolSourceSiteEffectTerm polSourceSiteEffectTerm = (from c in dbIM.PolSourceSiteEffectTerms.AsNoTracking()
                                   where c.PolSourceSiteEffectTermID == PolSourceSiteEffectTermID
                                   select c).FirstOrDefault();

                if (polSourceSiteEffectTerm == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(polSourceSiteEffectTerm));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                PolSourceSiteEffectTerm polSourceSiteEffectTerm = (from c in dbLocal.PolSourceSiteEffectTerms.AsNoTracking()
                        where c.PolSourceSiteEffectTermID == PolSourceSiteEffectTermID
                        select c).FirstOrDefault();

                if (polSourceSiteEffectTerm == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(polSourceSiteEffectTerm));
            }
            else
            {
                PolSourceSiteEffectTerm polSourceSiteEffectTerm = (from c in db.PolSourceSiteEffectTerms.AsNoTracking()
                        where c.PolSourceSiteEffectTermID == PolSourceSiteEffectTermID
                        select c).FirstOrDefault();

                if (polSourceSiteEffectTerm == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(polSourceSiteEffectTerm));
            }
        }
        public async Task<ActionResult<List<PolSourceSiteEffectTerm>>> GetPolSourceSiteEffectTermList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<PolSourceSiteEffectTerm> polSourceSiteEffectTermList = (from c in dbIM.PolSourceSiteEffectTerms.AsNoTracking() orderby c.PolSourceSiteEffectTermID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(polSourceSiteEffectTermList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<PolSourceSiteEffectTerm> polSourceSiteEffectTermList = (from c in dbLocal.PolSourceSiteEffectTerms.AsNoTracking() orderby c.PolSourceSiteEffectTermID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(polSourceSiteEffectTermList));
            }
            else
            {
                List<PolSourceSiteEffectTerm> polSourceSiteEffectTermList = (from c in db.PolSourceSiteEffectTerms.AsNoTracking() orderby c.PolSourceSiteEffectTermID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(polSourceSiteEffectTermList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int PolSourceSiteEffectTermID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                PolSourceSiteEffectTerm polSourceSiteEffectTerm = (from c in dbIM.PolSourceSiteEffectTerms
                                   where c.PolSourceSiteEffectTermID == PolSourceSiteEffectTermID
                                   select c).FirstOrDefault();
            
                if (polSourceSiteEffectTerm == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffectTerm", "PolSourceSiteEffectTermID", PolSourceSiteEffectTermID.ToString())));
                }
            
                try
                {
                    dbIM.PolSourceSiteEffectTerms.Remove(polSourceSiteEffectTerm);
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
                PolSourceSiteEffectTerm polSourceSiteEffectTerm = (from c in dbLocal.PolSourceSiteEffectTerms
                                   where c.PolSourceSiteEffectTermID == PolSourceSiteEffectTermID
                                   select c).FirstOrDefault();
                
                if (polSourceSiteEffectTerm == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffectTerm", "PolSourceSiteEffectTermID", PolSourceSiteEffectTermID.ToString())));
                }

                try
                {
                   dbLocal.PolSourceSiteEffectTerms.Remove(polSourceSiteEffectTerm);
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
                PolSourceSiteEffectTerm polSourceSiteEffectTerm = (from c in db.PolSourceSiteEffectTerms
                                   where c.PolSourceSiteEffectTermID == PolSourceSiteEffectTermID
                                   select c).FirstOrDefault();
                
                if (polSourceSiteEffectTerm == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffectTerm", "PolSourceSiteEffectTermID", PolSourceSiteEffectTermID.ToString())));
                }

                try
                {
                   db.PolSourceSiteEffectTerms.Remove(polSourceSiteEffectTerm);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Post(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceSiteEffectTerm), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.PolSourceSiteEffectTerms.Add(polSourceSiteEffectTerm);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceSiteEffectTerm));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.PolSourceSiteEffectTerms.Add(polSourceSiteEffectTerm);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceSiteEffectTerm));
            }
            else
            {
                try
                {
                   db.PolSourceSiteEffectTerms.Add(polSourceSiteEffectTerm);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceSiteEffectTerm));
            }
        }
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Put(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceSiteEffectTerm), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.PolSourceSiteEffectTerms.Update(polSourceSiteEffectTerm);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceSiteEffectTerm));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.PolSourceSiteEffectTerms.Update(polSourceSiteEffectTerm);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceSiteEffectTerm));
            }
            else
            {
            try
            {
               db.PolSourceSiteEffectTerms.Update(polSourceSiteEffectTerm);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceSiteEffectTerm));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            PolSourceSiteEffectTerm polSourceSiteEffectTerm = validationContext.ObjectInstance as PolSourceSiteEffectTerm;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceSiteEffectTerm.PolSourceSiteEffectTermID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceSiteEffectTermID"), new[] { nameof(polSourceSiteEffectTerm.PolSourceSiteEffectTermID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.PolSourceSiteEffectTerms select c).Where(c => c.PolSourceSiteEffectTermID == polSourceSiteEffectTerm.PolSourceSiteEffectTermID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffectTerm", "PolSourceSiteEffectTermID", polSourceSiteEffectTerm.PolSourceSiteEffectTermID.ToString()), new[] { nameof(polSourceSiteEffectTerm.PolSourceSiteEffectTermID) });
                    }
                }
                else
                {
                    if (!(from c in db.PolSourceSiteEffectTerms select c).Where(c => c.PolSourceSiteEffectTermID == polSourceSiteEffectTerm.PolSourceSiteEffectTermID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffectTerm", "PolSourceSiteEffectTermID", polSourceSiteEffectTerm.PolSourceSiteEffectTermID.ToString()), new[] { nameof(polSourceSiteEffectTerm.PolSourceSiteEffectTermID) });
                    }
                }
            }

            if (polSourceSiteEffectTerm.UnderGroupID != null)
            {
                PolSourceSiteEffectTerm PolSourceSiteEffectTermUnderGroupID = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    PolSourceSiteEffectTermUnderGroupID = (from c in dbLocal.PolSourceSiteEffectTerms where c.PolSourceSiteEffectTermID == polSourceSiteEffectTerm.UnderGroupID select c).FirstOrDefault();
                    if (PolSourceSiteEffectTermUnderGroupID == null)
                    {
                        PolSourceSiteEffectTermUnderGroupID = (from c in dbIM.PolSourceSiteEffectTerms where c.PolSourceSiteEffectTermID == polSourceSiteEffectTerm.UnderGroupID select c).FirstOrDefault();
                    }
                }
                else
                {
                    PolSourceSiteEffectTermUnderGroupID = (from c in db.PolSourceSiteEffectTerms where c.PolSourceSiteEffectTermID == polSourceSiteEffectTerm.UnderGroupID select c).FirstOrDefault();
                }

                if (PolSourceSiteEffectTermUnderGroupID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffectTerm", "UnderGroupID", (polSourceSiteEffectTerm.UnderGroupID == null ? "" : polSourceSiteEffectTerm.UnderGroupID.ToString())), new[] { nameof(polSourceSiteEffectTerm.UnderGroupID) });
                }
            }

            if (string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermEN))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EffectTermEN"), new[] { nameof(polSourceSiteEffectTerm.EffectTermEN) });
            }

            if (!string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermEN) && polSourceSiteEffectTerm.EffectTermEN.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "EffectTermEN", "100"), new[] { nameof(polSourceSiteEffectTerm.EffectTermEN) });
            }

            if (string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermFR))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EffectTermFR"), new[] { nameof(polSourceSiteEffectTerm.EffectTermFR) });
            }

            if (!string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermFR) && polSourceSiteEffectTerm.EffectTermFR.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "EffectTermFR", "100"), new[] { nameof(polSourceSiteEffectTerm.EffectTermFR) });
            }

            if (polSourceSiteEffectTerm.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(polSourceSiteEffectTerm.LastUpdateDate_UTC) });
            }
            else
            {
                if (polSourceSiteEffectTerm.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(polSourceSiteEffectTerm.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == polSourceSiteEffectTerm.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == polSourceSiteEffectTerm.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSiteEffectTerm.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceSiteEffectTerm.LastUpdateContactTVItemID.ToString()), new[] { nameof(polSourceSiteEffectTerm.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(polSourceSiteEffectTerm.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}