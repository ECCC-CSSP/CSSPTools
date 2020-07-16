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
   public partial interface ITVFileService
    {
       Task<ActionResult<bool>> Delete(int TVFileID);
       Task<ActionResult<List<TVFile>>> GetTVFileList(int skip = 0, int take = 100);
       Task<ActionResult<TVFile>> GetTVFileWithTVFileID(int TVFileID);
       Task<ActionResult<TVFile>> Post(TVFile tvfile);
       Task<ActionResult<TVFile>> Put(TVFile tvfile);
    }
    public partial class TVFileService : ControllerBase, ITVFileService
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
        public TVFileService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<TVFile>> GetTVFileWithTVFileID(int TVFileID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                TVFile tvFile = (from c in dbIM.TVFiles.AsNoTracking()
                                   where c.TVFileID == TVFileID
                                   select c).FirstOrDefault();

                if (tvFile == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvFile));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVFile tvFile = (from c in dbLocal.TVFiles.AsNoTracking()
                        where c.TVFileID == TVFileID
                        select c).FirstOrDefault();

                if (tvFile == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvFile));
            }
            else
            {
                TVFile tvFile = (from c in db.TVFiles.AsNoTracking()
                        where c.TVFileID == TVFileID
                        select c).FirstOrDefault();

                if (tvFile == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvFile));
            }
        }
        public async Task<ActionResult<List<TVFile>>> GetTVFileList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<TVFile> tvFileList = (from c in dbIM.TVFiles.AsNoTracking() orderby c.TVFileID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(tvFileList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<TVFile> tvFileList = (from c in dbLocal.TVFiles.AsNoTracking() orderby c.TVFileID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(tvFileList));
            }
            else
            {
                List<TVFile> tvFileList = (from c in db.TVFiles.AsNoTracking() orderby c.TVFileID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(tvFileList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int TVFileID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                TVFile tvFile = (from c in dbIM.TVFiles
                                   where c.TVFileID == TVFileID
                                   select c).FirstOrDefault();
            
                if (tvFile == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileID", TVFileID.ToString())));
                }
            
                try
                {
                    dbIM.TVFiles.Remove(tvFile);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }
            
                return await Task.FromResult(Ok(true));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVFile tvFile = (from c in dbLocal.TVFiles
                                   where c.TVFileID == TVFileID
                                   select c).FirstOrDefault();
                
                if (tvFile == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileID", TVFileID.ToString())));
                }

                try
                {
                   dbLocal.TVFiles.Remove(tvFile);
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
                TVFile tvFile = (from c in db.TVFiles
                                   where c.TVFileID == TVFileID
                                   select c).FirstOrDefault();
                
                if (tvFile == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileID", TVFileID.ToString())));
                }

                try
                {
                   db.TVFiles.Remove(tvFile);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<TVFile>> Post(TVFile tvFile)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvFile), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.TVFiles.Add(tvFile);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvFile));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.TVFiles.Add(tvFile);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvFile));
            }
            else
            {
                try
                {
                   db.TVFiles.Add(tvFile);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvFile));
            }
        }
        public async Task<ActionResult<TVFile>> Put(TVFile tvFile)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvFile), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.TVFiles.Update(tvFile);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvFile));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.TVFiles.Update(tvFile);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvFile));
            }
            else
            {
            try
            {
               db.TVFiles.Update(tvFile);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvFile));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            TVFile tvFile = validationContext.ObjectInstance as TVFile;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvFile.TVFileID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TVFileID"), new[] { "TVFileID" });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.TVFiles select c).Where(c => c.TVFileID == tvFile.TVFileID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileID", tvFile.TVFileID.ToString()), new[] { "TVFileID" });
                    }
                }
                else
                {
                    if (!(from c in db.TVFiles select c).Where(c => c.TVFileID == tvFile.TVFileID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileID", tvFile.TVFileID.ToString()), new[] { "TVFileID" });
                    }
                }
            }

            TVItem TVItemTVFileTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemTVFileTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tvFile.TVFileTVItemID select c).FirstOrDefault();
                if (TVItemTVFileTVItemID == null)
                {
                    TVItemTVFileTVItemID = (from c in dbIM.TVItems where c.TVItemID == tvFile.TVFileTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemTVFileTVItemID = (from c in db.TVItems where c.TVItemID == tvFile.TVFileTVItemID select c).FirstOrDefault();
            }

            if (TVItemTVFileTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVFileTVItemID", tvFile.TVFileTVItemID.ToString()), new[] { "TVFileTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.File,
                };
                if (!AllowableTVTypes.Contains(TVItemTVFileTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "TVFileTVItemID", "File"), new[] { "TVFileTVItemID" });
                }
            }

            if (tvFile.TemplateTVType != null)
            {
                retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvFile.TemplateTVType);
                if (tvFile.TemplateTVType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TemplateTVType"), new[] { "TemplateTVType" });
                }
            }

            if (tvFile.ReportTypeID != null)
            {
                ReportType ReportTypeReportTypeID = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    ReportTypeReportTypeID = (from c in dbLocal.ReportTypes where c.ReportTypeID == tvFile.ReportTypeID select c).FirstOrDefault();
                    if (ReportTypeReportTypeID == null)
                    {
                        ReportTypeReportTypeID = (from c in dbIM.ReportTypes where c.ReportTypeID == tvFile.ReportTypeID select c).FirstOrDefault();
                    }
                }
                else
                {
                    ReportTypeReportTypeID = (from c in db.ReportTypes where c.ReportTypeID == tvFile.ReportTypeID select c).FirstOrDefault();
                }

                if (ReportTypeReportTypeID == null)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportTypeID", (tvFile.ReportTypeID == null ? "" : tvFile.ReportTypeID.ToString())), new[] { "ReportTypeID" });
                }
            }

            //Parameters has no StringLength Attribute

            if (tvFile.Year != null)
            {
                if (tvFile.Year < 1980 || tvFile.Year > 2050)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Year", "1980", "2050"), new[] { "Year" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvFile.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            retStr = enums.EnumTypeOK(typeof(FilePurposeEnum), (int?)tvFile.FilePurpose);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "FilePurpose"), new[] { "FilePurpose" });
            }

            retStr = enums.EnumTypeOK(typeof(FileTypeEnum), (int?)tvFile.FileType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "FileType"), new[] { "FileType" });
            }

            if (tvFile.FileSize_kb < 0 || tvFile.FileSize_kb > 100000000)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "FileSize_kb", "0", "100000000"), new[] { "FileSize_kb" });
            }

            //FileInfo has no StringLength Attribute

            if (tvFile.FileCreatedDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "FileCreatedDate_UTC"), new[] { "FileCreatedDate_UTC" });
            }
            else
            {
                if (tvFile.FileCreatedDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "FileCreatedDate_UTC", "1980"), new[] { "FileCreatedDate_UTC" });
                }
            }

            if (!string.IsNullOrWhiteSpace(tvFile.ClientFilePath) && tvFile.ClientFilePath.Length > 250)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "ClientFilePath", "250"), new[] { "ClientFilePath" });
            }

            if (string.IsNullOrWhiteSpace(tvFile.ServerFileName))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "ServerFileName"), new[] { "ServerFileName" });
            }

            if (!string.IsNullOrWhiteSpace(tvFile.ServerFileName) && tvFile.ServerFileName.Length > 250)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "ServerFileName", "250"), new[] { "ServerFileName" });
            }

            if (string.IsNullOrWhiteSpace(tvFile.ServerFilePath))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "ServerFilePath"), new[] { "ServerFilePath" });
            }

            if (!string.IsNullOrWhiteSpace(tvFile.ServerFilePath) && tvFile.ServerFilePath.Length > 250)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "ServerFilePath", "250"), new[] { "ServerFilePath" });
            }

            if (tvFile.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvFile.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tvFile.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == tvFile.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvFile.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvFile.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
