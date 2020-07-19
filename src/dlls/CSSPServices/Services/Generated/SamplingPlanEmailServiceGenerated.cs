/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
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

namespace CSSPServices
{
   public partial interface ISamplingPlanEmailService
    {
       Task<ActionResult<bool>> Delete(int SamplingPlanEmailID);
       Task<ActionResult<List<SamplingPlanEmail>>> GetSamplingPlanEmailList(int skip = 0, int take = 100);
       Task<ActionResult<SamplingPlanEmail>> GetSamplingPlanEmailWithSamplingPlanEmailID(int SamplingPlanEmailID);
       Task<ActionResult<SamplingPlanEmail>> Post(SamplingPlanEmail samplingplanemail);
       Task<ActionResult<SamplingPlanEmail>> Put(SamplingPlanEmail samplingplanemail);
    }
    public partial class SamplingPlanEmailService : ControllerBase, ISamplingPlanEmailService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<SamplingPlanEmail>> GetSamplingPlanEmailWithSamplingPlanEmailID(int SamplingPlanEmailID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                SamplingPlanEmail samplingPlanEmail = (from c in dbIM.SamplingPlanEmails.AsNoTracking()
                                   where c.SamplingPlanEmailID == SamplingPlanEmailID
                                   select c).FirstOrDefault();

                if (samplingPlanEmail == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(samplingPlanEmail));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                SamplingPlanEmail samplingPlanEmail = (from c in dbLocal.SamplingPlanEmails.AsNoTracking()
                        where c.SamplingPlanEmailID == SamplingPlanEmailID
                        select c).FirstOrDefault();

                if (samplingPlanEmail == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(samplingPlanEmail));
            }
            else
            {
                SamplingPlanEmail samplingPlanEmail = (from c in db.SamplingPlanEmails.AsNoTracking()
                        where c.SamplingPlanEmailID == SamplingPlanEmailID
                        select c).FirstOrDefault();

                if (samplingPlanEmail == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(samplingPlanEmail));
            }
        }
        public async Task<ActionResult<List<SamplingPlanEmail>>> GetSamplingPlanEmailList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<SamplingPlanEmail> samplingPlanEmailList = (from c in dbIM.SamplingPlanEmails.AsNoTracking() orderby c.SamplingPlanEmailID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(samplingPlanEmailList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<SamplingPlanEmail> samplingPlanEmailList = (from c in dbLocal.SamplingPlanEmails.AsNoTracking() orderby c.SamplingPlanEmailID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(samplingPlanEmailList));
            }
            else
            {
                List<SamplingPlanEmail> samplingPlanEmailList = (from c in db.SamplingPlanEmails.AsNoTracking() orderby c.SamplingPlanEmailID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(samplingPlanEmailList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int SamplingPlanEmailID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                SamplingPlanEmail samplingPlanEmail = (from c in dbIM.SamplingPlanEmails
                                   where c.SamplingPlanEmailID == SamplingPlanEmailID
                                   select c).FirstOrDefault();
            
                if (samplingPlanEmail == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanEmail", "SamplingPlanEmailID", SamplingPlanEmailID.ToString())));
                }
            
                try
                {
                    dbIM.SamplingPlanEmails.Remove(samplingPlanEmail);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }
            
                return await Task.FromResult(Ok(true));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                SamplingPlanEmail samplingPlanEmail = (from c in dbLocal.SamplingPlanEmails
                                   where c.SamplingPlanEmailID == SamplingPlanEmailID
                                   select c).FirstOrDefault();
                
                if (samplingPlanEmail == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanEmail", "SamplingPlanEmailID", SamplingPlanEmailID.ToString())));
                }

                try
                {
                   dbLocal.SamplingPlanEmails.Remove(samplingPlanEmail);
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
                SamplingPlanEmail samplingPlanEmail = (from c in db.SamplingPlanEmails
                                   where c.SamplingPlanEmailID == SamplingPlanEmailID
                                   select c).FirstOrDefault();
                
                if (samplingPlanEmail == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanEmail", "SamplingPlanEmailID", SamplingPlanEmailID.ToString())));
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
        }
        public async Task<ActionResult<SamplingPlanEmail>> Post(SamplingPlanEmail samplingPlanEmail)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(samplingPlanEmail), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.SamplingPlanEmails.Add(samplingPlanEmail);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(samplingPlanEmail));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.SamplingPlanEmails.Add(samplingPlanEmail);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(samplingPlanEmail));
            }
            else
            {
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
        }
        public async Task<ActionResult<SamplingPlanEmail>> Put(SamplingPlanEmail samplingPlanEmail)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(samplingPlanEmail), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.SamplingPlanEmails.Update(samplingPlanEmail);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(samplingPlanEmail));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.SamplingPlanEmails.Update(samplingPlanEmail);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(samplingPlanEmail));
            }
            else
            {
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
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SamplingPlanEmailID"), new[] { "SamplingPlanEmailID" });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.SamplingPlanEmails select c).Where(c => c.SamplingPlanEmailID == samplingPlanEmail.SamplingPlanEmailID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanEmail", "SamplingPlanEmailID", samplingPlanEmail.SamplingPlanEmailID.ToString()), new[] { "SamplingPlanEmailID" });
                    }
                }
                else
                {
                    if (!(from c in db.SamplingPlanEmails select c).Where(c => c.SamplingPlanEmailID == samplingPlanEmail.SamplingPlanEmailID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlanEmail", "SamplingPlanEmailID", samplingPlanEmail.SamplingPlanEmailID.ToString()), new[] { "SamplingPlanEmailID" });
                    }
                }
            }

            SamplingPlan SamplingPlanSamplingPlanID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                SamplingPlanSamplingPlanID = (from c in dbLocal.SamplingPlans where c.SamplingPlanID == samplingPlanEmail.SamplingPlanID select c).FirstOrDefault();
                if (SamplingPlanSamplingPlanID == null)
                {
                    SamplingPlanSamplingPlanID = (from c in dbIM.SamplingPlans where c.SamplingPlanID == samplingPlanEmail.SamplingPlanID select c).FirstOrDefault();
                }
            }
            else
            {
                SamplingPlanSamplingPlanID = (from c in db.SamplingPlans where c.SamplingPlanID == samplingPlanEmail.SamplingPlanID select c).FirstOrDefault();
            }

            if (SamplingPlanSamplingPlanID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", samplingPlanEmail.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
            }

            if (string.IsNullOrWhiteSpace(samplingPlanEmail.Email))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Email"), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlanEmail.Email) && samplingPlanEmail.Email.Length > 150)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Email", "150"), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlanEmail.Email))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(samplingPlanEmail.Email))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotAValidEmail, "Email"), new[] { "Email" });
                }
            }

            if (samplingPlanEmail.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (samplingPlanEmail.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == samplingPlanEmail.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == samplingPlanEmail.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanEmail.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", samplingPlanEmail.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
