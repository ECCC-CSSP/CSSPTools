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
   public partial interface IDrogueRunPositionService
    {
       Task<ActionResult<bool>> Delete(int DrogueRunPositionID);
       Task<ActionResult<List<DrogueRunPosition>>> GetDrogueRunPositionList(int skip = 0, int take = 100);
       Task<ActionResult<DrogueRunPosition>> GetDrogueRunPositionWithDrogueRunPositionID(int DrogueRunPositionID);
       Task<ActionResult<DrogueRunPosition>> Post(DrogueRunPosition droguerunposition);
       Task<ActionResult<DrogueRunPosition>> Put(DrogueRunPosition droguerunposition);
    }
    public partial class DrogueRunPositionService : ControllerBase, IDrogueRunPositionService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBInMemoryContext dbIM { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public DrogueRunPositionService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal = null, CSSPDBInMemoryContext dbIM = null)
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
        public async Task<ActionResult<DrogueRunPosition>> GetDrogueRunPositionWithDrogueRunPositionID(int DrogueRunPositionID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                DrogueRunPosition drogueRunPosition = (from c in dbIM.DrogueRunPositions.AsNoTracking()
                                   where c.DrogueRunPositionID == DrogueRunPositionID
                                   select c).FirstOrDefault();

                if (drogueRunPosition == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(drogueRunPosition));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                DrogueRunPosition drogueRunPosition = (from c in dbLocal.DrogueRunPositions.AsNoTracking()
                        where c.DrogueRunPositionID == DrogueRunPositionID
                        select c).FirstOrDefault();

                if (drogueRunPosition == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(drogueRunPosition));
            }
            else
            {
                DrogueRunPosition drogueRunPosition = (from c in db.DrogueRunPositions.AsNoTracking()
                        where c.DrogueRunPositionID == DrogueRunPositionID
                        select c).FirstOrDefault();

                if (drogueRunPosition == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(drogueRunPosition));
            }
        }
        public async Task<ActionResult<List<DrogueRunPosition>>> GetDrogueRunPositionList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<DrogueRunPosition> drogueRunPositionList = (from c in dbIM.DrogueRunPositions.AsNoTracking() orderby c.DrogueRunPositionID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(drogueRunPositionList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<DrogueRunPosition> drogueRunPositionList = (from c in dbLocal.DrogueRunPositions.AsNoTracking() orderby c.DrogueRunPositionID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(drogueRunPositionList));
            }
            else
            {
                List<DrogueRunPosition> drogueRunPositionList = (from c in db.DrogueRunPositions.AsNoTracking() orderby c.DrogueRunPositionID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(drogueRunPositionList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int DrogueRunPositionID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                DrogueRunPosition drogueRunPosition = (from c in dbIM.DrogueRunPositions
                                   where c.DrogueRunPositionID == DrogueRunPositionID
                                   select c).FirstOrDefault();
            
                if (drogueRunPosition == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DrogueRunPosition", "DrogueRunPositionID", DrogueRunPositionID.ToString())));
                }
            
                try
                {
                    dbIM.DrogueRunPositions.Remove(drogueRunPosition);
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
                DrogueRunPosition drogueRunPosition = (from c in dbLocal.DrogueRunPositions
                                   where c.DrogueRunPositionID == DrogueRunPositionID
                                   select c).FirstOrDefault();
                
                if (drogueRunPosition == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DrogueRunPosition", "DrogueRunPositionID", DrogueRunPositionID.ToString())));
                }

                try
                {
                   dbLocal.DrogueRunPositions.Remove(drogueRunPosition);
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
                DrogueRunPosition drogueRunPosition = (from c in db.DrogueRunPositions
                                   where c.DrogueRunPositionID == DrogueRunPositionID
                                   select c).FirstOrDefault();
                
                if (drogueRunPosition == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DrogueRunPosition", "DrogueRunPositionID", DrogueRunPositionID.ToString())));
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

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<DrogueRunPosition>> Post(DrogueRunPosition drogueRunPosition)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(drogueRunPosition), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.DrogueRunPositions.Add(drogueRunPosition);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(drogueRunPosition));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.DrogueRunPositions.Add(drogueRunPosition);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(drogueRunPosition));
            }
            else
            {
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
        }
        public async Task<ActionResult<DrogueRunPosition>> Put(DrogueRunPosition drogueRunPosition)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(drogueRunPosition), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.DrogueRunPositions.Update(drogueRunPosition);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(drogueRunPosition));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.DrogueRunPositions.Update(drogueRunPosition);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(drogueRunPosition));
            }
            else
            {
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
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DrogueRunPositionID"), new[] { nameof(drogueRunPosition.DrogueRunPositionID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.DrogueRunPositions select c).Where(c => c.DrogueRunPositionID == drogueRunPosition.DrogueRunPositionID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DrogueRunPosition", "DrogueRunPositionID", drogueRunPosition.DrogueRunPositionID.ToString()), new[] { nameof(drogueRunPosition.DrogueRunPositionID) });
                    }
                }
                else
                {
                    if (!(from c in db.DrogueRunPositions select c).Where(c => c.DrogueRunPositionID == drogueRunPosition.DrogueRunPositionID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DrogueRunPosition", "DrogueRunPositionID", drogueRunPosition.DrogueRunPositionID.ToString()), new[] { nameof(drogueRunPosition.DrogueRunPositionID) });
                    }
                }
            }

            DrogueRun DrogueRunDrogueRunID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                DrogueRunDrogueRunID = (from c in dbLocal.DrogueRuns where c.DrogueRunID == drogueRunPosition.DrogueRunID select c).FirstOrDefault();
                if (DrogueRunDrogueRunID == null)
                {
                    DrogueRunDrogueRunID = (from c in dbIM.DrogueRuns where c.DrogueRunID == drogueRunPosition.DrogueRunID select c).FirstOrDefault();
                }
            }
            else
            {
                DrogueRunDrogueRunID = (from c in db.DrogueRuns where c.DrogueRunID == drogueRunPosition.DrogueRunID select c).FirstOrDefault();
            }

            if (DrogueRunDrogueRunID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DrogueRun", "DrogueRunID", drogueRunPosition.DrogueRunID.ToString()), new[] { nameof(drogueRunPosition.DrogueRunID) });
            }

            if (drogueRunPosition.Ordinal < 0 || drogueRunPosition.Ordinal > 100000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "100000"), new[] { nameof(drogueRunPosition.Ordinal) });
            }

            if (drogueRunPosition.StepLat < -180 || drogueRunPosition.StepLat > 180)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "StepLat", "-180", "180"), new[] { nameof(drogueRunPosition.StepLat) });
            }

            if (drogueRunPosition.StepLng < -90 || drogueRunPosition.StepLng > 90)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "StepLng", "-90", "90"), new[] { nameof(drogueRunPosition.StepLng) });
            }

            if (drogueRunPosition.StepDateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "StepDateTime_Local"), new[] { nameof(drogueRunPosition.StepDateTime_Local) });
            }
            else
            {
                if (drogueRunPosition.StepDateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StepDateTime_Local", "1980"), new[] { nameof(drogueRunPosition.StepDateTime_Local) });
                }
            }

            if (drogueRunPosition.CalculatedSpeed_m_s < 0 || drogueRunPosition.CalculatedSpeed_m_s > 10)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "CalculatedSpeed_m_s", "0", "10"), new[] { nameof(drogueRunPosition.CalculatedSpeed_m_s) });
            }

            if (drogueRunPosition.CalculatedDirection_deg < 0 || drogueRunPosition.CalculatedDirection_deg > 360)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "CalculatedDirection_deg", "0", "360"), new[] { nameof(drogueRunPosition.CalculatedDirection_deg) });
            }

            if (drogueRunPosition.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(drogueRunPosition.LastUpdateDate_UTC) });
            }
            else
            {
                if (drogueRunPosition.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(drogueRunPosition.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == drogueRunPosition.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == drogueRunPosition.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == drogueRunPosition.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", drogueRunPosition.LastUpdateContactTVItemID.ToString()), new[] { nameof(drogueRunPosition.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(drogueRunPosition.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
