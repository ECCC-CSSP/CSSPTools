using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;
using CSSPWebModels;
using System.ComponentModel.DataAnnotations;
using CSSPLogServices.Models;
using CSSPHelperModels;

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
            List<string> otherFileList = new List<string>()
            {
                "CssFamilyMaterial.css", "IconFamilyMaterial.css", "GoogleMap.js", "flUhRq6tzZclQEJ-Vdg-IuiaDsNc.woff2"
            };

            foreach (string fileName in otherFileList)
            {
                Assert.True(await CSSPFileServiceSetup(culture));

                Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

                var actionRes = await CSSPFileService.DownloadOtherFile(fileName);
                Assert.NotNull(((FileStreamResult)actionRes).FileStream);
            }

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
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

                Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

                LoggedInService.LoggedInContactInfo = null;

                var actionRes = await CSSPFileService.DownloadOtherFile(fileName);
                Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
                ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes).Value;
                Assert.NotEmpty(errRes.ErrList);
            }

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

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
