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

namespace CSSPDBServices
{
    public partial interface IMWQMRunLanguageDBService
    {
        Task<ActionResult<bool>> Delete(int MWQMRunLanguageID);
        Task<ActionResult<List<MWQMRunLanguage>>> GetMWQMRunLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<MWQMRunLanguage>> GetMWQMRunLanguageWithMWQMRunLanguageID(int MWQMRunLanguageID);
        Task<ActionResult<MWQMRunLanguage>> Post(MWQMRunLanguage mwqmrunlanguage);
        Task<ActionResult<MWQMRunLanguage>> Put(MWQMRunLanguage mwqmrunlanguage);
    }
    public partial class MWQMRunLanguageDBService : ControllerBase, IMWQMRunLanguageDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResultList { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;

            ValidationResultList = new List<ValidationResult>();
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<MWQMRunLanguage>> GetMWQMRunLanguageWithMWQMRunLanguageID(int MWQMRunLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            MWQMRunLanguage mwqmRunLanguage = (from c in db.MWQMRunLanguages.AsNoTracking()
                    where c.MWQMRunLanguageID == MWQMRunLanguageID
                    select c).FirstOrDefault();

            if (mwqmRunLanguage == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(mwqmRunLanguage));
        }
        public async Task<ActionResult<List<MWQMRunLanguage>>> GetMWQMRunLanguageList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<MWQMRunLanguage> mwqmRunLanguageList = (from c in db.MWQMRunLanguages.AsNoTracking() orderby c.MWQMRunLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(mwqmRunLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int MWQMRunLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            MWQMRunLanguage mwqmRunLanguage = (from c in db.MWQMRunLanguages
                    where c.MWQMRunLanguageID == MWQMRunLanguageID
                    select c).FirstOrDefault();

            if (mwqmRunLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMRunLanguage", "MWQMRunLanguageID", MWQMRunLanguageID.ToString())));
            }

            try
            {
                db.MWQMRunLanguages.Remove(mwqmRunLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<MWQMRunLanguage>> Post(MWQMRunLanguage mwqmRunLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.MWQMRunLanguages.Add(mwqmRunLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmRunLanguage));
        }
        public async Task<ActionResult<MWQMRunLanguage>> Put(MWQMRunLanguage mwqmRunLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.MWQMRunLanguages.Update(mwqmRunLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmRunLanguage));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MWQMRunLanguage mwqmRunLanguage = validationContext.ObjectInstance as MWQMRunLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmRunLanguage.MWQMRunLanguageID == 0)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMRunLanguageID"), new[] { nameof(mwqmRunLanguage.MWQMRunLanguageID) }));
                }

                if (!(from c in db.MWQMRunLanguages.AsNoTracking() select c).Where(c => c.MWQMRunLanguageID == mwqmRunLanguage.MWQMRunLanguageID).Any())
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMRunLanguage", "MWQMRunLanguageID", mwqmRunLanguage.MWQMRunLanguageID.ToString()), new[] { nameof(mwqmRunLanguage.MWQMRunLanguageID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)mwqmRunLanguage.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(mwqmRunLanguage.DBCommand) }));
            }

            MWQMRun MWQMRunMWQMRunID = null;
            MWQMRunMWQMRunID = (from c in db.MWQMRuns.AsNoTracking() where c.MWQMRunID == mwqmRunLanguage.MWQMRunID select c).FirstOrDefault();

            if (MWQMRunMWQMRunID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunID", mwqmRunLanguage.MWQMRunID.ToString()), new[] { nameof(mwqmRunLanguage.MWQMRunID)}));
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)mwqmRunLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(mwqmRunLanguage.Language) }));
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunComment))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RunComment"), new[] { nameof(mwqmRunLanguage.RunComment) }));
            }

            //RunComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmRunLanguage.TranslationStatusRunComment);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusRunComment"), new[] { nameof(mwqmRunLanguage.TranslationStatusRunComment) }));
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunWeatherComment))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RunWeatherComment"), new[] { nameof(mwqmRunLanguage.RunWeatherComment) }));
            }

            //RunWeatherComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmRunLanguage.TranslationStatusRunWeatherComment);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusRunWeatherComment"), new[] { nameof(mwqmRunLanguage.TranslationStatusRunWeatherComment) }));
            }

            if (mwqmRunLanguage.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mwqmRunLanguage.LastUpdateDate_UTC) }));
            }
            else
            {
                if (mwqmRunLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mwqmRunLanguage.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == mwqmRunLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmRunLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(mwqmRunLanguage.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mwqmRunLanguage.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResultList.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
