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
using LocalServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBLocalServices
{
    public partial interface IMWQMRunLanguageDBLocalService
    {
        Task<ActionResult<bool>> Delete(int MWQMRunLanguageID);
        Task<ActionResult<List<MWQMRunLanguage>>> GetMWQMRunLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<MWQMRunLanguage>> GetMWQMRunLanguageWithMWQMRunLanguageID(int MWQMRunLanguageID);
        Task<ActionResult<MWQMRunLanguage>> Post(MWQMRunLanguage mwqmrunlanguage);
        Task<ActionResult<MWQMRunLanguage>> Put(MWQMRunLanguage mwqmrunlanguage);
    }
    public partial class MWQMRunLanguageDBLocalService : ControllerBase, IMWQMRunLanguageDBLocalService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBInMemoryContext dbLocalIM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageDBLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext dbLocal,
           CSSPDBInMemoryContext dbLocalIM)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.dbLocal = dbLocal;
            this.dbLocalIM = dbLocalIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<MWQMRunLanguage>> GetMWQMRunLanguageWithMWQMRunLanguageID(int MWQMRunLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            MWQMRunLanguage mwqmRunLanguage = (from c in dbLocal.MWQMRunLanguages.AsNoTracking()
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
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<MWQMRunLanguage> mwqmRunLanguageList = (from c in dbLocal.MWQMRunLanguages.AsNoTracking() orderby c.MWQMRunLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(mwqmRunLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int MWQMRunLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            MWQMRunLanguage mwqmRunLanguage = (from c in dbLocal.MWQMRunLanguages
                    where c.MWQMRunLanguageID == MWQMRunLanguageID
                    select c).FirstOrDefault();

            if (mwqmRunLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMRunLanguage", "MWQMRunLanguageID", MWQMRunLanguageID.ToString())));
            }

            try
            {
                dbLocal.MWQMRunLanguages.Remove(mwqmRunLanguage);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<MWQMRunLanguage>> Post(MWQMRunLanguage mwqmRunLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (mwqmRunLanguage.MWQMRunLanguageID == 0)
            {
                int LastMWQMRunLanguageID = (from c in dbLocal.MWQMRunLanguages.AsNoTracking()
                          orderby c.MWQMRunLanguageID descending
                          select c.MWQMRunLanguageID).FirstOrDefault();

                mwqmRunLanguage.MWQMRunLanguageID = LastMWQMRunLanguageID + 1;
            }

            try
            {
                dbLocal.MWQMRunLanguages.Add(mwqmRunLanguage);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmRunLanguage));
        }
        public async Task<ActionResult<MWQMRunLanguage>> Put(MWQMRunLanguage mwqmRunLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocal.MWQMRunLanguages.Update(mwqmRunLanguage);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmRunLanguage));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MWQMRunLanguage mwqmRunLanguage = validationContext.ObjectInstance as MWQMRunLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmRunLanguage.MWQMRunLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMRunLanguageID"), new[] { nameof(mwqmRunLanguage.MWQMRunLanguageID) });
                }

                if (!(from c in dbLocal.MWQMRunLanguages.AsNoTracking() select c).Where(c => c.MWQMRunLanguageID == mwqmRunLanguage.MWQMRunLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMRunLanguage", "MWQMRunLanguageID", mwqmRunLanguage.MWQMRunLanguageID.ToString()), new[] { nameof(mwqmRunLanguage.MWQMRunLanguageID) });
                }
            }

            MWQMRun MWQMRunMWQMRunID = null;
            MWQMRunMWQMRunID = (from c in dbLocal.MWQMRuns.AsNoTracking() where c.MWQMRunID == mwqmRunLanguage.MWQMRunID select c).FirstOrDefault();

            if (MWQMRunMWQMRunID == null)
            {
                MWQMRunMWQMRunID = (from c in dbLocalIM.MWQMRuns.Local where c.MWQMRunID == mwqmRunLanguage.MWQMRunID select c).FirstOrDefault();

                if (MWQMRunMWQMRunID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunID", mwqmRunLanguage.MWQMRunID.ToString()), new[] { nameof(mwqmRunLanguage.MWQMRunID) });
                }

            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)mwqmRunLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(mwqmRunLanguage.Language) });
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunComment))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RunComment"), new[] { nameof(mwqmRunLanguage.RunComment) });
            }

            //RunComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmRunLanguage.TranslationStatusRunComment);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusRunComment"), new[] { nameof(mwqmRunLanguage.TranslationStatusRunComment) });
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunWeatherComment))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RunWeatherComment"), new[] { nameof(mwqmRunLanguage.RunWeatherComment) });
            }

            //RunWeatherComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmRunLanguage.TranslationStatusRunWeatherComment);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusRunWeatherComment"), new[] { nameof(mwqmRunLanguage.TranslationStatusRunWeatherComment) });
            }

            if (mwqmRunLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mwqmRunLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (mwqmRunLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mwqmRunLanguage.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == mwqmRunLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == mwqmRunLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

                if (TVItemLastUpdateContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmRunLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(mwqmRunLanguage.LastUpdateContactTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mwqmRunLanguage.LastUpdateContactTVItemID) });
                    }
                }

            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mwqmRunLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
