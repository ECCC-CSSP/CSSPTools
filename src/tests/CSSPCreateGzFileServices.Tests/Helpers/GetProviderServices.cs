using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;
using System.Collections.Generic;
using ManageServices;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CSSPCultureServices.Services;
using CSSPLogServices;
using CSSPScrambleServices;
using CSSPLocalLoggedInServices;

namespace CSSPCreateGzFileServices.Tests
{
    public partial class CSSPCreateGzFileServiceTests
    {
        private async Task GetProviderServices(string culture)
        {
            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
            Assert.NotNull(CSSPScrambleService);

            CSSPLogService = Provider.GetService<ICSSPLogService>();
            Assert.NotNull(CSSPLogService);

            CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
            Assert.NotNull(CSSPLocalLoggedInService);

            await CSSPLocalLoggedInService.SetLoggedInContactInfo();
            Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);

            CreateGzFileService = Provider.GetService<ICSSPCreateGzFileService>();
            Assert.NotNull(CreateGzFileService);

            dbManage = Provider.GetService<CSSPDBManageContext>();
            Assert.NotNull(dbManage);
        }
    }
}
