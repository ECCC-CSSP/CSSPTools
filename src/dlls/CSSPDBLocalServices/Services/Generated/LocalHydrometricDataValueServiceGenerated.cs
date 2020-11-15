/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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
using LocalServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBLocalServices
{
    public partial interface ILocalHydrometricDataValueDBService
    {
        Task<ActionResult<bool>> Delete(int LocalHydrometricDataValueID);
        Task<ActionResult<List<LocalHydrometricDataValue>>> GetLocalHydrometricDataValueList(int skip = 0, int take = 100);
        Task<ActionResult<LocalHydrometricDataValue>> GetLocalHydrometricDataValueWithHydrometricDataValueID(int HydrometricDataValueID);
        Task<ActionResult<LocalHydrometricDataValue>> Post(LocalHydrometricDataValue localhydrometricdatavalue);
        Task<ActionResult<LocalHydrometricDataValue>> Put(LocalHydrometricDataValue localhydrometricdatavalue);
    }
    public partial class LocalHydrometricDataValueDBService : ControllerBase, ILocalHydrometricDataValueDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LocalHydrometricDataValueDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<LocalHydrometricDataValue>> GetLocalHydrometricDataValueWithHydrometricDataValueID(int HydrometricDataValueID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalHydrometricDataValue localHydrometricDataValue = (from c in db.LocalHydrometricDataValues.AsNoTracking()
                    where c.HydrometricDataValueID == HydrometricDataValueID
                    select c).FirstOrDefault();

            if (localHydrometricDataValue == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localHydrometricDataValue));
        }
        public async Task<ActionResult<List<LocalHydrometricDataValue>>> GetLocalHydrometricDataValueList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalHydrometricDataValue> localHydrometricDataValueList = (from c in db.LocalHydrometricDataValues.AsNoTracking() orderby c.HydrometricDataValueID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localHydrometricDataValueList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalHydrometricDataValueID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalHydrometricDataValue localHydrometricDataValue = (from c in db.LocalHydrometricDataValues
                    where c.HydrometricDataValueID == LocalHydrometricDataValueID
                    select c).FirstOrDefault();

            if (localHydrometricDataValue == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalHydrometricDataValue", "LocalHydrometricDataValueID", LocalHydrometricDataValueID.ToString())));
            }

            try
            {
                db.LocalHydrometricDataValues.Remove(localHydrometricDataValue);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalHydrometricDataValue>> Post(LocalHydrometricDataValue localHydrometricDataValue)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localHydrometricDataValue), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalHydrometricDataValues.Add(localHydrometricDataValue);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localHydrometricDataValue));
        }
        public async Task<ActionResult<LocalHydrometricDataValue>> Put(LocalHydrometricDataValue localHydrometricDataValue)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localHydrometricDataValue), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalHydrometricDataValues.Update(localHydrometricDataValue);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localHydrometricDataValue));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalHydrometricDataValue localHydrometricDataValue = validationContext.ObjectInstance as LocalHydrometricDataValue;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localHydrometricDataValue.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localHydrometricDataValue.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localHydrometricDataValue.HydrometricDataValueID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "HydrometricDataValueID"), new[] { nameof(localHydrometricDataValue.HydrometricDataValueID) });
                }

                if (!(from c in db.LocalHydrometricDataValues.AsNoTracking() select c).Where(c => c.HydrometricDataValueID == localHydrometricDataValue.HydrometricDataValueID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", localHydrometricDataValue.HydrometricDataValueID.ToString()), new[] { nameof(localHydrometricDataValue.HydrometricDataValueID) });
                }
            }

            LocalHydrometricSite localHydrometricSiteHydrometricSiteID = null;
            localHydrometricSiteHydrometricSiteID = (from c in db.LocalHydrometricSites.AsNoTracking() where c.HydrometricSiteID == localHydrometricDataValue.HydrometricSiteID select c).FirstOrDefault();

            if (localHydrometricSiteHydrometricSiteID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalHydrometricSite", "HydrometricSiteID", localHydrometricDataValue.HydrometricSiteID.ToString()), new[] { nameof(localHydrometricDataValue.HydrometricSiteID) });
            }

            if (localHydrometricDataValue.DateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DateTime_Local"), new[] { nameof(localHydrometricDataValue.DateTime_Local) });
            }
            else
            {
                if (localHydrometricDataValue.DateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DateTime_Local", "1980"), new[] { nameof(localHydrometricDataValue.DateTime_Local) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(StorageDataTypeEnum), (int?)localHydrometricDataValue.StorageDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "StorageDataType"), new[] { nameof(localHydrometricDataValue.StorageDataType) });
            }

            if (localHydrometricDataValue.Discharge_m3_s != null)
            {
                if (localHydrometricDataValue.Discharge_m3_s < 0 || localHydrometricDataValue.Discharge_m3_s > 100000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Discharge_m3_s", "0", "100000"), new[] { nameof(localHydrometricDataValue.Discharge_m3_s) });
                }
            }

            if (localHydrometricDataValue.DischargeEntered_m3_s != null)
            {
                if (localHydrometricDataValue.DischargeEntered_m3_s < 0 || localHydrometricDataValue.DischargeEntered_m3_s > 100000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DischargeEntered_m3_s", "0", "100000"), new[] { nameof(localHydrometricDataValue.DischargeEntered_m3_s) });
                }
            }

            if (localHydrometricDataValue.Level_m != null)
            {
                if (localHydrometricDataValue.Level_m < 0 || localHydrometricDataValue.Level_m > 10000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Level_m", "0", "10000"), new[] { nameof(localHydrometricDataValue.Level_m) });
                }
            }

            //HourlyValues has no StringLength Attribute

            if (localHydrometricDataValue.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localHydrometricDataValue.LastUpdateDate_UTC) });
            }
            else
            {
                if (localHydrometricDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localHydrometricDataValue.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localHydrometricDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localHydrometricDataValue.LastUpdateContactTVItemID.ToString()), new[] { nameof(localHydrometricDataValue.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localHydrometricDataValue.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}