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
   public interface ITVItemLinkService
    {
       Task<ActionResult<bool>> Delete(int TVItemLinkID);
       Task<ActionResult<List<TVItemLink>>> GetTVItemLinkList();
       Task<ActionResult<TVItemLink>> GetTVItemLinkWithTVItemLinkID(int TVItemLinkID);
       Task<ActionResult<TVItemLink>> Post(TVItemLink tvitemlink);
       Task<ActionResult<TVItemLink>> Put(TVItemLink tvitemlink);
    }
    public partial class TVItemLinkService : ControllerBase, ITVItemLinkService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLinkService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<TVItemLink>> GetTVItemLinkWithTVItemLinkID(int TVItemLinkID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItemLink tvitemlink = (from c in db.TVItemLinks.AsNoTracking()
                    where c.TVItemLinkID == TVItemLinkID
                    select c).FirstOrDefault();

            if (tvitemlink == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(tvitemlink));
        }
        public async Task<ActionResult<List<TVItemLink>>> GetTVItemLinkList()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            List<TVItemLink> tvitemlinkList = (from c in db.TVItemLinks.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(tvitemlinkList));
        }
        public async Task<ActionResult<bool>> Delete(int TVItemLinkID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItemLink tvItemLink = (from c in db.TVItemLinks
                               where c.TVItemLinkID == TVItemLinkID
                               select c).FirstOrDefault();
            
            if (tvItemLink == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItemLink", "TVItemLinkID", TVItemLinkID.ToString())));
            }

            try
            {
               db.TVItemLinks.Remove(tvItemLink);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<TVItemLink>> Post(TVItemLink tvItemLink)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvItemLink), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.TVItemLinks.Add(tvItemLink);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvItemLink));
        }
        public async Task<ActionResult<TVItemLink>> Put(TVItemLink tvItemLink)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvItemLink), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.TVItemLinks.Update(tvItemLink);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvItemLink));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            TVItemLink tvItemLink = validationContext.ObjectInstance as TVItemLink;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvItemLink.TVItemLinkID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TVItemLinkID"), new[] { "TVItemLinkID" });
                }

                if (!(from c in db.TVItemLinks select c).Where(c => c.TVItemLinkID == tvItemLink.TVItemLinkID).Any())
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItemLink", "TVItemLinkID", tvItemLink.TVItemLinkID.ToString()), new[] { "TVItemLinkID" });
                }
            }

            TVItem TVItemFromTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLink.FromTVItemID select c).FirstOrDefault();

            if (TVItemFromTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "FromTVItemID", tvItemLink.FromTVItemID.ToString()), new[] { "FromTVItemID" });
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
                if (!AllowableTVTypes.Contains(TVItemFromTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "FromTVItemID", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint"), new[] { "FromTVItemID" });
                }
            }

            TVItem TVItemToTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLink.ToTVItemID select c).FirstOrDefault();

            if (TVItemToTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ToTVItemID", tvItemLink.ToTVItemID.ToString()), new[] { "ToTVItemID" });
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
                if (!AllowableTVTypes.Contains(TVItemToTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "ToTVItemID", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint"), new[] { "ToTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItemLink.FromTVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "FromTVType"), new[] { "FromTVType" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItemLink.ToTVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "ToTVType"), new[] { "ToTVType" });
            }

            if (tvItemLink.StartDateTime_Local != null && ((DateTime)tvItemLink.StartDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_Local", "1980"), new[] { "StartDateTime_Local" });
            }

            if (tvItemLink.EndDateTime_Local != null && ((DateTime)tvItemLink.EndDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_Local", "1980"), new[] { "EndDateTime_Local" });
            }

            if (tvItemLink.StartDateTime_Local > tvItemLink.EndDateTime_Local)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._DateIsBiggerThan_, "EndDateTime_Local", "TVItemLinkStartDateTime_Local"), new[] { "EndDateTime_Local" });
            }

            if (tvItemLink.Ordinal < 0 || tvItemLink.Ordinal > 100)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "100"), new[] { "Ordinal" });
            }

            if (tvItemLink.TVLevel < 0 || tvItemLink.TVLevel > 100)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "TVLevel", "0", "100"), new[] { "TVLevel" });
            }

            if (string.IsNullOrWhiteSpace(tvItemLink.TVPath))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TVPath"), new[] { "TVPath" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLink.TVPath) && tvItemLink.TVPath.Length > 250)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "TVPath", "250"), new[] { "TVPath" });
            }

            if (tvItemLink.ParentTVItemLinkID != null)
            {
                TVItemLink TVItemLinkParentTVItemLinkID = (from c in db.TVItemLinks where c.TVItemLinkID == tvItemLink.ParentTVItemLinkID select c).FirstOrDefault();

                if (TVItemLinkParentTVItemLinkID == null)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItemLink", "ParentTVItemLinkID", (tvItemLink.ParentTVItemLinkID == null ? "" : tvItemLink.ParentTVItemLinkID.ToString())), new[] { "ParentTVItemLinkID" });
                }
            }

            if (tvItemLink.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemLink.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLink.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvItemLink.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
