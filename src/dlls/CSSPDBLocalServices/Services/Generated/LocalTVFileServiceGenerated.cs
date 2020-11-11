/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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
    public partial interface ILocalTVFileDBService
    {
        Task<ActionResult<bool>> Delete(int LocalTVFileID);
        Task<ActionResult<List<LocalTVFile>>> GetLocalTVFileList(int skip = 0, int take = 100);
        Task<ActionResult<LocalTVFile>> GetLocalTVFileWithTVFileID(int TVFileID);
        Task<ActionResult<LocalTVFile>> Post(LocalTVFile localtvfile);
        Task<ActionResult<LocalTVFile>> Put(LocalTVFile localtvfile);
    }
    public partial class LocalTVFileDBService : ControllerBase, ILocalTVFileDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LocalTVFileDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<LocalTVFile>> GetLocalTVFileWithTVFileID(int TVFileID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalTVFile localTVFile = (from c in db.LocalTVFiles.AsNoTracking()
                    where c.TVFileID == TVFileID
                    select c).FirstOrDefault();

            if (localTVFile == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localTVFile));
        }
        public async Task<ActionResult<List<LocalTVFile>>> GetLocalTVFileList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalTVFile> localTVFileList = (from c in db.LocalTVFiles.AsNoTracking() orderby c.TVFileID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localTVFileList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalTVFileID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalTVFile localTVFile = (from c in db.LocalTVFiles
                    where c.TVFileID == LocalTVFileID
                    select c).FirstOrDefault();

            if (localTVFile == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVFile", "LocalTVFileID", LocalTVFileID.ToString())));
            }

            try
            {
                db.LocalTVFiles.Remove(localTVFile);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalTVFile>> Post(LocalTVFile localTVFile)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localTVFile), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalTVFiles.Add(localTVFile);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localTVFile));
        }
        public async Task<ActionResult<LocalTVFile>> Put(LocalTVFile localTVFile)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localTVFile), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalTVFiles.Update(localTVFile);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localTVFile));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalTVFile localTVFile = validationContext.ObjectInstance as LocalTVFile;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localTVFile.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localTVFile.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localTVFile.TVFileID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVFileID"), new[] { nameof(localTVFile.TVFileID) });
                }

                if (!(from c in db.LocalTVFiles.AsNoTracking() select c).Where(c => c.TVFileID == localTVFile.TVFileID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileID", localTVFile.TVFileID.ToString()), new[] { nameof(localTVFile.TVFileID) });
                }
            }

            LocalTVItem localTVItemTVFileTVItemID = null;
            localTVItemTVFileTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localTVFile.TVFileTVItemID select c).FirstOrDefault();

            if (localTVItemTVFileTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "TVFileTVItemID", localTVFile.TVFileTVItemID.ToString()), new[] { nameof(localTVFile.TVFileTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.File,
                };
                if (!AllowableTVTypes.Contains(localTVItemTVFileTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVFileTVItemID", "File"), new[] { nameof(localTVFile.TVFileTVItemID) });
                }
            }

            if (localTVFile.TemplateTVType != null)
            {
                retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)localTVFile.TemplateTVType);
                if (localTVFile.TemplateTVType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TemplateTVType"), new[] { nameof(localTVFile.TemplateTVType) });
                }
            }

            if (localTVFile.ReportTypeID != null)
            {
                LocalReportType localReportTypeReportTypeID = null;
                localReportTypeReportTypeID = (from c in db.LocalReportTypes.AsNoTracking() where c.ReportTypeID == localTVFile.ReportTypeID select c).FirstOrDefault();

                if (localReportTypeReportTypeID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportTypeID", (localTVFile.ReportTypeID == null ? "" : localTVFile.ReportTypeID.ToString())), new[] { nameof(localTVFile.ReportTypeID) });
                }
            }

            //Parameters has no StringLength Attribute

            if (localTVFile.Year != null)
            {
                if (localTVFile.Year < 1980 || localTVFile.Year > 2050)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Year", "1980", "2050"), new[] { nameof(localTVFile.Year) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)localTVFile.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(localTVFile.Language) });
            }

            retStr = enums.EnumTypeOK(typeof(FilePurposeEnum), (int?)localTVFile.FilePurpose);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FilePurpose"), new[] { nameof(localTVFile.FilePurpose) });
            }

            retStr = enums.EnumTypeOK(typeof(FileTypeEnum), (int?)localTVFile.FileType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FileType"), new[] { nameof(localTVFile.FileType) });
            }

            if (localTVFile.FileSize_kb < 0 || localTVFile.FileSize_kb > 100000000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "FileSize_kb", "0", "100000000"), new[] { nameof(localTVFile.FileSize_kb) });
            }

            //FileInfo has no StringLength Attribute

            if (localTVFile.FileCreatedDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FileCreatedDate_UTC"), new[] { nameof(localTVFile.FileCreatedDate_UTC) });
            }
            else
            {
                if (localTVFile.FileCreatedDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "FileCreatedDate_UTC", "1980"), new[] { nameof(localTVFile.FileCreatedDate_UTC) });
                }
            }

            if (!string.IsNullOrWhiteSpace(localTVFile.ClientFilePath) && localTVFile.ClientFilePath.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ClientFilePath", "250"), new[] { nameof(localTVFile.ClientFilePath) });
            }

            if (string.IsNullOrWhiteSpace(localTVFile.ServerFileName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ServerFileName"), new[] { nameof(localTVFile.ServerFileName) });
            }

            if (!string.IsNullOrWhiteSpace(localTVFile.ServerFileName) && localTVFile.ServerFileName.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ServerFileName", "250"), new[] { nameof(localTVFile.ServerFileName) });
            }

            if (string.IsNullOrWhiteSpace(localTVFile.ServerFilePath))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ServerFilePath"), new[] { nameof(localTVFile.ServerFilePath) });
            }

            if (!string.IsNullOrWhiteSpace(localTVFile.ServerFilePath) && localTVFile.ServerFilePath.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ServerFilePath", "250"), new[] { nameof(localTVFile.ServerFilePath) });
            }

            if (localTVFile.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localTVFile.LastUpdateDate_UTC) });
            }
            else
            {
                if (localTVFile.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localTVFile.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localTVFile.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localTVFile.LastUpdateContactTVItemID.ToString()), new[] { nameof(localTVFile.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localTVFile.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
