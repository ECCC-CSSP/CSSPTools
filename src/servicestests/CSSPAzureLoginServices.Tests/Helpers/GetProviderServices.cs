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
using CSSPFileServices;
using CSSPAzureLoginServices.Services;
using CSSPSQLiteServices;

namespace CSSPAzureLoginServices.Tests
{
    public partial class CSSPAzureLoginServiceTests
    {
        private async Task GetProviderServices()
        {
            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
            Assert.NotNull(CSSPScrambleService);

            CSSPLogService = Provider.GetService<ICSSPLogService>();
            Assert.NotNull(CSSPLogService);

            CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
            Assert.NotNull(CSSPLocalLoggedInService);

            CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
            Assert.NotNull(CSSPSQLiteService);

            FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);
            if (!fiCSSPDBManage.Exists)
            {
                await CSSPSQLiteService.CreateSQLiteCSSPDBManageAsync();
            }

            CSSPAzureLoginService = Provider.GetService<ICSSPAzureLoginService>();
            Assert.NotNull(CSSPAzureLoginService);

            dbManage = Provider.GetService<CSSPDBManageContext>();
            Assert.NotNull(dbManage);
        }
    }
}
