/*
 * Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
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
   public interface ITVFileLanguageService
    {
       Task<ActionResult<bool>> Delete(int TVFileLanguageID);
       Task<ActionResult<List<TVFileLanguage>>> GetTVFileLanguageList();
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
        private InMemoryDBContext dbIM { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileLanguageService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<TVFileLanguage>> GetTVFileLanguageWithTVFileLanguageID(int TVFileLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                TVFileLanguage tvfilelanguage = (from c in dbLocal.TVFileLanguages.AsNoTracking()
                        where c.TVFileLanguageID == TVFileLanguageID
                        select c).FirstOrDefault();

                if (tvfilelanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvfilelanguage));
            }
            else
            {
                TVFileLanguage tvfilelanguage = (from c in db.TVFileLanguages.AsNoTracking()
                        where c.TVFileLanguageID == TVFileLanguageID
                        select c).FirstOrDefault();

                if (tvfilelanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvfilelanguage));
            }
        }
        public async Task<ActionResult<List<TVFileLanguage>>> GetTVFileLanguageList()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                List<TVFileLanguage> tvfilelanguageList = (from c in dbLocal.TVFileLanguages.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(tvfilelanguageList));
            }
            else
            {
                List<TVFileLanguage> tvfilelanguageList = (from c in db.TVFileLanguages.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(tvfilelanguageList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int TVFileLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                TVFileLanguage tvFileLanguage = (from c in dbLocal.TVFileLanguages
                                   where c.TVFileLanguageID == TVFileLanguageID
                                   select c).FirstOrDefault();
                
                if (tvFileLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageID", TVFileLanguageID.ToString())));
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
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageID", TVFileLanguageID.ToString())));
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
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvFileLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
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
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvFileLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
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
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TVFileLanguageID"), new[] { "TVFileLanguageID" });
                }

                if (LoggedInService.IsLocal)
                {
                    if (!(from c in dbLocal.TVFileLanguages select c).Where(c => c.TVFileLanguageID == tvFileLanguage.TVFileLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageID", tvFileLanguage.TVFileLanguageID.ToString()), new[] { "TVFileLanguageID" });
                    }
                }
                else
                {
                    if (!(from c in db.TVFileLanguages select c).Where(c => c.TVFileLanguageID == tvFileLanguage.TVFileLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageID", tvFileLanguage.TVFileLanguageID.ToString()), new[] { "TVFileLanguageID" });
                    }
                }
            }

            TVFile TVFileTVFileID = null;
            if (LoggedInService.IsLocal)
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
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileID", tvFileLanguage.TVFileID.ToString()), new[] { "TVFileID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvFileLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            //FileDescription has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)tvFileLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TranslationStatus"), new[] { "TranslationStatus" });
            }

            if (tvFileLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvFileLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.IsLocal)
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
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvFileLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
