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
    public partial interface IMWQMSiteStartEndDateDBLocalIMService
    {
        Task<ActionResult<bool>> Delete(int MWQMSiteStartEndDateID);
        Task<ActionResult<List<MWQMSiteStartEndDate>>> GetMWQMSiteStartEndDateList(int skip = 0, int take = 100);
        Task<ActionResult<MWQMSiteStartEndDate>> GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(int MWQMSiteStartEndDateID);
        Task<ActionResult<MWQMSiteStartEndDate>> Post(MWQMSiteStartEndDate mwqmsitestartenddate);
        Task<ActionResult<MWQMSiteStartEndDate>> Put(MWQMSiteStartEndDate mwqmsitestartenddate);
    }
    public partial class MWQMSiteStartEndDateDBLocalIMService : ControllerBase, IMWQMSiteStartEndDateDBLocalIMService
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
        public MWQMSiteStartEndDateDBLocalIMService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<MWQMSiteStartEndDate>> GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(int MWQMSiteStartEndDateID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            MWQMSiteStartEndDate mwqmSiteStartEndDate = (from c in dbLocalIM.MWQMSiteStartEndDates.Local
                    where c.MWQMSiteStartEndDateID == MWQMSiteStartEndDateID
                    select c).FirstOrDefault();

            if (mwqmSiteStartEndDate == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(mwqmSiteStartEndDate));
        }
        public async Task<ActionResult<List<MWQMSiteStartEndDate>>> GetMWQMSiteStartEndDateList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = (from c in dbLocalIM.MWQMSiteStartEndDates.Local orderby c.MWQMSiteStartEndDateID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(mwqmSiteStartEndDateList));
        }
        public async Task<ActionResult<bool>> Delete(int MWQMSiteStartEndDateID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            MWQMSiteStartEndDate mwqmSiteStartEndDate = (from c in dbLocalIM.MWQMSiteStartEndDates.Local
                    where c.MWQMSiteStartEndDateID == MWQMSiteStartEndDateID
                    select c).FirstOrDefault();

            if (mwqmSiteStartEndDate == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSiteStartEndDate", "MWQMSiteStartEndDateID", MWQMSiteStartEndDateID.ToString())));
            }

            try
            {
                dbLocalIM.MWQMSiteStartEndDates.Remove(mwqmSiteStartEndDate);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<MWQMSiteStartEndDate>> Post(MWQMSiteStartEndDate mwqmSiteStartEndDate)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmSiteStartEndDate), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.MWQMSiteStartEndDates.Add(mwqmSiteStartEndDate);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSiteStartEndDate));
        }
        public async Task<ActionResult<MWQMSiteStartEndDate>> Put(MWQMSiteStartEndDate mwqmSiteStartEndDate)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmSiteStartEndDate), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.MWQMSiteStartEndDates.Update(mwqmSiteStartEndDate);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSiteStartEndDate));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            MWQMSiteStartEndDate mwqmSiteStartEndDate = validationContext.ObjectInstance as MWQMSiteStartEndDate;

            if (actionDBType == ActionDBTypeEnum.Create)
            {
                if (mwqmSiteStartEndDate.MWQMSiteStartEndDateID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMSiteStartEndDateID"), new[] { nameof(mwqmSiteStartEndDate.MWQMSiteStartEndDateID) });
                }
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSiteStartEndDate.MWQMSiteStartEndDateID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMSiteStartEndDateID"), new[] { nameof(mwqmSiteStartEndDate.MWQMSiteStartEndDateID) });
                }

                if (!(from c in dbLocalIM.MWQMSiteStartEndDates.Local select c).Where(c => c.MWQMSiteStartEndDateID == mwqmSiteStartEndDate.MWQMSiteStartEndDateID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSiteStartEndDate", "MWQMSiteStartEndDateID", mwqmSiteStartEndDate.MWQMSiteStartEndDateID.ToString()), new[] { nameof(mwqmSiteStartEndDate.MWQMSiteStartEndDateID) });
                }
            }

            TVItem TVItemMWQMSiteTVItemID = null;
            TVItemMWQMSiteTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == mwqmSiteStartEndDate.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteTVItemID", mwqmSiteStartEndDate.MWQMSiteTVItemID.ToString()), new[] { nameof(mwqmSiteStartEndDate.MWQMSiteTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MWQMSiteTVItemID", "MWQMSite"), new[] { nameof(mwqmSiteStartEndDate.MWQMSiteTVItemID) });
                }
            }

            if (mwqmSiteStartEndDate.StartDate.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "StartDate"), new[] { nameof(mwqmSiteStartEndDate.StartDate) });
            }
            else
            {
                if (mwqmSiteStartEndDate.StartDate.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDate", "1980"), new[] { nameof(mwqmSiteStartEndDate.StartDate) });
                }
            }

            if (mwqmSiteStartEndDate.EndDate != null && ((DateTime)mwqmSiteStartEndDate.EndDate).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDate", "1980"), new[] { nameof(mwqmSiteStartEndDate.EndDate) });
            }

            if (mwqmSiteStartEndDate.StartDate > mwqmSiteStartEndDate.EndDate)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, "EndDate", "MWQMSiteStartEndDateStartDate"), new[] { nameof(mwqmSiteStartEndDate.EndDate) });
            }

            if (mwqmSiteStartEndDate.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mwqmSiteStartEndDate.LastUpdateDate_UTC) });
            }
            else
            {
                if (mwqmSiteStartEndDate.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mwqmSiteStartEndDate.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == mwqmSiteStartEndDate.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmSiteStartEndDate.LastUpdateContactTVItemID.ToString()), new[] { nameof(mwqmSiteStartEndDate.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mwqmSiteStartEndDate.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
