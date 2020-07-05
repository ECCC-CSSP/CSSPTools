/*
 * Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
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
   public interface IClassificationService
    {
       Task<ActionResult<bool>> Delete(int ClassificationID);
       Task<ActionResult<List<Classification>>> GetClassificationList();
       Task<ActionResult<Classification>> GetClassificationWithClassificationID(int ClassificationID);
       Task<ActionResult<Classification>> Post(Classification classification);
       Task<ActionResult<Classification>> Put(Classification classification);
    }
    public partial class ClassificationService : ControllerBase, IClassificationService
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
        public ClassificationService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<Classification>> GetClassificationWithClassificationID(int ClassificationID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                Classification classification = (from c in dbLocal.Classifications.AsNoTracking()
                        where c.ClassificationID == ClassificationID
                        select c).FirstOrDefault();

                if (classification == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(classification));
            }
            else
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
        }
        public async Task<ActionResult<List<Classification>>> GetClassificationList()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                List<Classification> classificationList = (from c in dbLocal.Classifications.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(classificationList));
            }
            else
            {
                List<Classification> classificationList = (from c in db.Classifications.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(classificationList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int ClassificationID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                Classification classification = (from c in dbLocal.Classifications
                                   where c.ClassificationID == ClassificationID
                                   select c).FirstOrDefault();
                
                if (classification == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Classification", "ClassificationID", ClassificationID.ToString())));
                }

                try
                {
                   dbLocal.Classifications.Remove(classification);
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
                Classification classification = (from c in db.Classifications
                                   where c.ClassificationID == ClassificationID
                                   select c).FirstOrDefault();
                
                if (classification == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Classification", "ClassificationID", ClassificationID.ToString())));
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
        }
        public async Task<ActionResult<Classification>> Post(Classification classification)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(classification), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
                try
                {
                   dbLocal.Classifications.Add(classification);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(classification));
            }
            else
            {
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
        }
        public async Task<ActionResult<Classification>> Put(Classification classification)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(classification), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
            try
            {
               dbLocal.Classifications.Update(classification);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(classification));
            }
            else
            {
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
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "ClassificationID"), new[] { "ClassificationID" });
                }

                if (LoggedInService.IsLocal)
                {
                    if (!(from c in dbLocal.Classifications select c).Where(c => c.ClassificationID == classification.ClassificationID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Classification", "ClassificationID", classification.ClassificationID.ToString()), new[] { "ClassificationID" });
                    }
                }
                else
                {
                    if (!(from c in db.Classifications select c).Where(c => c.ClassificationID == classification.ClassificationID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Classification", "ClassificationID", classification.ClassificationID.ToString()), new[] { "ClassificationID" });
                    }
                }
            }

            TVItem TVItemClassificationTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemClassificationTVItemID = (from c in dbLocal.TVItems where c.TVItemID == classification.ClassificationTVItemID select c).FirstOrDefault();
                if (TVItemClassificationTVItemID == null)
                {
                    TVItemClassificationTVItemID = (from c in dbIM.TVItems where c.TVItemID == classification.ClassificationTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemClassificationTVItemID = (from c in db.TVItems where c.TVItemID == classification.ClassificationTVItemID select c).FirstOrDefault();
            }

            if (TVItemClassificationTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ClassificationTVItemID", classification.ClassificationTVItemID.ToString()), new[] { "ClassificationTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Classification,
                };
                if (!AllowableTVTypes.Contains(TVItemClassificationTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "ClassificationTVItemID", "Classification"), new[] { "ClassificationTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(ClassificationTypeEnum), (int?)classification.ClassificationType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "ClassificationType"), new[] { "ClassificationType" });
            }

            if (classification.Ordinal < 0 || classification.Ordinal > 10000)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "10000"), new[] { "Ordinal" });
            }

            if (classification.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (classification.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == classification.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == classification.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == classification.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", classification.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
