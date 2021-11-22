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
using Azure.Storage.Files.Shares;
using Azure;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace CSSPFileServices.Tests
{
    public partial class FileServiceTests
    {
        private void DeleteAllOtherFilesLocal()
        {
            DirectoryInfo di = new DirectoryInfo(Configuration["CSSPOtherFilesPath"]);
            Assert.True(di.Exists);

            foreach(FileInfo fi in di.GetFiles())
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            Assert.Empty(di.GetFiles());
        }
    }
}
