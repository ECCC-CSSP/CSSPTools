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
    public partial class FileItemListServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private IFileItemListService FileItemListService { get; set; }
        #endregion Properties

        #region Constructors
        public FileItemListServiceTest() : base()
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
        public async Task FileItemList_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FileItemList fileItemList = GetFilledRandomFileItemList("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(255)]
            // [CSSPMinLength(1)]
            // fileItemList.Text   (String)
            // -----------------------------------


            fileItemList = null;
            fileItemList = GetFilledRandomFileItemList("Text");
            FileItemListService.Validate(new ValidationContext(fileItemList));
            Assert.True(FileItemListService.errRes.ErrList.Count() > 0);
            Assert.True(FileItemListService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "Text"))).Any());


            fileItemList = null;
            fileItemList = GetFilledRandomFileItemList("");
            fileItemList.Text = GetRandomString("", 256);
            FileItemListService.Validate(new ValidationContext(fileItemList));
            Assert.True(FileItemListService.errRes.ErrList.Count() > 0);
            Assert.True(FileItemListService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Text", "1", "255"))).Any());

            fileItemList = null;
            fileItemList = GetFilledRandomFileItemList("");
            fileItemList.Text = GetRandomString("", 256);
            FileItemListService.Validate(new ValidationContext(fileItemList));
            Assert.True(FileItemListService.errRes.ErrList.Count() > 0);
            Assert.True(FileItemListService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Text", "1", "255"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(255)]
            // [CSSPMinLength(1)]
            // fileItemList.FileName   (String)
            // -----------------------------------


            fileItemList = null;
            fileItemList = GetFilledRandomFileItemList("FileName");
            FileItemListService.Validate(new ValidationContext(fileItemList));
            Assert.True(FileItemListService.errRes.ErrList.Count() > 0);
            Assert.True(FileItemListService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "FileName"))).Any());


            fileItemList = null;
            fileItemList = GetFilledRandomFileItemList("");
            fileItemList.FileName = GetRandomString("", 256);
            FileItemListService.Validate(new ValidationContext(fileItemList));
            Assert.True(FileItemListService.errRes.ErrList.Count() > 0);
            Assert.True(FileItemListService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "FileName", "1", "255"))).Any());

            fileItemList = null;
            fileItemList = GetFilledRandomFileItemList("");
            fileItemList.FileName = GetRandomString("", 256);
            FileItemListService.Validate(new ValidationContext(fileItemList));
            Assert.True(FileItemListService.errRes.ErrList.Count() > 0);
            Assert.True(FileItemListService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "FileName", "1", "255"))).Any());
        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_cssphelperservicestests.json")
               .AddUserSecrets("a79b4a81-ba75-4dfc-8d95-46259f73f055")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IFileItemListService, FileItemListService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            FileItemListService = Provider.GetService<IFileItemListService>();
            Assert.NotNull(FileItemListService);

            return await Task.FromResult(true);
        }
        private FileItemList GetFilledRandomFileItemList(string OmitPropName)
        {
            FileItemList fileItemList = new FileItemList();

            if (OmitPropName != "Text") fileItemList.Text = GetRandomString("", 6);
            if (OmitPropName != "FileName") fileItemList.FileName = GetRandomString("", 6);

            return fileItemList;
        }

        #endregion Functions private
    }
}
