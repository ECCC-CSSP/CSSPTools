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

namespace CSSPDesktopServices.Tests
{
    public partial class CSSPDesktopServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetCSSPOtherFileListAsync_Good_Test(string culture)
        {
            Assert.True(await CSSPDesktopServiceSetup(culture));

            List<string> CSSPOtherFileList = await CSSPDesktopService.GetCSSPOtherFileListAsync();
            Assert.NotNull(CSSPOtherFileList);
            Assert.NotEmpty(CSSPOtherFileList);
            Assert.Equal(6, CSSPOtherFileList.Count);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetDirectoryToCreateListAsync_Good_Test(string culture)
        {
            Assert.True(await CSSPDesktopServiceSetup(culture));

            List<string> CSSPDirectoryList = await CSSPDesktopService.GetDirectoryToCreateListAsync();
            Assert.NotNull(CSSPDirectoryList);
            Assert.NotEmpty(CSSPDirectoryList);
            Assert.Equal(8, CSSPDirectoryList.Count);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetJsonFileNameListAsync_Good_Test(string culture)
        {
            Assert.True(await CSSPDesktopServiceSetup(culture));

            List<string> CSSPJsonFileNameList = await CSSPDesktopService.GetJsonFileNameListAsync();
            Assert.NotNull(CSSPJsonFileNameList);
            Assert.NotEmpty(CSSPJsonFileNameList);
            Assert.Equal(18, CSSPJsonFileNameList.Count);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetZipFileNameListAsync_Good_Test(string culture)
        {
            Assert.True(await CSSPDesktopServiceSetup(culture));

            List<string> CSSPZipFileNameList = await CSSPDesktopService.GetZipFileNameListAsync();
            Assert.NotNull(CSSPZipFileNameList);
            Assert.NotEmpty(CSSPZipFileNameList);
            Assert.Equal(3, CSSPZipFileNameList.Count);
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
