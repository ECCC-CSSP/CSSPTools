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
   public partial interface IHydrometricDataValueService
    {
       Task<ActionResult<bool>> Delete(int HydrometricDataValueID);
       Task<ActionResult<List<HydrometricDataValue>>> GetHydrometricDataValueList(int skip = 0, int take = 100);
       Task<ActionResult<HydrometricDataValue>> GetHydrometricDataValueWithHydrometricDataValueID(int HydrometricDataValueID);
       Task<ActionResult<HydrometricDataValue>> Post(HydrometricDataValue hydrometricdatavalue);
       Task<ActionResult<HydrometricDataValue>> Put(HydrometricDataValue hydrometricdatavalue);
    }
    public partial class HydrometricDataValueService : ControllerBase, IHydrometricDataValueService
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
        public HydrometricDataValueService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal = null, CSSPDBInMemoryContext dbIM = null)
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
        public async Task<ActionResult<HydrometricDataValue>> GetHydrometricDataValueWithHydrometricDataValueID(int HydrometricDataValueID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                HydrometricDataValue hydrometricDataValue = (from c in dbIM.HydrometricDataValues.AsNoTracking()
                                   where c.HydrometricDataValueID == HydrometricDataValueID
                                   select c).FirstOrDefault();

                if (hydrometricDataValue == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(hydrometricDataValue));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                HydrometricDataValue hydrometricDataValue = (from c in dbLocal.HydrometricDataValues.AsNoTracking()
                        where c.HydrometricDataValueID == HydrometricDataValueID
                        select c).FirstOrDefault();

                if (hydrometricDataValue == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(hydrometricDataValue));
            }
            else
            {
                HydrometricDataValue hydrometricDataValue = (from c in db.HydrometricDataValues.AsNoTracking()
                        where c.HydrometricDataValueID == HydrometricDataValueID
                        select c).FirstOrDefault();

                if (hydrometricDataValue == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(hydrometricDataValue));
            }
        }
        public async Task<ActionResult<List<HydrometricDataValue>>> GetHydrometricDataValueList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<HydrometricDataValue> hydrometricDataValueList = (from c in dbIM.HydrometricDataValues.AsNoTracking() orderby c.HydrometricDataValueID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(hydrometricDataValueList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<HydrometricDataValue> hydrometricDataValueList = (from c in dbLocal.HydrometricDataValues.AsNoTracking() orderby c.HydrometricDataValueID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(hydrometricDataValueList));
            }
            else
            {
                List<HydrometricDataValue> hydrometricDataValueList = (from c in db.HydrometricDataValues.AsNoTracking() orderby c.HydrometricDataValueID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(hydrometricDataValueList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int HydrometricDataValueID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                HydrometricDataValue hydrometricDataValue = (from c in dbIM.HydrometricDataValues
                                   where c.HydrometricDataValueID == HydrometricDataValueID
                                   select c).FirstOrDefault();
            
                if (hydrometricDataValue == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", HydrometricDataValueID.ToString())));
                }
            
                try
                {
                    dbIM.HydrometricDataValues.Remove(hydrometricDataValue);
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
                HydrometricDataValue hydrometricDataValue = (from c in dbLocal.HydrometricDataValues
                                   where c.HydrometricDataValueID == HydrometricDataValueID
                                   select c).FirstOrDefault();
                
                if (hydrometricDataValue == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", HydrometricDataValueID.ToString())));
                }

                try
                {
                   dbLocal.HydrometricDataValues.Remove(hydrometricDataValue);
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
                HydrometricDataValue hydrometricDataValue = (from c in db.HydrometricDataValues
                                   where c.HydrometricDataValueID == HydrometricDataValueID
                                   select c).FirstOrDefault();
                
                if (hydrometricDataValue == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", HydrometricDataValueID.ToString())));
                }

                try
                {
                   db.HydrometricDataValues.Remove(hydrometricDataValue);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<HydrometricDataValue>> Post(HydrometricDataValue hydrometricDataValue)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(hydrometricDataValue), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.HydrometricDataValues.Add(hydrometricDataValue);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(hydrometricDataValue));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.HydrometricDataValues.Add(hydrometricDataValue);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(hydrometricDataValue));
            }
            else
            {
                try
                {
                   db.HydrometricDataValues.Add(hydrometricDataValue);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(hydrometricDataValue));
            }
        }
        public async Task<ActionResult<HydrometricDataValue>> Put(HydrometricDataValue hydrometricDataValue)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(hydrometricDataValue), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.HydrometricDataValues.Update(hydrometricDataValue);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(hydrometricDataValue));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.HydrometricDataValues.Update(hydrometricDataValue);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(hydrometricDataValue));
            }
            else
            {
            try
            {
               db.HydrometricDataValues.Update(hydrometricDataValue);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(hydrometricDataValue));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            HydrometricDataValue hydrometricDataValue = validationContext.ObjectInstance as HydrometricDataValue;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (hydrometricDataValue.HydrometricDataValueID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "HydrometricDataValueID"), new[] { nameof(hydrometricDataValue.HydrometricDataValueID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.HydrometricDataValues select c).Where(c => c.HydrometricDataValueID == hydrometricDataValue.HydrometricDataValueID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", hydrometricDataValue.HydrometricDataValueID.ToString()), new[] { nameof(hydrometricDataValue.HydrometricDataValueID) });
                    }
                }
                else
                {
                    if (!(from c in db.HydrometricDataValues select c).Where(c => c.HydrometricDataValueID == hydrometricDataValue.HydrometricDataValueID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", hydrometricDataValue.HydrometricDataValueID.ToString()), new[] { nameof(hydrometricDataValue.HydrometricDataValueID) });
                    }
                }
            }

            HydrometricSite HydrometricSiteHydrometricSiteID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                HydrometricSiteHydrometricSiteID = (from c in dbLocal.HydrometricSites where c.HydrometricSiteID == hydrometricDataValue.HydrometricSiteID select c).FirstOrDefault();
                if (HydrometricSiteHydrometricSiteID == null)
                {
                    HydrometricSiteHydrometricSiteID = (from c in dbIM.HydrometricSites where c.HydrometricSiteID == hydrometricDataValue.HydrometricSiteID select c).FirstOrDefault();
                }
            }
            else
            {
                HydrometricSiteHydrometricSiteID = (from c in db.HydrometricSites where c.HydrometricSiteID == hydrometricDataValue.HydrometricSiteID select c).FirstOrDefault();
            }

            if (HydrometricSiteHydrometricSiteID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricSiteID", hydrometricDataValue.HydrometricSiteID.ToString()), new[] { nameof(hydrometricDataValue.HydrometricSiteID) });
            }

            if (hydrometricDataValue.DateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DateTime_Local"), new[] { nameof(hydrometricDataValue.DateTime_Local) });
            }
            else
            {
                if (hydrometricDataValue.DateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DateTime_Local", "1980"), new[] { nameof(hydrometricDataValue.DateTime_Local) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(StorageDataTypeEnum), (int?)hydrometricDataValue.StorageDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "StorageDataType"), new[] { nameof(hydrometricDataValue.StorageDataType) });
            }

            if (hydrometricDataValue.Discharge_m3_s != null)
            {
                if (hydrometricDataValue.Discharge_m3_s < 0 || hydrometricDataValue.Discharge_m3_s > 100000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Discharge_m3_s", "0", "100000"), new[] { nameof(hydrometricDataValue.Discharge_m3_s) });
                }
            }

            if (hydrometricDataValue.DischargeEntered_m3_s != null)
            {
                if (hydrometricDataValue.DischargeEntered_m3_s < 0 || hydrometricDataValue.DischargeEntered_m3_s > 100000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DischargeEntered_m3_s", "0", "100000"), new[] { nameof(hydrometricDataValue.DischargeEntered_m3_s) });
                }
            }

            if (hydrometricDataValue.Level_m != null)
            {
                if (hydrometricDataValue.Level_m < 0 || hydrometricDataValue.Level_m > 10000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Level_m", "0", "10000"), new[] { nameof(hydrometricDataValue.Level_m) });
                }
            }

            //HourlyValues has no StringLength Attribute

            if (hydrometricDataValue.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(hydrometricDataValue.LastUpdateDate_UTC) });
            }
            else
            {
                if (hydrometricDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(hydrometricDataValue.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == hydrometricDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == hydrometricDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == hydrometricDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", hydrometricDataValue.LastUpdateContactTVItemID.ToString()), new[] { nameof(hydrometricDataValue.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(hydrometricDataValue.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
