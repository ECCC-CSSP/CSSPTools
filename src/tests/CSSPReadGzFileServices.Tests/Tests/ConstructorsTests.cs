using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using CSSPWebModels;

namespace ReadGzFileServices.Tests
{
    public partial class ReadGzFileServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Constructor_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(LoggedInService);
            Assert.NotNull(LoggedInService.LoggedInContactInfo);
            Assert.NotNull(CSSPLogService);
            Assert.NotNull(ManageFileService);
            Assert.NotNull(ReadGzFileService);
            Assert.NotNull(CSSPFileService);
            Assert.NotNull(configReadGzfile);
            Assert.NotNull(configLogService);
            Assert.NotNull(configFileService);
        }
    }
}
