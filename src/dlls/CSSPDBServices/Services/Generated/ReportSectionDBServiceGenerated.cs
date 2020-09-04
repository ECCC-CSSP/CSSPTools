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
using LoggedInServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBServices
{
    public partial interface IReportSectionDBService
    {
        Task<ActionResult<bool>> Delete(int ReportSectionID);
        Task<ActionResult<List<ReportSection>>> GetReportSectionList(int skip = 0, int take = 100);
        Task<ActionResult<ReportSection>> GetReportSectionWithReportSectionID(int ReportSectionID);
        Task<ActionResult<ReportSection>> Post(ReportSection reportsection);
        Task<ActionResult<ReportSection>> Put(ReportSection reportsection);
    }
    public partial class ReportSectionDBService : ControllerBase, IReportSectionDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public ReportSectionDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<ReportSection>> GetReportSectionWithReportSectionID(int ReportSectionID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            ReportSection reportSection = (from c in db.ReportSections.AsNoTracking()
                    where c.ReportSectionID == ReportSectionID
                    select c).FirstOrDefault();

            if (reportSection == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(reportSection));
        }
        public async Task<ActionResult<List<ReportSection>>> GetReportSectionList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<ReportSection> reportSectionList = (from c in db.ReportSections.AsNoTracking() orderby c.ReportSectionID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(reportSectionList));
        }
        public async Task<ActionResult<bool>> Delete(int ReportSectionID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ReportSection reportSection = (from c in db.ReportSections
                    where c.ReportSectionID == ReportSectionID
                    select c).FirstOrDefault();

            if (reportSection == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ReportSection", "ReportSectionID", ReportSectionID.ToString())));
            }

            try
            {
                db.ReportSections.Remove(reportSection);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<ReportSection>> Post(ReportSection reportSection)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(reportSection), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.ReportSections.Add(reportSection);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(reportSection));
        }
        public async Task<ActionResult<ReportSection>> Put(ReportSection reportSection)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(reportSection), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.ReportSections.Update(reportSection);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(reportSection));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            ReportSection reportSection = validationContext.ObjectInstance as ReportSection;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (reportSection.ReportSectionID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ReportSectionID"), new[] { nameof(reportSection.ReportSectionID) });
                }

                if (!(from c in db.ReportSections select c).Where(c => c.ReportSectionID == reportSection.ReportSectionID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ReportSection", "ReportSectionID", reportSection.ReportSectionID.ToString()), new[] { nameof(reportSection.ReportSectionID) });
                }
            }

            ReportType ReportTypeReportTypeID = null;
            ReportTypeReportTypeID = (from c in db.ReportTypes where c.ReportTypeID == reportSection.ReportTypeID select c).FirstOrDefault();

            if (ReportTypeReportTypeID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportTypeID", reportSection.ReportTypeID.ToString()), new[] { nameof(reportSection.ReportTypeID) });
            }

            if (reportSection.TVItemID != null)
            {
                TVItem TVItemTVItemID = null;
                TVItemTVItemID = (from c in db.TVItems where c.TVItemID == reportSection.TVItemID select c).FirstOrDefault();

                if (TVItemTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", (reportSection.TVItemID == null ? "" : reportSection.TVItemID.ToString())), new[] { nameof(reportSection.TVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                    };
                    if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVItemID", ""), new[] { nameof(reportSection.TVItemID) });
                    }
                }
            }

            if (reportSection.Language != null)
            {
                retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)reportSection.Language);
                if (reportSection.Language == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(reportSection.Language) });
                }
            }

            if (reportSection.Ordinal < 0 || reportSection.Ordinal > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "1000"), new[] { nameof(reportSection.Ordinal) });
            }

            if (reportSection.ParentReportSectionID != null)
            {
                ReportSection ReportSectionParentReportSectionID = null;
                ReportSectionParentReportSectionID = (from c in db.ReportSections where c.ReportSectionID == reportSection.ParentReportSectionID select c).FirstOrDefault();

                if (ReportSectionParentReportSectionID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ReportSection", "ParentReportSectionID", (reportSection.ParentReportSectionID == null ? "" : reportSection.ParentReportSectionID.ToString())), new[] { nameof(reportSection.ParentReportSectionID) });
                }
            }

            if (reportSection.Year != null)
            {
                if (reportSection.Year < 1979 || reportSection.Year > 2050)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Year", "1979", "2050"), new[] { nameof(reportSection.Year) });
                }
            }

            if (reportSection.TemplateReportSectionID != null)
            {
                ReportSection ReportSectionTemplateReportSectionID = null;
                ReportSectionTemplateReportSectionID = (from c in db.ReportSections where c.ReportSectionID == reportSection.TemplateReportSectionID select c).FirstOrDefault();

                if (ReportSectionTemplateReportSectionID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ReportSection", "TemplateReportSectionID", (reportSection.TemplateReportSectionID == null ? "" : reportSection.TemplateReportSectionID.ToString())), new[] { nameof(reportSection.TemplateReportSectionID) });
                }
            }

            if (!string.IsNullOrWhiteSpace(reportSection.ReportSectionName) && reportSection.ReportSectionName.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ReportSectionName", "100"), new[] { nameof(reportSection.ReportSectionName) });
            }

            if (!string.IsNullOrWhiteSpace(reportSection.ReportSectionText) && reportSection.ReportSectionText.Length > 10000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ReportSectionText", "10000"), new[] { nameof(reportSection.ReportSectionText) });
            }

            if (reportSection.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(reportSection.LastUpdateDate_UTC) });
            }
            else
            {
                if (reportSection.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(reportSection.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == reportSection.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", reportSection.LastUpdateContactTVItemID.ToString()), new[] { nameof(reportSection.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(reportSection.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
