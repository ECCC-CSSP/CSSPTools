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
namespace CSSPAzureLoginServices.Tests
{
    public partial class CSSPAzureLoginServiceTests
    {
        private void CheckRequiredDirectories()
        {
            List<string> dirList = new List<string>()
            {
                Configuration["CSSPDBManage"],
            };

            // create all directories
            foreach (string FileName in dirList)
            {
                FileInfo fi = new FileInfo(FileName);
                DirectoryInfo di = new DirectoryInfo(fi.DirectoryName);
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
            }

            foreach (string FileName in dirList)
            {
                FileInfo fi = new FileInfo(FileName);
                DirectoryInfo di = new DirectoryInfo(fi.DirectoryName);
                Assert.True(di.Exists);

            }
        }
    }
}
