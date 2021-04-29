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
    public partial interface IInfrastructureLanguageDBService
    {
        Task<ActionResult<bool>> Delete(int InfrastructureLanguageID);
        Task<ActionResult<List<InfrastructureLanguage>>> GetInfrastructureLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<InfrastructureLanguage>> GetInfrastructureLanguageWithInfrastructureLanguageID(int InfrastructureLanguageID);
        Task<ActionResult<InfrastructureLanguage>> Post(InfrastructureLanguage infrastructurelanguage);
        Task<ActionResult<InfrastructureLanguage>> Put(InfrastructureLanguage infrastructurelanguage);
    }
    public partial class InfrastructureLanguageDBService : ControllerBase, IInfrastructureLanguageDBService
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
        public InfrastructureLanguageDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<InfrastructureLanguage>> GetInfrastructureLanguageWithInfrastructureLanguageID(int InfrastructureLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            InfrastructureLanguage infrastructureLanguage = (from c in db.InfrastructureLanguages.AsNoTracking()
                    where c.InfrastructureLanguageID == InfrastructureLanguageID
                    select c).FirstOrDefault();

            if (infrastructureLanguage == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(infrastructureLanguage));
        }
        public async Task<ActionResult<List<InfrastructureLanguage>>> GetInfrastructureLanguageList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<InfrastructureLanguage> infrastructureLanguageList = (from c in db.InfrastructureLanguages.AsNoTracking() orderby c.InfrastructureLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(infrastructureLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int InfrastructureLanguageID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            InfrastructureLanguage infrastructureLanguage = (from c in db.InfrastructureLanguages
                    where c.InfrastructureLanguageID == InfrastructureLanguageID
                    select c).FirstOrDefault();

            if (infrastructureLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "InfrastructureLanguage", "InfrastructureLanguageID", InfrastructureLanguageID.ToString())));
            }

            try
            {
                db.InfrastructureLanguages.Remove(infrastructureLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<InfrastructureLanguage>> Post(InfrastructureLanguage infrastructureLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(infrastructureLanguage), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.InfrastructureLanguages.Add(infrastructureLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(infrastructureLanguage));
        }
        public async Task<ActionResult<InfrastructureLanguage>> Put(InfrastructureLanguage infrastructureLanguage)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(infrastructureLanguage), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.InfrastructureLanguages.Update(infrastructureLanguage);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(infrastructureLanguage));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            InfrastructureLanguage infrastructureLanguage = validationContext.ObjectInstance as InfrastructureLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (infrastructureLanguage.InfrastructureLanguageID == 0)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "InfrastructureLanguageID"), new[] { nameof(infrastructureLanguage.InfrastructureLanguageID) }));
                }

                if (!(from c in db.InfrastructureLanguages.AsNoTracking() select c).Where(c => c.InfrastructureLanguageID == infrastructureLanguage.InfrastructureLanguageID).Any())
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "InfrastructureLanguage", "InfrastructureLanguageID", infrastructureLanguage.InfrastructureLanguageID.ToString()), new[] { nameof(infrastructureLanguage.InfrastructureLanguageID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)infrastructureLanguage.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(infrastructureLanguage.DBCommand) }));
            }

            Infrastructure InfrastructureInfrastructureID = null;
            InfrastructureInfrastructureID = (from c in db.Infrastructures.AsNoTracking() where c.InfrastructureID == infrastructureLanguage.InfrastructureID select c).FirstOrDefault();

            if (InfrastructureInfrastructureID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureID", infrastructureLanguage.InfrastructureID.ToString()), new[] { nameof(infrastructureLanguage.InfrastructureID)}));
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)infrastructureLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(infrastructureLanguage.Language) }));
            }

            if (string.IsNullOrWhiteSpace(infrastructureLanguage.Comment))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Comment"), new[] { nameof(infrastructureLanguage.Comment) }));
            }

            //Comment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)infrastructureLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { nameof(infrastructureLanguage.TranslationStatus) }));
            }

            if (infrastructureLanguage.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(infrastructureLanguage.LastUpdateDate_UTC) }));
            }
            else
            {
                if (infrastructureLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(infrastructureLanguage.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == infrastructureLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", infrastructureLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(infrastructureLanguage.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(infrastructureLanguage.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResultList.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
