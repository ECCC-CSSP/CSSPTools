using System.Threading.Tasks;
using Xunit;

namespace CSSPLogServices.Tests
{
    public partial class CSSPLogServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FillConfigModel_Good_Test(string culture)
        {
            Assert.True(await CSSPLogServiceSetup(culture));

            Assert.True(CSSPLogService.FillConfigModel(config));

        }
    }
}
