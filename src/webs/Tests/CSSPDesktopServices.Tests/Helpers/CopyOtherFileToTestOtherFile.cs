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
        private async Task CopyOtherFileToTestOtherFile()
        {

            foreach(string fileName in await GetCSSPOtherFileListAsync())
            {
                try
                {
                    File.Copy(fileName.Replace("test", ""), fileName);
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            foreach (string fileName in await GetCSSPOtherFileListAsync())
            {
                FileInfo fi = new FileInfo(fileName);

                Assert.True(fi.Exists);
            }
        }
    }
}
