using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPAzureLoginServices.Services;
using CSSPEnums;
using CSSPSQLiteServices;
using CSSPFileServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CSSPReadGzFileServices;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPLogServices;

namespace CSSPAzureLoginServices.Tests
{
    public partial class CSSPAzureLoginServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPAzureLoginService_Constructor_Good_Test(string culture)
        {
            Assert.True(await CSSPAzureLoginServiceSetup(culture));
        }
    }
}
