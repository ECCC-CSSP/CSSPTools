/* Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPHelperServices_Tests.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPHelperModels;
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
using CSSPHelperServices.Tests;

namespace CSSPHelperServices.Tests
{
    [Collection("Sequential")]
    public partial class NewContactServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private INewContactService NewContactService { get; set; }
        #endregion Properties

        #region Constructors
        public NewContactServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructors
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskParameter_Constructor_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(enums);
        }
        #endregion Tests Generated Constructors

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task NewContact_Properties_Test(string culture)
        {
            List<ValidationResult> ValidationResultList = new List<ValidationResult>();
            IEnumerable<ValidationResult> validationResults;
            Assert.True(await Setup(culture));



            NewContact newContact = GetFilledRandomNewContact("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(200)]
            // [CSSPMinLength(1)]
            // newContact.LoginEmail   (String)
            // -----------------------------------


            newContact = null;
            newContact = GetFilledRandomNewContact("LoginEmail");
            validationResults = NewContactService.Validate(new ValidationContext(newContact));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "LoginEmail"))).Any());


            newContact = null;
            newContact = GetFilledRandomNewContact("");
            newContact.LoginEmail = GetRandomString("", 201);
            validationResults = NewContactService.Validate(new ValidationContext(newContact));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LoginEmail", "1", "200"))).Any());

            newContact = null;
            newContact = GetFilledRandomNewContact("");
            newContact.LoginEmail = GetRandomString("", 201);
            validationResults = NewContactService.Validate(new ValidationContext(newContact));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LoginEmail", "1", "200"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(200)]
            // [CSSPMinLength(1)]
            // newContact.FirstName   (String)
            // -----------------------------------


            newContact = null;
            newContact = GetFilledRandomNewContact("FirstName");
            validationResults = NewContactService.Validate(new ValidationContext(newContact));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "FirstName"))).Any());


            newContact = null;
            newContact = GetFilledRandomNewContact("");
            newContact.FirstName = GetRandomString("", 201);
            validationResults = NewContactService.Validate(new ValidationContext(newContact));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "FirstName", "1", "200"))).Any());

            newContact = null;
            newContact = GetFilledRandomNewContact("");
            newContact.FirstName = GetRandomString("", 201);
            validationResults = NewContactService.Validate(new ValidationContext(newContact));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "FirstName", "1", "200"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(200)]
            // [CSSPMinLength(1)]
            // newContact.LastName   (String)
            // -----------------------------------


            newContact = null;
            newContact = GetFilledRandomNewContact("LastName");
            validationResults = NewContactService.Validate(new ValidationContext(newContact));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "LastName"))).Any());


            newContact = null;
            newContact = GetFilledRandomNewContact("");
            newContact.LastName = GetRandomString("", 201);
            validationResults = NewContactService.Validate(new ValidationContext(newContact));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LastName", "1", "200"))).Any());

            newContact = null;
            newContact = GetFilledRandomNewContact("");
            newContact.LastName = GetRandomString("", 201);
            validationResults = NewContactService.Validate(new ValidationContext(newContact));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LastName", "1", "200"))).Any());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(50)]
            // newContact.Initial   (String)
            // -----------------------------------


            newContact = null;
            newContact = GetFilledRandomNewContact("");
            newContact.Initial = GetRandomString("", 51);
            validationResults = NewContactService.Validate(new ValidationContext(newContact));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Initial", "50"))).Any());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // newContact.ContactTitle   (ContactTitleEnum)
            // -----------------------------------


            newContact = null;
            newContact = GetFilledRandomNewContact("");
            newContact.ContactTitle = (ContactTitleEnum)1000000;
            validationResults = NewContactService.Validate(new ValidationContext(newContact));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "ContactTitle"))).Any());


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(100)]
            // newContact.ContactTitleText   (String)
            // -----------------------------------


            newContact = null;
            newContact = GetFilledRandomNewContact("");
            newContact.ContactTitleText = GetRandomString("", 101);
            validationResults = NewContactService.Validate(new ValidationContext(newContact));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ContactTitleText", "100"))).Any());
        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_CSSPDBServicestests.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<INewContactService, NewContactService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            NewContactService = Provider.GetService<INewContactService>();
            Assert.NotNull(NewContactService);

            return await Task.FromResult(true);
        }
        private NewContact GetFilledRandomNewContact(string OmitPropName)
        {
            NewContact newContact = new NewContact();

            if (OmitPropName != "LoginEmail") newContact.LoginEmail = GetRandomString("", 6);
            if (OmitPropName != "FirstName") newContact.FirstName = GetRandomString("", 6);
            if (OmitPropName != "LastName") newContact.LastName = GetRandomString("", 6);
            if (OmitPropName != "Initial") newContact.Initial = GetRandomString("", 5);
            if (OmitPropName != "ContactTitle") newContact.ContactTitle = (ContactTitleEnum)GetRandomEnumType(typeof(ContactTitleEnum));
            if (OmitPropName != "ContactTitleText") newContact.ContactTitleText = GetRandomString("", 5);

            return newContact;
        }

        #endregion Functions private
    }
}
