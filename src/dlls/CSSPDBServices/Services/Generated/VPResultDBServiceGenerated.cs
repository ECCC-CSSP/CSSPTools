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
    public partial interface IVPResultDBService
    {
        Task<ActionResult<bool>> Delete(int VPResultID);
        Task<ActionResult<List<VPResult>>> GetVPResultList(int skip = 0, int take = 100);
        Task<ActionResult<VPResult>> GetVPResultWithVPResultID(int VPResultID);
        Task<ActionResult<VPResult>> Post(VPResult vpresult);
        Task<ActionResult<VPResult>> Put(VPResult vpresult);
    }
    public partial class VPResultDBService : ControllerBase, IVPResultDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public VPResultDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<VPResult>> GetVPResultWithVPResultID(int VPResultID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            VPResult vpResult = (from c in db.VPResults.AsNoTracking()
                    where c.VPResultID == VPResultID
                    select c).FirstOrDefault();

            if (vpResult == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(vpResult));
        }
        public async Task<ActionResult<List<VPResult>>> GetVPResultList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<VPResult> vpResultList = (from c in db.VPResults.AsNoTracking() orderby c.VPResultID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(vpResultList));
        }
        public async Task<ActionResult<bool>> Delete(int VPResultID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            VPResult vpResult = (from c in db.VPResults
                    where c.VPResultID == VPResultID
                    select c).FirstOrDefault();

            if (vpResult == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "VPResult", "VPResultID", VPResultID.ToString())));
            }

            try
            {
                db.VPResults.Remove(vpResult);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<VPResult>> Post(VPResult vpResult)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(vpResult), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.VPResults.Add(vpResult);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(vpResult));
        }
        public async Task<ActionResult<VPResult>> Put(VPResult vpResult)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(vpResult), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.VPResults.Update(vpResult);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(vpResult));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            VPResult vpResult = validationContext.ObjectInstance as VPResult;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (vpResult.VPResultID == 0)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "VPResultID"), new[] { nameof(vpResult.VPResultID) }));
                }

                if (!(from c in db.VPResults.AsNoTracking() select c).Where(c => c.VPResultID == vpResult.VPResultID).Any())
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "VPResult", "VPResultID", vpResult.VPResultID.ToString()), new[] { nameof(vpResult.VPResultID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)vpResult.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(vpResult.DBCommand) }));
            }

            VPScenario VPScenarioVPScenarioID = null;
            VPScenarioVPScenarioID = (from c in db.VPScenarios.AsNoTracking() where c.VPScenarioID == vpResult.VPScenarioID select c).FirstOrDefault();

            if (VPScenarioVPScenarioID == null)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioID", vpResult.VPScenarioID.ToString()), new[] { nameof(vpResult.VPScenarioID)}));
            }

            if (vpResult.Ordinal < 0 || vpResult.Ordinal > 1000)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "1000"), new[] { nameof(vpResult.Ordinal) }));
            }

            if (vpResult.Concentration_MPN_100ml < 0 || vpResult.Concentration_MPN_100ml > 10000000)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Concentration_MPN_100ml", "0", "10000000"), new[] { nameof(vpResult.Concentration_MPN_100ml) }));
            }

            if (vpResult.Dilution < 0 || vpResult.Dilution > 1000000)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Dilution", "0", "1000000"), new[] { nameof(vpResult.Dilution) }));
            }

            if (vpResult.FarFieldWidth_m < 0 || vpResult.FarFieldWidth_m > 10000)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "FarFieldWidth_m", "0", "10000"), new[] { nameof(vpResult.FarFieldWidth_m) }));
            }

            if (vpResult.DispersionDistance_m < 0 || vpResult.DispersionDistance_m > 100000)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DispersionDistance_m", "0", "100000"), new[] { nameof(vpResult.DispersionDistance_m) }));
            }

            if (vpResult.TravelTime_hour < 0 || vpResult.TravelTime_hour > 100)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TravelTime_hour", "0", "100"), new[] { nameof(vpResult.TravelTime_hour) }));
            }

            if (vpResult.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(vpResult.LastUpdateDate_UTC) }));
            }
            else
            {
                if (vpResult.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(vpResult.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == vpResult.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", vpResult.LastUpdateContactTVItemID.ToString()), new[] { nameof(vpResult.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(vpResult.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
