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
    public partial interface ILocalPolSourceSiteEffectDBService
    {
        Task<ActionResult<bool>> Delete(int LocalPolSourceSiteEffectID);
        Task<ActionResult<List<LocalPolSourceSiteEffect>>> GetLocalPolSourceSiteEffectList(int skip = 0, int take = 100);
        Task<ActionResult<LocalPolSourceSiteEffect>> GetLocalPolSourceSiteEffectWithPolSourceSiteEffectID(int PolSourceSiteEffectID);
        Task<ActionResult<LocalPolSourceSiteEffect>> Post(LocalPolSourceSiteEffect localpolsourcesiteeffect);
        Task<ActionResult<LocalPolSourceSiteEffect>> Put(LocalPolSourceSiteEffect localpolsourcesiteeffect);
    }
    public partial class LocalPolSourceSiteEffectDBService : ControllerBase, ILocalPolSourceSiteEffectDBService
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
        public LocalPolSourceSiteEffectDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<LocalPolSourceSiteEffect>> GetLocalPolSourceSiteEffectWithPolSourceSiteEffectID(int PolSourceSiteEffectID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalPolSourceSiteEffect localPolSourceSiteEffect = (from c in db.LocalPolSourceSiteEffects.AsNoTracking()
                    where c.PolSourceSiteEffectID == PolSourceSiteEffectID
                    select c).FirstOrDefault();

            if (localPolSourceSiteEffect == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localPolSourceSiteEffect));
        }
        public async Task<ActionResult<List<LocalPolSourceSiteEffect>>> GetLocalPolSourceSiteEffectList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalPolSourceSiteEffect> localPolSourceSiteEffectList = (from c in db.LocalPolSourceSiteEffects.AsNoTracking() orderby c.PolSourceSiteEffectID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localPolSourceSiteEffectList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalPolSourceSiteEffectID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalPolSourceSiteEffect localPolSourceSiteEffect = (from c in db.LocalPolSourceSiteEffects
                    where c.PolSourceSiteEffectID == LocalPolSourceSiteEffectID
                    select c).FirstOrDefault();

            if (localPolSourceSiteEffect == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalPolSourceSiteEffect", "LocalPolSourceSiteEffectID", LocalPolSourceSiteEffectID.ToString())));
            }

            try
            {
                db.LocalPolSourceSiteEffects.Remove(localPolSourceSiteEffect);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalPolSourceSiteEffect>> Post(LocalPolSourceSiteEffect localPolSourceSiteEffect)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localPolSourceSiteEffect), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalPolSourceSiteEffects.Add(localPolSourceSiteEffect);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localPolSourceSiteEffect));
        }
        public async Task<ActionResult<LocalPolSourceSiteEffect>> Put(LocalPolSourceSiteEffect localPolSourceSiteEffect)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localPolSourceSiteEffect), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalPolSourceSiteEffects.Update(localPolSourceSiteEffect);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localPolSourceSiteEffect));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalPolSourceSiteEffect localPolSourceSiteEffect = validationContext.ObjectInstance as LocalPolSourceSiteEffect;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localPolSourceSiteEffect.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localPolSourceSiteEffect.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localPolSourceSiteEffect.PolSourceSiteEffectID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceSiteEffectID"), new[] { nameof(localPolSourceSiteEffect.PolSourceSiteEffectID) });
                }

                if (!(from c in db.LocalPolSourceSiteEffects.AsNoTracking() select c).Where(c => c.PolSourceSiteEffectID == localPolSourceSiteEffect.PolSourceSiteEffectID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffect", "PolSourceSiteEffectID", localPolSourceSiteEffect.PolSourceSiteEffectID.ToString()), new[] { nameof(localPolSourceSiteEffect.PolSourceSiteEffectID) });
                }
            }

            LocalTVItem localTVItemPolSourceSiteOrInfrastructureTVItemID = null;
            localTVItemPolSourceSiteOrInfrastructureTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localPolSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID select c).FirstOrDefault();

            if (localTVItemPolSourceSiteOrInfrastructureTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "PolSourceSiteOrInfrastructureTVItemID", localPolSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID.ToString()), new[] { nameof(localPolSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                    TVTypeEnum.PolSourceSite,
                };
                if (!AllowableTVTypes.Contains(localTVItemPolSourceSiteOrInfrastructureTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "PolSourceSiteOrInfrastructureTVItemID", "Infrastructure,PolSourceSite"), new[] { nameof(localPolSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID) });
                }
            }

            LocalTVItem localTVItemMWQMSiteTVItemID = null;
            localTVItemMWQMSiteTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localPolSourceSiteEffect.MWQMSiteTVItemID select c).FirstOrDefault();

            if (localTVItemMWQMSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "MWQMSiteTVItemID", localPolSourceSiteEffect.MWQMSiteTVItemID.ToString()), new[] { nameof(localPolSourceSiteEffect.MWQMSiteTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(localTVItemMWQMSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MWQMSiteTVItemID", "MWQMSite"), new[] { nameof(localPolSourceSiteEffect.MWQMSiteTVItemID) });
                }
            }

            if (!string.IsNullOrWhiteSpace(localPolSourceSiteEffect.PolSourceSiteEffectTermIDs) && localPolSourceSiteEffect.PolSourceSiteEffectTermIDs.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "PolSourceSiteEffectTermIDs", "250"), new[] { nameof(localPolSourceSiteEffect.PolSourceSiteEffectTermIDs) });
            }

            //Comments has no StringLength Attribute

            if (localPolSourceSiteEffect.AnalysisDocumentTVItemID != null)
            {
                LocalTVItem localTVItemAnalysisDocumentTVItemID = null;
                localTVItemAnalysisDocumentTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localPolSourceSiteEffect.AnalysisDocumentTVItemID select c).FirstOrDefault();

                if (localTVItemAnalysisDocumentTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "AnalysisDocumentTVItemID", (localPolSourceSiteEffect.AnalysisDocumentTVItemID == null ? "" : localPolSourceSiteEffect.AnalysisDocumentTVItemID.ToString())), new[] { nameof(localPolSourceSiteEffect.AnalysisDocumentTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.File,
                    };
                    if (!AllowableTVTypes.Contains(localTVItemAnalysisDocumentTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "AnalysisDocumentTVItemID", "File"), new[] { nameof(localPolSourceSiteEffect.AnalysisDocumentTVItemID) });
                    }
                }
            }

            if (localPolSourceSiteEffect.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localPolSourceSiteEffect.LastUpdateDate_UTC) });
            }
            else
            {
                if (localPolSourceSiteEffect.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localPolSourceSiteEffect.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localPolSourceSiteEffect.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localPolSourceSiteEffect.LastUpdateContactTVItemID.ToString()), new[] { nameof(localPolSourceSiteEffect.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localPolSourceSiteEffect.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
