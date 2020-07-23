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
   public partial interface IEmailDistributionListLanguageService
    {
       Task<ActionResult<bool>> Delete(int EmailDistributionListLanguageID);
       Task<ActionResult<List<EmailDistributionListLanguage>>> GetEmailDistributionListLanguageList(int skip = 0, int take = 100);
       Task<ActionResult<EmailDistributionListLanguage>> GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(int EmailDistributionListLanguageID);
       Task<ActionResult<EmailDistributionListLanguage>> Post(EmailDistributionListLanguage emaildistributionlistlanguage);
       Task<ActionResult<EmailDistributionListLanguage>> Put(EmailDistributionListLanguage emaildistributionlistlanguage);
    }
    public partial class EmailDistributionListLanguageService : ControllerBase, IEmailDistributionListLanguageService
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
        public EmailDistributionListLanguageService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, CSSPDBInMemoryContext dbIM)
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
        public async Task<ActionResult<EmailDistributionListLanguage>> GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(int EmailDistributionListLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                EmailDistributionListLanguage emailDistributionListLanguage = (from c in dbIM.EmailDistributionListLanguages.AsNoTracking()
                                   where c.EmailDistributionListLanguageID == EmailDistributionListLanguageID
                                   select c).FirstOrDefault();

                if (emailDistributionListLanguage == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(emailDistributionListLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                EmailDistributionListLanguage emailDistributionListLanguage = (from c in dbLocal.EmailDistributionListLanguages.AsNoTracking()
                        where c.EmailDistributionListLanguageID == EmailDistributionListLanguageID
                        select c).FirstOrDefault();

                if (emailDistributionListLanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(emailDistributionListLanguage));
            }
            else
            {
                EmailDistributionListLanguage emailDistributionListLanguage = (from c in db.EmailDistributionListLanguages.AsNoTracking()
                        where c.EmailDistributionListLanguageID == EmailDistributionListLanguageID
                        select c).FirstOrDefault();

                if (emailDistributionListLanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(emailDistributionListLanguage));
            }
        }
        public async Task<ActionResult<List<EmailDistributionListLanguage>>> GetEmailDistributionListLanguageList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<EmailDistributionListLanguage> emailDistributionListLanguageList = (from c in dbIM.EmailDistributionListLanguages.AsNoTracking() orderby c.EmailDistributionListLanguageID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(emailDistributionListLanguageList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<EmailDistributionListLanguage> emailDistributionListLanguageList = (from c in dbLocal.EmailDistributionListLanguages.AsNoTracking() orderby c.EmailDistributionListLanguageID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(emailDistributionListLanguageList));
            }
            else
            {
                List<EmailDistributionListLanguage> emailDistributionListLanguageList = (from c in db.EmailDistributionListLanguages.AsNoTracking() orderby c.EmailDistributionListLanguageID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(emailDistributionListLanguageList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int EmailDistributionListLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                EmailDistributionListLanguage emailDistributionListLanguage = (from c in dbIM.EmailDistributionListLanguages
                                   where c.EmailDistributionListLanguageID == EmailDistributionListLanguageID
                                   select c).FirstOrDefault();
            
                if (emailDistributionListLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListLanguage", "EmailDistributionListLanguageID", EmailDistributionListLanguageID.ToString())));
                }
            
                try
                {
                    dbIM.EmailDistributionListLanguages.Remove(emailDistributionListLanguage);
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
                EmailDistributionListLanguage emailDistributionListLanguage = (from c in dbLocal.EmailDistributionListLanguages
                                   where c.EmailDistributionListLanguageID == EmailDistributionListLanguageID
                                   select c).FirstOrDefault();
                
                if (emailDistributionListLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListLanguage", "EmailDistributionListLanguageID", EmailDistributionListLanguageID.ToString())));
                }

                try
                {
                   dbLocal.EmailDistributionListLanguages.Remove(emailDistributionListLanguage);
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
                EmailDistributionListLanguage emailDistributionListLanguage = (from c in db.EmailDistributionListLanguages
                                   where c.EmailDistributionListLanguageID == EmailDistributionListLanguageID
                                   select c).FirstOrDefault();
                
                if (emailDistributionListLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListLanguage", "EmailDistributionListLanguageID", EmailDistributionListLanguageID.ToString())));
                }

                try
                {
                   db.EmailDistributionListLanguages.Remove(emailDistributionListLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<EmailDistributionListLanguage>> Post(EmailDistributionListLanguage emailDistributionListLanguage)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(emailDistributionListLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.EmailDistributionListLanguages.Add(emailDistributionListLanguage);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(emailDistributionListLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.EmailDistributionListLanguages.Add(emailDistributionListLanguage);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(emailDistributionListLanguage));
            }
            else
            {
                try
                {
                   db.EmailDistributionListLanguages.Add(emailDistributionListLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(emailDistributionListLanguage));
            }
        }
        public async Task<ActionResult<EmailDistributionListLanguage>> Put(EmailDistributionListLanguage emailDistributionListLanguage)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(emailDistributionListLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.EmailDistributionListLanguages.Update(emailDistributionListLanguage);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(emailDistributionListLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.EmailDistributionListLanguages.Update(emailDistributionListLanguage);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(emailDistributionListLanguage));
            }
            else
            {
            try
            {
               db.EmailDistributionListLanguages.Update(emailDistributionListLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(emailDistributionListLanguage));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            EmailDistributionListLanguage emailDistributionListLanguage = validationContext.ObjectInstance as EmailDistributionListLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (emailDistributionListLanguage.EmailDistributionListLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EmailDistributionListLanguageID"), new[] { nameof(emailDistributionListLanguage.EmailDistributionListLanguageID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.EmailDistributionListLanguages select c).Where(c => c.EmailDistributionListLanguageID == emailDistributionListLanguage.EmailDistributionListLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListLanguage", "EmailDistributionListLanguageID", emailDistributionListLanguage.EmailDistributionListLanguageID.ToString()), new[] { nameof(emailDistributionListLanguage.EmailDistributionListLanguageID) });
                    }
                }
                else
                {
                    if (!(from c in db.EmailDistributionListLanguages select c).Where(c => c.EmailDistributionListLanguageID == emailDistributionListLanguage.EmailDistributionListLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListLanguage", "EmailDistributionListLanguageID", emailDistributionListLanguage.EmailDistributionListLanguageID.ToString()), new[] { nameof(emailDistributionListLanguage.EmailDistributionListLanguageID) });
                    }
                }
            }

            EmailDistributionList EmailDistributionListEmailDistributionListID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                EmailDistributionListEmailDistributionListID = (from c in dbLocal.EmailDistributionLists where c.EmailDistributionListID == emailDistributionListLanguage.EmailDistributionListID select c).FirstOrDefault();
                if (EmailDistributionListEmailDistributionListID == null)
                {
                    EmailDistributionListEmailDistributionListID = (from c in dbIM.EmailDistributionLists where c.EmailDistributionListID == emailDistributionListLanguage.EmailDistributionListID select c).FirstOrDefault();
                }
            }
            else
            {
                EmailDistributionListEmailDistributionListID = (from c in db.EmailDistributionLists where c.EmailDistributionListID == emailDistributionListLanguage.EmailDistributionListID select c).FirstOrDefault();
            }

            if (EmailDistributionListEmailDistributionListID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListID", emailDistributionListLanguage.EmailDistributionListID.ToString()), new[] { nameof(emailDistributionListLanguage.EmailDistributionListID) });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)emailDistributionListLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(emailDistributionListLanguage.Language) });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListLanguage.EmailListName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EmailListName"), new[] { nameof(emailDistributionListLanguage.EmailListName) });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListLanguage.EmailListName) && (emailDistributionListLanguage.EmailListName.Length < 1 || emailDistributionListLanguage.EmailListName.Length > 100))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "EmailListName", "1", "100"), new[] { nameof(emailDistributionListLanguage.EmailListName) });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)emailDistributionListLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { nameof(emailDistributionListLanguage.TranslationStatus) });
            }

            if (emailDistributionListLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(emailDistributionListLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (emailDistributionListLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(emailDistributionListLanguage.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == emailDistributionListLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == emailDistributionListLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionListLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", emailDistributionListLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(emailDistributionListLanguage.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(emailDistributionListLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
