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
        public async Task BadConfigFile_Error_Test(string culture)
        {
            Assert.True(await CSSPLogServiceSetup(culture, 2));
        }
    }
}
