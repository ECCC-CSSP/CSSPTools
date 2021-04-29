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

namespace CSSPDBServices
{
    public partial interface IPolSourceSiteEffectTermDBService
    {
        Task<ActionResult<bool>> Delete(int PolSourceSiteEffectTermID);
        Task<ActionResult<List<PolSourceSiteEffectTerm>>> GetPolSourceSiteEffectTermList(int skip = 0, int take = 100);
        Task<ActionResult<PolSourceSiteEffectTerm>> GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermID(int PolSourceSiteEffectTermID);
        Task<ActionResult<PolSourceSiteEffectTerm>> Post(PolSourceSiteEffectTerm polsourcesiteeffectterm);
        Task<ActionResult<PolSourceSiteEffectTerm>> Put(PolSourceSiteEffectTerm polsourcesiteeffectterm);
    }
    public partial class PolSourceSiteEffectTermDBService : ControllerBase, IPolSourceSiteEffectTermDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResultList { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTermDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;

            ValidationResultList = new List<ValidationResult>();
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<PolSourceSiteEffectTerm>> GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermID(int PolSourceSiteEffectTermID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            PolSourceSiteEffectTerm polSourceSiteEffectTerm = (from c in db.PolSourceSiteEffectTerms.AsNoTracking()
                    where c.PolSourceSiteEffectTermID == PolSourceSiteEffectTermID
                    select c).FirstOrDefault();

            if (polSourceSiteEffectTerm == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(polSourceSiteEffectTerm));
        }
        public async Task<ActionResult<List<PolSourceSiteEffectTerm>>> GetPolSourceSiteEffectTermList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<PolSourceSiteEffectTerm> polSourceSiteEffectTermList = (from c in db.PolSourceSiteEffectTerms.AsNoTracking() orderby c.PolSourceSiteEffectTermID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(polSourceSiteEffectTermList));
        }
        public async Task<ActionResult<bool>> Delete(int PolSourceSiteEffectTermID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            PolSourceSiteEffectTerm polSourceSiteEffectTerm = (from c in db.PolSourceSiteEffectTerms
                    where c.PolSourceSiteEffectTermID == PolSourceSiteEffectTermID
                    select c).FirstOrDefault();

            if (polSourceSiteEffectTerm == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffectTerm", "PolSourceSiteEffectTermID", PolSourceSiteEffectTermID.ToString())));
            }

            try
            {
                db.PolSourceSiteEffectTerms.Remove(polSourceSiteEffectTerm);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Post(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(polSourceSiteEffectTerm), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.PolSourceSiteEffectTerms.Add(polSourceSiteEffectTerm);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceSiteEffectTerm));
        }
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Put(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(polSourceSiteEffectTerm), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.PolSourceSiteEffectTerms.Update(polSourceSiteEffectTerm);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceSiteEffectTerm));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            PolSourceSiteEffectTerm polSourceSiteEffectTerm = validationContext.ObjectInstance as PolSourceSiteEffectTerm;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceSiteEffectTerm.PolSourceSiteEffectTermID == 0)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceSiteEffectTermID"), new[] { nameof(polSourceSiteEffectTerm.PolSourceSiteEffectTermID) }));
                }

                if (!(from c in db.PolSourceSiteEffectTerms.AsNoTracking() select c).Where(c => c.PolSourceSiteEffectTermID == polSourceSiteEffectTerm.PolSourceSiteEffectTermID).Any())
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffectTerm", "PolSourceSiteEffectTermID", polSourceSiteEffectTerm.PolSourceSiteEffectTermID.ToString()), new[] { nameof(polSourceSiteEffectTerm.PolSourceSiteEffectTermID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)polSourceSiteEffectTerm.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(polSourceSiteEffectTerm.DBCommand) }));
            }

            if (polSourceSiteEffectTerm.UnderGroupID != null)
            {
                PolSourceSiteEffectTerm PolSourceSiteEffectTermUnderGroupID = null;
                PolSourceSiteEffectTermUnderGroupID = (from c in db.PolSourceSiteEffectTerms.AsNoTracking() where c.PolSourceSiteEffectTermID == polSourceSiteEffectTerm.UnderGroupID select c).FirstOrDefault();

                if (PolSourceSiteEffectTermUnderGroupID == null)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffectTerm", "UnderGroupID", (polSourceSiteEffectTerm.UnderGroupID == null ? "" : polSourceSiteEffectTerm.UnderGroupID.ToString())), new[] { nameof(polSourceSiteEffectTerm.UnderGroupID) }));
                }
            }

            if (string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermEN))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EffectTermEN"), new[] { nameof(polSourceSiteEffectTerm.EffectTermEN) }));
            }

            if (!string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermEN) && polSourceSiteEffectTerm.EffectTermEN.Length > 100)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "EffectTermEN", "100"), new[] { nameof(polSourceSiteEffectTerm.EffectTermEN) }));
            }

            if (string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermFR))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EffectTermFR"), new[] { nameof(polSourceSiteEffectTerm.EffectTermFR) }));
            }

            if (!string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermFR) && polSourceSiteEffectTerm.EffectTermFR.Length > 100)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "EffectTermFR", "100"), new[] { nameof(polSourceSiteEffectTerm.EffectTermFR) }));
            }

            if (polSourceSiteEffectTerm.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(polSourceSiteEffectTerm.LastUpdateDate_UTC) }));
            }
            else
            {
                if (polSourceSiteEffectTerm.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(polSourceSiteEffectTerm.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == polSourceSiteEffectTerm.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceSiteEffectTerm.LastUpdateContactTVItemID.ToString()), new[] { nameof(polSourceSiteEffectTerm.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(polSourceSiteEffectTerm.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResultList.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
