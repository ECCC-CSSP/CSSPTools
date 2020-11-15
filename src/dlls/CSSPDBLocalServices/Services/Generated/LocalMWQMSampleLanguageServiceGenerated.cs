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
    public partial interface ILocalMWQMSampleLanguageDBService
    {
        Task<ActionResult<bool>> Delete(int LocalMWQMSampleLanguageID);
        Task<ActionResult<List<LocalMWQMSampleLanguage>>> GetLocalMWQMSampleLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<LocalMWQMSampleLanguage>> GetLocalMWQMSampleLanguageWithMWQMSampleLanguageID(int MWQMSampleLanguageID);
        Task<ActionResult<LocalMWQMSampleLanguage>> Post(LocalMWQMSampleLanguage localmwqmsamplelanguage);
        Task<ActionResult<LocalMWQMSampleLanguage>> Put(LocalMWQMSampleLanguage localmwqmsamplelanguage);
    }
    public partial class LocalMWQMSampleLanguageDBService : ControllerBase, ILocalMWQMSampleLanguageDBService
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
        public LocalMWQMSampleLanguageDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<LocalMWQMSampleLanguage>> GetLocalMWQMSampleLanguageWithMWQMSampleLanguageID(int MWQMSampleLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalMWQMSampleLanguage localMWQMSampleLanguage = (from c in db.LocalMWQMSampleLanguages.AsNoTracking()
                    where c.MWQMSampleLanguageID == MWQMSampleLanguageID
                    select c).FirstOrDefault();

            if (localMWQMSampleLanguage == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localMWQMSampleLanguage));
        }
        public async Task<ActionResult<List<LocalMWQMSampleLanguage>>> GetLocalMWQMSampleLanguageList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalMWQMSampleLanguage> localMWQMSampleLanguageList = (from c in db.LocalMWQMSampleLanguages.AsNoTracking() orderby c.MWQMSampleLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localMWQMSampleLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalMWQMSampleLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalMWQMSampleLanguage localMWQMSampleLanguage = (from c in db.LocalMWQMSampleLanguages
                    where c.MWQMSampleLanguageID == LocalMWQMSampleLanguageID
                    select c).FirstOrDefault();

            if (localMWQMSampleLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalMWQMSampleLanguage", "LocalMWQMSampleLanguageID", LocalMWQMSampleLanguageID.ToString())));
            }

            try
            {
                db.LocalMWQMSampleLanguages.Remove(localMWQMSampleLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalMWQMSampleLanguage>> Post(LocalMWQMSampleLanguage localMWQMSampleLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localMWQMSampleLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalMWQMSampleLanguages.Add(localMWQMSampleLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localMWQMSampleLanguage));
        }
        public async Task<ActionResult<LocalMWQMSampleLanguage>> Put(LocalMWQMSampleLanguage localMWQMSampleLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localMWQMSampleLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalMWQMSampleLanguages.Update(localMWQMSampleLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localMWQMSampleLanguage));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalMWQMSampleLanguage localMWQMSampleLanguage = validationContext.ObjectInstance as LocalMWQMSampleLanguage;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localMWQMSampleLanguage.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localMWQMSampleLanguage.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localMWQMSampleLanguage.MWQMSampleLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMSampleLanguageID"), new[] { nameof(localMWQMSampleLanguage.MWQMSampleLanguageID) });
                }

                if (!(from c in db.LocalMWQMSampleLanguages.AsNoTracking() select c).Where(c => c.MWQMSampleLanguageID == localMWQMSampleLanguage.MWQMSampleLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSampleLanguage", "MWQMSampleLanguageID", localMWQMSampleLanguage.MWQMSampleLanguageID.ToString()), new[] { nameof(localMWQMSampleLanguage.MWQMSampleLanguageID) });
                }
            }

            LocalMWQMSample localMWQMSampleMWQMSampleID = null;
            localMWQMSampleMWQMSampleID = (from c in db.LocalMWQMSamples.AsNoTracking() where c.MWQMSampleID == localMWQMSampleLanguage.MWQMSampleID select c).FirstOrDefault();

            if (localMWQMSampleMWQMSampleID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalMWQMSample", "MWQMSampleID", localMWQMSampleLanguage.MWQMSampleID.ToString()), new[] { nameof(localMWQMSampleLanguage.MWQMSampleID) });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)localMWQMSampleLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(localMWQMSampleLanguage.Language) });
            }

            if (string.IsNullOrWhiteSpace(localMWQMSampleLanguage.MWQMSampleNote))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMSampleNote"), new[] { nameof(localMWQMSampleLanguage.MWQMSampleNote) });
            }

            //MWQMSampleNote has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)localMWQMSampleLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { nameof(localMWQMSampleLanguage.TranslationStatus) });
            }

            if (localMWQMSampleLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localMWQMSampleLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (localMWQMSampleLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localMWQMSampleLanguage.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localMWQMSampleLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localMWQMSampleLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(localMWQMSampleLanguage.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localMWQMSampleLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}