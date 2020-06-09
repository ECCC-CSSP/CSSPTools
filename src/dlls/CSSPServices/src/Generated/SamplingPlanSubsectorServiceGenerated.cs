/*
 * Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Resources;
using CultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
   public interface ISamplingPlanSubsectorService
    {
       Task<ActionResult<SamplingPlanSubsector>> GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(int SamplingPlanSubsectorID);
       Task<ActionResult<List<SamplingPlanSubsector>>> GetSamplingPlanSubsectorList();
       Task<ActionResult<SamplingPlanSubsector>> Add(SamplingPlanSubsector samplingplansubsector);
       Task<ActionResult<bool>> Delete(int SamplingPlanSubsectorID);
       Task<ActionResult<SamplingPlanSubsector>> Update(SamplingPlanSubsector samplingplansubsector);
    }
    public partial class SamplingPlanSubsectorService : ControllerBase, ISamplingPlanSubsectorService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private ICultureService CultureService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorService(ICultureService CultureService, IEnums enums, CSSPDBContext db)
        {
            this.CultureService = CultureService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<SamplingPlanSubsector>> GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(int SamplingPlanSubsectorID)
        {
            SamplingPlanSubsector samplingplansubsector = (from c in db.SamplingPlanSubsectors.AsNoTracking()
                    where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                    select c).FirstOrDefault();

            if (samplingplansubsector == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(samplingplansubsector));
        }
        public async Task<ActionResult<List<SamplingPlanSubsector>>> GetSamplingPlanSubsectorList()
        {
            List<SamplingPlanSubsector> samplingplansubsectorList = (from c in db.SamplingPlanSubsectors.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(samplingplansubsectorList));
        }
        public async Task<ActionResult<SamplingPlanSubsector>> Add(SamplingPlanSubsector samplingPlanSubsector)
        {
            ValidationResults = Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.SamplingPlanSubsectors.Add(samplingPlanSubsector);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(samplingPlanSubsector));
        }
        public async Task<ActionResult<bool>> Delete(int SamplingPlanSubsectorID)
        {
            SamplingPlanSubsector samplingPlanSubsector = (from c in db.SamplingPlanSubsectors
                               where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                               select c).FirstOrDefault();
            
            if (samplingPlanSubsector == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorID", SamplingPlanSubsectorID.ToString())));
            }

            try
            {
               db.SamplingPlanSubsectors.Remove(samplingPlanSubsector);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<SamplingPlanSubsector>> Update(SamplingPlanSubsector samplingPlanSubsector)
        {
            ValidationResults = Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.SamplingPlanSubsectors.Update(samplingPlanSubsector);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(samplingPlanSubsector));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            SamplingPlanSubsector samplingPlanSubsector = validationContext.ObjectInstance as SamplingPlanSubsector;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (samplingPlanSubsector.SamplingPlanSubsectorID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "SamplingPlanSubsectorID"), new[] { "SamplingPlanSubsectorID" });
                }

                if (!(from c in db.SamplingPlanSubsectors select c).Where(c => c.SamplingPlanSubsectorID == samplingPlanSubsector.SamplingPlanSubsectorID).Any())
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorID", samplingPlanSubsector.SamplingPlanSubsectorID.ToString()), new[] { "SamplingPlanSubsectorID" });
                }
            }

            SamplingPlan SamplingPlanSamplingPlanID = (from c in db.SamplingPlans where c.SamplingPlanID == samplingPlanSubsector.SamplingPlanID select c).FirstOrDefault();

            if (SamplingPlanSamplingPlanID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", samplingPlanSubsector.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
            }

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsector.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "SubsectorTVItemID", samplingPlanSubsector.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "SubsectorTVItemID", "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            if (samplingPlanSubsector.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (samplingPlanSubsector.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", samplingPlanSubsector.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
