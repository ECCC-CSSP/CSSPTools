using System.Threading.Tasks;
using Xunit;

namespace CreateGzFileServices.Tests
{
    public partial class CreateGzFileServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Constructor_Good_Test(string culture)
        {
            Assert.True(await CSSPCreateGzFileServiceSetup(culture));

            Assert.NotNull(Configuration);
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(enums);
            Assert.NotNull(CSSPScrambleService);
            Assert.NotNull(CSSPLogService);
            Assert.NotNull(CreateGzFileService);
            Assert.NotNull(CSSPLocalLoggedInService);
            Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
            Assert.NotNull(dbManage);
        }
    }
}
