using CSSPModels;
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
        private ILoggedInService loggedInService { get; set; }
        private IConfiguration configuration { get; set; }
        private IServiceCollection serviceCollection { get; set; }
        private IServiceProvider serviceProvider { get; set; }
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
            await Setup(new CultureInfo(culture));

            await loggedInService.SetID("f837a0d7-783e-498e-b821-de9c9bd981de");
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", await loggedInService.GetID());
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetContact_Good_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            await loggedInService.SetID("f837a0d7-783e-498e-b821-de9c9bd981de");
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", await loggedInService.GetID());

            Contact contact = await loggedInService.GetContact();
            Assert.Equal("Charles", contact.FirstName);
            Assert.Equal("G", contact.Initial);
            Assert.Equal("LeBlanc", contact.LastName);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetTVItemUserAuthorizationList_Good_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            await loggedInService.SetID("f837a0d7-783e-498e-b821-de9c9bd981de");
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", await loggedInService.GetID());

            List<TVItemUserAuthorization> TVTypeUserAuthorizationList = await loggedInService.GetTVItemUserAuthorizationList();
            Assert.True(TVTypeUserAuthorizationList.Count == 0);

            await loggedInService.SetID("023566a4-4a25-4484-88f5-584aa8e1da38");
            Assert.Equal("023566a4-4a25-4484-88f5-584aa8e1da38", await loggedInService.GetID());

            TVTypeUserAuthorizationList = await loggedInService.GetTVItemUserAuthorizationList();
            Assert.True(TVTypeUserAuthorizationList.Count == 1);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetTVTypeUserAuthorizationList_Good_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            await loggedInService.SetID("f837a0d7-783e-498e-b821-de9c9bd981de");
            Assert.Equal("f837a0d7-783e-498e-b821-de9c9bd981de", await loggedInService.GetID());

            List<TVTypeUserAuthorization> TVItemUserAuthorizationList = await loggedInService.GetTVTypeUserAuthorizationList();
            Assert.True(TVItemUserAuthorizationList.Count == 1);

            await loggedInService.SetID("023566a4-4a25-4484-88f5-584aa8e1da38");
            Assert.Equal("023566a4-4a25-4484-88f5-584aa8e1da38", await loggedInService.GetID());

            TVItemUserAuthorizationList = await loggedInService.GetTVTypeUserAuthorizationList();
            Assert.True(TVItemUserAuthorizationList.Count == 1);
        }
        #endregion Functions public

        #region Functions private
        private async Task Setup(CultureInfo culture)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IConfiguration>(configuration);

            string CSSPDBConnString = configuration.GetValue<string>("CSSPDBConnectionString");
            Assert.NotNull(CSSPDBConnString);
                
            serviceCollection.AddDbContext<CSSPDBContext>(options =>
                {
                    options.UseSqlServer(CSSPDBConnString);
                });

            serviceCollection.AddSingleton<ILoggedInService, LoggedInService>();

            serviceProvider = serviceCollection.BuildServiceProvider();
            Assert.NotNull(serviceProvider);

            loggedInService = serviceProvider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        }
        #endregion Functions private
    }
}
