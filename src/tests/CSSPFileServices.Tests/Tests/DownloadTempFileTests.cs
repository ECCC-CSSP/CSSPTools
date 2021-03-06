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
        public async Task FileService_DownloadTempFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FileInfo fi = new FileInfo($@"{CSSPTempFilesPath}\\ThisFileShoulBeUnique743Testing.txt");

            if (fi.Exists)
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            File.WriteAllText(fi.FullName, "bonjour");
            
            var actionRes = await FileService.DownloadTempFile(fi.Name);
            Assert.NotNull(((FileStreamResult)actionRes).FileStream);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadTempFile_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FileInfo fi = new FileInfo($@"{CSSPTempFilesPath}\\ThisFileShoulBeUnique743Testing.txt");

            File.WriteAllText(fi.FullName, "bonjour");

            LoggedInService.LoggedInContactInfo = null;

            var actionRes = await FileService.DownloadTempFile(fi.Name);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
