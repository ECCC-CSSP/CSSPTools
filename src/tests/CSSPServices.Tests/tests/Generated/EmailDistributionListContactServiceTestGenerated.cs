/* Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceTestGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
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
    public partial class EmailDistributionListContactServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private IEmailDistributionListContactService emailDistributionListContactService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EmailDistributionListContact_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               EmailDistributionListContact emailDistributionListContact = GetFilledRandomEmailDistributionListContact(""); 

               // List<EmailDistributionListContact>
               var actionEmailDistributionListContactList = await emailDistributionListContactService.GetEmailDistributionListContactList();
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactList.Result).Value);
               List<EmailDistributionListContact> emailDistributionListContactList = (List<EmailDistributionListContact>)((OkObjectResult)actionEmailDistributionListContactList.Result).Value;

               int count = ((List<EmailDistributionListContact>)((OkObjectResult)actionEmailDistributionListContactList.Result).Value).Count();
                Assert.True(count > 0);

               // Add EmailDistributionListContact
               var actionEmailDistributionListContactAdded = await emailDistributionListContactService.Add(emailDistributionListContact);
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactAdded.Result).Value);
               EmailDistributionListContact emailDistributionListContactAdded = (EmailDistributionListContact)((OkObjectResult)actionEmailDistributionListContactAdded.Result).Value;
               Assert.NotNull(emailDistributionListContactAdded);

               // Update EmailDistributionListContact
               var actionEmailDistributionListContactUpdated = await emailDistributionListContactService.Update(emailDistributionListContact);
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactUpdated.Result).Value);
               EmailDistributionListContact emailDistributionListContactUpdated = (EmailDistributionListContact)((OkObjectResult)actionEmailDistributionListContactUpdated.Result).Value;
               Assert.NotNull(emailDistributionListContactUpdated);

               // Delete EmailDistributionListContact
               var actionEmailDistributionListContactDeleted = await emailDistributionListContactService.Delete(emailDistributionListContact.EmailDistributionListContactID);
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionEmailDistributionListContactDeleted.Result).Value;
               Assert.True(retBool);
            }
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
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

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IEmailDistributionListContactService, EmailDistributionListContactService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            emailDistributionListContactService = Provider.GetService<IEmailDistributionListContactService>();
            Assert.NotNull(emailDistributionListContactService);

            return await Task.FromResult(true);
        }
        private EmailDistributionListContact GetFilledRandomEmailDistributionListContact(string OmitPropName)
        {
            EmailDistributionListContact emailDistributionListContact = new EmailDistributionListContact();

            if (OmitPropName != "EmailDistributionListID") emailDistributionListContact.EmailDistributionListID = 1;
            if (OmitPropName != "IsCC") emailDistributionListContact.IsCC = true;
            if (OmitPropName != "Name") emailDistributionListContact.Name = GetRandomString("", 5);
            if (OmitPropName != "Email") emailDistributionListContact.Email = GetRandomEmail();
            if (OmitPropName != "CMPRainfallSeasonal") emailDistributionListContact.CMPRainfallSeasonal = true;
            if (OmitPropName != "CMPWastewater") emailDistributionListContact.CMPWastewater = true;
            if (OmitPropName != "EmergencyWeather") emailDistributionListContact.EmergencyWeather = true;
            if (OmitPropName != "EmergencyWastewater") emailDistributionListContact.EmergencyWastewater = true;
            if (OmitPropName != "ReopeningAllTypes") emailDistributionListContact.ReopeningAllTypes = true;
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionListContact.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionListContact.LastUpdateContactTVItemID = 2;

            return emailDistributionListContact;
        }
        #endregion Functions private
    }
}
