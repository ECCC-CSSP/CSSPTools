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
   public interface ISamplingPlanEmailService
    {
       Task<ActionResult<SamplingPlanEmail>> GetSamplingPlanEmailWithSamplingPlanEmailID(int SamplingPlanEmailID);
       Task<ActionResult<List<SamplingPlanEmail>>> GetSamplingPlanEmailList();
       Task<ActionResult<SamplingPlanEmail>> Add(SamplingPlanEmail samplingplanemail);
       Task<ActionResult<bool>> Delete(int SamplingPlanEmailID);
       Task<ActionResult<SamplingPlanEmail>> Update(SamplingPlanEmail samplingplanemail);
    }
    public partial class SamplingPlanEmailService : ControllerBase, ISamplingPlanEmailService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private ICultureService CultureService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailService(ICultureService CultureService, IEnums enums, CSSPDBContext db)
        {
            this.CultureService = CultureService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<SamplingPlanEmail>> GetSamplingPlanEmailWithSamplingPlanEmailID(int SamplingPlanEmailID)
        {
            SamplingPlanEmail samplingplanemail = (from c in db.SamplingPlanEmails.AsNoTracking()
                    where c.SamplingPlanEmailID == SamplingPlanEmailID
                    select c).FirstOrDefault();

            if (samplingplanemail == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(samplingplanemail));
        }
        public async Task<ActionResult<List<SamplingPlanEmail>>> GetSamplingPlanEmailList()
        {
            List<SamplingPlanEmail> samplingplanemailList = (from c in db.SamplingPlanEmails.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(samplingplanemailList));
        }
        public async Task<ActionResult<SamplingPlanEmail>> Add(SamplingPlanEmail samplingPlanEmail)
        {
            ValidationResults = Validate(new ValidationContext(samplingPlanEmail), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.SamplingPlanEmails.Add(samplingPlanEmail);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(samplingPlanEmail));
        }
        public async Task<ActionResult<bool>> Delete(int SamplingPlanEmailID)
        {
            SamplingPlanEmail samplingPlanEmail = (from c in db.SamplingPlanEmails
                               where c.SamplingPlanEmailID == SamplingPlanEmailID
                               select c).FirstOrDefault();
            
            if (samplingPlanEmail == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanEmail", "SamplingPlanEmailID", SamplingPlanEmailID.ToString())));
            }

            try
            {
               db.SamplingPlanEmails.Remove(samplingPlanEmail);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<SamplingPlanEmail>> Update(SamplingPlanEmail samplingPlanEmail)
        {
            ValidationResults = Validate(new ValidationContext(samplingPlanEmail), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.SamplingPlanEmails.Update(samplingPlanEmail);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(samplingPlanEmail));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            SamplingPlanEmail samplingPlanEmail = validationContext.ObjectInstance as SamplingPlanEmail;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (samplingPlanEmail.SamplingPlanEmailID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "SamplingPlanEmailID"), new[] { "SamplingPlanEmailID" });
                }

                if (!(from c in db.SamplingPlanEmails select c).Where(c => c.SamplingPlanEmailID == samplingPlanEmail.SamplingPlanEmailID).Any())
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanEmail", "SamplingPlanEmailID", samplingPlanEmail.SamplingPlanEmailID.ToString()), new[] { "SamplingPlanEmailID" });
                }
            }

            SamplingPlan SamplingPlanSamplingPlanID = (from c in db.SamplingPlans where c.SamplingPlanID == samplingPlanEmail.SamplingPlanID select c).FirstOrDefault();

            if (SamplingPlanSamplingPlanID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", samplingPlanEmail.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
            }

            if (string.IsNullOrWhiteSpace(samplingPlanEmail.Email))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "Email"), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlanEmail.Email) && samplingPlanEmail.Email.Length > 150)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "Email", "150"), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlanEmail.Email))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(samplingPlanEmail.Email))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotAValidEmail, "Email"), new[] { "Email" });
                }
            }

            if (samplingPlanEmail.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (samplingPlanEmail.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanEmail.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", samplingPlanEmail.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
