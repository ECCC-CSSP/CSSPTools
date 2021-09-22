using System.Threading.Tasks;
using Xunit;

namespace ManageServices.Tests
{
    public partial class ManageServicesTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Constructor_Good_Test(string culture)
        {
            Assert.True(await CSSPDBManageServiceSetup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(CommandLogService);
            Assert.NotNull(ManageFileService);
            Assert.NotNull(dbManage);
        }
    }
}
