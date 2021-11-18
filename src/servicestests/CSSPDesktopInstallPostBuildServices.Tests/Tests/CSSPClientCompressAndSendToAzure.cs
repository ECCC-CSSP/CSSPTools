using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CSSPCultureServices.Services;
using CSSPDesktopInstallPostBuildServices.Services;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using CSSPHelperModels;
using Azure.Storage.Files.Shares;
using Azure;

namespace CSSPDesktopInstallPostBuildServices.Tests
{
    public partial class CSSPDesktopInstallPostBuildServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPClientCompressAndSendToAzure_Good_Test(string culture)
        {
            Assert.True(await CSSPDesktopInstallPostBuildServiceSetup(culture));

            string fileName = Configuration["CSSPClientZipFile"];

            FileInfo fi = new FileInfo(fileName);
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

            fi = new FileInfo(fileName);
            Assert.False(fi.Exists);

            bool retBool = await CSSPDesktopInstallPostBuildService.LoginAsync();
            Assert.True(retBool);

            ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPDesktopInstallPostBuildService.AzureStoreHash), Configuration["AzureStoreCSSPWebAPIsLocalPath"]);
            Assert.NotNull(shareClient);

            ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
            Assert.NotNull(directory);

            ShareFileClient shareFileClient = directory.GetFileClient(fi.Name);
            Assert.NotNull(shareFileClient);

            if (await shareFileClient.ExistsAsync())
            {
                try
                {
                    await shareFileClient.DeleteAsync();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            Assert.False(await shareFileClient.ExistsAsync());

            retBool = await CSSPDesktopInstallPostBuildService.CSSPClientCompressAndSendToAzureAsync();
            Assert.True(retBool);

            Assert.True(await shareFileClient.ExistsAsync());

            fi = new FileInfo(fileName);
            Assert.True(fi.Exists);
        }
    }
}
