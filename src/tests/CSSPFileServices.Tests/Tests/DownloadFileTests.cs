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
        public async Task DownloadFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            CSSPLogService.CSSPAppName = "FileServiceTests";
            CSSPLogService.CSSPCommandName = "Testing_DownloadFileTests";

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            FileInfo fi = new FileInfo($"{ config.CSSPFilesPath }{ParentTVItemID}\\{FileName}");
            Assert.True(fi.Exists);

            var actionRes2 = await FileService.DownloadFile(ParentTVItemID, FileName);
            Assert.NotNull(((FileStreamResult)actionRes2).FileStream);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadFile_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            CSSPLogService.CSSPAppName = "FileServiceTests";
            CSSPLogService.CSSPCommandName = "Testing_DownloadFileTests";

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            FileInfo fi = new FileInfo($"{ config.CSSPFilesPath }{ParentTVItemID}\\{FileName}");
            Assert.True(fi.Exists);

            LoggedInService.LoggedInContactInfo = null;

            var actionRes = await FileService.DownloadFile(ParentTVItemID, FileName);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
            var ValidationResultList = (List<ValidationResult>)((UnauthorizedObjectResult)actionRes).Value;
            Assert.NotEmpty(ValidationResultList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadFile_FileNotExist_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            CSSPLogService.CSSPAppName = "FileServiceTests";
            CSSPLogService.CSSPCommandName = "Testing_DownloadFileTests_FileNotExist";

            int ParentTVItemID = 1;
            string FileName = "NotExist.png";

            FileInfo fi = new FileInfo($"{ config.CSSPFilesPath }{ParentTVItemID}\\{FileName}");
            Assert.False(fi.Exists);

            var actionRes = await FileService.DownloadFile(ParentTVItemID, FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes).StatusCode);
            var ValidationResultList = (List<ValidationResult>)((BadRequestObjectResult)actionRes).Value;
            Assert.NotEmpty(ValidationResultList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
