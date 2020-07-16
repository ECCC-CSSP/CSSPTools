/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Resources;
using CultureServices.Services;
using LoggedInServices.Services;
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
       Task<ActionResult<bool>> Delete(int SamplingPlanSubsectorID);
       Task<ActionResult<List<SamplingPlanSubsector>>> GetSamplingPlanSubsectorList(int skip = 0, int take = 100);
       Task<ActionResult<SamplingPlanSubsector>> GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(int SamplingPlanSubsectorID);
       Task<ActionResult<SamplingPlanSubsector>> Post(SamplingPlanSubsector samplingplansubsector);
       Task<ActionResult<SamplingPlanSubsector>> Put(SamplingPlanSubsector samplingplansubsector);
    }
    public partial class SamplingPlanSubsectorService : ControllerBase, ISamplingPlanSubsectorService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<SamplingPlanSubsector>> GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(int SamplingPlanSubsectorID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                SamplingPlanSubsector samplingPlanSubsector = (from c in dbIM.SamplingPlanSubsectors.AsNoTracking()
                                   where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                                   select c).FirstOrDefault();

                if (samplingPlanSubsector == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(samplingPlanSubsector));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                SamplingPlanSubsector samplingPlanSubsector = (from c in dbLocal.SamplingPlanSubsectors.AsNoTracking()
                        where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                        select c).FirstOrDefault();

                if (samplingPlanSubsector == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(samplingPlanSubsector));
            }
            else
            {
                SamplingPlanSubsector samplingPlanSubsector = (from c in db.SamplingPlanSubsectors.AsNoTracking()
                        where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                        select c).FirstOrDefault();

                if (samplingPlanSubsector == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(samplingPlanSubsector));
            }
        }
        public async Task<ActionResult<List<SamplingPlanSubsector>>> GetSamplingPlanSubsectorList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<SamplingPlanSubsector> samplingPlanSubsectorList = (from c in dbIM.SamplingPlanSubsectors.AsNoTracking() orderby c.SamplingPlanSubsectorID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(samplingPlanSubsectorList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<SamplingPlanSubsector> samplingPlanSubsectorList = (from c in dbLocal.SamplingPlanSubsectors.AsNoTracking() orderby c.SamplingPlanSubsectorID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(samplingPlanSubsectorList));
            }
            else
            {
                List<SamplingPlanSubsector> samplingPlanSubsectorList = (from c in db.SamplingPlanSubsectors.AsNoTracking() orderby c.SamplingPlanSubsectorID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(samplingPlanSubsectorList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int SamplingPlanSubsectorID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                SamplingPlanSubsector samplingPlanSubsector = (from c in dbIM.SamplingPlanSubsectors
                                   where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                                   select c).FirstOrDefault();
            
                if (samplingPlanSubsector == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorID", SamplingPlanSubsectorID.ToString())));
                }
            
                try
                {
                    dbIM.SamplingPlanSubsectors.Remove(samplingPlanSubsector);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }
            
                return await Task.FromResult(Ok(true));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                SamplingPlanSubsector samplingPlanSubsector = (from c in dbLocal.SamplingPlanSubsectors
                                   where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                                   select c).FirstOrDefault();
                
                if (samplingPlanSubsector == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorID", SamplingPlanSubsectorID.ToString())));
                }

                try
                {
                   dbLocal.SamplingPlanSubsectors.Remove(samplingPlanSubsector);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
            else
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
        }
        public async Task<ActionResult<SamplingPlanSubsector>> Post(SamplingPlanSubsector samplingPlanSubsector)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.SamplingPlanSubsectors.Add(samplingPlanSubsector);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(samplingPlanSubsector));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.SamplingPlanSubsectors.Add(samplingPlanSubsector);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(samplingPlanSubsector));
            }
            else
            {
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
        }
        public async Task<ActionResult<SamplingPlanSubsector>> Put(SamplingPlanSubsector samplingPlanSubsector)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.SamplingPlanSubsectors.Update(samplingPlanSubsector);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(samplingPlanSubsector));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.SamplingPlanSubsectors.Update(samplingPlanSubsector);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(samplingPlanSubsector));
            }
            else
            {
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

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.SamplingPlanSubsectors select c).Where(c => c.SamplingPlanSubsectorID == samplingPlanSubsector.SamplingPlanSubsectorID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorID", samplingPlanSubsector.SamplingPlanSubsectorID.ToString()), new[] { "SamplingPlanSubsectorID" });
                    }
                }
                else
                {
                    if (!(from c in db.SamplingPlanSubsectors select c).Where(c => c.SamplingPlanSubsectorID == samplingPlanSubsector.SamplingPlanSubsectorID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorID", samplingPlanSubsector.SamplingPlanSubsectorID.ToString()), new[] { "SamplingPlanSubsectorID" });
                    }
                }
            }

            SamplingPlan SamplingPlanSamplingPlanID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                SamplingPlanSamplingPlanID = (from c in dbLocal.SamplingPlans where c.SamplingPlanID == samplingPlanSubsector.SamplingPlanID select c).FirstOrDefault();
                if (SamplingPlanSamplingPlanID == null)
                {
                    SamplingPlanSamplingPlanID = (from c in dbIM.SamplingPlans where c.SamplingPlanID == samplingPlanSubsector.SamplingPlanID select c).FirstOrDefault();
                }
            }
            else
            {
                SamplingPlanSamplingPlanID = (from c in db.SamplingPlans where c.SamplingPlanID == samplingPlanSubsector.SamplingPlanID select c).FirstOrDefault();
            }

            if (SamplingPlanSamplingPlanID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", samplingPlanSubsector.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
            }

            TVItem TVItemSubsectorTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemSubsectorTVItemID = (from c in dbLocal.TVItems where c.TVItemID == samplingPlanSubsector.SubsectorTVItemID select c).FirstOrDefault();
                if (TVItemSubsectorTVItemID == null)
                {
                    TVItemSubsectorTVItemID = (from c in dbIM.TVItems where c.TVItemID == samplingPlanSubsector.SubsectorTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsector.SubsectorTVItemID select c).FirstOrDefault();
            }

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

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == samplingPlanSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == samplingPlanSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

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
