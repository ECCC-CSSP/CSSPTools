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
    public partial interface IMWQMSampleLanguageDBLocalService
    {
        Task<ActionResult<bool>> Delete(int MWQMSampleLanguageID);
        Task<ActionResult<List<MWQMSampleLanguage>>> GetMWQMSampleLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<MWQMSampleLanguage>> GetMWQMSampleLanguageWithMWQMSampleLanguageID(int MWQMSampleLanguageID);
        Task<ActionResult<MWQMSampleLanguage>> Post(MWQMSampleLanguage mwqmsamplelanguage);
        Task<ActionResult<MWQMSampleLanguage>> Put(MWQMSampleLanguage mwqmsamplelanguage);
    }
    public partial class MWQMSampleLanguageDBLocalService : ControllerBase, IMWQMSampleLanguageDBLocalService
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
        public MWQMSampleLanguageDBLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<MWQMSampleLanguage>> GetMWQMSampleLanguageWithMWQMSampleLanguageID(int MWQMSampleLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            MWQMSampleLanguage mwqmSampleLanguage = (from c in dbLocal.MWQMSampleLanguages.AsNoTracking()
                    where c.MWQMSampleLanguageID == MWQMSampleLanguageID
                    select c).FirstOrDefault();

            if (mwqmSampleLanguage == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(mwqmSampleLanguage));
        }
        public async Task<ActionResult<List<MWQMSampleLanguage>>> GetMWQMSampleLanguageList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<MWQMSampleLanguage> mwqmSampleLanguageList = (from c in dbLocal.MWQMSampleLanguages.AsNoTracking() orderby c.MWQMSampleLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(mwqmSampleLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int MWQMSampleLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            MWQMSampleLanguage mwqmSampleLanguage = (from c in dbLocal.MWQMSampleLanguages
                    where c.MWQMSampleLanguageID == MWQMSampleLanguageID
                    select c).FirstOrDefault();

            if (mwqmSampleLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSampleLanguage", "MWQMSampleLanguageID", MWQMSampleLanguageID.ToString())));
            }

            try
            {
                dbLocal.MWQMSampleLanguages.Remove(mwqmSampleLanguage);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<MWQMSampleLanguage>> Post(MWQMSampleLanguage mwqmSampleLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmSampleLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (mwqmSampleLanguage.MWQMSampleLanguageID == 0)
            {
                int LastMWQMSampleLanguageID = (from c in dbLocal.MWQMSampleLanguages.AsNoTracking()
                          orderby c.MWQMSampleLanguageID descending
                          select c.MWQMSampleLanguageID).FirstOrDefault();

                mwqmSampleLanguage.MWQMSampleLanguageID = LastMWQMSampleLanguageID + 1;
            }

            try
            {
                dbLocal.MWQMSampleLanguages.Add(mwqmSampleLanguage);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSampleLanguage));
        }
        public async Task<ActionResult<MWQMSampleLanguage>> Put(MWQMSampleLanguage mwqmSampleLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmSampleLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocal.MWQMSampleLanguages.Update(mwqmSampleLanguage);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSampleLanguage));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MWQMSampleLanguage mwqmSampleLanguage = validationContext.ObjectInstance as MWQMSampleLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSampleLanguage.MWQMSampleLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMSampleLanguageID"), new[] { nameof(mwqmSampleLanguage.MWQMSampleLanguageID) });
                }

                if (!(from c in dbLocal.MWQMSampleLanguages.AsNoTracking() select c).Where(c => c.MWQMSampleLanguageID == mwqmSampleLanguage.MWQMSampleLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSampleLanguage", "MWQMSampleLanguageID", mwqmSampleLanguage.MWQMSampleLanguageID.ToString()), new[] { nameof(mwqmSampleLanguage.MWQMSampleLanguageID) });
                }
            }

            MWQMSample MWQMSampleMWQMSampleID = null;
            MWQMSampleMWQMSampleID = (from c in dbLocal.MWQMSamples.AsNoTracking() where c.MWQMSampleID == mwqmSampleLanguage.MWQMSampleID select c).FirstOrDefault();

            if (MWQMSampleMWQMSampleID == null)
            {
                MWQMSampleMWQMSampleID = (from c in dbLocalIM.MWQMSamples.Local where c.MWQMSampleID == mwqmSampleLanguage.MWQMSampleID select c).FirstOrDefault();

                if (MWQMSampleMWQMSampleID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSample", "MWQMSampleID", mwqmSampleLanguage.MWQMSampleID.ToString()), new[] { nameof(mwqmSampleLanguage.MWQMSampleID) });
                }

            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)mwqmSampleLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(mwqmSampleLanguage.Language) });
            }

            if (string.IsNullOrWhiteSpace(mwqmSampleLanguage.MWQMSampleNote))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMSampleNote"), new[] { nameof(mwqmSampleLanguage.MWQMSampleNote) });
            }

            //MWQMSampleNote has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmSampleLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { nameof(mwqmSampleLanguage.TranslationStatus) });
            }

            if (mwqmSampleLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mwqmSampleLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (mwqmSampleLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mwqmSampleLanguage.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == mwqmSampleLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == mwqmSampleLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

                if (TVItemLastUpdateContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmSampleLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(mwqmSampleLanguage.LastUpdateContactTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mwqmSampleLanguage.LastUpdateContactTVItemID) });
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
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mwqmSampleLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
