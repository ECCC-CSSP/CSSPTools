using System.Threading.Tasks;
using Xunit;

namespace UpdateServices.Tests
{
    public partial class UpdateServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task UpdateService_UploadChangedFilesToAzure_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            bool retBool = await CSSPUpdateService.UploadChangedFilesToAzure();
            Assert.True(retBool);
        }
    }
}
