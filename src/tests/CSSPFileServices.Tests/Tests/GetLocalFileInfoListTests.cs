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
        public async Task GetLocalFileInfoList_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int ParentTVItemID = 1;

            var actionRes = await FileService.GetLocalFileInfoList(ParentTVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            List<LocalFileInfo> localFileInfoList = ((List<LocalFileInfo>)((OkObjectResult)actionRes.Result).Value);
            Assert.NotNull(localFileInfoList);
            Assert.True(localFileInfoList.Count > 0);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetLocalFileInfoList_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int ParentTVItemID = 1;

            LoggedInService.LoggedInContactInfo = null;

            var actionRes = await FileService.GetLocalFileInfoList(ParentTVItemID);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            var ValidationResultList = (List<ValidationResult>)((UnauthorizedObjectResult)actionRes.Result).Value;
            Assert.NotNull(ValidationResultList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetLocalFileInfoList_ParentTVItemIDDoesNotExist_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int ParentTVItemID = 111111111;

            var actionRes = await FileService.GetLocalFileInfoList(ParentTVItemID);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
            var ValidationResultList = (List<ValidationResult>)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotNull(ValidationResultList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
