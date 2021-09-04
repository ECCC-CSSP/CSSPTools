using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;
using System.Collections.Generic;
using ManageServices;
using System.Linq;

namespace CreateGzFileServices.Tests
{
    public partial class CreateGzFileServiceTests
    {
        private void CheckVar(ActionResult<bool> actionRes, WebTypeEnum webTypeEnum)
        {
            WriteTimeSpan(webTypeEnum);

            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                               where c.AppName == CSSPLogService.CSSPAppName
                                               && c.CommandName == CSSPLogService.CSSPCommandName
                                               select c).ToList();

            Assert.True(commandLogList.Count == 1);
            WriteTimeSpan(webTypeEnum);
        }
    }
}
