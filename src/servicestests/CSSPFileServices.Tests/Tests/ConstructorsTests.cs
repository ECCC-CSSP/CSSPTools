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
        }
    }
}
