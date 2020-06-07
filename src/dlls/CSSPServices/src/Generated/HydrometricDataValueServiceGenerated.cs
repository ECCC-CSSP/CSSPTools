/*
 * Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
   public interface IHydrometricDataValueService
    {
       Task<ActionResult<HydrometricDataValue>> GetHydrometricDataValueWithHydrometricDataValueID(int HydrometricDataValueID);
       Task<ActionResult<List<HydrometricDataValue>>> GetHydrometricDataValueList();
       Task<ActionResult<HydrometricDataValue>> Add(HydrometricDataValue hydrometricdatavalue);
       Task<ActionResult<bool>> Delete(int HydrometricDataValueID);
       Task<ActionResult<HydrometricDataValue>> Update(HydrometricDataValue hydrometricdatavalue);
       Task SetCulture(CultureInfo culture);
    }
    public partial class HydrometricDataValueService : ControllerBase, IHydrometricDataValueService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricDataValueService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<HydrometricDataValue>> GetHydrometricDataValueWithHydrometricDataValueID(int HydrometricDataValueID)
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
        public async Task<ActionResult<List<HydrometricDataValue>>> GetHydrometricDataValueList()
        {
            List<HydrometricDataValue> hydrometricdatavalueList = (from c in db.HydrometricDataValues.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(hydrometricdatavalueList));
        }
        public async Task<ActionResult<HydrometricDataValue>> Add(HydrometricDataValue hydrometricDataValue)
        {
            ValidationResults = Validate(new ValidationContext(hydrometricDataValue), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

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
        public async Task<ActionResult<bool>> Delete(int HydrometricDataValueID)
        {
            HydrometricDataValue hydrometricDataValue = (from c in db.HydrometricDataValues
                               where c.HydrometricDataValueID == HydrometricDataValueID
                               select c).FirstOrDefault();
            
            if (hydrometricDataValue == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", HydrometricDataValueID.ToString())));
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
        public async Task<ActionResult<HydrometricDataValue>> Update(HydrometricDataValue hydrometricDataValue)
        {
            ValidationResults = Validate(new ValidationContext(hydrometricDataValue), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

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
        public async Task SetCulture(CultureInfo culture)
        {
            CSSPServicesRes.Culture = culture;
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "HydrometricDataValueID"), new[] { "HydrometricDataValueID" });
                }

                if (!(from c in db.HydrometricDataValues select c).Where(c => c.HydrometricDataValueID == hydrometricDataValue.HydrometricDataValueID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", hydrometricDataValue.HydrometricDataValueID.ToString()), new[] { "HydrometricDataValueID" });
                }
            }

            HydrometricSite HydrometricSiteHydrometricSiteID = (from c in db.HydrometricSites where c.HydrometricSiteID == hydrometricDataValue.HydrometricSiteID select c).FirstOrDefault();

            if (HydrometricSiteHydrometricSiteID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricSiteID", hydrometricDataValue.HydrometricSiteID.ToString()), new[] { "HydrometricSiteID" });
            }

            if (hydrometricDataValue.DateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DateTime_Local"), new[] { "DateTime_Local" });
            }
            else
            {
                if (hydrometricDataValue.DateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "DateTime_Local", "1980"), new[] { "DateTime_Local" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(StorageDataTypeEnum), (int?)hydrometricDataValue.StorageDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "StorageDataType"), new[] { "StorageDataType" });
            }

            if (hydrometricDataValue.Discharge_m3_s != null)
            {
                if (hydrometricDataValue.Discharge_m3_s < 0 || hydrometricDataValue.Discharge_m3_s > 100000)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Discharge_m3_s", "0", "100000"), new[] { "Discharge_m3_s" });
                }
            }

            if (hydrometricDataValue.DischargeEntered_m3_s != null)
            {
                if (hydrometricDataValue.DischargeEntered_m3_s < 0 || hydrometricDataValue.DischargeEntered_m3_s > 100000)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DischargeEntered_m3_s", "0", "100000"), new[] { "DischargeEntered_m3_s" });
                }
            }

            if (hydrometricDataValue.Level_m != null)
            {
                if (hydrometricDataValue.Level_m < 0 || hydrometricDataValue.Level_m > 10000)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Level_m", "0", "10000"), new[] { "Level_m" });
                }
            }

            //HourlyValues has no StringLength Attribute

            if (hydrometricDataValue.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (hydrometricDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == hydrometricDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", hydrometricDataValue.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
