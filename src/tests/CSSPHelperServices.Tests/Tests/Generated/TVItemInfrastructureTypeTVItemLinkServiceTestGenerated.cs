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
    public partial class TVItemInfrastructureTypeTVItemLinkServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ITVItemInfrastructureTypeTVItemLinkService TVItemInfrastructureTypeTVItemLinkService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemInfrastructureTypeTVItemLinkServiceTest() : base()
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
        public async Task TVItemInfrastructureTypeTVItemLink_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            TVItemInfrastructureTypeTVItemLink tvItemInfrastructureTypeTVItemLink = GetFilledRandomTVItemInfrastructureTypeTVItemLink("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItemInfrastructureTypeTVItemLink.InfrastructureType   (InfrastructureTypeEnum)
            // -----------------------------------


            tvItemInfrastructureTypeTVItemLink = null;
            tvItemInfrastructureTypeTVItemLink = GetFilledRandomTVItemInfrastructureTypeTVItemLink("");
            tvItemInfrastructureTypeTVItemLink.InfrastructureType = (InfrastructureTypeEnum)1000000;
            TVItemInfrastructureTypeTVItemLinkService.Validate(new ValidationContext(tvItemInfrastructureTypeTVItemLink));
            Assert.True(TVItemInfrastructureTypeTVItemLinkService.errRes.ErrList.Count() > 0);
            Assert.True(TVItemInfrastructureTypeTVItemLinkService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "InfrastructureType"))).Any());


            // -----------------------------------
            // Is Nullable
            // tvItemInfrastructureTypeTVItemLink.SeeOtherMunicipalityTVItemID   (Int32)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(100)]
            // tvItemInfrastructureTypeTVItemLink.InfrastructureTypeText   (String)
            // -----------------------------------


            tvItemInfrastructureTypeTVItemLink = null;
            tvItemInfrastructureTypeTVItemLink = GetFilledRandomTVItemInfrastructureTypeTVItemLink("");
            tvItemInfrastructureTypeTVItemLink.InfrastructureTypeText = GetRandomString("", 101);
            TVItemInfrastructureTypeTVItemLinkService.Validate(new ValidationContext(tvItemInfrastructureTypeTVItemLink));
            Assert.True(TVItemInfrastructureTypeTVItemLinkService.errRes.ErrList.Count() > 0);
            Assert.True(TVItemInfrastructureTypeTVItemLinkService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "InfrastructureTypeText", "100"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // tvItemInfrastructureTypeTVItemLink.TVItem   (TVItem)
            // -----------------------------------

            //CSSPError: Type not implemented [TVItem]

            //CSSPError: Type not implemented [TVItem]


            // -----------------------------------
            // Is NOT Nullable
            // tvItemInfrastructureTypeTVItemLink.TVItemLinkList   (TVItemLink)
            // -----------------------------------

            //CSSPError: Type not implemented [TVItemLinkList]

            //CSSPError: Type not implemented [TVItemLinkList]


            // -----------------------------------
            // Is NOT Nullable
            // tvItemInfrastructureTypeTVItemLink.FlowTo   (TVItemInfrastructureTypeTVItemLink)
            // -----------------------------------

            //CSSPError: Type not implemented [FlowTo]

            //CSSPError: Type not implemented [FlowTo]

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
            Services.AddSingleton<ITVItemInfrastructureTypeTVItemLinkService, TVItemInfrastructureTypeTVItemLinkService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            TVItemInfrastructureTypeTVItemLinkService = Provider.GetService<ITVItemInfrastructureTypeTVItemLinkService>();
            Assert.NotNull(TVItemInfrastructureTypeTVItemLinkService);

            return await Task.FromResult(true);
        }
        private TVItemInfrastructureTypeTVItemLink GetFilledRandomTVItemInfrastructureTypeTVItemLink(string OmitPropName)
        {
            TVItemInfrastructureTypeTVItemLink tvItemInfrastructureTypeTVItemLink = new TVItemInfrastructureTypeTVItemLink();

            if (OmitPropName != "InfrastructureType") tvItemInfrastructureTypeTVItemLink.InfrastructureType = (InfrastructureTypeEnum)GetRandomEnumType(typeof(InfrastructureTypeEnum));
            // should implement a Range for the property SeeOtherMunicipalityTVItemID and type TVItemInfrastructureTypeTVItemLink
            if (OmitPropName != "InfrastructureTypeText") tvItemInfrastructureTypeTVItemLink.InfrastructureTypeText = GetRandomString("", 5);
            //CSSPError: property [TVItem] and type [TVItemInfrastructureTypeTVItemLink] is  not implemented
            //CSSPError: property [TVItemLinkList] and type [TVItemInfrastructureTypeTVItemLink] is  not implemented
            //CSSPError: property [FlowTo] and type [TVItemInfrastructureTypeTVItemLink] is  not implemented

            return tvItemInfrastructureTypeTVItemLink;
        }

        #endregion Functions private
    }
}
