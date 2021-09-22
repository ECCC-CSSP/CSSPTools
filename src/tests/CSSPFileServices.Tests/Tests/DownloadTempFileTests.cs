using CSSPHelperModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPFileServices.Tests
{
    //[Collection("Sequential")]
    public partial class FileServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadTempFile_Good_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            FileInfo fi = new FileInfo($@"{ Configuration["CSSPTempFilesPath"] }\\ThisFileShoulBeUnique743Testing.txt");

            if (fi.Exists)
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            File.WriteAllText(fi.FullName, "bonjour");
            
            var actionRes = await CSSPFileService.DownloadTempFile(fi.Name);
            Assert.NotNull(((PhysicalFileResult)actionRes).FileName);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadTempFile_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            FileInfo fi = new FileInfo($@"{ Configuration["CSSPTempFilesPath"] }\\ThisFileShoulBeUnique743Testing.txt");

            File.WriteAllText(fi.FullName, "bonjour");

            LoggedInService.LoggedInContactInfo = null;

            var actionRes = await CSSPFileService.DownloadTempFile(fi.Name);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
            ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadTempFile_FileDoesNotExist_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            string FileName = "doesnotexist.css";

            var actionRes = await CSSPFileService.DownloadTempFile(FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
