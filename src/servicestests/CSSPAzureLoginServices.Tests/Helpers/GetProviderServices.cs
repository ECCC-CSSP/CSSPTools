using CSSPAzureLoginServices.Services;
using CSSPCultureServices.Services;
using CSSPLocalLoggedInServices;
using CSSPLogServices;
using CSSPScrambleServices;
using CSSPSQLiteServices;
using ManageServices;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Threading.Tasks;
using Xunit;

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
