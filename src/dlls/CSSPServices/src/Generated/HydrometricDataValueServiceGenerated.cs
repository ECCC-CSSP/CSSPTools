/*
 * Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
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
   public interface IHydrometricDataValueService
    {
       Task<ActionResult<bool>> Delete(int HydrometricDataValueID);
       Task<ActionResult<List<HydrometricDataValue>>> GetHydrometricDataValueList();
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
        private InMemoryDBContext dbIM { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricDataValueService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<HydrometricDataValue>> GetHydrometricDataValueWithHydrometricDataValueID(int HydrometricDataValueID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                HydrometricDataValue hydrometricdatavalue = (from c in dbLocal.HydrometricDataValues.AsNoTracking()
                        where c.HydrometricDataValueID == HydrometricDataValueID
                        select c).FirstOrDefault();

                if (hydrometricdatavalue == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(hydrometricdatavalue));
            }
            else
            {
                HydrometricDataValue hydrometricdatavalue = (from c in db.HydrometricDataValues.AsNoTracking()
                        where c.HydrometricDataValueID == HydrometricDataValueID
                        select c).FirstOrDefault();

                if (hydrometricdatavalue == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(hydrometricdatavalue));
            }
        }
        public async Task<ActionResult<List<HydrometricDataValue>>> GetHydrometricDataValueList()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                List<HydrometricDataValue> hydrometricdatavalueList = (from c in dbLocal.HydrometricDataValues.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(hydrometricdatavalueList));
            }
            else
            {
                List<HydrometricDataValue> hydrometricdatavalueList = (from c in db.HydrometricDataValues.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(hydrometricdatavalueList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int HydrometricDataValueID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                HydrometricDataValue hydrometricDataValue = (from c in dbLocal.HydrometricDataValues
                                   where c.HydrometricDataValueID == HydrometricDataValueID
                                   select c).FirstOrDefault();
                
                if (hydrometricDataValue == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", HydrometricDataValueID.ToString())));
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
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", HydrometricDataValueID.ToString())));
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

            if (LoggedInService.IsLocal)
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

            if (LoggedInService.IsLocal)
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
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "HydrometricDataValueID"), new[] { "HydrometricDataValueID" });
                }

                if (LoggedInService.IsLocal)
                {
                    if (!(from c in dbLocal.HydrometricDataValues select c).Where(c => c.HydrometricDataValueID == hydrometricDataValue.HydrometricDataValueID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", hydrometricDataValue.HydrometricDataValueID.ToString()), new[] { "HydrometricDataValueID" });
                    }
                }
                else
                {
                    if (!(from c in db.HydrometricDataValues select c).Where(c => c.HydrometricDataValueID == hydrometricDataValue.HydrometricDataValueID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", hydrometricDataValue.HydrometricDataValueID.ToString()), new[] { "HydrometricDataValueID" });
                    }
                }
            }

            HydrometricSite HydrometricSiteHydrometricSiteID = null;
            if (LoggedInService.IsLocal)
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
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricSiteID", hydrometricDataValue.HydrometricSiteID.ToString()), new[] { "HydrometricSiteID" });
            }

            if (hydrometricDataValue.DateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "DateTime_Local"), new[] { "DateTime_Local" });
            }
            else
            {
                if (hydrometricDataValue.DateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "DateTime_Local", "1980"), new[] { "DateTime_Local" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(StorageDataTypeEnum), (int?)hydrometricDataValue.StorageDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "StorageDataType"), new[] { "StorageDataType" });
            }

            if (hydrometricDataValue.Discharge_m3_s != null)
            {
                if (hydrometricDataValue.Discharge_m3_s < 0 || hydrometricDataValue.Discharge_m3_s > 100000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Discharge_m3_s", "0", "100000"), new[] { "Discharge_m3_s" });
                }
            }

            if (hydrometricDataValue.DischargeEntered_m3_s != null)
            {
                if (hydrometricDataValue.DischargeEntered_m3_s < 0 || hydrometricDataValue.DischargeEntered_m3_s > 100000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "DischargeEntered_m3_s", "0", "100000"), new[] { "DischargeEntered_m3_s" });
                }
            }

            if (hydrometricDataValue.Level_m != null)
            {
                if (hydrometricDataValue.Level_m < 0 || hydrometricDataValue.Level_m > 10000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Level_m", "0", "10000"), new[] { "Level_m" });
                }
            }

            //HourlyValues has no StringLength Attribute

            if (hydrometricDataValue.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (hydrometricDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.IsLocal)
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
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", hydrometricDataValue.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
