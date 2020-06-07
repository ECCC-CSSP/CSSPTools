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
   public interface IBoxModelService
    {
       Task<ActionResult<BoxModel>> GetBoxModelWithBoxModelID(int BoxModelID);
       Task<ActionResult<List<BoxModel>>> GetBoxModelList();
       Task<ActionResult<BoxModel>> Add(BoxModel boxmodel);
       Task<ActionResult<bool>> Delete(int BoxModelID);
       Task<ActionResult<BoxModel>> Update(BoxModel boxmodel);
       Task SetCulture(CultureInfo culture);
    }
    public partial class BoxModelService : ControllerBase, IBoxModelService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<BoxModel>> GetBoxModelWithBoxModelID(int BoxModelID)
        {
            BoxModel boxmodel = (from c in db.BoxModels.AsNoTracking()
                    where c.BoxModelID == BoxModelID
                    select c).FirstOrDefault();

            if (boxmodel == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(boxmodel));
        }
        public async Task<ActionResult<List<BoxModel>>> GetBoxModelList()
        {
            List<BoxModel> boxmodelList = (from c in db.BoxModels.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(boxmodelList));
        }
        public async Task<ActionResult<BoxModel>> Add(BoxModel boxModel)
        {
            ValidationResults = Validate(new ValidationContext(boxModel), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.BoxModels.Add(boxModel);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(boxModel));
        }
        public async Task<ActionResult<bool>> Delete(int BoxModelID)
        {
            BoxModel boxModel = (from c in db.BoxModels
                               where c.BoxModelID == BoxModelID
                               select c).FirstOrDefault();
            
            if (boxModel == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelID", BoxModelID.ToString())));
            }

            try
            {
               db.BoxModels.Remove(boxModel);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<BoxModel>> Update(BoxModel boxModel)
        {
            ValidationResults = Validate(new ValidationContext(boxModel), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.BoxModels.Update(boxModel);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(boxModel));
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
            BoxModel boxModel = validationContext.ObjectInstance as BoxModel;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (boxModel.BoxModelID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "BoxModelID"), new[] { "BoxModelID" });
                }

                if (!(from c in db.BoxModels select c).Where(c => c.BoxModelID == boxModel.BoxModelID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelID", boxModel.BoxModelID.ToString()), new[] { "BoxModelID" });
                }
            }

            TVItem TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == boxModel.InfrastructureTVItemID select c).FirstOrDefault();

            if (TVItemInfrastructureTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureTVItemID", boxModel.InfrastructureTVItemID.ToString()), new[] { "InfrastructureTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                };
                if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "InfrastructureTVItemID", "Infrastructure"), new[] { "InfrastructureTVItemID" });
                }
            }

            if (boxModel.Discharge_m3_day < 0 || boxModel.Discharge_m3_day > 10000)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Discharge_m3_day", "0", "10000"), new[] { "Discharge_m3_day" });
            }

            if (boxModel.Depth_m < 0 || boxModel.Depth_m > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Depth_m", "0", "1000"), new[] { "Depth_m" });
            }

            if (boxModel.Temperature_C < -15 || boxModel.Temperature_C > 40)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Temperature_C", "-15", "40"), new[] { "Temperature_C" });
            }

            if (boxModel.Dilution < 0 || boxModel.Dilution > 10000000)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Dilution", "0", "10000000"), new[] { "Dilution" });
            }

            if (boxModel.DecayRate_per_day < 0 || boxModel.DecayRate_per_day > 100)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DecayRate_per_day", "0", "100"), new[] { "DecayRate_per_day" });
            }

            if (boxModel.FCUntreated_MPN_100ml < 0 || boxModel.FCUntreated_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "FCUntreated_MPN_100ml", "0", "10000000"), new[] { "FCUntreated_MPN_100ml" });
            }

            if (boxModel.FCPreDisinfection_MPN_100ml < 0 || boxModel.FCPreDisinfection_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "FCPreDisinfection_MPN_100ml", "0", "10000000"), new[] { "FCPreDisinfection_MPN_100ml" });
            }

            if (boxModel.Concentration_MPN_100ml < 0 || boxModel.Concentration_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Concentration_MPN_100ml", "0", "10000000"), new[] { "Concentration_MPN_100ml" });
            }

            if (boxModel.T90_hour < 0)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "T90_hour", "0"), new[] { "T90_hour" });
            }

            if (boxModel.DischargeDuration_hour < 0 || boxModel.DischargeDuration_hour > 24)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DischargeDuration_hour", "0", "24"), new[] { "DischargeDuration_hour" });
            }

            if (boxModel.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (boxModel.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == boxModel.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", boxModel.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
