using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;

namespace CSSPCreateGzFileServices.Tests
{
    public partial class CSSPCreateGzFileServiceTests
    {
        private void SetVar(WebTypeEnum webTypeEnum)
        {
            CSSPLogService.CSSPAppName = "AppNameTest";
            CSSPLogService.CSSPCommandName = "CommandNameTest";

            WriteTimeSpan(webTypeEnum);
        }
    }
}
