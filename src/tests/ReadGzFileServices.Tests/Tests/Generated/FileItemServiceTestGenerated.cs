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
    public partial class FileItemServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IFileItemService FileItemService { get; set; }
        private FileItem fileItem { get; set; }
        #endregion Properties

        #region Constructors
        public FileItemServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Basic Test Not Mapped
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task FileItemService_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            fileItem = GetFilledRandomFileItem("");

            List<ValidationResult> ValidationResultsList = FileItemService.Validate(new ValidationContext(fileItem)).ToList();
            Assert.True(ValidationResultsList.Count == 0);
        }
        #endregion Tests Generated Basic Test Not Mapped

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservicestests.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IFileItemService, FileItemService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            FileItemService = Provider.GetService<IFileItemService>();
            Assert.NotNull(FileItemService);

            return await Task.FromResult(true);
        }
        private FileItem GetFilledRandomFileItem(string OmitPropName)
        {
            FileItem fileItem = new FileItem();

            if (OmitPropName != "Name") fileItem.Name = GetRandomString("", 6);
            if (OmitPropName != "TVItemID") fileItem.TVItemID = GetRandomInt(1, 11);

            return fileItem;
        }
        private void CheckFileItemFields(List<FileItem> fileItemList)
        {
            Assert.False(string.IsNullOrWhiteSpace(fileItemList[0].Name));
        }
        #endregion Functions private
    }
}
