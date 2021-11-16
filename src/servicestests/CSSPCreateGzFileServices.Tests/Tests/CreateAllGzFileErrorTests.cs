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
using CSSPHelperModels;
using CSSPCultureServices.Resources;

namespace CSSPCreateGzFileServices.Tests
{
    public partial class CSSPCreateGzFileServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateAllGzFiles_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await CSSPCreateGzFileServiceSetup(culture));

            CSSPLocalLoggedInService.LoggedInContactInfo = null;

            var actionRes = await CreateGzFileService.CreateAllGzFilesAsync();
            Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
        }
    }
}
