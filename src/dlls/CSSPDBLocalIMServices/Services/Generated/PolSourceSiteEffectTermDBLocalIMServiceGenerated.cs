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
using LocalServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBLocalIMServices
{
    public partial interface IPolSourceSiteEffectTermDBLocalIMService
    {
        Task<ActionResult<bool>> Delete(int PolSourceSiteEffectTermID);
        Task<ActionResult<List<PolSourceSiteEffectTerm>>> GetPolSourceSiteEffectTermList(int skip = 0, int take = 100);
        Task<ActionResult<PolSourceSiteEffectTerm>> GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermID(int PolSourceSiteEffectTermID);
        Task<ActionResult<PolSourceSiteEffectTerm>> Post(PolSourceSiteEffectTerm polsourcesiteeffectterm);
        Task<ActionResult<PolSourceSiteEffectTerm>> Put(PolSourceSiteEffectTerm polsourcesiteeffectterm);
    }
    public partial class PolSourceSiteEffectTermDBLocalIMService : ControllerBase, IPolSourceSiteEffectTermDBLocalIMService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBInMemoryContext dbLocalIM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTermDBLocalIMService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBInMemoryContext dbLocalIM)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.dbLocalIM = dbLocalIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<PolSourceSiteEffectTerm>> GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermID(int PolSourceSiteEffectTermID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            PolSourceSiteEffectTerm polSourceSiteEffectTerm = (from c in dbLocalIM.PolSourceSiteEffectTerms.AsNoTracking()
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
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<PolSourceSiteEffectTerm> polSourceSiteEffectTermList = (from c in dbLocalIM.PolSourceSiteEffectTerms.AsNoTracking() orderby c.PolSourceSiteEffectTermID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(polSourceSiteEffectTermList));
        }
        public async Task<ActionResult<bool>> Delete(int PolSourceSiteEffectTermID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            PolSourceSiteEffectTerm polSourceSiteEffectTerm = (from c in dbLocalIM.PolSourceSiteEffectTerms
                    where c.PolSourceSiteEffectTermID == PolSourceSiteEffectTermID
                    select c).FirstOrDefault();

            if (polSourceSiteEffectTerm == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffectTerm", "PolSourceSiteEffectTermID", PolSourceSiteEffectTermID.ToString())));
            }

            try
            {
                dbLocalIM.PolSourceSiteEffectTerms.Remove(polSourceSiteEffectTerm);
                dbLocalIM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Post(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceSiteEffectTerm), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.PolSourceSiteEffectTerms.Add(polSourceSiteEffectTerm);
                dbLocalIM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceSiteEffectTerm));
        }
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Put(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceSiteEffectTerm), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.PolSourceSiteEffectTerms.Update(polSourceSiteEffectTerm);
                dbLocalIM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceSiteEffectTerm));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            PolSourceSiteEffectTerm polSourceSiteEffectTerm = validationContext.ObjectInstance as PolSourceSiteEffectTerm;

            if (actionDBType == ActionDBTypeEnum.Create)
            {
                if (polSourceSiteEffectTerm.PolSourceSiteEffectTermID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceSiteEffectTermID"), new[] { nameof(polSourceSiteEffectTerm.PolSourceSiteEffectTermID) });
                }
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceSiteEffectTerm.PolSourceSiteEffectTermID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceSiteEffectTermID"), new[] { nameof(polSourceSiteEffectTerm.PolSourceSiteEffectTermID) });
                }

                if (!(from c in dbLocalIM.PolSourceSiteEffectTerms select c).Where(c => c.PolSourceSiteEffectTermID == polSourceSiteEffectTerm.PolSourceSiteEffectTermID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffectTerm", "PolSourceSiteEffectTermID", polSourceSiteEffectTerm.PolSourceSiteEffectTermID.ToString()), new[] { nameof(polSourceSiteEffectTerm.PolSourceSiteEffectTermID) });
                }
            }

            if (polSourceSiteEffectTerm.UnderGroupID != null)
            {
                PolSourceSiteEffectTerm PolSourceSiteEffectTermUnderGroupID = null;
                PolSourceSiteEffectTermUnderGroupID = (from c in dbLocalIM.PolSourceSiteEffectTerms where c.PolSourceSiteEffectTermID == polSourceSiteEffectTerm.UnderGroupID select c).FirstOrDefault();

                if (PolSourceSiteEffectTermUnderGroupID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffectTerm", "UnderGroupID", (polSourceSiteEffectTerm.UnderGroupID == null ? "" : polSourceSiteEffectTerm.UnderGroupID.ToString())), new[] { nameof(polSourceSiteEffectTerm.UnderGroupID) });
                }
            }

            if (string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermEN))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EffectTermEN"), new[] { nameof(polSourceSiteEffectTerm.EffectTermEN) });
            }

            if (!string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermEN) && polSourceSiteEffectTerm.EffectTermEN.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "EffectTermEN", "100"), new[] { nameof(polSourceSiteEffectTerm.EffectTermEN) });
            }

            if (string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermFR))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EffectTermFR"), new[] { nameof(polSourceSiteEffectTerm.EffectTermFR) });
            }

            if (!string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermFR) && polSourceSiteEffectTerm.EffectTermFR.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "EffectTermFR", "100"), new[] { nameof(polSourceSiteEffectTerm.EffectTermFR) });
            }

            if (polSourceSiteEffectTerm.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(polSourceSiteEffectTerm.LastUpdateDate_UTC) });
            }
            else
            {
                if (polSourceSiteEffectTerm.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(polSourceSiteEffectTerm.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems where c.TVItemID == polSourceSiteEffectTerm.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceSiteEffectTerm.LastUpdateContactTVItemID.ToString()), new[] { nameof(polSourceSiteEffectTerm.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(polSourceSiteEffectTerm.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
