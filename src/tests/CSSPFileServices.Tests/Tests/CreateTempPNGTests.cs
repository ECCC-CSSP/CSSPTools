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

namespace CSSPFileServices.Tests
{
    //[Collection("Sequential")]
    public partial class FileServiceTests
    {
        [Theory(Skip = "Will need to figure out a way to write the test function")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateTempPNG_Good_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            Assert.True(true);
        }

        [Theory(Skip = "Will need to figure out a way to write the test function")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateTempPNG_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            LoggedInService.LoggedInContactInfo = null;

            Assert.True(true);
        }
    }
}
