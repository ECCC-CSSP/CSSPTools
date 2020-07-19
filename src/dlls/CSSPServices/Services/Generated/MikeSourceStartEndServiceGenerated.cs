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
   public partial interface IMikeSourceStartEndService
    {
       Task<ActionResult<bool>> Delete(int MikeSourceStartEndID);
       Task<ActionResult<List<MikeSourceStartEnd>>> GetMikeSourceStartEndList(int skip = 0, int take = 100);
       Task<ActionResult<MikeSourceStartEnd>> GetMikeSourceStartEndWithMikeSourceStartEndID(int MikeSourceStartEndID);
       Task<ActionResult<MikeSourceStartEnd>> Post(MikeSourceStartEnd mikesourcestartend);
       Task<ActionResult<MikeSourceStartEnd>> Put(MikeSourceStartEnd mikesourcestartend);
    }
    public partial class MikeSourceStartEndService : ControllerBase, IMikeSourceStartEndService
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
        public MikeSourceStartEndService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<MikeSourceStartEnd>> GetMikeSourceStartEndWithMikeSourceStartEndID(int MikeSourceStartEndID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                MikeSourceStartEnd mikeSourceStartEnd = (from c in dbIM.MikeSourceStartEnds.AsNoTracking()
                                   where c.MikeSourceStartEndID == MikeSourceStartEndID
                                   select c).FirstOrDefault();

                if (mikeSourceStartEnd == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mikeSourceStartEnd));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                MikeSourceStartEnd mikeSourceStartEnd = (from c in dbLocal.MikeSourceStartEnds.AsNoTracking()
                        where c.MikeSourceStartEndID == MikeSourceStartEndID
                        select c).FirstOrDefault();

                if (mikeSourceStartEnd == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mikeSourceStartEnd));
            }
            else
            {
                MikeSourceStartEnd mikeSourceStartEnd = (from c in db.MikeSourceStartEnds.AsNoTracking()
                        where c.MikeSourceStartEndID == MikeSourceStartEndID
                        select c).FirstOrDefault();

                if (mikeSourceStartEnd == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mikeSourceStartEnd));
            }
        }
        public async Task<ActionResult<List<MikeSourceStartEnd>>> GetMikeSourceStartEndList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<MikeSourceStartEnd> mikeSourceStartEndList = (from c in dbIM.MikeSourceStartEnds.AsNoTracking() orderby c.MikeSourceStartEndID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(mikeSourceStartEndList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<MikeSourceStartEnd> mikeSourceStartEndList = (from c in dbLocal.MikeSourceStartEnds.AsNoTracking() orderby c.MikeSourceStartEndID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(mikeSourceStartEndList));
            }
            else
            {
                List<MikeSourceStartEnd> mikeSourceStartEndList = (from c in db.MikeSourceStartEnds.AsNoTracking() orderby c.MikeSourceStartEndID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(mikeSourceStartEndList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int MikeSourceStartEndID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                MikeSourceStartEnd mikeSourceStartEnd = (from c in dbIM.MikeSourceStartEnds
                                   where c.MikeSourceStartEndID == MikeSourceStartEndID
                                   select c).FirstOrDefault();
            
                if (mikeSourceStartEnd == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeSourceStartEnd", "MikeSourceStartEndID", MikeSourceStartEndID.ToString())));
                }
            
                try
                {
                    dbIM.MikeSourceStartEnds.Remove(mikeSourceStartEnd);
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
                MikeSourceStartEnd mikeSourceStartEnd = (from c in dbLocal.MikeSourceStartEnds
                                   where c.MikeSourceStartEndID == MikeSourceStartEndID
                                   select c).FirstOrDefault();
                
                if (mikeSourceStartEnd == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeSourceStartEnd", "MikeSourceStartEndID", MikeSourceStartEndID.ToString())));
                }

                try
                {
                   dbLocal.MikeSourceStartEnds.Remove(mikeSourceStartEnd);
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
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<MikeSourceStartEnd>> Post(MikeSourceStartEnd mikeSourceStartEnd)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mikeSourceStartEnd), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.MikeSourceStartEnds.Add(mikeSourceStartEnd);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mikeSourceStartEnd));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.MikeSourceStartEnds.Add(mikeSourceStartEnd);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mikeSourceStartEnd));
            }
            else
            {
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
        }
        public async Task<ActionResult<MikeSourceStartEnd>> Put(MikeSourceStartEnd mikeSourceStartEnd)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mikeSourceStartEnd), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.MikeSourceStartEnds.Update(mikeSourceStartEnd);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mikeSourceStartEnd));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.MikeSourceStartEnds.Update(mikeSourceStartEnd);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeSourceStartEnd));
            }
            else
            {
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
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MikeSourceStartEnd mikeSourceStartEnd = validationContext.ObjectInstance as MikeSourceStartEnd;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeSourceStartEnd.MikeSourceStartEndID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeSourceStartEndID"), new[] { "MikeSourceStartEndID" });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.MikeSourceStartEnds select c).Where(c => c.MikeSourceStartEndID == mikeSourceStartEnd.MikeSourceStartEndID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeSourceStartEnd", "MikeSourceStartEndID", mikeSourceStartEnd.MikeSourceStartEndID.ToString()), new[] { "MikeSourceStartEndID" });
                    }
                }
                else
                {
                    if (!(from c in db.MikeSourceStartEnds select c).Where(c => c.MikeSourceStartEndID == mikeSourceStartEnd.MikeSourceStartEndID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeSourceStartEnd", "MikeSourceStartEndID", mikeSourceStartEnd.MikeSourceStartEndID.ToString()), new[] { "MikeSourceStartEndID" });
                    }
                }
            }

            MikeSource MikeSourceMikeSourceID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                MikeSourceMikeSourceID = (from c in dbLocal.MikeSources where c.MikeSourceID == mikeSourceStartEnd.MikeSourceID select c).FirstOrDefault();
                if (MikeSourceMikeSourceID == null)
                {
                    MikeSourceMikeSourceID = (from c in dbIM.MikeSources where c.MikeSourceID == mikeSourceStartEnd.MikeSourceID select c).FirstOrDefault();
                }
            }
            else
            {
                MikeSourceMikeSourceID = (from c in db.MikeSources where c.MikeSourceID == mikeSourceStartEnd.MikeSourceID select c).FirstOrDefault();
            }

            if (MikeSourceMikeSourceID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeSource", "MikeSourceID", mikeSourceStartEnd.MikeSourceID.ToString()), new[] { "MikeSourceID" });
            }

            if (mikeSourceStartEnd.StartDateAndTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "StartDateAndTime_Local"), new[] { "StartDateAndTime_Local" });
            }
            else
            {
                if (mikeSourceStartEnd.StartDateAndTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateAndTime_Local", "1980"), new[] { "StartDateAndTime_Local" });
                }
            }

            if (mikeSourceStartEnd.EndDateAndTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EndDateAndTime_Local"), new[] { "EndDateAndTime_Local" });
            }
            else
            {
                if (mikeSourceStartEnd.EndDateAndTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateAndTime_Local", "1980"), new[] { "EndDateAndTime_Local" });
                }
            }

            if (mikeSourceStartEnd.StartDateAndTime_Local > mikeSourceStartEnd.EndDateAndTime_Local)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, "EndDateAndTime_Local", "MikeSourceStartEndStartDateAndTime_Local"), new[] { "EndDateAndTime_Local" });
            }

            if (mikeSourceStartEnd.SourceFlowStart_m3_day < 0 || mikeSourceStartEnd.SourceFlowStart_m3_day > 1000000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourceFlowStart_m3_day", "0", "1000000"), new[] { "SourceFlowStart_m3_day" });
            }

            if (mikeSourceStartEnd.SourceFlowEnd_m3_day < 0 || mikeSourceStartEnd.SourceFlowEnd_m3_day > 1000000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourceFlowEnd_m3_day", "0", "1000000"), new[] { "SourceFlowEnd_m3_day" });
            }

            if (mikeSourceStartEnd.SourcePollutionStart_MPN_100ml < 0 || mikeSourceStartEnd.SourcePollutionStart_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourcePollutionStart_MPN_100ml", "0", "10000000"), new[] { "SourcePollutionStart_MPN_100ml" });
            }

            if (mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml < 0 || mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourcePollutionEnd_MPN_100ml", "0", "10000000"), new[] { "SourcePollutionEnd_MPN_100ml" });
            }

            if (mikeSourceStartEnd.SourceTemperatureStart_C < -10 || mikeSourceStartEnd.SourceTemperatureStart_C > 40)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourceTemperatureStart_C", "-10", "40"), new[] { "SourceTemperatureStart_C" });
            }

            if (mikeSourceStartEnd.SourceTemperatureEnd_C < -10 || mikeSourceStartEnd.SourceTemperatureEnd_C > 40)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourceTemperatureEnd_C", "-10", "40"), new[] { "SourceTemperatureEnd_C" });
            }

            if (mikeSourceStartEnd.SourceSalinityStart_PSU < 0 || mikeSourceStartEnd.SourceSalinityStart_PSU > 40)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourceSalinityStart_PSU", "0", "40"), new[] { "SourceSalinityStart_PSU" });
            }

            if (mikeSourceStartEnd.SourceSalinityEnd_PSU < 0 || mikeSourceStartEnd.SourceSalinityEnd_PSU > 40)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SourceSalinityEnd_PSU", "0", "40"), new[] { "SourceSalinityEnd_PSU" });
            }

            if (mikeSourceStartEnd.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeSourceStartEnd.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mikeSourceStartEnd.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == mikeSourceStartEnd.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeSourceStartEnd.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mikeSourceStartEnd.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
