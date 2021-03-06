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
    public partial class RegisterModelServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private IRegisterModelService RegisterModelService { get; set; }
        #endregion Properties

        #region Constructors
        public RegisterModelServiceTest() : base()
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
        public async Task RegisterModel_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            RegisterModel registerModel = GetFilledRandomRegisterModel("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // [CSSPMinLength(1)]
            // registerModel.FirstName   (String)
            // -----------------------------------


            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("FirstName");
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "FirstName"))).Any());


            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("");
            registerModel.FirstName = GetRandomString("", 101);
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "FirstName", "1", "100"))).Any());

            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("");
            registerModel.FirstName = GetRandomString("", 101);
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "FirstName", "1", "100"))).Any());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(100)]
            // registerModel.Initial   (String)
            // -----------------------------------


            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("");
            registerModel.Initial = GetRandomString("", 101);
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Initial", "100"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // [CSSPMinLength(1)]
            // registerModel.LastName   (String)
            // -----------------------------------


            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("LastName");
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "LastName"))).Any());


            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("");
            registerModel.LastName = GetRandomString("", 101);
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LastName", "1", "100"))).Any());

            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("");
            registerModel.LastName = GetRandomString("", 101);
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LastName", "1", "100"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // [CSSPMinLength(5)]
            // registerModel.LoginEmail   (String)
            // -----------------------------------


            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("LoginEmail");
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "LoginEmail"))).Any());


            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("");
            registerModel.LoginEmail = GetRandomString("", 101);
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LoginEmail", "5", "100"))).Any());

            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("");
            registerModel.LoginEmail = GetRandomString("", 101);
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LoginEmail", "5", "100"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(50)]
            // [CSSPMinLength(5)]
            // registerModel.Password   (String)
            // -----------------------------------


            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("Password");
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "Password"))).Any());


            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("");
            registerModel.Password = GetRandomString("", 51);
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Password", "5", "50"))).Any());

            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("");
            registerModel.Password = GetRandomString("", 51);
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Password", "5", "50"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(50)]
            // [CSSPMinLength(5)]
            // registerModel.ConfirmPassword   (String)
            // -----------------------------------


            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("ConfirmPassword");
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "ConfirmPassword"))).Any());


            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("");
            registerModel.ConfirmPassword = GetRandomString("", 51);
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "ConfirmPassword", "5", "50"))).Any());

            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("");
            registerModel.ConfirmPassword = GetRandomString("", 51);
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "ConfirmPassword", "5", "50"))).Any());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // registerModel.ContactTitle   (ContactTitleEnum)
            // -----------------------------------


            registerModel = null;
            registerModel = GetFilledRandomRegisterModel("");
            registerModel.ContactTitle = (ContactTitleEnum)1000000;
            RegisterModelService.Validate(new ValidationContext(registerModel));
            Assert.True(RegisterModelService.ValidationResults.Count() > 0);
            Assert.True(RegisterModelService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "ContactTitle"))).Any());

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
            Services.AddSingleton<IRegisterModelService, RegisterModelService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            RegisterModelService = Provider.GetService<IRegisterModelService>();
            Assert.NotNull(RegisterModelService);

            return await Task.FromResult(true);
        }
        private RegisterModel GetFilledRandomRegisterModel(string OmitPropName)
        {
            RegisterModel registerModel = new RegisterModel();

            if (OmitPropName != "FirstName") registerModel.FirstName = GetRandomString("", 6);
            if (OmitPropName != "Initial") registerModel.Initial = GetRandomString("", 5);
            if (OmitPropName != "LastName") registerModel.LastName = GetRandomString("", 6);
            if (OmitPropName != "LoginEmail") registerModel.LoginEmail = GetRandomString("", 10);
            if (OmitPropName != "Password") registerModel.Password = GetRandomString("", 10);
            if (OmitPropName != "ConfirmPassword") registerModel.ConfirmPassword = GetRandomString("", 10);
            if (OmitPropName != "ContactTitle") registerModel.ContactTitle = (ContactTitleEnum)GetRandomEnumType(typeof(ContactTitleEnum));

            return registerModel;
        }

        #endregion Functions private
    }
}
