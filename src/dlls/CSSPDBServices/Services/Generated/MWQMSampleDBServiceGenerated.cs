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
    public partial interface IMWQMSampleDBService
    {
        Task<ActionResult<bool>> Delete(int MWQMSampleID);
        Task<ActionResult<List<MWQMSample>>> GetMWQMSampleList(int skip = 0, int take = 100);
        Task<ActionResult<MWQMSample>> GetMWQMSampleWithMWQMSampleID(int MWQMSampleID);
        Task<ActionResult<MWQMSample>> Post(MWQMSample mwqmsample);
        Task<ActionResult<MWQMSample>> Put(MWQMSample mwqmsample);
    }
    public partial class MWQMSampleDBService : ControllerBase, IMWQMSampleDBService
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
        public MWQMSampleDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<MWQMSample>> GetMWQMSampleWithMWQMSampleID(int MWQMSampleID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            MWQMSample mwqmSample = (from c in db.MWQMSamples.AsNoTracking()
                    where c.MWQMSampleID == MWQMSampleID
                    select c).FirstOrDefault();

            if (mwqmSample == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(mwqmSample));
        }
        public async Task<ActionResult<List<MWQMSample>>> GetMWQMSampleList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<MWQMSample> mwqmSampleList = (from c in db.MWQMSamples.AsNoTracking() orderby c.MWQMSampleID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(mwqmSampleList));
        }
        public async Task<ActionResult<bool>> Delete(int MWQMSampleID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            MWQMSample mwqmSample = (from c in db.MWQMSamples
                    where c.MWQMSampleID == MWQMSampleID
                    select c).FirstOrDefault();

            if (mwqmSample == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSample", "MWQMSampleID", MWQMSampleID.ToString())));
            }

            try
            {
                db.MWQMSamples.Remove(mwqmSample);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<MWQMSample>> Post(MWQMSample mwqmSample)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(mwqmSample), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.MWQMSamples.Add(mwqmSample);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSample));
        }
        public async Task<ActionResult<MWQMSample>> Put(MWQMSample mwqmSample)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(mwqmSample), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.MWQMSamples.Update(mwqmSample);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSample));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MWQMSample mwqmSample = validationContext.ObjectInstance as MWQMSample;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSample.MWQMSampleID == 0)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMSampleID"), new[] { nameof(mwqmSample.MWQMSampleID) }));
                }

                if (!(from c in db.MWQMSamples.AsNoTracking() select c).Where(c => c.MWQMSampleID == mwqmSample.MWQMSampleID).Any())
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSample", "MWQMSampleID", mwqmSample.MWQMSampleID.ToString()), new[] { nameof(mwqmSample.MWQMSampleID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)mwqmSample.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(mwqmSample.DBCommand) }));
            }

            TVItem TVItemMWQMSiteTVItemID = null;
            TVItemMWQMSiteTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == mwqmSample.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteTVItemID", mwqmSample.MWQMSiteTVItemID.ToString()), new[] { nameof(mwqmSample.MWQMSiteTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MWQMSiteTVItemID", "MWQMSite"), new[] { nameof(mwqmSample.MWQMSiteTVItemID) }));
                }
            }

            TVItem TVItemMWQMRunTVItemID = null;
            TVItemMWQMRunTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == mwqmSample.MWQMRunTVItemID select c).FirstOrDefault();

            if (TVItemMWQMRunTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMRunTVItemID", mwqmSample.MWQMRunTVItemID.ToString()), new[] { nameof(mwqmSample.MWQMRunTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMRun,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMRunTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MWQMRunTVItemID", "MWQMRun"), new[] { nameof(mwqmSample.MWQMRunTVItemID) }));
                }
            }

            if (mwqmSample.SampleDateTime_Local.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SampleDateTime_Local"), new[] { nameof(mwqmSample.SampleDateTime_Local) }));
            }
            else
            {
                if (mwqmSample.SampleDateTime_Local.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "SampleDateTime_Local", "1980"), new[] { nameof(mwqmSample.SampleDateTime_Local) }));
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmSample.TimeText) && mwqmSample.TimeText.Length > 6)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TimeText", "6"), new[] { nameof(mwqmSample.TimeText) }));
            }

            if (mwqmSample.Depth_m != null)
            {
                if (mwqmSample.Depth_m < 0 || mwqmSample.Depth_m > 1000)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Depth_m", "0", "1000"), new[] { nameof(mwqmSample.Depth_m) }));
                }
            }

            if (mwqmSample.FecCol_MPN_100ml < 0 || mwqmSample.FecCol_MPN_100ml > 10000000)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "FecCol_MPN_100ml", "0", "10000000"), new[] { nameof(mwqmSample.FecCol_MPN_100ml) }));
            }

            if (mwqmSample.Salinity_PPT != null)
            {
                if (mwqmSample.Salinity_PPT < 0 || mwqmSample.Salinity_PPT > 40)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Salinity_PPT", "0", "40"), new[] { nameof(mwqmSample.Salinity_PPT) }));
                }
            }

            if (mwqmSample.WaterTemp_C != null)
            {
                if (mwqmSample.WaterTemp_C < -10 || mwqmSample.WaterTemp_C > 40)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "WaterTemp_C", "-10", "40"), new[] { nameof(mwqmSample.WaterTemp_C) }));
                }
            }

            if (mwqmSample.PH != null)
            {
                if (mwqmSample.PH < 0 || mwqmSample.PH > 14)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "PH", "0", "14"), new[] { nameof(mwqmSample.PH) }));
                }
            }

            if (string.IsNullOrWhiteSpace(mwqmSample.SampleTypesText))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SampleTypesText"), new[] { nameof(mwqmSample.SampleTypesText) }));
            }

            if (!string.IsNullOrWhiteSpace(mwqmSample.SampleTypesText) && mwqmSample.SampleTypesText.Length > 50)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SampleTypesText", "50"), new[] { nameof(mwqmSample.SampleTypesText) }));
            }

            if (mwqmSample.SampleType_old != null)
            {
                retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)mwqmSample.SampleType_old);
                if (mwqmSample.SampleType_old == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SampleType_old"), new[] { nameof(mwqmSample.SampleType_old) }));
                }
            }

            if (mwqmSample.Tube_10 != null)
            {
                if (mwqmSample.Tube_10 < 0 || mwqmSample.Tube_10 > 5)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tube_10", "0", "5"), new[] { nameof(mwqmSample.Tube_10) }));
                }
            }

            if (mwqmSample.Tube_1_0 != null)
            {
                if (mwqmSample.Tube_1_0 < 0 || mwqmSample.Tube_1_0 > 5)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tube_1_0", "0", "5"), new[] { nameof(mwqmSample.Tube_1_0) }));
                }
            }

            if (mwqmSample.Tube_0_1 != null)
            {
                if (mwqmSample.Tube_0_1 < 0 || mwqmSample.Tube_0_1 > 5)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tube_0_1", "0", "5"), new[] { nameof(mwqmSample.Tube_0_1) }));
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmSample.ProcessedBy) && mwqmSample.ProcessedBy.Length > 10)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ProcessedBy", "10"), new[] { nameof(mwqmSample.ProcessedBy) }));
            }

            if (mwqmSample.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mwqmSample.LastUpdateDate_UTC) }));
            }
            else
            {
                if (mwqmSample.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mwqmSample.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == mwqmSample.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmSample.LastUpdateContactTVItemID.ToString()), new[] { nameof(mwqmSample.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mwqmSample.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResultList.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
