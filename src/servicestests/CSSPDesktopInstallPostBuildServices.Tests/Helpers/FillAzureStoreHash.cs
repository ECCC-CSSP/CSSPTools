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

namespace CSSPDesktopInstallPostBuildServices.Tests
{
    public partial class CSSPDesktopInstallPostBuildServiceTests
    {
        private void FillAzureStoreHash()
        {
            //CSSPLocalLoggedInService.SetLoggedInContactInfo();
            //Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
            //Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);

            //AzureStoreHash = (from c in dbManage.Contacts
            //                         where c.ContactID == CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactID
            //                         select c.AzureStoreHash).FirstOrDefault();

            //Assert.NotNull(AzureStoreHash);
        }
    }
}
