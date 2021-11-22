using System.Threading.Tasks;
using Xunit;

namespace CSSPReadGzFileServices.Tests
{
    public partial class CSSPReadGzFileServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Constructor_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));
        }
    }
}
