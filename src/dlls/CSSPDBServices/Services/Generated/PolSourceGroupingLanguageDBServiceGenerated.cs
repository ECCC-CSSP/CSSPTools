/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBServices.exe
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
    public partial interface IPolSourceGroupingLanguageDBService
    {
        Task<ActionResult<bool>> Delete(int PolSourceGroupingLanguageID);
        Task<ActionResult<List<PolSourceGroupingLanguage>>> GetPolSourceGroupingLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<PolSourceGroupingLanguage>> GetPolSourceGroupingLanguageWithPolSourceGroupingLanguageID(int PolSourceGroupingLanguageID);
        Task<ActionResult<PolSourceGroupingLanguage>> Post(PolSourceGroupingLanguage polsourcegroupinglanguage);
        Task<ActionResult<PolSourceGroupingLanguage>> Put(PolSourceGroupingLanguage polsourcegroupinglanguage);
    }
    public partial class PolSourceGroupingLanguageDBService : ControllerBase, IPolSourceGroupingLanguageDBService
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
        public PolSourceGroupingLanguageDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<PolSourceGroupingLanguage>> GetPolSourceGroupingLanguageWithPolSourceGroupingLanguageID(int PolSourceGroupingLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            PolSourceGroupingLanguage polSourceGroupingLanguage = (from c in db.PolSourceGroupingLanguages.AsNoTracking()
                    where c.PolSourceGroupingLanguageID == PolSourceGroupingLanguageID
                    select c).FirstOrDefault();

            if (polSourceGroupingLanguage == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(polSourceGroupingLanguage));
        }
        public async Task<ActionResult<List<PolSourceGroupingLanguage>>> GetPolSourceGroupingLanguageList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<PolSourceGroupingLanguage> polSourceGroupingLanguageList = (from c in db.PolSourceGroupingLanguages.AsNoTracking() orderby c.PolSourceGroupingLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(polSourceGroupingLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int PolSourceGroupingLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            PolSourceGroupingLanguage polSourceGroupingLanguage = (from c in db.PolSourceGroupingLanguages
                    where c.PolSourceGroupingLanguageID == PolSourceGroupingLanguageID
                    select c).FirstOrDefault();

            if (polSourceGroupingLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceGroupingLanguage", "PolSourceGroupingLanguageID", PolSourceGroupingLanguageID.ToString())));
            }

            try
            {
                db.PolSourceGroupingLanguages.Remove(polSourceGroupingLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<PolSourceGroupingLanguage>> Post(PolSourceGroupingLanguage polSourceGroupingLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceGroupingLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.PolSourceGroupingLanguages.Add(polSourceGroupingLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceGroupingLanguage));
        }
        public async Task<ActionResult<PolSourceGroupingLanguage>> Put(PolSourceGroupingLanguage polSourceGroupingLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceGroupingLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.PolSourceGroupingLanguages.Update(polSourceGroupingLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceGroupingLanguage));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            PolSourceGroupingLanguage polSourceGroupingLanguage = validationContext.ObjectInstance as PolSourceGroupingLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceGroupingLanguage.PolSourceGroupingLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceGroupingLanguageID"), new[] { nameof(polSourceGroupingLanguage.PolSourceGroupingLanguageID) });
                }

                if (!(from c in db.PolSourceGroupingLanguages.AsNoTracking() select c).Where(c => c.PolSourceGroupingLanguageID == polSourceGroupingLanguage.PolSourceGroupingLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceGroupingLanguage", "PolSourceGroupingLanguageID", polSourceGroupingLanguage.PolSourceGroupingLanguageID.ToString()), new[] { nameof(polSourceGroupingLanguage.PolSourceGroupingLanguageID) });
                }
            }

            PolSourceGrouping PolSourceGroupingPolSourceGroupingID = null;
            PolSourceGroupingPolSourceGroupingID = (from c in db.PolSourceGroupings.AsNoTracking() where c.PolSourceGroupingID == polSourceGroupingLanguage.PolSourceGroupingID select c).FirstOrDefault();

            if (PolSourceGroupingPolSourceGroupingID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceGrouping", "PolSourceGroupingID", polSourceGroupingLanguage.PolSourceGroupingID.ToString()), new[] { nameof(polSourceGroupingLanguage.PolSourceGroupingID) });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)polSourceGroupingLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(polSourceGroupingLanguage.Language) });
            }

            if (string.IsNullOrWhiteSpace(polSourceGroupingLanguage.SourceName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SourceName"), new[] { nameof(polSourceGroupingLanguage.SourceName) });
            }

            if (!string.IsNullOrWhiteSpace(polSourceGroupingLanguage.SourceName) && polSourceGroupingLanguage.SourceName.Length > 500)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SourceName", "500"), new[] { nameof(polSourceGroupingLanguage.SourceName) });
            }

            if (polSourceGroupingLanguage.SourceNameOrder < 0 || polSourceGroupingLanguage.SourceNameOrder > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourceNameOrder", "0", "1000"), new[] { nameof(polSourceGroupingLanguage.SourceNameOrder) });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)polSourceGroupingLanguage.TranslationStatusSourceName);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusSourceName"), new[] { nameof(polSourceGroupingLanguage.TranslationStatusSourceName) });
            }

            if (string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Init))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Init"), new[] { nameof(polSourceGroupingLanguage.Init) });
            }

            if (!string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Init) && polSourceGroupingLanguage.Init.Length > 50)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Init", "50"), new[] { nameof(polSourceGroupingLanguage.Init) });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)polSourceGroupingLanguage.TranslationStatusInit);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusInit"), new[] { nameof(polSourceGroupingLanguage.TranslationStatusInit) });
            }

            if (string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Description))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Description"), new[] { nameof(polSourceGroupingLanguage.Description) });
            }

            if (!string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Description) && polSourceGroupingLanguage.Description.Length > 500)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Description", "500"), new[] { nameof(polSourceGroupingLanguage.Description) });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)polSourceGroupingLanguage.TranslationStatusDescription);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusDescription"), new[] { nameof(polSourceGroupingLanguage.TranslationStatusDescription) });
            }

            if (string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Report))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Report"), new[] { nameof(polSourceGroupingLanguage.Report) });
            }

            if (!string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Report) && polSourceGroupingLanguage.Report.Length > 500)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Report", "500"), new[] { nameof(polSourceGroupingLanguage.Report) });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)polSourceGroupingLanguage.TranslationStatusReport);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusReport"), new[] { nameof(polSourceGroupingLanguage.TranslationStatusReport) });
            }

            if (string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Text))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Text"), new[] { nameof(polSourceGroupingLanguage.Text) });
            }

            if (!string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Text) && polSourceGroupingLanguage.Text.Length > 500)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Text", "500"), new[] { nameof(polSourceGroupingLanguage.Text) });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)polSourceGroupingLanguage.TranslationStatusText);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusText"), new[] { nameof(polSourceGroupingLanguage.TranslationStatusText) });
            }

            if (polSourceGroupingLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(polSourceGroupingLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (polSourceGroupingLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(polSourceGroupingLanguage.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == polSourceGroupingLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceGroupingLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(polSourceGroupingLanguage.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(polSourceGroupingLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
