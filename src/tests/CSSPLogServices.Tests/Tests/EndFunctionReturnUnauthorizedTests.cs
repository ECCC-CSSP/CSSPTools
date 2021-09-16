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
        public async Task EndFunctionReturnUnauthorized_Good_Test(string culture)
        {
            Assert.True(await CSSPLogServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            string ThisFunction = "ThisFunction";
            string ErrorText = "Error Text";

            var actionRes = CSSPLogService.EndFunctionReturnUnauthorized(ThisFunction, ErrorText);

            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);

            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.Equal("CSSPLogService_AppName", CSSPLogService.CSSPAppName);
            Assert.Equal("CSSPLogService_CommandName", CSSPLogService.CSSPCommandName);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
