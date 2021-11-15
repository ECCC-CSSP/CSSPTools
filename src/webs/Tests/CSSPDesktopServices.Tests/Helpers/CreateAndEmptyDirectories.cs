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

namespace CSSPDesktopServices.Tests
{
    public partial class CSSPDesktopServiceTests
    {
        private void CreateAndEmptyDirectories()
        {
            foreach(string dir in dirList)
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (!di.Exists)
                {
                    try
                    {
                        di.Create();
                    }
                    catch (Exception ex)
                    {
                        Assert.True(false, ex.Message);
                    }
                }
                else
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                }

                di = new DirectoryInfo(dir);
                Assert.True(di.Exists);
                Assert.Empty(di.GetFiles());
            }
        }
    }
}
