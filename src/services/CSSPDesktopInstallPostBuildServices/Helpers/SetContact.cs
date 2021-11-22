using Azure.Storage.Blobs;
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPHelperModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPDesktopInstallPostBuildServices.Services
{
    public partial class CSSPDesktopInstallPostBuildService : ICSSPDesktopInstallPostBuildService
    {
        public void SetContact(Contact contact)
        {
            this.contact = contact;
        }
    }
}
