using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace UpdateServices.Tests
{
    public partial class UpdateServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile_Good_Test(string culture)
        {
            Assert.True(await CSSPUpdateServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            CSSPLogService.CSSPAppName = "AppNameTest";
            CSSPLogService.CSSPCommandName = "CommandNameTest";

            var actionRes = await CSSPUpdateService.RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);

            await CSSPLogService.Save();

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
