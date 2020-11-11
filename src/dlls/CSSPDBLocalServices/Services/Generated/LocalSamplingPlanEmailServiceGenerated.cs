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
    public partial interface ILocalSamplingPlanEmailDBService
    {
        Task<ActionResult<bool>> Delete(int LocalSamplingPlanEmailID);
        Task<ActionResult<List<LocalSamplingPlanEmail>>> GetLocalSamplingPlanEmailList(int skip = 0, int take = 100);
        Task<ActionResult<LocalSamplingPlanEmail>> GetLocalSamplingPlanEmailWithSamplingPlanEmailID(int SamplingPlanEmailID);
        Task<ActionResult<LocalSamplingPlanEmail>> Post(LocalSamplingPlanEmail localsamplingplanemail);
        Task<ActionResult<LocalSamplingPlanEmail>> Put(LocalSamplingPlanEmail localsamplingplanemail);
    }
    public partial class LocalSamplingPlanEmailDBService : ControllerBase, ILocalSamplingPlanEmailDBService
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
        public LocalSamplingPlanEmailDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<LocalSamplingPlanEmail>> GetLocalSamplingPlanEmailWithSamplingPlanEmailID(int SamplingPlanEmailID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalSamplingPlanEmail localSamplingPlanEmail = (from c in db.LocalSamplingPlanEmails.AsNoTracking()
                    where c.SamplingPlanEmailID == SamplingPlanEmailID
                    select c).FirstOrDefault();

            if (localSamplingPlanEmail == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localSamplingPlanEmail));
        }
        public async Task<ActionResult<List<LocalSamplingPlanEmail>>> GetLocalSamplingPlanEmailList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalSamplingPlanEmail> localSamplingPlanEmailList = (from c in db.LocalSamplingPlanEmails.AsNoTracking() orderby c.SamplingPlanEmailID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localSamplingPlanEmailList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalSamplingPlanEmailID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalSamplingPlanEmail localSamplingPlanEmail = (from c in db.LocalSamplingPlanEmails
                    where c.SamplingPlanEmailID == LocalSamplingPlanEmailID
                    select c).FirstOrDefault();

            if (localSamplingPlanEmail == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalSamplingPlanEmail", "LocalSamplingPlanEmailID", LocalSamplingPlanEmailID.ToString())));
            }

            try
            {
                db.LocalSamplingPlanEmails.Remove(localSamplingPlanEmail);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalSamplingPlanEmail>> Post(LocalSamplingPlanEmail localSamplingPlanEmail)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localSamplingPlanEmail), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalSamplingPlanEmails.Add(localSamplingPlanEmail);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localSamplingPlanEmail));
        }
        public async Task<ActionResult<LocalSamplingPlanEmail>> Put(LocalSamplingPlanEmail localSamplingPlanEmail)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localSamplingPlanEmail), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalSamplingPlanEmails.Update(localSamplingPlanEmail);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localSamplingPlanEmail));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalSamplingPlanEmail localSamplingPlanEmail = validationContext.ObjectInstance as LocalSamplingPlanEmail;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localSamplingPlanEmail.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localSamplingPlanEmail.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localSamplingPlanEmail.SamplingPlanEmailID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SamplingPlanEmailID"), new[] { nameof(localSamplingPlanEmail.SamplingPlanEmailID) });
                }

                if (!(from c in db.LocalSamplingPlanEmails.AsNoTracking() select c).Where(c => c.SamplingPlanEmailID == localSamplingPlanEmail.SamplingPlanEmailID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanEmail", "SamplingPlanEmailID", localSamplingPlanEmail.SamplingPlanEmailID.ToString()), new[] { nameof(localSamplingPlanEmail.SamplingPlanEmailID) });
                }
            }

            LocalSamplingPlan localSamplingPlanSamplingPlanID = null;
            localSamplingPlanSamplingPlanID = (from c in db.LocalSamplingPlans.AsNoTracking() where c.SamplingPlanID == localSamplingPlanEmail.SamplingPlanID select c).FirstOrDefault();

            if (localSamplingPlanSamplingPlanID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalSamplingPlan", "SamplingPlanID", localSamplingPlanEmail.SamplingPlanID.ToString()), new[] { nameof(localSamplingPlanEmail.SamplingPlanID) });
            }

            if (string.IsNullOrWhiteSpace(localSamplingPlanEmail.Email))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Email"), new[] { nameof(localSamplingPlanEmail.Email) });
            }

            if (!string.IsNullOrWhiteSpace(localSamplingPlanEmail.Email) && localSamplingPlanEmail.Email.Length > 150)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Email", "150"), new[] { nameof(localSamplingPlanEmail.Email) });
            }

            if (!string.IsNullOrWhiteSpace(localSamplingPlanEmail.Email))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(localSamplingPlanEmail.Email))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotAValidEmail, "Email"), new[] { nameof(localSamplingPlanEmail.Email) });
                }
            }

            if (localSamplingPlanEmail.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localSamplingPlanEmail.LastUpdateDate_UTC) });
            }
            else
            {
                if (localSamplingPlanEmail.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localSamplingPlanEmail.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localSamplingPlanEmail.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localSamplingPlanEmail.LastUpdateContactTVItemID.ToString()), new[] { nameof(localSamplingPlanEmail.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localSamplingPlanEmail.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
