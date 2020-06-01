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
    public partial class EmailServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IEmailService emailService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public EmailServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task Email_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            Email email = GetFilledRandomEmail(""); 

            // List<Email>
            var actionEmailList = await emailService.GetEmailList();
            Assert.Equal(200, ((ObjectResult)actionEmailList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailList.Result).Value);
            List<Email> emailList = (List<Email>)(((OkObjectResult)actionEmailList.Result).Value);

            int count = ((List<Email>)((OkObjectResult)actionEmailList.Result).Value).Count();
            Assert.True(count > 0);

            // Add Email
            var actionEmailAdded = await emailService.Add(email);
            Assert.Equal(200, ((ObjectResult)actionEmailAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailAdded.Result).Value);
            Email emailAdded = (Email)(((OkObjectResult)actionEmailAdded.Result).Value);
            Assert.NotNull(emailAdded);

            // Update Email
            var actionEmailUpdated = await emailService.Update(email);
            Assert.Equal(200, ((ObjectResult)actionEmailUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailUpdated.Result).Value);
            Email emailUpdated = (Email)(((OkObjectResult)actionEmailUpdated.Result).Value);
            Assert.NotNull(emailUpdated);

            // Delete Email
            var actionEmailDeleted = await emailService.Delete(email);
            Assert.Equal(200, ((ObjectResult)actionEmailDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDeleted.Result).Value);
            Email emailDeleted = (Email)(((OkObjectResult)actionEmailDeleted.Result).Value);
            Assert.NotNull(emailDeleted);
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
            Services.AddSingleton<IEmailService, EmailService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            emailService = Provider.GetService<IEmailService>();
            Assert.NotNull(emailService);
        
            await emailService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private Email GetFilledRandomEmail(string OmitPropName)
        {
            Email email = new Email();

            if (OmitPropName != "EmailTVItemID") email.EmailTVItemID = 54;
            if (OmitPropName != "EmailAddress") email.EmailAddress = GetRandomEmail();
            if (OmitPropName != "EmailType") email.EmailType = (EmailTypeEnum)GetRandomEnumType(typeof(EmailTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") email.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") email.LastUpdateContactTVItemID = 2;

            return email;
        }
        #endregion Functions private
    }
}