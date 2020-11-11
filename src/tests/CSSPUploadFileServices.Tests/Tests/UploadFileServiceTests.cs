using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace UploadFileServices.Tests
{
    [Collection("Sequential")]
    public partial class UploadFileServiceTests
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
        public async Task UploadFileService_UploadFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            // Download file
            var actionRes2 = await UploadFileService.UploadFile(ParentTVItemID, FileName);
            Assert.NotNull(((FileStreamResult)actionRes2).FileStream);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
