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
   public interface ISpillService
    {
       Task<ActionResult<Spill>> GetSpillWithSpillID(int SpillID);
       Task<ActionResult<List<Spill>>> GetSpillList();
       Task<ActionResult<Spill>> Add(Spill spill);
       Task<ActionResult<Spill>> Delete(Spill spill);
       Task<ActionResult<Spill>> Update(Spill spill);
       Task SetCulture(CultureInfo culture);
    }
    public partial class SpillService : ControllerBase, ISpillService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public SpillService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<Spill>> GetSpillWithSpillID(int SpillID)
        {
            Spill spill = (from c in db.Spills.AsNoTracking()
                    where c.SpillID == SpillID
                    select c).FirstOrDefault();

            if (spill == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(spill));
        }
        public async Task<ActionResult<List<Spill>>> GetSpillList()
        {
            List<Spill> spillList = (from c in db.Spills.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(spillList));
        }
        public async Task<ActionResult<Spill>> Add(Spill spill)
        {
            ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.Spills.Add(spill);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(spill));
        }
        public async Task<ActionResult<Spill>> Delete(Spill spill)
        {
            ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Delete);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.Spills.Remove(spill);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(spill));
        }
        public async Task<ActionResult<Spill>> Update(Spill spill)
        {
            ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.Spills.Update(spill);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(spill));
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
            Spill spill = validationContext.ObjectInstance as Spill;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (spill.SpillID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SpillID"), new[] { "SpillID" });
                }

                if (!(from c in db.Spills select c).Where(c => c.SpillID == spill.SpillID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillID", spill.SpillID.ToString()), new[] { "SpillID" });
                }
            }

            TVItem TVItemMunicipalityTVItemID = (from c in db.TVItems where c.TVItemID == spill.MunicipalityTVItemID select c).FirstOrDefault();

            if (TVItemMunicipalityTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MunicipalityTVItemID", spill.MunicipalityTVItemID.ToString()), new[] { "MunicipalityTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Municipality,
                };
                if (!AllowableTVTypes.Contains(TVItemMunicipalityTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MunicipalityTVItemID", "Municipality"), new[] { "MunicipalityTVItemID" });
                }
            }

            if (spill.InfrastructureTVItemID != null)
            {
                TVItem TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == spill.InfrastructureTVItemID select c).FirstOrDefault();

                if (TVItemInfrastructureTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureTVItemID", (spill.InfrastructureTVItemID == null ? "" : spill.InfrastructureTVItemID.ToString())), new[] { "InfrastructureTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Infrastructure,
                    };
                    if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "InfrastructureTVItemID", "Infrastructure"), new[] { "InfrastructureTVItemID" });
                    }
                }
            }

            if (spill.StartDateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "StartDateTime_Local"), new[] { "StartDateTime_Local" });
            }
            else
            {
                if (spill.StartDateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "StartDateTime_Local", "1980"), new[] { "StartDateTime_Local" });
                }
            }

            if (spill.EndDateTime_Local != null && ((DateTime)spill.EndDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "EndDateTime_Local", "1980"), new[] { "EndDateTime_Local" });
            }

            if (spill.StartDateTime_Local > spill.EndDateTime_Local)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "EndDateTime_Local", "SpillStartDateTime_Local"), new[] { "EndDateTime_Local" });
            }

            if (spill.AverageFlow_m3_day < 0 || spill.AverageFlow_m3_day > 1000000)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AverageFlow_m3_day", "0", "1000000"), new[] { "AverageFlow_m3_day" });
            }

            if (spill.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (spill.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == spill.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", spill.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
