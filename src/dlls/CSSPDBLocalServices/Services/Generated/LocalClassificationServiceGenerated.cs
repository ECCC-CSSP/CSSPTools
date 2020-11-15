/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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
using LocalServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBLocalServices
{
    public partial interface ILocalClassificationDBService
    {
        Task<ActionResult<bool>> Delete(int LocalClassificationID);
        Task<ActionResult<List<LocalClassification>>> GetLocalClassificationList(int skip = 0, int take = 100);
        Task<ActionResult<LocalClassification>> GetLocalClassificationWithClassificationID(int ClassificationID);
        Task<ActionResult<LocalClassification>> Post(LocalClassification localclassification);
        Task<ActionResult<LocalClassification>> Put(LocalClassification localclassification);
    }
    public partial class LocalClassificationDBService : ControllerBase, ILocalClassificationDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LocalClassificationDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<LocalClassification>> GetLocalClassificationWithClassificationID(int ClassificationID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalClassification localClassification = (from c in db.LocalClassifications.AsNoTracking()
                    where c.ClassificationID == ClassificationID
                    select c).FirstOrDefault();

            if (localClassification == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localClassification));
        }
        public async Task<ActionResult<List<LocalClassification>>> GetLocalClassificationList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalClassification> localClassificationList = (from c in db.LocalClassifications.AsNoTracking() orderby c.ClassificationID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localClassificationList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalClassificationID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalClassification localClassification = (from c in db.LocalClassifications
                    where c.ClassificationID == LocalClassificationID
                    select c).FirstOrDefault();

            if (localClassification == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalClassification", "LocalClassificationID", LocalClassificationID.ToString())));
            }

            try
            {
                db.LocalClassifications.Remove(localClassification);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalClassification>> Post(LocalClassification localClassification)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localClassification), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalClassifications.Add(localClassification);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localClassification));
        }
        public async Task<ActionResult<LocalClassification>> Put(LocalClassification localClassification)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localClassification), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalClassifications.Update(localClassification);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localClassification));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalClassification localClassification = validationContext.ObjectInstance as LocalClassification;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localClassification.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localClassification.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localClassification.ClassificationID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ClassificationID"), new[] { nameof(localClassification.ClassificationID) });
                }

                if (!(from c in db.LocalClassifications.AsNoTracking() select c).Where(c => c.ClassificationID == localClassification.ClassificationID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Classification", "ClassificationID", localClassification.ClassificationID.ToString()), new[] { nameof(localClassification.ClassificationID) });
                }
            }

            LocalTVItem localTVItemClassificationTVItemID = null;
            localTVItemClassificationTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localClassification.ClassificationTVItemID select c).FirstOrDefault();

            if (localTVItemClassificationTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "ClassificationTVItemID", localClassification.ClassificationTVItemID.ToString()), new[] { nameof(localClassification.ClassificationTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Classification,
                };
                if (!AllowableTVTypes.Contains(localTVItemClassificationTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ClassificationTVItemID", "Classification"), new[] { nameof(localClassification.ClassificationTVItemID) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(ClassificationTypeEnum), (int?)localClassification.ClassificationType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ClassificationType"), new[] { nameof(localClassification.ClassificationType) });
            }

            if (localClassification.Ordinal < 0 || localClassification.Ordinal > 10000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "10000"), new[] { nameof(localClassification.Ordinal) });
            }

            if (localClassification.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localClassification.LastUpdateDate_UTC) });
            }
            else
            {
                if (localClassification.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localClassification.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localClassification.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localClassification.LastUpdateContactTVItemID.ToString()), new[] { nameof(localClassification.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localClassification.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}