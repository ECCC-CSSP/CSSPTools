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
    public partial class DocTemplateControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IDocTemplateService docTemplateService { get; set; }
        private IDocTemplateController docTemplateController { get; set; }
        #endregion Properties

        #region Constructors
        public DocTemplateControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task DocTemplateController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(docTemplateService);
            Assert.NotNull(docTemplateController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task DocTemplateController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionDocTemplateList = await docTemplateController.Get();
               Assert.Equal(200, ((ObjectResult)actionDocTemplateList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionDocTemplateList.Result).Value);
               List<DocTemplate> docTemplateList = (List<DocTemplate>)(((OkObjectResult)actionDocTemplateList.Result).Value);

               int count = ((List<DocTemplate>)((OkObjectResult)actionDocTemplateList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(DocTemplateID)
               var actionDocTemplate = await docTemplateController.Get(docTemplateList[0].DocTemplateID);
               Assert.Equal(200, ((ObjectResult)actionDocTemplate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionDocTemplate.Result).Value);
               DocTemplate docTemplate = (DocTemplate)(((OkObjectResult)actionDocTemplate.Result).Value);
               Assert.NotNull(docTemplate);
               Assert.Equal(docTemplateList[0].DocTemplateID, docTemplate.DocTemplateID);

               // testing Post(DocTemplate docTemplate)
               docTemplate.DocTemplateID = 0;
               var actionDocTemplateNew = await docTemplateController.Post(docTemplate);
               Assert.Equal(200, ((ObjectResult)actionDocTemplateNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionDocTemplateNew.Result).Value);
               DocTemplate docTemplateNew = (DocTemplate)(((OkObjectResult)actionDocTemplateNew.Result).Value);
               Assert.NotNull(docTemplateNew);

               // testing Put(DocTemplate docTemplate)
               var actionDocTemplateUpdate = await docTemplateController.Put(docTemplateNew);
               Assert.Equal(200, ((ObjectResult)actionDocTemplateUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionDocTemplateUpdate.Result).Value);
               DocTemplate docTemplateUpdate = (DocTemplate)(((OkObjectResult)actionDocTemplateUpdate.Result).Value);
               Assert.NotNull(docTemplateUpdate);

               // testing Delete(DocTemplate docTemplate)
               var actionDocTemplateDelete = await docTemplateController.Delete(docTemplateUpdate);
               Assert.Equal(200, ((ObjectResult)actionDocTemplateDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionDocTemplateDelete.Result).Value);
               DocTemplate docTemplateDelete = (DocTemplate)(((OkObjectResult)actionDocTemplateDelete.Result).Value);
               Assert.NotNull(docTemplateDelete);
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
            Services.AddSingleton<IDocTemplateService, DocTemplateService>();
            Services.AddSingleton<IDocTemplateController, DocTemplateController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            docTemplateService = Provider.GetService<IDocTemplateService>();
            Assert.NotNull(docTemplateService);
        
            await docTemplateService.SetCulture(culture);
        
            docTemplateController = Provider.GetService<IDocTemplateController>();
            Assert.NotNull(docTemplateController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
