/*
 * Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
   public interface IMWQMSiteStartEndDateService
    {
       Task<ActionResult<MWQMSiteStartEndDate>> GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(int MWQMSiteStartEndDateID);
       Task<ActionResult<List<MWQMSiteStartEndDate>>> GetMWQMSiteStartEndDateList();
       Task<ActionResult<MWQMSiteStartEndDate>> Add(MWQMSiteStartEndDate mwqmsitestartenddate);
       Task<ActionResult<MWQMSiteStartEndDate>> Delete(MWQMSiteStartEndDate mwqmsitestartenddate);
       Task<ActionResult<MWQMSiteStartEndDate>> Update(MWQMSiteStartEndDate mwqmsitestartenddate);
       Task SetCulture(CultureInfo culture);
    }
    public partial class MWQMSiteStartEndDateService : ControllerBase, IMWQMSiteStartEndDateService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<MWQMSiteStartEndDate>> GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(int MWQMSiteStartEndDateID)
        {
            MWQMSiteStartEndDate mwqmsitestartenddate = (from c in db.MWQMSiteStartEndDates.AsNoTracking()
                    where c.MWQMSiteStartEndDateID == MWQMSiteStartEndDateID
                    select c).FirstOrDefault();

            if (mwqmsitestartenddate == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(mwqmsitestartenddate));
        }
        public async Task<ActionResult<List<MWQMSiteStartEndDate>>> GetMWQMSiteStartEndDateList()
        {
            List<MWQMSiteStartEndDate> mwqmsitestartenddateList = (from c in db.MWQMSiteStartEndDates.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(mwqmsitestartenddateList));
        }
        public async Task<ActionResult<MWQMSiteStartEndDate>> Add(MWQMSiteStartEndDate mwqmSiteStartEndDate)
        {
            mwqmSiteStartEndDate.ValidationResults = Validate(new ValidationContext(mwqmSiteStartEndDate), ActionDBTypeEnum.Create);
            if (mwqmSiteStartEndDate.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(mwqmSiteStartEndDate.ValidationResults));
            }

            try
            {
               db.MWQMSiteStartEndDates.Add(mwqmSiteStartEndDate);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSiteStartEndDate));
        }
        public async Task<ActionResult<MWQMSiteStartEndDate>> Delete(MWQMSiteStartEndDate mwqmSiteStartEndDate)
        {
            mwqmSiteStartEndDate.ValidationResults = Validate(new ValidationContext(mwqmSiteStartEndDate), ActionDBTypeEnum.Delete);
            if (mwqmSiteStartEndDate.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(mwqmSiteStartEndDate.ValidationResults));
            }

            try
            {
               db.MWQMSiteStartEndDates.Remove(mwqmSiteStartEndDate);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSiteStartEndDate));
        }
        public async Task<ActionResult<MWQMSiteStartEndDate>> Update(MWQMSiteStartEndDate mwqmSiteStartEndDate)
        {
            mwqmSiteStartEndDate.ValidationResults = Validate(new ValidationContext(mwqmSiteStartEndDate), ActionDBTypeEnum.Update);
            if (mwqmSiteStartEndDate.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(mwqmSiteStartEndDate.ValidationResults));
            }

            try
            {
               db.MWQMSiteStartEndDates.Update(mwqmSiteStartEndDate);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSiteStartEndDate));
        }
        public async Task SetCulture(CultureInfo culture)
        {
            CSSPServicesRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MWQMSiteStartEndDate mwqmSiteStartEndDate = validationContext.ObjectInstance as MWQMSiteStartEndDate;
            mwqmSiteStartEndDate.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSiteStartEndDate.MWQMSiteStartEndDateID == 0)
                {
                    mwqmSiteStartEndDate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSiteStartEndDateID"), new[] { "MWQMSiteStartEndDateID" });
                }

                if (!(from c in db.MWQMSiteStartEndDates select c).Where(c => c.MWQMSiteStartEndDateID == mwqmSiteStartEndDate.MWQMSiteStartEndDateID).Any())
                {
                    mwqmSiteStartEndDate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSiteStartEndDate", "MWQMSiteStartEndDateID", mwqmSiteStartEndDate.MWQMSiteStartEndDateID.ToString()), new[] { "MWQMSiteStartEndDateID" });
                }
            }

            TVItem TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSiteStartEndDate.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteTVItemID", mwqmSiteStartEndDate.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    mwqmSiteStartEndDate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSiteTVItemID", "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            if (mwqmSiteStartEndDate.StartDate.Year == 1)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "StartDate"), new[] { "StartDate" });
            }
            else
            {
                if (mwqmSiteStartEndDate.StartDate.Year < 1980)
                {
                mwqmSiteStartEndDate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "StartDate", "1980"), new[] { "StartDate" });
                }
            }

            if (mwqmSiteStartEndDate.EndDate != null && ((DateTime)mwqmSiteStartEndDate.EndDate).Year < 1980)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "EndDate", "1980"), new[] { "EndDate" });
            }

            if (mwqmSiteStartEndDate.StartDate > mwqmSiteStartEndDate.EndDate)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "EndDate", "MWQMSiteStartEndDateStartDate"), new[] { "EndDate" });
            }

            if (mwqmSiteStartEndDate.LastUpdateDate_UTC.Year == 1)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSiteStartEndDate.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmSiteStartEndDate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSiteStartEndDate.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmSiteStartEndDate.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmSiteStartEndDate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions private

    }
}
