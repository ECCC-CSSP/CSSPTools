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
    public partial interface ILocalSpillLanguageDBService
    {
        Task<ActionResult<bool>> Delete(int LocalSpillLanguageID);
        Task<ActionResult<List<LocalSpillLanguage>>> GetLocalSpillLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<LocalSpillLanguage>> GetLocalSpillLanguageWithSpillLanguageID(int SpillLanguageID);
        Task<ActionResult<LocalSpillLanguage>> Post(LocalSpillLanguage localspilllanguage);
        Task<ActionResult<LocalSpillLanguage>> Put(LocalSpillLanguage localspilllanguage);
    }
    public partial class LocalSpillLanguageDBService : ControllerBase, ILocalSpillLanguageDBService
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
        public LocalSpillLanguageDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<LocalSpillLanguage>> GetLocalSpillLanguageWithSpillLanguageID(int SpillLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalSpillLanguage localSpillLanguage = (from c in db.LocalSpillLanguages.AsNoTracking()
                    where c.SpillLanguageID == SpillLanguageID
                    select c).FirstOrDefault();

            if (localSpillLanguage == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localSpillLanguage));
        }
        public async Task<ActionResult<List<LocalSpillLanguage>>> GetLocalSpillLanguageList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalSpillLanguage> localSpillLanguageList = (from c in db.LocalSpillLanguages.AsNoTracking() orderby c.SpillLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localSpillLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalSpillLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalSpillLanguage localSpillLanguage = (from c in db.LocalSpillLanguages
                    where c.SpillLanguageID == LocalSpillLanguageID
                    select c).FirstOrDefault();

            if (localSpillLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalSpillLanguage", "LocalSpillLanguageID", LocalSpillLanguageID.ToString())));
            }

            try
            {
                db.LocalSpillLanguages.Remove(localSpillLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalSpillLanguage>> Post(LocalSpillLanguage localSpillLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localSpillLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalSpillLanguages.Add(localSpillLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localSpillLanguage));
        }
        public async Task<ActionResult<LocalSpillLanguage>> Put(LocalSpillLanguage localSpillLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localSpillLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalSpillLanguages.Update(localSpillLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localSpillLanguage));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalSpillLanguage localSpillLanguage = validationContext.ObjectInstance as LocalSpillLanguage;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localSpillLanguage.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localSpillLanguage.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localSpillLanguage.SpillLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SpillLanguageID"), new[] { nameof(localSpillLanguage.SpillLanguageID) });
                }

                if (!(from c in db.LocalSpillLanguages.AsNoTracking() select c).Where(c => c.SpillLanguageID == localSpillLanguage.SpillLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SpillLanguage", "SpillLanguageID", localSpillLanguage.SpillLanguageID.ToString()), new[] { nameof(localSpillLanguage.SpillLanguageID) });
                }
            }

            LocalSpill localSpillSpillID = null;
            localSpillSpillID = (from c in db.LocalSpills.AsNoTracking() where c.SpillID == localSpillLanguage.SpillID select c).FirstOrDefault();

            if (localSpillSpillID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalSpill", "SpillID", localSpillLanguage.SpillID.ToString()), new[] { nameof(localSpillLanguage.SpillID) });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)localSpillLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(localSpillLanguage.Language) });
            }

            if (string.IsNullOrWhiteSpace(localSpillLanguage.SpillComment))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SpillComment"), new[] { nameof(localSpillLanguage.SpillComment) });
            }

            //SpillComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)localSpillLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { nameof(localSpillLanguage.TranslationStatus) });
            }

            if (localSpillLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localSpillLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (localSpillLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localSpillLanguage.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localSpillLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localSpillLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(localSpillLanguage.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localSpillLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
