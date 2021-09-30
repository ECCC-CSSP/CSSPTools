/*
 * Manually edited
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
using CSSPServerLoggedInServices;
using Microsoft.Extensions.Configuration;
using CSSPHelperModels;

namespace CSSPDBServices
{
    public partial interface IAppTaskLanguageDBService
    {
        Task<ActionResult<bool>> Delete(int AppTaskLanguageID);
        Task<ActionResult<List<AppTaskLanguage>>> GetAppTaskLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<AppTaskLanguage>> GetAppTaskLanguageWithAppTaskLanguageID(int AppTaskLanguageID);
        Task<ActionResult<AppTaskLanguage>> Post(AppTaskLanguage apptasklanguage);
        Task<ActionResult<AppTaskLanguage>> Put(AppTaskLanguage apptasklanguage);
    }
    public partial class AppTaskLanguageDBService : ControllerBase, IAppTaskLanguageDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
        private CSSPDBContext db { get; }
        private ErrRes errRes { get; set; } = new ErrRes();
        #endregion Properties

        #region Constructors
        public AppTaskLanguageDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPServerLoggedInService CSSPServerLoggedInService, CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.CSSPServerLoggedInService = CSSPServerLoggedInService;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<AppTaskLanguage>> GetAppTaskLanguageWithAppTaskLanguageID(int AppTaskLanguageID)
        {
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            AppTaskLanguage appTaskLanguage = (from c in db.AppTaskLanguages.AsNoTracking()
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
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            List<AppTaskLanguage> appTaskLanguageList = (from c in db.AppTaskLanguages.AsNoTracking() orderby c.AppTaskLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(appTaskLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int AppTaskLanguageID)
        {
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            AppTaskLanguage appTaskLanguage = (from c in db.AppTaskLanguages
                                               where c.AppTaskLanguageID == AppTaskLanguageID
                                               select c).FirstOrDefault();

            if (appTaskLanguage == null)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", AppTaskLanguageID.ToString()));
                return await Task.FromResult(BadRequest(errRes));
            }

            try
            {
                db.AppTaskLanguages.Remove(appTaskLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                errRes.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                return await Task.FromResult(BadRequest(errRes));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<AppTaskLanguage>> Post(AppTaskLanguage appTaskLanguage)
        {
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            if (!await Validate (new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(errRes));
            }

            try
            {
                db.AppTaskLanguages.Add(appTaskLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                errRes.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                return await Task.FromResult(BadRequest(errRes));
            }

            return await Task.FromResult(Ok(appTaskLanguage));
        }
        public async Task<ActionResult<AppTaskLanguage>> Put(AppTaskLanguage appTaskLanguage)
        {
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            if (!await Validate(new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(errRes));
            }

            try
            {
                db.AppTaskLanguages.Update(appTaskLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                errRes.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                return await Task.FromResult(BadRequest(errRes));
            }

            return await Task.FromResult(Ok(appTaskLanguage));
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            AppTaskLanguage appTaskLanguage = validationContext.ObjectInstance as AppTaskLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (appTaskLanguage.AppTaskLanguageID == 0)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskLanguageID"));
                }

                if (!(from c in db.AppTaskLanguages.AsNoTracking() select c).Where(c => c.AppTaskLanguageID == appTaskLanguage.AppTaskLanguageID).Any())
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", appTaskLanguage.AppTaskLanguageID.ToString()));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)appTaskLanguage.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            }

            AppTask AppTaskAppTaskID = null;
            AppTaskAppTaskID = (from c in db.AppTasks.AsNoTracking() where c.AppTaskID == appTaskLanguage.AppTaskID select c).FirstOrDefault();

            if (AppTaskAppTaskID == null)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskLanguage.AppTaskID.ToString()));
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.StatusText) && appTaskLanguage.StatusText.Length > 250)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", "250"));
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.ErrorText) && appTaskLanguage.ErrorText.Length > 250)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", "250"));
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)appTaskLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
            }

            if (appTaskLanguage.LastUpdateDate_UTC.Year == 1)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"));
            }
            else
            {
                if (appTaskLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == appTaskLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", appTaskLanguage.LastUpdateContactTVItemID.ToString()));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"));
                }
            }

            return errRes.ErrList.Count == 0 ? await Task.FromResult(true) : await Task.FromResult(false);
        }
        #endregion Functions private
    }

}
