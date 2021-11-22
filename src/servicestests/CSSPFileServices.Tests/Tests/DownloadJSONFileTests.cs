using CSSPEnums;
using CSSPHelperModels;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
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
        public async Task DownloadJSONFile_Good_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            FileInfo fi = new FileInfo($@"{ Configuration["CSSPJSONPath"] }{FileName}");
            Assert.True(fi.Exists);

            var actionRes2 = await CSSPFileService.DownloadJSONFile(FileName);
            Assert.NotNull(((PhysicalFileResult)actionRes2).FileName);

            await CSSPLogService.Save();

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadJSONFile_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPath"] }{FileName}");
            Assert.True(fi.Exists);

            CSSPLocalLoggedInService.LoggedInContactInfo = null;

            var actionRes = await CSSPFileService.DownloadJSONFile(FileName);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
            ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes).Value;
            Assert.NotEmpty(errRes.ErrList);

            await CSSPLogService.Save();

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadJSONFile_FileNotExist_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPFilesPath"] }{FileName}");
            Assert.False(fi.Exists);

            var actionRes = await CSSPFileService.DownloadJSONFile(FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes).Value;
            Assert.NotEmpty(errRes.ErrList);

            await CSSPLogService.Save();

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
