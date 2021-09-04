using CSSPEnums;
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
        public async Task CSSPLogService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(LoggedInService);
            Assert.NotNull(LoggedInService.LoggedInContactInfo);
            Assert.NotNull(dbManage);
            Assert.NotNull(CSSPLogService);
            Assert.Equal("Unknown", CSSPLogService.CSSPAppName);
            Assert.Equal("Unknown", CSSPLogService.CSSPCommandName);
            Assert.Equal("", CSSPLogService.sbError.ToString());
            Assert.Equal("", CSSPLogService.sbLog.ToString());
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
