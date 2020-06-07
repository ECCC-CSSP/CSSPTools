/* Auto generated from C:\CSSPTools\src\codegen\WebAPIClassNameControllerTestGenerated\bin\Debug\netcoreapp3.1\WebAPIClassNameControllerTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using UserServices.Models;
using Xunit;

namespace CSSPWebAPIs.Tests.Controllers
{
    public partial class MWQMLookupMPNControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMWQMLookupMPNService mwqmLookupMPNService { get; set; }
        private IMWQMLookupMPNController mwqmLookupMPNController { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMLookupMPNController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mwqmLookupMPNService);
            Assert.NotNull(mwqmLookupMPNController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMLookupMPNController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionMWQMLookupMPNList = await mwqmLookupMPNController.Get();
                Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNList.Result).Value);
                List<MWQMLookupMPN> mwqmLookupMPNList = (List<MWQMLookupMPN>)((OkObjectResult)actionMWQMLookupMPNList.Result).Value;

                int count = ((List<MWQMLookupMPN>)((OkObjectResult)actionMWQMLookupMPNList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(MWQMLookupMPNID)
                var actionMWQMLookupMPN = await mwqmLookupMPNController.Get(mwqmLookupMPNList[0].MWQMLookupMPNID);
                Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPN.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMLookupMPN.Result).Value);
                MWQMLookupMPN mwqmLookupMPN = (MWQMLookupMPN)((OkObjectResult)actionMWQMLookupMPN.Result).Value;
                Assert.NotNull(mwqmLookupMPN);
                Assert.Equal(mwqmLookupMPNList[0].MWQMLookupMPNID, mwqmLookupMPN.MWQMLookupMPNID);

                // testing Delete(int mwqmLookupMPN.MWQMLookupMPNID )
                var actionMWQMLookupMPNDelete = await mwqmLookupMPNController.Delete(mwqmLookupMPN.MWQMLookupMPNID);
                Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionMWQMLookupMPNDelete.Result).Value;
                Assert.True(retBool2);

                // testing Post(MWQMLookupMPN mwqmLookupMPN)
                mwqmLookupMPN.MWQMLookupMPNID = 0;
                var actionMWQMLookupMPNNew = await mwqmLookupMPNController.Post(mwqmLookupMPN);
                Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNNew.Result).Value);
                MWQMLookupMPN mwqmLookupMPNNew = (MWQMLookupMPN)((OkObjectResult)actionMWQMLookupMPNNew.Result).Value;
                Assert.NotNull(mwqmLookupMPNNew);

                // testing Put(MWQMLookupMPN mwqmLookupMPN)
                var actionMWQMLookupMPNUpdate = await mwqmLookupMPNController.Put(mwqmLookupMPNNew);
                Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNUpdate.Result).Value);
                MWQMLookupMPN mwqmLookupMPNUpdate = (MWQMLookupMPN)((OkObjectResult)actionMWQMLookupMPNUpdate.Result).Value;
                Assert.NotNull(mwqmLookupMPNUpdate);

            }
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();

            Services = new ServiceCollection();

            IConfigurationSection connectionStringsSection = Config.GetSection("ConnectionStrings");
            Services.Configure<ConnectionStringsModel>(connectionStringsSection);

            ConnectionStringsModel connectionStrings = connectionStringsSection.Get<ConnectionStringsModel>();

            Services.AddSingleton<IConfiguration>(Config);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(connectionStrings.TestDB);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionStrings.TestDB));

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IMWQMLookupMPNService, MWQMLookupMPNService>();
            Services.AddSingleton<IMWQMLookupMPNController, MWQMLookupMPNController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            mwqmLookupMPNService = Provider.GetService<IMWQMLookupMPNService>();
            Assert.NotNull(mwqmLookupMPNService);

            await mwqmLookupMPNService.SetCulture(culture);

            mwqmLookupMPNController = Provider.GetService<IMWQMLookupMPNController>();
            Assert.NotNull(mwqmLookupMPNController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
