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

namespace CSSPServices.Tests
{
    public partial class RegisterModelServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IRegisterModelService RegisterModelService { get; set; }
        private RegisterModel registerModel { get; set; }
        #endregion Properties

        #region Constructors
        public RegisterModelServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Basic Test Not Mapped
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task RegisterModelService_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            registerModel = GetFilledRandomRegisterModel("");

            List<ValidationResult> ValidationResultsList = RegisterModelService.Validate(new ValidationContext(registerModel)).ToList();
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
            Services.AddSingleton<IRegisterModelService, RegisterModelService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

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

            return registerModel;
        }
        private void CheckRegisterModelFields(List<RegisterModel> registerModelList)
        {
            Assert.False(string.IsNullOrWhiteSpace(registerModelList[0].FirstName));
            if (!string.IsNullOrWhiteSpace(registerModelList[0].Initial))
            {
                Assert.False(string.IsNullOrWhiteSpace(registerModelList[0].Initial));
            }
            Assert.False(string.IsNullOrWhiteSpace(registerModelList[0].LastName));
            Assert.False(string.IsNullOrWhiteSpace(registerModelList[0].LoginEmail));
            Assert.False(string.IsNullOrWhiteSpace(registerModelList[0].Password));
            Assert.False(string.IsNullOrWhiteSpace(registerModelList[0].ConfirmPassword));
        }
        #endregion Functions private
    }
}
