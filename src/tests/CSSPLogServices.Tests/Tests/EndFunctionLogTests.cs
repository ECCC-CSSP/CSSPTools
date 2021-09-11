using ManageServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using CSSPEnums;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CSSPLogServices.Tests
{
    public partial class CSSPLogServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EndFunctionLog_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            string ThisFunction = "ThisFunction";

            CSSPLogService.EndFunctionLog(ThisFunction);

            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
            Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.Equal("CSSPLogService_AppName", CSSPLogService.CSSPAppName);
            Assert.Equal("CSSPLogService_CommandName", CSSPLogService.CSSPCommandName);

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
