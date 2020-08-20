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
   public partial interface ITVFileLanguageService
    {
       Task<ActionResult<bool>> Delete(int TVFileLanguageID);
       Task<ActionResult<List<TVFileLanguage>>> GetTVFileLanguageList(int skip = 0, int take = 100);
       Task<ActionResult<TVFileLanguage>> GetTVFileLanguageWithTVFileLanguageID(int TVFileLanguageID);
       Task<ActionResult<TVFileLanguage>> Post(TVFileLanguage tvfilelanguage);
       Task<ActionResult<TVFileLanguage>> Put(TVFileLanguage tvfilelanguage);
    }
    public partial class TVFileLanguageService : ControllerBase, ITVFileLanguageService
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
        public TVFileLanguageService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal = null, CSSPDBInMemoryContext dbIM = null)
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
        public async Task<ActionResult<TVFileLanguage>> GetTVFileLanguageWithTVFileLanguageID(int TVFileLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                TVFileLanguage tvFileLanguage = (from c in dbIM.TVFileLanguages.AsNoTracking()
                                   where c.TVFileLanguageID == TVFileLanguageID
                                   select c).FirstOrDefault();

                if (tvFileLanguage == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvFileLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVFileLanguage tvFileLanguage = (from c in dbLocal.TVFileLanguages.AsNoTracking()
                        where c.TVFileLanguageID == TVFileLanguageID
                        select c).FirstOrDefault();

                if (tvFileLanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvFileLanguage));
            }
            else
            {
                TVFileLanguage tvFileLanguage = (from c in db.TVFileLanguages.AsNoTracking()
                        where c.TVFileLanguageID == TVFileLanguageID
                        select c).FirstOrDefault();

                if (tvFileLanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvFileLanguage));
            }
        }
        public async Task<ActionResult<List<TVFileLanguage>>> GetTVFileLanguageList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<TVFileLanguage> tvFileLanguageList = (from c in dbIM.TVFileLanguages.AsNoTracking() orderby c.TVFileLanguageID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(tvFileLanguageList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<TVFileLanguage> tvFileLanguageList = (from c in dbLocal.TVFileLanguages.AsNoTracking() orderby c.TVFileLanguageID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(tvFileLanguageList));
            }
            else
            {
                List<TVFileLanguage> tvFileLanguageList = (from c in db.TVFileLanguages.AsNoTracking() orderby c.TVFileLanguageID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(tvFileLanguageList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int TVFileLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                TVFileLanguage tvFileLanguage = (from c in dbIM.TVFileLanguages
                                   where c.TVFileLanguageID == TVFileLanguageID
                                   select c).FirstOrDefault();
            
                if (tvFileLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageID", TVFileLanguageID.ToString())));
                }
            
                try
                {
                    dbIM.TVFileLanguages.Remove(tvFileLanguage);
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
                TVFileLanguage tvFileLanguage = (from c in dbLocal.TVFileLanguages
                                   where c.TVFileLanguageID == TVFileLanguageID
                                   select c).FirstOrDefault();
                
                if (tvFileLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageID", TVFileLanguageID.ToString())));
                }

                try
                {
                   dbLocal.TVFileLanguages.Remove(tvFileLanguage);
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
                TVFileLanguage tvFileLanguage = (from c in db.TVFileLanguages
                                   where c.TVFileLanguageID == TVFileLanguageID
                                   select c).FirstOrDefault();
                
                if (tvFileLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageID", TVFileLanguageID.ToString())));
                }

                try
                {
                   db.TVFileLanguages.Remove(tvFileLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<TVFileLanguage>> Post(TVFileLanguage tvFileLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvFileLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.TVFileLanguages.Add(tvFileLanguage);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvFileLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.TVFileLanguages.Add(tvFileLanguage);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvFileLanguage));
            }
            else
            {
                try
                {
                   db.TVFileLanguages.Add(tvFileLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvFileLanguage));
            }
        }
        public async Task<ActionResult<TVFileLanguage>> Put(TVFileLanguage tvFileLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvFileLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.TVFileLanguages.Update(tvFileLanguage);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvFileLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.TVFileLanguages.Update(tvFileLanguage);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvFileLanguage));
            }
            else
            {
            try
            {
               db.TVFileLanguages.Update(tvFileLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvFileLanguage));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            TVFileLanguage tvFileLanguage = validationContext.ObjectInstance as TVFileLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvFileLanguage.TVFileLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVFileLanguageID"), new[] { nameof(tvFileLanguage.TVFileLanguageID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.TVFileLanguages select c).Where(c => c.TVFileLanguageID == tvFileLanguage.TVFileLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageID", tvFileLanguage.TVFileLanguageID.ToString()), new[] { nameof(tvFileLanguage.TVFileLanguageID) });
                    }
                }
                else
                {
                    if (!(from c in db.TVFileLanguages select c).Where(c => c.TVFileLanguageID == tvFileLanguage.TVFileLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageID", tvFileLanguage.TVFileLanguageID.ToString()), new[] { nameof(tvFileLanguage.TVFileLanguageID) });
                    }
                }
            }

            TVFile TVFileTVFileID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVFileTVFileID = (from c in dbLocal.TVFiles where c.TVFileID == tvFileLanguage.TVFileID select c).FirstOrDefault();
                if (TVFileTVFileID == null)
                {
                    TVFileTVFileID = (from c in dbIM.TVFiles where c.TVFileID == tvFileLanguage.TVFileID select c).FirstOrDefault();
                }
            }
            else
            {
                TVFileTVFileID = (from c in db.TVFiles where c.TVFileID == tvFileLanguage.TVFileID select c).FirstOrDefault();
            }

            if (TVFileTVFileID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileID", tvFileLanguage.TVFileID.ToString()), new[] { nameof(tvFileLanguage.TVFileID) });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvFileLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(tvFileLanguage.Language) });
            }

            //FileDescription has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)tvFileLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { nameof(tvFileLanguage.TranslationStatus) });
            }

            if (tvFileLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(tvFileLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (tvFileLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(tvFileLanguage.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tvFileLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == tvFileLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvFileLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvFileLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(tvFileLanguage.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(tvFileLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
