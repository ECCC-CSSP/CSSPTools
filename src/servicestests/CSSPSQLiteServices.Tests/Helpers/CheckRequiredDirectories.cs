﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CSSPSQLiteServices.Tests
{
    public partial class CSSPSQLiteServiceTests
    {
        private void CheckRequiredDirectories()
        {
            List<string> dirList = new List<string>()
            {
                Configuration["CSSPDBLocal"],
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

            foreach(string FileName in dirList)
            {
                FileInfo fi = new FileInfo(FileName);
                DirectoryInfo di = new DirectoryInfo(fi.DirectoryName);
                Assert.True(di.Exists);

            }
        }
    }
}
