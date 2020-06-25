using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace CSSPServices.Tests
{
    public partial class WebServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        // see Helpers.cs
        #endregion Properties

        #region Constructors
        // see Helpers.cs
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebCountry = await WebService.GetWebCountry(7);
            Assert.Equal(200, ((ObjectResult)actionWebCountry.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebCountry.Result).Value);
            WebCountry webCountry = (WebCountry)((OkObjectResult)actionWebCountry.Result).Value;
            Assert.NotNull(webCountry);
            Assert.NotNull(webCountry.TVItem);
            Assert.NotNull(webCountry.TVItemLanguageList);
            Assert.NotNull(webCountry.TVItemStatList);
            Assert.NotNull(webCountry.MapInfoList);
            Assert.NotNull(webCountry.MapInfoPointList);
        }
        #endregion Tests Generated CRUD

        #region Functions private
        #endregion Functions private
    }
}
