using System.Threading.Tasks;
using Xunit;

namespace UpdateServices.Tests
{
    [Collection("Sequential")]
    public partial class UpdateServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Constructor_Good_Test(string culture)
        {
            Assert.True(await CSSPUpdateServiceSetup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(enums);
            Assert.NotNull(CSSPLogService);
            Assert.NotNull(CSSPLocalLoggedInService);
            Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
            Assert.NotNull(CreateGzFileService);
            Assert.NotNull(CSSPUpdateService);
            Assert.NotNull(db);
            Assert.NotNull(dbManage);
        }
    }
}
