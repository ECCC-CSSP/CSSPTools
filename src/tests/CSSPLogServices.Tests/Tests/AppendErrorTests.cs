using CSSPCultureServices.Resources;
using System.ComponentModel.DataAnnotations;
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
        public async Task AppendError_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            string ErrorStr = "Testing";

            CSSPLogService.AppendError(new ValidationResult(ErrorStr, new[] { "" }));

            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.StartsWith($"{ CSSPCultureServicesRes.ERRORCap}: {ErrorStr}", CSSPLogService.sbError.ToString());

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
