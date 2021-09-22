using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using CSSPWebModels;
using System.Collections.Generic;

namespace CSSPFileServices.Tests
{
    public partial class FileServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Constructor_Good_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.NotNull(Configuration);
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(ManageFileService);
            Assert.NotNull(CSSPFileService);
            Assert.NotNull(LoggedInService);
            Assert.NotNull(LoggedInService.LoggedInContactInfo);
            Assert.NotNull(CSSPLogService);
            Assert.NotNull(dbManage);

            DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPath"]);
            Assert.True(di.Exists);

            di = new DirectoryInfo(Configuration["CSSPFilesPath"]);
            Assert.True(di.Exists);

            di = new DirectoryInfo(Configuration["CSSPTempFilesPath"]);
            Assert.True(di.Exists);

            di = new DirectoryInfo(Configuration["CSSPOtherFilesPath"]);
            Assert.True(di.Exists);
        }
    }
}
