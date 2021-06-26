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
        [Theory(Skip = "Will need to figure out a way to write the test function")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_CreateTempPNG_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.True(true);
        }

        [Theory(Skip = "Will need to figure out a way to write the test function")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_CreateTempPNG_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            Assert.True(true);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
