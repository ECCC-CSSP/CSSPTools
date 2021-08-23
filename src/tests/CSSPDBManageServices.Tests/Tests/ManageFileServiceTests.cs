using CSSPCultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManageServices.Tests
{
    [Collection("Sequential")]
    public partial class ManageServicesTests
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
        public async Task ManageFileService_All_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ManageFile manageFile = new ManageFile()
            {
                ManageFileID = 0,
                AzureFileName = "TestingFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
                LoadedOnce = true,
            };

            // testing AddOrModify -- add
            var actionManageFileAddOrModify = await ManageFileService.ManageFileAddOrModify(manageFile);
            Assert.Equal(200, ((ObjectResult)actionManageFileAddOrModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionManageFileAddOrModify.Result).Value);
            ManageFile manageFileNewPost = (ManageFile)((OkObjectResult)actionManageFileAddOrModify.Result).Value;
            Assert.NotNull(manageFileNewPost);
            Assert.Equal(manageFile.ManageFileID, manageFileNewPost.ManageFileID);
            Assert.Equal(manageFile.AzureFileName, manageFileNewPost.AzureFileName);
            Assert.Equal(manageFile.AzureETag, manageFileNewPost.AzureETag);
            Assert.Equal(manageFile.AzureStorage, manageFileNewPost.AzureStorage);
            Assert.Equal(manageFile.AzureCreationTimeUTC, manageFileNewPost.AzureCreationTimeUTC);

            // testing AddOrModify -- modify
            manageFileNewPost.AzureFileName = "NewAzureFileName";
            var actionManageFilePut = await ManageFileService.ManageFileAddOrModify(manageFileNewPost);
            Assert.Equal(200, ((ObjectResult)actionManageFilePut.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionManageFilePut.Result).Value);
            ManageFile manageFileNewPut = (ManageFile)((OkObjectResult)actionManageFilePut.Result).Value;
            Assert.NotNull(manageFileNewPut);
            Assert.Equal(manageFileNewPost.ManageFileID, manageFileNewPut.ManageFileID);
            Assert.Equal(manageFileNewPost.AzureFileName, manageFileNewPut.AzureFileName);
            Assert.Equal(manageFileNewPost.AzureETag, manageFileNewPut.AzureETag);
            Assert.Equal(manageFileNewPost.AzureStorage, manageFileNewPut.AzureStorage);
            Assert.Equal(manageFileNewPost.AzureCreationTimeUTC, manageFileNewPut.AzureCreationTimeUTC);

            // testing GetWithManageFileID
            var actionManageFileGetWithID = await ManageFileService.ManageFileGetWithManageFileID(manageFileNewPut.ManageFileID);
            Assert.Equal(200, ((ObjectResult)actionManageFileGetWithID.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionManageFileGetWithID.Result).Value);
            ManageFile manageFileNewGetWithID = (ManageFile)((OkObjectResult)actionManageFileGetWithID.Result).Value;
            Assert.NotNull(manageFileNewGetWithID);
            Assert.Equal(manageFileNewPut.ManageFileID, manageFileNewGetWithID.ManageFileID);
            Assert.Equal(manageFileNewPut.AzureFileName, manageFileNewGetWithID.AzureFileName);
            Assert.Equal(manageFileNewPut.AzureETag, manageFileNewGetWithID.AzureETag);
            Assert.Equal(manageFileNewPut.AzureStorage, manageFileNewGetWithID.AzureStorage);
            Assert.Equal(manageFileNewPut.AzureCreationTimeUTC, manageFileNewGetWithID.AzureCreationTimeUTC);

            // testing GetWithAzureStorageAndAzureFileName
            var actionManageFileGetWithAzureStorageAndAzureFileName = await ManageFileService.ManageFileGetWithAzureStorageAndAzureFileName(manageFileNewGetWithID.AzureStorage, manageFileNewGetWithID.AzureFileName);
            Assert.Equal(200, ((ObjectResult)actionManageFileGetWithAzureStorageAndAzureFileName.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionManageFileGetWithAzureStorageAndAzureFileName.Result).Value);
            ManageFile manageFileNewGetWithAzureStorageAndAzureFileName = (ManageFile)((OkObjectResult)actionManageFileGetWithAzureStorageAndAzureFileName.Result).Value;
            Assert.NotNull(manageFileNewGetWithAzureStorageAndAzureFileName);
            Assert.Equal(manageFileNewGetWithID.ManageFileID, manageFileNewGetWithAzureStorageAndAzureFileName.ManageFileID);
            Assert.Equal(manageFileNewGetWithID.AzureFileName, manageFileNewGetWithAzureStorageAndAzureFileName.AzureFileName);
            Assert.Equal(manageFileNewGetWithID.AzureETag, manageFileNewGetWithAzureStorageAndAzureFileName.AzureETag);
            Assert.Equal(manageFileNewGetWithID.AzureStorage, manageFileNewGetWithAzureStorageAndAzureFileName.AzureStorage);
            Assert.Equal(manageFileNewGetWithID.AzureCreationTimeUTC, manageFileNewGetWithAzureStorageAndAzureFileName.AzureCreationTimeUTC);

            // testing GetManageFileNextIndexToUse
            var actionGetManageFileNextIndexToUse = await ManageFileService.ManageFileGetNextIndexToUse();
            Assert.Equal(200, ((ObjectResult)actionGetManageFileNextIndexToUse.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionGetManageFileNextIndexToUse.Result).Value);
            int? LastIndexRet = (int?)((OkObjectResult)actionGetManageFileNextIndexToUse.Result).Value;
            Assert.NotNull(LastIndexRet);
            Assert.True(LastIndexRet > 1);

            // testing GetManageFileList
            var actionManageFileGetFilesMangementList = await ManageFileService.ManageFileGetList();
            Assert.Equal(200, ((ObjectResult)actionManageFileGetFilesMangementList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionManageFileGetFilesMangementList.Result).Value);
            List<ManageFile> manageFileGetManageFileList = (List<ManageFile>)((OkObjectResult)actionManageFileGetFilesMangementList.Result).Value;
            Assert.True(manageFileGetManageFileList.Count() == 1);

            // testing Delete
            var actionDelete = await ManageFileService.ManageFileDelete(manageFileNewPost.ManageFileID);
            Assert.Equal(200, ((ObjectResult)actionDelete.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDelete.Result).Value);
            bool DeleteRet = (bool)((OkObjectResult)actionDelete.Result).Value;
            Assert.True(DeleteRet);

            // testing GetManageFileList
            var actionManageFileGetManageFileList2 = await ManageFileService.ManageFileGetList();
            Assert.Equal(200, ((ObjectResult)actionManageFileGetManageFileList2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionManageFileGetManageFileList2.Result).Value);
            List<ManageFile> manageFileGetManageFileList2 = (List<ManageFile>)((OkObjectResult)actionManageFileGetManageFileList2.Result).Value;
            Assert.True(manageFileGetManageFileList2.Count() == 0);

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ManageFileService_GetWithAzureStorageAndAzureFileName_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string AzureStorage = "WillNotFind";
            string AzureFileName = "WillNotFind";

            string error = string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ManageFile", "AzureStorage,AzureFileName", $"{ AzureStorage }, { AzureFileName }");

            var actionManageFile = await ManageFileService.ManageFileGetWithAzureStorageAndAzureFileName(AzureStorage, AzureFileName);
            Assert.NotEqual(200, ((ObjectResult)actionManageFile.Result).StatusCode);
            Assert.Equal(400, ((BadRequestObjectResult)actionManageFile.Result).StatusCode);
            Assert.Equal(error, ((BadRequestObjectResult)actionManageFile.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ManageFileService_GetManageFileList_Skip_2_Take_3_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int skip = 2;
            int take = 3;

            ManageFile manageFile = new ManageFile()
            {
                ManageFileID = 0,
                AzureFileName = "TestingFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
                LoadedOnce = true,
            };

            for (int i = 0; i < 10; i++)
            {
                manageFile.ManageFileID = 0;
                manageFile.AzureFileName = manageFile.AzureFileName + i.ToString();

                // testing Post
                var actionManageFilePost = await ManageFileService.ManageFileAddOrModify(manageFile);
                Assert.Equal(200, ((ObjectResult)actionManageFilePost.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionManageFilePost.Result).Value);
                ManageFile manageFileNewPost = (ManageFile)((OkObjectResult)actionManageFilePost.Result).Value;
                Assert.NotNull(manageFileNewPost);
                Assert.Equal(manageFile.ManageFileID, manageFileNewPost.ManageFileID);
                Assert.Equal(manageFile.AzureFileName, manageFileNewPost.AzureFileName);
                Assert.Equal(manageFile.AzureETag, manageFileNewPost.AzureETag);
                Assert.Equal(manageFile.AzureStorage, manageFileNewPost.AzureStorage);
                Assert.Equal(manageFile.AzureCreationTimeUTC, manageFileNewPost.AzureCreationTimeUTC);
            }

            var actionManageFile = await ManageFileService.ManageFileGetList(skip, take);
            Assert.Equal(200, ((ObjectResult)actionManageFile.Result).StatusCode);
            List<ManageFile> manageFileList = (List<ManageFile>)((OkObjectResult)actionManageFile.Result).Value;
            Assert.True(manageFileList.Count == 3);
            Assert.Equal("TestingFileName012", manageFileList[0].AzureFileName);
            Assert.Equal("TestingFileName0123", manageFileList[1].AzureFileName);
            Assert.Equal("TestingFileName01234", manageFileList[2].AzureFileName);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ManageFileService_Delete_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int ManageFileID = 0;

            string error = string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ManageFile", "ManageFileID", ManageFileID.ToString());

            var actionManageFile = await ManageFileService.ManageFileDelete(ManageFileID);
            Assert.NotEqual(200, ((ObjectResult)actionManageFile.Result).StatusCode);
            Assert.Equal(400, ((BadRequestObjectResult)actionManageFile.Result).StatusCode);
            Assert.Equal(error, ((BadRequestObjectResult)actionManageFile.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ManageFileService_AddOrModify_BadRequest_ManageFile_Equal_null_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ManageFile manageFile = null;

            string error = string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "manageFile");

            var actionManageFile = await ManageFileService.ManageFileAddOrModify(manageFile);
            Assert.NotEqual(200, ((ObjectResult)actionManageFile.Result).StatusCode);
            Assert.Equal(400, ((BadRequestObjectResult)actionManageFile.Result).StatusCode);
            Assert.Equal(error, ((BadRequestObjectResult)actionManageFile.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ManageFileService_ValidateAddOrModify_AzureFileName_Empty_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ManageFile manageFile = new ManageFile()
            {
                ManageFileID = 0,
                AzureFileName = "",
                AzureETag = "ThisIsETag",
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
                LoadedOnce = true,
            };

            string error = string.Format(CSSPCultureServicesRes._IsRequired, "AzureFileName");

            var actionManageFile = await ManageFileService.ManageFileAddOrModify(manageFile);
            Assert.Equal(400, ((ObjectResult)actionManageFile.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionManageFile.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionManageFile.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ManageFileService_ValidateAddOrModify_AzureFileName_Length_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ManageFile manageFile = new ManageFile()
            {
                ManageFileID = 0,
                AzureFileName = "".PadRight(201, 'a'),
                AzureETag = "ThisIsETag",
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
                LoadedOnce = true,
            };

            string error = string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureFileName", "200");

            var actionManageFile = await ManageFileService.ManageFileAddOrModify(manageFile);
            Assert.Equal(400, ((ObjectResult)actionManageFile.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionManageFile.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionManageFile.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ManageFileService_ValidateAddOrModify_AzureETag_Empty_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ManageFile manageFile = new ManageFile()
            {
                ManageFileID = 0,
                AzureFileName = "ThisIsFileName",
                AzureETag = "",
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
                LoadedOnce = true,
            };

            string error = string.Format(CSSPCultureServicesRes._IsRequired, "AzureETag");

            var actionManageFile = await ManageFileService.ManageFileAddOrModify(manageFile);
            Assert.Equal(400, ((ObjectResult)actionManageFile.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionManageFile.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionManageFile.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ManageFileService_ValidateAddOrModify_AzureETag_Length_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ManageFile manageFile = new ManageFile()
            {
                ManageFileID = 0,
                AzureFileName = "ThisIsFileName",
                AzureETag = "".PadRight(101, 'a'),
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
                LoadedOnce = true,
            };

            string error = string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureETag", "100");

            var actionManageFile = await ManageFileService.ManageFileAddOrModify(manageFile);
            Assert.Equal(400, ((ObjectResult)actionManageFile.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionManageFile.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionManageFile.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ManageFileService_ValidateAddOrModify_AzureStorage_Empty_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ManageFile manageFile = new ManageFile()
            {
                ManageFileID = 0,
                AzureFileName = "ThisIsFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "",
                AzureCreationTimeUTC = DateTime.UtcNow,
                LoadedOnce = true,
            };

            string error = string.Format(CSSPCultureServicesRes._IsRequired, "AzureStorage");

            var actionManageFile = await ManageFileService.ManageFileAddOrModify(manageFile);
            Assert.Equal(400, ((ObjectResult)actionManageFile.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionManageFile.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionManageFile.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ManageFileService_ValidateAddOrModify_AzureStorage_Length_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ManageFile manageFile = new ManageFile()
            {
                ManageFileID = 0,
                AzureFileName = "ThisIsFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "".PadRight(101, 'a'),
                AzureCreationTimeUTC = DateTime.UtcNow,
                LoadedOnce = true,
            };

            string error = string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureStorage", "100");

            var actionManageFile = await ManageFileService.ManageFileAddOrModify(manageFile);
            Assert.Equal(400, ((ObjectResult)actionManageFile.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionManageFile.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionManageFile.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ManageFileService_ValidateAddOrModify_AlreadyExist_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ManageFile manageFile = new ManageFile()
            {
                ManageFileID = 0,
                AzureFileName = "ThisIsFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "ThisAzureStorage",
                AzureCreationTimeUTC = DateTime.UtcNow,
                LoadedOnce = true,
            };

            var actionManageFileAddOrModify = await ManageFileService.ManageFileAddOrModify(manageFile);
            Assert.Equal(200, ((ObjectResult)actionManageFileAddOrModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionManageFileAddOrModify.Result).Value);
            ManageFile manageFileNewPost = (ManageFile)((OkObjectResult)actionManageFileAddOrModify.Result).Value;
            Assert.NotNull(manageFileNewPost);
            Assert.Equal(manageFile.ManageFileID, manageFileNewPost.ManageFileID);
            Assert.Equal(manageFile.AzureFileName, manageFileNewPost.AzureFileName);
            Assert.Equal(manageFile.AzureETag, manageFileNewPost.AzureETag);
            Assert.Equal(manageFile.AzureStorage, manageFileNewPost.AzureStorage);
            Assert.Equal(manageFile.AzureCreationTimeUTC, manageFileNewPost.AzureCreationTimeUTC);

            string error = string.Format(CSSPCultureServicesRes._AlreadyExists, "ManageFile");

            manageFile.ManageFileID = 0;

            var actionManageFile = await ManageFileService.ManageFileAddOrModify(manageFile);
            Assert.Equal(400, ((ObjectResult)actionManageFile.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionManageFile.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionManageFile.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ManageFileService_ValidateAddOrModify_AlreadyExistWithDifferent_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ManageFile manageFile = new ManageFile()
            {
                ManageFileID = 0,
                AzureFileName = "ThisIsFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "ThisAzureStorage",
                AzureCreationTimeUTC = DateTime.UtcNow,
                LoadedOnce = true,
            };

            var actionManageFileAddOrModify = await ManageFileService.ManageFileAddOrModify(manageFile);
            Assert.Equal(200, ((ObjectResult)actionManageFileAddOrModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionManageFileAddOrModify.Result).Value);
            ManageFile manageFileNewPost = (ManageFile)((OkObjectResult)actionManageFileAddOrModify.Result).Value;
            Assert.NotNull(manageFileNewPost);
            Assert.Equal(manageFile.ManageFileID, manageFileNewPost.ManageFileID);
            Assert.Equal(manageFile.AzureFileName, manageFileNewPost.AzureFileName);
            Assert.Equal(manageFile.AzureETag, manageFileNewPost.AzureETag);
            Assert.Equal(manageFile.AzureStorage, manageFileNewPost.AzureStorage);
            Assert.Equal(manageFile.AzureCreationTimeUTC, manageFileNewPost.AzureCreationTimeUTC);

            string error = string.Format(CSSPCultureServicesRes._AlreadyExistsWithDifferent_, "ManageFile", "ManageFileID");

            manageFile.ManageFileID = 3;

            var actionManageFile = await ManageFileService.ManageFileAddOrModify(manageFile);
            Assert.Equal(400, ((ObjectResult)actionManageFile.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionManageFile.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionManageFile.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ManageFileService_ValidateAddOrModify_AzureCreationTimeUTC_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ManageFile manageFile = new ManageFile()
            {
                ManageFileID = 0,
                AzureFileName = "ThisIsFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "ThisAzureStorage",
                AzureCreationTimeUTC = new DateTime(1978, 1, 1),
                LoadedOnce = true,
            };

            string error = string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "AzureCreationTimeUTC", "1980");

            var actionManageFile = await ManageFileService.ManageFileAddOrModify(manageFile);
            Assert.Equal(400, ((ObjectResult)actionManageFile.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionManageFile.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionManageFile.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
