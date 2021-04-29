/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPDBPreferenceModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPScrambleServices;
using CSSPWebModels;
using LoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task TestDelete(PostTVItemModel postTVItemModel)
        {
            var actionDeleteTVItemModelRes = await PostTVItemModelService.DeleteLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionDeleteTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDeleteTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionDeleteTVItemModelRes.Result).Value;
            Assert.True(boolRet);
        }
    }
}
