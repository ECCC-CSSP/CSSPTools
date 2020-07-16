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
   public interface IRainExceedanceService
    {
       Task<ActionResult<bool>> Delete(int RainExceedanceID);
       Task<ActionResult<List<RainExceedance>>> GetRainExceedanceList(int skip = 0, int take = 100);
       Task<ActionResult<RainExceedance>> GetRainExceedanceWithRainExceedanceID(int RainExceedanceID);
       Task<ActionResult<RainExceedance>> Post(RainExceedance rainexceedance);
       Task<ActionResult<RainExceedance>> Put(RainExceedance rainexceedance);
    }
    public partial class RainExceedanceService : ControllerBase, IRainExceedanceService
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
        public RainExceedanceService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<RainExceedance>> GetRainExceedanceWithRainExceedanceID(int RainExceedanceID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                RainExceedance rainExceedance = (from c in dbIM.RainExceedances.AsNoTracking()
                                   where c.RainExceedanceID == RainExceedanceID
                                   select c).FirstOrDefault();

                if (rainExceedance == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(rainExceedance));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                RainExceedance rainExceedance = (from c in dbLocal.RainExceedances.AsNoTracking()
                        where c.RainExceedanceID == RainExceedanceID
                        select c).FirstOrDefault();

                if (rainExceedance == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(rainExceedance));
            }
            else
            {
                RainExceedance rainExceedance = (from c in db.RainExceedances.AsNoTracking()
                        where c.RainExceedanceID == RainExceedanceID
                        select c).FirstOrDefault();

                if (rainExceedance == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(rainExceedance));
            }
        }
        public async Task<ActionResult<List<RainExceedance>>> GetRainExceedanceList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<RainExceedance> rainExceedanceList = (from c in dbIM.RainExceedances.AsNoTracking() orderby c.RainExceedanceID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(rainExceedanceList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<RainExceedance> rainExceedanceList = (from c in dbLocal.RainExceedances.AsNoTracking() orderby c.RainExceedanceID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(rainExceedanceList));
            }
            else
            {
                List<RainExceedance> rainExceedanceList = (from c in db.RainExceedances.AsNoTracking() orderby c.RainExceedanceID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(rainExceedanceList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int RainExceedanceID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                RainExceedance rainExceedance = (from c in dbIM.RainExceedances
                                   where c.RainExceedanceID == RainExceedanceID
                                   select c).FirstOrDefault();
            
                if (rainExceedance == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "RainExceedance", "RainExceedanceID", RainExceedanceID.ToString())));
                }
            
                try
                {
                    dbIM.RainExceedances.Remove(rainExceedance);
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
                RainExceedance rainExceedance = (from c in dbLocal.RainExceedances
                                   where c.RainExceedanceID == RainExceedanceID
                                   select c).FirstOrDefault();
                
                if (rainExceedance == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "RainExceedance", "RainExceedanceID", RainExceedanceID.ToString())));
                }

                try
                {
                   dbLocal.RainExceedances.Remove(rainExceedance);
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
                RainExceedance rainExceedance = (from c in db.RainExceedances
                                   where c.RainExceedanceID == RainExceedanceID
                                   select c).FirstOrDefault();
                
                if (rainExceedance == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "RainExceedance", "RainExceedanceID", RainExceedanceID.ToString())));
                }

                try
                {
                   db.RainExceedances.Remove(rainExceedance);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<RainExceedance>> Post(RainExceedance rainExceedance)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(rainExceedance), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.RainExceedances.Add(rainExceedance);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(rainExceedance));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.RainExceedances.Add(rainExceedance);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(rainExceedance));
            }
            else
            {
                try
                {
                   db.RainExceedances.Add(rainExceedance);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(rainExceedance));
            }
        }
        public async Task<ActionResult<RainExceedance>> Put(RainExceedance rainExceedance)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(rainExceedance), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.RainExceedances.Update(rainExceedance);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(rainExceedance));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.RainExceedances.Update(rainExceedance);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(rainExceedance));
            }
            else
            {
            try
            {
               db.RainExceedances.Update(rainExceedance);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(rainExceedance));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            RainExceedance rainExceedance = validationContext.ObjectInstance as RainExceedance;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (rainExceedance.RainExceedanceID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "RainExceedanceID"), new[] { "RainExceedanceID" });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.RainExceedances select c).Where(c => c.RainExceedanceID == rainExceedance.RainExceedanceID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "RainExceedance", "RainExceedanceID", rainExceedance.RainExceedanceID.ToString()), new[] { "RainExceedanceID" });
                    }
                }
                else
                {
                    if (!(from c in db.RainExceedances select c).Where(c => c.RainExceedanceID == rainExceedance.RainExceedanceID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "RainExceedance", "RainExceedanceID", rainExceedance.RainExceedanceID.ToString()), new[] { "RainExceedanceID" });
                    }
                }
            }

            TVItem TVItemRainExceedanceTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemRainExceedanceTVItemID = (from c in dbLocal.TVItems where c.TVItemID == rainExceedance.RainExceedanceTVItemID select c).FirstOrDefault();
                if (TVItemRainExceedanceTVItemID == null)
                {
                    TVItemRainExceedanceTVItemID = (from c in dbIM.TVItems where c.TVItemID == rainExceedance.RainExceedanceTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemRainExceedanceTVItemID = (from c in db.TVItems where c.TVItemID == rainExceedance.RainExceedanceTVItemID select c).FirstOrDefault();
            }

            if (TVItemRainExceedanceTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "RainExceedanceTVItemID", rainExceedance.RainExceedanceTVItemID.ToString()), new[] { "RainExceedanceTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.RainExceedance,
                };
                if (!AllowableTVTypes.Contains(TVItemRainExceedanceTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "RainExceedanceTVItemID", "RainExceedance"), new[] { "RainExceedanceTVItemID" });
                }
            }

            if (rainExceedance.StartMonth < 1 || rainExceedance.StartMonth > 12)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "StartMonth", "1", "12"), new[] { "StartMonth" });
            }

            if (rainExceedance.StartDay < 1 || rainExceedance.StartDay > 31)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "StartDay", "1", "31"), new[] { "StartDay" });
            }

            if (rainExceedance.EndMonth < 1 || rainExceedance.EndMonth > 12)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "EndMonth", "1", "12"), new[] { "EndMonth" });
            }

            if (rainExceedance.EndDay < 1 || rainExceedance.EndDay > 31)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "EndDay", "1", "31"), new[] { "EndDay" });
            }

            if (rainExceedance.RainMaximum_mm < 0 || rainExceedance.RainMaximum_mm > 300)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "RainMaximum_mm", "0", "300"), new[] { "RainMaximum_mm" });
            }

            if (rainExceedance.StakeholdersEmailDistributionListID != null)
            {
                EmailDistributionList EmailDistributionListStakeholdersEmailDistributionListID = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    EmailDistributionListStakeholdersEmailDistributionListID = (from c in dbLocal.EmailDistributionLists where c.EmailDistributionListID == rainExceedance.StakeholdersEmailDistributionListID select c).FirstOrDefault();
                    if (EmailDistributionListStakeholdersEmailDistributionListID == null)
                    {
                        EmailDistributionListStakeholdersEmailDistributionListID = (from c in dbIM.EmailDistributionLists where c.EmailDistributionListID == rainExceedance.StakeholdersEmailDistributionListID select c).FirstOrDefault();
                    }
                }
                else
                {
                    EmailDistributionListStakeholdersEmailDistributionListID = (from c in db.EmailDistributionLists where c.EmailDistributionListID == rainExceedance.StakeholdersEmailDistributionListID select c).FirstOrDefault();
                }

                if (EmailDistributionListStakeholdersEmailDistributionListID == null)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "StakeholdersEmailDistributionListID", (rainExceedance.StakeholdersEmailDistributionListID == null ? "" : rainExceedance.StakeholdersEmailDistributionListID.ToString())), new[] { "StakeholdersEmailDistributionListID" });
                }
            }

            if (rainExceedance.OnlyStaffEmailDistributionListID != null)
            {
                EmailDistributionList EmailDistributionListOnlyStaffEmailDistributionListID = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    EmailDistributionListOnlyStaffEmailDistributionListID = (from c in dbLocal.EmailDistributionLists where c.EmailDistributionListID == rainExceedance.OnlyStaffEmailDistributionListID select c).FirstOrDefault();
                    if (EmailDistributionListOnlyStaffEmailDistributionListID == null)
                    {
                        EmailDistributionListOnlyStaffEmailDistributionListID = (from c in dbIM.EmailDistributionLists where c.EmailDistributionListID == rainExceedance.OnlyStaffEmailDistributionListID select c).FirstOrDefault();
                    }
                }
                else
                {
                    EmailDistributionListOnlyStaffEmailDistributionListID = (from c in db.EmailDistributionLists where c.EmailDistributionListID == rainExceedance.OnlyStaffEmailDistributionListID select c).FirstOrDefault();
                }

                if (EmailDistributionListOnlyStaffEmailDistributionListID == null)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "OnlyStaffEmailDistributionListID", (rainExceedance.OnlyStaffEmailDistributionListID == null ? "" : rainExceedance.OnlyStaffEmailDistributionListID.ToString())), new[] { "OnlyStaffEmailDistributionListID" });
                }
            }

            if (rainExceedance.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (rainExceedance.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == rainExceedance.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == rainExceedance.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == rainExceedance.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", rainExceedance.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
