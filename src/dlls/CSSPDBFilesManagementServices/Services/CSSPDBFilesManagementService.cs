/*
 * Manually edited
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

namespace CSSPDBFilesManagementServices
{
    public partial interface ICSSPDBFilesManagementService
    {
        Task<ActionResult<bool>> Delete(int CSSPFileID);
        Task<ActionResult<List<CSSPFile>>> GetCSSPFileList(int skip = 0, int take = 100);
        Task<ActionResult<int>> GetCSSPFileNextIndexToUse();
        Task<ActionResult<CSSPFile>> GetWithCSSPFileID(int CSSPFileID);
        Task<ActionResult<CSSPFile>> GetWithAzureStorageAndAzureFileName(string AzureStorage, string AzureFileName);
        Task<ActionResult<CSSPFile>> Post(CSSPFile csspFile);
        Task<ActionResult<CSSPFile>> Put(CSSPFile csspFile);
        CSSPDBFilesManagementContext dbFM { get; set; }
    }
    public partial class CSSPDBFilesManagementService : ControllerBase, ICSSPDBFilesManagementService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public CSSPDBFilesManagementContext dbFM { get; set; }

        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDBFilesManagementService(ICSSPCultureService CSSPCultureService, ILocalService LocalService, CSSPDBFilesManagementContext dbFM)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.dbFM = dbFM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<int>> GetCSSPFileNextIndexToUse()
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            int? LastIndex = (from c in dbFM.CSSPFiles
                              orderby c.CSSPFileID descending
                              select c.CSSPFileID).FirstOrDefault();

            LastIndex = LastIndex == null ? 1 : LastIndex + 1;

            return await Task.FromResult(Ok(LastIndex));
        }
        public async Task<ActionResult<CSSPFile>> GetWithCSSPFileID(int CSSPFileID)
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            CSSPFile csspFile = (from c in dbFM.CSSPFiles.AsNoTracking()
                                 where c.CSSPFileID == CSSPFileID
                                 select c).FirstOrDefault();

            if (csspFile == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CSSPFile", "CSSPFileID", CSSPFileID.ToString())));
            }

            return await Task.FromResult(Ok(csspFile));
        }
        public async Task<ActionResult<CSSPFile>> GetWithAzureStorageAndAzureFileName(string AzureStorage, string AzureFileName)
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            CSSPFile csspFile = (from c in dbFM.CSSPFiles.AsNoTracking()
                                 where c.AzureStorage == AzureStorage
                                 && c.AzureFileName == AzureFileName
                                 select c).FirstOrDefault();

            if (csspFile == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CSSPFile", "AzureStorage,AzureFileName", $"{ AzureStorage }, { AzureFileName }")));
            }

            return await Task.FromResult(Ok(csspFile));
        }
        public async Task<ActionResult<List<CSSPFile>>> GetCSSPFileList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<CSSPFile> csspFileList = (from c in dbFM.CSSPFiles.AsNoTracking() orderby c.CSSPFileID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(csspFileList));
        }
        public async Task<ActionResult<bool>> Delete(int CSSPFileID)
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            CSSPFile csspFile = (from c in dbFM.CSSPFiles
                                 where c.CSSPFileID == CSSPFileID
                                 select c).FirstOrDefault();

            if (csspFile == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CSSPFile", "CSSPFileID", CSSPFileID.ToString())));
            }

            try
            {
                dbFM.CSSPFiles.Remove(csspFile);
                dbFM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<CSSPFile>> Post(CSSPFile csspFile)
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            if (csspFile == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "csspFile")));
            }

            ValidationResults = Validate(new ValidationContext(csspFile), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            int? LastIndex = (from c in dbFM.CSSPFiles
                              orderby c.CSSPFileID descending
                              select c.CSSPFileID).FirstOrDefault();

            LastIndex = LastIndex == null ? 1 : LastIndex + 1;

            try
            {
                csspFile.CSSPFileID = (int)LastIndex;
                dbFM.CSSPFiles.Add(csspFile);
                dbFM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(csspFile));
        }
        public async Task<ActionResult<CSSPFile>> Put(CSSPFile csspFile)
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            if (csspFile == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "csspFile")));
            }

            ValidationResults = Validate(new ValidationContext(csspFile), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbFM.CSSPFiles.Update(csspFile);
                dbFM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(csspFile));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            CSSPFile csspFile = validationContext.ObjectInstance as CSSPFile;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (csspFile.CSSPFileID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "CSSPFileID"), new[] { nameof(csspFile.CSSPFileID) });
                }

                if (!(from c in dbFM.CSSPFiles select c).Where(c => c.CSSPFileID == csspFile.CSSPFileID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CSSPFile", "CSSPFileID", csspFile.CSSPFileID.ToString()), new[] { nameof(csspFile.CSSPFileID) });
                }
            }

            // doing AzureStorage
            if (string.IsNullOrWhiteSpace(csspFile.AzureStorage))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AzureStorage"), new[] { nameof(csspFile.AzureStorage) });
            }

            if (!string.IsNullOrWhiteSpace(csspFile.AzureStorage) && csspFile.AzureStorage.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureStorage", "100"), new[] { nameof(csspFile.AzureStorage) });
            }

            // doing AzureFileName
            if (string.IsNullOrWhiteSpace(csspFile.AzureFileName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AzureFileName"), new[] { nameof(csspFile.AzureFileName) });
            }

            if (!string.IsNullOrWhiteSpace(csspFile.AzureFileName) && csspFile.AzureFileName.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureFileName", "200"), new[] { nameof(csspFile.AzureFileName) });
            }

            // doing AzureETag
            if (string.IsNullOrWhiteSpace(csspFile.AzureETag))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AzureETag"), new[] { nameof(csspFile.AzureETag) });
            }

            if (!string.IsNullOrWhiteSpace(csspFile.AzureETag) && csspFile.AzureETag.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureETag", "100"), new[] { nameof(csspFile.AzureETag) });
            }

            // doing AzureCreationTimeUTC
            if (csspFile.AzureCreationTimeUTC == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AzureCreationTimeUTC"), new[] { nameof(csspFile.AzureCreationTimeUTC) });
            }

            if (csspFile.AzureCreationTimeUTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "AzureCreationTimeUTC", "1980"), new[] { nameof(csspFile.AzureCreationTimeUTC) });
            }
        }
        #endregion Functions private

    }
}