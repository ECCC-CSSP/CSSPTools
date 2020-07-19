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
   public partial interface IPolSourceGroupingLanguageService
    {
       Task<ActionResult<bool>> Delete(int PolSourceGroupingLanguageID);
       Task<ActionResult<List<PolSourceGroupingLanguage>>> GetPolSourceGroupingLanguageList(int skip = 0, int take = 100);
       Task<ActionResult<PolSourceGroupingLanguage>> GetPolSourceGroupingLanguageWithPolSourceGroupingLanguageID(int PolSourceGroupingLanguageID);
       Task<ActionResult<PolSourceGroupingLanguage>> Post(PolSourceGroupingLanguage polsourcegroupinglanguage);
       Task<ActionResult<PolSourceGroupingLanguage>> Put(PolSourceGroupingLanguage polsourcegroupinglanguage);
    }
    public partial class PolSourceGroupingLanguageService : ControllerBase, IPolSourceGroupingLanguageService
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
        public PolSourceGroupingLanguageService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<PolSourceGroupingLanguage>> GetPolSourceGroupingLanguageWithPolSourceGroupingLanguageID(int PolSourceGroupingLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                PolSourceGroupingLanguage polSourceGroupingLanguage = (from c in dbIM.PolSourceGroupingLanguages.AsNoTracking()
                                   where c.PolSourceGroupingLanguageID == PolSourceGroupingLanguageID
                                   select c).FirstOrDefault();

                if (polSourceGroupingLanguage == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(polSourceGroupingLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                PolSourceGroupingLanguage polSourceGroupingLanguage = (from c in dbLocal.PolSourceGroupingLanguages.AsNoTracking()
                        where c.PolSourceGroupingLanguageID == PolSourceGroupingLanguageID
                        select c).FirstOrDefault();

                if (polSourceGroupingLanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(polSourceGroupingLanguage));
            }
            else
            {
                PolSourceGroupingLanguage polSourceGroupingLanguage = (from c in db.PolSourceGroupingLanguages.AsNoTracking()
                        where c.PolSourceGroupingLanguageID == PolSourceGroupingLanguageID
                        select c).FirstOrDefault();

                if (polSourceGroupingLanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(polSourceGroupingLanguage));
            }
        }
        public async Task<ActionResult<List<PolSourceGroupingLanguage>>> GetPolSourceGroupingLanguageList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<PolSourceGroupingLanguage> polSourceGroupingLanguageList = (from c in dbIM.PolSourceGroupingLanguages.AsNoTracking() orderby c.PolSourceGroupingLanguageID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(polSourceGroupingLanguageList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<PolSourceGroupingLanguage> polSourceGroupingLanguageList = (from c in dbLocal.PolSourceGroupingLanguages.AsNoTracking() orderby c.PolSourceGroupingLanguageID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(polSourceGroupingLanguageList));
            }
            else
            {
                List<PolSourceGroupingLanguage> polSourceGroupingLanguageList = (from c in db.PolSourceGroupingLanguages.AsNoTracking() orderby c.PolSourceGroupingLanguageID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(polSourceGroupingLanguageList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int PolSourceGroupingLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                PolSourceGroupingLanguage polSourceGroupingLanguage = (from c in dbIM.PolSourceGroupingLanguages
                                   where c.PolSourceGroupingLanguageID == PolSourceGroupingLanguageID
                                   select c).FirstOrDefault();
            
                if (polSourceGroupingLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceGroupingLanguage", "PolSourceGroupingLanguageID", PolSourceGroupingLanguageID.ToString())));
                }
            
                try
                {
                    dbIM.PolSourceGroupingLanguages.Remove(polSourceGroupingLanguage);
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
                PolSourceGroupingLanguage polSourceGroupingLanguage = (from c in dbLocal.PolSourceGroupingLanguages
                                   where c.PolSourceGroupingLanguageID == PolSourceGroupingLanguageID
                                   select c).FirstOrDefault();
                
                if (polSourceGroupingLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceGroupingLanguage", "PolSourceGroupingLanguageID", PolSourceGroupingLanguageID.ToString())));
                }

                try
                {
                   dbLocal.PolSourceGroupingLanguages.Remove(polSourceGroupingLanguage);
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
                PolSourceGroupingLanguage polSourceGroupingLanguage = (from c in db.PolSourceGroupingLanguages
                                   where c.PolSourceGroupingLanguageID == PolSourceGroupingLanguageID
                                   select c).FirstOrDefault();
                
                if (polSourceGroupingLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceGroupingLanguage", "PolSourceGroupingLanguageID", PolSourceGroupingLanguageID.ToString())));
                }

                try
                {
                   db.PolSourceGroupingLanguages.Remove(polSourceGroupingLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<PolSourceGroupingLanguage>> Post(PolSourceGroupingLanguage polSourceGroupingLanguage)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceGroupingLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.PolSourceGroupingLanguages.Add(polSourceGroupingLanguage);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceGroupingLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.PolSourceGroupingLanguages.Add(polSourceGroupingLanguage);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceGroupingLanguage));
            }
            else
            {
                try
                {
                   db.PolSourceGroupingLanguages.Add(polSourceGroupingLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceGroupingLanguage));
            }
        }
        public async Task<ActionResult<PolSourceGroupingLanguage>> Put(PolSourceGroupingLanguage polSourceGroupingLanguage)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceGroupingLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.PolSourceGroupingLanguages.Update(polSourceGroupingLanguage);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceGroupingLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.PolSourceGroupingLanguages.Update(polSourceGroupingLanguage);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceGroupingLanguage));
            }
            else
            {
            try
            {
               db.PolSourceGroupingLanguages.Update(polSourceGroupingLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceGroupingLanguage));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            PolSourceGroupingLanguage polSourceGroupingLanguage = validationContext.ObjectInstance as PolSourceGroupingLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceGroupingLanguage.PolSourceGroupingLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceGroupingLanguageID"), new[] { "PolSourceGroupingLanguageID" });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.PolSourceGroupingLanguages select c).Where(c => c.PolSourceGroupingLanguageID == polSourceGroupingLanguage.PolSourceGroupingLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceGroupingLanguage", "PolSourceGroupingLanguageID", polSourceGroupingLanguage.PolSourceGroupingLanguageID.ToString()), new[] { "PolSourceGroupingLanguageID" });
                    }
                }
                else
                {
                    if (!(from c in db.PolSourceGroupingLanguages select c).Where(c => c.PolSourceGroupingLanguageID == polSourceGroupingLanguage.PolSourceGroupingLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceGroupingLanguage", "PolSourceGroupingLanguageID", polSourceGroupingLanguage.PolSourceGroupingLanguageID.ToString()), new[] { "PolSourceGroupingLanguageID" });
                    }
                }
            }

            PolSourceGrouping PolSourceGroupingPolSourceGroupingID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                PolSourceGroupingPolSourceGroupingID = (from c in dbLocal.PolSourceGroupings where c.PolSourceGroupingID == polSourceGroupingLanguage.PolSourceGroupingID select c).FirstOrDefault();
                if (PolSourceGroupingPolSourceGroupingID == null)
                {
                    PolSourceGroupingPolSourceGroupingID = (from c in dbIM.PolSourceGroupings where c.PolSourceGroupingID == polSourceGroupingLanguage.PolSourceGroupingID select c).FirstOrDefault();
                }
            }
            else
            {
                PolSourceGroupingPolSourceGroupingID = (from c in db.PolSourceGroupings where c.PolSourceGroupingID == polSourceGroupingLanguage.PolSourceGroupingID select c).FirstOrDefault();
            }

            if (PolSourceGroupingPolSourceGroupingID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceGrouping", "PolSourceGroupingID", polSourceGroupingLanguage.PolSourceGroupingID.ToString()), new[] { "PolSourceGroupingID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)polSourceGroupingLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(polSourceGroupingLanguage.SourceName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SourceName"), new[] { "SourceName" });
            }

            if (!string.IsNullOrWhiteSpace(polSourceGroupingLanguage.SourceName) && polSourceGroupingLanguage.SourceName.Length > 500)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SourceName", "500"), new[] { "SourceName" });
            }

            if (polSourceGroupingLanguage.SourceNameOrder < 0 || polSourceGroupingLanguage.SourceNameOrder > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourceNameOrder", "0", "1000"), new[] { "SourceNameOrder" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)polSourceGroupingLanguage.TranslationStatusSourceName);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusSourceName"), new[] { "TranslationStatusSourceName" });
            }

            if (string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Init))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Init"), new[] { "Init" });
            }

            if (!string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Init) && polSourceGroupingLanguage.Init.Length > 50)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Init", "50"), new[] { "Init" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)polSourceGroupingLanguage.TranslationStatusInit);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusInit"), new[] { "TranslationStatusInit" });
            }

            if (string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Description))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Description"), new[] { "Description" });
            }

            if (!string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Description) && polSourceGroupingLanguage.Description.Length > 500)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Description", "500"), new[] { "Description" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)polSourceGroupingLanguage.TranslationStatusDescription);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusDescription"), new[] { "TranslationStatusDescription" });
            }

            if (string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Report))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Report"), new[] { "Report" });
            }

            if (!string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Report) && polSourceGroupingLanguage.Report.Length > 500)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Report", "500"), new[] { "Report" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)polSourceGroupingLanguage.TranslationStatusReport);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusReport"), new[] { "TranslationStatusReport" });
            }

            if (string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Text))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Text"), new[] { "Text" });
            }

            if (!string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Text) && polSourceGroupingLanguage.Text.Length > 500)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Text", "500"), new[] { "Text" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)polSourceGroupingLanguage.TranslationStatusText);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusText"), new[] { "TranslationStatusText" });
            }

            if (polSourceGroupingLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (polSourceGroupingLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == polSourceGroupingLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == polSourceGroupingLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceGroupingLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceGroupingLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
