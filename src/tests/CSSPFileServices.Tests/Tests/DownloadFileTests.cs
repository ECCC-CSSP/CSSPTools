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

namespace FileServices.Tests
{
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
        public async Task FileService_DownloadFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            FileInfo fi = new FileInfo($"{ CSSPFilesPath }{ParentTVItemID}\\{FileName}");

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

            var actionRes = await FileService.LocalizeAzureFile(ParentTVItemID, FileName);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            var actionRes2 = await FileService.DownloadFile(ParentTVItemID, FileName);
            Assert.NotNull(((FileStreamResult)actionRes2).FileStream);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadFile_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            FileInfo fi = new FileInfo($"{ CSSPFilesPath }{ParentTVItemID}\\{FileName}");

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

            var actionRes = await FileService.LocalizeAzureFile(ParentTVItemID, FileName);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            LoggedInService.LoggedInContactInfo = null;

            var actionRes2 = await FileService.DownloadFile(ParentTVItemID, FileName);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes2).StatusCode);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
