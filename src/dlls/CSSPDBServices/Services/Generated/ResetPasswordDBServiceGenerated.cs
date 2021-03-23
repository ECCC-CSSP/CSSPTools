/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPDBServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
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
using LoggedInServices;
using Microsoft.Extensions.Configuration;
using CSSPScrambleServices;

namespace CSSPDBServices
{
    public partial interface IResetPasswordDBService
    {
        Task<ActionResult<bool>> Delete(int ResetPasswordID);
        Task<ActionResult<List<ResetPassword>>> GetResetPasswordList(int skip = 0, int take = 100);
        Task<ActionResult<ResetPassword>> GetResetPasswordWithResetPasswordID(int ResetPasswordID);
        Task<ActionResult<ResetPassword>> Post(ResetPassword resetpassword);
        Task<ActionResult<ResetPassword>> Put(ResetPassword resetpassword);
    }
    public partial class ResetPasswordDBService : ControllerBase, IResetPasswordDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IScrambleService ScrambleService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public ResetPasswordDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ScrambleService = ScrambleService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<ResetPassword>> GetResetPasswordWithResetPasswordID(int ResetPasswordID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            ResetPassword resetPassword = (from c in db.ResetPasswords.AsNoTracking()
                    where c.ResetPasswordID == ResetPasswordID
                    select c).FirstOrDefault();

            if (resetPassword == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(resetPassword));
        }
        public async Task<ActionResult<List<ResetPassword>>> GetResetPasswordList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<ResetPassword> resetPasswordList = (from c in db.ResetPasswords.AsNoTracking() orderby c.ResetPasswordID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(resetPasswordList));
        }
        public async Task<ActionResult<bool>> Delete(int ResetPasswordID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            ResetPassword resetPassword = (from c in db.ResetPasswords
                    where c.ResetPasswordID == ResetPasswordID
                    select c).FirstOrDefault();

            if (resetPassword == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ResetPassword", "ResetPasswordID", ResetPasswordID.ToString())));
            }

            try
            {
                db.ResetPasswords.Remove(resetPassword);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<ResetPassword>> Post(ResetPassword resetPassword)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            ValidationResults = Validate(new ValidationContext(resetPassword), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.ResetPasswords.Add(resetPassword);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(resetPassword));
        }
        public async Task<ActionResult<ResetPassword>> Put(ResetPassword resetPassword)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            ValidationResults = Validate(new ValidationContext(resetPassword), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.ResetPasswords.Update(resetPassword);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(resetPassword));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            ResetPassword resetPassword = validationContext.ObjectInstance as ResetPassword;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (resetPassword.ResetPasswordID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ResetPasswordID"), new[] { nameof(resetPassword.ResetPasswordID) });
                }

                if (!(from c in db.ResetPasswords.AsNoTracking() select c).Where(c => c.ResetPasswordID == resetPassword.ResetPasswordID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ResetPassword", "ResetPasswordID", resetPassword.ResetPasswordID.ToString()), new[] { nameof(resetPassword.ResetPasswordID) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)resetPassword.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(resetPassword.DBCommand) });
            }

            if (string.IsNullOrWhiteSpace(resetPassword.Email))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Email"), new[] { nameof(resetPassword.Email) });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Email) && resetPassword.Email.Length > 256)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Email", "256"), new[] { nameof(resetPassword.Email) });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Email))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(resetPassword.Email))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotAValidEmail, "Email"), new[] { nameof(resetPassword.Email) });
                }
            }

            if (resetPassword.ExpireDate_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ExpireDate_Local"), new[] { nameof(resetPassword.ExpireDate_Local) });
            }
            else
            {
                if (resetPassword.ExpireDate_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "ExpireDate_Local", "1980"), new[] { nameof(resetPassword.ExpireDate_Local) });
                }
            }

            if (string.IsNullOrWhiteSpace(resetPassword.Code))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Code"), new[] { nameof(resetPassword.Code) });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Code) && resetPassword.Code.Length > 8)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Code", "8"), new[] { nameof(resetPassword.Code) });
            }

            if (resetPassword.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(resetPassword.LastUpdateDate_UTC) });
            }
            else
            {
                if (resetPassword.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(resetPassword.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == resetPassword.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", resetPassword.LastUpdateContactTVItemID.ToString()), new[] { nameof(resetPassword.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(resetPassword.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
