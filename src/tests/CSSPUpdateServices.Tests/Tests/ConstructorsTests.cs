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
        public async Task UpdateService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(LoggedInService);
            Assert.NotNull(LoggedInService.LoggedInContactInfo);
            Assert.NotNull(CreateGzFileService);
            Assert.NotNull(AzureStore);
            Assert.NotNull(AzureStoreCSSPFilesPath);
            Assert.NotNull(AzureStoreCSSPJSONPath);
            Assert.NotNull(db);
            Assert.NotNull(dbManage);
            Assert.NotNull(CSSPUpdateService);
        }
    }
}
