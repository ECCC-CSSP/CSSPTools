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
    public partial interface IMikeScenarioResultDBService
    {
        Task<ActionResult<bool>> Delete(int MikeScenarioResultID);
        Task<ActionResult<List<MikeScenarioResult>>> GetMikeScenarioResultList(int skip = 0, int take = 100);
        Task<ActionResult<MikeScenarioResult>> GetMikeScenarioResultWithMikeScenarioResultID(int MikeScenarioResultID);
        Task<ActionResult<MikeScenarioResult>> Post(MikeScenarioResult mikescenarioresult);
        Task<ActionResult<MikeScenarioResult>> Put(MikeScenarioResult mikescenarioresult);
    }
    public partial class MikeScenarioResultDBService : ControllerBase, IMikeScenarioResultDBService
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
        public MikeScenarioResultDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<MikeScenarioResult>> GetMikeScenarioResultWithMikeScenarioResultID(int MikeScenarioResultID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            MikeScenarioResult mikeScenarioResult = (from c in db.MikeScenarioResults.AsNoTracking()
                    where c.MikeScenarioResultID == MikeScenarioResultID
                    select c).FirstOrDefault();

            if (mikeScenarioResult == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(mikeScenarioResult));
        }
        public async Task<ActionResult<List<MikeScenarioResult>>> GetMikeScenarioResultList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<MikeScenarioResult> mikeScenarioResultList = (from c in db.MikeScenarioResults.AsNoTracking() orderby c.MikeScenarioResultID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(mikeScenarioResultList));
        }
        public async Task<ActionResult<bool>> Delete(int MikeScenarioResultID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            MikeScenarioResult mikeScenarioResult = (from c in db.MikeScenarioResults
                    where c.MikeScenarioResultID == MikeScenarioResultID
                    select c).FirstOrDefault();

            if (mikeScenarioResult == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenarioResult", "MikeScenarioResultID", MikeScenarioResultID.ToString())));
            }

            try
            {
                db.MikeScenarioResults.Remove(mikeScenarioResult);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<MikeScenarioResult>> Post(MikeScenarioResult mikeScenarioResult)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(mikeScenarioResult), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.MikeScenarioResults.Add(mikeScenarioResult);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeScenarioResult));
        }
        public async Task<ActionResult<MikeScenarioResult>> Put(MikeScenarioResult mikeScenarioResult)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(mikeScenarioResult), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.MikeScenarioResults.Update(mikeScenarioResult);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeScenarioResult));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MikeScenarioResult mikeScenarioResult = validationContext.ObjectInstance as MikeScenarioResult;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeScenarioResult.MikeScenarioResultID == 0)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeScenarioResultID"), new[] { nameof(mikeScenarioResult.MikeScenarioResultID) }));
                }

                if (!(from c in db.MikeScenarioResults.AsNoTracking() select c).Where(c => c.MikeScenarioResultID == mikeScenarioResult.MikeScenarioResultID).Any())
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenarioResult", "MikeScenarioResultID", mikeScenarioResult.MikeScenarioResultID.ToString()), new[] { nameof(mikeScenarioResult.MikeScenarioResultID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)mikeScenarioResult.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(mikeScenarioResult.DBCommand) }));
            }

            TVItem TVItemMikeScenarioTVItemID = null;
            TVItemMikeScenarioTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == mikeScenarioResult.MikeScenarioTVItemID select c).FirstOrDefault();

            if (TVItemMikeScenarioTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeScenarioTVItemID", mikeScenarioResult.MikeScenarioTVItemID.ToString()), new[] { nameof(mikeScenarioResult.MikeScenarioTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeScenario,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeScenarioTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MikeScenarioTVItemID", "MikeScenario"), new[] { nameof(mikeScenarioResult.MikeScenarioTVItemID) }));
                }
            }

            //MikeResultsJSON has no StringLength Attribute

            if (mikeScenarioResult.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mikeScenarioResult.LastUpdateDate_UTC) }));
            }
            else
            {
                if (mikeScenarioResult.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mikeScenarioResult.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == mikeScenarioResult.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mikeScenarioResult.LastUpdateContactTVItemID.ToString()), new[] { nameof(mikeScenarioResult.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mikeScenarioResult.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResultList.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
