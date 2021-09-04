using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;

namespace CreateGzFileServices.Tests
{
    public partial class CreateGzFileServiceTests
    {
        private void SetVar(WebTypeEnum webTypeEnum)
        {
            CSSPLogService.CSSPAppName = "AppNameTest";
            CSSPLogService.CSSPCommandName = "CommandNameTest";

            WriteTimeSpan(webTypeEnum);
        }
    }
}
