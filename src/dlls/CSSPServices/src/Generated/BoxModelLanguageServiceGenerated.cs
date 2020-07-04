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
   public interface IBoxModelLanguageService
    {
       Task<ActionResult<bool>> Delete(int BoxModelLanguageID);
       Task<ActionResult<List<BoxModelLanguage>>> GetBoxModelLanguageList();
       Task<ActionResult<BoxModelLanguage>> GetBoxModelLanguageWithBoxModelLanguageID(int BoxModelLanguageID);
       Task<ActionResult<BoxModelLanguage>> Post(BoxModelLanguage boxmodellanguage);
       Task<ActionResult<BoxModelLanguage>> Put(BoxModelLanguage boxmodellanguage);
    }
    public partial class BoxModelLanguageService : ControllerBase, IBoxModelLanguageService
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
        public BoxModelLanguageService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<BoxModelLanguage>> GetBoxModelLanguageWithBoxModelLanguageID(int BoxModelLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                BoxModelLanguage boxmodellanguage = (from c in dbLocal.BoxModelLanguages.AsNoTracking()
                        where c.BoxModelLanguageID == BoxModelLanguageID
                        select c).FirstOrDefault();

                if (boxmodellanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(boxmodellanguage));
            }
            else
            {
                BoxModelLanguage boxmodellanguage = (from c in db.BoxModelLanguages.AsNoTracking()
                        where c.BoxModelLanguageID == BoxModelLanguageID
                        select c).FirstOrDefault();

                if (boxmodellanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(boxmodellanguage));
            }
        }
        public async Task<ActionResult<List<BoxModelLanguage>>> GetBoxModelLanguageList()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                List<BoxModelLanguage> boxmodellanguageList = (from c in dbLocal.BoxModelLanguages.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(boxmodellanguageList));
            }
            else
            {
                List<BoxModelLanguage> boxmodellanguageList = (from c in db.BoxModelLanguages.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(boxmodellanguageList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int BoxModelLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                BoxModelLanguage boxModelLanguage = (from c in dbLocal.BoxModelLanguages
                                   where c.BoxModelLanguageID == BoxModelLanguageID
                                   select c).FirstOrDefault();
                
                if (boxModelLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "BoxModelLanguage", "BoxModelLanguageID", BoxModelLanguageID.ToString())));
                }

                try
                {
                   dbLocal.BoxModelLanguages.Remove(boxModelLanguage);
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
                BoxModelLanguage boxModelLanguage = (from c in db.BoxModelLanguages
                                   where c.BoxModelLanguageID == BoxModelLanguageID
                                   select c).FirstOrDefault();
                
                if (boxModelLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "BoxModelLanguage", "BoxModelLanguageID", BoxModelLanguageID.ToString())));
                }

                try
                {
                   db.BoxModelLanguages.Remove(boxModelLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<BoxModelLanguage>> Post(BoxModelLanguage boxModelLanguage)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(boxModelLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
                try
                {
                   dbLocal.BoxModelLanguages.Add(boxModelLanguage);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(boxModelLanguage));
            }
            else
            {
                try
                {
                   db.BoxModelLanguages.Add(boxModelLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(boxModelLanguage));
            }
        }
        public async Task<ActionResult<BoxModelLanguage>> Put(BoxModelLanguage boxModelLanguage)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(boxModelLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
            try
            {
               dbLocal.BoxModelLanguages.Update(boxModelLanguage);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(boxModelLanguage));
            }
            else
            {
            try
            {
               db.BoxModelLanguages.Update(boxModelLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(boxModelLanguage));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            BoxModelLanguage boxModelLanguage = validationContext.ObjectInstance as BoxModelLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (boxModelLanguage.BoxModelLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "BoxModelLanguageID"), new[] { "BoxModelLanguageID" });
                }

                if (LoggedInService.IsLocal)
                {
                    if (!(from c in dbLocal.BoxModelLanguages select c).Where(c => c.BoxModelLanguageID == boxModelLanguage.BoxModelLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "BoxModelLanguage", "BoxModelLanguageID", boxModelLanguage.BoxModelLanguageID.ToString()), new[] { "BoxModelLanguageID" });
                    }
                }
                else
                {
                    if (!(from c in db.BoxModelLanguages select c).Where(c => c.BoxModelLanguageID == boxModelLanguage.BoxModelLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "BoxModelLanguage", "BoxModelLanguageID", boxModelLanguage.BoxModelLanguageID.ToString()), new[] { "BoxModelLanguageID" });
                    }
                }
            }

            BoxModel BoxModelBoxModelID = null;
            if (LoggedInService.IsLocal)
            {
                BoxModelBoxModelID = (from c in dbLocal.BoxModels where c.BoxModelID == boxModelLanguage.BoxModelID select c).FirstOrDefault();
                if (BoxModelBoxModelID == null)
                {
                    BoxModelBoxModelID = (from c in dbIM.BoxModels where c.BoxModelID == boxModelLanguage.BoxModelID select c).FirstOrDefault();
                }
            }
            else
            {
                BoxModelBoxModelID = (from c in db.BoxModels where c.BoxModelID == boxModelLanguage.BoxModelID select c).FirstOrDefault();
            }

            if (BoxModelBoxModelID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelID", boxModelLanguage.BoxModelID.ToString()), new[] { "BoxModelID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)boxModelLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(boxModelLanguage.ScenarioName))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "ScenarioName"), new[] { "ScenarioName" });
            }

            if (!string.IsNullOrWhiteSpace(boxModelLanguage.ScenarioName) && boxModelLanguage.ScenarioName.Length > 250)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "ScenarioName", "250"), new[] { "ScenarioName" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)boxModelLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TranslationStatus"), new[] { "TranslationStatus" });
            }

            if (boxModelLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (boxModelLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == boxModelLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == boxModelLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == boxModelLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", boxModelLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
