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
            Assert.NotNull(webRoot.TVItemStatList);
            Assert.NotNull(webRoot.MapInfoList);
            Assert.NotNull(webRoot.MapInfoPointList);
        }
        #endregion Tests Generated CRUD

        #region Functions private
        #endregion Functions private
    }
}
