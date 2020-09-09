using CSSPModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CSSPCultureServices.Resources;

namespace CSSPDBFilesManagementServices.Tests
{
    [Collection("Sequential")]
    public partial class CSSPDBFilesManagementServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBFilesManagementService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(CSSPDBFilesManagementService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBFilesManagementService_All_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPFile csspFile = new CSSPFile()
            {
                //CSSPFileID = 1000000,
                AzureFileName = "TestingFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
            };

            CSSPDBFilesManagementService.dbFM.Database.BeginTransaction();

            // testing Post
            var actionCSSPFilePost = await CSSPDBFilesManagementService.Post(csspFile);
            Assert.Equal(200, ((ObjectResult)actionCSSPFilePost.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCSSPFilePost.Result).Value);
            CSSPFile csspFileNewPost = (CSSPFile)((OkObjectResult)actionCSSPFilePost.Result).Value;
            Assert.NotNull(csspFileNewPost);
            Assert.Equal(csspFile.CSSPFileID, csspFileNewPost.CSSPFileID);
            Assert.Equal(csspFile.AzureFileName, csspFileNewPost.AzureFileName);
            Assert.Equal(csspFile.AzureETag, csspFileNewPost.AzureETag);
            Assert.Equal(csspFile.AzureStorage, csspFileNewPost.AzureStorage);
            Assert.Equal(csspFile.AzureCreationTimeUTC, csspFileNewPost.AzureCreationTimeUTC);

            // testing Put
            csspFileNewPost.AzureFileName = "NewAzureFileName";
            var actionCSSPFilePut = await CSSPDBFilesManagementService.Put(csspFileNewPost);
            Assert.Equal(200, ((ObjectResult)actionCSSPFilePut.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCSSPFilePut.Result).Value);
            CSSPFile csspFileNewPut = (CSSPFile)((OkObjectResult)actionCSSPFilePut.Result).Value;
            Assert.NotNull(csspFileNewPut);
            Assert.Equal(csspFileNewPost.CSSPFileID, csspFileNewPut.CSSPFileID);
            Assert.Equal(csspFileNewPost.AzureFileName, csspFileNewPut.AzureFileName);
            Assert.Equal(csspFileNewPost.AzureETag, csspFileNewPut.AzureETag);
            Assert.Equal(csspFileNewPost.AzureStorage, csspFileNewPut.AzureStorage);
            Assert.Equal(csspFileNewPost.AzureCreationTimeUTC, csspFileNewPut.AzureCreationTimeUTC);

            // testing GetWithCSSPFileID
            var actionCSSPFileGetWithID = await CSSPDBFilesManagementService.GetWithCSSPFileID(csspFileNewPut.CSSPFileID);
            Assert.Equal(200, ((ObjectResult)actionCSSPFileGetWithID.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCSSPFileGetWithID.Result).Value);
            CSSPFile csspFileNewGetWithID = (CSSPFile)((OkObjectResult)actionCSSPFileGetWithID.Result).Value;
            Assert.NotNull(csspFileNewGetWithID);
            Assert.Equal(csspFileNewPut.CSSPFileID, csspFileNewGetWithID.CSSPFileID);
            Assert.Equal(csspFileNewPut.AzureFileName, csspFileNewGetWithID.AzureFileName);
            Assert.Equal(csspFileNewPut.AzureETag, csspFileNewGetWithID.AzureETag);
            Assert.Equal(csspFileNewPut.AzureStorage, csspFileNewGetWithID.AzureStorage);
            Assert.Equal(csspFileNewPut.AzureCreationTimeUTC, csspFileNewGetWithID.AzureCreationTimeUTC);

            // testing GetWithAzureStorageAndAzureFileName
            var actionCSSPFileGetWithAzureStorageAndAzureFileName = await CSSPDBFilesManagementService.GetWithAzureStorageAndAzureFileName(csspFileNewGetWithID.AzureStorage, csspFileNewGetWithID.AzureFileName);
            Assert.Equal(200, ((ObjectResult)actionCSSPFileGetWithAzureStorageAndAzureFileName.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCSSPFileGetWithAzureStorageAndAzureFileName.Result).Value);
            CSSPFile csspFileNewGetWithAzureStorageAndAzureFileName = (CSSPFile)((OkObjectResult)actionCSSPFileGetWithAzureStorageAndAzureFileName.Result).Value;
            Assert.NotNull(csspFileNewGetWithAzureStorageAndAzureFileName);
            Assert.Equal(csspFileNewGetWithID.CSSPFileID, csspFileNewGetWithAzureStorageAndAzureFileName.CSSPFileID);
            Assert.Equal(csspFileNewGetWithID.AzureFileName, csspFileNewGetWithAzureStorageAndAzureFileName.AzureFileName);
            Assert.Equal(csspFileNewGetWithID.AzureETag, csspFileNewGetWithAzureStorageAndAzureFileName.AzureETag);
            Assert.Equal(csspFileNewGetWithID.AzureStorage, csspFileNewGetWithAzureStorageAndAzureFileName.AzureStorage);
            Assert.Equal(csspFileNewGetWithID.AzureCreationTimeUTC, csspFileNewGetWithAzureStorageAndAzureFileName.AzureCreationTimeUTC);

            // testing GetCSSPFileNextIndexToUse
            var actionGetCSSPFileNextIndexToUse = await CSSPDBFilesManagementService.GetCSSPFileNextIndexToUse();
            Assert.Equal(200, ((ObjectResult)actionGetCSSPFileNextIndexToUse.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionGetCSSPFileNextIndexToUse.Result).Value);
            int? LastIndexRet = (int?)((OkObjectResult)actionGetCSSPFileNextIndexToUse.Result).Value;
            Assert.NotNull(LastIndexRet);
            Assert.True(LastIndexRet > 0);

            // testing GetCSSPFileList
            var actionCSSPFileGetCSSPFileList = await CSSPDBFilesManagementService.GetCSSPFileList();
            Assert.Equal(200, ((ObjectResult)actionCSSPFileGetCSSPFileList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCSSPFileGetCSSPFileList.Result).Value);
            List<CSSPFile> csspFileGetCSSPFileList = (List<CSSPFile>)((OkObjectResult)actionCSSPFileGetCSSPFileList.Result).Value;
            Assert.True(csspFileGetCSSPFileList.Count > 0);

            // testing Delete
            var actionDelete = await CSSPDBFilesManagementService.Delete(csspFileNewPost.CSSPFileID);
            Assert.Equal(200, ((ObjectResult)actionDelete.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDelete.Result).Value);
            bool DeleteRet = (bool)((OkObjectResult)actionDelete.Result).Value;
            Assert.True(DeleteRet);

            CSSPDBFilesManagementService.dbFM.Database.RollbackTransaction();
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBFilesManagementService_Unauthorized_All_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LocalService.LoggedInContactInfo = null;

            CSSPFile csspFile = new CSSPFile()
            {
                //CSSPFileID = 1000000,
                AzureFileName = "TestingFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
            };

            CSSPDBFilesManagementService.dbFM.Database.BeginTransaction();

            var actionCSSPFile1 = await CSSPDBFilesManagementService.GetCSSPFileNextIndexToUse();
            Assert.NotEqual(200, ((ObjectResult)actionCSSPFile1.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPFile1.Result).StatusCode);

            var actionCSSPFile2 = await CSSPDBFilesManagementService.GetWithCSSPFileID(12345);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPFile2.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPFile2.Result).StatusCode);

            var actionCSSPFile3 = await CSSPDBFilesManagementService.GetWithAzureStorageAndAzureFileName("aaa", "bbb");
            Assert.NotEqual(200, ((ObjectResult)actionCSSPFile3.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPFile3.Result).StatusCode);

            var actionCSSPFile4 = await CSSPDBFilesManagementService.GetCSSPFileList();
            Assert.NotEqual(200, ((ObjectResult)actionCSSPFile4.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPFile4.Result).StatusCode);

            var actionCSSPFile5 = await CSSPDBFilesManagementService.Delete(1234);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPFile5.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPFile5.Result).StatusCode);

            var actionCSSPFile6 = await CSSPDBFilesManagementService.Post(csspFile);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPFile6.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPFile6.Result).StatusCode);

            var actionCSSPFile7 = await CSSPDBFilesManagementService.Post(csspFile);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPFile7.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPFile7.Result).StatusCode);

            CSSPDBFilesManagementService.dbFM.Database.RollbackTransaction();
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBFilesManagementService_GetWithCSSPFileID_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int CSSPFileID = 0;

            CSSPDBFilesManagementService.dbFM.Database.BeginTransaction();

            var actionCSSPFile = await CSSPDBFilesManagementService.GetWithCSSPFileID(CSSPFileID);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPFile.Result).StatusCode);
            Assert.Equal(400, ((BadRequestObjectResult)actionCSSPFile.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CSSPFile", "CSSPFileID", CSSPFileID.ToString()),
                ((BadRequestObjectResult)actionCSSPFile.Result).Value);

            CSSPDBFilesManagementService.dbFM.Database.RollbackTransaction();
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBFilesManagementService_GetWithAzureStorageAndAzureFileName_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string AzureStorage = "WillNotFind";
            string AzureFileName = "WillNotFind";

            CSSPDBFilesManagementService.dbFM.Database.BeginTransaction();

            var actionCSSPFile = await CSSPDBFilesManagementService.GetWithAzureStorageAndAzureFileName(AzureStorage, AzureFileName);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPFile.Result).StatusCode);
            Assert.Equal(400, ((BadRequestObjectResult)actionCSSPFile.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CSSPFile", "AzureStorage,AzureFileName", $"{ AzureStorage }, { AzureFileName }"),
                ((BadRequestObjectResult)actionCSSPFile.Result).Value);

            CSSPDBFilesManagementService.dbFM.Database.RollbackTransaction();
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBFilesManagementService_GetCSSPFileList_Skip_2_Take_3_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int skip = 2;
            int take = 3;

            CSSPDBFilesManagementService.dbFM.Database.BeginTransaction();

            var actionCSSPFile = await CSSPDBFilesManagementService.GetCSSPFileList(skip, take);
            Assert.Equal(200, ((ObjectResult)actionCSSPFile.Result).StatusCode);
            List<CSSPFile> csspFileList = (List<CSSPFile>)((OkObjectResult)actionCSSPFile.Result).Value;
            Assert.True(csspFileList.Count == 3);

            CSSPDBFilesManagementService.dbFM.Database.RollbackTransaction();
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBFilesManagementService_Delete_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPDBFilesManagementService.dbFM.Database.BeginTransaction();

            int CSSPFileID = 0;

            var actionCSSPFile = await CSSPDBFilesManagementService.Delete(CSSPFileID);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPFile.Result).StatusCode);
            Assert.Equal(400, ((BadRequestObjectResult)actionCSSPFile.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CSSPFile", "CSSPFileID", CSSPFileID.ToString()),
                ((BadRequestObjectResult)actionCSSPFile.Result).Value);

            CSSPDBFilesManagementService.dbFM.Database.RollbackTransaction();
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBFilesManagementService_Post_BadRequest_CSSPFile_Equal_null_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPDBFilesManagementService.dbFM.Database.BeginTransaction();

            CSSPFile csspFile = null;

            var actionCSSPFile = await CSSPDBFilesManagementService.Post(csspFile);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPFile.Result).StatusCode);
            Assert.Equal(400, ((BadRequestObjectResult)actionCSSPFile.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "csspFile"),
                ((BadRequestObjectResult)actionCSSPFile.Result).Value);

            CSSPDBFilesManagementService.dbFM.Database.RollbackTransaction();
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBFilesManagementService_Put_BadRequest_CSSPFile_Equal_null_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPDBFilesManagementService.dbFM.Database.BeginTransaction();

            CSSPFile csspFile = null;

            var actionCSSPFile = await CSSPDBFilesManagementService.Put(csspFile);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPFile.Result).StatusCode);
            Assert.Equal(400, ((BadRequestObjectResult)actionCSSPFile.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "csspFile"),
                ((BadRequestObjectResult)actionCSSPFile.Result).Value);

            CSSPDBFilesManagementService.dbFM.Database.RollbackTransaction();
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
