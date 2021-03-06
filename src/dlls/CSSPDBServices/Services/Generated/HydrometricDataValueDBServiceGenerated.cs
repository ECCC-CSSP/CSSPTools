/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPDBServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
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
using LoggedInServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBServices
{
    public partial interface IHydrometricDataValueDBService
    {
        Task<ActionResult<bool>> Delete(int HydrometricDataValueID);
        Task<ActionResult<List<HydrometricDataValue>>> GetHydrometricDataValueList(int skip = 0, int take = 100);
        Task<ActionResult<HydrometricDataValue>> GetHydrometricDataValueWithHydrometricDataValueID(int HydrometricDataValueID);
        Task<ActionResult<HydrometricDataValue>> Post(HydrometricDataValue hydrometricdatavalue);
        Task<ActionResult<HydrometricDataValue>> Put(HydrometricDataValue hydrometricdatavalue);
    }
    public partial class HydrometricDataValueDBService : ControllerBase, IHydrometricDataValueDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResultList { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricDataValueDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;

            ValidationResultList = new List<ValidationResult>();
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<HydrometricDataValue>> GetHydrometricDataValueWithHydrometricDataValueID(int HydrometricDataValueID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            HydrometricDataValue hydrometricDataValue = (from c in db.HydrometricDataValues.AsNoTracking()
                    where c.HydrometricDataValueID == HydrometricDataValueID
                    select c).FirstOrDefault();

            if (hydrometricDataValue == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(hydrometricDataValue));
        }
        public async Task<ActionResult<List<HydrometricDataValue>>> GetHydrometricDataValueList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<HydrometricDataValue> hydrometricDataValueList = (from c in db.HydrometricDataValues.AsNoTracking() orderby c.HydrometricDataValueID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(hydrometricDataValueList));
        }
        public async Task<ActionResult<bool>> Delete(int HydrometricDataValueID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

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
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<HydrometricDataValue>> Post(HydrometricDataValue hydrometricDataValue)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(hydrometricDataValue), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.HydrometricDataValues.Add(hydrometricDataValue);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(hydrometricDataValue));
        }
        public async Task<ActionResult<HydrometricDataValue>> Put(HydrometricDataValue hydrometricDataValue)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(hydrometricDataValue), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.HydrometricDataValues.Update(hydrometricDataValue);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(hydrometricDataValue));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            HydrometricDataValue hydrometricDataValue = validationContext.ObjectInstance as HydrometricDataValue;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (hydrometricDataValue.HydrometricDataValueID == 0)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "HydrometricDataValueID"), new[] { nameof(hydrometricDataValue.HydrometricDataValueID) }));
                }

                if (!(from c in db.HydrometricDataValues.AsNoTracking() select c).Where(c => c.HydrometricDataValueID == hydrometricDataValue.HydrometricDataValueID).Any())
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", hydrometricDataValue.HydrometricDataValueID.ToString()), new[] { nameof(hydrometricDataValue.HydrometricDataValueID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)hydrometricDataValue.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(hydrometricDataValue.DBCommand) }));
            }

            HydrometricSite HydrometricSiteHydrometricSiteID = null;
            HydrometricSiteHydrometricSiteID = (from c in db.HydrometricSites.AsNoTracking() where c.HydrometricSiteID == hydrometricDataValue.HydrometricSiteID select c).FirstOrDefault();

            if (HydrometricSiteHydrometricSiteID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricSiteID", hydrometricDataValue.HydrometricSiteID.ToString()), new[] { nameof(hydrometricDataValue.HydrometricSiteID)}));
            }

            if (hydrometricDataValue.DateTime_Local.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DateTime_Local"), new[] { nameof(hydrometricDataValue.DateTime_Local) }));
            }
            else
            {
                if (hydrometricDataValue.DateTime_Local.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DateTime_Local", "1980"), new[] { nameof(hydrometricDataValue.DateTime_Local) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(StorageDataTypeEnum), (int?)hydrometricDataValue.StorageDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "StorageDataType"), new[] { nameof(hydrometricDataValue.StorageDataType) }));
            }

            if (hydrometricDataValue.Discharge_m3_s != null)
            {
                if (hydrometricDataValue.Discharge_m3_s < 0 || hydrometricDataValue.Discharge_m3_s > 100000)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Discharge_m3_s", "0", "100000"), new[] { nameof(hydrometricDataValue.Discharge_m3_s) }));
                }
            }

            if (hydrometricDataValue.DischargeEntered_m3_s != null)
            {
                if (hydrometricDataValue.DischargeEntered_m3_s < 0 || hydrometricDataValue.DischargeEntered_m3_s > 100000)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DischargeEntered_m3_s", "0", "100000"), new[] { nameof(hydrometricDataValue.DischargeEntered_m3_s) }));
                }
            }

            if (hydrometricDataValue.Level_m != null)
            {
                if (hydrometricDataValue.Level_m < 0 || hydrometricDataValue.Level_m > 10000)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Level_m", "0", "10000"), new[] { nameof(hydrometricDataValue.Level_m) }));
                }
            }

            //HourlyValues has no StringLength Attribute

            if (hydrometricDataValue.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(hydrometricDataValue.LastUpdateDate_UTC) }));
            }
            else
            {
                if (hydrometricDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(hydrometricDataValue.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == hydrometricDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", hydrometricDataValue.LastUpdateContactTVItemID.ToString()), new[] { nameof(hydrometricDataValue.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(hydrometricDataValue.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResultList.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
