using System.Threading.Tasks;
using Xunit;

namespace CSSPLogServices.Tests
{
    public partial class CSSPLogServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see under Setup.cs
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FillConfigModel_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.True(CSSPLogService.FillConfigModel(config));

        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
