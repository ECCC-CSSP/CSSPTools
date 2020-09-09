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

namespace CSSPDBLocalIMServices
{
    public partial interface IAppTaskLanguageDBLocalIMService
    {
        Task<ActionResult<bool>> Delete(int AppTaskLanguageID);
        Task<ActionResult<List<AppTaskLanguage>>> GetAppTaskLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<AppTaskLanguage>> GetAppTaskLanguageWithAppTaskLanguageID(int AppTaskLanguageID);
        Task<ActionResult<AppTaskLanguage>> Post(AppTaskLanguage apptasklanguage);
        Task<ActionResult<AppTaskLanguage>> Put(AppTaskLanguage apptasklanguage);
    }
    public partial class AppTaskLanguageDBLocalIMService : ControllerBase, IAppTaskLanguageDBLocalIMService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBInMemoryContext dbLocalIM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageDBLocalIMService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBInMemoryContext dbLocalIM)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.dbLocalIM = dbLocalIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<AppTaskLanguage>> GetAppTaskLanguageWithAppTaskLanguageID(int AppTaskLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            AppTaskLanguage appTaskLanguage = (from c in dbLocalIM.AppTaskLanguages.Local
                    where c.AppTaskLanguageID == AppTaskLanguageID
                    select c).FirstOrDefault();

            if (appTaskLanguage == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(appTaskLanguage));
        }
        public async Task<ActionResult<List<AppTaskLanguage>>> GetAppTaskLanguageList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<AppTaskLanguage> appTaskLanguageList = (from c in dbLocalIM.AppTaskLanguages.Local orderby c.AppTaskLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(appTaskLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int AppTaskLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            AppTaskLanguage appTaskLanguage = (from c in dbLocalIM.AppTaskLanguages.Local
                    where c.AppTaskLanguageID == AppTaskLanguageID
                    select c).FirstOrDefault();

            if (appTaskLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", AppTaskLanguageID.ToString())));
            }

            try
            {
                dbLocalIM.AppTaskLanguages.Remove(appTaskLanguage);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<AppTaskLanguage>> Post(AppTaskLanguage appTaskLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.AppTaskLanguages.Add(appTaskLanguage);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(appTaskLanguage));
        }
        public async Task<ActionResult<AppTaskLanguage>> Put(AppTaskLanguage appTaskLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.AppTaskLanguages.Update(appTaskLanguage);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(appTaskLanguage));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            AppTaskLanguage appTaskLanguage = validationContext.ObjectInstance as AppTaskLanguage;

            if (actionDBType == ActionDBTypeEnum.Create)
            {
                if (appTaskLanguage.AppTaskLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskLanguageID"), new[] { nameof(appTaskLanguage.AppTaskLanguageID) });
                }
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (appTaskLanguage.AppTaskLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskLanguageID"), new[] { nameof(appTaskLanguage.AppTaskLanguageID) });
                }

                if (!(from c in dbLocalIM.AppTaskLanguages.Local select c).Where(c => c.AppTaskLanguageID == appTaskLanguage.AppTaskLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", appTaskLanguage.AppTaskLanguageID.ToString()), new[] { nameof(appTaskLanguage.AppTaskLanguageID) });
                }
            }

            AppTask AppTaskAppTaskID = null;
            AppTaskAppTaskID = (from c in dbLocalIM.AppTasks.Local where c.AppTaskID == appTaskLanguage.AppTaskID select c).FirstOrDefault();

            if (AppTaskAppTaskID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskLanguage.AppTaskID.ToString()), new[] { nameof(appTaskLanguage.AppTaskID) });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(appTaskLanguage.Language) });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.StatusText) && appTaskLanguage.StatusText.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", "250"), new[] { nameof(appTaskLanguage.StatusText) });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.ErrorText) && appTaskLanguage.ErrorText.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", "250"), new[] { nameof(appTaskLanguage.ErrorText) });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)appTaskLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { nameof(appTaskLanguage.TranslationStatus) });
            }

            if (appTaskLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(appTaskLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (appTaskLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(appTaskLanguage.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == appTaskLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", appTaskLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(appTaskLanguage.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(appTaskLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
