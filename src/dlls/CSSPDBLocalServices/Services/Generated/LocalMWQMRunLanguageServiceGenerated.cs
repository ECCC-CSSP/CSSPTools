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
    public partial interface ILocalMWQMRunLanguageDBService
    {
        Task<ActionResult<bool>> Delete(int LocalMWQMRunLanguageID);
        Task<ActionResult<List<LocalMWQMRunLanguage>>> GetLocalMWQMRunLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<LocalMWQMRunLanguage>> GetLocalMWQMRunLanguageWithMWQMRunLanguageID(int MWQMRunLanguageID);
        Task<ActionResult<LocalMWQMRunLanguage>> Post(LocalMWQMRunLanguage localmwqmrunlanguage);
        Task<ActionResult<LocalMWQMRunLanguage>> Put(LocalMWQMRunLanguage localmwqmrunlanguage);
    }
    public partial class LocalMWQMRunLanguageDBService : ControllerBase, ILocalMWQMRunLanguageDBService
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
        public LocalMWQMRunLanguageDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<LocalMWQMRunLanguage>> GetLocalMWQMRunLanguageWithMWQMRunLanguageID(int MWQMRunLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalMWQMRunLanguage localMWQMRunLanguage = (from c in db.LocalMWQMRunLanguages.AsNoTracking()
                    where c.MWQMRunLanguageID == MWQMRunLanguageID
                    select c).FirstOrDefault();

            if (localMWQMRunLanguage == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localMWQMRunLanguage));
        }
        public async Task<ActionResult<List<LocalMWQMRunLanguage>>> GetLocalMWQMRunLanguageList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalMWQMRunLanguage> localMWQMRunLanguageList = (from c in db.LocalMWQMRunLanguages.AsNoTracking() orderby c.MWQMRunLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localMWQMRunLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalMWQMRunLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalMWQMRunLanguage localMWQMRunLanguage = (from c in db.LocalMWQMRunLanguages
                    where c.MWQMRunLanguageID == LocalMWQMRunLanguageID
                    select c).FirstOrDefault();

            if (localMWQMRunLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalMWQMRunLanguage", "LocalMWQMRunLanguageID", LocalMWQMRunLanguageID.ToString())));
            }

            try
            {
                db.LocalMWQMRunLanguages.Remove(localMWQMRunLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalMWQMRunLanguage>> Post(LocalMWQMRunLanguage localMWQMRunLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localMWQMRunLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalMWQMRunLanguages.Add(localMWQMRunLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localMWQMRunLanguage));
        }
        public async Task<ActionResult<LocalMWQMRunLanguage>> Put(LocalMWQMRunLanguage localMWQMRunLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localMWQMRunLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalMWQMRunLanguages.Update(localMWQMRunLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localMWQMRunLanguage));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalMWQMRunLanguage localMWQMRunLanguage = validationContext.ObjectInstance as LocalMWQMRunLanguage;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localMWQMRunLanguage.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localMWQMRunLanguage.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localMWQMRunLanguage.MWQMRunLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMRunLanguageID"), new[] { nameof(localMWQMRunLanguage.MWQMRunLanguageID) });
                }

                if (!(from c in db.LocalMWQMRunLanguages.AsNoTracking() select c).Where(c => c.MWQMRunLanguageID == localMWQMRunLanguage.MWQMRunLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMRunLanguage", "MWQMRunLanguageID", localMWQMRunLanguage.MWQMRunLanguageID.ToString()), new[] { nameof(localMWQMRunLanguage.MWQMRunLanguageID) });
                }
            }

            LocalMWQMRun localMWQMRunMWQMRunID = null;
            localMWQMRunMWQMRunID = (from c in db.LocalMWQMRuns.AsNoTracking() where c.MWQMRunID == localMWQMRunLanguage.MWQMRunID select c).FirstOrDefault();

            if (localMWQMRunMWQMRunID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalMWQMRun", "MWQMRunID", localMWQMRunLanguage.MWQMRunID.ToString()), new[] { nameof(localMWQMRunLanguage.MWQMRunID) });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)localMWQMRunLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(localMWQMRunLanguage.Language) });
            }

            if (string.IsNullOrWhiteSpace(localMWQMRunLanguage.RunComment))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RunComment"), new[] { nameof(localMWQMRunLanguage.RunComment) });
            }

            //RunComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)localMWQMRunLanguage.TranslationStatusRunComment);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusRunComment"), new[] { nameof(localMWQMRunLanguage.TranslationStatusRunComment) });
            }

            if (string.IsNullOrWhiteSpace(localMWQMRunLanguage.RunWeatherComment))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RunWeatherComment"), new[] { nameof(localMWQMRunLanguage.RunWeatherComment) });
            }

            //RunWeatherComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)localMWQMRunLanguage.TranslationStatusRunWeatherComment);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusRunWeatherComment"), new[] { nameof(localMWQMRunLanguage.TranslationStatusRunWeatherComment) });
            }

            if (localMWQMRunLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localMWQMRunLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (localMWQMRunLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localMWQMRunLanguage.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localMWQMRunLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localMWQMRunLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(localMWQMRunLanguage.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localMWQMRunLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
