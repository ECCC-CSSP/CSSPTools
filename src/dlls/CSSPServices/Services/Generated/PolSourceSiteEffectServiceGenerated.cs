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
   public partial interface IPolSourceSiteEffectService
    {
       Task<ActionResult<bool>> Delete(int PolSourceSiteEffectID);
       Task<ActionResult<List<PolSourceSiteEffect>>> GetPolSourceSiteEffectList(int skip = 0, int take = 100);
       Task<ActionResult<PolSourceSiteEffect>> GetPolSourceSiteEffectWithPolSourceSiteEffectID(int PolSourceSiteEffectID);
       Task<ActionResult<PolSourceSiteEffect>> Post(PolSourceSiteEffect polsourcesiteeffect);
       Task<ActionResult<PolSourceSiteEffect>> Put(PolSourceSiteEffect polsourcesiteeffect);
    }
    public partial class PolSourceSiteEffectService : ControllerBase, IPolSourceSiteEffectService
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
        public PolSourceSiteEffectService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal = null, CSSPDBInMemoryContext dbIM = null)
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
        public async Task<ActionResult<PolSourceSiteEffect>> GetPolSourceSiteEffectWithPolSourceSiteEffectID(int PolSourceSiteEffectID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                PolSourceSiteEffect polSourceSiteEffect = (from c in dbIM.PolSourceSiteEffects.AsNoTracking()
                                   where c.PolSourceSiteEffectID == PolSourceSiteEffectID
                                   select c).FirstOrDefault();

                if (polSourceSiteEffect == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(polSourceSiteEffect));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                PolSourceSiteEffect polSourceSiteEffect = (from c in dbLocal.PolSourceSiteEffects.AsNoTracking()
                        where c.PolSourceSiteEffectID == PolSourceSiteEffectID
                        select c).FirstOrDefault();

                if (polSourceSiteEffect == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(polSourceSiteEffect));
            }
            else
            {
                PolSourceSiteEffect polSourceSiteEffect = (from c in db.PolSourceSiteEffects.AsNoTracking()
                        where c.PolSourceSiteEffectID == PolSourceSiteEffectID
                        select c).FirstOrDefault();

                if (polSourceSiteEffect == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(polSourceSiteEffect));
            }
        }
        public async Task<ActionResult<List<PolSourceSiteEffect>>> GetPolSourceSiteEffectList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<PolSourceSiteEffect> polSourceSiteEffectList = (from c in dbIM.PolSourceSiteEffects.AsNoTracking() orderby c.PolSourceSiteEffectID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(polSourceSiteEffectList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<PolSourceSiteEffect> polSourceSiteEffectList = (from c in dbLocal.PolSourceSiteEffects.AsNoTracking() orderby c.PolSourceSiteEffectID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(polSourceSiteEffectList));
            }
            else
            {
                List<PolSourceSiteEffect> polSourceSiteEffectList = (from c in db.PolSourceSiteEffects.AsNoTracking() orderby c.PolSourceSiteEffectID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(polSourceSiteEffectList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int PolSourceSiteEffectID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                PolSourceSiteEffect polSourceSiteEffect = (from c in dbIM.PolSourceSiteEffects
                                   where c.PolSourceSiteEffectID == PolSourceSiteEffectID
                                   select c).FirstOrDefault();
            
                if (polSourceSiteEffect == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffect", "PolSourceSiteEffectID", PolSourceSiteEffectID.ToString())));
                }
            
                try
                {
                    dbIM.PolSourceSiteEffects.Remove(polSourceSiteEffect);
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
                PolSourceSiteEffect polSourceSiteEffect = (from c in dbLocal.PolSourceSiteEffects
                                   where c.PolSourceSiteEffectID == PolSourceSiteEffectID
                                   select c).FirstOrDefault();
                
                if (polSourceSiteEffect == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffect", "PolSourceSiteEffectID", PolSourceSiteEffectID.ToString())));
                }

                try
                {
                   dbLocal.PolSourceSiteEffects.Remove(polSourceSiteEffect);
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
                PolSourceSiteEffect polSourceSiteEffect = (from c in db.PolSourceSiteEffects
                                   where c.PolSourceSiteEffectID == PolSourceSiteEffectID
                                   select c).FirstOrDefault();
                
                if (polSourceSiteEffect == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffect", "PolSourceSiteEffectID", PolSourceSiteEffectID.ToString())));
                }

                try
                {
                   db.PolSourceSiteEffects.Remove(polSourceSiteEffect);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<PolSourceSiteEffect>> Post(PolSourceSiteEffect polSourceSiteEffect)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceSiteEffect), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.PolSourceSiteEffects.Add(polSourceSiteEffect);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceSiteEffect));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.PolSourceSiteEffects.Add(polSourceSiteEffect);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceSiteEffect));
            }
            else
            {
                try
                {
                   db.PolSourceSiteEffects.Add(polSourceSiteEffect);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceSiteEffect));
            }
        }
        public async Task<ActionResult<PolSourceSiteEffect>> Put(PolSourceSiteEffect polSourceSiteEffect)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceSiteEffect), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.PolSourceSiteEffects.Update(polSourceSiteEffect);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceSiteEffect));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.PolSourceSiteEffects.Update(polSourceSiteEffect);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceSiteEffect));
            }
            else
            {
            try
            {
               db.PolSourceSiteEffects.Update(polSourceSiteEffect);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceSiteEffect));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            PolSourceSiteEffect polSourceSiteEffect = validationContext.ObjectInstance as PolSourceSiteEffect;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceSiteEffect.PolSourceSiteEffectID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceSiteEffectID"), new[] { nameof(polSourceSiteEffect.PolSourceSiteEffectID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.PolSourceSiteEffects select c).Where(c => c.PolSourceSiteEffectID == polSourceSiteEffect.PolSourceSiteEffectID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffect", "PolSourceSiteEffectID", polSourceSiteEffect.PolSourceSiteEffectID.ToString()), new[] { nameof(polSourceSiteEffect.PolSourceSiteEffectID) });
                    }
                }
                else
                {
                    if (!(from c in db.PolSourceSiteEffects select c).Where(c => c.PolSourceSiteEffectID == polSourceSiteEffect.PolSourceSiteEffectID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffect", "PolSourceSiteEffectID", polSourceSiteEffect.PolSourceSiteEffectID.ToString()), new[] { nameof(polSourceSiteEffect.PolSourceSiteEffectID) });
                    }
                }
            }

            TVItem TVItemPolSourceSiteOrInfrastructureTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemPolSourceSiteOrInfrastructureTVItemID = (from c in dbLocal.TVItems where c.TVItemID == polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID select c).FirstOrDefault();
                if (TVItemPolSourceSiteOrInfrastructureTVItemID == null)
                {
                    TVItemPolSourceSiteOrInfrastructureTVItemID = (from c in dbIM.TVItems where c.TVItemID == polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemPolSourceSiteOrInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID select c).FirstOrDefault();
            }

            if (TVItemPolSourceSiteOrInfrastructureTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceSiteOrInfrastructureTVItemID", polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID.ToString()), new[] { nameof(polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                    TVTypeEnum.PolSourceSite,
                };
                if (!AllowableTVTypes.Contains(TVItemPolSourceSiteOrInfrastructureTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "PolSourceSiteOrInfrastructureTVItemID", "Infrastructure,PolSourceSite"), new[] { nameof(polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID) });
                }
            }

            TVItem TVItemMWQMSiteTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemMWQMSiteTVItemID = (from c in dbLocal.TVItems where c.TVItemID == polSourceSiteEffect.MWQMSiteTVItemID select c).FirstOrDefault();
                if (TVItemMWQMSiteTVItemID == null)
                {
                    TVItemMWQMSiteTVItemID = (from c in dbIM.TVItems where c.TVItemID == polSourceSiteEffect.MWQMSiteTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSiteEffect.MWQMSiteTVItemID select c).FirstOrDefault();
            }

            if (TVItemMWQMSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteTVItemID", polSourceSiteEffect.MWQMSiteTVItemID.ToString()), new[] { nameof(polSourceSiteEffect.MWQMSiteTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MWQMSiteTVItemID", "MWQMSite"), new[] { nameof(polSourceSiteEffect.MWQMSiteTVItemID) });
                }
            }

            if (!string.IsNullOrWhiteSpace(polSourceSiteEffect.PolSourceSiteEffectTermIDs) && polSourceSiteEffect.PolSourceSiteEffectTermIDs.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "PolSourceSiteEffectTermIDs", "250"), new[] { nameof(polSourceSiteEffect.PolSourceSiteEffectTermIDs) });
            }

            //Comments has no StringLength Attribute

            if (polSourceSiteEffect.AnalysisDocumentTVItemID != null)
            {
                TVItem TVItemAnalysisDocumentTVItemID = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    TVItemAnalysisDocumentTVItemID = (from c in dbLocal.TVItems where c.TVItemID == polSourceSiteEffect.AnalysisDocumentTVItemID select c).FirstOrDefault();
                    if (TVItemAnalysisDocumentTVItemID == null)
                    {
                        TVItemAnalysisDocumentTVItemID = (from c in dbIM.TVItems where c.TVItemID == polSourceSiteEffect.AnalysisDocumentTVItemID select c).FirstOrDefault();
                    }
                }
                else
                {
                    TVItemAnalysisDocumentTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSiteEffect.AnalysisDocumentTVItemID select c).FirstOrDefault();
                }

                if (TVItemAnalysisDocumentTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "AnalysisDocumentTVItemID", (polSourceSiteEffect.AnalysisDocumentTVItemID == null ? "" : polSourceSiteEffect.AnalysisDocumentTVItemID.ToString())), new[] { nameof(polSourceSiteEffect.AnalysisDocumentTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.File,
                    };
                    if (!AllowableTVTypes.Contains(TVItemAnalysisDocumentTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "AnalysisDocumentTVItemID", "File"), new[] { nameof(polSourceSiteEffect.AnalysisDocumentTVItemID) });
                    }
                }
            }

            if (polSourceSiteEffect.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(polSourceSiteEffect.LastUpdateDate_UTC) });
            }
            else
            {
                if (polSourceSiteEffect.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(polSourceSiteEffect.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == polSourceSiteEffect.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == polSourceSiteEffect.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSiteEffect.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceSiteEffect.LastUpdateContactTVItemID.ToString()), new[] { nameof(polSourceSiteEffect.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(polSourceSiteEffect.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
