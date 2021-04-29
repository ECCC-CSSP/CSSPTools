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
    public partial interface IBoxModelLanguageDBService
    {
        Task<ActionResult<bool>> Delete(int BoxModelLanguageID);
        Task<ActionResult<List<BoxModelLanguage>>> GetBoxModelLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<BoxModelLanguage>> GetBoxModelLanguageWithBoxModelLanguageID(int BoxModelLanguageID);
        Task<ActionResult<BoxModelLanguage>> Post(BoxModelLanguage boxmodellanguage);
        Task<ActionResult<BoxModelLanguage>> Put(BoxModelLanguage boxmodellanguage);
    }
    public partial class BoxModelLanguageDBService : ControllerBase, IBoxModelLanguageDBService
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
        public BoxModelLanguageDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<BoxModelLanguage>> GetBoxModelLanguageWithBoxModelLanguageID(int BoxModelLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            BoxModelLanguage boxModelLanguage = (from c in db.BoxModelLanguages.AsNoTracking()
                    where c.BoxModelLanguageID == BoxModelLanguageID
                    select c).FirstOrDefault();

            if (boxModelLanguage == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(boxModelLanguage));
        }
        public async Task<ActionResult<List<BoxModelLanguage>>> GetBoxModelLanguageList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<BoxModelLanguage> boxModelLanguageList = (from c in db.BoxModelLanguages.AsNoTracking() orderby c.BoxModelLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(boxModelLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int BoxModelLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            BoxModelLanguage boxModelLanguage = (from c in db.BoxModelLanguages
                    where c.BoxModelLanguageID == BoxModelLanguageID
                    select c).FirstOrDefault();

            if (boxModelLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "BoxModelLanguage", "BoxModelLanguageID", BoxModelLanguageID.ToString())));
            }

            try
            {
                db.BoxModelLanguages.Remove(boxModelLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<BoxModelLanguage>> Post(BoxModelLanguage boxModelLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(boxModelLanguage), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.BoxModelLanguages.Add(boxModelLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(boxModelLanguage));
        }
        public async Task<ActionResult<BoxModelLanguage>> Put(BoxModelLanguage boxModelLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(boxModelLanguage), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.BoxModelLanguages.Update(boxModelLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(boxModelLanguage));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            BoxModelLanguage boxModelLanguage = validationContext.ObjectInstance as BoxModelLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (boxModelLanguage.BoxModelLanguageID == 0)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "BoxModelLanguageID"), new[] { nameof(boxModelLanguage.BoxModelLanguageID) }));
                }

                if (!(from c in db.BoxModelLanguages.AsNoTracking() select c).Where(c => c.BoxModelLanguageID == boxModelLanguage.BoxModelLanguageID).Any())
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "BoxModelLanguage", "BoxModelLanguageID", boxModelLanguage.BoxModelLanguageID.ToString()), new[] { nameof(boxModelLanguage.BoxModelLanguageID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)boxModelLanguage.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(boxModelLanguage.DBCommand) }));
            }

            BoxModel BoxModelBoxModelID = null;
            BoxModelBoxModelID = (from c in db.BoxModels.AsNoTracking() where c.BoxModelID == boxModelLanguage.BoxModelID select c).FirstOrDefault();

            if (BoxModelBoxModelID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelID", boxModelLanguage.BoxModelID.ToString()), new[] { nameof(boxModelLanguage.BoxModelID)}));
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)boxModelLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(boxModelLanguage.Language) }));
            }

            if (string.IsNullOrWhiteSpace(boxModelLanguage.ScenarioName))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ScenarioName"), new[] { nameof(boxModelLanguage.ScenarioName) }));
            }

            if (!string.IsNullOrWhiteSpace(boxModelLanguage.ScenarioName) && boxModelLanguage.ScenarioName.Length > 250)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ScenarioName", "250"), new[] { nameof(boxModelLanguage.ScenarioName) }));
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)boxModelLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { nameof(boxModelLanguage.TranslationStatus) }));
            }

            if (boxModelLanguage.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(boxModelLanguage.LastUpdateDate_UTC) }));
            }
            else
            {
                if (boxModelLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(boxModelLanguage.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == boxModelLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", boxModelLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(boxModelLanguage.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(boxModelLanguage.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResultList.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
