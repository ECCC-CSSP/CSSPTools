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
using CSSPAzureLoginServices.Services;
using CSSPHelperModels;

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

            fiCSSPDBLocal = new FileInfo(Configuration["CSSPDBLocal"]);
            Assert.True(fiCSSPDBLocal.Exists);

            FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);
            if (!fiCSSPDBManage.Exists)
            {
                await CSSPSQLiteService.CreateSQLiteCSSPDBManageAsync();
            }

            fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);
            Assert.True(fiCSSPDBManage.Exists);

            dbManage = Provider.GetService<CSSPDBManageContext>();
            Assert.NotNull(dbManage);

            CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
            Assert.NotNull(CSSPLocalLoggedInService);

            Contact contact = (from c in dbManage.Contacts
                               select c).FirstOrDefault();

            if (contact == null)
            {
                CSSPAzureLoginService = Provider.GetService<ICSSPAzureLoginService>();
                Assert.NotNull(CSSPAzureLoginService);

                LoginModel loginModel = new LoginModel()
                {
                    LoginEmail = Configuration["LoginEmail"],
                    Password = Configuration["Password"],
                };

                var actionRes = await CSSPAzureLoginService.AzureLoginAsync(loginModel);
                Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
                Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
                Assert.Empty(CSSPLogService.ErrRes.ErrList);

                Contact contactDB = (from c in dbManage.Contacts
                                     select c).FirstOrDefault();
                Assert.NotNull(contactDB);

                Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
                Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);
                Assert.Equal(contactDB.ContactTVItemID, CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID);

            }

            await CSSPLocalLoggedInService.SetLocalLoggedInContactInfo();
            Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
            Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);
            Assert.True(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID > 0);

            CreateGzFileService = Provider.GetService<ICSSPCreateGzFileService>();
            Assert.NotNull(CreateGzFileService);
        }
    }
}
