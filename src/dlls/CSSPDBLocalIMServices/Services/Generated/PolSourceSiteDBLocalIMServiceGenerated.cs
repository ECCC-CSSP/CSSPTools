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
    public partial interface IPolSourceSiteDBLocalIMService
    {
        Task<ActionResult<bool>> Delete(int PolSourceSiteID);
        Task<ActionResult<List<PolSourceSite>>> GetPolSourceSiteList(int skip = 0, int take = 100);
        Task<ActionResult<PolSourceSite>> GetPolSourceSiteWithPolSourceSiteID(int PolSourceSiteID);
        Task<ActionResult<PolSourceSite>> Post(PolSourceSite polsourcesite);
        Task<ActionResult<PolSourceSite>> Put(PolSourceSite polsourcesite);
    }
    public partial class PolSourceSiteDBLocalIMService : ControllerBase, IPolSourceSiteDBLocalIMService
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
        public PolSourceSiteDBLocalIMService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<PolSourceSite>> GetPolSourceSiteWithPolSourceSiteID(int PolSourceSiteID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            PolSourceSite polSourceSite = (from c in dbLocalIM.PolSourceSites.Local
                    where c.PolSourceSiteID == PolSourceSiteID
                    select c).FirstOrDefault();

            if (polSourceSite == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(polSourceSite));
        }
        public async Task<ActionResult<List<PolSourceSite>>> GetPolSourceSiteList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<PolSourceSite> polSourceSiteList = (from c in dbLocalIM.PolSourceSites.Local orderby c.PolSourceSiteID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(polSourceSiteList));
        }
        public async Task<ActionResult<bool>> Delete(int PolSourceSiteID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            PolSourceSite polSourceSite = (from c in dbLocalIM.PolSourceSites.Local
                    where c.PolSourceSiteID == PolSourceSiteID
                    select c).FirstOrDefault();

            if (polSourceSite == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSiteID", PolSourceSiteID.ToString())));
            }

            try
            {
                dbLocalIM.PolSourceSites.Remove(polSourceSite);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<PolSourceSite>> Post(PolSourceSite polSourceSite)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceSite), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.PolSourceSites.Add(polSourceSite);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceSite));
        }
        public async Task<ActionResult<PolSourceSite>> Put(PolSourceSite polSourceSite)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceSite), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.PolSourceSites.Update(polSourceSite);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceSite));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            PolSourceSite polSourceSite = validationContext.ObjectInstance as PolSourceSite;

            if (actionDBType == ActionDBTypeEnum.Create)
            {
                if (polSourceSite.PolSourceSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceSiteID"), new[] { nameof(polSourceSite.PolSourceSiteID) });
                }
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceSite.PolSourceSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceSiteID"), new[] { nameof(polSourceSite.PolSourceSiteID) });
                }

                if (!(from c in dbLocalIM.PolSourceSites.Local select c).Where(c => c.PolSourceSiteID == polSourceSite.PolSourceSiteID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSiteID", polSourceSite.PolSourceSiteID.ToString()), new[] { nameof(polSourceSite.PolSourceSiteID) });
                }
            }

            TVItem TVItemPolSourceSiteTVItemID = null;
            TVItemPolSourceSiteTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == polSourceSite.PolSourceSiteTVItemID select c).FirstOrDefault();

            if (TVItemPolSourceSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceSiteTVItemID", polSourceSite.PolSourceSiteTVItemID.ToString()), new[] { nameof(polSourceSite.PolSourceSiteTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.PolSourceSite,
                };
                if (!AllowableTVTypes.Contains(TVItemPolSourceSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "PolSourceSiteTVItemID", "PolSourceSite"), new[] { nameof(polSourceSite.PolSourceSiteTVItemID) });
                }
            }

            if (!string.IsNullOrWhiteSpace(polSourceSite.Temp_Locator_CanDelete) && polSourceSite.Temp_Locator_CanDelete.Length > 50)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Temp_Locator_CanDelete", "50"), new[] { nameof(polSourceSite.Temp_Locator_CanDelete) });
            }

            if (polSourceSite.Oldsiteid != null)
            {
                if (polSourceSite.Oldsiteid < 0 || polSourceSite.Oldsiteid > 1000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Oldsiteid", "0", "1000"), new[] { nameof(polSourceSite.Oldsiteid) });
                }
            }

            if (polSourceSite.Site != null)
            {
                if (polSourceSite.Site < 0 || polSourceSite.Site > 1000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Site", "0", "1000"), new[] { nameof(polSourceSite.Site) });
                }
            }

            if (polSourceSite.SiteID != null)
            {
                if (polSourceSite.SiteID < 0 || polSourceSite.SiteID > 1000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SiteID", "0", "1000"), new[] { nameof(polSourceSite.SiteID) });
                }
            }

            if (polSourceSite.InactiveReason != null)
            {
                retStr = enums.EnumTypeOK(typeof(PolSourceInactiveReasonEnum), (int?)polSourceSite.InactiveReason);
                if (polSourceSite.InactiveReason == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "InactiveReason"), new[] { nameof(polSourceSite.InactiveReason) });
                }
            }

            if (polSourceSite.CivicAddressTVItemID != null)
            {
                TVItem TVItemCivicAddressTVItemID = null;
                TVItemCivicAddressTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == polSourceSite.CivicAddressTVItemID select c).FirstOrDefault();

                if (TVItemCivicAddressTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "CivicAddressTVItemID", (polSourceSite.CivicAddressTVItemID == null ? "" : polSourceSite.CivicAddressTVItemID.ToString())), new[] { nameof(polSourceSite.CivicAddressTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Address,
                    };
                    if (!AllowableTVTypes.Contains(TVItemCivicAddressTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "CivicAddressTVItemID", "Address"), new[] { nameof(polSourceSite.CivicAddressTVItemID) });
                    }
                }
            }

            if (polSourceSite.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(polSourceSite.LastUpdateDate_UTC) });
            }
            else
            {
                if (polSourceSite.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(polSourceSite.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == polSourceSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceSite.LastUpdateContactTVItemID.ToString()), new[] { nameof(polSourceSite.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(polSourceSite.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}