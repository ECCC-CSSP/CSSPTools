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

namespace FileServices.Tests
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
                Assert.True(await Setup(culture));

                Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

                var actionRes = await FileService.DownloadOtherFile(fileName);
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
                Assert.True(await Setup(culture));

                Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

                LoggedInService.LoggedInContactInfo = null;

                var actionRes = await FileService.DownloadOtherFile(fileName);
                Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
                var ValidationResultList = (List<ValidationResult>)((UnauthorizedObjectResult)actionRes).Value;
                Assert.NotNull(ValidationResultList);
            }

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadOtherFile_FileDoesNotExist_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            string FileName = "NotExist.css";

            var actionRes = await FileService.DownloadOtherFile(FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes).StatusCode);
            var ValidationResultList = (List<ValidationResult>)((BadRequestObjectResult)actionRes).Value;
            Assert.NotNull(ValidationResultList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
