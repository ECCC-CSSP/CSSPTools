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
    public partial interface ITideLocationDBLocalService
    {
        Task<ActionResult<bool>> Delete(int TideLocationID);
        Task<ActionResult<List<TideLocation>>> GetTideLocationList(int skip = 0, int take = 100);
        Task<ActionResult<TideLocation>> GetTideLocationWithTideLocationID(int TideLocationID);
        Task<ActionResult<TideLocation>> Post(TideLocation tidelocation);
        Task<ActionResult<TideLocation>> Put(TideLocation tidelocation);
    }
    public partial class TideLocationDBLocalService : ControllerBase, ITideLocationDBLocalService
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
        public TideLocationDBLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<TideLocation>> GetTideLocationWithTideLocationID(int TideLocationID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            TideLocation tideLocation = (from c in dbLocal.TideLocations.AsNoTracking()
                    where c.TideLocationID == TideLocationID
                    select c).FirstOrDefault();

            if (tideLocation == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(tideLocation));
        }
        public async Task<ActionResult<List<TideLocation>>> GetTideLocationList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<TideLocation> tideLocationList = (from c in dbLocal.TideLocations.AsNoTracking() orderby c.TideLocationID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(tideLocationList));
        }
        public async Task<ActionResult<bool>> Delete(int TideLocationID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TideLocation tideLocation = (from c in dbLocal.TideLocations
                    where c.TideLocationID == TideLocationID
                    select c).FirstOrDefault();

            if (tideLocation == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TideLocation", "TideLocationID", TideLocationID.ToString())));
            }

            try
            {
                dbLocal.TideLocations.Remove(tideLocation);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<TideLocation>> Post(TideLocation tideLocation)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tideLocation), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (tideLocation.TideLocationID == 0)
            {
                int LastTideLocationID = (from c in dbLocal.TideLocations.AsNoTracking()
                          orderby c.TideLocationID descending
                          select c.TideLocationID).FirstOrDefault();

                tideLocation.TideLocationID = LastTideLocationID + 1;
            }

            try
            {
                dbLocal.TideLocations.Add(tideLocation);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tideLocation));
        }
        public async Task<ActionResult<TideLocation>> Put(TideLocation tideLocation)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tideLocation), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocal.TideLocations.Update(tideLocation);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tideLocation));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            TideLocation tideLocation = validationContext.ObjectInstance as TideLocation;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tideLocation.TideLocationID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TideLocationID"), new[] { nameof(tideLocation.TideLocationID) });
                }

                if (!(from c in dbLocal.TideLocations.AsNoTracking() select c).Where(c => c.TideLocationID == tideLocation.TideLocationID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TideLocation", "TideLocationID", tideLocation.TideLocationID.ToString()), new[] { nameof(tideLocation.TideLocationID) });
                }
            }

            if (tideLocation.Zone < 0 || tideLocation.Zone > 10000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Zone", "0", "10000"), new[] { nameof(tideLocation.Zone) });
            }

            if (string.IsNullOrWhiteSpace(tideLocation.Name))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Name"), new[] { nameof(tideLocation.Name) });
            }

            if (!string.IsNullOrWhiteSpace(tideLocation.Name) && tideLocation.Name.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Name", "100"), new[] { nameof(tideLocation.Name) });
            }

            if (string.IsNullOrWhiteSpace(tideLocation.Prov))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Prov"), new[] { nameof(tideLocation.Prov) });
            }

            if (!string.IsNullOrWhiteSpace(tideLocation.Prov) && tideLocation.Prov.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Prov", "100"), new[] { nameof(tideLocation.Prov) });
            }

            if (tideLocation.sid < 0 || tideLocation.sid > 100000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "sid", "0", "100000"), new[] { nameof(tideLocation.sid) });
            }

            if (tideLocation.Lat < -90 || tideLocation.Lat > 90)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lat", "-90", "90"), new[] { nameof(tideLocation.Lat) });
            }

            if (tideLocation.Lng < -180 || tideLocation.Lng > 180)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lng", "-180", "180"), new[] { nameof(tideLocation.Lng) });
            }

            if (tideLocation.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(tideLocation.LastUpdateDate_UTC) });
            }
            else
            {
                if (tideLocation.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(tideLocation.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == tideLocation.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == tideLocation.LastUpdateContactTVItemID select c).FirstOrDefault();

                if (TVItemLastUpdateContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tideLocation.LastUpdateContactTVItemID.ToString()), new[] { nameof(tideLocation.LastUpdateContactTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(tideLocation.LastUpdateContactTVItemID) });
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
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(tideLocation.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}