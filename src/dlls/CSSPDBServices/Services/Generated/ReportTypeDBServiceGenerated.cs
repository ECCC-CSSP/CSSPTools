/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPDBServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
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
    public partial interface IReportTypeDBService
    {
        Task<ActionResult<bool>> Delete(int ReportTypeID);
        Task<ActionResult<List<ReportType>>> GetReportTypeList(int skip = 0, int take = 100);
        Task<ActionResult<ReportType>> GetReportTypeWithReportTypeID(int ReportTypeID);
        Task<ActionResult<ReportType>> Post(ReportType reporttype);
        Task<ActionResult<ReportType>> Put(ReportType reporttype);
    }
    public partial class ReportTypeDBService : ControllerBase, IReportTypeDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public ReportTypeDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<ReportType>> GetReportTypeWithReportTypeID(int ReportTypeID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            ReportType reportType = (from c in db.ReportTypes.AsNoTracking()
                    where c.ReportTypeID == ReportTypeID
                    select c).FirstOrDefault();

            if (reportType == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(reportType));
        }
        public async Task<ActionResult<List<ReportType>>> GetReportTypeList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<ReportType> reportTypeList = (from c in db.ReportTypes.AsNoTracking() orderby c.ReportTypeID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(reportTypeList));
        }
        public async Task<ActionResult<bool>> Delete(int ReportTypeID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            ReportType reportType = (from c in db.ReportTypes
                    where c.ReportTypeID == ReportTypeID
                    select c).FirstOrDefault();

            if (reportType == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportTypeID", ReportTypeID.ToString())));
            }

            try
            {
                db.ReportTypes.Remove(reportType);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<ReportType>> Post(ReportType reportType)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(reportType), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.ReportTypes.Add(reportType);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(reportType));
        }
        public async Task<ActionResult<ReportType>> Put(ReportType reportType)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(reportType), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.ReportTypes.Update(reportType);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(reportType));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            ReportType reportType = validationContext.ObjectInstance as ReportType;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (reportType.ReportTypeID == 0)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ReportTypeID"), new[] { nameof(reportType.ReportTypeID) }));
                }

                if (!(from c in db.ReportTypes.AsNoTracking() select c).Where(c => c.ReportTypeID == reportType.ReportTypeID).Any())
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportTypeID", reportType.ReportTypeID.ToString()), new[] { nameof(reportType.ReportTypeID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)reportType.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(reportType.DBCommand) }));
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)reportType.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), new[] { nameof(reportType.TVType) }));
            }

            retStr = enums.EnumTypeOK(typeof(FileTypeEnum), (int?)reportType.FileType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FileType"), new[] { nameof(reportType.FileType) }));
            }

            if (string.IsNullOrWhiteSpace(reportType.UniqueCode))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "UniqueCode"), new[] { nameof(reportType.UniqueCode) }));
            }

            if (!string.IsNullOrWhiteSpace(reportType.UniqueCode) && reportType.UniqueCode.Length > 100)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "UniqueCode", "100"), new[] { nameof(reportType.UniqueCode) }));
            }

            if (reportType.Language != null)
            {
                retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)reportType.Language);
                if (reportType.Language == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(reportType.Language) }));
                }
            }

            if (!string.IsNullOrWhiteSpace(reportType.Name) && reportType.Name.Length > 100)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Name", "100"), new[] { nameof(reportType.Name) }));
            }

            if (!string.IsNullOrWhiteSpace(reportType.Description) && reportType.Description.Length > 1000)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Description", "1000"), new[] { nameof(reportType.Description) }));
            }

            if (!string.IsNullOrWhiteSpace(reportType.StartOfFileName) && reportType.StartOfFileName.Length > 100)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StartOfFileName", "100"), new[] { nameof(reportType.StartOfFileName) }));
            }

            if (reportType.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(reportType.LastUpdateDate_UTC) }));
            }
            else
            {
                if (reportType.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(reportType.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == reportType.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", reportType.LastUpdateContactTVItemID.ToString()), new[] { nameof(reportType.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(reportType.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
