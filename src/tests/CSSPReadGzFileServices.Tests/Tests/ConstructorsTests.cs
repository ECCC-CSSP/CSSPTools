using System.Threading.Tasks;
using Xunit;

namespace ReadGzFileServices.Tests
{
    public partial class ReadGzFileServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Constructor_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            Assert.NotNull(Configuration);
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(LoggedInService);
            Assert.NotNull(LoggedInService.LoggedInContactInfo);
            Assert.NotNull(CSSPLogService);
            Assert.NotNull(ManageFileService);
            Assert.NotNull(ReadGzFileService);
            Assert.NotNull(CSSPFileService);
        }
    }
}
