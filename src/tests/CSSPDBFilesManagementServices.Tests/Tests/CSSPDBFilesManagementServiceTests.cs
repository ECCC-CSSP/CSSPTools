using CSSPDBModels;
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
using CSSPDBFilesManagementModels;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FilesManagementServices.Tests
{
    [Collection("Sequential")]
    public partial class FilesManagementServicesTests
    {
        #region Variables
        StringBuilder sb = new StringBuilder();
        Random random = new Random();
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(FilesManagementService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_All_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FilesManagement filesManagement = new FilesManagement()
            {
                FilesManagementID = 0,
                AzureFileName = "TestingFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
            };

            // testing AddOrModify -- add
            var actionFilesManagementAddOrModify = await FilesManagementService.AddOrModify(filesManagement);
            Assert.Equal(200, ((ObjectResult)actionFilesManagementAddOrModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionFilesManagementAddOrModify.Result).Value);
            FilesManagement filesManagementNewPost = (FilesManagement)((OkObjectResult)actionFilesManagementAddOrModify.Result).Value;
            Assert.NotNull(filesManagementNewPost);
            Assert.Equal(filesManagement.FilesManagementID, filesManagementNewPost.FilesManagementID);
            Assert.Equal(filesManagement.AzureFileName, filesManagementNewPost.AzureFileName);
            Assert.Equal(filesManagement.AzureETag, filesManagementNewPost.AzureETag);
            Assert.Equal(filesManagement.AzureStorage, filesManagementNewPost.AzureStorage);
            Assert.Equal(filesManagement.AzureCreationTimeUTC, filesManagementNewPost.AzureCreationTimeUTC);

            // testing AddOrModify -- modify
            filesManagementNewPost.AzureFileName = "NewAzureFileName";
            var actionFilesManagementPut = await FilesManagementService.AddOrModify(filesManagementNewPost);
            Assert.Equal(200, ((ObjectResult)actionFilesManagementPut.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionFilesManagementPut.Result).Value);
            FilesManagement filesManagementNewPut = (FilesManagement)((OkObjectResult)actionFilesManagementPut.Result).Value;
            Assert.NotNull(filesManagementNewPut);
            Assert.Equal(filesManagementNewPost.FilesManagementID, filesManagementNewPut.FilesManagementID);
            Assert.Equal(filesManagementNewPost.AzureFileName, filesManagementNewPut.AzureFileName);
            Assert.Equal(filesManagementNewPost.AzureETag, filesManagementNewPut.AzureETag);
            Assert.Equal(filesManagementNewPost.AzureStorage, filesManagementNewPut.AzureStorage);
            Assert.Equal(filesManagementNewPost.AzureCreationTimeUTC, filesManagementNewPut.AzureCreationTimeUTC);

            // testing GetWithFilesManagementID
            var actionFilesManagementGetWithID = await FilesManagementService.GetWithFilesManagementID(filesManagementNewPut.FilesManagementID);
            Assert.Equal(200, ((ObjectResult)actionFilesManagementGetWithID.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionFilesManagementGetWithID.Result).Value);
            FilesManagement filesManagementNewGetWithID = (FilesManagement)((OkObjectResult)actionFilesManagementGetWithID.Result).Value;
            Assert.NotNull(filesManagementNewGetWithID);
            Assert.Equal(filesManagementNewPut.FilesManagementID, filesManagementNewGetWithID.FilesManagementID);
            Assert.Equal(filesManagementNewPut.AzureFileName, filesManagementNewGetWithID.AzureFileName);
            Assert.Equal(filesManagementNewPut.AzureETag, filesManagementNewGetWithID.AzureETag);
            Assert.Equal(filesManagementNewPut.AzureStorage, filesManagementNewGetWithID.AzureStorage);
            Assert.Equal(filesManagementNewPut.AzureCreationTimeUTC, filesManagementNewGetWithID.AzureCreationTimeUTC);

            // testing GetWithAzureStorageAndAzureFileName
            var actionFilesManagementGetWithAzureStorageAndAzureFileName = await FilesManagementService.GetWithAzureStorageAndAzureFileName(filesManagementNewGetWithID.AzureStorage, filesManagementNewGetWithID.AzureFileName);
            Assert.Equal(200, ((ObjectResult)actionFilesManagementGetWithAzureStorageAndAzureFileName.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionFilesManagementGetWithAzureStorageAndAzureFileName.Result).Value);
            FilesManagement filesManagementNewGetWithAzureStorageAndAzureFileName = (FilesManagement)((OkObjectResult)actionFilesManagementGetWithAzureStorageAndAzureFileName.Result).Value;
            Assert.NotNull(filesManagementNewGetWithAzureStorageAndAzureFileName);
            Assert.Equal(filesManagementNewGetWithID.FilesManagementID, filesManagementNewGetWithAzureStorageAndAzureFileName.FilesManagementID);
            Assert.Equal(filesManagementNewGetWithID.AzureFileName, filesManagementNewGetWithAzureStorageAndAzureFileName.AzureFileName);
            Assert.Equal(filesManagementNewGetWithID.AzureETag, filesManagementNewGetWithAzureStorageAndAzureFileName.AzureETag);
            Assert.Equal(filesManagementNewGetWithID.AzureStorage, filesManagementNewGetWithAzureStorageAndAzureFileName.AzureStorage);
            Assert.Equal(filesManagementNewGetWithID.AzureCreationTimeUTC, filesManagementNewGetWithAzureStorageAndAzureFileName.AzureCreationTimeUTC);

            // testing GetFilesManagementNextIndexToUse
            var actionGetFilesManagementNextIndexToUse = await FilesManagementService.GetFilesManagementNextIndexToUse();
            Assert.Equal(200, ((ObjectResult)actionGetFilesManagementNextIndexToUse.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionGetFilesManagementNextIndexToUse.Result).Value);
            int? LastIndexRet = (int?)((OkObjectResult)actionGetFilesManagementNextIndexToUse.Result).Value;
            Assert.NotNull(LastIndexRet);
            Assert.True(LastIndexRet > 1);

            // testing GetFilesManagementList
            var actionFilesManagementGetFilesMangementList = await FilesManagementService.GetFilesManagementList();
            Assert.Equal(200, ((ObjectResult)actionFilesManagementGetFilesMangementList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionFilesManagementGetFilesMangementList.Result).Value);
            List<FilesManagement> filesManagementGetFilesManagementList = (List<FilesManagement>)((OkObjectResult)actionFilesManagementGetFilesMangementList.Result).Value;
            Assert.True(filesManagementGetFilesManagementList.Count() == 1);

            // testing Delete
            var actionDelete = await FilesManagementService.Delete(filesManagementNewPost.FilesManagementID);
            Assert.Equal(200, ((ObjectResult)actionDelete.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDelete.Result).Value);
            bool DeleteRet = (bool)((OkObjectResult)actionDelete.Result).Value;
            Assert.True(DeleteRet);

            // testing GetFilesManagementList
            var actionFilesManagementGetFilesManagementList2 = await FilesManagementService.GetFilesManagementList();
            Assert.Equal(200, ((ObjectResult)actionFilesManagementGetFilesManagementList2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionFilesManagementGetFilesManagementList2.Result).Value);
            List<FilesManagement> filesManagementGetFilesManagementList2 = (List<FilesManagement>)((OkObjectResult)actionFilesManagementGetFilesManagementList2.Result).Value;
            Assert.True(filesManagementGetFilesManagementList2.Count() == 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_Unauthorized_All_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            FilesManagement filesManagement = new FilesManagement()
            {
                AzureFileName = "TestingFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
            };

            var actionFilesManagement6 = await FilesManagementService.AddOrModify(filesManagement);
            Assert.NotEqual(200, ((ObjectResult)actionFilesManagement6.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionFilesManagement6.Result).StatusCode);

            var actionFilesManagement5 = await FilesManagementService.Delete(1234);
            Assert.NotEqual(200, ((ObjectResult)actionFilesManagement5.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionFilesManagement5.Result).StatusCode);

            var actionFilesManagement4 = await FilesManagementService.GetFilesManagementList();
            Assert.NotEqual(200, ((ObjectResult)actionFilesManagement4.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionFilesManagement4.Result).StatusCode);

            var actionFileManagement1 = await FilesManagementService.GetFilesManagementNextIndexToUse();
            Assert.NotEqual(200, ((ObjectResult)actionFileManagement1.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionFileManagement1.Result).StatusCode);

            var actionFilesManagement2 = await FilesManagementService.GetWithFilesManagementID(12345);
            Assert.NotEqual(200, ((ObjectResult)actionFilesManagement2.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionFilesManagement2.Result).StatusCode);

            var actionFilesManagement3 = await FilesManagementService.GetWithAzureStorageAndAzureFileName("aaa", "bbb");
            Assert.NotEqual(200, ((ObjectResult)actionFilesManagement3.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionFilesManagement3.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_GetWithFilesManagementID_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int FilesManagementID = 0;

            string error = string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "FilesManagement", "FilesManagementID", FilesManagementID.ToString());

            var actionFilesManagement = await FilesManagementService.GetWithFilesManagementID(FilesManagementID);
            Assert.NotEqual(200, ((ObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.Equal(400, ((BadRequestObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.Equal(error, ((BadRequestObjectResult)actionFilesManagement.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_GetWithAzureStorageAndAzureFileName_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string AzureStorage = "WillNotFind";
            string AzureFileName = "WillNotFind";

            string error = string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "FilesManagement", "AzureStorage,AzureFileName", $"{ AzureStorage }, { AzureFileName }");

            var actionFilesManagement = await FilesManagementService.GetWithAzureStorageAndAzureFileName(AzureStorage, AzureFileName);
            Assert.NotEqual(200, ((ObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.Equal(400, ((BadRequestObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.Equal(error, ((BadRequestObjectResult)actionFilesManagement.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_GetFilesManagementList_Skip_2_Take_3_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int skip = 2;
            int take = 3;

            FilesManagement filesManagement = new FilesManagement()
            {
                FilesManagementID = 0,
                AzureFileName = "TestingFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
            };

            for (int i = 0; i < 10; i++)
            {
                filesManagement.FilesManagementID = 0;
                filesManagement.AzureFileName = filesManagement.AzureFileName + i.ToString();

                // testing Post
                var actionFilesManagementPost = await FilesManagementService.AddOrModify(filesManagement);
                Assert.Equal(200, ((ObjectResult)actionFilesManagementPost.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionFilesManagementPost.Result).Value);
                FilesManagement filesManagementNewPost = (FilesManagement)((OkObjectResult)actionFilesManagementPost.Result).Value;
                Assert.NotNull(filesManagementNewPost);
                Assert.Equal(filesManagement.FilesManagementID, filesManagementNewPost.FilesManagementID);
                Assert.Equal(filesManagement.AzureFileName, filesManagementNewPost.AzureFileName);
                Assert.Equal(filesManagement.AzureETag, filesManagementNewPost.AzureETag);
                Assert.Equal(filesManagement.AzureStorage, filesManagementNewPost.AzureStorage);
                Assert.Equal(filesManagement.AzureCreationTimeUTC, filesManagementNewPost.AzureCreationTimeUTC);
            }

            var actionFilesManagement = await FilesManagementService.GetFilesManagementList(skip, take);
            Assert.Equal(200, ((ObjectResult)actionFilesManagement.Result).StatusCode);
            List<FilesManagement> filesManagementList = (List<FilesManagement>)((OkObjectResult)actionFilesManagement.Result).Value;
            Assert.True(filesManagementList.Count == 3);
            Assert.Equal("TestingFileName012", filesManagementList[0].AzureFileName);
            Assert.Equal("TestingFileName0123", filesManagementList[1].AzureFileName);
            Assert.Equal("TestingFileName01234", filesManagementList[2].AzureFileName);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_Delete_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int FilesManagementID = 0;

            string error = string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "FilesManagement", "FilesManagementID", FilesManagementID.ToString());

            var actionFilesManagement = await FilesManagementService.Delete(FilesManagementID);
            Assert.NotEqual(200, ((ObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.Equal(400, ((BadRequestObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.Equal(error, ((BadRequestObjectResult)actionFilesManagement.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_AddOrModify_BadRequest_FilesManagement_Equal_null_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FilesManagement filesManagement = null;

            string error = string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "filesManagement");

            var actionFilesManagement = await FilesManagementService.AddOrModify(filesManagement);
            Assert.NotEqual(200, ((ObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.Equal(400, ((BadRequestObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.Equal(error, ((BadRequestObjectResult)actionFilesManagement.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_ValidateAddOrModify_AzureFileName_Empty_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FilesManagement filesManagement = new FilesManagement()
            {
                FilesManagementID = 0,
                AzureFileName = "",
                AzureETag = "ThisIsETag",
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
            };

            string error = string.Format(CSSPCultureServicesRes._IsRequired, "AzureFileName");

            var actionFilesManagement = await FilesManagementService.AddOrModify(filesManagement);
            Assert.Equal(400, ((ObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionFilesManagement.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionFilesManagement.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_ValidateAddOrModify_AzureFileName_Length_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FilesManagement filesManagement = new FilesManagement()
            {
                FilesManagementID = 0,
                AzureFileName = "".PadRight(201, 'a'),
                AzureETag = "ThisIsETag",
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
            };

            string error = string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureFileName", "200");

            var actionFilesManagement = await FilesManagementService.AddOrModify(filesManagement);
            Assert.Equal(400, ((ObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionFilesManagement.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionFilesManagement.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_ValidateAddOrModify_AzureETag_Empty_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FilesManagement filesManagement = new FilesManagement()
            {
                FilesManagementID = 0,
                AzureFileName = "ThisIsFileName",
                AzureETag = "",
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
            };

            string error = string.Format(CSSPCultureServicesRes._IsRequired, "AzureETag");

            var actionFilesManagement = await FilesManagementService.AddOrModify(filesManagement);
            Assert.Equal(400, ((ObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionFilesManagement.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionFilesManagement.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_ValidateAddOrModify_AzureETag_Length_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FilesManagement filesManagement = new FilesManagement()
            {
                FilesManagementID = 0,
                AzureFileName = "ThisIsFileName",
                AzureETag = "".PadRight(101, 'a'),
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
            };

            string error = string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureETag", "100");

            var actionFilesManagement = await FilesManagementService.AddOrModify(filesManagement);
            Assert.Equal(400, ((ObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionFilesManagement.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionFilesManagement.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_ValidateAddOrModify_AzureStorage_Empty_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FilesManagement filesManagement = new FilesManagement()
            {
                FilesManagementID = 0,
                AzureFileName = "ThisIsFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "",
                AzureCreationTimeUTC = DateTime.UtcNow,
            };

            string error = string.Format(CSSPCultureServicesRes._IsRequired, "AzureStorage");

            var actionFilesManagement = await FilesManagementService.AddOrModify(filesManagement);
            Assert.Equal(400, ((ObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionFilesManagement.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionFilesManagement.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_ValidateAddOrModify_AzureStorage_Length_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FilesManagement filesManagement = new FilesManagement()
            {
                FilesManagementID = 0,
                AzureFileName = "ThisIsFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "".PadRight(101, 'a'),
                AzureCreationTimeUTC = DateTime.UtcNow,
            };

            string error = string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureStorage", "100");

            var actionFilesManagement = await FilesManagementService.AddOrModify(filesManagement);
            Assert.Equal(400, ((ObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionFilesManagement.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionFilesManagement.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_ValidateAddOrModify_AlreadyExist_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FilesManagement filesManagement = new FilesManagement()
            {
                FilesManagementID = 0,
                AzureFileName = "ThisIsFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "ThisAzureStorage",
                AzureCreationTimeUTC = DateTime.UtcNow,
            };

            var actionFilesManagementAddOrModify = await FilesManagementService.AddOrModify(filesManagement);
            Assert.Equal(200, ((ObjectResult)actionFilesManagementAddOrModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionFilesManagementAddOrModify.Result).Value);
            FilesManagement filesManagementNewPost = (FilesManagement)((OkObjectResult)actionFilesManagementAddOrModify.Result).Value;
            Assert.NotNull(filesManagementNewPost);
            Assert.Equal(filesManagement.FilesManagementID, filesManagementNewPost.FilesManagementID);
            Assert.Equal(filesManagement.AzureFileName, filesManagementNewPost.AzureFileName);
            Assert.Equal(filesManagement.AzureETag, filesManagementNewPost.AzureETag);
            Assert.Equal(filesManagement.AzureStorage, filesManagementNewPost.AzureStorage);
            Assert.Equal(filesManagement.AzureCreationTimeUTC, filesManagementNewPost.AzureCreationTimeUTC);

            string error = string.Format(CSSPCultureServicesRes._AlreadyExists, "FilesManagement");

            filesManagement.FilesManagementID = 0;

            var actionFilesManagement = await FilesManagementService.AddOrModify(filesManagement);
            Assert.Equal(400, ((ObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionFilesManagement.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionFilesManagement.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_ValidateAddOrModify_AlreadyExistWithDifferent_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FilesManagement filesManagement = new FilesManagement()
            {
                FilesManagementID = 0,
                AzureFileName = "ThisIsFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "ThisAzureStorage",
                AzureCreationTimeUTC = DateTime.UtcNow,
            };

            var actionFilesManagementAddOrModify = await FilesManagementService.AddOrModify(filesManagement);
            Assert.Equal(200, ((ObjectResult)actionFilesManagementAddOrModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionFilesManagementAddOrModify.Result).Value);
            FilesManagement filesManagementNewPost = (FilesManagement)((OkObjectResult)actionFilesManagementAddOrModify.Result).Value;
            Assert.NotNull(filesManagementNewPost);
            Assert.Equal(filesManagement.FilesManagementID, filesManagementNewPost.FilesManagementID);
            Assert.Equal(filesManagement.AzureFileName, filesManagementNewPost.AzureFileName);
            Assert.Equal(filesManagement.AzureETag, filesManagementNewPost.AzureETag);
            Assert.Equal(filesManagement.AzureStorage, filesManagementNewPost.AzureStorage);
            Assert.Equal(filesManagement.AzureCreationTimeUTC, filesManagementNewPost.AzureCreationTimeUTC);

            string error = string.Format(CSSPCultureServicesRes._AlreadyExistsWithDifferent_, "FilesManagement", "FilesManagementID");

            filesManagement.FilesManagementID = 3;

            var actionFilesManagement = await FilesManagementService.AddOrModify(filesManagement);
            Assert.Equal(400, ((ObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionFilesManagement.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionFilesManagement.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FilesManagementService_ValidateAddOrModify_AzureCreationTimeUTC_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FilesManagement filesManagement = new FilesManagement()
            {
                FilesManagementID = 0,
                AzureFileName = "ThisIsFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "ThisAzureStorage",
                AzureCreationTimeUTC = new DateTime(1978, 1, 1),
            };

            string error = string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "AzureCreationTimeUTC", "1980");

            var actionFilesManagement = await FilesManagementService.AddOrModify(filesManagement);
            Assert.Equal(400, ((ObjectResult)actionFilesManagement.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionFilesManagement.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionFilesManagement.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
