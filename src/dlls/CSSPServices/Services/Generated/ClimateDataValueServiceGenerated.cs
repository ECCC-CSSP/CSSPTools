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
   public partial interface IClimateDataValueService
    {
       Task<ActionResult<bool>> Delete(int ClimateDataValueID);
       Task<ActionResult<List<ClimateDataValue>>> GetClimateDataValueList(int skip = 0, int take = 100);
       Task<ActionResult<ClimateDataValue>> GetClimateDataValueWithClimateDataValueID(int ClimateDataValueID);
       Task<ActionResult<ClimateDataValue>> Post(ClimateDataValue climatedatavalue);
       Task<ActionResult<ClimateDataValue>> Put(ClimateDataValue climatedatavalue);
    }
    public partial class ClimateDataValueService : ControllerBase, IClimateDataValueService
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
        public ClimateDataValueService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, CSSPDBInMemoryContext dbIM)
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
        public async Task<ActionResult<ClimateDataValue>> GetClimateDataValueWithClimateDataValueID(int ClimateDataValueID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                ClimateDataValue climateDataValue = (from c in dbIM.ClimateDataValues.AsNoTracking()
                                   where c.ClimateDataValueID == ClimateDataValueID
                                   select c).FirstOrDefault();

                if (climateDataValue == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(climateDataValue));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                ClimateDataValue climateDataValue = (from c in dbLocal.ClimateDataValues.AsNoTracking()
                        where c.ClimateDataValueID == ClimateDataValueID
                        select c).FirstOrDefault();

                if (climateDataValue == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(climateDataValue));
            }
            else
            {
                ClimateDataValue climateDataValue = (from c in db.ClimateDataValues.AsNoTracking()
                        where c.ClimateDataValueID == ClimateDataValueID
                        select c).FirstOrDefault();

                if (climateDataValue == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(climateDataValue));
            }
        }
        public async Task<ActionResult<List<ClimateDataValue>>> GetClimateDataValueList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<ClimateDataValue> climateDataValueList = (from c in dbIM.ClimateDataValues.AsNoTracking() orderby c.ClimateDataValueID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(climateDataValueList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<ClimateDataValue> climateDataValueList = (from c in dbLocal.ClimateDataValues.AsNoTracking() orderby c.ClimateDataValueID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(climateDataValueList));
            }
            else
            {
                List<ClimateDataValue> climateDataValueList = (from c in db.ClimateDataValues.AsNoTracking() orderby c.ClimateDataValueID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(climateDataValueList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int ClimateDataValueID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                ClimateDataValue climateDataValue = (from c in dbIM.ClimateDataValues
                                   where c.ClimateDataValueID == ClimateDataValueID
                                   select c).FirstOrDefault();
            
                if (climateDataValue == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ClimateDataValue", "ClimateDataValueID", ClimateDataValueID.ToString())));
                }
            
                try
                {
                    dbIM.ClimateDataValues.Remove(climateDataValue);
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
                ClimateDataValue climateDataValue = (from c in dbLocal.ClimateDataValues
                                   where c.ClimateDataValueID == ClimateDataValueID
                                   select c).FirstOrDefault();
                
                if (climateDataValue == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ClimateDataValue", "ClimateDataValueID", ClimateDataValueID.ToString())));
                }

                try
                {
                   dbLocal.ClimateDataValues.Remove(climateDataValue);
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
                ClimateDataValue climateDataValue = (from c in db.ClimateDataValues
                                   where c.ClimateDataValueID == ClimateDataValueID
                                   select c).FirstOrDefault();
                
                if (climateDataValue == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ClimateDataValue", "ClimateDataValueID", ClimateDataValueID.ToString())));
                }

                try
                {
                   db.ClimateDataValues.Remove(climateDataValue);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<ClimateDataValue>> Post(ClimateDataValue climateDataValue)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(climateDataValue), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.ClimateDataValues.Add(climateDataValue);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(climateDataValue));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.ClimateDataValues.Add(climateDataValue);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(climateDataValue));
            }
            else
            {
                try
                {
                   db.ClimateDataValues.Add(climateDataValue);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(climateDataValue));
            }
        }
        public async Task<ActionResult<ClimateDataValue>> Put(ClimateDataValue climateDataValue)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(climateDataValue), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.ClimateDataValues.Update(climateDataValue);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(climateDataValue));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.ClimateDataValues.Update(climateDataValue);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(climateDataValue));
            }
            else
            {
            try
            {
               db.ClimateDataValues.Update(climateDataValue);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(climateDataValue));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            ClimateDataValue climateDataValue = validationContext.ObjectInstance as ClimateDataValue;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (climateDataValue.ClimateDataValueID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ClimateDataValueID"), new[] { nameof(climateDataValue.ClimateDataValueID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.ClimateDataValues select c).Where(c => c.ClimateDataValueID == climateDataValue.ClimateDataValueID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ClimateDataValue", "ClimateDataValueID", climateDataValue.ClimateDataValueID.ToString()), new[] { nameof(climateDataValue.ClimateDataValueID) });
                    }
                }
                else
                {
                    if (!(from c in db.ClimateDataValues select c).Where(c => c.ClimateDataValueID == climateDataValue.ClimateDataValueID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ClimateDataValue", "ClimateDataValueID", climateDataValue.ClimateDataValueID.ToString()), new[] { nameof(climateDataValue.ClimateDataValueID) });
                    }
                }
            }

            ClimateSite ClimateSiteClimateSiteID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                ClimateSiteClimateSiteID = (from c in dbLocal.ClimateSites where c.ClimateSiteID == climateDataValue.ClimateSiteID select c).FirstOrDefault();
                if (ClimateSiteClimateSiteID == null)
                {
                    ClimateSiteClimateSiteID = (from c in dbIM.ClimateSites where c.ClimateSiteID == climateDataValue.ClimateSiteID select c).FirstOrDefault();
                }
            }
            else
            {
                ClimateSiteClimateSiteID = (from c in db.ClimateSites where c.ClimateSiteID == climateDataValue.ClimateSiteID select c).FirstOrDefault();
            }

            if (ClimateSiteClimateSiteID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ClimateSite", "ClimateSiteID", climateDataValue.ClimateSiteID.ToString()), new[] { nameof(climateDataValue.ClimateSiteID) });
            }

            if (climateDataValue.DateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DateTime_Local"), new[] { nameof(climateDataValue.DateTime_Local) });
            }
            else
            {
                if (climateDataValue.DateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DateTime_Local", "1980"), new[] { nameof(climateDataValue.DateTime_Local) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(StorageDataTypeEnum), (int?)climateDataValue.StorageDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "StorageDataType"), new[] { nameof(climateDataValue.StorageDataType) });
            }

            if (climateDataValue.Snow_cm != null)
            {
                if (climateDataValue.Snow_cm < 0 || climateDataValue.Snow_cm > 10000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Snow_cm", "0", "10000"), new[] { nameof(climateDataValue.Snow_cm) });
                }
            }

            if (climateDataValue.Rainfall_mm != null)
            {
                if (climateDataValue.Rainfall_mm < 0 || climateDataValue.Rainfall_mm > 10000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Rainfall_mm", "0", "10000"), new[] { nameof(climateDataValue.Rainfall_mm) });
                }
            }

            if (climateDataValue.RainfallEntered_mm != null)
            {
                if (climateDataValue.RainfallEntered_mm < 0 || climateDataValue.RainfallEntered_mm > 10000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RainfallEntered_mm", "0", "10000"), new[] { nameof(climateDataValue.RainfallEntered_mm) });
                }
            }

            if (climateDataValue.TotalPrecip_mm_cm != null)
            {
                if (climateDataValue.TotalPrecip_mm_cm < 0 || climateDataValue.TotalPrecip_mm_cm > 10000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TotalPrecip_mm_cm", "0", "10000"), new[] { nameof(climateDataValue.TotalPrecip_mm_cm) });
                }
            }

            if (climateDataValue.MaxTemp_C != null)
            {
                if (climateDataValue.MaxTemp_C < -50 || climateDataValue.MaxTemp_C > 50)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MaxTemp_C", "-50", "50"), new[] { nameof(climateDataValue.MaxTemp_C) });
                }
            }

            if (climateDataValue.MinTemp_C != null)
            {
                if (climateDataValue.MinTemp_C < -50 || climateDataValue.MinTemp_C > 50)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MinTemp_C", "-50", "50"), new[] { nameof(climateDataValue.MinTemp_C) });
                }
            }

            if (climateDataValue.HeatDegDays_C != null)
            {
                if (climateDataValue.HeatDegDays_C < -1000 || climateDataValue.HeatDegDays_C > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "HeatDegDays_C", "-1000", "100"), new[] { nameof(climateDataValue.HeatDegDays_C) });
                }
            }

            if (climateDataValue.CoolDegDays_C != null)
            {
                if (climateDataValue.CoolDegDays_C < -1000 || climateDataValue.CoolDegDays_C > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "CoolDegDays_C", "-1000", "100"), new[] { nameof(climateDataValue.CoolDegDays_C) });
                }
            }

            if (climateDataValue.SnowOnGround_cm != null)
            {
                if (climateDataValue.SnowOnGround_cm < 0 || climateDataValue.SnowOnGround_cm > 10000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SnowOnGround_cm", "0", "10000"), new[] { nameof(climateDataValue.SnowOnGround_cm) });
                }
            }

            if (climateDataValue.DirMaxGust_0North != null)
            {
                if (climateDataValue.DirMaxGust_0North < 0 || climateDataValue.DirMaxGust_0North > 360)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DirMaxGust_0North", "0", "360"), new[] { nameof(climateDataValue.DirMaxGust_0North) });
                }
            }

            if (climateDataValue.SpdMaxGust_kmh != null)
            {
                if (climateDataValue.SpdMaxGust_kmh < 0 || climateDataValue.SpdMaxGust_kmh > 300)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SpdMaxGust_kmh", "0", "300"), new[] { nameof(climateDataValue.SpdMaxGust_kmh) });
                }
            }

            //HourlyValues has no StringLength Attribute

            if (climateDataValue.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(climateDataValue.LastUpdateDate_UTC) });
            }
            else
            {
                if (climateDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(climateDataValue.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == climateDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == climateDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == climateDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", climateDataValue.LastUpdateContactTVItemID.ToString()), new[] { nameof(climateDataValue.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(climateDataValue.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
