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
        public async Task CSSPLogService_AppendLog_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string LogStr = "Testing";

            Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
            CSSPLogService.AppendLog(LogStr);
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
            Assert.StartsWith(LogStr, CSSPLogService.sbLog.ToString());
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
