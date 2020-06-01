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
   public interface IMikeScenarioResultService
    {
       Task<ActionResult<MikeScenarioResult>> GetMikeScenarioResultWithMikeScenarioResultID(int MikeScenarioResultID);
       Task<ActionResult<List<MikeScenarioResult>>> GetMikeScenarioResultList();
       Task<ActionResult<MikeScenarioResult>> Add(MikeScenarioResult mikescenarioresult);
       Task<ActionResult<MikeScenarioResult>> Delete(MikeScenarioResult mikescenarioresult);
       Task<ActionResult<MikeScenarioResult>> Update(MikeScenarioResult mikescenarioresult);
       Task SetCulture(CultureInfo culture);
    }
    public partial class MikeScenarioResultService : ControllerBase, IMikeScenarioResultService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public MikeScenarioResultService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<MikeScenarioResult>> GetMikeScenarioResultWithMikeScenarioResultID(int MikeScenarioResultID)
        {
            MikeScenarioResult mikescenarioresult = (from c in db.MikeScenarioResults.AsNoTracking()
                    where c.MikeScenarioResultID == MikeScenarioResultID
                    select c).FirstOrDefault();

            if (mikescenarioresult == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(mikescenarioresult));
        }
        public async Task<ActionResult<List<MikeScenarioResult>>> GetMikeScenarioResultList()
        {
            List<MikeScenarioResult> mikescenarioresultList = (from c in db.MikeScenarioResults.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(mikescenarioresultList));
        }
        public async Task<ActionResult<MikeScenarioResult>> Add(MikeScenarioResult mikeScenarioResult)
        {
            mikeScenarioResult.ValidationResults = Validate(new ValidationContext(mikeScenarioResult), ActionDBTypeEnum.Create);
            if (mikeScenarioResult.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(mikeScenarioResult.ValidationResults));
            }

            try
            {
               db.MikeScenarioResults.Add(mikeScenarioResult);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeScenarioResult));
        }
        public async Task<ActionResult<MikeScenarioResult>> Delete(MikeScenarioResult mikeScenarioResult)
        {
            mikeScenarioResult.ValidationResults = Validate(new ValidationContext(mikeScenarioResult), ActionDBTypeEnum.Delete);
            if (mikeScenarioResult.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(mikeScenarioResult.ValidationResults));
            }

            try
            {
               db.MikeScenarioResults.Remove(mikeScenarioResult);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeScenarioResult));
        }
        public async Task<ActionResult<MikeScenarioResult>> Update(MikeScenarioResult mikeScenarioResult)
        {
            mikeScenarioResult.ValidationResults = Validate(new ValidationContext(mikeScenarioResult), ActionDBTypeEnum.Update);
            if (mikeScenarioResult.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(mikeScenarioResult.ValidationResults));
            }

            try
            {
               db.MikeScenarioResults.Update(mikeScenarioResult);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeScenarioResult));
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
            MikeScenarioResult mikeScenarioResult = validationContext.ObjectInstance as MikeScenarioResult;
            mikeScenarioResult.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeScenarioResult.MikeScenarioResultID == 0)
                {
                    mikeScenarioResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeScenarioResultID"), new[] { "MikeScenarioResultID" });
                }

                if (!(from c in db.MikeScenarioResults select c).Where(c => c.MikeScenarioResultID == mikeScenarioResult.MikeScenarioResultID).Any())
                {
                    mikeScenarioResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MikeScenarioResult", "MikeScenarioResultID", mikeScenarioResult.MikeScenarioResultID.ToString()), new[] { "MikeScenarioResultID" });
                }
            }

            TVItem TVItemMikeScenarioTVItemID = (from c in db.TVItems where c.TVItemID == mikeScenarioResult.MikeScenarioTVItemID select c).FirstOrDefault();

            if (TVItemMikeScenarioTVItemID == null)
            {
                mikeScenarioResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeScenarioTVItemID", mikeScenarioResult.MikeScenarioTVItemID.ToString()), new[] { "MikeScenarioTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeScenario,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeScenarioTVItemID.TVType))
                {
                    mikeScenarioResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MikeScenarioTVItemID", "MikeScenario"), new[] { "MikeScenarioTVItemID" });
                }
            }

            //MikeResultsJSON has no StringLength Attribute

            if (mikeScenarioResult.LastUpdateDate_UTC.Year == 1)
            {
                mikeScenarioResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeScenarioResult.LastUpdateDate_UTC.Year < 1980)
                {
                mikeScenarioResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeScenarioResult.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mikeScenarioResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mikeScenarioResult.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mikeScenarioResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                mikeScenarioResult.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions private

    }
}