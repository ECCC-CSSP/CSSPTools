using CSSPWebModels;
using System;
using Xunit;

namespace CSSPWebModelsTests.Tests
{
    public class WebRootTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private WebRoot webRoot { get; set; }
        #endregion Properties

        #region Constructors
        public WebRootTests()
        {
            webRoot = new WebRoot();
        }
        #endregion Constructors


        #region Tests Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public void WebRoot_Good_Test(string culture)
        {
            Assert.NotEmpty(culture);
        }
        #endregion Tests Functions public
    }
}
