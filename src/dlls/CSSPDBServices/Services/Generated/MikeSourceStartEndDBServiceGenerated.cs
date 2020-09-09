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
    public partial interface IMikeSourceStartEndDBService
    {
        Task<ActionResult<bool>> Delete(int MikeSourceStartEndID);
        Task<ActionResult<List<MikeSourceStartEnd>>> GetMikeSourceStartEndList(int skip = 0, int take = 100);
        Task<ActionResult<MikeSourceStartEnd>> GetMikeSourceStartEndWithMikeSourceStartEndID(int MikeSourceStartEndID);
        Task<ActionResult<MikeSourceStartEnd>> Post(MikeSourceStartEnd mikesourcestartend);
        Task<ActionResult<MikeSourceStartEnd>> Put(MikeSourceStartEnd mikesourcestartend);
    }
    public partial class MikeSourceStartEndDBService : ControllerBase, IMikeSourceStartEndDBService
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
        public MikeSourceStartEndDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<MikeSourceStartEnd>> GetMikeSourceStartEndWithMikeSourceStartEndID(int MikeSourceStartEndID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            MikeSourceStartEnd mikeSourceStartEnd = (from c in db.MikeSourceStartEnds.AsNoTracking()
                    where c.MikeSourceStartEndID == MikeSourceStartEndID
                    select c).FirstOrDefault();

            if (mikeSourceStartEnd == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(mikeSourceStartEnd));
        }
        public async Task<ActionResult<List<MikeSourceStartEnd>>> GetMikeSourceStartEndList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<MikeSourceStartEnd> mikeSourceStartEndList = (from c in db.MikeSourceStartEnds.AsNoTracking() orderby c.MikeSourceStartEndID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(mikeSourceStartEndList));
        }
        public async Task<ActionResult<bool>> Delete(int MikeSourceStartEndID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            MikeSourceStartEnd mikeSourceStartEnd = (from c in db.MikeSourceStartEnds
                    where c.MikeSourceStartEndID == MikeSourceStartEndID
                    select c).FirstOrDefault();

            if (mikeSourceStartEnd == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeSourceStartEnd", "MikeSourceStartEndID", MikeSourceStartEndID.ToString())));
            }

            try
            {
                db.MikeSourceStartEnds.Remove(mikeSourceStartEnd);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<MikeSourceStartEnd>> Post(MikeSourceStartEnd mikeSourceStartEnd)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mikeSourceStartEnd), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.MikeSourceStartEnds.Add(mikeSourceStartEnd);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeSourceStartEnd));
        }
        public async Task<ActionResult<MikeSourceStartEnd>> Put(MikeSourceStartEnd mikeSourceStartEnd)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mikeSourceStartEnd), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.MikeSourceStartEnds.Update(mikeSourceStartEnd);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeSourceStartEnd));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            MikeSourceStartEnd mikeSourceStartEnd = validationContext.ObjectInstance as MikeSourceStartEnd;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeSourceStartEnd.MikeSourceStartEndID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeSourceStartEndID"), new[] { nameof(mikeSourceStartEnd.MikeSourceStartEndID) });
                }

                if (!(from c in db.MikeSourceStartEnds.AsNoTracking() select c).Where(c => c.MikeSourceStartEndID == mikeSourceStartEnd.MikeSourceStartEndID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeSourceStartEnd", "MikeSourceStartEndID", mikeSourceStartEnd.MikeSourceStartEndID.ToString()), new[] { nameof(mikeSourceStartEnd.MikeSourceStartEndID) });
                }
            }

            MikeSource MikeSourceMikeSourceID = null;
            MikeSourceMikeSourceID = (from c in db.MikeSources.AsNoTracking() where c.MikeSourceID == mikeSourceStartEnd.MikeSourceID select c).FirstOrDefault();

            if (MikeSourceMikeSourceID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeSource", "MikeSourceID", mikeSourceStartEnd.MikeSourceID.ToString()), new[] { nameof(mikeSourceStartEnd.MikeSourceID) });
            }

            if (mikeSourceStartEnd.StartDateAndTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "StartDateAndTime_Local"), new[] { nameof(mikeSourceStartEnd.StartDateAndTime_Local) });
            }
            else
            {
                if (mikeSourceStartEnd.StartDateAndTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateAndTime_Local", "1980"), new[] { nameof(mikeSourceStartEnd.StartDateAndTime_Local) });
                }
            }

            if (mikeSourceStartEnd.EndDateAndTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EndDateAndTime_Local"), new[] { nameof(mikeSourceStartEnd.EndDateAndTime_Local) });
            }
            else
            {
                if (mikeSourceStartEnd.EndDateAndTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateAndTime_Local", "1980"), new[] { nameof(mikeSourceStartEnd.EndDateAndTime_Local) });
                }
            }

            if (mikeSourceStartEnd.StartDateAndTime_Local > mikeSourceStartEnd.EndDateAndTime_Local)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, "EndDateAndTime_Local", "MikeSourceStartEndStartDateAndTime_Local"), new[] { nameof(mikeSourceStartEnd.EndDateAndTime_Local) });
            }

            if (mikeSourceStartEnd.SourceFlowStart_m3_day < 0 || mikeSourceStartEnd.SourceFlowStart_m3_day > 1000000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourceFlowStart_m3_day", "0", "1000000"), new[] { nameof(mikeSourceStartEnd.SourceFlowStart_m3_day) });
            }

            if (mikeSourceStartEnd.SourceFlowEnd_m3_day < 0 || mikeSourceStartEnd.SourceFlowEnd_m3_day > 1000000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourceFlowEnd_m3_day", "0", "1000000"), new[] { nameof(mikeSourceStartEnd.SourceFlowEnd_m3_day) });
            }

            if (mikeSourceStartEnd.SourcePollutionStart_MPN_100ml < 0 || mikeSourceStartEnd.SourcePollutionStart_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourcePollutionStart_MPN_100ml", "0", "10000000"), new[] { nameof(mikeSourceStartEnd.SourcePollutionStart_MPN_100ml) });
            }

            if (mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml < 0 || mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourcePollutionEnd_MPN_100ml", "0", "10000000"), new[] { nameof(mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml) });
            }

            if (mikeSourceStartEnd.SourceTemperatureStart_C < -10 || mikeSourceStartEnd.SourceTemperatureStart_C > 40)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourceTemperatureStart_C", "-10", "40"), new[] { nameof(mikeSourceStartEnd.SourceTemperatureStart_C) });
            }

            if (mikeSourceStartEnd.SourceTemperatureEnd_C < -10 || mikeSourceStartEnd.SourceTemperatureEnd_C > 40)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourceTemperatureEnd_C", "-10", "40"), new[] { nameof(mikeSourceStartEnd.SourceTemperatureEnd_C) });
            }

            if (mikeSourceStartEnd.SourceSalinityStart_PSU < 0 || mikeSourceStartEnd.SourceSalinityStart_PSU > 40)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourceSalinityStart_PSU", "0", "40"), new[] { nameof(mikeSourceStartEnd.SourceSalinityStart_PSU) });
            }

            if (mikeSourceStartEnd.SourceSalinityEnd_PSU < 0 || mikeSourceStartEnd.SourceSalinityEnd_PSU > 40)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourceSalinityEnd_PSU", "0", "40"), new[] { nameof(mikeSourceStartEnd.SourceSalinityEnd_PSU) });
            }

            if (mikeSourceStartEnd.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mikeSourceStartEnd.LastUpdateDate_UTC) });
            }
            else
            {
                if (mikeSourceStartEnd.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mikeSourceStartEnd.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == mikeSourceStartEnd.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mikeSourceStartEnd.LastUpdateContactTVItemID.ToString()), new[] { nameof(mikeSourceStartEnd.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mikeSourceStartEnd.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
