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
using LoggedInServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBServices
{
    public partial interface ITVFileLanguageDBService
    {
        Task<ActionResult<bool>> Delete(int TVFileLanguageID);
        Task<ActionResult<List<TVFileLanguage>>> GetTVFileLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<TVFileLanguage>> GetTVFileLanguageWithTVFileLanguageID(int TVFileLanguageID);
        Task<ActionResult<TVFileLanguage>> Post(TVFileLanguage tvfilelanguage);
        Task<ActionResult<TVFileLanguage>> Put(TVFileLanguage tvfilelanguage);
    }
    public partial class TVFileLanguageDBService : ControllerBase, ITVFileLanguageDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileLanguageDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<TVFileLanguage>> GetTVFileLanguageWithTVFileLanguageID(int TVFileLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            TVFileLanguage tvFileLanguage = (from c in db.TVFileLanguages.AsNoTracking()
                    where c.TVFileLanguageID == TVFileLanguageID
                    select c).FirstOrDefault();

            if (tvFileLanguage == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(tvFileLanguage));
        }
        public async Task<ActionResult<List<TVFileLanguage>>> GetTVFileLanguageList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<TVFileLanguage> tvFileLanguageList = (from c in db.TVFileLanguages.AsNoTracking() orderby c.TVFileLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(tvFileLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int TVFileLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVFileLanguage tvFileLanguage = (from c in db.TVFileLanguages
                    where c.TVFileLanguageID == TVFileLanguageID
                    select c).FirstOrDefault();

            if (tvFileLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageID", TVFileLanguageID.ToString())));
            }

            try
            {
                db.TVFileLanguages.Remove(tvFileLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<TVFileLanguage>> Post(TVFileLanguage tvFileLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvFileLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.TVFileLanguages.Add(tvFileLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvFileLanguage));
        }
        public async Task<ActionResult<TVFileLanguage>> Put(TVFileLanguage tvFileLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvFileLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.TVFileLanguages.Update(tvFileLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvFileLanguage));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            TVFileLanguage tvFileLanguage = validationContext.ObjectInstance as TVFileLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvFileLanguage.TVFileLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVFileLanguageID"), new[] { nameof(tvFileLanguage.TVFileLanguageID) });
                }

                if (!(from c in db.TVFileLanguages.AsNoTracking() select c).Where(c => c.TVFileLanguageID == tvFileLanguage.TVFileLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageID", tvFileLanguage.TVFileLanguageID.ToString()), new[] { nameof(tvFileLanguage.TVFileLanguageID) });
                }
            }

            TVFile TVFileTVFileID = null;
            TVFileTVFileID = (from c in db.TVFiles.AsNoTracking() where c.TVFileID == tvFileLanguage.TVFileID select c).FirstOrDefault();

            if (TVFileTVFileID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileID", tvFileLanguage.TVFileID.ToString()), new[] { nameof(tvFileLanguage.TVFileID) });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvFileLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(tvFileLanguage.Language) });
            }

            //FileDescription has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)tvFileLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { nameof(tvFileLanguage.TranslationStatus) });
            }

            if (tvFileLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(tvFileLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (tvFileLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(tvFileLanguage.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == tvFileLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvFileLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(tvFileLanguage.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(tvFileLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}