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
    public partial class PolSourceObservationIssueServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IPolSourceObservationIssueService polSourceObservationIssueService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceObservationIssue_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               PolSourceObservationIssue polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue(""); 

               // List<PolSourceObservationIssue>
               var actionPolSourceObservationIssueList = await polSourceObservationIssueService.GetPolSourceObservationIssueList();
               Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueList.Result).Value);
               List<PolSourceObservationIssue> polSourceObservationIssueList = (List<PolSourceObservationIssue>)(((OkObjectResult)actionPolSourceObservationIssueList.Result).Value);

               int count = ((List<PolSourceObservationIssue>)((OkObjectResult)actionPolSourceObservationIssueList.Result).Value).Count();
                Assert.True(count > 0);

               // Add PolSourceObservationIssue
               var actionPolSourceObservationIssueAdded = await polSourceObservationIssueService.Add(polSourceObservationIssue);
               Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueAdded.Result).Value);
               PolSourceObservationIssue polSourceObservationIssueAdded = (PolSourceObservationIssue)(((OkObjectResult)actionPolSourceObservationIssueAdded.Result).Value);
               Assert.NotNull(polSourceObservationIssueAdded);

               // Update PolSourceObservationIssue
               var actionPolSourceObservationIssueUpdated = await polSourceObservationIssueService.Update(polSourceObservationIssue);
               Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueUpdated.Result).Value);
               PolSourceObservationIssue polSourceObservationIssueUpdated = (PolSourceObservationIssue)(((OkObjectResult)actionPolSourceObservationIssueUpdated.Result).Value);
               Assert.NotNull(polSourceObservationIssueUpdated);

               // Delete PolSourceObservationIssue
               var actionPolSourceObservationIssueDeleted = await polSourceObservationIssueService.Delete(polSourceObservationIssue);
               Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueDeleted.Result).Value);
               PolSourceObservationIssue polSourceObservationIssueDeleted = (PolSourceObservationIssue)(((OkObjectResult)actionPolSourceObservationIssueDeleted.Result).Value);
               Assert.NotNull(polSourceObservationIssueDeleted);
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
            Services.AddSingleton<IPolSourceObservationIssueService, PolSourceObservationIssueService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            polSourceObservationIssueService = Provider.GetService<IPolSourceObservationIssueService>();
            Assert.NotNull(polSourceObservationIssueService);
        
            await polSourceObservationIssueService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private PolSourceObservationIssue GetFilledRandomPolSourceObservationIssue(string OmitPropName)
        {
            PolSourceObservationIssue polSourceObservationIssue = new PolSourceObservationIssue();

            if (OmitPropName != "PolSourceObservationID") polSourceObservationIssue.PolSourceObservationID = 1;
            if (OmitPropName != "ObservationInfo") polSourceObservationIssue.ObservationInfo = GetRandomString("", 5);
            if (OmitPropName != "Ordinal") polSourceObservationIssue.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "ExtraComment") polSourceObservationIssue.ExtraComment = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservationIssue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceObservationIssue.LastUpdateContactTVItemID = 2;

            return polSourceObservationIssue;
        }
        #endregion Functions private
    }
}
