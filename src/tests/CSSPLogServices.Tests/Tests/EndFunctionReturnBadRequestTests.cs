using ManageServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using CSSPEnums;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using CSSPLogServices.Models;
using CSSPHelperModels;

namespace CSSPLogServices.Tests
{
    public partial class CSSPLogServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EndFunctionReturnBadRequest_Good_Test(string culture)
        {
            Assert.True(await CSSPLogServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            string ThisFunction = "ThisFunction";
            string ErrorText = "Error Text";

            var actionRes = await CSSPLogService.EndFunctionReturnBadRequest(ThisFunction, ErrorText);

            Assert.Equal(400, ((BadRequestObjectResult)actionRes).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            
            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
