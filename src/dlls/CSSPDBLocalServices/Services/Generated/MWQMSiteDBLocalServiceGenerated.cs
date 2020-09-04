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
    public partial interface IMWQMSiteDBLocalService
    {
        Task<ActionResult<bool>> Delete(int MWQMSiteID);
        Task<ActionResult<List<MWQMSite>>> GetMWQMSiteList(int skip = 0, int take = 100);
        Task<ActionResult<MWQMSite>> GetMWQMSiteWithMWQMSiteID(int MWQMSiteID);
        Task<ActionResult<MWQMSite>> Post(MWQMSite mwqmsite);
        Task<ActionResult<MWQMSite>> Put(MWQMSite mwqmsite);
    }
    public partial class MWQMSiteDBLocalService : ControllerBase, IMWQMSiteDBLocalService
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
        public MWQMSiteDBLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<MWQMSite>> GetMWQMSiteWithMWQMSiteID(int MWQMSiteID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            MWQMSite mwqmSite = (from c in dbLocal.MWQMSites.AsNoTracking()
                    where c.MWQMSiteID == MWQMSiteID
                    select c).FirstOrDefault();

            if (mwqmSite == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(mwqmSite));
        }
        public async Task<ActionResult<List<MWQMSite>>> GetMWQMSiteList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<MWQMSite> mwqmSiteList = (from c in dbLocal.MWQMSites.AsNoTracking() orderby c.MWQMSiteID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(mwqmSiteList));
        }
        public async Task<ActionResult<bool>> Delete(int MWQMSiteID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            MWQMSite mwqmSite = (from c in dbLocal.MWQMSites
                    where c.MWQMSiteID == MWQMSiteID
                    select c).FirstOrDefault();

            if (mwqmSite == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSite", "MWQMSiteID", MWQMSiteID.ToString())));
            }

            try
            {
                dbLocal.MWQMSites.Remove(mwqmSite);
                dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<MWQMSite>> Post(MWQMSite mwqmSite)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmSite), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (mwqmSite.MWQMSiteID == 0)
            {
                int LastMWQMSiteID = (from c in dbLocal.MWQMSites
                          orderby c.MWQMSiteID descending
                          select c.MWQMSiteID).FirstOrDefault();

                mwqmSite.MWQMSiteID = LastMWQMSiteID + 1;
            }

            try
            {
                dbLocal.MWQMSites.Add(mwqmSite);
                dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSite));
        }
        public async Task<ActionResult<MWQMSite>> Put(MWQMSite mwqmSite)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmSite), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocal.MWQMSites.Update(mwqmSite);
                dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSite));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MWQMSite mwqmSite = validationContext.ObjectInstance as MWQMSite;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSite.MWQMSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMSiteID"), new[] { nameof(mwqmSite.MWQMSiteID) });
                }

                if (!(from c in dbLocal.MWQMSites select c).Where(c => c.MWQMSiteID == mwqmSite.MWQMSiteID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSite", "MWQMSiteID", mwqmSite.MWQMSiteID.ToString()), new[] { nameof(mwqmSite.MWQMSiteID) });
                }
            }

            TVItem TVItemMWQMSiteTVItemID = null;
            TVItemMWQMSiteTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mwqmSite.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteTVItemID", mwqmSite.MWQMSiteTVItemID.ToString()), new[] { nameof(mwqmSite.MWQMSiteTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MWQMSiteTVItemID", "MWQMSite"), new[] { nameof(mwqmSite.MWQMSiteTVItemID) });
                }
            }

            if (string.IsNullOrWhiteSpace(mwqmSite.MWQMSiteNumber))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMSiteNumber"), new[] { nameof(mwqmSite.MWQMSiteNumber) });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSite.MWQMSiteNumber) && mwqmSite.MWQMSiteNumber.Length > 8)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "MWQMSiteNumber", "8"), new[] { nameof(mwqmSite.MWQMSiteNumber) });
            }

            if (string.IsNullOrWhiteSpace(mwqmSite.MWQMSiteDescription))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMSiteDescription"), new[] { nameof(mwqmSite.MWQMSiteDescription) });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSite.MWQMSiteDescription) && mwqmSite.MWQMSiteDescription.Length > 200)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "MWQMSiteDescription", "200"), new[] { nameof(mwqmSite.MWQMSiteDescription) });
            }

            retStr = enums.EnumTypeOK(typeof(MWQMSiteLatestClassificationEnum), (int?)mwqmSite.MWQMSiteLatestClassification);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMSiteLatestClassification"), new[] { nameof(mwqmSite.MWQMSiteLatestClassification) });
            }

            if (mwqmSite.Ordinal < 0 || mwqmSite.Ordinal > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "1000"), new[] { nameof(mwqmSite.Ordinal) });
            }

            if (mwqmSite.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mwqmSite.LastUpdateDate_UTC) });
            }
            else
            {
                if (mwqmSite.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mwqmSite.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mwqmSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmSite.LastUpdateContactTVItemID.ToString()), new[] { nameof(mwqmSite.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mwqmSite.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
