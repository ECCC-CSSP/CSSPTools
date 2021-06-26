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

namespace FileServices.Tests
{
    //[Collection("Sequential")]
    public partial class FileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see under GzFileServices Setup.cs
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadOtherFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<string> otherFileList = new List<string>()
            {
                "CssFamilyMaterial.css", "IconFamilyMaterial.css", "GoogleMap.js", "flUhRq6tzZclQEJ-Vdg-IuiaDsNc.woff2"
            };

            foreach(string fileName in otherFileList)
            {
                var actionRes = await FileService.DownloadOtherFile(fileName);
                Assert.NotNull(((FileStreamResult)actionRes).FileStream);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadOtherFile_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<string> otherFileList = new List<string>()
            {
                "CssFamilyMaterial.css", "IconFamilyMaterial.css", "GoogleMap.js", "flUhRq6tzZclQEJ-Vdg-IuiaDsNc.woff2"
            };

            foreach (string fileName in otherFileList)
            {
                LoggedInService.LoggedInContactInfo = null;

                var actionRes = await FileService.DownloadOtherFile(fileName);
                Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
            }
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
