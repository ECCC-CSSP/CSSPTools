using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DownloadFileServices.Tests
{
    [Collection("Sequential")]
    public partial class DownloadFileServiceTests
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
        public async Task DownloadFileService_LocalizeAzureFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            // Download file
            var actionRes2 = await DownloadFileService.LocalizeAzureFile(ParentTVItemID, FileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadFileService_DownloadFile_Good_Test(string culture)
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

            // Download file
            var actionRes2 = await DownloadFileService.DownloadFile(ParentTVItemID, FileName);
            Assert.NotNull(((FileStreamResult)actionRes2).FileStream);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
