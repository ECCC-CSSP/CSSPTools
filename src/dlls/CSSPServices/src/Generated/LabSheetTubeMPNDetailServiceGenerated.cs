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
   public interface ILabSheetTubeMPNDetailService
    {
       Task<ActionResult<LabSheetTubeMPNDetail>> GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(int LabSheetTubeMPNDetailID);
       Task<ActionResult<List<LabSheetTubeMPNDetail>>> GetLabSheetTubeMPNDetailList();
       Task<ActionResult<LabSheetTubeMPNDetail>> Add(LabSheetTubeMPNDetail labsheettubempndetail);
       Task<ActionResult<LabSheetTubeMPNDetail>> Delete(LabSheetTubeMPNDetail labsheettubempndetail);
       Task<ActionResult<LabSheetTubeMPNDetail>> Update(LabSheetTubeMPNDetail labsheettubempndetail);
       Task SetCulture(CultureInfo culture);
    }
    public partial class LabSheetTubeMPNDetailService : ControllerBase, ILabSheetTubeMPNDetailService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<LabSheetTubeMPNDetail>> GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(int LabSheetTubeMPNDetailID)
        {
            LabSheetTubeMPNDetail labsheettubempndetail = (from c in db.LabSheetTubeMPNDetails.AsNoTracking()
                    where c.LabSheetTubeMPNDetailID == LabSheetTubeMPNDetailID
                    select c).FirstOrDefault();

            if (labsheettubempndetail == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(labsheettubempndetail));
        }
        public async Task<ActionResult<List<LabSheetTubeMPNDetail>>> GetLabSheetTubeMPNDetailList()
        {
            List<LabSheetTubeMPNDetail> labsheettubempndetailList = (from c in db.LabSheetTubeMPNDetails.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(labsheettubempndetailList));
        }
        public async Task<ActionResult<LabSheetTubeMPNDetail>> Add(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
        {
            ValidationResults = Validate(new ValidationContext(labSheetTubeMPNDetail), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.LabSheetTubeMPNDetails.Add(labSheetTubeMPNDetail);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(labSheetTubeMPNDetail));
        }
        public async Task<ActionResult<LabSheetTubeMPNDetail>> Delete(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
        {
            ValidationResults = Validate(new ValidationContext(labSheetTubeMPNDetail), ActionDBTypeEnum.Delete);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.LabSheetTubeMPNDetails.Remove(labSheetTubeMPNDetail);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(labSheetTubeMPNDetail));
        }
        public async Task<ActionResult<LabSheetTubeMPNDetail>> Update(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
        {
            ValidationResults = Validate(new ValidationContext(labSheetTubeMPNDetail), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.LabSheetTubeMPNDetails.Update(labSheetTubeMPNDetail);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(labSheetTubeMPNDetail));
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
            LabSheetTubeMPNDetail labSheetTubeMPNDetail = validationContext.ObjectInstance as LabSheetTubeMPNDetail;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (labSheetTubeMPNDetail.LabSheetTubeMPNDetailID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetTubeMPNDetailID"), new[] { "LabSheetTubeMPNDetailID" });
                }

                if (!(from c in db.LabSheetTubeMPNDetails select c).Where(c => c.LabSheetTubeMPNDetailID == labSheetTubeMPNDetail.LabSheetTubeMPNDetailID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "LabSheetTubeMPNDetail", "LabSheetTubeMPNDetailID", labSheetTubeMPNDetail.LabSheetTubeMPNDetailID.ToString()), new[] { "LabSheetTubeMPNDetailID" });
                }
            }

            LabSheetDetail LabSheetDetailLabSheetDetailID = (from c in db.LabSheetDetails where c.LabSheetDetailID == labSheetTubeMPNDetail.LabSheetDetailID select c).FirstOrDefault();

            if (LabSheetDetailLabSheetDetailID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "LabSheetDetail", "LabSheetDetailID", labSheetTubeMPNDetail.LabSheetDetailID.ToString()), new[] { "LabSheetDetailID" });
            }

            if (labSheetTubeMPNDetail.Ordinal < 0 || labSheetTubeMPNDetail.Ordinal > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "1000"), new[] { "Ordinal" });
            }

            TVItem TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == labSheetTubeMPNDetail.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteTVItemID", labSheetTubeMPNDetail.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSiteTVItemID", "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            if (labSheetTubeMPNDetail.SampleDateTime != null && ((DateTime)labSheetTubeMPNDetail.SampleDateTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SampleDateTime", "1980"), new[] { "SampleDateTime" });
            }

            if (labSheetTubeMPNDetail.MPN != null)
            {
                if (labSheetTubeMPNDetail.MPN < 1 || labSheetTubeMPNDetail.MPN > 10000000)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MPN", "1", "10000000"), new[] { "MPN" });
                }
            }

            if (labSheetTubeMPNDetail.Tube10 != null)
            {
                if (labSheetTubeMPNDetail.Tube10 < 0 || labSheetTubeMPNDetail.Tube10 > 5)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Tube10", "0", "5"), new[] { "Tube10" });
                }
            }

            if (labSheetTubeMPNDetail.Tube1_0 != null)
            {
                if (labSheetTubeMPNDetail.Tube1_0 < 0 || labSheetTubeMPNDetail.Tube1_0 > 5)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Tube1_0", "0", "5"), new[] { "Tube1_0" });
                }
            }

            if (labSheetTubeMPNDetail.Tube0_1 != null)
            {
                if (labSheetTubeMPNDetail.Tube0_1 < 0 || labSheetTubeMPNDetail.Tube0_1 > 5)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Tube0_1", "0", "5"), new[] { "Tube0_1" });
                }
            }

            if (labSheetTubeMPNDetail.Salinity != null)
            {
                if (labSheetTubeMPNDetail.Salinity < 0 || labSheetTubeMPNDetail.Salinity > 40)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Salinity", "0", "40"), new[] { "Salinity" });
                }
            }

            if (labSheetTubeMPNDetail.Temperature != null)
            {
                if (labSheetTubeMPNDetail.Temperature < -10 || labSheetTubeMPNDetail.Temperature > 40)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Temperature", "-10", "40"), new[] { "Temperature" });
                }
            }

            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetail.ProcessedBy) && labSheetTubeMPNDetail.ProcessedBy.Length > 10)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ProcessedBy", "10"), new[] { "ProcessedBy" });
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)labSheetTubeMPNDetail.SampleType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SampleType"), new[] { "SampleType" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetail.SiteComment) && labSheetTubeMPNDetail.SiteComment.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "SiteComment", "250"), new[] { "SiteComment" });
            }

            if (labSheetTubeMPNDetail.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (labSheetTubeMPNDetail.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheetTubeMPNDetail.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", labSheetTubeMPNDetail.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions private

    }
}
