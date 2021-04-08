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
    public partial interface IClimateSiteDBService
    {
        Task<ActionResult<bool>> Delete(int ClimateSiteID);
        Task<ActionResult<List<ClimateSite>>> GetClimateSiteList(int skip = 0, int take = 100);
        Task<ActionResult<ClimateSite>> GetClimateSiteWithClimateSiteID(int ClimateSiteID);
        Task<ActionResult<ClimateSite>> Post(ClimateSite climatesite);
        Task<ActionResult<ClimateSite>> Put(ClimateSite climatesite);
    }
    public partial class ClimateSiteDBService : ControllerBase, IClimateSiteDBService
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
        public ClimateSiteDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<ClimateSite>> GetClimateSiteWithClimateSiteID(int ClimateSiteID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            ClimateSite climateSite = (from c in db.ClimateSites.AsNoTracking()
                    where c.ClimateSiteID == ClimateSiteID
                    select c).FirstOrDefault();

            if (climateSite == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(climateSite));
        }
        public async Task<ActionResult<List<ClimateSite>>> GetClimateSiteList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<ClimateSite> climateSiteList = (from c in db.ClimateSites.AsNoTracking() orderby c.ClimateSiteID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(climateSiteList));
        }
        public async Task<ActionResult<bool>> Delete(int ClimateSiteID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            ClimateSite climateSite = (from c in db.ClimateSites
                    where c.ClimateSiteID == ClimateSiteID
                    select c).FirstOrDefault();

            if (climateSite == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ClimateSite", "ClimateSiteID", ClimateSiteID.ToString())));
            }

            try
            {
                db.ClimateSites.Remove(climateSite);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<ClimateSite>> Post(ClimateSite climateSite)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(climateSite), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.ClimateSites.Add(climateSite);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(climateSite));
        }
        public async Task<ActionResult<ClimateSite>> Put(ClimateSite climateSite)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(climateSite), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.ClimateSites.Update(climateSite);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(climateSite));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            ClimateSite climateSite = validationContext.ObjectInstance as ClimateSite;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (climateSite.ClimateSiteID == 0)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ClimateSiteID"), new[] { nameof(climateSite.ClimateSiteID) }));
                }

                if (!(from c in db.ClimateSites.AsNoTracking() select c).Where(c => c.ClimateSiteID == climateSite.ClimateSiteID).Any())
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ClimateSite", "ClimateSiteID", climateSite.ClimateSiteID.ToString()), new[] { nameof(climateSite.ClimateSiteID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)climateSite.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(climateSite.DBCommand) }));
            }

            TVItem TVItemClimateSiteTVItemID = null;
            TVItemClimateSiteTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == climateSite.ClimateSiteTVItemID select c).FirstOrDefault();

            if (TVItemClimateSiteTVItemID == null)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ClimateSiteTVItemID", climateSite.ClimateSiteTVItemID.ToString()), new[] { nameof(climateSite.ClimateSiteTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.ClimateSite,
                };
                if (!AllowableTVTypes.Contains(TVItemClimateSiteTVItemID.TVType))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ClimateSiteTVItemID", "ClimateSite"), new[] { nameof(climateSite.ClimateSiteTVItemID) }));
                }
            }

            if (climateSite.ECDBID != null)
            {
                if (climateSite.ECDBID < 1 || climateSite.ECDBID > 100000)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ECDBID", "1", "100000"), new[] { nameof(climateSite.ECDBID) }));
                }
            }

            if (string.IsNullOrWhiteSpace(climateSite.ClimateSiteName))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ClimateSiteName"), new[] { nameof(climateSite.ClimateSiteName) }));
            }

            if (!string.IsNullOrWhiteSpace(climateSite.ClimateSiteName) && climateSite.ClimateSiteName.Length > 100)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ClimateSiteName", "100"), new[] { nameof(climateSite.ClimateSiteName) }));
            }

            if (string.IsNullOrWhiteSpace(climateSite.Province))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Province"), new[] { nameof(climateSite.Province) }));
            }

            if (!string.IsNullOrWhiteSpace(climateSite.Province) && climateSite.Province.Length > 4)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Province", "4"), new[] { nameof(climateSite.Province) }));
            }

            if (climateSite.Elevation_m != null)
            {
                if (climateSite.Elevation_m < 0 || climateSite.Elevation_m > 10000)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Elevation_m", "0", "10000"), new[] { nameof(climateSite.Elevation_m) }));
                }
            }

            if (!string.IsNullOrWhiteSpace(climateSite.ClimateID) && climateSite.ClimateID.Length > 10)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ClimateID", "10"), new[] { nameof(climateSite.ClimateID) }));
            }

            if (climateSite.WMOID != null)
            {
                if (climateSite.WMOID < 1 || climateSite.WMOID > 100000)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "WMOID", "1", "100000"), new[] { nameof(climateSite.WMOID) }));
                }
            }

            if (!string.IsNullOrWhiteSpace(climateSite.TCID) && climateSite.TCID.Length > 3)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TCID", "3"), new[] { nameof(climateSite.TCID) }));
            }

            if (climateSite.TimeOffset_hour != null)
            {
                if (climateSite.TimeOffset_hour < -10 || climateSite.TimeOffset_hour > 0)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TimeOffset_hour", "-10", "0"), new[] { nameof(climateSite.TimeOffset_hour) }));
                }
            }

            if (!string.IsNullOrWhiteSpace(climateSite.File_desc) && climateSite.File_desc.Length > 50)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "File_desc", "50"), new[] { nameof(climateSite.File_desc) }));
            }

            if (climateSite.HourlyStartDate_Local != null && ((DateTime)climateSite.HourlyStartDate_Local).Year < 1980)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "HourlyStartDate_Local", "1980"), new[] { nameof(climateSite.HourlyStartDate_Local) }));
            }

            if (climateSite.HourlyEndDate_Local != null && ((DateTime)climateSite.HourlyEndDate_Local).Year < 1980)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "HourlyEndDate_Local", "1980"), new[] { nameof(climateSite.HourlyEndDate_Local) }));
            }

            if (climateSite.DailyStartDate_Local != null && ((DateTime)climateSite.DailyStartDate_Local).Year < 1980)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DailyStartDate_Local", "1980"), new[] { nameof(climateSite.DailyStartDate_Local) }));
            }

            if (climateSite.DailyEndDate_Local != null && ((DateTime)climateSite.DailyEndDate_Local).Year < 1980)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DailyEndDate_Local", "1980"), new[] { nameof(climateSite.DailyEndDate_Local) }));
            }

            if (climateSite.MonthlyStartDate_Local != null && ((DateTime)climateSite.MonthlyStartDate_Local).Year < 1980)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "MonthlyStartDate_Local", "1980"), new[] { nameof(climateSite.MonthlyStartDate_Local) }));
            }

            if (climateSite.MonthlyEndDate_Local != null && ((DateTime)climateSite.MonthlyEndDate_Local).Year < 1980)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "MonthlyEndDate_Local", "1980"), new[] { nameof(climateSite.MonthlyEndDate_Local) }));
            }

            if (climateSite.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(climateSite.LastUpdateDate_UTC) }));
            }
            else
            {
                if (climateSite.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(climateSite.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == climateSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", climateSite.LastUpdateContactTVItemID.ToString()), new[] { nameof(climateSite.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(climateSite.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
