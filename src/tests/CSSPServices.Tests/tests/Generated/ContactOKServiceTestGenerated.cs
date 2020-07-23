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

namespace CSSPServices.Tests
{
    public partial class ContactOKServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IContactOKService ContactOKService { get; set; }
        private ContactOK contactOK { get; set; }
        #endregion Properties

        #region Constructors
        public ContactOKServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Basic Test Not Mapped
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactOKService_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            contactOK = GetFilledRandomContactOK("");

            List<ValidationResult> ValidationResultsList = ContactOKService.Validate(new ValidationContext(contactOK)).ToList();
            Assert.True(ValidationResultsList.Count == 0);
        }
        #endregion Tests Generated Basic Test Not Mapped

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservices.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IContactOKService, ContactOKService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            ContactOKService = Provider.GetService<IContactOKService>();
            Assert.NotNull(ContactOKService);

            return await Task.FromResult(true);
        }
        private ContactOK GetFilledRandomContactOK(string OmitPropName)
        {
            ContactOK contactOK = new ContactOK();

            if (OmitPropName != "ContactID") contactOK.ContactID = GetRandomInt(1, 11);
            if (OmitPropName != "ContactTVItemID") contactOK.ContactTVItemID = GetRandomInt(1, 11);

            return contactOK;
        }
        private void CheckContactOKFields(List<ContactOK> contactOKList)
        {
        }
        #endregion Functions private
    }
}
