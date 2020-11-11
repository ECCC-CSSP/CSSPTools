/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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
using LocalServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBLocalServices
{
    public partial interface ILocalEmailDistributionListLanguageDBService
    {
        Task<ActionResult<bool>> Delete(int LocalEmailDistributionListLanguageID);
        Task<ActionResult<List<LocalEmailDistributionListLanguage>>> GetLocalEmailDistributionListLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<LocalEmailDistributionListLanguage>> GetLocalEmailDistributionListLanguageWithEmailDistributionListLanguageID(int EmailDistributionListLanguageID);
        Task<ActionResult<LocalEmailDistributionListLanguage>> Post(LocalEmailDistributionListLanguage localemaildistributionlistlanguage);
        Task<ActionResult<LocalEmailDistributionListLanguage>> Put(LocalEmailDistributionListLanguage localemaildistributionlistlanguage);
    }
    public partial class LocalEmailDistributionListLanguageDBService : ControllerBase, ILocalEmailDistributionListLanguageDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LocalEmailDistributionListLanguageDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<LocalEmailDistributionListLanguage>> GetLocalEmailDistributionListLanguageWithEmailDistributionListLanguageID(int EmailDistributionListLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalEmailDistributionListLanguage localEmailDistributionListLanguage = (from c in db.LocalEmailDistributionListLanguages.AsNoTracking()
                    where c.EmailDistributionListLanguageID == EmailDistributionListLanguageID
                    select c).FirstOrDefault();

            if (localEmailDistributionListLanguage == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localEmailDistributionListLanguage));
        }
        public async Task<ActionResult<List<LocalEmailDistributionListLanguage>>> GetLocalEmailDistributionListLanguageList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalEmailDistributionListLanguage> localEmailDistributionListLanguageList = (from c in db.LocalEmailDistributionListLanguages.AsNoTracking() orderby c.EmailDistributionListLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localEmailDistributionListLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalEmailDistributionListLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalEmailDistributionListLanguage localEmailDistributionListLanguage = (from c in db.LocalEmailDistributionListLanguages
                    where c.EmailDistributionListLanguageID == LocalEmailDistributionListLanguageID
                    select c).FirstOrDefault();

            if (localEmailDistributionListLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalEmailDistributionListLanguage", "LocalEmailDistributionListLanguageID", LocalEmailDistributionListLanguageID.ToString())));
            }

            try
            {
                db.LocalEmailDistributionListLanguages.Remove(localEmailDistributionListLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalEmailDistributionListLanguage>> Post(LocalEmailDistributionListLanguage localEmailDistributionListLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localEmailDistributionListLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalEmailDistributionListLanguages.Add(localEmailDistributionListLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localEmailDistributionListLanguage));
        }
        public async Task<ActionResult<LocalEmailDistributionListLanguage>> Put(LocalEmailDistributionListLanguage localEmailDistributionListLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localEmailDistributionListLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalEmailDistributionListLanguages.Update(localEmailDistributionListLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localEmailDistributionListLanguage));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalEmailDistributionListLanguage localEmailDistributionListLanguage = validationContext.ObjectInstance as LocalEmailDistributionListLanguage;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localEmailDistributionListLanguage.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localEmailDistributionListLanguage.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localEmailDistributionListLanguage.EmailDistributionListLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EmailDistributionListLanguageID"), new[] { nameof(localEmailDistributionListLanguage.EmailDistributionListLanguageID) });
                }

                if (!(from c in db.LocalEmailDistributionListLanguages.AsNoTracking() select c).Where(c => c.EmailDistributionListLanguageID == localEmailDistributionListLanguage.EmailDistributionListLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListLanguage", "EmailDistributionListLanguageID", localEmailDistributionListLanguage.EmailDistributionListLanguageID.ToString()), new[] { nameof(localEmailDistributionListLanguage.EmailDistributionListLanguageID) });
                }
            }

            LocalEmailDistributionList localEmailDistributionListEmailDistributionListID = null;
            localEmailDistributionListEmailDistributionListID = (from c in db.LocalEmailDistributionLists.AsNoTracking() where c.EmailDistributionListID == localEmailDistributionListLanguage.EmailDistributionListID select c).FirstOrDefault();

            if (localEmailDistributionListEmailDistributionListID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalEmailDistributionList", "EmailDistributionListID", localEmailDistributionListLanguage.EmailDistributionListID.ToString()), new[] { nameof(localEmailDistributionListLanguage.EmailDistributionListID) });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)localEmailDistributionListLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(localEmailDistributionListLanguage.Language) });
            }

            if (string.IsNullOrWhiteSpace(localEmailDistributionListLanguage.EmailListName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EmailListName"), new[] { nameof(localEmailDistributionListLanguage.EmailListName) });
            }

            if (!string.IsNullOrWhiteSpace(localEmailDistributionListLanguage.EmailListName) && (localEmailDistributionListLanguage.EmailListName.Length < 1 || localEmailDistributionListLanguage.EmailListName.Length > 100))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "EmailListName", "1", "100"), new[] { nameof(localEmailDistributionListLanguage.EmailListName) });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)localEmailDistributionListLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { nameof(localEmailDistributionListLanguage.TranslationStatus) });
            }

            if (localEmailDistributionListLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localEmailDistributionListLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (localEmailDistributionListLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localEmailDistributionListLanguage.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localEmailDistributionListLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localEmailDistributionListLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(localEmailDistributionListLanguage.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localEmailDistributionListLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
