using CSSPHelperModels;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPFileServices.Tests
{
    //[Collection("Sequential")]
    public partial class FileServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadOtherFile_Good_Test(string culture)
        {
            List<string> fileList = new List<string>()
            {
                "CssFamilyMaterial.css",
                "IconFamilyMaterial.css",
                "GoogleMap.js",
                "flUhRq6tzZclQEJ-Vdg-IuiaDsNc.woff2"
            };

            foreach (string fileName in fileList)
            {
                Assert.True(await CSSPFileServiceSetup(culture));

                CSSPLogService.CSSPAppName = "FileServiceTests";
                CSSPLogService.CSSPCommandName = "Testing_DownloadOtherFile";

                FileInfo fi = new FileInfo(Configuration["CSSPOtherFilesPath"] + $"{ fileName }");
                Assert.True(fi.Exists);

                Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

                var actionRes = await CSSPFileService.DownloadOtherFile(fileName);
                Assert.NotNull(((PhysicalFileResult)actionRes).FileName);

                await CSSPLogService.Save();

                Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadOtherFile_Unauthorized_Error_Test(string culture)
        {
            List<string> otherFileList = new List<string>()
            {
                "CssFamilyMaterial.css", "IconFamilyMaterial.css", "GoogleMap.js", "flUhRq6tzZclQEJ-Vdg-IuiaDsNc.woff2"
            };

            foreach (string fileName in otherFileList)
            {
                Assert.True(await CSSPFileServiceSetup(culture));

                FileInfo fi = new FileInfo(Configuration["CSSPOtherFilesPath"] + $"{ fileName }");
                Assert.True(fi.Exists);

                Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

                CSSPLocalLoggedInService.LoggedInContactInfo = null;

                var actionRes = await CSSPFileService.DownloadOtherFile(fileName);
                Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
                ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes).Value;
                Assert.NotEmpty(errRes.ErrList);
            }

            await CSSPLogService.Save();

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadOtherFile_FileDoesNotExist_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            string FileName = "NotExist.css";

            var actionRes = await CSSPFileService.DownloadOtherFile(FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes).Value;
            Assert.NotEmpty(errRes.ErrList);

            await CSSPLogService.Save();

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
