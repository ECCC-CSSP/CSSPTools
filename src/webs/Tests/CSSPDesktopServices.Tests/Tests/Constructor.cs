using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPDesktopServices.Services;
using CSSPEnums;
using CSSPSQLiteServices;
using CSSPFileServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadGzFileServices;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPLogServices;

namespace CSSPDesktopServices.Tests
{
    public partial class CSSPDesktopServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDesktopService_Constructor_Good_Test(string culture)
        {
            Assert.True(await CSSPDesktopServiceSetup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(CSSPDesktopService);
            Assert.NotNull(CSSPSQLiteService);
        }
    }
}
