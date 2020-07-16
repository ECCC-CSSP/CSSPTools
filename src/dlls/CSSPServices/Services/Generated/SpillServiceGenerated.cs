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
   public partial interface ISpillService
    {
       Task<ActionResult<bool>> Delete(int SpillID);
       Task<ActionResult<List<Spill>>> GetSpillList(int skip = 0, int take = 100);
       Task<ActionResult<Spill>> GetSpillWithSpillID(int SpillID);
       Task<ActionResult<Spill>> Post(Spill spill);
       Task<ActionResult<Spill>> Put(Spill spill);
    }
    public partial class SpillService : ControllerBase, ISpillService
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
        public SpillService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<Spill>> GetSpillWithSpillID(int SpillID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                Spill spill = (from c in dbIM.Spills.AsNoTracking()
                                   where c.SpillID == SpillID
                                   select c).FirstOrDefault();

                if (spill == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(spill));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                Spill spill = (from c in dbLocal.Spills.AsNoTracking()
                        where c.SpillID == SpillID
                        select c).FirstOrDefault();

                if (spill == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(spill));
            }
            else
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
        }
        public async Task<ActionResult<List<Spill>>> GetSpillList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<Spill> spillList = (from c in dbIM.Spills.AsNoTracking() orderby c.SpillID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(spillList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<Spill> spillList = (from c in dbLocal.Spills.AsNoTracking() orderby c.SpillID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(spillList));
            }
            else
            {
                List<Spill> spillList = (from c in db.Spills.AsNoTracking() orderby c.SpillID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(spillList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int SpillID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                Spill spill = (from c in dbIM.Spills
                                   where c.SpillID == SpillID
                                   select c).FirstOrDefault();
            
                if (spill == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillID", SpillID.ToString())));
                }
            
                try
                {
                    dbIM.Spills.Remove(spill);
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
                Spill spill = (from c in dbLocal.Spills
                                   where c.SpillID == SpillID
                                   select c).FirstOrDefault();
                
                if (spill == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillID", SpillID.ToString())));
                }

                try
                {
                   dbLocal.Spills.Remove(spill);
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
                Spill spill = (from c in db.Spills
                                   where c.SpillID == SpillID
                                   select c).FirstOrDefault();
                
                if (spill == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillID", SpillID.ToString())));
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

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<Spill>> Post(Spill spill)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.Spills.Add(spill);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(spill));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.Spills.Add(spill);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(spill));
            }
            else
            {
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
        }
        public async Task<ActionResult<Spill>> Put(Spill spill)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.Spills.Update(spill);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(spill));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.Spills.Update(spill);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(spill));
            }
            else
            {
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
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "SpillID"), new[] { "SpillID" });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.Spills select c).Where(c => c.SpillID == spill.SpillID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillID", spill.SpillID.ToString()), new[] { "SpillID" });
                    }
                }
                else
                {
                    if (!(from c in db.Spills select c).Where(c => c.SpillID == spill.SpillID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillID", spill.SpillID.ToString()), new[] { "SpillID" });
                    }
                }
            }

            TVItem TVItemMunicipalityTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemMunicipalityTVItemID = (from c in dbLocal.TVItems where c.TVItemID == spill.MunicipalityTVItemID select c).FirstOrDefault();
                if (TVItemMunicipalityTVItemID == null)
                {
                    TVItemMunicipalityTVItemID = (from c in dbIM.TVItems where c.TVItemID == spill.MunicipalityTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemMunicipalityTVItemID = (from c in db.TVItems where c.TVItemID == spill.MunicipalityTVItemID select c).FirstOrDefault();
            }

            if (TVItemMunicipalityTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MunicipalityTVItemID", spill.MunicipalityTVItemID.ToString()), new[] { "MunicipalityTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Municipality,
                };
                if (!AllowableTVTypes.Contains(TVItemMunicipalityTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "MunicipalityTVItemID", "Municipality"), new[] { "MunicipalityTVItemID" });
                }
            }

            if (spill.InfrastructureTVItemID != null)
            {
                TVItem TVItemInfrastructureTVItemID = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    TVItemInfrastructureTVItemID = (from c in dbLocal.TVItems where c.TVItemID == spill.InfrastructureTVItemID select c).FirstOrDefault();
                    if (TVItemInfrastructureTVItemID == null)
                    {
                        TVItemInfrastructureTVItemID = (from c in dbIM.TVItems where c.TVItemID == spill.InfrastructureTVItemID select c).FirstOrDefault();
                    }
                }
                else
                {
                    TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == spill.InfrastructureTVItemID select c).FirstOrDefault();
                }

                if (TVItemInfrastructureTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureTVItemID", (spill.InfrastructureTVItemID == null ? "" : spill.InfrastructureTVItemID.ToString())), new[] { "InfrastructureTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Infrastructure,
                    };
                    if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "InfrastructureTVItemID", "Infrastructure"), new[] { "InfrastructureTVItemID" });
                    }
                }
            }

            if (spill.StartDateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "StartDateTime_Local"), new[] { "StartDateTime_Local" });
            }
            else
            {
                if (spill.StartDateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_Local", "1980"), new[] { "StartDateTime_Local" });
                }
            }

            if (spill.EndDateTime_Local != null && ((DateTime)spill.EndDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_Local", "1980"), new[] { "EndDateTime_Local" });
            }

            if (spill.StartDateTime_Local > spill.EndDateTime_Local)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._DateIsBiggerThan_, "EndDateTime_Local", "SpillStartDateTime_Local"), new[] { "EndDateTime_Local" });
            }

            if (spill.AverageFlow_m3_day < 0 || spill.AverageFlow_m3_day > 1000000)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "AverageFlow_m3_day", "0", "1000000"), new[] { "AverageFlow_m3_day" });
            }

            if (spill.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (spill.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == spill.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == spill.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == spill.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", spill.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
