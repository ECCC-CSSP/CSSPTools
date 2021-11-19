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

namespace CSSPCreateGzFileServices.Tests
{
    public partial class CSSPCreateGzFileServiceTests
    {
        private void CheckRequiredDirectories()
        {
            List<string> FileList = new List<string>()
            {
                Configuration["CSSPDBLocal"],
                Configuration["CSSPDBManage"],
                Configuration["azure_csspjson_backup"],
                Configuration["azure_csspjson_backup_uncompress"],
                Configuration["CSSPJSONPathLocal"],
            };

            // create all directories
            foreach (string FileName in FileList)
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

            foreach (string FileName in FileList)
            {
                FileInfo fi = new FileInfo(FileName);
                DirectoryInfo di = new DirectoryInfo(fi.DirectoryName);
                Assert.True(di.Exists);

            }
        }
    }
}
