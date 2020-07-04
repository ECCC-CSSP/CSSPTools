/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Resources;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
   public interface IReportTypeService
    {
       Task<ActionResult<bool>> Delete(int ReportTypeID);
       Task<ActionResult<List<ReportType>>> GetReportTypeList();
       Task<ActionResult<ReportType>> GetReportTypeWithReportTypeID(int ReportTypeID);
       Task<ActionResult<ReportType>> Post(ReportType reporttype);
       Task<ActionResult<ReportType>> Put(ReportType reporttype);
    }
    public partial class ReportTypeService : ControllerBase, IReportTypeService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public ReportTypeService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<ReportType>> GetReportTypeWithReportTypeID(int ReportTypeID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                ReportType reporttype = (from c in dbLocal.ReportTypes.AsNoTracking()
                        where c.ReportTypeID == ReportTypeID
                        select c).FirstOrDefault();

                if (reporttype == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(reporttype));
            }
            else
            {
                ReportType reporttype = (from c in db.ReportTypes.AsNoTracking()
                        where c.ReportTypeID == ReportTypeID
                        select c).FirstOrDefault();

                if (reporttype == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(reporttype));
            }
        }
        public async Task<ActionResult<List<ReportType>>> GetReportTypeList()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                List<ReportType> reporttypeList = (from c in dbLocal.ReportTypes.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(reporttypeList));
            }
            else
            {
                List<ReportType> reporttypeList = (from c in db.ReportTypes.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(reporttypeList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int ReportTypeID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                ReportType reportType = (from c in dbLocal.ReportTypes
                                   where c.ReportTypeID == ReportTypeID
                                   select c).FirstOrDefault();
                
                if (reportType == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportTypeID", ReportTypeID.ToString())));
                }

                try
                {
                   dbLocal.ReportTypes.Remove(reportType);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
            else
            {
                ReportType reportType = (from c in db.ReportTypes
                                   where c.ReportTypeID == ReportTypeID
                                   select c).FirstOrDefault();
                
                if (reportType == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportTypeID", ReportTypeID.ToString())));
                }

                try
                {
                   db.ReportTypes.Remove(reportType);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<ReportType>> Post(ReportType reportType)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(reportType), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
                try
                {
                   dbLocal.ReportTypes.Add(reportType);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(reportType));
            }
            else
            {
                try
                {
                   db.ReportTypes.Add(reportType);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(reportType));
            }
        }
        public async Task<ActionResult<ReportType>> Put(ReportType reportType)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(reportType), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
            try
            {
               dbLocal.ReportTypes.Update(reportType);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(reportType));
            }
            else
            {
            try
            {
               db.ReportTypes.Update(reportType);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(reportType));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            ReportType reportType = validationContext.ObjectInstance as ReportType;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (reportType.ReportTypeID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "ReportTypeID"), new[] { "ReportTypeID" });
                }

                if (LoggedInService.IsLocal)
                {
                    if (!(from c in dbLocal.ReportTypes select c).Where(c => c.ReportTypeID == reportType.ReportTypeID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportTypeID", reportType.ReportTypeID.ToString()), new[] { "ReportTypeID" });
                    }
                }
                else
                {
                    if (!(from c in db.ReportTypes select c).Where(c => c.ReportTypeID == reportType.ReportTypeID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportTypeID", reportType.ReportTypeID.ToString()), new[] { "ReportTypeID" });
                    }
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)reportType.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TVType"), new[] { "TVType" });
            }

            retStr = enums.EnumTypeOK(typeof(FileTypeEnum), (int?)reportType.FileType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "FileType"), new[] { "FileType" });
            }

            if (string.IsNullOrWhiteSpace(reportType.UniqueCode))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "UniqueCode"), new[] { "UniqueCode" });
            }

            if (!string.IsNullOrWhiteSpace(reportType.UniqueCode) && reportType.UniqueCode.Length > 100)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "UniqueCode", "100"), new[] { "UniqueCode" });
            }

            if (reportType.Language != null)
            {
                retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)reportType.Language);
                if (reportType.Language == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "Language"), new[] { "Language" });
                }
            }

            if (!string.IsNullOrWhiteSpace(reportType.Name) && reportType.Name.Length > 100)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "Name", "100"), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(reportType.Description) && reportType.Description.Length > 1000)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "Description", "1000"), new[] { "Description" });
            }

            if (!string.IsNullOrWhiteSpace(reportType.StartOfFileName) && reportType.StartOfFileName.Length > 100)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "StartOfFileName", "100"), new[] { "StartOfFileName" });
            }

            if (reportType.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (reportType.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == reportType.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == reportType.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == reportType.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", reportType.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
