﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CSSPCultureServices.Services;
using CSSPDesktopInstallPostBuildServices.Services;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using CSSPHelperModels;

namespace CSSPDesktopInstallPostBuildServices.Tests
{
    public partial class CSSPDesktopInstallPostBuildServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPClientCompressAndSendToAzure_Good_Test(string culture)
        {
            Assert.True(await CSSPDesktopInstallPostBuildServiceSetup(culture));

            bool retBool = await CSSPDesktopInstallPostBuildService.LoginAsync();
            Assert.True(retBool);

            retBool = await CSSPDesktopInstallPostBuildService.CSSPClientCompressAndSendToAzureAsync();
            Assert.True(retBool);
        }
    }
}
