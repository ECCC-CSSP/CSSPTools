using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace UpdateServices.Tests
{
    public partial class UpdateServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task UpdateService_UploadAllJsonFilesToAzure_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPUpdateService.UploadAllJsonFilesToAzure();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        }
    }
}
