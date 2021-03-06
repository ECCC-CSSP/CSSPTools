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
    public partial interface IBoxModelDBService
    {
        Task<ActionResult<bool>> Delete(int BoxModelID);
        Task<ActionResult<List<BoxModel>>> GetBoxModelList(int skip = 0, int take = 100);
        Task<ActionResult<BoxModel>> GetBoxModelWithBoxModelID(int BoxModelID);
        Task<ActionResult<BoxModel>> Post(BoxModel boxmodel);
        Task<ActionResult<BoxModel>> Put(BoxModel boxmodel);
    }
    public partial class BoxModelDBService : ControllerBase, IBoxModelDBService
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
        public BoxModelDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<BoxModel>> GetBoxModelWithBoxModelID(int BoxModelID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            BoxModel boxModel = (from c in db.BoxModels.AsNoTracking()
                    where c.BoxModelID == BoxModelID
                    select c).FirstOrDefault();

            if (boxModel == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(boxModel));
        }
        public async Task<ActionResult<List<BoxModel>>> GetBoxModelList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<BoxModel> boxModelList = (from c in db.BoxModels.AsNoTracking() orderby c.BoxModelID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(boxModelList));
        }
        public async Task<ActionResult<bool>> Delete(int BoxModelID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            BoxModel boxModel = (from c in db.BoxModels
                    where c.BoxModelID == BoxModelID
                    select c).FirstOrDefault();

            if (boxModel == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelID", BoxModelID.ToString())));
            }

            try
            {
                db.BoxModels.Remove(boxModel);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<BoxModel>> Post(BoxModel boxModel)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(boxModel), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.BoxModels.Add(boxModel);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(boxModel));
        }
        public async Task<ActionResult<BoxModel>> Put(BoxModel boxModel)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(boxModel), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.BoxModels.Update(boxModel);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(boxModel));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            BoxModel boxModel = validationContext.ObjectInstance as BoxModel;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (boxModel.BoxModelID == 0)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "BoxModelID"), new[] { nameof(boxModel.BoxModelID) }));
                }

                if (!(from c in db.BoxModels.AsNoTracking() select c).Where(c => c.BoxModelID == boxModel.BoxModelID).Any())
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelID", boxModel.BoxModelID.ToString()), new[] { nameof(boxModel.BoxModelID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)boxModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(boxModel.DBCommand) }));
            }

            TVItem TVItemInfrastructureTVItemID = null;
            TVItemInfrastructureTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == boxModel.InfrastructureTVItemID select c).FirstOrDefault();

            if (TVItemInfrastructureTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureTVItemID", boxModel.InfrastructureTVItemID.ToString()), new[] { nameof(boxModel.InfrastructureTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                };
                if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "InfrastructureTVItemID", "Infrastructure"), new[] { nameof(boxModel.InfrastructureTVItemID) }));
                }
            }

            if (boxModel.Discharge_m3_day < 0 || boxModel.Discharge_m3_day > 10000)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Discharge_m3_day", "0", "10000"), new[] { nameof(boxModel.Discharge_m3_day) }));
            }

            if (boxModel.Depth_m < 0 || boxModel.Depth_m > 1000)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Depth_m", "0", "1000"), new[] { nameof(boxModel.Depth_m) }));
            }

            if (boxModel.Temperature_C < -15 || boxModel.Temperature_C > 40)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Temperature_C", "-15", "40"), new[] { nameof(boxModel.Temperature_C) }));
            }

            if (boxModel.Dilution < 0 || boxModel.Dilution > 10000000)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Dilution", "0", "10000000"), new[] { nameof(boxModel.Dilution) }));
            }

            if (boxModel.DecayRate_per_day < 0 || boxModel.DecayRate_per_day > 100)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DecayRate_per_day", "0", "100"), new[] { nameof(boxModel.DecayRate_per_day) }));
            }

            if (boxModel.FCUntreated_MPN_100ml < 0 || boxModel.FCUntreated_MPN_100ml > 10000000)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "FCUntreated_MPN_100ml", "0", "10000000"), new[] { nameof(boxModel.FCUntreated_MPN_100ml) }));
            }

            if (boxModel.FCPreDisinfection_MPN_100ml < 0 || boxModel.FCPreDisinfection_MPN_100ml > 10000000)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "FCPreDisinfection_MPN_100ml", "0", "10000000"), new[] { nameof(boxModel.FCPreDisinfection_MPN_100ml) }));
            }

            if (boxModel.Concentration_MPN_100ml < 0 || boxModel.Concentration_MPN_100ml > 10000000)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Concentration_MPN_100ml", "0", "10000000"), new[] { nameof(boxModel.Concentration_MPN_100ml) }));
            }

            if (boxModel.T90_hour < 0)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "T90_hour", "0"), new[] { nameof(boxModel.T90_hour) }));
            }

            if (boxModel.DischargeDuration_hour < 0 || boxModel.DischargeDuration_hour > 24)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DischargeDuration_hour", "0", "24"), new[] { nameof(boxModel.DischargeDuration_hour) }));
            }

            if (boxModel.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(boxModel.LastUpdateDate_UTC) }));
            }
            else
            {
                if (boxModel.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(boxModel.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == boxModel.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", boxModel.LastUpdateContactTVItemID.ToString()), new[] { nameof(boxModel.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(boxModel.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResultList.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
