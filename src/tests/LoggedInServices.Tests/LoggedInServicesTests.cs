using CSSPModels;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace LoggedInServices.Tests
{
    public class LoggedInServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private string DBFileName { get; set; } = "DBFileName";
        #endregion Properties

        #region Constructors
        public LoggedInServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetID_SetID_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("f837a0d7-783e-498e-b821-de9c9bd981de");
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", (await LoggedInService.GetLoggedInContactInfo()).LoggedInContact.Id);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetContact_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("f837a0d7-783e-498e-b821-de9c9bd981de");
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", (await LoggedInService.GetLoggedInContactInfo()).LoggedInContact.Id);

            Contact contact = (await LoggedInService.GetLoggedInContactInfo()).LoggedInContact;
            Assert.Equal("Charles", contact.FirstName);
            Assert.Equal("G", contact.Initial);
            Assert.Equal("LeBlanc", contact.LastName);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetTVTypeUserAuthorizationList_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("f837a0d7-783e-498e-b821-de9c9bd981de");
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", (await LoggedInService.GetLoggedInContactInfo()).LoggedInContact.Id);

            List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = (await LoggedInService.GetLoggedInContactInfo()).TVTypeUserAuthorizationList;
            Assert.True(TVTypeUserAuthorizationList.Count > 1);

            await LoggedInService.SetLoggedInContactInfo("023566a4-4a25-4484-88f5-584aa8e1da38");
            Assert.Equal("023566a4-4a25-4484-88f5-584aa8e1da38", (await LoggedInService.GetLoggedInContactInfo()).LoggedInContact.Id);

            TVTypeUserAuthorizationList = (await LoggedInService.GetLoggedInContactInfo()).TVTypeUserAuthorizationList;
            Assert.True(TVTypeUserAuthorizationList.Count == 0);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetTVItemUserAuthorizationList_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("f837a0d7-783e-498e-b821-de9c9bd981de");
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", (await LoggedInService.GetLoggedInContactInfo()).LoggedInContact.Id);

            List<TVItemUserAuthorization> TVItemUserAuthorizationList = (await LoggedInService.GetLoggedInContactInfo()).TVItemUserAuthorizationList;
            Assert.True(TVItemUserAuthorizationList.Count > 0);

            await LoggedInService.SetLoggedInContactInfo("023566a4-4a25-4484-88f5-584aa8e1da38");
            Assert.Equal("023566a4-4a25-4484-88f5-584aa8e1da38", (await LoggedInService.GetLoggedInContactInfo()).LoggedInContact.Id);

            TVItemUserAuthorizationList = (await LoggedInService.GetLoggedInContactInfo()).TVItemUserAuthorizationList;
            Assert.True(TVItemUserAuthorizationList.Count == 0);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task Contact_Should_Exist_In_Memory_DB_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // first time it will get the LoggedInContactInfo from the read DB
            await LoggedInService.SetLoggedInContactInfo("f837a0d7-783e-498e-b821-de9c9bd981de");
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", (await LoggedInService.GetLoggedInContactInfo()).LoggedInContact.Id);

            // first time it will get the LoggedInContactInfo from the InMemory DB
            await LoggedInService.SetLoggedInContactInfo("f837a0d7-783e-498e-b821-de9c9bd981de");
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", (await LoggedInService.GetLoggedInContactInfo()).LoggedInContact.Id);
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceCollection.AddSingleton<ICultureService, CultureService>();
            ServiceCollection.AddSingleton<ILoggedInService, LoggedInService>();

            string CSSPDBConnString = Configuration.GetValue<string>("CSSPDBConnectionString");
            Assert.NotNull(CSSPDBConnString);

            ServiceCollection.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            ServiceCollection.AddDbContext<InMemoryDBContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            CultureService = ServiceProvider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            LoggedInService = ServiceProvider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);


            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
