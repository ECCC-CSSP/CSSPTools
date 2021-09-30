using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace CSSPLogServices.Tests
{
    public partial class CSSPLogServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CheckComputerName_Good_Test(string culture)
        {
            Assert.True(await CSSPLogServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            string FunctionName = "TheFunctionName";

            Assert.True(await CSSPLogService.CheckComputerName(FunctionName));

            Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
            Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
