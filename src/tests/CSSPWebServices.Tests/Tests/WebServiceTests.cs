using CSSPWebModels;
using CSSPWebServices.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace CSSPWebServices.Tests
{
    public partial class WebServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see Helpers.cs
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        public async Task DoStoreFilesUndercsspfilesForSubsector_Good_Test(string culture)
        {
            //Assert.True(await Setup(culture));

            //bool retBool = await WebService.StoreFilesUndercsspfilesForSubsector(635); // Bouctouche River and Harbour Subsector
            //Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebRoot = await WebService.GetWebRoot();
            Assert.Equal(200, ((ObjectResult)actionWebRoot.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebRoot.Result).Value);
            WebRoot webRoot = (WebRoot)((OkObjectResult)actionWebRoot.Result).Value;
            Assert.NotNull(webRoot);
            Assert.NotNull(webRoot.TVItem);
            Assert.NotNull(webRoot.TVItemLanguageList);
            Assert.NotNull(webRoot.MapInfoList);
            Assert.NotNull(webRoot.MapInfoPointList);
            Assert.NotNull(webRoot.TVItemCountryList);
            Assert.NotNull(webRoot.TVItemLanguageCountryList);
            Assert.NotNull(webRoot.MapInfoCountryList);
            Assert.NotNull(webRoot.MapInfoPointCountryList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebCountry = await WebService.GetWebCountry(5);
            Assert.Equal(200, ((ObjectResult)actionWebCountry.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebCountry.Result).Value);
            WebCountry webCountry = (WebCountry)((OkObjectResult)actionWebCountry.Result).Value;
            Assert.NotNull(webCountry);
            Assert.NotNull(webCountry.TVItem);
            Assert.NotNull(webCountry.TVItemLanguageList);
            Assert.NotNull(webCountry.MapInfoList);
            Assert.NotNull(webCountry.MapInfoPointList);
        }
        #endregion Tests Generated CRUD

        #region Functions private
        #endregion Functions private
    }
}
