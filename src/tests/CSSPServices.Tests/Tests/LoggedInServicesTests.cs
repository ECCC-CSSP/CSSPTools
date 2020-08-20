using CSSPModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CSSPServices.Tests
{
    public class LoggedInServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
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
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", LoggedInService.LoggedInContactInfo.LoggedInContact.Id);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetContact_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("f837a0d7-783e-498e-b821-de9c9bd981de");
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", LoggedInService.LoggedInContactInfo.LoggedInContact.Id);

            Contact contact = LoggedInService.LoggedInContactInfo.LoggedInContact;
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
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", LoggedInService.LoggedInContactInfo.LoggedInContact.Id);

            List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = LoggedInService.LoggedInContactInfo.TVTypeUserAuthorizationList;
            Assert.True(TVTypeUserAuthorizationList.Count > 1);

            await LoggedInService.SetLoggedInContactInfo("023566a4-4a25-4484-88f5-584aa8e1da38");
            Assert.Equal("023566a4-4a25-4484-88f5-584aa8e1da38", LoggedInService.LoggedInContactInfo.LoggedInContact.Id);

            TVTypeUserAuthorizationList = LoggedInService.LoggedInContactInfo.TVTypeUserAuthorizationList;
            Assert.True(TVTypeUserAuthorizationList.Count == 0);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetTVItemUserAuthorizationList_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("f837a0d7-783e-498e-b821-de9c9bd981de");
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", LoggedInService.LoggedInContactInfo.LoggedInContact.Id);

            List<TVItemUserAuthorization> TVItemUserAuthorizationList = LoggedInService.LoggedInContactInfo.TVItemUserAuthorizationList;
            Assert.True(TVItemUserAuthorizationList.Count > 0);

            await LoggedInService.SetLoggedInContactInfo("023566a4-4a25-4484-88f5-584aa8e1da38");
            Assert.Equal("023566a4-4a25-4484-88f5-584aa8e1da38", LoggedInService.LoggedInContactInfo.LoggedInContact.Id);

            TVItemUserAuthorizationList = LoggedInService.LoggedInContactInfo.TVItemUserAuthorizationList;
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
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", LoggedInService.LoggedInContactInfo.LoggedInContact.Id);

            // first time it will get the LoggedInContactInfo from the InMemory DB
            await LoggedInService.SetLoggedInContactInfo("f837a0d7-783e-498e-b821-de9c9bd981de");
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", LoggedInService.LoggedInContactInfo.LoggedInContact.Id);
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
            ServiceCollection.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            ServiceCollection.AddSingleton<ILoggedInService, LoggedInService>();

            string CSSPDBConnString = Configuration.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            ServiceCollection.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            ServiceCollection.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            CSSPCultureService = ServiceProvider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            LoggedInService = ServiceProvider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);


            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
