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
   public interface IClassificationService
    {
       Task<ActionResult<Classification>> GetClassificationWithClassificationID(int ClassificationID);
       Task<ActionResult<List<Classification>>> GetClassificationList();
       Task<ActionResult<Classification>> Add(Classification classification);
       Task<ActionResult<bool>> Delete(int ClassificationID);
       Task<ActionResult<Classification>> Update(Classification classification);
       Task SetCulture(CultureInfo culture);
    }
    public partial class ClassificationService : ControllerBase, IClassificationService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public ClassificationService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<Classification>> GetClassificationWithClassificationID(int ClassificationID)
        {
            Classification classification = (from c in db.Classifications.AsNoTracking()
                    where c.ClassificationID == ClassificationID
                    select c).FirstOrDefault();

            if (classification == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(classification));
        }
        public async Task<ActionResult<List<Classification>>> GetClassificationList()
        {
            List<Classification> classificationList = (from c in db.Classifications.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(classificationList));
        }
        public async Task<ActionResult<Classification>> Add(Classification classification)
        {
            ValidationResults = Validate(new ValidationContext(classification), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.Classifications.Add(classification);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(classification));
        }
        public async Task<ActionResult<bool>> Delete(int ClassificationID)
        {
            Classification classification = (from c in db.Classifications
                               where c.ClassificationID == ClassificationID
                               select c).FirstOrDefault();
            
            if (classification == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Classification", "ClassificationID", ClassificationID.ToString())));
            }

            try
            {
               db.Classifications.Remove(classification);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<Classification>> Update(Classification classification)
        {
            ValidationResults = Validate(new ValidationContext(classification), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.Classifications.Update(classification);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(classification));
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
            Classification classification = validationContext.ObjectInstance as Classification;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (classification.ClassificationID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ClassificationID"), new[] { "ClassificationID" });
                }

                if (!(from c in db.Classifications select c).Where(c => c.ClassificationID == classification.ClassificationID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Classification", "ClassificationID", classification.ClassificationID.ToString()), new[] { "ClassificationID" });
                }
            }

            TVItem TVItemClassificationTVItemID = (from c in db.TVItems where c.TVItemID == classification.ClassificationTVItemID select c).FirstOrDefault();

            if (TVItemClassificationTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ClassificationTVItemID", classification.ClassificationTVItemID.ToString()), new[] { "ClassificationTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Classification,
                };
                if (!AllowableTVTypes.Contains(TVItemClassificationTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "ClassificationTVItemID", "Classification"), new[] { "ClassificationTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(ClassificationTypeEnum), (int?)classification.ClassificationType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ClassificationType"), new[] { "ClassificationType" });
            }

            if (classification.Ordinal < 0 || classification.Ordinal > 10000)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "10000"), new[] { "Ordinal" });
            }

            if (classification.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (classification.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == classification.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", classification.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
