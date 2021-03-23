/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPDBServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
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
using LoggedInServices;
using Microsoft.Extensions.Configuration;
using CSSPScrambleServices;

namespace CSSPDBServices
{
    public partial interface IEmailDistributionListContactLanguageDBService
    {
        Task<ActionResult<bool>> Delete(int EmailDistributionListContactLanguageID);
        Task<ActionResult<List<EmailDistributionListContactLanguage>>> GetEmailDistributionListContactLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<EmailDistributionListContactLanguage>> GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(int EmailDistributionListContactLanguageID);
        Task<ActionResult<EmailDistributionListContactLanguage>> Post(EmailDistributionListContactLanguage emaildistributionlistcontactlanguage);
        Task<ActionResult<EmailDistributionListContactLanguage>> Put(EmailDistributionListContactLanguage emaildistributionlistcontactlanguage);
    }
    public partial class EmailDistributionListContactLanguageDBService : ControllerBase, IEmailDistributionListContactLanguageDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IScrambleService ScrambleService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactLanguageDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ScrambleService = ScrambleService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<EmailDistributionListContactLanguage>> GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(int EmailDistributionListContactLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            EmailDistributionListContactLanguage emailDistributionListContactLanguage = (from c in db.EmailDistributionListContactLanguages.AsNoTracking()
                    where c.EmailDistributionListContactLanguageID == EmailDistributionListContactLanguageID
                    select c).FirstOrDefault();

            if (emailDistributionListContactLanguage == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(emailDistributionListContactLanguage));
        }
        public async Task<ActionResult<List<EmailDistributionListContactLanguage>>> GetEmailDistributionListContactLanguageList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageList = (from c in db.EmailDistributionListContactLanguages.AsNoTracking() orderby c.EmailDistributionListContactLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(emailDistributionListContactLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int EmailDistributionListContactLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            EmailDistributionListContactLanguage emailDistributionListContactLanguage = (from c in db.EmailDistributionListContactLanguages
                    where c.EmailDistributionListContactLanguageID == EmailDistributionListContactLanguageID
                    select c).FirstOrDefault();

            if (emailDistributionListContactLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContactLanguage", "EmailDistributionListContactLanguageID", EmailDistributionListContactLanguageID.ToString())));
            }

            try
            {
                db.EmailDistributionListContactLanguages.Remove(emailDistributionListContactLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<EmailDistributionListContactLanguage>> Post(EmailDistributionListContactLanguage emailDistributionListContactLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            ValidationResults = Validate(new ValidationContext(emailDistributionListContactLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.EmailDistributionListContactLanguages.Add(emailDistributionListContactLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(emailDistributionListContactLanguage));
        }
        public async Task<ActionResult<EmailDistributionListContactLanguage>> Put(EmailDistributionListContactLanguage emailDistributionListContactLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            ValidationResults = Validate(new ValidationContext(emailDistributionListContactLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.EmailDistributionListContactLanguages.Update(emailDistributionListContactLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(emailDistributionListContactLanguage));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            EmailDistributionListContactLanguage emailDistributionListContactLanguage = validationContext.ObjectInstance as EmailDistributionListContactLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (emailDistributionListContactLanguage.EmailDistributionListContactLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EmailDistributionListContactLanguageID"), new[] { nameof(emailDistributionListContactLanguage.EmailDistributionListContactLanguageID) });
                }

                if (!(from c in db.EmailDistributionListContactLanguages.AsNoTracking() select c).Where(c => c.EmailDistributionListContactLanguageID == emailDistributionListContactLanguage.EmailDistributionListContactLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContactLanguage", "EmailDistributionListContactLanguageID", emailDistributionListContactLanguage.EmailDistributionListContactLanguageID.ToString()), new[] { nameof(emailDistributionListContactLanguage.EmailDistributionListContactLanguageID) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)emailDistributionListContactLanguage.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(emailDistributionListContactLanguage.DBCommand) });
            }

            EmailDistributionListContact EmailDistributionListContactEmailDistributionListContactID = null;
            EmailDistributionListContactEmailDistributionListContactID = (from c in db.EmailDistributionListContacts.AsNoTracking() where c.EmailDistributionListContactID == emailDistributionListContactLanguage.EmailDistributionListContactID select c).FirstOrDefault();

            if (EmailDistributionListContactEmailDistributionListContactID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContact", "EmailDistributionListContactID", emailDistributionListContactLanguage.EmailDistributionListContactID.ToString()), new[] { nameof(emailDistributionListContactLanguage.EmailDistributionListContactID) });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)emailDistributionListContactLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(emailDistributionListContactLanguage.Language) });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListContactLanguage.Agency))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Agency"), new[] { nameof(emailDistributionListContactLanguage.Agency) });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContactLanguage.Agency) && (emailDistributionListContactLanguage.Agency.Length < 1 || emailDistributionListContactLanguage.Agency.Length > 100))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Agency", "1", "100"), new[] { nameof(emailDistributionListContactLanguage.Agency) });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)emailDistributionListContactLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { nameof(emailDistributionListContactLanguage.TranslationStatus) });
            }

            if (emailDistributionListContactLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(emailDistributionListContactLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (emailDistributionListContactLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(emailDistributionListContactLanguage.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == emailDistributionListContactLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", emailDistributionListContactLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(emailDistributionListContactLanguage.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(emailDistributionListContactLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
