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
using CSSPSQLiteServices;
using CSSPDesktopInstallPostBuildServices.Services;

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

            CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
            Assert.NotNull(CSSPSQLiteService);

            FileInfo fiCSSPDBLocal = new FileInfo(Configuration["CSSPDBLocal"]);
            if (!fiCSSPDBLocal.Exists)
            {
                await CSSPSQLiteService.CreateSQLiteCSSPDBLocalAsync();
            }

            FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);
            if (!fiCSSPDBManage.Exists)
            {
                await CSSPSQLiteService.CreateSQLiteCSSPDBManageAsync();
            }

            dbManage = Provider.GetService<CSSPDBManageContext>();
            Assert.NotNull(dbManage);

            Contact contact = (from c in dbManage.Contacts
                               select c).FirstOrDefault();

            if (contact == null)
            {
                CSSPDesktopInstallPostBuildService = Provider.GetService<ICSSPDesktopInstallPostBuildService>();
                Assert.NotNull(CSSPDesktopInstallPostBuildService);

                await CSSPDesktopInstallPostBuildService.LoginAsync();
            }

            CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
            Assert.NotNull(CSSPLocalLoggedInService);

            await CSSPLocalLoggedInService.SetLoggedInContactInfo();
            Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
            Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);
            Assert.True(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID > 0);

            CreateGzFileService = Provider.GetService<ICSSPCreateGzFileService>();
            Assert.NotNull(CreateGzFileService);
        }
    }
}
