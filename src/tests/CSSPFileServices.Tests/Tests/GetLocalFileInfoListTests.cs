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
        public async Task FileService_GetLocalFileInfoList_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int ParentTVItemID = 1;

            var actionRes = await FileService.GetLocalFileInfoList(ParentTVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            List<LocalFileInfo> localFileInfoList = ((List<LocalFileInfo>)((OkObjectResult)actionRes.Result).Value);
            Assert.NotNull(localFileInfoList);
            Assert.True(localFileInfoList.Count > 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_GetLocalFileInfoList_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int ParentTVItemID = 1;

            LoggedInService.LoggedInContactInfo = null;

            var actionRes = await FileService.GetLocalFileInfoList(ParentTVItemID);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
