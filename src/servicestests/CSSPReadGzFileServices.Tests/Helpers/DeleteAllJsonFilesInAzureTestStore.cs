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

namespace CSSPReadGzFileServices.Tests
{
    public partial class CSSPReadGzFileServiceTests
    {
        private void DeleteAllJsonFilesInAzureTestStore()
        {
            ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJSONPath"]);
            Assert.NotNull(shareClient);

            ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
            Assert.NotNull(directory);

            foreach (ShareFileItem shareFileItem in directory.GetFilesAndDirectories())
            {
                ShareFileClient file = directory.GetFileClient(shareFileItem.Name);
                Assert.NotNull(file);

                Response<bool> responseFile = file.DeleteIfExists();
                Assert.True(responseFile.Value);
            }

            Assert.Empty(directory.GetFilesAndDirectories());
        }
    }
}
