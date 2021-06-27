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

namespace ManageServices
{
    public partial interface IManageFileService
    {
        Task<ActionResult<ManageFile>> ManageFileAddOrModify(ManageFile manageFile);
        Task<ActionResult<bool>> ManageFileDelete(int ManageFileID);
        Task<ActionResult<List<ManageFile>>> ManageFileGetList(int skip = 0, int take = 100);
        Task<ActionResult<int>> ManageFileGetNextIndexToUse();
        Task<ActionResult<ManageFile>> ManageFileGetWithAzureStorageAndAzureFileName(string AzureStorage, string AzureFileName);
        Task<ActionResult<ManageFile>> ManageFileGetWithManageFileID(int ManageFileID);
    }
    public partial class ManageFileService : ControllerBase, IManageFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBManageContext dbManage { get; set; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public ManageFileService(ICSSPCultureService CSSPCultureService, CSSPDBManageContext dbManage)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.dbManage = dbManage;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<ManageFile>> ManageFileAddOrModify(ManageFile manageFile)
        {
            if (manageFile == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "manageFile")));
            }

            ValidationResults = ManageFileValidateAddOrModify(new ValidationContext(manageFile));
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            return await DoManageFileAddOrModify(manageFile);
        }
        public async Task<ActionResult<bool>> ManageFileDelete(int ManagementFileID)
        {
            ManageFile manageFile = (from c in dbManage.ManageFiles
                                        where c.ManageFileID == ManagementFileID
                                        select c).FirstOrDefault();

            if (manageFile == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ManageFile", "ManageFileID", ManagementFileID.ToString())));
            }

            try
            {
                dbManage.ManageFiles.Remove(manageFile);
                dbManage.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<List<ManageFile>>> ManageFileGetList(int skip = 0, int take = 100)
        {
            List<ManageFile> csspFileList = (from c in dbManage.ManageFiles.AsNoTracking()
                                                  orderby c.ManageFileID
                                                  select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(csspFileList));
        }
        public async Task<ActionResult<int>> ManageFileGetNextIndexToUse()
        {
            int? LastIndex = (from c in dbManage.ManageFiles
                              orderby c.ManageFileID descending
                              select c.ManageFileID).FirstOrDefault() + 1;

            return await Task.FromResult(Ok(LastIndex));
        }
        public async Task<ActionResult<ManageFile>> ManageFileGetWithManageFileID(int ManageFileID)
        {
            ManageFile csspFile = (from c in dbManage.ManageFiles.AsNoTracking()
                                        where c.ManageFileID == ManageFileID
                                        select c).FirstOrDefault();

            if (csspFile == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ManageFile", "ManageFileID", ManageFileID.ToString())));
            }

            return await Task.FromResult(Ok(csspFile));
        }
        public async Task<ActionResult<ManageFile>> ManageFileGetWithAzureStorageAndAzureFileName(string AzureStorage, string AzureFileName)
        {
            ManageFile csspFile = (from c in dbManage.ManageFiles.AsNoTracking()
                                        where c.AzureStorage == AzureStorage
                                        && c.AzureFileName == AzureFileName
                                        select c).FirstOrDefault();

            if (csspFile == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ManageFile", "AzureStorage,AzureFileName", $"{ AzureStorage }, { AzureFileName }")));
            }

            return await Task.FromResult(Ok(csspFile));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

        #region Functions private
        private async Task<ActionResult<ManageFile>> DoManageFileAddOrModify(ManageFile manageFile)
        {
            ManageFile manageFileAddOrModify = new ManageFile();

            if (manageFile.ManageFileID == 0) // add
            {
                manageFileAddOrModify = manageFile;
                int? LastIndex = (from c in dbManage.ManageFiles
                                  orderby c.ManageFileID descending
                                  select c.ManageFileID).FirstOrDefault() + 1;

                manageFile.ManageFileID = (int)LastIndex;
                dbManage.ManageFiles.Add(manageFile);
            }
            else // modify
            {
                manageFileAddOrModify = (from c in dbManage.ManageFiles
                                              where c.ManageFileID == manageFile.ManageFileID
                                              select c).FirstOrDefault();

                if (manageFileAddOrModify == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ManageFile", "ManageFileID", manageFile.ManageFileID.ToString())));
                }

                manageFileAddOrModify.AzureCreationTimeUTC = manageFile.AzureCreationTimeUTC;
                manageFileAddOrModify.AzureETag = manageFile.AzureETag;
                manageFileAddOrModify.AzureFileName = manageFile.AzureFileName;
                manageFileAddOrModify.AzureStorage = manageFile.AzureStorage;
                manageFileAddOrModify.LoadedOnce = true;
            }

            try
            {
                dbManage.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(manageFileAddOrModify));
        }
        private IEnumerable<ValidationResult> ManageFileValidateAddOrModify(ValidationContext validationContext)
        {
            ManageFile manageFile = validationContext.ObjectInstance as ManageFile;

            // doing AzureStorage
            if (string.IsNullOrWhiteSpace(manageFile.AzureStorage))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AzureStorage"), new[] { "AzureStorage" });
            }
            else
            {
                if (manageFile.AzureStorage.Length > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureStorage", "100"), new[] { "AzureStorage" });
                }
            }

            // doing AzureFileName
            if (string.IsNullOrWhiteSpace(manageFile.AzureFileName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AzureFileName"), new[] { "AzureFileName" });
            }
            else
            {
                if (manageFile.AzureFileName.Length > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureFileName", "200"), new[] { "AzureFileName" });
                }
            }

            // doing AzureETag
            if (string.IsNullOrWhiteSpace(manageFile.AzureETag))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AzureETag"), new[] { "AzureETag" });
            }
            else
            {
                if (manageFile.AzureETag.Length > 100)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureETag", "100"), new[] { "AzureETag" });
                }
            }

            if (manageFile.AzureCreationTimeUTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "AzureCreationTimeUTC", "1980"), new[] { "AzureCreationTimeUTC" });
            }

            if (manageFile.ManageFileID == 0) // adding new
            {
                ManageFile manageFileAlreadyExist = (from c in dbManage.ManageFiles
                                                               where c.AzureETag == manageFile.AzureETag
                                                               && c.AzureFileName == manageFile.AzureFileName
                                                               && c.AzureStorage == manageFile.AzureStorage
                                                               select c).FirstOrDefault();

                if (manageFileAlreadyExist != null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._AlreadyExists, "ManageFile"), new[] { "" });
                }
            }
            else
            {
                ManageFile manageFileExist = (from c in dbManage.ManageFiles
                                                        where c.AzureFileName == manageFile.AzureFileName
                                                        && c.AzureStorage == manageFile.AzureStorage
                                                        && c.ManageFileID != manageFile.ManageFileID
                                                        select c).FirstOrDefault();

                if (manageFileExist != null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._AlreadyExistsWithDifferent_, "ManageFile", "ManageFileID"), new[] { "" });
                }

            }

        }
        #endregion Functions private

    }
}
