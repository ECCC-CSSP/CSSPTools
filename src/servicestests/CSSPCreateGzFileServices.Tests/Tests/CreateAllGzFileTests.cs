using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;
using System.Reflection;
using ManageServices;
using System.Collections.Generic;
using System.Linq;

namespace CSSPCreateGzFileServices.Tests
{
    public partial class CSSPCreateGzFileServiceTests
    {
        [Theory(Skip = "Skip as it takes a long time. Still wants a marker however")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateAllGzFile_Good_Test(string culture)
        {
            Assert.True(await CSSPCreateGzFileServiceSetup(culture));

            // commented out because it takes a long time to excecute
            // remove comment if you want to manually test it

            //SetVar(WebTypeEnum.WebAllAddresses);
            //var actionRes = await CreateGzFileService.CreateAllGzFiles();
            //CheckVar(actionRes, WebTypeEnum.WebAllAddresses);
        }
    }
}
