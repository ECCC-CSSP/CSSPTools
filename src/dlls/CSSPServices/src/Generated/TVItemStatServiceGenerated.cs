/*
 * Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
   public interface ITVItemStatService
    {
       Task<ActionResult<TVItemStat>> GetTVItemStatWithTVItemStatID(int TVItemStatID);
       Task<ActionResult<List<TVItemStat>>> GetTVItemStatList();
       Task<ActionResult<TVItemStat>> Add(TVItemStat tvitemstat);
       Task<ActionResult<TVItemStat>> Delete(TVItemStat tvitemstat);
       Task<ActionResult<TVItemStat>> Update(TVItemStat tvitemstat);
       Task SetCulture(CultureInfo culture);
    }
    public partial class TVItemStatService : ControllerBase, ITVItemStatService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public TVItemStatService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<TVItemStat>> GetTVItemStatWithTVItemStatID(int TVItemStatID)
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
        public async Task<ActionResult<List<TVItemStat>>> GetTVItemStatList()
        {
            List<TVItemStat> tvitemstatList = (from c in db.TVItemStats.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(tvitemstatList));
        }
        public async Task<ActionResult<TVItemStat>> Add(TVItemStat tvItemStat)
        {
            tvItemStat.ValidationResults = Validate(new ValidationContext(tvItemStat), ActionDBTypeEnum.Create);
            if (tvItemStat.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(tvItemStat.ValidationResults));
            }

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
        public async Task<ActionResult<TVItemStat>> Delete(TVItemStat tvItemStat)
        {
            tvItemStat.ValidationResults = Validate(new ValidationContext(tvItemStat), ActionDBTypeEnum.Delete);
            if (tvItemStat.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(tvItemStat.ValidationResults));
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

            return await Task.FromResult(Ok(tvItemStat));
        }
        public async Task<ActionResult<TVItemStat>> Update(TVItemStat tvItemStat)
        {
            tvItemStat.ValidationResults = Validate(new ValidationContext(tvItemStat), ActionDBTypeEnum.Update);
            if (tvItemStat.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(tvItemStat.ValidationResults));
            }

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
        public async Task SetCulture(CultureInfo culture)
        {
            CSSPServicesRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            TVItemStat tvItemStat = validationContext.ObjectInstance as TVItemStat;
            tvItemStat.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvItemStat.TVItemStatID == 0)
                {
                    tvItemStat.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemStatID"), new[] { "TVItemStatID" });
                }

                if (!(from c in db.TVItemStats select c).Where(c => c.TVItemStatID == tvItemStat.TVItemStatID).Any())
                {
                    tvItemStat.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItemStat", "TVItemStatID", tvItemStat.TVItemStatID.ToString()), new[] { "TVItemStatID" });
                }
            }

            TVItem TVItemTVItemID = (from c in db.TVItems where c.TVItemID == tvItemStat.TVItemID select c).FirstOrDefault();

            if (TVItemTVItemID == null)
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", tvItemStat.TVItemID.ToString()), new[] { "TVItemID" });
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
                    tvItemStat.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemID", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItemStat.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVType"), new[] { "TVType" });
            }

            if (tvItemStat.ChildCount < 0 || tvItemStat.ChildCount > 10000000)
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ChildCount", "0", "10000000"), new[] { "ChildCount" });
            }

            if (tvItemStat.LastUpdateDate_UTC.Year == 1)
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemStat.LastUpdateDate_UTC.Year < 1980)
                {
                tvItemStat.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemStat.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvItemStat.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tvItemStat.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions private

    }
}
