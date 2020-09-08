/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Services;
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
using System.ComponentModel.DataAnnotations;
using CSSPCultureServices.Resources;
using LocalServices;

namespace CSSPDBLocalIMServices.Tests
{
    [Collection("Sequential")]
    public partial class EmailDistributionListDBLocalIMServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IEmailDistributionListDBLocalIMService EmailDistributionListDBLocalIMService { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private EmailDistributionList emailDistributionList { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListDBLocalIMServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DBLocalIM]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EmailDistributionListDBLocalIM_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            emailDistributionList = GetFilledRandomEmailDistributionList("");

            await DoCRUDDBLocalIMTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EmailDistributionList_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionEmailDistributionListList = await EmailDistributionListDBLocalIMService.GetEmailDistributionListList();
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListList.Result).Value);
            List<EmailDistributionList> emailDistributionListList = (List<EmailDistributionList>)((OkObjectResult)actionEmailDistributionListList.Result).Value;

            count = emailDistributionListList.Count();

            EmailDistributionList emailDistributionList = GetFilledRandomEmailDistributionList("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // emailDistributionList.EmailDistributionListID   (Int32)
            // -----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.EmailDistributionListID = 0;

            var actionEmailDistributionList = await EmailDistributionListDBLocalIMService.Put(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.EmailDistributionListID = 10000000;
            actionEmailDistributionList = await EmailDistributionListDBLocalIMService.Put(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Country)]
            // emailDistributionList.ParentTVItemID   (Int32)
            // -----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.ParentTVItemID = 0;
            actionEmailDistributionList = await EmailDistributionListDBLocalIMService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.ParentTVItemID = 1;
            actionEmailDistributionList = await EmailDistributionListDBLocalIMService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // emailDistributionList.Ordinal   (Int32)
            // -----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.Ordinal = -1;
            actionEmailDistributionList = await EmailDistributionListDBLocalIMService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);
            //Assert.AreEqual(count, emailDistributionListService.GetEmailDistributionListList().Count());
            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.Ordinal = 1001;
            actionEmailDistributionList = await EmailDistributionListDBLocalIMService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);
            //Assert.AreEqual(count, emailDistributionListDBLocalIMService.GetEmailDistributionListList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // emailDistributionList.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.LastUpdateDate_UTC = new DateTime();
            actionEmailDistributionList = await EmailDistributionListDBLocalIMService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);
            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionEmailDistributionList = await EmailDistributionListDBLocalIMService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // emailDistributionList.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.LastUpdateContactTVItemID = 0;
            actionEmailDistributionList = await EmailDistributionListDBLocalIMService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.LastUpdateContactTVItemID = 1;
            actionEmailDistributionList = await EmailDistributionListDBLocalIMService.Post(emailDistributionList);
            Assert.IsType<BadRequestObjectResult>(actionEmailDistributionList.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalIMTest()
        {
            emailDistributionList.EmailDistributionListID = 10000000;

            // Post EmailDistributionList
            var actionEmailDistributionListAdded = await EmailDistributionListDBLocalIMService.Post(emailDistributionList);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListAdded.Result).Value);
            EmailDistributionList emailDistributionListAdded = (EmailDistributionList)((OkObjectResult)actionEmailDistributionListAdded.Result).Value;
            Assert.NotNull(emailDistributionListAdded);

            // List<EmailDistributionList>
            var actionEmailDistributionListList = await EmailDistributionListDBLocalIMService.GetEmailDistributionListList();
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListList.Result).Value);
            List<EmailDistributionList> emailDistributionListList = (List<EmailDistributionList>)((OkObjectResult)actionEmailDistributionListList.Result).Value;

            int count = ((List<EmailDistributionList>)((OkObjectResult)actionEmailDistributionListList.Result).Value).Count();
            Assert.True(count > 0);

            // Get EmailDistributionList With EmailDistributionListID
            var actionEmailDistributionListGet = await EmailDistributionListDBLocalIMService.GetEmailDistributionListWithEmailDistributionListID(emailDistributionListList[0].EmailDistributionListID);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListGet.Result).Value);
            EmailDistributionList emailDistributionListGet = (EmailDistributionList)((OkObjectResult)actionEmailDistributionListGet.Result).Value;
            Assert.NotNull(emailDistributionListGet);
            Assert.Equal(emailDistributionListGet.EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);

            // Put EmailDistributionList
            var actionEmailDistributionListUpdated = await EmailDistributionListDBLocalIMService.Put(emailDistributionList);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListUpdated.Result).Value);
            EmailDistributionList emailDistributionListUpdated = (EmailDistributionList)((OkObjectResult)actionEmailDistributionListUpdated.Result).Value;
            Assert.NotNull(emailDistributionListUpdated);

            // Delete EmailDistributionList
            var actionEmailDistributionListDeleted = await EmailDistributionListDBLocalIMService.Delete(emailDistributionList.EmailDistributionListID);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionEmailDistributionListDeleted.Result).Value;
            Assert.True(retBool);

        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalimservicestests.json")
               .AddUserSecrets("64a6d1e4-0d0c-4e59-9c2e-640182417704")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLoginFileName = Config.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLoginFileName);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IEmailDistributionListDBLocalIMService, EmailDistributionListDBLocalIMService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocalIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbLocalIM);

            EmailDistributionListDBLocalIMService = Provider.GetService<IEmailDistributionListDBLocalIMService>();
            Assert.NotNull(EmailDistributionListDBLocalIMService);

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
        private void CheckEmailDistributionListFields(List<EmailDistributionList> emailDistributionListList)
        {
        }

        #endregion Functions private
    }
}
