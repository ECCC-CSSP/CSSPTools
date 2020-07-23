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

namespace CSSPServices
{
   public partial interface IDrogueRunService
    {
       Task<ActionResult<bool>> Delete(int DrogueRunID);
       Task<ActionResult<List<DrogueRun>>> GetDrogueRunList(int skip = 0, int take = 100);
       Task<ActionResult<DrogueRun>> GetDrogueRunWithDrogueRunID(int DrogueRunID);
       Task<ActionResult<DrogueRun>> Post(DrogueRun droguerun);
       Task<ActionResult<DrogueRun>> Put(DrogueRun droguerun);
    }
    public partial class DrogueRunService : ControllerBase, IDrogueRunService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public DrogueRunService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<DrogueRun>> GetDrogueRunWithDrogueRunID(int DrogueRunID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                DrogueRun drogueRun = (from c in dbIM.DrogueRuns.AsNoTracking()
                                   where c.DrogueRunID == DrogueRunID
                                   select c).FirstOrDefault();

                if (drogueRun == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(drogueRun));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                DrogueRun drogueRun = (from c in dbLocal.DrogueRuns.AsNoTracking()
                        where c.DrogueRunID == DrogueRunID
                        select c).FirstOrDefault();

                if (drogueRun == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(drogueRun));
            }
            else
            {
                DrogueRun drogueRun = (from c in db.DrogueRuns.AsNoTracking()
                        where c.DrogueRunID == DrogueRunID
                        select c).FirstOrDefault();

                if (drogueRun == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(drogueRun));
            }
        }
        public async Task<ActionResult<List<DrogueRun>>> GetDrogueRunList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<DrogueRun> drogueRunList = (from c in dbIM.DrogueRuns.AsNoTracking() orderby c.DrogueRunID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(drogueRunList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<DrogueRun> drogueRunList = (from c in dbLocal.DrogueRuns.AsNoTracking() orderby c.DrogueRunID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(drogueRunList));
            }
            else
            {
                List<DrogueRun> drogueRunList = (from c in db.DrogueRuns.AsNoTracking() orderby c.DrogueRunID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(drogueRunList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int DrogueRunID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                DrogueRun drogueRun = (from c in dbIM.DrogueRuns
                                   where c.DrogueRunID == DrogueRunID
                                   select c).FirstOrDefault();
            
                if (drogueRun == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DrogueRun", "DrogueRunID", DrogueRunID.ToString())));
                }
            
                try
                {
                    dbIM.DrogueRuns.Remove(drogueRun);
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
                DrogueRun drogueRun = (from c in dbLocal.DrogueRuns
                                   where c.DrogueRunID == DrogueRunID
                                   select c).FirstOrDefault();
                
                if (drogueRun == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DrogueRun", "DrogueRunID", DrogueRunID.ToString())));
                }

                try
                {
                   dbLocal.DrogueRuns.Remove(drogueRun);
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
                DrogueRun drogueRun = (from c in db.DrogueRuns
                                   where c.DrogueRunID == DrogueRunID
                                   select c).FirstOrDefault();
                
                if (drogueRun == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DrogueRun", "DrogueRunID", DrogueRunID.ToString())));
                }

                try
                {
                   db.DrogueRuns.Remove(drogueRun);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<DrogueRun>> Post(DrogueRun drogueRun)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(drogueRun), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.DrogueRuns.Add(drogueRun);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(drogueRun));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.DrogueRuns.Add(drogueRun);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(drogueRun));
            }
            else
            {
                try
                {
                   db.DrogueRuns.Add(drogueRun);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(drogueRun));
            }
        }
        public async Task<ActionResult<DrogueRun>> Put(DrogueRun drogueRun)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(drogueRun), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.DrogueRuns.Update(drogueRun);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(drogueRun));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.DrogueRuns.Update(drogueRun);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(drogueRun));
            }
            else
            {
            try
            {
               db.DrogueRuns.Update(drogueRun);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(drogueRun));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            DrogueRun drogueRun = validationContext.ObjectInstance as DrogueRun;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (drogueRun.DrogueRunID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DrogueRunID"), new[] { nameof(drogueRun.DrogueRunID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.DrogueRuns select c).Where(c => c.DrogueRunID == drogueRun.DrogueRunID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DrogueRun", "DrogueRunID", drogueRun.DrogueRunID.ToString()), new[] { nameof(drogueRun.DrogueRunID) });
                    }
                }
                else
                {
                    if (!(from c in db.DrogueRuns select c).Where(c => c.DrogueRunID == drogueRun.DrogueRunID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DrogueRun", "DrogueRunID", drogueRun.DrogueRunID.ToString()), new[] { nameof(drogueRun.DrogueRunID) });
                    }
                }
            }

            TVItem TVItemSubsectorTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemSubsectorTVItemID = (from c in dbLocal.TVItems where c.TVItemID == drogueRun.SubsectorTVItemID select c).FirstOrDefault();
                if (TVItemSubsectorTVItemID == null)
                {
                    TVItemSubsectorTVItemID = (from c in dbIM.TVItems where c.TVItemID == drogueRun.SubsectorTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == drogueRun.SubsectorTVItemID select c).FirstOrDefault();
            }

            if (TVItemSubsectorTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "SubsectorTVItemID", drogueRun.SubsectorTVItemID.ToString()), new[] { nameof(drogueRun.SubsectorTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "SubsectorTVItemID", "Subsector"), new[] { nameof(drogueRun.SubsectorTVItemID) });
                }
            }

            if (drogueRun.DrogueNumber < 0 || drogueRun.DrogueNumber > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DrogueNumber", "0", "100"), new[] { nameof(drogueRun.DrogueNumber) });
            }

            retStr = enums.EnumTypeOK(typeof(DrogueTypeEnum), (int?)drogueRun.DrogueType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DrogueType"), new[] { nameof(drogueRun.DrogueType) });
            }

            if (drogueRun.RunStartDateTime.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RunStartDateTime"), new[] { nameof(drogueRun.RunStartDateTime) });
            }
            else
            {
                if (drogueRun.RunStartDateTime.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "RunStartDateTime", "1980"), new[] { nameof(drogueRun.RunStartDateTime) });
                }
            }

            if (drogueRun.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(drogueRun.LastUpdateDate_UTC) });
            }
            else
            {
                if (drogueRun.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(drogueRun.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == drogueRun.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == drogueRun.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == drogueRun.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", drogueRun.LastUpdateContactTVItemID.ToString()), new[] { nameof(drogueRun.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(drogueRun.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}