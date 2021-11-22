﻿using System;
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
        public async Task CreateAllRequiredDirectories_Good_Test(string culture)
        {
            Assert.True(await CSSPDesktopServiceSetup(culture));

            bool retBool = await CSSPDesktopService.CreateAllRequiredDirectoriesAsync();
            Assert.True(retBool);

            Assert.Empty(CSSPLogService.ErrRes.ErrList);

            foreach (string DirName in await CSSPDesktopService.GetDirectoryToCreateListAsync())
            {
                DirectoryInfo di = new DirectoryInfo(DirName);
                Assert.True(di.Exists);
            }
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}