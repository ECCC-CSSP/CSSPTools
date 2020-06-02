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
   public interface IDrogueRunPositionService
    {
       Task<ActionResult<DrogueRunPosition>> GetDrogueRunPositionWithDrogueRunPositionID(int DrogueRunPositionID);
       Task<ActionResult<List<DrogueRunPosition>>> GetDrogueRunPositionList();
       Task<ActionResult<DrogueRunPosition>> Add(DrogueRunPosition droguerunposition);
       Task<ActionResult<DrogueRunPosition>> Delete(DrogueRunPosition droguerunposition);
       Task<ActionResult<DrogueRunPosition>> Update(DrogueRunPosition droguerunposition);
       Task SetCulture(CultureInfo culture);
    }
    public partial class DrogueRunPositionService : ControllerBase, IDrogueRunPositionService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public DrogueRunPositionService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<DrogueRunPosition>> GetDrogueRunPositionWithDrogueRunPositionID(int DrogueRunPositionID)
        {
            DrogueRunPosition droguerunposition = (from c in db.DrogueRunPositions.AsNoTracking()
                    where c.DrogueRunPositionID == DrogueRunPositionID
                    select c).FirstOrDefault();

            if (droguerunposition == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(droguerunposition));
        }
        public async Task<ActionResult<List<DrogueRunPosition>>> GetDrogueRunPositionList()
        {
            List<DrogueRunPosition> droguerunpositionList = (from c in db.DrogueRunPositions.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(droguerunpositionList));
        }
        public async Task<ActionResult<DrogueRunPosition>> Add(DrogueRunPosition drogueRunPosition)
        {
            ValidationResults = Validate(new ValidationContext(drogueRunPosition), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.DrogueRunPositions.Add(drogueRunPosition);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(drogueRunPosition));
        }
        public async Task<ActionResult<DrogueRunPosition>> Delete(DrogueRunPosition drogueRunPosition)
        {
            ValidationResults = Validate(new ValidationContext(drogueRunPosition), ActionDBTypeEnum.Delete);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.DrogueRunPositions.Remove(drogueRunPosition);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(drogueRunPosition));
        }
        public async Task<ActionResult<DrogueRunPosition>> Update(DrogueRunPosition drogueRunPosition)
        {
            ValidationResults = Validate(new ValidationContext(drogueRunPosition), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.DrogueRunPositions.Update(drogueRunPosition);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(drogueRunPosition));
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
            DrogueRunPosition drogueRunPosition = validationContext.ObjectInstance as DrogueRunPosition;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (drogueRunPosition.DrogueRunPositionID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DrogueRunPositionID"), new[] { "DrogueRunPositionID" });
                }

                if (!(from c in db.DrogueRunPositions select c).Where(c => c.DrogueRunPositionID == drogueRunPosition.DrogueRunPositionID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "DrogueRunPosition", "DrogueRunPositionID", drogueRunPosition.DrogueRunPositionID.ToString()), new[] { "DrogueRunPositionID" });
                }
            }

            DrogueRun DrogueRunDrogueRunID = (from c in db.DrogueRuns where c.DrogueRunID == drogueRunPosition.DrogueRunID select c).FirstOrDefault();

            if (DrogueRunDrogueRunID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "DrogueRun", "DrogueRunID", drogueRunPosition.DrogueRunID.ToString()), new[] { "DrogueRunID" });
            }

            if (drogueRunPosition.Ordinal < 0 || drogueRunPosition.Ordinal > 100000)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "100000"), new[] { "Ordinal" });
            }

            if (drogueRunPosition.StepLat < -180 || drogueRunPosition.StepLat > 180)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "StepLat", "-180", "180"), new[] { "StepLat" });
            }

            if (drogueRunPosition.StepLng < -90 || drogueRunPosition.StepLng > 90)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "StepLng", "-90", "90"), new[] { "StepLng" });
            }

            if (drogueRunPosition.StepDateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "StepDateTime_Local"), new[] { "StepDateTime_Local" });
            }
            else
            {
                if (drogueRunPosition.StepDateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "StepDateTime_Local", "1980"), new[] { "StepDateTime_Local" });
                }
            }

            if (drogueRunPosition.CalculatedSpeed_m_s < 0 || drogueRunPosition.CalculatedSpeed_m_s > 10)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "CalculatedSpeed_m_s", "0", "10"), new[] { "CalculatedSpeed_m_s" });
            }

            if (drogueRunPosition.CalculatedDirection_deg < 0 || drogueRunPosition.CalculatedDirection_deg > 360)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "CalculatedDirection_deg", "0", "360"), new[] { "CalculatedDirection_deg" });
            }

            if (drogueRunPosition.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (drogueRunPosition.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == drogueRunPosition.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", drogueRunPosition.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions private

    }
}
