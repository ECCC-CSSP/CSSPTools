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
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CheckComputerName_Error_Test(string culture)
        {
            Assert.True(await CSSPLogServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            string FunctionName = "TheFunctionName";

            config.ComputerName = "notExist";

            CSSPLogService.FillConfigModel(config);

            Assert.False(await CSSPLogService.CheckComputerName(FunctionName));

            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.Contains(config.ComputerName, CSSPLogService.sbError.ToString());

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
