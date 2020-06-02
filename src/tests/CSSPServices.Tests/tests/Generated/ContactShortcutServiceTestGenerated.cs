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
    public partial class ContactShortcutServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IContactShortcutService contactShortcutService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public ContactShortcutServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactShortcut_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               ContactShortcut contactShortcut = GetFilledRandomContactShortcut(""); 

               // List<ContactShortcut>
               var actionContactShortcutList = await contactShortcutService.GetContactShortcutList();
               Assert.Equal(200, ((ObjectResult)actionContactShortcutList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactShortcutList.Result).Value);
               List<ContactShortcut> contactShortcutList = (List<ContactShortcut>)(((OkObjectResult)actionContactShortcutList.Result).Value);

               int count = ((List<ContactShortcut>)((OkObjectResult)actionContactShortcutList.Result).Value).Count();
                Assert.True(count > 0);

               // Add ContactShortcut
               var actionContactShortcutAdded = await contactShortcutService.Add(contactShortcut);
               Assert.Equal(200, ((ObjectResult)actionContactShortcutAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactShortcutAdded.Result).Value);
               ContactShortcut contactShortcutAdded = (ContactShortcut)(((OkObjectResult)actionContactShortcutAdded.Result).Value);
               Assert.NotNull(contactShortcutAdded);

               // Update ContactShortcut
               var actionContactShortcutUpdated = await contactShortcutService.Update(contactShortcut);
               Assert.Equal(200, ((ObjectResult)actionContactShortcutUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactShortcutUpdated.Result).Value);
               ContactShortcut contactShortcutUpdated = (ContactShortcut)(((OkObjectResult)actionContactShortcutUpdated.Result).Value);
               Assert.NotNull(contactShortcutUpdated);

               // Delete ContactShortcut
               var actionContactShortcutDeleted = await contactShortcutService.Delete(contactShortcut);
               Assert.Equal(200, ((ObjectResult)actionContactShortcutDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionContactShortcutDeleted.Result).Value);
               ContactShortcut contactShortcutDeleted = (ContactShortcut)(((OkObjectResult)actionContactShortcutDeleted.Result).Value);
               Assert.NotNull(contactShortcutDeleted);
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
            Services.AddSingleton<IContactShortcutService, ContactShortcutService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            contactShortcutService = Provider.GetService<IContactShortcutService>();
            Assert.NotNull(contactShortcutService);
        
            await contactShortcutService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private ContactShortcut GetFilledRandomContactShortcut(string OmitPropName)
        {
            ContactShortcut contactShortcut = new ContactShortcut();

            if (OmitPropName != "ContactID") contactShortcut.ContactID = 1;
            if (OmitPropName != "ShortCutText") contactShortcut.ShortCutText = GetRandomString("", 5);
            if (OmitPropName != "ShortCutAddress") contactShortcut.ShortCutAddress = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") contactShortcut.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") contactShortcut.LastUpdateContactTVItemID = 2;

            return contactShortcut;
        }
        #endregion Functions private
    }
}
