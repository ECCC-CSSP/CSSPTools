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
        public async Task CSSPLogService_AppendError_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string ErrorStr = "Testing";

            Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            CSSPLogService.AppendError(ErrorStr);
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.StartsWith(ErrorStr, CSSPLogService.sbError.ToString());
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
