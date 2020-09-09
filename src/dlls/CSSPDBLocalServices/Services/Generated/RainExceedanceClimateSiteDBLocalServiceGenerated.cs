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

namespace CSSPDBLocalServices
{
    public partial interface IRainExceedanceClimateSiteDBLocalService
    {
        Task<ActionResult<bool>> Delete(int RainExceedanceClimateSiteID);
        Task<ActionResult<List<RainExceedanceClimateSite>>> GetRainExceedanceClimateSiteList(int skip = 0, int take = 100);
        Task<ActionResult<RainExceedanceClimateSite>> GetRainExceedanceClimateSiteWithRainExceedanceClimateSiteID(int RainExceedanceClimateSiteID);
        Task<ActionResult<RainExceedanceClimateSite>> Post(RainExceedanceClimateSite rainexceedanceclimatesite);
        Task<ActionResult<RainExceedanceClimateSite>> Put(RainExceedanceClimateSite rainexceedanceclimatesite);
    }
    public partial class RainExceedanceClimateSiteDBLocalService : ControllerBase, IRainExceedanceClimateSiteDBLocalService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBInMemoryContext dbLocalIM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public RainExceedanceClimateSiteDBLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext dbLocal,
           CSSPDBInMemoryContext dbLocalIM)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.dbLocal = dbLocal;
            this.dbLocalIM = dbLocalIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<RainExceedanceClimateSite>> GetRainExceedanceClimateSiteWithRainExceedanceClimateSiteID(int RainExceedanceClimateSiteID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            RainExceedanceClimateSite rainExceedanceClimateSite = (from c in dbLocal.RainExceedanceClimateSites.AsNoTracking()
                    where c.RainExceedanceClimateSiteID == RainExceedanceClimateSiteID
                    select c).FirstOrDefault();

            if (rainExceedanceClimateSite == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(rainExceedanceClimateSite));
        }
        public async Task<ActionResult<List<RainExceedanceClimateSite>>> GetRainExceedanceClimateSiteList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<RainExceedanceClimateSite> rainExceedanceClimateSiteList = (from c in dbLocal.RainExceedanceClimateSites.AsNoTracking() orderby c.RainExceedanceClimateSiteID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(rainExceedanceClimateSiteList));
        }
        public async Task<ActionResult<bool>> Delete(int RainExceedanceClimateSiteID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            RainExceedanceClimateSite rainExceedanceClimateSite = (from c in dbLocal.RainExceedanceClimateSites.Local
                    where c.RainExceedanceClimateSiteID == RainExceedanceClimateSiteID
                    select c).FirstOrDefault();

            if (rainExceedanceClimateSite == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "RainExceedanceClimateSite", "RainExceedanceClimateSiteID", RainExceedanceClimateSiteID.ToString())));
            }

            try
            {
                dbLocal.RainExceedanceClimateSites.Remove(rainExceedanceClimateSite);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<RainExceedanceClimateSite>> Post(RainExceedanceClimateSite rainExceedanceClimateSite)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(rainExceedanceClimateSite), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (rainExceedanceClimateSite.RainExceedanceClimateSiteID == 0)
            {
                int LastRainExceedanceClimateSiteID = (from c in dbLocal.RainExceedanceClimateSites.AsNoTracking()
                          orderby c.RainExceedanceClimateSiteID descending
                          select c.RainExceedanceClimateSiteID).FirstOrDefault();

                rainExceedanceClimateSite.RainExceedanceClimateSiteID = LastRainExceedanceClimateSiteID + 1;
            }

            try
            {
                dbLocal.RainExceedanceClimateSites.Add(rainExceedanceClimateSite);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(rainExceedanceClimateSite));
        }
        public async Task<ActionResult<RainExceedanceClimateSite>> Put(RainExceedanceClimateSite rainExceedanceClimateSite)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(rainExceedanceClimateSite), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocal.RainExceedanceClimateSites.Update(rainExceedanceClimateSite);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(rainExceedanceClimateSite));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            RainExceedanceClimateSite rainExceedanceClimateSite = validationContext.ObjectInstance as RainExceedanceClimateSite;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (rainExceedanceClimateSite.RainExceedanceClimateSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RainExceedanceClimateSiteID"), new[] { nameof(rainExceedanceClimateSite.RainExceedanceClimateSiteID) });
                }

                if (!(from c in dbLocal.RainExceedanceClimateSites.AsNoTracking() select c).Where(c => c.RainExceedanceClimateSiteID == rainExceedanceClimateSite.RainExceedanceClimateSiteID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "RainExceedanceClimateSite", "RainExceedanceClimateSiteID", rainExceedanceClimateSite.RainExceedanceClimateSiteID.ToString()), new[] { nameof(rainExceedanceClimateSite.RainExceedanceClimateSiteID) });
                }
            }

            TVItem TVItemRainExceedanceTVItemID = null;
            TVItemRainExceedanceTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == rainExceedanceClimateSite.RainExceedanceTVItemID select c).FirstOrDefault();

            if (TVItemRainExceedanceTVItemID == null)
            {
                TVItemRainExceedanceTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == rainExceedanceClimateSite.RainExceedanceTVItemID select c).FirstOrDefault();

                if (TVItemRainExceedanceTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "RainExceedanceTVItemID", rainExceedanceClimateSite.RainExceedanceTVItemID.ToString()), new[] { nameof(rainExceedanceClimateSite.RainExceedanceTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.RainExceedance,
                    };
                    if (!AllowableTVTypes.Contains(TVItemRainExceedanceTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "RainExceedanceTVItemID", "RainExceedance"), new[] { nameof(rainExceedanceClimateSite.RainExceedanceTVItemID) });
                    }
                }

            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.RainExceedance,
                };
                if (!AllowableTVTypes.Contains(TVItemRainExceedanceTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "RainExceedanceTVItemID", "RainExceedance"), new[] { nameof(rainExceedanceClimateSite.RainExceedanceTVItemID) });
                }
            }

            TVItem TVItemClimateSiteTVItemID = null;
            TVItemClimateSiteTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == rainExceedanceClimateSite.ClimateSiteTVItemID select c).FirstOrDefault();

            if (TVItemClimateSiteTVItemID == null)
            {
                TVItemClimateSiteTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == rainExceedanceClimateSite.ClimateSiteTVItemID select c).FirstOrDefault();

                if (TVItemClimateSiteTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ClimateSiteTVItemID", rainExceedanceClimateSite.ClimateSiteTVItemID.ToString()), new[] { nameof(rainExceedanceClimateSite.ClimateSiteTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.ClimateSite,
                    };
                    if (!AllowableTVTypes.Contains(TVItemClimateSiteTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ClimateSiteTVItemID", "ClimateSite"), new[] { nameof(rainExceedanceClimateSite.ClimateSiteTVItemID) });
                    }
                }

            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.ClimateSite,
                };
                if (!AllowableTVTypes.Contains(TVItemClimateSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ClimateSiteTVItemID", "ClimateSite"), new[] { nameof(rainExceedanceClimateSite.ClimateSiteTVItemID) });
                }
            }

            if (rainExceedanceClimateSite.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(rainExceedanceClimateSite.LastUpdateDate_UTC) });
            }
            else
            {
                if (rainExceedanceClimateSite.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(rainExceedanceClimateSite.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == rainExceedanceClimateSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == rainExceedanceClimateSite.LastUpdateContactTVItemID select c).FirstOrDefault();

                if (TVItemLastUpdateContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", rainExceedanceClimateSite.LastUpdateContactTVItemID.ToString()), new[] { nameof(rainExceedanceClimateSite.LastUpdateContactTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(rainExceedanceClimateSite.LastUpdateContactTVItemID) });
                    }
                }

            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(rainExceedanceClimateSite.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
