using CSSPCultureServices.Resources;
using CSSPHelperModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManageServices.Tests
{

    public partial class ManageFileServicesTests
    {
        private async Task<ManageFile> FillManageFileAsync()
        {
            return await Task.FromResult(new ManageFile()
            {
                ManageFileID = 0,
                AzureFileName = "TestingFileName",
                AzureETag = "ThisIsETag",
                AzureStorage = "StorageName",
                AzureCreationTimeUTC = DateTime.UtcNow,
                LoadedOnce = true,
            });
        }
    }
}
