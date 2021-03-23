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
using CSSPScrambleServices;

namespace CSSPDBServices
{
    public partial interface ISpillLanguageDBService
    {
        Task<ActionResult<bool>> Delete(int SpillLanguageID);
        Task<ActionResult<List<SpillLanguage>>> GetSpillLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<SpillLanguage>> GetSpillLanguageWithSpillLanguageID(int SpillLanguageID);
        Task<ActionResult<SpillLanguage>> Post(SpillLanguage spilllanguage);
        Task<ActionResult<SpillLanguage>> Put(SpillLanguage spilllanguage);
    }
    public partial class SpillLanguageDBService : ControllerBase, ISpillLanguageDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IScrambleService ScrambleService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public SpillLanguageDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ScrambleService = ScrambleService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<SpillLanguage>> GetSpillLanguageWithSpillLanguageID(int SpillLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            SpillLanguage spillLanguage = (from c in db.SpillLanguages.AsNoTracking()
                    where c.SpillLanguageID == SpillLanguageID
                    select c).FirstOrDefault();

            if (spillLanguage == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(spillLanguage));
        }
        public async Task<ActionResult<List<SpillLanguage>>> GetSpillLanguageList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<SpillLanguage> spillLanguageList = (from c in db.SpillLanguages.AsNoTracking() orderby c.SpillLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(spillLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int SpillLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            SpillLanguage spillLanguage = (from c in db.SpillLanguages
                    where c.SpillLanguageID == SpillLanguageID
                    select c).FirstOrDefault();

            if (spillLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SpillLanguage", "SpillLanguageID", SpillLanguageID.ToString())));
            }

            try
            {
                db.SpillLanguages.Remove(spillLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<SpillLanguage>> Post(SpillLanguage spillLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            ValidationResults = Validate(new ValidationContext(spillLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.SpillLanguages.Add(spillLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(spillLanguage));
        }
        public async Task<ActionResult<SpillLanguage>> Put(SpillLanguage spillLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            ValidationResults = Validate(new ValidationContext(spillLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.SpillLanguages.Update(spillLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(spillLanguage));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            SpillLanguage spillLanguage = validationContext.ObjectInstance as SpillLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (spillLanguage.SpillLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SpillLanguageID"), new[] { nameof(spillLanguage.SpillLanguageID) });
                }

                if (!(from c in db.SpillLanguages.AsNoTracking() select c).Where(c => c.SpillLanguageID == spillLanguage.SpillLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SpillLanguage", "SpillLanguageID", spillLanguage.SpillLanguageID.ToString()), new[] { nameof(spillLanguage.SpillLanguageID) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)spillLanguage.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(spillLanguage.DBCommand) });
            }

            Spill SpillSpillID = null;
            SpillSpillID = (from c in db.Spills.AsNoTracking() where c.SpillID == spillLanguage.SpillID select c).FirstOrDefault();

            if (SpillSpillID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillID", spillLanguage.SpillID.ToString()), new[] { nameof(spillLanguage.SpillID) });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)spillLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(spillLanguage.Language) });
            }

            if (string.IsNullOrWhiteSpace(spillLanguage.SpillComment))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SpillComment"), new[] { nameof(spillLanguage.SpillComment) });
            }

            //SpillComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)spillLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { nameof(spillLanguage.TranslationStatus) });
            }

            if (spillLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(spillLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (spillLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(spillLanguage.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == spillLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", spillLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(spillLanguage.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(spillLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
