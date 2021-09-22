using CSSPHelperModels;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPFileServices.Tests
{
    public partial class FileServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetAzureFileInfo_Good_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            var actionRes = await CSSPFileService.GetAzureFileInfo(ParentTVItemID, FileName);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            LocalFileInfo localFileInfoRet = ((LocalFileInfo)((OkObjectResult)actionRes.Result).Value);
            Assert.NotNull(localFileInfoRet);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetAzureFileInfo_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            LoggedInService.LoggedInContactInfo = null;

            var actionRes = await CSSPFileService.GetAzureFileInfo(ParentTVItemID, FileName);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetAzureFileInfo_ParentTVItemIDNotFound_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int ParentTVItemID = 111111111;
            string FileName = "BarTopBottom.png";

            var actionRes = await CSSPFileService.GetAzureFileInfo(ParentTVItemID, FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetAzureFileInfo_FileDoesNotExist_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int ParentTVItemID = 1;
            string FileName = "NotExist.png";

            var actionRes = await CSSPFileService.GetAzureFileInfo(ParentTVItemID, FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory(Skip = "Will need to rewrite this one")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetAzureFileInfo_AzureStore_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            //config.AzureStore = "notgood" + config.AzureStore;

            var actionRes = await CSSPFileService.GetAzureFileInfo(ParentTVItemID, FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory(Skip = "Will need to rewrite this one")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetAzureFileInfo_AzureStoreCSSPFilesPath_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            //config.AzureStoreCSSPFilesPath = "notgood" + config.AzureStoreCSSPFilesPath;

            var actionRes = await CSSPFileService.GetAzureFileInfo(ParentTVItemID, FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
