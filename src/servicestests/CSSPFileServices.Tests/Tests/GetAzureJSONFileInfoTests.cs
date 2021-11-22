using CSSPEnums;
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
        public async Task GetAzureJSONFileInfo_Good_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            var actionRes = await CSSPFileService.GetAzureJSONFileInfo(FileName);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            LocalFileInfo localFileInfoRet = ((LocalFileInfo)((OkObjectResult)actionRes.Result).Value);
            Assert.NotNull(localFileInfoRet);

            await CSSPLogService.Save();

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetAzureJSONFileInfo_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            CSSPLocalLoggedInService.LoggedInContactInfo = null;

            var actionRes = await CSSPFileService.GetAzureJSONFileInfo(FileName);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            await CSSPLogService.Save();

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetAzureJSONFileInfo_ParentTVItemIDNotFound_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            var actionRes = await CSSPFileService.GetAzureJSONFileInfo(FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            await CSSPLogService.Save();

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetAzureJSONFileInfo_FileDoesNotExist_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            var actionRes = await CSSPFileService.GetAzureJSONFileInfo(FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            await CSSPLogService.Save();

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory(Skip = "Will need to rewrite this one")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetAzureJSONFileInfo_AzureStore_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            var actionRes = await CSSPFileService.GetAzureJSONFileInfo(FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            await CSSPLogService.Save();

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory(Skip = "Will need to rewrite this one")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetAzureJSONFileInfo_AzureStoreCSSPFilesPath_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            var actionRes = await CSSPFileService.GetAzureJSONFileInfo(FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            await CSSPLogService.Save();

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
