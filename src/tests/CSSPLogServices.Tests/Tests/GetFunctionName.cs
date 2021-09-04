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
        public async Task CSSPLogService_GetFunctionName_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string ThisFunction = "ThisFunction";
            Assert.Equal(ThisFunction, await CSSPLogService.GetFunctionName($"<{ThisFunction}>"));
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
