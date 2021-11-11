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
using CSSPHelperModels;

namespace CSSPDesktopServices.Tests
{
    public partial class CSSPDesktopServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDesktopService_Login_Good_Test(string culture)
        {
            Assert.True(await CSSPDesktopServiceSetup(culture));

            LoginModel loginModel = new LoginModel()
            {
                LoginEmail = Configuration["LoginEmail"],
                Password = Configuration["Password"],
            };

            bool retBool = await CSSPDesktopService.Login(loginModel);
            Assert.True(retBool);
        }
    }
}
