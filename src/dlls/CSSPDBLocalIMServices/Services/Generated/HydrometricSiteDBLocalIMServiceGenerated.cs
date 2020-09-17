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
    public partial interface IHydrometricSiteDBLocalIMService
    {
        Task<ActionResult<bool>> Delete(int HydrometricSiteID);
        Task<ActionResult<List<HydrometricSite>>> GetHydrometricSiteList(int skip = 0, int take = 100);
        Task<ActionResult<HydrometricSite>> GetHydrometricSiteWithHydrometricSiteID(int HydrometricSiteID);
        Task<ActionResult<HydrometricSite>> Post(HydrometricSite hydrometricsite);
        Task<ActionResult<HydrometricSite>> Put(HydrometricSite hydrometricsite);
    }
    public partial class HydrometricSiteDBLocalIMService : ControllerBase, IHydrometricSiteDBLocalIMService
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
        public HydrometricSiteDBLocalIMService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<HydrometricSite>> GetHydrometricSiteWithHydrometricSiteID(int HydrometricSiteID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            HydrometricSite hydrometricSite = (from c in dbLocalIM.HydrometricSites.Local
                    where c.HydrometricSiteID == HydrometricSiteID
                    select c).FirstOrDefault();

            if (hydrometricSite == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(hydrometricSite));
        }
        public async Task<ActionResult<List<HydrometricSite>>> GetHydrometricSiteList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<HydrometricSite> hydrometricSiteList = (from c in dbLocalIM.HydrometricSites.Local orderby c.HydrometricSiteID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(hydrometricSiteList));
        }
        public async Task<ActionResult<bool>> Delete(int HydrometricSiteID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            HydrometricSite hydrometricSite = (from c in dbLocalIM.HydrometricSites.Local
                    where c.HydrometricSiteID == HydrometricSiteID
                    select c).FirstOrDefault();

            if (hydrometricSite == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricSiteID", HydrometricSiteID.ToString())));
            }

            try
            {
                dbLocalIM.HydrometricSites.Remove(hydrometricSite);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<HydrometricSite>> Post(HydrometricSite hydrometricSite)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(hydrometricSite), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.HydrometricSites.Add(hydrometricSite);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(hydrometricSite));
        }
        public async Task<ActionResult<HydrometricSite>> Put(HydrometricSite hydrometricSite)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(hydrometricSite), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.HydrometricSites.Update(hydrometricSite);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(hydrometricSite));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            HydrometricSite hydrometricSite = validationContext.ObjectInstance as HydrometricSite;

            if (actionDBType == ActionDBTypeEnum.Create)
            {
                if (hydrometricSite.HydrometricSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "HydrometricSiteID"), new[] { nameof(hydrometricSite.HydrometricSiteID) });
                }
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (hydrometricSite.HydrometricSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "HydrometricSiteID"), new[] { nameof(hydrometricSite.HydrometricSiteID) });
                }

                if (!(from c in dbLocalIM.HydrometricSites.Local select c).Where(c => c.HydrometricSiteID == hydrometricSite.HydrometricSiteID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricSiteID", hydrometricSite.HydrometricSiteID.ToString()), new[] { nameof(hydrometricSite.HydrometricSiteID) });
                }
            }

            TVItem TVItemHydrometricSiteTVItemID = null;
            TVItemHydrometricSiteTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == hydrometricSite.HydrometricSiteTVItemID select c).FirstOrDefault();

            if (TVItemHydrometricSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "HydrometricSiteTVItemID", hydrometricSite.HydrometricSiteTVItemID.ToString()), new[] { nameof(hydrometricSite.HydrometricSiteTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.HydrometricSite,
                };
                if (!AllowableTVTypes.Contains(TVItemHydrometricSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "HydrometricSiteTVItemID", "HydrometricSite"), new[] { nameof(hydrometricSite.HydrometricSiteTVItemID) });
                }
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.FedSiteNumber) && hydrometricSite.FedSiteNumber.Length > 7)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "FedSiteNumber", "7"), new[] { nameof(hydrometricSite.FedSiteNumber) });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.QuebecSiteNumber) && hydrometricSite.QuebecSiteNumber.Length > 7)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "QuebecSiteNumber", "7"), new[] { nameof(hydrometricSite.QuebecSiteNumber) });
            }

            if (string.IsNullOrWhiteSpace(hydrometricSite.HydrometricSiteName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "HydrometricSiteName"), new[] { nameof(hydrometricSite.HydrometricSiteName) });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.HydrometricSiteName) && hydrometricSite.HydrometricSiteName.Length > 200)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "HydrometricSiteName", "200"), new[] { nameof(hydrometricSite.HydrometricSiteName) });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.Description) && hydrometricSite.Description.Length > 200)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Description", "200"), new[] { nameof(hydrometricSite.Description) });
            }

            if (string.IsNullOrWhiteSpace(hydrometricSite.Province))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Province"), new[] { nameof(hydrometricSite.Province) });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.Province) && hydrometricSite.Province.Length > 4)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Province", "4"), new[] { nameof(hydrometricSite.Province) });
            }

            if (hydrometricSite.Elevation_m != null)
            {
                if (hydrometricSite.Elevation_m < 0 || hydrometricSite.Elevation_m > 10000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Elevation_m", "0", "10000"), new[] { nameof(hydrometricSite.Elevation_m) });
                }
            }

            if (hydrometricSite.StartDate_Local != null && ((DateTime)hydrometricSite.StartDate_Local).Year < 1849)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDate_Local", "1849"), new[] { nameof(hydrometricSite.StartDate_Local) });
            }

            if (hydrometricSite.EndDate_Local != null && ((DateTime)hydrometricSite.EndDate_Local).Year < 1849)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDate_Local", "1849"), new[] { nameof(hydrometricSite.EndDate_Local) });
            }

            if (hydrometricSite.StartDate_Local > hydrometricSite.EndDate_Local)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, "EndDate_Local", "HydrometricSiteStartDate_Local"), new[] { nameof(hydrometricSite.EndDate_Local) });
            }

            if (hydrometricSite.TimeOffset_hour != null)
            {
                if (hydrometricSite.TimeOffset_hour < -10 || hydrometricSite.TimeOffset_hour > 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TimeOffset_hour", "-10", "0"), new[] { nameof(hydrometricSite.TimeOffset_hour) });
                }
            }

            if (hydrometricSite.DrainageArea_km2 != null)
            {
                if (hydrometricSite.DrainageArea_km2 < 0 || hydrometricSite.DrainageArea_km2 > 1000000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DrainageArea_km2", "0", "1000000"), new[] { nameof(hydrometricSite.DrainageArea_km2) });
                }
            }

            if (hydrometricSite.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(hydrometricSite.LastUpdateDate_UTC) });
            }
            else
            {
                if (hydrometricSite.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(hydrometricSite.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == hydrometricSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", hydrometricSite.LastUpdateContactTVItemID.ToString()), new[] { nameof(hydrometricSite.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(hydrometricSite.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}