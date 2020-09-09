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
using LoggedInServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBServices
{
    public partial interface IInfrastructureDBService
    {
        Task<ActionResult<bool>> Delete(int InfrastructureID);
        Task<ActionResult<List<Infrastructure>>> GetInfrastructureList(int skip = 0, int take = 100);
        Task<ActionResult<Infrastructure>> GetInfrastructureWithInfrastructureID(int InfrastructureID);
        Task<ActionResult<Infrastructure>> Post(Infrastructure infrastructure);
        Task<ActionResult<Infrastructure>> Put(Infrastructure infrastructure);
    }
    public partial class InfrastructureDBService : ControllerBase, IInfrastructureDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<Infrastructure>> GetInfrastructureWithInfrastructureID(int InfrastructureID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            Infrastructure infrastructure = (from c in db.Infrastructures.AsNoTracking()
                    where c.InfrastructureID == InfrastructureID
                    select c).FirstOrDefault();

            if (infrastructure == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(infrastructure));
        }
        public async Task<ActionResult<List<Infrastructure>>> GetInfrastructureList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<Infrastructure> infrastructureList = (from c in db.Infrastructures.AsNoTracking() orderby c.InfrastructureID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(infrastructureList));
        }
        public async Task<ActionResult<bool>> Delete(int InfrastructureID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            Infrastructure infrastructure = (from c in db.Infrastructures
                    where c.InfrastructureID == InfrastructureID
                    select c).FirstOrDefault();

            if (infrastructure == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureID", InfrastructureID.ToString())));
            }

            try
            {
                db.Infrastructures.Remove(infrastructure);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<Infrastructure>> Post(Infrastructure infrastructure)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(infrastructure), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.Infrastructures.Add(infrastructure);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(infrastructure));
        }
        public async Task<ActionResult<Infrastructure>> Put(Infrastructure infrastructure)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(infrastructure), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.Infrastructures.Update(infrastructure);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(infrastructure));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Infrastructure infrastructure = validationContext.ObjectInstance as Infrastructure;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (infrastructure.InfrastructureID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "InfrastructureID"), new[] { nameof(infrastructure.InfrastructureID) });
                }

                if (!(from c in db.Infrastructures.AsNoTracking() select c).Where(c => c.InfrastructureID == infrastructure.InfrastructureID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureID", infrastructure.InfrastructureID.ToString()), new[] { nameof(infrastructure.InfrastructureID) });
                }
            }

            TVItem TVItemInfrastructureTVItemID = null;
            TVItemInfrastructureTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == infrastructure.InfrastructureTVItemID select c).FirstOrDefault();

            if (TVItemInfrastructureTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureTVItemID", infrastructure.InfrastructureTVItemID.ToString()), new[] { nameof(infrastructure.InfrastructureTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                };
                if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "InfrastructureTVItemID", "Infrastructure"), new[] { nameof(infrastructure.InfrastructureTVItemID) });
                }
            }

            if (infrastructure.PrismID != null)
            {
                if (infrastructure.PrismID < 0 || infrastructure.PrismID > 100000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "PrismID", "0", "100000"), new[] { nameof(infrastructure.PrismID) });
                }
            }

            if (infrastructure.TPID != null)
            {
                if (infrastructure.TPID < 0 || infrastructure.TPID > 100000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TPID", "0", "100000"), new[] { nameof(infrastructure.TPID) });
                }
            }

            if (infrastructure.LSID != null)
            {
                if (infrastructure.LSID < 0 || infrastructure.LSID > 100000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "LSID", "0", "100000"), new[] { nameof(infrastructure.LSID) });
                }
            }

            if (infrastructure.SiteID != null)
            {
                if (infrastructure.SiteID < 0 || infrastructure.SiteID > 100000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SiteID", "0", "100000"), new[] { nameof(infrastructure.SiteID) });
                }
            }

            if (infrastructure.Site != null)
            {
                if (infrastructure.Site < 0 || infrastructure.Site > 100000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Site", "0", "100000"), new[] { nameof(infrastructure.Site) });
                }
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.InfrastructureCategory) && (infrastructure.InfrastructureCategory.Length < 1 || infrastructure.InfrastructureCategory.Length > 1))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "InfrastructureCategory", "1", "1"), new[] { nameof(infrastructure.InfrastructureCategory) });
            }

            if (infrastructure.InfrastructureType != null)
            {
                retStr = enums.EnumTypeOK(typeof(InfrastructureTypeEnum), (int?)infrastructure.InfrastructureType);
                if (infrastructure.InfrastructureType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "InfrastructureType"), new[] { nameof(infrastructure.InfrastructureType) });
                }
            }

            if (infrastructure.FacilityType != null)
            {
                retStr = enums.EnumTypeOK(typeof(FacilityTypeEnum), (int?)infrastructure.FacilityType);
                if (infrastructure.FacilityType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FacilityType"), new[] { nameof(infrastructure.FacilityType) });
                }
            }

            if (infrastructure.NumberOfCells != null)
            {
                if (infrastructure.NumberOfCells < 0 || infrastructure.NumberOfCells > 10)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfCells", "0", "10"), new[] { nameof(infrastructure.NumberOfCells) });
                }
            }

            if (infrastructure.NumberOfAeratedCells != null)
            {
                if (infrastructure.NumberOfAeratedCells < 0 || infrastructure.NumberOfAeratedCells > 10)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfAeratedCells", "0", "10"), new[] { nameof(infrastructure.NumberOfAeratedCells) });
                }
            }

            if (infrastructure.AerationType != null)
            {
                retStr = enums.EnumTypeOK(typeof(AerationTypeEnum), (int?)infrastructure.AerationType);
                if (infrastructure.AerationType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AerationType"), new[] { nameof(infrastructure.AerationType) });
                }
            }

            if (infrastructure.PreliminaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(PreliminaryTreatmentTypeEnum), (int?)infrastructure.PreliminaryTreatmentType);
                if (infrastructure.PreliminaryTreatmentType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PreliminaryTreatmentType"), new[] { nameof(infrastructure.PreliminaryTreatmentType) });
                }
            }

            if (infrastructure.PrimaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(PrimaryTreatmentTypeEnum), (int?)infrastructure.PrimaryTreatmentType);
                if (infrastructure.PrimaryTreatmentType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PrimaryTreatmentType"), new[] { nameof(infrastructure.PrimaryTreatmentType) });
                }
            }

            if (infrastructure.SecondaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(SecondaryTreatmentTypeEnum), (int?)infrastructure.SecondaryTreatmentType);
                if (infrastructure.SecondaryTreatmentType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SecondaryTreatmentType"), new[] { nameof(infrastructure.SecondaryTreatmentType) });
                }
            }

            if (infrastructure.TertiaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(TertiaryTreatmentTypeEnum), (int?)infrastructure.TertiaryTreatmentType);
                if (infrastructure.TertiaryTreatmentType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TertiaryTreatmentType"), new[] { nameof(infrastructure.TertiaryTreatmentType) });
                }
            }

            if (infrastructure.TreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(TreatmentTypeEnum), (int?)infrastructure.TreatmentType);
                if (infrastructure.TreatmentType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TreatmentType"), new[] { nameof(infrastructure.TreatmentType) });
                }
            }

            if (infrastructure.DisinfectionType != null)
            {
                retStr = enums.EnumTypeOK(typeof(DisinfectionTypeEnum), (int?)infrastructure.DisinfectionType);
                if (infrastructure.DisinfectionType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DisinfectionType"), new[] { nameof(infrastructure.DisinfectionType) });
                }
            }

            if (infrastructure.CollectionSystemType != null)
            {
                retStr = enums.EnumTypeOK(typeof(CollectionSystemTypeEnum), (int?)infrastructure.CollectionSystemType);
                if (infrastructure.CollectionSystemType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "CollectionSystemType"), new[] { nameof(infrastructure.CollectionSystemType) });
                }
            }

            if (infrastructure.AlarmSystemType != null)
            {
                retStr = enums.EnumTypeOK(typeof(AlarmSystemTypeEnum), (int?)infrastructure.AlarmSystemType);
                if (infrastructure.AlarmSystemType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AlarmSystemType"), new[] { nameof(infrastructure.AlarmSystemType) });
                }
            }

            if (infrastructure.DesignFlow_m3_day != null)
            {
                if (infrastructure.DesignFlow_m3_day < 0 || infrastructure.DesignFlow_m3_day > 1000000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DesignFlow_m3_day", "0", "1000000"), new[] { nameof(infrastructure.DesignFlow_m3_day) });
                }
            }

            if (infrastructure.AverageFlow_m3_day != null)
            {
                if (infrastructure.AverageFlow_m3_day < 0 || infrastructure.AverageFlow_m3_day > 1000000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "AverageFlow_m3_day", "0", "1000000"), new[] { nameof(infrastructure.AverageFlow_m3_day) });
                }
            }

            if (infrastructure.PeakFlow_m3_day != null)
            {
                if (infrastructure.PeakFlow_m3_day < 0 || infrastructure.PeakFlow_m3_day > 1000000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "PeakFlow_m3_day", "0", "1000000"), new[] { nameof(infrastructure.PeakFlow_m3_day) });
                }
            }

            if (infrastructure.PopServed != null)
            {
                if (infrastructure.PopServed < 0 || infrastructure.PopServed > 1000000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "PopServed", "0", "1000000"), new[] { nameof(infrastructure.PopServed) });
                }
            }

            if (infrastructure.ValveType != null)
            {
                retStr = enums.EnumTypeOK(typeof(ValveTypeEnum), (int?)infrastructure.ValveType);
                if (infrastructure.ValveType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ValveType"), new[] { nameof(infrastructure.ValveType) });
                }
            }

            if (infrastructure.PercFlowOfTotal != null)
            {
                if (infrastructure.PercFlowOfTotal < 0 || infrastructure.PercFlowOfTotal > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "PercFlowOfTotal", "0", "100"), new[] { nameof(infrastructure.PercFlowOfTotal) });
                }
            }

            if (infrastructure.TimeOffset_hour != null)
            {
                if (infrastructure.TimeOffset_hour < -10 || infrastructure.TimeOffset_hour > 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TimeOffset_hour", "-10", "0"), new[] { nameof(infrastructure.TimeOffset_hour) });
                }
            }

            //TempCatchAllRemoveLater has no StringLength Attribute

            if (infrastructure.AverageDepth_m != null)
            {
                if (infrastructure.AverageDepth_m < 0 || infrastructure.AverageDepth_m > 1000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "AverageDepth_m", "0", "1000"), new[] { nameof(infrastructure.AverageDepth_m) });
                }
            }

            if (infrastructure.NumberOfPorts != null)
            {
                if (infrastructure.NumberOfPorts < 1 || infrastructure.NumberOfPorts > 1000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfPorts", "1", "1000"), new[] { nameof(infrastructure.NumberOfPorts) });
                }
            }

            if (infrastructure.PortDiameter_m != null)
            {
                if (infrastructure.PortDiameter_m < 0 || infrastructure.PortDiameter_m > 10)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "PortDiameter_m", "0", "10"), new[] { nameof(infrastructure.PortDiameter_m) });
                }
            }

            if (infrastructure.PortSpacing_m != null)
            {
                if (infrastructure.PortSpacing_m < 0 || infrastructure.PortSpacing_m > 10000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "PortSpacing_m", "0", "10000"), new[] { nameof(infrastructure.PortSpacing_m) });
                }
            }

            if (infrastructure.PortElevation_m != null)
            {
                if (infrastructure.PortElevation_m < 0 || infrastructure.PortElevation_m > 1000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "PortElevation_m", "0", "1000"), new[] { nameof(infrastructure.PortElevation_m) });
                }
            }

            if (infrastructure.VerticalAngle_deg != null)
            {
                if (infrastructure.VerticalAngle_deg < -90 || infrastructure.VerticalAngle_deg > 90)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "VerticalAngle_deg", "-90", "90"), new[] { nameof(infrastructure.VerticalAngle_deg) });
                }
            }

            if (infrastructure.HorizontalAngle_deg != null)
            {
                if (infrastructure.HorizontalAngle_deg < -180 || infrastructure.HorizontalAngle_deg > 180)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "HorizontalAngle_deg", "-180", "180"), new[] { nameof(infrastructure.HorizontalAngle_deg) });
                }
            }

            if (infrastructure.DecayRate_per_day != null)
            {
                if (infrastructure.DecayRate_per_day < 0 || infrastructure.DecayRate_per_day > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DecayRate_per_day", "0", "100"), new[] { nameof(infrastructure.DecayRate_per_day) });
                }
            }

            if (infrastructure.NearFieldVelocity_m_s != null)
            {
                if (infrastructure.NearFieldVelocity_m_s < 0 || infrastructure.NearFieldVelocity_m_s > 10)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NearFieldVelocity_m_s", "0", "10"), new[] { nameof(infrastructure.NearFieldVelocity_m_s) });
                }
            }

            if (infrastructure.FarFieldVelocity_m_s != null)
            {
                if (infrastructure.FarFieldVelocity_m_s < 0 || infrastructure.FarFieldVelocity_m_s > 10)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "FarFieldVelocity_m_s", "0", "10"), new[] { nameof(infrastructure.FarFieldVelocity_m_s) });
                }
            }

            if (infrastructure.ReceivingWaterSalinity_PSU != null)
            {
                if (infrastructure.ReceivingWaterSalinity_PSU < 0 || infrastructure.ReceivingWaterSalinity_PSU > 40)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ReceivingWaterSalinity_PSU", "0", "40"), new[] { nameof(infrastructure.ReceivingWaterSalinity_PSU) });
                }
            }

            if (infrastructure.ReceivingWaterTemperature_C != null)
            {
                if (infrastructure.ReceivingWaterTemperature_C < -10 || infrastructure.ReceivingWaterTemperature_C > 40)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ReceivingWaterTemperature_C", "-10", "40"), new[] { nameof(infrastructure.ReceivingWaterTemperature_C) });
                }
            }

            if (infrastructure.ReceivingWater_MPN_per_100ml != null)
            {
                if (infrastructure.ReceivingWater_MPN_per_100ml < 0 || infrastructure.ReceivingWater_MPN_per_100ml > 10000000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ReceivingWater_MPN_per_100ml", "0", "10000000"), new[] { nameof(infrastructure.ReceivingWater_MPN_per_100ml) });
                }
            }

            if (infrastructure.DistanceFromShore_m != null)
            {
                if (infrastructure.DistanceFromShore_m < 0 || infrastructure.DistanceFromShore_m > 1000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DistanceFromShore_m", "0", "1000"), new[] { nameof(infrastructure.DistanceFromShore_m) });
                }
            }

            if (infrastructure.SeeOtherMunicipalityTVItemID != null)
            {
                TVItem TVItemSeeOtherMunicipalityTVItemID = null;
                TVItemSeeOtherMunicipalityTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == infrastructure.SeeOtherMunicipalityTVItemID select c).FirstOrDefault();

                if (TVItemSeeOtherMunicipalityTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "SeeOtherMunicipalityTVItemID", (infrastructure.SeeOtherMunicipalityTVItemID == null ? "" : infrastructure.SeeOtherMunicipalityTVItemID.ToString())), new[] { nameof(infrastructure.SeeOtherMunicipalityTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Infrastructure,
                    };
                    if (!AllowableTVTypes.Contains(TVItemSeeOtherMunicipalityTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "SeeOtherMunicipalityTVItemID", "Infrastructure"), new[] { nameof(infrastructure.SeeOtherMunicipalityTVItemID) });
                    }
                }
            }

            if (infrastructure.CivicAddressTVItemID != null)
            {
                TVItem TVItemCivicAddressTVItemID = null;
                TVItemCivicAddressTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == infrastructure.CivicAddressTVItemID select c).FirstOrDefault();

                if (TVItemCivicAddressTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "CivicAddressTVItemID", (infrastructure.CivicAddressTVItemID == null ? "" : infrastructure.CivicAddressTVItemID.ToString())), new[] { nameof(infrastructure.CivicAddressTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Address,
                    };
                    if (!AllowableTVTypes.Contains(TVItemCivicAddressTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "CivicAddressTVItemID", "Address"), new[] { nameof(infrastructure.CivicAddressTVItemID) });
                    }
                }
            }

            if (infrastructure.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(infrastructure.LastUpdateDate_UTC) });
            }
            else
            {
                if (infrastructure.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(infrastructure.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == infrastructure.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", infrastructure.LastUpdateContactTVItemID.ToString()), new[] { nameof(infrastructure.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(infrastructure.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
