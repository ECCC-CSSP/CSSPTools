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
   public partial interface ITVItemUserAuthorizationService
    {
       Task<ActionResult<bool>> Delete(int TVItemUserAuthorizationID);
       Task<ActionResult<List<TVItemUserAuthorization>>> GetTVItemUserAuthorizationList(int skip = 0, int take = 100);
       Task<ActionResult<TVItemUserAuthorization>> GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(int TVItemUserAuthorizationID);
       Task<ActionResult<TVItemUserAuthorization>> Post(TVItemUserAuthorization tvitemuserauthorization);
       Task<ActionResult<TVItemUserAuthorization>> Put(TVItemUserAuthorization tvitemuserauthorization);
    }
    public partial class TVItemUserAuthorizationService : ControllerBase, ITVItemUserAuthorizationService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<TVItemUserAuthorization>> GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(int TVItemUserAuthorizationID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                TVItemUserAuthorization tvItemUserAuthorization = (from c in dbIM.TVItemUserAuthorizations.AsNoTracking()
                                   where c.TVItemUserAuthorizationID == TVItemUserAuthorizationID
                                   select c).FirstOrDefault();

                if (tvItemUserAuthorization == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvItemUserAuthorization));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemUserAuthorization tvItemUserAuthorization = (from c in dbLocal.TVItemUserAuthorizations.AsNoTracking()
                        where c.TVItemUserAuthorizationID == TVItemUserAuthorizationID
                        select c).FirstOrDefault();

                if (tvItemUserAuthorization == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvItemUserAuthorization));
            }
            else
            {
                TVItemUserAuthorization tvItemUserAuthorization = (from c in db.TVItemUserAuthorizations.AsNoTracking()
                        where c.TVItemUserAuthorizationID == TVItemUserAuthorizationID
                        select c).FirstOrDefault();

                if (tvItemUserAuthorization == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvItemUserAuthorization));
            }
        }
        public async Task<ActionResult<List<TVItemUserAuthorization>>> GetTVItemUserAuthorizationList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<TVItemUserAuthorization> tvItemUserAuthorizationList = (from c in dbIM.TVItemUserAuthorizations.AsNoTracking() orderby c.TVItemUserAuthorizationID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(tvItemUserAuthorizationList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<TVItemUserAuthorization> tvItemUserAuthorizationList = (from c in dbLocal.TVItemUserAuthorizations.AsNoTracking() orderby c.TVItemUserAuthorizationID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(tvItemUserAuthorizationList));
            }
            else
            {
                List<TVItemUserAuthorization> tvItemUserAuthorizationList = (from c in db.TVItemUserAuthorizations.AsNoTracking() orderby c.TVItemUserAuthorizationID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(tvItemUserAuthorizationList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int TVItemUserAuthorizationID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                TVItemUserAuthorization tvItemUserAuthorization = (from c in dbIM.TVItemUserAuthorizations
                                   where c.TVItemUserAuthorizationID == TVItemUserAuthorizationID
                                   select c).FirstOrDefault();
            
                if (tvItemUserAuthorization == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemUserAuthorization", "TVItemUserAuthorizationID", TVItemUserAuthorizationID.ToString())));
                }
            
                try
                {
                    dbIM.TVItemUserAuthorizations.Remove(tvItemUserAuthorization);
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
                TVItemUserAuthorization tvItemUserAuthorization = (from c in dbLocal.TVItemUserAuthorizations
                                   where c.TVItemUserAuthorizationID == TVItemUserAuthorizationID
                                   select c).FirstOrDefault();
                
                if (tvItemUserAuthorization == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemUserAuthorization", "TVItemUserAuthorizationID", TVItemUserAuthorizationID.ToString())));
                }

                try
                {
                   dbLocal.TVItemUserAuthorizations.Remove(tvItemUserAuthorization);
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
                TVItemUserAuthorization tvItemUserAuthorization = (from c in db.TVItemUserAuthorizations
                                   where c.TVItemUserAuthorizationID == TVItemUserAuthorizationID
                                   select c).FirstOrDefault();
                
                if (tvItemUserAuthorization == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemUserAuthorization", "TVItemUserAuthorizationID", TVItemUserAuthorizationID.ToString())));
                }

                try
                {
                   db.TVItemUserAuthorizations.Remove(tvItemUserAuthorization);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<TVItemUserAuthorization>> Post(TVItemUserAuthorization tvItemUserAuthorization)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvItemUserAuthorization), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.TVItemUserAuthorizations.Add(tvItemUserAuthorization);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvItemUserAuthorization));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.TVItemUserAuthorizations.Add(tvItemUserAuthorization);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvItemUserAuthorization));
            }
            else
            {
                try
                {
                   db.TVItemUserAuthorizations.Add(tvItemUserAuthorization);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvItemUserAuthorization));
            }
        }
        public async Task<ActionResult<TVItemUserAuthorization>> Put(TVItemUserAuthorization tvItemUserAuthorization)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvItemUserAuthorization), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.TVItemUserAuthorizations.Update(tvItemUserAuthorization);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvItemUserAuthorization));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.TVItemUserAuthorizations.Update(tvItemUserAuthorization);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvItemUserAuthorization));
            }
            else
            {
            try
            {
               db.TVItemUserAuthorizations.Update(tvItemUserAuthorization);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvItemUserAuthorization));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            TVItemUserAuthorization tvItemUserAuthorization = validationContext.ObjectInstance as TVItemUserAuthorization;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvItemUserAuthorization.TVItemUserAuthorizationID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemUserAuthorizationID"), new[] { "TVItemUserAuthorizationID" });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.TVItemUserAuthorizations select c).Where(c => c.TVItemUserAuthorizationID == tvItemUserAuthorization.TVItemUserAuthorizationID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemUserAuthorization", "TVItemUserAuthorizationID", tvItemUserAuthorization.TVItemUserAuthorizationID.ToString()), new[] { "TVItemUserAuthorizationID" });
                    }
                }
                else
                {
                    if (!(from c in db.TVItemUserAuthorizations select c).Where(c => c.TVItemUserAuthorizationID == tvItemUserAuthorization.TVItemUserAuthorizationID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemUserAuthorization", "TVItemUserAuthorizationID", tvItemUserAuthorization.TVItemUserAuthorizationID.ToString()), new[] { "TVItemUserAuthorizationID" });
                    }
                }
            }

            TVItem TVItemContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tvItemUserAuthorization.ContactTVItemID select c).FirstOrDefault();
                if (TVItemContactTVItemID == null)
                {
                    TVItemContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == tvItemUserAuthorization.ContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.ContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactTVItemID", tvItemUserAuthorization.ContactTVItemID.ToString()), new[] { "ContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ContactTVItemID", "Contact"), new[] { "ContactTVItemID" });
                }
            }

            TVItem TVItemTVItemID1 = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemTVItemID1 = (from c in dbLocal.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID1 select c).FirstOrDefault();
                if (TVItemTVItemID1 == null)
                {
                    TVItemTVItemID1 = (from c in dbIM.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID1 select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemTVItemID1 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID1 select c).FirstOrDefault();
            }

            if (TVItemTVItemID1 == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID1", tvItemUserAuthorization.TVItemID1.ToString()), new[] { "TVItemID1" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Address,
                    TVTypeEnum.Area,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.Contact,
                    TVTypeEnum.Country,
                    TVTypeEnum.Email,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.Infrastructure,
                    TVTypeEnum.MikeScenario,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.Province,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.Tel,
                    TVTypeEnum.TideSite,
                    TVTypeEnum.WasteWaterTreatmentPlant,
                    TVTypeEnum.LiftStation,
                    TVTypeEnum.Spill,
                    TVTypeEnum.BoxModel,
                    TVTypeEnum.VisualPlumesScenario,
                    TVTypeEnum.OtherInfrastructure,
                    TVTypeEnum.MWQMRun,
                    TVTypeEnum.MeshNode,
                    TVTypeEnum.WebTideNode,
                    TVTypeEnum.SamplingPlan,
                    TVTypeEnum.SeeOtherMunicipality,
                    TVTypeEnum.LineOverflow,
                    TVTypeEnum.MapInfo,
                    TVTypeEnum.MapInfoPoint,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID1.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVItemID1", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID1" });
                }
            }

            if (tvItemUserAuthorization.TVItemID2 != null)
            {
                TVItem TVItemTVItemID2 = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    TVItemTVItemID2 = (from c in dbLocal.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID2 select c).FirstOrDefault();
                    if (TVItemTVItemID2 == null)
                    {
                        TVItemTVItemID2 = (from c in dbIM.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID2 select c).FirstOrDefault();
                    }
                }
                else
                {
                    TVItemTVItemID2 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID2 select c).FirstOrDefault();
                }

                if (TVItemTVItemID2 == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID2", (tvItemUserAuthorization.TVItemID2 == null ? "" : tvItemUserAuthorization.TVItemID2.ToString())), new[] { "TVItemID2" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Root,
                        TVTypeEnum.Address,
                        TVTypeEnum.Area,
                        TVTypeEnum.ClimateSite,
                        TVTypeEnum.Contact,
                        TVTypeEnum.Country,
                        TVTypeEnum.Email,
                        TVTypeEnum.File,
                        TVTypeEnum.HydrometricSite,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.MikeSource,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.MWQMSite,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.Province,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.Tel,
                        TVTypeEnum.TideSite,
                        TVTypeEnum.WasteWaterTreatmentPlant,
                        TVTypeEnum.LiftStation,
                        TVTypeEnum.Spill,
                        TVTypeEnum.BoxModel,
                        TVTypeEnum.VisualPlumesScenario,
                        TVTypeEnum.OtherInfrastructure,
                        TVTypeEnum.MWQMRun,
                        TVTypeEnum.MeshNode,
                        TVTypeEnum.WebTideNode,
                        TVTypeEnum.SamplingPlan,
                        TVTypeEnum.SeeOtherMunicipality,
                        TVTypeEnum.LineOverflow,
                        TVTypeEnum.MapInfo,
                        TVTypeEnum.MapInfoPoint,
                    };
                    if (!AllowableTVTypes.Contains(TVItemTVItemID2.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVItemID2", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID2" });
                    }
                }
            }

            if (tvItemUserAuthorization.TVItemID3 != null)
            {
                TVItem TVItemTVItemID3 = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    TVItemTVItemID3 = (from c in dbLocal.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID3 select c).FirstOrDefault();
                    if (TVItemTVItemID3 == null)
                    {
                        TVItemTVItemID3 = (from c in dbIM.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID3 select c).FirstOrDefault();
                    }
                }
                else
                {
                    TVItemTVItemID3 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID3 select c).FirstOrDefault();
                }

                if (TVItemTVItemID3 == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID3", (tvItemUserAuthorization.TVItemID3 == null ? "" : tvItemUserAuthorization.TVItemID3.ToString())), new[] { "TVItemID3" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Root,
                        TVTypeEnum.Address,
                        TVTypeEnum.Area,
                        TVTypeEnum.ClimateSite,
                        TVTypeEnum.Contact,
                        TVTypeEnum.Country,
                        TVTypeEnum.Email,
                        TVTypeEnum.File,
                        TVTypeEnum.HydrometricSite,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.MikeSource,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.MWQMSite,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.Province,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.Tel,
                        TVTypeEnum.TideSite,
                        TVTypeEnum.WasteWaterTreatmentPlant,
                        TVTypeEnum.LiftStation,
                        TVTypeEnum.Spill,
                        TVTypeEnum.BoxModel,
                        TVTypeEnum.VisualPlumesScenario,
                        TVTypeEnum.OtherInfrastructure,
                        TVTypeEnum.MWQMRun,
                        TVTypeEnum.MeshNode,
                        TVTypeEnum.WebTideNode,
                        TVTypeEnum.SamplingPlan,
                        TVTypeEnum.SeeOtherMunicipality,
                        TVTypeEnum.LineOverflow,
                        TVTypeEnum.MapInfo,
                        TVTypeEnum.MapInfoPoint,
                    };
                    if (!AllowableTVTypes.Contains(TVItemTVItemID3.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVItemID3", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID3" });
                    }
                }
            }

            if (tvItemUserAuthorization.TVItemID4 != null)
            {
                TVItem TVItemTVItemID4 = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    TVItemTVItemID4 = (from c in dbLocal.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID4 select c).FirstOrDefault();
                    if (TVItemTVItemID4 == null)
                    {
                        TVItemTVItemID4 = (from c in dbIM.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID4 select c).FirstOrDefault();
                    }
                }
                else
                {
                    TVItemTVItemID4 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID4 select c).FirstOrDefault();
                }

                if (TVItemTVItemID4 == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID4", (tvItemUserAuthorization.TVItemID4 == null ? "" : tvItemUserAuthorization.TVItemID4.ToString())), new[] { "TVItemID4" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Root,
                        TVTypeEnum.Address,
                        TVTypeEnum.Area,
                        TVTypeEnum.ClimateSite,
                        TVTypeEnum.Contact,
                        TVTypeEnum.Country,
                        TVTypeEnum.Email,
                        TVTypeEnum.File,
                        TVTypeEnum.HydrometricSite,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.MikeSource,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.MWQMSite,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.Province,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.Tel,
                        TVTypeEnum.TideSite,
                        TVTypeEnum.WasteWaterTreatmentPlant,
                        TVTypeEnum.LiftStation,
                        TVTypeEnum.Spill,
                        TVTypeEnum.BoxModel,
                        TVTypeEnum.VisualPlumesScenario,
                        TVTypeEnum.OtherInfrastructure,
                        TVTypeEnum.MWQMRun,
                        TVTypeEnum.MeshNode,
                        TVTypeEnum.WebTideNode,
                        TVTypeEnum.SamplingPlan,
                        TVTypeEnum.SeeOtherMunicipality,
                        TVTypeEnum.LineOverflow,
                        TVTypeEnum.MapInfo,
                        TVTypeEnum.MapInfoPoint,
                    };
                    if (!AllowableTVTypes.Contains(TVItemTVItemID4.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVItemID4", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID4" });
                    }
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVAuthEnum), (int?)tvItemUserAuthorization.TVAuth);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVAuth"), new[] { "TVAuth" });
            }

            if (tvItemUserAuthorization.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemUserAuthorization.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tvItemUserAuthorization.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == tvItemUserAuthorization.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvItemUserAuthorization.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
