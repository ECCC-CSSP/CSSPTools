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
    public partial class ElementServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IElementService ElementService { get; set; }
        private Element element { get; set; }
        #endregion Properties

        #region Constructors
        public ElementServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Basic Test Not Mapped
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ElementService_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            element = GetFilledRandomElement("");

            List<ValidationResult> ValidationResultsList = ElementService.Validate(new ValidationContext(element)).ToList();
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
            Services.AddSingleton<IElementService, ElementService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            ElementService = Provider.GetService<IElementService>();
            Assert.NotNull(ElementService);

            return await Task.FromResult(true);
        }
        private Element GetFilledRandomElement(string OmitPropName)
        {
            Element element = new Element();

            if (OmitPropName != "ID") element.ID = GetRandomInt(1, 11);
            if (OmitPropName != "Type") element.Type = GetRandomInt(1, 11);
            if (OmitPropName != "NumbOfNodes") element.NumbOfNodes = GetRandomInt(1, 11);
            // should implement a Range for the property Value and type Element
            // should implement a Range for the property XNode0 and type Element
            // should implement a Range for the property YNode0 and type Element
            // should implement a Range for the property ZNode0 and type Element
            //CSSPError: property [NodeList] and type [Element] is  not implemented

            return element;
        }
        private void CheckElementFields(List<Element> elementList)
        {
        }
        #endregion Functions private
    }
}
