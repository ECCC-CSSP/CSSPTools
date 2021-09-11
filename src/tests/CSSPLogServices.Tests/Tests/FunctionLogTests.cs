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
        public async Task FunctionLog_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string ThisFunction = "ThisFunction";
            
            CSSPLogService.FunctionLog(ThisFunction);
            
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
            Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
