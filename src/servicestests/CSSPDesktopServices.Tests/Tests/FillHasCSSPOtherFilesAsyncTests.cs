using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPDesktopServices.Services;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using CSSPHelperModels;

namespace CSSPDesktopServices.Tests
{
    public partial class CSSPDesktopServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FillHasCSSPOtherFilesAsync_Good_Test(string culture)
        {
            Assert.True(await CSSPDesktopServiceSetup(culture));

            DeleteCSSPDesktopPath();
            CreateCSSPOtherFilesPath();

            Assert.True(await CSSPDesktopService.FillHasCSSPOtherFilesAsync());
            Assert.False(CSSPDesktopService.HasCSSPOtherFiles);

            DirectoryCopy(Configuration["LocalCSSPOtherFilesPath"], Configuration["CSSPOtherFilesPath"], true);

            Assert.True(await CSSPDesktopService.FillHasCSSPOtherFilesAsync());
            Assert.True(CSSPDesktopService.HasCSSPOtherFiles);
        }
    }
}
