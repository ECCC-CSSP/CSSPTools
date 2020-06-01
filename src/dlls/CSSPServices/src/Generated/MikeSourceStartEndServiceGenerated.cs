/*
 * Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
   public interface IMikeSourceStartEndService
    {
       Task<ActionResult<MikeSourceStartEnd>> GetMikeSourceStartEndWithMikeSourceStartEndID(int MikeSourceStartEndID);
       Task<ActionResult<List<MikeSourceStartEnd>>> GetMikeSourceStartEndList();
       Task<ActionResult<MikeSourceStartEnd>> Add(MikeSourceStartEnd mikesourcestartend);
       Task<ActionResult<MikeSourceStartEnd>> Delete(MikeSourceStartEnd mikesourcestartend);
       Task<ActionResult<MikeSourceStartEnd>> Update(MikeSourceStartEnd mikesourcestartend);
       Task SetCulture(CultureInfo culture);
    }
    public partial class MikeSourceStartEndService : ControllerBase, IMikeSourceStartEndService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<MikeSourceStartEnd>> GetMikeSourceStartEndWithMikeSourceStartEndID(int MikeSourceStartEndID)
        {
            MikeSourceStartEnd mikesourcestartend = (from c in db.MikeSourceStartEnds.AsNoTracking()
                    where c.MikeSourceStartEndID == MikeSourceStartEndID
                    select c).FirstOrDefault();

            if (mikesourcestartend == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(mikesourcestartend));
        }
        public async Task<ActionResult<List<MikeSourceStartEnd>>> GetMikeSourceStartEndList()
        {
            List<MikeSourceStartEnd> mikesourcestartendList = (from c in db.MikeSourceStartEnds.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(mikesourcestartendList));
        }
        public async Task<ActionResult<MikeSourceStartEnd>> Add(MikeSourceStartEnd mikeSourceStartEnd)
        {
            mikeSourceStartEnd.ValidationResults = Validate(new ValidationContext(mikeSourceStartEnd), ActionDBTypeEnum.Create);
            if (mikeSourceStartEnd.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(mikeSourceStartEnd.ValidationResults));
            }

            try
            {
               db.MikeSourceStartEnds.Add(mikeSourceStartEnd);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeSourceStartEnd));
        }
        public async Task<ActionResult<MikeSourceStartEnd>> Delete(MikeSourceStartEnd mikeSourceStartEnd)
        {
            mikeSourceStartEnd.ValidationResults = Validate(new ValidationContext(mikeSourceStartEnd), ActionDBTypeEnum.Delete);
            if (mikeSourceStartEnd.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(mikeSourceStartEnd.ValidationResults));
            }

            try
            {
               db.MikeSourceStartEnds.Remove(mikeSourceStartEnd);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeSourceStartEnd));
        }
        public async Task<ActionResult<MikeSourceStartEnd>> Update(MikeSourceStartEnd mikeSourceStartEnd)
        {
            mikeSourceStartEnd.ValidationResults = Validate(new ValidationContext(mikeSourceStartEnd), ActionDBTypeEnum.Update);
            if (mikeSourceStartEnd.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(mikeSourceStartEnd.ValidationResults));
            }

            try
            {
               db.MikeSourceStartEnds.Update(mikeSourceStartEnd);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeSourceStartEnd));
        }
        public async Task SetCulture(CultureInfo culture)
        {
            CSSPServicesRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MikeSourceStartEnd mikeSourceStartEnd = validationContext.ObjectInstance as MikeSourceStartEnd;
            mikeSourceStartEnd.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeSourceStartEnd.MikeSourceStartEndID == 0)
                {
                    mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeSourceStartEndID"), new[] { "MikeSourceStartEndID" });
                }

                if (!(from c in db.MikeSourceStartEnds select c).Where(c => c.MikeSourceStartEndID == mikeSourceStartEnd.MikeSourceStartEndID).Any())
                {
                    mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MikeSourceStartEnd", "MikeSourceStartEndID", mikeSourceStartEnd.MikeSourceStartEndID.ToString()), new[] { "MikeSourceStartEndID" });
                }
            }

            MikeSource MikeSourceMikeSourceID = (from c in db.MikeSources where c.MikeSourceID == mikeSourceStartEnd.MikeSourceID select c).FirstOrDefault();

            if (MikeSourceMikeSourceID == null)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MikeSource", "MikeSourceID", mikeSourceStartEnd.MikeSourceID.ToString()), new[] { "MikeSourceID" });
            }

            if (mikeSourceStartEnd.StartDateAndTime_Local.Year == 1)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "StartDateAndTime_Local"), new[] { "StartDateAndTime_Local" });
            }
            else
            {
                if (mikeSourceStartEnd.StartDateAndTime_Local.Year < 1980)
                {
                mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "StartDateAndTime_Local", "1980"), new[] { "StartDateAndTime_Local" });
                }
            }

            if (mikeSourceStartEnd.EndDateAndTime_Local.Year == 1)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EndDateAndTime_Local"), new[] { "EndDateAndTime_Local" });
            }
            else
            {
                if (mikeSourceStartEnd.EndDateAndTime_Local.Year < 1980)
                {
                mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "EndDateAndTime_Local", "1980"), new[] { "EndDateAndTime_Local" });
                }
            }

            if (mikeSourceStartEnd.StartDateAndTime_Local > mikeSourceStartEnd.EndDateAndTime_Local)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "EndDateAndTime_Local", "MikeSourceStartEndStartDateAndTime_Local"), new[] { "EndDateAndTime_Local" });
            }

            if (mikeSourceStartEnd.SourceFlowStart_m3_day < 0 || mikeSourceStartEnd.SourceFlowStart_m3_day > 1000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SourceFlowStart_m3_day", "0", "1000000"), new[] { "SourceFlowStart_m3_day" });
            }

            if (mikeSourceStartEnd.SourceFlowEnd_m3_day < 0 || mikeSourceStartEnd.SourceFlowEnd_m3_day > 1000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SourceFlowEnd_m3_day", "0", "1000000"), new[] { "SourceFlowEnd_m3_day" });
            }

            if (mikeSourceStartEnd.SourcePollutionStart_MPN_100ml < 0 || mikeSourceStartEnd.SourcePollutionStart_MPN_100ml > 10000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SourcePollutionStart_MPN_100ml", "0", "10000000"), new[] { "SourcePollutionStart_MPN_100ml" });
            }

            if (mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml < 0 || mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml > 10000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SourcePollutionEnd_MPN_100ml", "0", "10000000"), new[] { "SourcePollutionEnd_MPN_100ml" });
            }

            if (mikeSourceStartEnd.SourceTemperatureStart_C < -10 || mikeSourceStartEnd.SourceTemperatureStart_C > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SourceTemperatureStart_C", "-10", "40"), new[] { "SourceTemperatureStart_C" });
            }

            if (mikeSourceStartEnd.SourceTemperatureEnd_C < -10 || mikeSourceStartEnd.SourceTemperatureEnd_C > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SourceTemperatureEnd_C", "-10", "40"), new[] { "SourceTemperatureEnd_C" });
            }

            if (mikeSourceStartEnd.SourceSalinityStart_PSU < 0 || mikeSourceStartEnd.SourceSalinityStart_PSU > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SourceSalinityStart_PSU", "0", "40"), new[] { "SourceSalinityStart_PSU" });
            }

            if (mikeSourceStartEnd.SourceSalinityEnd_PSU < 0 || mikeSourceStartEnd.SourceSalinityEnd_PSU > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SourceSalinityEnd_PSU", "0", "40"), new[] { "SourceSalinityEnd_PSU" });
            }

            if (mikeSourceStartEnd.LastUpdateDate_UTC.Year == 1)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeSourceStartEnd.LastUpdateDate_UTC.Year < 1980)
                {
                mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeSourceStartEnd.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mikeSourceStartEnd.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions private

    }
}