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

namespace CSSPServices
{
   public partial interface IAppTaskLanguageService
    {
       Task<ActionResult<bool>> Delete(int AppTaskLanguageID);
       Task<ActionResult<List<AppTaskLanguage>>> GetAppTaskLanguageList(int skip = 0, int take = 100);
       Task<ActionResult<AppTaskLanguage>> GetAppTaskLanguageWithAppTaskLanguageID(int AppTaskLanguageID);
       Task<ActionResult<AppTaskLanguage>> Post(AppTaskLanguage apptasklanguage);
       Task<ActionResult<AppTaskLanguage>> Put(AppTaskLanguage apptasklanguage);
    }
    public partial class AppTaskLanguageService : ControllerBase, IAppTaskLanguageService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<AppTaskLanguage>> GetAppTaskLanguageWithAppTaskLanguageID(int AppTaskLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                AppTaskLanguage appTaskLanguage = (from c in dbIM.AppTaskLanguages.AsNoTracking()
                                   where c.AppTaskLanguageID == AppTaskLanguageID
                                   select c).FirstOrDefault();

                if (appTaskLanguage == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(appTaskLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                AppTaskLanguage appTaskLanguage = (from c in dbLocal.AppTaskLanguages.AsNoTracking()
                        where c.AppTaskLanguageID == AppTaskLanguageID
                        select c).FirstOrDefault();

                if (appTaskLanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(appTaskLanguage));
            }
            else
            {
                AppTaskLanguage appTaskLanguage = (from c in db.AppTaskLanguages.AsNoTracking()
                        where c.AppTaskLanguageID == AppTaskLanguageID
                        select c).FirstOrDefault();

                if (appTaskLanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(appTaskLanguage));
            }
        }
        public async Task<ActionResult<List<AppTaskLanguage>>> GetAppTaskLanguageList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<AppTaskLanguage> appTaskLanguageList = (from c in dbIM.AppTaskLanguages.AsNoTracking() orderby c.AppTaskLanguageID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(appTaskLanguageList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<AppTaskLanguage> appTaskLanguageList = (from c in dbLocal.AppTaskLanguages.AsNoTracking() orderby c.AppTaskLanguageID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(appTaskLanguageList));
            }
            else
            {
                List<AppTaskLanguage> appTaskLanguageList = (from c in db.AppTaskLanguages.AsNoTracking() orderby c.AppTaskLanguageID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(appTaskLanguageList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int AppTaskLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                AppTaskLanguage appTaskLanguage = (from c in dbIM.AppTaskLanguages
                                   where c.AppTaskLanguageID == AppTaskLanguageID
                                   select c).FirstOrDefault();
            
                if (appTaskLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", AppTaskLanguageID.ToString())));
                }
            
                try
                {
                    dbIM.AppTaskLanguages.Remove(appTaskLanguage);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }
            
                return await Task.FromResult(Ok(true));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                AppTaskLanguage appTaskLanguage = (from c in dbLocal.AppTaskLanguages
                                   where c.AppTaskLanguageID == AppTaskLanguageID
                                   select c).FirstOrDefault();
                
                if (appTaskLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", AppTaskLanguageID.ToString())));
                }

                try
                {
                   dbLocal.AppTaskLanguages.Remove(appTaskLanguage);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
            else
            {
                AppTaskLanguage appTaskLanguage = (from c in db.AppTaskLanguages
                                   where c.AppTaskLanguageID == AppTaskLanguageID
                                   select c).FirstOrDefault();
                
                if (appTaskLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", AppTaskLanguageID.ToString())));
                }

                try
                {
                   db.AppTaskLanguages.Remove(appTaskLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<AppTaskLanguage>> Post(AppTaskLanguage appTaskLanguage)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.AppTaskLanguages.Add(appTaskLanguage);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(appTaskLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.AppTaskLanguages.Add(appTaskLanguage);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(appTaskLanguage));
            }
            else
            {
                try
                {
                   db.AppTaskLanguages.Add(appTaskLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(appTaskLanguage));
            }
        }
        public async Task<ActionResult<AppTaskLanguage>> Put(AppTaskLanguage appTaskLanguage)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.AppTaskLanguages.Update(appTaskLanguage);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(appTaskLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.AppTaskLanguages.Update(appTaskLanguage);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(appTaskLanguage));
            }
            else
            {
            try
            {
               db.AppTaskLanguages.Update(appTaskLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(appTaskLanguage));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            AppTaskLanguage appTaskLanguage = validationContext.ObjectInstance as AppTaskLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (appTaskLanguage.AppTaskLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskLanguageID"), new[] { nameof(appTaskLanguage.AppTaskLanguageID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.AppTaskLanguages select c).Where(c => c.AppTaskLanguageID == appTaskLanguage.AppTaskLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", appTaskLanguage.AppTaskLanguageID.ToString()), new[] { nameof(appTaskLanguage.AppTaskLanguageID) });
                    }
                }
                else
                {
                    if (!(from c in db.AppTaskLanguages select c).Where(c => c.AppTaskLanguageID == appTaskLanguage.AppTaskLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", appTaskLanguage.AppTaskLanguageID.ToString()), new[] { nameof(appTaskLanguage.AppTaskLanguageID) });
                    }
                }
            }

            AppTask AppTaskAppTaskID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                AppTaskAppTaskID = (from c in dbLocal.AppTasks where c.AppTaskID == appTaskLanguage.AppTaskID select c).FirstOrDefault();
                if (AppTaskAppTaskID == null)
                {
                    AppTaskAppTaskID = (from c in dbIM.AppTasks where c.AppTaskID == appTaskLanguage.AppTaskID select c).FirstOrDefault();
                }
            }
            else
            {
                AppTaskAppTaskID = (from c in db.AppTasks where c.AppTaskID == appTaskLanguage.AppTaskID select c).FirstOrDefault();
            }

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
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == appTaskLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == appTaskLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == appTaskLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

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
