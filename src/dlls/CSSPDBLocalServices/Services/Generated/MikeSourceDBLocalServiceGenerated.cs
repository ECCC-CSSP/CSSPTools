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
    public partial interface IMikeSourceDBLocalService
    {
        Task<ActionResult<bool>> Delete(int MikeSourceID);
        Task<ActionResult<List<MikeSource>>> GetMikeSourceList(int skip = 0, int take = 100);
        Task<ActionResult<MikeSource>> GetMikeSourceWithMikeSourceID(int MikeSourceID);
        Task<ActionResult<MikeSource>> Post(MikeSource mikesource);
        Task<ActionResult<MikeSource>> Put(MikeSource mikesource);
    }
    public partial class MikeSourceDBLocalService : ControllerBase, IMikeSourceDBLocalService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext dbLocal { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceDBLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext dbLocal)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.dbLocal = dbLocal;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<MikeSource>> GetMikeSourceWithMikeSourceID(int MikeSourceID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            MikeSource mikeSource = (from c in dbLocal.MikeSources.AsNoTracking()
                    where c.MikeSourceID == MikeSourceID
                    select c).FirstOrDefault();

            if (mikeSource == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(mikeSource));
        }
        public async Task<ActionResult<List<MikeSource>>> GetMikeSourceList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<MikeSource> mikeSourceList = (from c in dbLocal.MikeSources.AsNoTracking() orderby c.MikeSourceID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(mikeSourceList));
        }
        public async Task<ActionResult<bool>> Delete(int MikeSourceID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            MikeSource mikeSource = (from c in dbLocal.MikeSources
                    where c.MikeSourceID == MikeSourceID
                    select c).FirstOrDefault();

            if (mikeSource == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeSource", "MikeSourceID", MikeSourceID.ToString())));
            }

            try
            {
                dbLocal.MikeSources.Remove(mikeSource);
                dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<MikeSource>> Post(MikeSource mikeSource)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (mikeSource.MikeSourceID == 0)
            {
                int LastMikeSourceID = (from c in dbLocal.MikeSources
                          orderby c.MikeSourceID descending
                          select c.MikeSourceID).FirstOrDefault();

                mikeSource.MikeSourceID = LastMikeSourceID + 1;
            }

            try
            {
                dbLocal.MikeSources.Add(mikeSource);
                dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeSource));
        }
        public async Task<ActionResult<MikeSource>> Put(MikeSource mikeSource)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocal.MikeSources.Update(mikeSource);
                dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeSource));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            MikeSource mikeSource = validationContext.ObjectInstance as MikeSource;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeSource.MikeSourceID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeSourceID"), new[] { nameof(mikeSource.MikeSourceID) });
                }

                if (!(from c in dbLocal.MikeSources select c).Where(c => c.MikeSourceID == mikeSource.MikeSourceID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeSource", "MikeSourceID", mikeSource.MikeSourceID.ToString()), new[] { nameof(mikeSource.MikeSourceID) });
                }
            }

            TVItem TVItemMikeSourceTVItemID = null;
            TVItemMikeSourceTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mikeSource.MikeSourceTVItemID select c).FirstOrDefault();

            if (TVItemMikeSourceTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeSourceTVItemID", mikeSource.MikeSourceTVItemID.ToString()), new[] { nameof(mikeSource.MikeSourceTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeSource,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeSourceTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MikeSourceTVItemID", "MikeSource"), new[] { nameof(mikeSource.MikeSourceTVItemID) });
                }
            }

            if (mikeSource.HydrometricTVItemID != null)
            {
                TVItem TVItemHydrometricTVItemID = null;
                TVItemHydrometricTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mikeSource.HydrometricTVItemID select c).FirstOrDefault();

                if (TVItemHydrometricTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "HydrometricTVItemID", (mikeSource.HydrometricTVItemID == null ? "" : mikeSource.HydrometricTVItemID.ToString())), new[] { nameof(mikeSource.HydrometricTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.HydrometricSite,
                    };
                    if (!AllowableTVTypes.Contains(TVItemHydrometricTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "HydrometricTVItemID", "HydrometricSite"), new[] { nameof(mikeSource.HydrometricTVItemID) });
                    }
                }
            }

            if (mikeSource.DrainageArea_km2 != null)
            {
                if (mikeSource.DrainageArea_km2 < 0 || mikeSource.DrainageArea_km2 > 1000000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DrainageArea_km2", "0", "1000000"), new[] { nameof(mikeSource.DrainageArea_km2) });
                }
            }

            if (mikeSource.Factor != null)
            {
                if (mikeSource.Factor < 0 || mikeSource.Factor > 1000000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Factor", "0", "1000000"), new[] { nameof(mikeSource.Factor) });
                }
            }

            if (string.IsNullOrWhiteSpace(mikeSource.SourceNumberString))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SourceNumberString"), new[] { nameof(mikeSource.SourceNumberString) });
            }

            if (!string.IsNullOrWhiteSpace(mikeSource.SourceNumberString) && mikeSource.SourceNumberString.Length > 50)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SourceNumberString", "50"), new[] { nameof(mikeSource.SourceNumberString) });
            }

            if (mikeSource.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mikeSource.LastUpdateDate_UTC) });
            }
            else
            {
                if (mikeSource.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mikeSource.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mikeSource.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mikeSource.LastUpdateContactTVItemID.ToString()), new[] { nameof(mikeSource.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mikeSource.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
