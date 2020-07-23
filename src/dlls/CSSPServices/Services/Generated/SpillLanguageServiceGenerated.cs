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
   public partial interface ISpillLanguageService
    {
       Task<ActionResult<bool>> Delete(int SpillLanguageID);
       Task<ActionResult<List<SpillLanguage>>> GetSpillLanguageList(int skip = 0, int take = 100);
       Task<ActionResult<SpillLanguage>> GetSpillLanguageWithSpillLanguageID(int SpillLanguageID);
       Task<ActionResult<SpillLanguage>> Post(SpillLanguage spilllanguage);
       Task<ActionResult<SpillLanguage>> Put(SpillLanguage spilllanguage);
    }
    public partial class SpillLanguageService : ControllerBase, ISpillLanguageService
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
        public SpillLanguageService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<SpillLanguage>> GetSpillLanguageWithSpillLanguageID(int SpillLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                SpillLanguage spillLanguage = (from c in dbIM.SpillLanguages.AsNoTracking()
                                   where c.SpillLanguageID == SpillLanguageID
                                   select c).FirstOrDefault();

                if (spillLanguage == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(spillLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                SpillLanguage spillLanguage = (from c in dbLocal.SpillLanguages.AsNoTracking()
                        where c.SpillLanguageID == SpillLanguageID
                        select c).FirstOrDefault();

                if (spillLanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(spillLanguage));
            }
            else
            {
                SpillLanguage spillLanguage = (from c in db.SpillLanguages.AsNoTracking()
                        where c.SpillLanguageID == SpillLanguageID
                        select c).FirstOrDefault();

                if (spillLanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(spillLanguage));
            }
        }
        public async Task<ActionResult<List<SpillLanguage>>> GetSpillLanguageList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<SpillLanguage> spillLanguageList = (from c in dbIM.SpillLanguages.AsNoTracking() orderby c.SpillLanguageID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(spillLanguageList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<SpillLanguage> spillLanguageList = (from c in dbLocal.SpillLanguages.AsNoTracking() orderby c.SpillLanguageID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(spillLanguageList));
            }
            else
            {
                List<SpillLanguage> spillLanguageList = (from c in db.SpillLanguages.AsNoTracking() orderby c.SpillLanguageID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(spillLanguageList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int SpillLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                SpillLanguage spillLanguage = (from c in dbIM.SpillLanguages
                                   where c.SpillLanguageID == SpillLanguageID
                                   select c).FirstOrDefault();
            
                if (spillLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SpillLanguage", "SpillLanguageID", SpillLanguageID.ToString())));
                }
            
                try
                {
                    dbIM.SpillLanguages.Remove(spillLanguage);
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
                SpillLanguage spillLanguage = (from c in dbLocal.SpillLanguages
                                   where c.SpillLanguageID == SpillLanguageID
                                   select c).FirstOrDefault();
                
                if (spillLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SpillLanguage", "SpillLanguageID", SpillLanguageID.ToString())));
                }

                try
                {
                   dbLocal.SpillLanguages.Remove(spillLanguage);
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
                SpillLanguage spillLanguage = (from c in db.SpillLanguages
                                   where c.SpillLanguageID == SpillLanguageID
                                   select c).FirstOrDefault();
                
                if (spillLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SpillLanguage", "SpillLanguageID", SpillLanguageID.ToString())));
                }

                try
                {
                   db.SpillLanguages.Remove(spillLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<SpillLanguage>> Post(SpillLanguage spillLanguage)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(spillLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.SpillLanguages.Add(spillLanguage);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(spillLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.SpillLanguages.Add(spillLanguage);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(spillLanguage));
            }
            else
            {
                try
                {
                   db.SpillLanguages.Add(spillLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(spillLanguage));
            }
        }
        public async Task<ActionResult<SpillLanguage>> Put(SpillLanguage spillLanguage)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(spillLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.SpillLanguages.Update(spillLanguage);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(spillLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.SpillLanguages.Update(spillLanguage);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(spillLanguage));
            }
            else
            {
            try
            {
               db.SpillLanguages.Update(spillLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(spillLanguage));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            SpillLanguage spillLanguage = validationContext.ObjectInstance as SpillLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (spillLanguage.SpillLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SpillLanguageID"), new[] { nameof(spillLanguage.SpillLanguageID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.SpillLanguages select c).Where(c => c.SpillLanguageID == spillLanguage.SpillLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SpillLanguage", "SpillLanguageID", spillLanguage.SpillLanguageID.ToString()), new[] { nameof(spillLanguage.SpillLanguageID) });
                    }
                }
                else
                {
                    if (!(from c in db.SpillLanguages select c).Where(c => c.SpillLanguageID == spillLanguage.SpillLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SpillLanguage", "SpillLanguageID", spillLanguage.SpillLanguageID.ToString()), new[] { nameof(spillLanguage.SpillLanguageID) });
                    }
                }
            }

            Spill SpillSpillID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                SpillSpillID = (from c in dbLocal.Spills where c.SpillID == spillLanguage.SpillID select c).FirstOrDefault();
                if (SpillSpillID == null)
                {
                    SpillSpillID = (from c in dbIM.Spills where c.SpillID == spillLanguage.SpillID select c).FirstOrDefault();
                }
            }
            else
            {
                SpillSpillID = (from c in db.Spills where c.SpillID == spillLanguage.SpillID select c).FirstOrDefault();
            }

            if (SpillSpillID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillID", spillLanguage.SpillID.ToString()), new[] { nameof(spillLanguage.SpillID) });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)spillLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(spillLanguage.Language) });
            }

            if (string.IsNullOrWhiteSpace(spillLanguage.SpillComment))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SpillComment"), new[] { nameof(spillLanguage.SpillComment) });
            }

            //SpillComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)spillLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { nameof(spillLanguage.TranslationStatus) });
            }

            if (spillLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(spillLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (spillLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(spillLanguage.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == spillLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == spillLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == spillLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", spillLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(spillLanguage.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(spillLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
