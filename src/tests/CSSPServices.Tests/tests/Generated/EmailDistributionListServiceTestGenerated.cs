/* Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceTestGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
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
using Xunit;

namespace CSSPServices.Tests
{
    public partial class EmailDistributionListServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IEmailDistributionListService emailDistributionListService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EmailDistributionList_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            EmailDistributionList emailDistributionList = GetFilledRandomEmailDistributionList(""); 

            // List<EmailDistributionList>
            var actionEmailDistributionListList = await emailDistributionListService.GetEmailDistributionListList();
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListList.Result).Value);
            List<EmailDistributionList> emailDistributionListList = (List<EmailDistributionList>)(((OkObjectResult)actionEmailDistributionListList.Result).Value);

            int count = ((List<EmailDistributionList>)((OkObjectResult)actionEmailDistributionListList.Result).Value).Count();
            Assert.True(count > 0);

            // Add EmailDistributionList
            var actionEmailDistributionListAdded = await emailDistributionListService.Add(emailDistributionList);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListAdded.Result).Value);
            EmailDistributionList emailDistributionListAdded = (EmailDistributionList)(((OkObjectResult)actionEmailDistributionListAdded.Result).Value);
            Assert.NotNull(emailDistributionListAdded);

            // Update EmailDistributionList
            var actionEmailDistributionListUpdated = await emailDistributionListService.Update(emailDistributionList);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListUpdated.Result).Value);
            EmailDistributionList emailDistributionListUpdated = (EmailDistributionList)(((OkObjectResult)actionEmailDistributionListUpdated.Result).Value);
            Assert.NotNull(emailDistributionListUpdated);

            // Delete EmailDistributionList
            var actionEmailDistributionListDeleted = await emailDistributionListService.Delete(emailDistributionList);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListDeleted.Result).Value);
            EmailDistributionList emailDistributionListDeleted = (EmailDistributionList)(((OkObjectResult)actionEmailDistributionListDeleted.Result).Value);
            Assert.NotNull(emailDistributionListDeleted);
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();
        
            Services = new ServiceCollection();
        
            Services.AddSingleton<IConfiguration>(Config);
        
            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);
        
            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });
        
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IEmailDistributionListService, EmailDistributionListService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            emailDistributionListService = Provider.GetService<IEmailDistributionListService>();
            Assert.NotNull(emailDistributionListService);
        
            await emailDistributionListService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private EmailDistributionList GetFilledRandomEmailDistributionList(string OmitPropName)
        {
            EmailDistributionList emailDistributionList = new EmailDistributionList();

            if (OmitPropName != "ParentTVItemID") emailDistributionList.ParentTVItemID = 5;
            if (OmitPropName != "Ordinal") emailDistributionList.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionList.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionList.LastUpdateContactTVItemID = 2;

            return emailDistributionList;
        }
        #endregion Functions private
    }
}