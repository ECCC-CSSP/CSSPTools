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
    public partial interface ITideDataValueDBService
    {
        Task<ActionResult<bool>> Delete(int TideDataValueID);
        Task<ActionResult<List<TideDataValue>>> GetTideDataValueList(int skip = 0, int take = 100);
        Task<ActionResult<TideDataValue>> GetTideDataValueWithTideDataValueID(int TideDataValueID);
        Task<ActionResult<TideDataValue>> Post(TideDataValue tidedatavalue);
        Task<ActionResult<TideDataValue>> Put(TideDataValue tidedatavalue);
    }
    public partial class TideDataValueDBService : ControllerBase, ITideDataValueDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public TideDataValueDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<TideDataValue>> GetTideDataValueWithTideDataValueID(int TideDataValueID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TideDataValue tideDataValue = (from c in db.TideDataValues.AsNoTracking()
                    where c.TideDataValueID == TideDataValueID
                    select c).FirstOrDefault();

            if (tideDataValue == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(tideDataValue));
        }
        public async Task<ActionResult<List<TideDataValue>>> GetTideDataValueList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<TideDataValue> tideDataValueList = (from c in db.TideDataValues.AsNoTracking() orderby c.TideDataValueID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(tideDataValueList));
        }
        public async Task<ActionResult<bool>> Delete(int TideDataValueID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TideDataValue tideDataValue = (from c in db.TideDataValues
                    where c.TideDataValueID == TideDataValueID
                    select c).FirstOrDefault();

            if (tideDataValue == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TideDataValue", "TideDataValueID", TideDataValueID.ToString())));
            }

            try
            {
                db.TideDataValues.Remove(tideDataValue);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<TideDataValue>> Post(TideDataValue tideDataValue)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(tideDataValue), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.TideDataValues.Add(tideDataValue);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tideDataValue));
        }
        public async Task<ActionResult<TideDataValue>> Put(TideDataValue tideDataValue)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(tideDataValue), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.TideDataValues.Update(tideDataValue);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tideDataValue));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            TideDataValue tideDataValue = validationContext.ObjectInstance as TideDataValue;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tideDataValue.TideDataValueID == 0)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TideDataValueID"), new[] { nameof(tideDataValue.TideDataValueID) }));
                }

                if (!(from c in db.TideDataValues.AsNoTracking() select c).Where(c => c.TideDataValueID == tideDataValue.TideDataValueID).Any())
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TideDataValue", "TideDataValueID", tideDataValue.TideDataValueID.ToString()), new[] { nameof(tideDataValue.TideDataValueID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)tideDataValue.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(tideDataValue.DBCommand) }));
            }

            TVItem TVItemTideSiteTVItemID = null;
            TVItemTideSiteTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == tideDataValue.TideSiteTVItemID select c).FirstOrDefault();

            if (TVItemTideSiteTVItemID == null)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TideSiteTVItemID", tideDataValue.TideSiteTVItemID.ToString()), new[] { nameof(tideDataValue.TideSiteTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.TideSite,
                };
                if (!AllowableTVTypes.Contains(TVItemTideSiteTVItemID.TVType))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TideSiteTVItemID", "TideSite"), new[] { nameof(tideDataValue.TideSiteTVItemID) }));
                }
            }

            if (tideDataValue.DateTime_Local.Year == 1)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DateTime_Local"), new[] { nameof(tideDataValue.DateTime_Local) }));
            }
            else
            {
                if (tideDataValue.DateTime_Local.Year < 1980)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DateTime_Local", "1980"), new[] { nameof(tideDataValue.DateTime_Local) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(TideDataTypeEnum), (int?)tideDataValue.TideDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TideDataType"), new[] { nameof(tideDataValue.TideDataType) }));
            }

            retStr = enums.EnumTypeOK(typeof(StorageDataTypeEnum), (int?)tideDataValue.StorageDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "StorageDataType"), new[] { nameof(tideDataValue.StorageDataType) }));
            }

            if (tideDataValue.Depth_m < 0 || tideDataValue.Depth_m > 10000)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Depth_m", "0", "10000"), new[] { nameof(tideDataValue.Depth_m) }));
            }

            if (tideDataValue.UVelocity_m_s < 0 || tideDataValue.UVelocity_m_s > 10)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "UVelocity_m_s", "0", "10"), new[] { nameof(tideDataValue.UVelocity_m_s) }));
            }

            if (tideDataValue.VVelocity_m_s < 0 || tideDataValue.VVelocity_m_s > 10)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "VVelocity_m_s", "0", "10"), new[] { nameof(tideDataValue.VVelocity_m_s) }));
            }

            if (tideDataValue.TideStart != null)
            {
                retStr = enums.EnumTypeOK(typeof(TideTextEnum), (int?)tideDataValue.TideStart);
                if (tideDataValue.TideStart == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TideStart"), new[] { nameof(tideDataValue.TideStart) }));
                }
            }

            if (tideDataValue.TideEnd != null)
            {
                retStr = enums.EnumTypeOK(typeof(TideTextEnum), (int?)tideDataValue.TideEnd);
                if (tideDataValue.TideEnd == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TideEnd"), new[] { nameof(tideDataValue.TideEnd) }));
                }
            }

            if (tideDataValue.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(tideDataValue.LastUpdateDate_UTC) }));
            }
            else
            {
                if (tideDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(tideDataValue.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == tideDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tideDataValue.LastUpdateContactTVItemID.ToString()), new[] { nameof(tideDataValue.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(tideDataValue.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
