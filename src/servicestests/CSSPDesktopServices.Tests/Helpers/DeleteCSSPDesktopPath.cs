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
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CSSPDesktopServices.Tests
{
    public partial class CSSPDesktopServiceTests
    {
        private void DeleteCSSPDesktopPath()
        {
            DirectoryInfo di = new DirectoryInfo(Configuration["CSSPDesktopPath"]);
            if (di.Exists)
            {
                try
                {
                    di.Delete(true);
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }
        }
    }
}
