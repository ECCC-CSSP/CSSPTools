/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
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
   public interface IInfrastructureService
    {
       Task<ActionResult<bool>> Delete(int InfrastructureID);
       Task<ActionResult<List<Infrastructure>>> GetInfrastructureList(int skip = 0, int take = 100);
       Task<ActionResult<Infrastructure>> GetInfrastructureWithInfrastructureID(int InfrastructureID);
       Task<ActionResult<Infrastructure>> Post(Infrastructure infrastructure);
       Task<ActionResult<Infrastructure>> Put(Infrastructure infrastructure);
    }
    public partial class InfrastructureService : ControllerBase, IInfrastructureService
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
        public InfrastructureService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<Infrastructure>> GetInfrastructureWithInfrastructureID(int InfrastructureID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsMemory)
            {
                Infrastructure infrastructure = (from c in dbIM.Infrastructures.AsNoTracking()
                                   where c.InfrastructureID == InfrastructureID
                                   select c).FirstOrDefault();

                if (infrastructure == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(infrastructure));
            }
            else if (LoggedInService.IsLocal)
            {
                Infrastructure infrastructure = (from c in dbLocal.Infrastructures.AsNoTracking()
                        where c.InfrastructureID == InfrastructureID
                        select c).FirstOrDefault();

                if (infrastructure == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(infrastructure));
            }
            else
            {
                Infrastructure infrastructure = (from c in db.Infrastructures.AsNoTracking()
                        where c.InfrastructureID == InfrastructureID
                        select c).FirstOrDefault();

                if (infrastructure == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(infrastructure));
            }
        }
        public async Task<ActionResult<List<Infrastructure>>> GetInfrastructureList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsMemory)
            {
                List<Infrastructure> infrastructureList = (from c in dbIM.Infrastructures.AsNoTracking() orderby c.InfrastructureID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(infrastructureList));
            }
            else if (LoggedInService.IsLocal)
            {
                List<Infrastructure> infrastructureList = (from c in dbLocal.Infrastructures.AsNoTracking() orderby c.InfrastructureID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(infrastructureList));
            }
            else
            {
                List<Infrastructure> infrastructureList = (from c in db.Infrastructures.AsNoTracking() orderby c.InfrastructureID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(infrastructureList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int InfrastructureID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsMemory)
            {
                Infrastructure infrastructure = (from c in dbIM.Infrastructures
                                   where c.InfrastructureID == InfrastructureID
                                   select c).FirstOrDefault();
            
                if (infrastructure == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureID", InfrastructureID.ToString())));
                }
            
                try
                {
                    dbIM.Infrastructures.Remove(infrastructure);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }
            
                return await Task.FromResult(Ok(true));
            }
            else if (LoggedInService.IsLocal)
            {
                Infrastructure infrastructure = (from c in dbLocal.Infrastructures
                                   where c.InfrastructureID == InfrastructureID
                                   select c).FirstOrDefault();
                
                if (infrastructure == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureID", InfrastructureID.ToString())));
                }

                try
                {
                   dbLocal.Infrastructures.Remove(infrastructure);
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
                Infrastructure infrastructure = (from c in db.Infrastructures
                                   where c.InfrastructureID == InfrastructureID
                                   select c).FirstOrDefault();
                
                if (infrastructure == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureID", InfrastructureID.ToString())));
                }

                try
                {
                   db.Infrastructures.Remove(infrastructure);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<Infrastructure>> Post(Infrastructure infrastructure)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(infrastructure), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsMemory)
            {
                try
                {
                    dbIM.Infrastructures.Add(infrastructure);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(infrastructure));
            }
            else if (LoggedInService.IsLocal)
            {
                try
                {
                   dbLocal.Infrastructures.Add(infrastructure);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(infrastructure));
            }
            else
            {
                try
                {
                   db.Infrastructures.Add(infrastructure);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(infrastructure));
            }
        }
        public async Task<ActionResult<Infrastructure>> Put(Infrastructure infrastructure)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(infrastructure), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsMemory)
            {
                try
                {
                    dbIM.Infrastructures.Update(infrastructure);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(infrastructure));
            }
            else if (LoggedInService.IsLocal)
            {
            try
            {
               dbLocal.Infrastructures.Update(infrastructure);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(infrastructure));
            }
            else
            {
            try
            {
               db.Infrastructures.Update(infrastructure);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(infrastructure));
            }
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
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "InfrastructureID"), new[] { "InfrastructureID" });
                }

                if (LoggedInService.IsLocal)
                {
                    if (!(from c in dbLocal.Infrastructures select c).Where(c => c.InfrastructureID == infrastructure.InfrastructureID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureID", infrastructure.InfrastructureID.ToString()), new[] { "InfrastructureID" });
                    }
                }
                else
                {
                    if (!(from c in db.Infrastructures select c).Where(c => c.InfrastructureID == infrastructure.InfrastructureID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureID", infrastructure.InfrastructureID.ToString()), new[] { "InfrastructureID" });
                    }
                }
            }

            TVItem TVItemInfrastructureTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemInfrastructureTVItemID = (from c in dbLocal.TVItems where c.TVItemID == infrastructure.InfrastructureTVItemID select c).FirstOrDefault();
                if (TVItemInfrastructureTVItemID == null)
                {
                    TVItemInfrastructureTVItemID = (from c in dbIM.TVItems where c.TVItemID == infrastructure.InfrastructureTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.InfrastructureTVItemID select c).FirstOrDefault();
            }

            if (TVItemInfrastructureTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureTVItemID", infrastructure.InfrastructureTVItemID.ToString()), new[] { "InfrastructureTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                };
                if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "InfrastructureTVItemID", "Infrastructure"), new[] { "InfrastructureTVItemID" });
                }
            }

            if (infrastructure.PrismID != null)
            {
                if (infrastructure.PrismID < 0 || infrastructure.PrismID > 100000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "PrismID", "0", "100000"), new[] { "PrismID" });
                }
            }

            if (infrastructure.TPID != null)
            {
                if (infrastructure.TPID < 0 || infrastructure.TPID > 100000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "TPID", "0", "100000"), new[] { "TPID" });
                }
            }

            if (infrastructure.LSID != null)
            {
                if (infrastructure.LSID < 0 || infrastructure.LSID > 100000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "LSID", "0", "100000"), new[] { "LSID" });
                }
            }

            if (infrastructure.SiteID != null)
            {
                if (infrastructure.SiteID < 0 || infrastructure.SiteID > 100000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "SiteID", "0", "100000"), new[] { "SiteID" });
                }
            }

            if (infrastructure.Site != null)
            {
                if (infrastructure.Site < 0 || infrastructure.Site > 100000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Site", "0", "100000"), new[] { "Site" });
                }
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.InfrastructureCategory) && (infrastructure.InfrastructureCategory.Length < 1 || infrastructure.InfrastructureCategory.Length > 1))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._LengthShouldBeBetween_And_, "InfrastructureCategory", "1", "1"), new[] { "InfrastructureCategory" });
            }

            if (infrastructure.InfrastructureType != null)
            {
                retStr = enums.EnumTypeOK(typeof(InfrastructureTypeEnum), (int?)infrastructure.InfrastructureType);
                if (infrastructure.InfrastructureType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "InfrastructureType"), new[] { "InfrastructureType" });
                }
            }

            if (infrastructure.FacilityType != null)
            {
                retStr = enums.EnumTypeOK(typeof(FacilityTypeEnum), (int?)infrastructure.FacilityType);
                if (infrastructure.FacilityType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "FacilityType"), new[] { "FacilityType" });
                }
            }

            if (infrastructure.NumberOfCells != null)
            {
                if (infrastructure.NumberOfCells < 0 || infrastructure.NumberOfCells > 10)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "NumberOfCells", "0", "10"), new[] { "NumberOfCells" });
                }
            }

            if (infrastructure.NumberOfAeratedCells != null)
            {
                if (infrastructure.NumberOfAeratedCells < 0 || infrastructure.NumberOfAeratedCells > 10)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "NumberOfAeratedCells", "0", "10"), new[] { "NumberOfAeratedCells" });
                }
            }

            if (infrastructure.AerationType != null)
            {
                retStr = enums.EnumTypeOK(typeof(AerationTypeEnum), (int?)infrastructure.AerationType);
                if (infrastructure.AerationType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "AerationType"), new[] { "AerationType" });
                }
            }

            if (infrastructure.PreliminaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(PreliminaryTreatmentTypeEnum), (int?)infrastructure.PreliminaryTreatmentType);
                if (infrastructure.PreliminaryTreatmentType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "PreliminaryTreatmentType"), new[] { "PreliminaryTreatmentType" });
                }
            }

            if (infrastructure.PrimaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(PrimaryTreatmentTypeEnum), (int?)infrastructure.PrimaryTreatmentType);
                if (infrastructure.PrimaryTreatmentType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "PrimaryTreatmentType"), new[] { "PrimaryTreatmentType" });
                }
            }

            if (infrastructure.SecondaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(SecondaryTreatmentTypeEnum), (int?)infrastructure.SecondaryTreatmentType);
                if (infrastructure.SecondaryTreatmentType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "SecondaryTreatmentType"), new[] { "SecondaryTreatmentType" });
                }
            }

            if (infrastructure.TertiaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(TertiaryTreatmentTypeEnum), (int?)infrastructure.TertiaryTreatmentType);
                if (infrastructure.TertiaryTreatmentType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TertiaryTreatmentType"), new[] { "TertiaryTreatmentType" });
                }
            }

            if (infrastructure.TreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(TreatmentTypeEnum), (int?)infrastructure.TreatmentType);
                if (infrastructure.TreatmentType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TreatmentType"), new[] { "TreatmentType" });
                }
            }

            if (infrastructure.DisinfectionType != null)
            {
                retStr = enums.EnumTypeOK(typeof(DisinfectionTypeEnum), (int?)infrastructure.DisinfectionType);
                if (infrastructure.DisinfectionType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "DisinfectionType"), new[] { "DisinfectionType" });
                }
            }

            if (infrastructure.CollectionSystemType != null)
            {
                retStr = enums.EnumTypeOK(typeof(CollectionSystemTypeEnum), (int?)infrastructure.CollectionSystemType);
                if (infrastructure.CollectionSystemType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "CollectionSystemType"), new[] { "CollectionSystemType" });
                }
            }

            if (infrastructure.AlarmSystemType != null)
            {
                retStr = enums.EnumTypeOK(typeof(AlarmSystemTypeEnum), (int?)infrastructure.AlarmSystemType);
                if (infrastructure.AlarmSystemType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "AlarmSystemType"), new[] { "AlarmSystemType" });
                }
            }

            if (infrastructure.DesignFlow_m3_day != null)
            {
                if (infrastructure.DesignFlow_m3_day < 0 || infrastructure.DesignFlow_m3_day > 1000000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "DesignFlow_m3_day", "0", "1000000"), new[] { "DesignFlow_m3_day" });
                }
            }

            if (infrastructure.AverageFlow_m3_day != null)
            {
                if (infrastructure.AverageFlow_m3_day < 0 || infrastructure.AverageFlow_m3_day > 1000000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "AverageFlow_m3_day", "0", "1000000"), new[] { "AverageFlow_m3_day" });
                }
            }

            if (infrastructure.PeakFlow_m3_day != null)
            {
                if (infrastructure.PeakFlow_m3_day < 0 || infrastructure.PeakFlow_m3_day > 1000000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "PeakFlow_m3_day", "0", "1000000"), new[] { "PeakFlow_m3_day" });
                }
            }

            if (infrastructure.PopServed != null)
            {
                if (infrastructure.PopServed < 0 || infrastructure.PopServed > 1000000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "PopServed", "0", "1000000"), new[] { "PopServed" });
                }
            }

            if (infrastructure.ValveType != null)
            {
                retStr = enums.EnumTypeOK(typeof(ValveTypeEnum), (int?)infrastructure.ValveType);
                if (infrastructure.ValveType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "ValveType"), new[] { "ValveType" });
                }
            }

            if (infrastructure.PercFlowOfTotal != null)
            {
                if (infrastructure.PercFlowOfTotal < 0 || infrastructure.PercFlowOfTotal > 100)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "PercFlowOfTotal", "0", "100"), new[] { "PercFlowOfTotal" });
                }
            }

            if (infrastructure.TimeOffset_hour != null)
            {
                if (infrastructure.TimeOffset_hour < -10 || infrastructure.TimeOffset_hour > 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "TimeOffset_hour", "-10", "0"), new[] { "TimeOffset_hour" });
                }
            }

            //TempCatchAllRemoveLater has no StringLength Attribute

            if (infrastructure.AverageDepth_m != null)
            {
                if (infrastructure.AverageDepth_m < 0 || infrastructure.AverageDepth_m > 1000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "AverageDepth_m", "0", "1000"), new[] { "AverageDepth_m" });
                }
            }

            if (infrastructure.NumberOfPorts != null)
            {
                if (infrastructure.NumberOfPorts < 1 || infrastructure.NumberOfPorts > 1000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "NumberOfPorts", "1", "1000"), new[] { "NumberOfPorts" });
                }
            }

            if (infrastructure.PortDiameter_m != null)
            {
                if (infrastructure.PortDiameter_m < 0 || infrastructure.PortDiameter_m > 10)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "PortDiameter_m", "0", "10"), new[] { "PortDiameter_m" });
                }
            }

            if (infrastructure.PortSpacing_m != null)
            {
                if (infrastructure.PortSpacing_m < 0 || infrastructure.PortSpacing_m > 10000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "PortSpacing_m", "0", "10000"), new[] { "PortSpacing_m" });
                }
            }

            if (infrastructure.PortElevation_m != null)
            {
                if (infrastructure.PortElevation_m < 0 || infrastructure.PortElevation_m > 1000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "PortElevation_m", "0", "1000"), new[] { "PortElevation_m" });
                }
            }

            if (infrastructure.VerticalAngle_deg != null)
            {
                if (infrastructure.VerticalAngle_deg < -90 || infrastructure.VerticalAngle_deg > 90)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "VerticalAngle_deg", "-90", "90"), new[] { "VerticalAngle_deg" });
                }
            }

            if (infrastructure.HorizontalAngle_deg != null)
            {
                if (infrastructure.HorizontalAngle_deg < -180 || infrastructure.HorizontalAngle_deg > 180)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "HorizontalAngle_deg", "-180", "180"), new[] { "HorizontalAngle_deg" });
                }
            }

            if (infrastructure.DecayRate_per_day != null)
            {
                if (infrastructure.DecayRate_per_day < 0 || infrastructure.DecayRate_per_day > 100)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "DecayRate_per_day", "0", "100"), new[] { "DecayRate_per_day" });
                }
            }

            if (infrastructure.NearFieldVelocity_m_s != null)
            {
                if (infrastructure.NearFieldVelocity_m_s < 0 || infrastructure.NearFieldVelocity_m_s > 10)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "NearFieldVelocity_m_s", "0", "10"), new[] { "NearFieldVelocity_m_s" });
                }
            }

            if (infrastructure.FarFieldVelocity_m_s != null)
            {
                if (infrastructure.FarFieldVelocity_m_s < 0 || infrastructure.FarFieldVelocity_m_s > 10)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "FarFieldVelocity_m_s", "0", "10"), new[] { "FarFieldVelocity_m_s" });
                }
            }

            if (infrastructure.ReceivingWaterSalinity_PSU != null)
            {
                if (infrastructure.ReceivingWaterSalinity_PSU < 0 || infrastructure.ReceivingWaterSalinity_PSU > 40)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "ReceivingWaterSalinity_PSU", "0", "40"), new[] { "ReceivingWaterSalinity_PSU" });
                }
            }

            if (infrastructure.ReceivingWaterTemperature_C != null)
            {
                if (infrastructure.ReceivingWaterTemperature_C < -10 || infrastructure.ReceivingWaterTemperature_C > 40)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "ReceivingWaterTemperature_C", "-10", "40"), new[] { "ReceivingWaterTemperature_C" });
                }
            }

            if (infrastructure.ReceivingWater_MPN_per_100ml != null)
            {
                if (infrastructure.ReceivingWater_MPN_per_100ml < 0 || infrastructure.ReceivingWater_MPN_per_100ml > 10000000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "ReceivingWater_MPN_per_100ml", "0", "10000000"), new[] { "ReceivingWater_MPN_per_100ml" });
                }
            }

            if (infrastructure.DistanceFromShore_m != null)
            {
                if (infrastructure.DistanceFromShore_m < 0 || infrastructure.DistanceFromShore_m > 1000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "DistanceFromShore_m", "0", "1000"), new[] { "DistanceFromShore_m" });
                }
            }

            if (infrastructure.SeeOtherMunicipalityTVItemID != null)
            {
                TVItem TVItemSeeOtherMunicipalityTVItemID = null;
                if (LoggedInService.IsLocal)
                {
                    TVItemSeeOtherMunicipalityTVItemID = (from c in dbLocal.TVItems where c.TVItemID == infrastructure.SeeOtherMunicipalityTVItemID select c).FirstOrDefault();
                    if (TVItemSeeOtherMunicipalityTVItemID == null)
                    {
                        TVItemSeeOtherMunicipalityTVItemID = (from c in dbIM.TVItems where c.TVItemID == infrastructure.SeeOtherMunicipalityTVItemID select c).FirstOrDefault();
                    }
                }
                else
                {
                    TVItemSeeOtherMunicipalityTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.SeeOtherMunicipalityTVItemID select c).FirstOrDefault();
                }

                if (TVItemSeeOtherMunicipalityTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "SeeOtherMunicipalityTVItemID", (infrastructure.SeeOtherMunicipalityTVItemID == null ? "" : infrastructure.SeeOtherMunicipalityTVItemID.ToString())), new[] { "SeeOtherMunicipalityTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Infrastructure,
                    };
                    if (!AllowableTVTypes.Contains(TVItemSeeOtherMunicipalityTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "SeeOtherMunicipalityTVItemID", "Infrastructure"), new[] { "SeeOtherMunicipalityTVItemID" });
                    }
                }
            }

            if (infrastructure.CivicAddressTVItemID != null)
            {
                TVItem TVItemCivicAddressTVItemID = null;
                if (LoggedInService.IsLocal)
                {
                    TVItemCivicAddressTVItemID = (from c in dbLocal.TVItems where c.TVItemID == infrastructure.CivicAddressTVItemID select c).FirstOrDefault();
                    if (TVItemCivicAddressTVItemID == null)
                    {
                        TVItemCivicAddressTVItemID = (from c in dbIM.TVItems where c.TVItemID == infrastructure.CivicAddressTVItemID select c).FirstOrDefault();
                    }
                }
                else
                {
                    TVItemCivicAddressTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.CivicAddressTVItemID select c).FirstOrDefault();
                }

                if (TVItemCivicAddressTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "CivicAddressTVItemID", (infrastructure.CivicAddressTVItemID == null ? "" : infrastructure.CivicAddressTVItemID.ToString())), new[] { "CivicAddressTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Address,
                    };
                    if (!AllowableTVTypes.Contains(TVItemCivicAddressTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "CivicAddressTVItemID", "Address"), new[] { "CivicAddressTVItemID" });
                    }
                }
            }

            if (infrastructure.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (infrastructure.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == infrastructure.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == infrastructure.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", infrastructure.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
