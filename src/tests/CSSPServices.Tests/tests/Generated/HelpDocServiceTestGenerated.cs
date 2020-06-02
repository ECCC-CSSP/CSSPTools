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
using System.Transactions;
using Xunit;

namespace CSSPServices.Tests
{
    public partial class HelpDocServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IHelpDocService helpDocService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public HelpDocServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task HelpDoc_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               HelpDoc helpDoc = GetFilledRandomHelpDoc(""); 

               // List<HelpDoc>
               var actionHelpDocList = await helpDocService.GetHelpDocList();
               Assert.Equal(200, ((ObjectResult)actionHelpDocList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHelpDocList.Result).Value);
               List<HelpDoc> helpDocList = (List<HelpDoc>)(((OkObjectResult)actionHelpDocList.Result).Value);

               int count = ((List<HelpDoc>)((OkObjectResult)actionHelpDocList.Result).Value).Count();
                Assert.True(count > 0);

               // Add HelpDoc
               var actionHelpDocAdded = await helpDocService.Add(helpDoc);
               Assert.Equal(200, ((ObjectResult)actionHelpDocAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHelpDocAdded.Result).Value);
               HelpDoc helpDocAdded = (HelpDoc)(((OkObjectResult)actionHelpDocAdded.Result).Value);
               Assert.NotNull(helpDocAdded);

               // Update HelpDoc
               var actionHelpDocUpdated = await helpDocService.Update(helpDoc);
               Assert.Equal(200, ((ObjectResult)actionHelpDocUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHelpDocUpdated.Result).Value);
               HelpDoc helpDocUpdated = (HelpDoc)(((OkObjectResult)actionHelpDocUpdated.Result).Value);
               Assert.NotNull(helpDocUpdated);

               // Delete HelpDoc
               var actionHelpDocDeleted = await helpDocService.Delete(helpDoc);
               Assert.Equal(200, ((ObjectResult)actionHelpDocDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHelpDocDeleted.Result).Value);
               HelpDoc helpDocDeleted = (HelpDoc)(((OkObjectResult)actionHelpDocDeleted.Result).Value);
               Assert.NotNull(helpDocDeleted);
            }
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
            Services.AddSingleton<IHelpDocService, HelpDocService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            helpDocService = Provider.GetService<IHelpDocService>();
            Assert.NotNull(helpDocService);
        
            await helpDocService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private HelpDoc GetFilledRandomHelpDoc(string OmitPropName)
        {
            HelpDoc helpDoc = new HelpDoc();

            if (OmitPropName != "DocKey") helpDoc.DocKey = GetRandomString("", 5);
            if (OmitPropName != "Language") helpDoc.Language = LanguageRequest;
            if (OmitPropName != "DocHTMLText") helpDoc.DocHTMLText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") helpDoc.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") helpDoc.LastUpdateContactTVItemID = 2;

            return helpDoc;
        }
        #endregion Functions private
    }
}
