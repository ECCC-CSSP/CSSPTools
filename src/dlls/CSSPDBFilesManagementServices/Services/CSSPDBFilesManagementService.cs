/*
 * Manually edited
 *
 */

using CSSPEnums;
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
using CSSPDBFilesManagementModels;

namespace FilesManagementServices
{
    public partial interface IFilesManagementService
    {
        Task<ActionResult<FilesManagement>> AddOrModify(FilesManagement csspFile);
        Task<ActionResult<bool>> Delete(int CSSPFileID);
        Task<ActionResult<List<FilesManagement>>> GetFilesManagementList(int skip = 0, int take = 100);
        Task<ActionResult<int>> GetFilesManagementNextIndexToUse();
        Task<ActionResult<FilesManagement>> GetWithAzureStorageAndAzureFileName(string AzureStorage, string AzureFileName);
        Task<ActionResult<FilesManagement>> GetWithFilesManagementID(int CSSPFileID);
    }
    public partial class FilesManagementService : ControllerBase, IFilesManagementService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBFilesManagementContext dbFM { get; set; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public FilesManagementService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, CSSPDBFilesManagementContext dbFM)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.dbFM = dbFM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<FilesManagement>> AddOrModify(FilesManagement filesManagement)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            if (filesManagement == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "filesManagement")));
            }

            ValidationResults = ValidateAddOrModify(new ValidationContext(filesManagement));
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            return await DoAddOrModify(filesManagement);
        }
        public async Task<ActionResult<bool>> Delete(int FileManagementID)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            FilesManagement filesManagement = (from c in dbFM.FilesManagements
                                        where c.FilesManagementID == FileManagementID
                                        select c).FirstOrDefault();

            if (filesManagement == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "FilesManagement", "FilesManagementID", FileManagementID.ToString())));
            }

            try
            {
                dbFM.FilesManagements.Remove(filesManagement);
                dbFM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<List<FilesManagement>>> GetFilesManagementList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<FilesManagement> csspFileList = (from c in dbFM.FilesManagements.AsNoTracking()
                                                  orderby c.FilesManagementID
                                                  select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(csspFileList));
        }
        public async Task<ActionResult<int>> GetFilesManagementNextIndexToUse()
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            int? LastIndex = (from c in dbFM.FilesManagements
                              orderby c.FilesManagementID descending
                              select c.FilesManagementID).FirstOrDefault() + 1;

            return await Task.FromResult(Ok(LastIndex));
        }
        public async Task<ActionResult<FilesManagement>> GetWithFilesManagementID(int CSSPFileID)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            FilesManagement csspFile = (from c in dbFM.FilesManagements.AsNoTracking()
                                        where c.FilesManagementID == CSSPFileID
                                        select c).FirstOrDefault();

            if (csspFile == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "FilesManagement", "FilesManagementID", CSSPFileID.ToString())));
            }

            return await Task.FromResult(Ok(csspFile));
        }
        public async Task<ActionResult<FilesManagement>> GetWithAzureStorageAndAzureFileName(string AzureStorage, string AzureFileName)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            FilesManagement csspFile = (from c in dbFM.FilesManagements.AsNoTracking()
                                        where c.AzureStorage == AzureStorage
                                        && c.AzureFileName == AzureFileName
                                        select c).FirstOrDefault();

            if (csspFile == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "FilesManagement", "AzureStorage,AzureFileName", $"{ AzureStorage }, { AzureFileName }")));
            }

            return await Task.FromResult(Ok(csspFile));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

        #region Functions private
        private async Task<ActionResult<FilesManagement>> DoAddOrModify(FilesManagement filesManagement)
        {
            FilesManagement filesManagementAddOrModify = new FilesManagement();

            if (filesManagement.FilesManagementID == 0) // add
            {
                filesManagementAddOrModify = filesManagement;
                int? LastIndex = (from c in dbFM.FilesManagements
                                  orderby c.FilesManagementID descending
                                  select c.FilesManagementID).FirstOrDefault() + 1;

                filesManagement.FilesManagementID = (int)LastIndex;
                dbFM.FilesManagements.Add(filesManagement);
            }
            else // modify
            {
                filesManagementAddOrModify = (from c in dbFM.FilesManagements
                                              where c.FilesManagementID == filesManagement.FilesManagementID
                                              select c).FirstOrDefault();

                if (filesManagementAddOrModify == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "FilesManagement", "FilesManagementID", filesManagement.FilesManagementID.ToString())));
                }

                filesManagementAddOrModify.AzureCreationTimeUTC = filesManagement.AzureCreationTimeUTC;
                filesManagementAddOrModify.AzureETag = filesManagement.AzureETag;
                filesManagementAddOrModify.AzureFileName = filesManagement.AzureFileName;
                filesManagementAddOrModify.AzureStorage = filesManagement.AzureStorage;
            }

            try
            {
                dbFM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(filesManagementAddOrModify));
        }
        private IEnumerable<ValidationResult> ValidateAddOrModify(ValidationContext validationContext)
        {
            FilesManagement filesManagement = validationContext.ObjectInstance as FilesManagement;

            // doing AzureStorage
            if (string.IsNullOrWhiteSpace(filesManagement.AzureStorage))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AzureStorage"), new[] { "AzureStorage" });
            }
            else
            {
                if (filesManagement.AzureStorage.Length > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureStorage", "100"), new[] { "AzureStorage" });
                }
            }

            // doing AzureFileName
            if (string.IsNullOrWhiteSpace(filesManagement.AzureFileName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AzureFileName"), new[] { "AzureFileName" });
            }
            else
            {
                if (filesManagement.AzureFileName.Length > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureFileName", "200"), new[] { "AzureFileName" });
                }
            }

            // doing AzureETag
            if (string.IsNullOrWhiteSpace(filesManagement.AzureETag))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AzureETag"), new[] { "AzureETag" });
            }
            else
            {
                if (filesManagement.AzureETag.Length > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureETag", "100"), new[] { "AzureETag" });
                }
            }

            if (filesManagement.AzureCreationTimeUTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "AzureCreationTimeUTC", "1980"), new[] { "AzureCreationTimeUTC" });
            }

            if (filesManagement.FilesManagementID == 0) // adding new
            {
                FilesManagement filesManagementAlreadyExist = (from c in dbFM.FilesManagements
                                                               where c.AzureETag == filesManagement.AzureETag
                                                               && c.AzureFileName == filesManagement.AzureFileName
                                                               && c.AzureStorage == filesManagement.AzureStorage
                                                               select c).FirstOrDefault();

                if (filesManagementAlreadyExist != null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._AlreadyExists, "FilesManagement"), new[] { "" });
                }
            }
            else
            {
                FilesManagement filesManagementExist = (from c in dbFM.FilesManagements
                                                        where c.AzureFileName == filesManagement.AzureFileName
                                                        && c.AzureStorage == filesManagement.AzureStorage
                                                        && c.FilesManagementID != filesManagement.FilesManagementID
                                                        select c).FirstOrDefault();

                if (filesManagementExist != null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._AlreadyExistsWithDifferent_, "FilesManagement", "FilesManagementID"), new[] { "" });
                }

            }

        }
        #endregion Functions private

    }
}
