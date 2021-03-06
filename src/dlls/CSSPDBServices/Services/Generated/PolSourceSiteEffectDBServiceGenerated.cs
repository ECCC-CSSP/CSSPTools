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
    public partial interface IPolSourceSiteEffectDBService
    {
        Task<ActionResult<bool>> Delete(int PolSourceSiteEffectID);
        Task<ActionResult<List<PolSourceSiteEffect>>> GetPolSourceSiteEffectList(int skip = 0, int take = 100);
        Task<ActionResult<PolSourceSiteEffect>> GetPolSourceSiteEffectWithPolSourceSiteEffectID(int PolSourceSiteEffectID);
        Task<ActionResult<PolSourceSiteEffect>> Post(PolSourceSiteEffect polsourcesiteeffect);
        Task<ActionResult<PolSourceSiteEffect>> Put(PolSourceSiteEffect polsourcesiteeffect);
    }
    public partial class PolSourceSiteEffectDBService : ControllerBase, IPolSourceSiteEffectDBService
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
        public PolSourceSiteEffectDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<PolSourceSiteEffect>> GetPolSourceSiteEffectWithPolSourceSiteEffectID(int PolSourceSiteEffectID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            PolSourceSiteEffect polSourceSiteEffect = (from c in db.PolSourceSiteEffects.AsNoTracking()
                    where c.PolSourceSiteEffectID == PolSourceSiteEffectID
                    select c).FirstOrDefault();

            if (polSourceSiteEffect == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(polSourceSiteEffect));
        }
        public async Task<ActionResult<List<PolSourceSiteEffect>>> GetPolSourceSiteEffectList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<PolSourceSiteEffect> polSourceSiteEffectList = (from c in db.PolSourceSiteEffects.AsNoTracking() orderby c.PolSourceSiteEffectID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(polSourceSiteEffectList));
        }
        public async Task<ActionResult<bool>> Delete(int PolSourceSiteEffectID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            PolSourceSiteEffect polSourceSiteEffect = (from c in db.PolSourceSiteEffects
                    where c.PolSourceSiteEffectID == PolSourceSiteEffectID
                    select c).FirstOrDefault();

            if (polSourceSiteEffect == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffect", "PolSourceSiteEffectID", PolSourceSiteEffectID.ToString())));
            }

            try
            {
                db.PolSourceSiteEffects.Remove(polSourceSiteEffect);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<PolSourceSiteEffect>> Post(PolSourceSiteEffect polSourceSiteEffect)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(polSourceSiteEffect), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.PolSourceSiteEffects.Add(polSourceSiteEffect);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceSiteEffect));
        }
        public async Task<ActionResult<PolSourceSiteEffect>> Put(PolSourceSiteEffect polSourceSiteEffect)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(polSourceSiteEffect), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.PolSourceSiteEffects.Update(polSourceSiteEffect);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceSiteEffect));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            PolSourceSiteEffect polSourceSiteEffect = validationContext.ObjectInstance as PolSourceSiteEffect;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceSiteEffect.PolSourceSiteEffectID == 0)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceSiteEffectID"), new[] { nameof(polSourceSiteEffect.PolSourceSiteEffectID) }));
                }

                if (!(from c in db.PolSourceSiteEffects.AsNoTracking() select c).Where(c => c.PolSourceSiteEffectID == polSourceSiteEffect.PolSourceSiteEffectID).Any())
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffect", "PolSourceSiteEffectID", polSourceSiteEffect.PolSourceSiteEffectID.ToString()), new[] { nameof(polSourceSiteEffect.PolSourceSiteEffectID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)polSourceSiteEffect.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(polSourceSiteEffect.DBCommand) }));
            }

            TVItem TVItemPolSourceSiteOrInfrastructureTVItemID = null;
            TVItemPolSourceSiteOrInfrastructureTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID select c).FirstOrDefault();

            if (TVItemPolSourceSiteOrInfrastructureTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceSiteOrInfrastructureTVItemID", polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID.ToString()), new[] { nameof(polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                    TVTypeEnum.PolSourceSite,
                };
                if (!AllowableTVTypes.Contains(TVItemPolSourceSiteOrInfrastructureTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "PolSourceSiteOrInfrastructureTVItemID", "Infrastructure,PolSourceSite"), new[] { nameof(polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID) }));
                }
            }

            TVItem TVItemMWQMSiteTVItemID = null;
            TVItemMWQMSiteTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == polSourceSiteEffect.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteTVItemID", polSourceSiteEffect.MWQMSiteTVItemID.ToString()), new[] { nameof(polSourceSiteEffect.MWQMSiteTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MWQMSiteTVItemID", "MWQMSite"), new[] { nameof(polSourceSiteEffect.MWQMSiteTVItemID) }));
                }
            }

            if (!string.IsNullOrWhiteSpace(polSourceSiteEffect.PolSourceSiteEffectTermIDs) && polSourceSiteEffect.PolSourceSiteEffectTermIDs.Length > 250)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "PolSourceSiteEffectTermIDs", "250"), new[] { nameof(polSourceSiteEffect.PolSourceSiteEffectTermIDs) }));
            }

            //Comments has no StringLength Attribute

            if (polSourceSiteEffect.AnalysisDocumentTVItemID != null)
            {
                TVItem TVItemAnalysisDocumentTVItemID = null;
                TVItemAnalysisDocumentTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == polSourceSiteEffect.AnalysisDocumentTVItemID select c).FirstOrDefault();

                if (TVItemAnalysisDocumentTVItemID == null)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "AnalysisDocumentTVItemID", (polSourceSiteEffect.AnalysisDocumentTVItemID == null ? "" : polSourceSiteEffect.AnalysisDocumentTVItemID.ToString())), new[] { nameof(polSourceSiteEffect.AnalysisDocumentTVItemID) }));
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.File,
                    };
                    if (!AllowableTVTypes.Contains(TVItemAnalysisDocumentTVItemID.TVType))
                    {
                        ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "AnalysisDocumentTVItemID", "File"), new[] { nameof(polSourceSiteEffect.AnalysisDocumentTVItemID) }));
                    }
                }
            }

            if (polSourceSiteEffect.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(polSourceSiteEffect.LastUpdateDate_UTC) }));
            }
            else
            {
                if (polSourceSiteEffect.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(polSourceSiteEffect.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == polSourceSiteEffect.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceSiteEffect.LastUpdateContactTVItemID.ToString()), new[] { nameof(polSourceSiteEffect.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(polSourceSiteEffect.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResultList.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
