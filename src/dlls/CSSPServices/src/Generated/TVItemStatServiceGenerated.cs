/*
 * Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
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
   public interface ITVItemStatService
    {
       Task<ActionResult<bool>> Delete(int TVItemStatID);
       Task<ActionResult<List<TVItemStat>>> GetTVItemStatList();
       Task<ActionResult<TVItemStat>> GetTVItemStatWithTVItemStatID(int TVItemStatID);
       Task<ActionResult<TVItemStat>> Post(TVItemStat tvitemstat);
       Task<ActionResult<TVItemStat>> Put(TVItemStat tvitemstat);
    }
    public partial class TVItemStatService : ControllerBase, ITVItemStatService
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
        public TVItemStatService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<TVItemStat>> GetTVItemStatWithTVItemStatID(int TVItemStatID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                TVItemStat tvitemstat = (from c in dbLocal.TVItemStats.AsNoTracking()
                        where c.TVItemStatID == TVItemStatID
                        select c).FirstOrDefault();

                if (tvitemstat == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvitemstat));
            }
            else
            {
                TVItemStat tvitemstat = (from c in db.TVItemStats.AsNoTracking()
                        where c.TVItemStatID == TVItemStatID
                        select c).FirstOrDefault();

                if (tvitemstat == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvitemstat));
            }
        }
        public async Task<ActionResult<List<TVItemStat>>> GetTVItemStatList()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                List<TVItemStat> tvitemstatList = (from c in dbLocal.TVItemStats.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(tvitemstatList));
            }
            else
            {
                List<TVItemStat> tvitemstatList = (from c in db.TVItemStats.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(tvitemstatList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int TVItemStatID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                TVItemStat tvItemStat = (from c in dbLocal.TVItemStats
                                   where c.TVItemStatID == TVItemStatID
                                   select c).FirstOrDefault();
                
                if (tvItemStat == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItemStat", "TVItemStatID", TVItemStatID.ToString())));
                }

                try
                {
                   dbLocal.TVItemStats.Remove(tvItemStat);
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
                TVItemStat tvItemStat = (from c in db.TVItemStats
                                   where c.TVItemStatID == TVItemStatID
                                   select c).FirstOrDefault();
                
                if (tvItemStat == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItemStat", "TVItemStatID", TVItemStatID.ToString())));
                }

                try
                {
                   db.TVItemStats.Remove(tvItemStat);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<TVItemStat>> Post(TVItemStat tvItemStat)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvItemStat), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
                try
                {
                   dbLocal.TVItemStats.Add(tvItemStat);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvItemStat));
            }
            else
            {
                try
                {
                   db.TVItemStats.Add(tvItemStat);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvItemStat));
            }
        }
        public async Task<ActionResult<TVItemStat>> Put(TVItemStat tvItemStat)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvItemStat), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
            try
            {
               dbLocal.TVItemStats.Update(tvItemStat);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvItemStat));
            }
            else
            {
            try
            {
               db.TVItemStats.Update(tvItemStat);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvItemStat));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            TVItemStat tvItemStat = validationContext.ObjectInstance as TVItemStat;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvItemStat.TVItemStatID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TVItemStatID"), new[] { "TVItemStatID" });
                }

                if (LoggedInService.IsLocal)
                {
                    if (!(from c in dbLocal.TVItemStats select c).Where(c => c.TVItemStatID == tvItemStat.TVItemStatID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItemStat", "TVItemStatID", tvItemStat.TVItemStatID.ToString()), new[] { "TVItemStatID" });
                    }
                }
                else
                {
                    if (!(from c in db.TVItemStats select c).Where(c => c.TVItemStatID == tvItemStat.TVItemStatID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItemStat", "TVItemStatID", tvItemStat.TVItemStatID.ToString()), new[] { "TVItemStatID" });
                    }
                }
            }

            TVItem TVItemTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tvItemStat.TVItemID select c).FirstOrDefault();
                if (TVItemTVItemID == null)
                {
                    TVItemTVItemID = (from c in dbIM.TVItems where c.TVItemID == tvItemStat.TVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemTVItemID = (from c in db.TVItems where c.TVItemID == tvItemStat.TVItemID select c).FirstOrDefault();
            }

            if (TVItemTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", tvItemStat.TVItemID.ToString()), new[] { "TVItemID" });
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
                if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "TVItemID", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItemStat.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TVType"), new[] { "TVType" });
            }

            if (tvItemStat.ChildCount < 0 || tvItemStat.ChildCount > 10000000)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "ChildCount", "0", "10000000"), new[] { "ChildCount" });
            }

            if (tvItemStat.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemStat.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tvItemStat.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == tvItemStat.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemStat.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvItemStat.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
