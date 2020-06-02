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
    public partial class TVFileControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ITVFileService tvFileService { get; set; }
        private ITVFileController tvFileController { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVFileController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(tvFileService);
            Assert.NotNull(tvFileController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVFileController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionTVFileList = await tvFileController.Get();
               Assert.Equal(200, ((ObjectResult)actionTVFileList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVFileList.Result).Value);
               List<TVFile> tvFileList = (List<TVFile>)(((OkObjectResult)actionTVFileList.Result).Value);

               int count = ((List<TVFile>)((OkObjectResult)actionTVFileList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(TVFileID)
               var actionTVFile = await tvFileController.Get(tvFileList[0].TVFileID);
               Assert.Equal(200, ((ObjectResult)actionTVFile.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVFile.Result).Value);
               TVFile tvFile = (TVFile)(((OkObjectResult)actionTVFile.Result).Value);
               Assert.NotNull(tvFile);
               Assert.Equal(tvFileList[0].TVFileID, tvFile.TVFileID);

               // testing Post(TVFile tvFile)
               tvFile.TVFileID = 0;
               var actionTVFileNew = await tvFileController.Post(tvFile);
               Assert.Equal(200, ((ObjectResult)actionTVFileNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVFileNew.Result).Value);
               TVFile tvFileNew = (TVFile)(((OkObjectResult)actionTVFileNew.Result).Value);
               Assert.NotNull(tvFileNew);

               // testing Put(TVFile tvFile)
               var actionTVFileUpdate = await tvFileController.Put(tvFileNew);
               Assert.Equal(200, ((ObjectResult)actionTVFileUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVFileUpdate.Result).Value);
               TVFile tvFileUpdate = (TVFile)(((OkObjectResult)actionTVFileUpdate.Result).Value);
               Assert.NotNull(tvFileUpdate);

               // testing Delete(TVFile tvFile)
               var actionTVFileDelete = await tvFileController.Delete(tvFileUpdate);
               Assert.Equal(200, ((ObjectResult)actionTVFileDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVFileDelete.Result).Value);
               TVFile tvFileDelete = (TVFile)(((OkObjectResult)actionTVFileDelete.Result).Value);
               Assert.NotNull(tvFileDelete);
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
            Services.AddSingleton<ITVFileService, TVFileService>();
            Services.AddSingleton<ITVFileController, TVFileController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            tvFileService = Provider.GetService<ITVFileService>();
            Assert.NotNull(tvFileService);
        
            await tvFileService.SetCulture(culture);
        
            tvFileController = Provider.GetService<ITVFileController>();
            Assert.NotNull(tvFileController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
