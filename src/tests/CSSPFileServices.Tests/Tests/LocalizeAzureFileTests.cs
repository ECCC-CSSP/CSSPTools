using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using CSSPWebModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FileServices.Tests
{
    public partial class FileServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalizeAzureFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            var actionRes = await FileService.LocalizeAzureFile(ParentTVItemID, FileName);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalizeAzureFile_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            LoggedInService.LoggedInContactInfo = null;

            var actionRes = await FileService.LocalizeAzureFile(ParentTVItemID, FileName);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            var ValidationResultList = (List<ValidationResult>)((UnauthorizedObjectResult)actionRes.Result).Value;
            Assert.NotNull(ValidationResultList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalizeAzureFile_AzureStore_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            config.AzureStore = "notexist" + config.AzureStore;

            await FileService.FillConfigModel(config);

            var actionRes = await FileService.LocalizeAzureFile(ParentTVItemID, FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
            var ValidationResultList = (List<ValidationResult>)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotNull(ValidationResultList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalizeAzureFile_AzureStoreCSSPFilesPath_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            config.AzureStoreCSSPFilesPath = "notexist" + config.AzureStoreCSSPFilesPath;

            await FileService.FillConfigModel(config);

            var actionRes = await FileService.LocalizeAzureFile(ParentTVItemID, FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
            var ValidationResultList = (List<ValidationResult>)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotNull(ValidationResultList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalizeAzureFile_ParentTVItemIDDoesNotExist_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int ParentTVItemID = 111111111;
            string FileName = "BarTopBottom.png";

            var actionRes = await FileService.LocalizeAzureFile(ParentTVItemID, FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
            var ValidationResultList = (List<ValidationResult>)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotNull(ValidationResultList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalizeAzureFile_FileNameDoesNotExist_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int ParentTVItemID = 1;
            string FileName = "NotExist.png";

            var actionRes = await FileService.LocalizeAzureFile(ParentTVItemID, FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
            var ValidationResultList = (List<ValidationResult>)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotNull(ValidationResultList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
