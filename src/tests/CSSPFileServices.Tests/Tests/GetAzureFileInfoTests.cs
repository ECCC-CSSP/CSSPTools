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
        public async Task FileService_GetAzureFileInfo_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            var actionRes = await FileService.GetAzureFileInfo(ParentTVItemID, FileName);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            LocalFileInfo localFileInfoRet = ((LocalFileInfo)((OkObjectResult)actionRes.Result).Value);
            Assert.NotNull(localFileInfoRet);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_GetAzureFileInfo_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            LoggedInService.LoggedInContactInfo = null;

            var actionRes = await FileService.GetAzureFileInfo(ParentTVItemID, FileName);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
