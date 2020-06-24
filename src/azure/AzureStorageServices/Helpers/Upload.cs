using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AzureStorageServices.Services
{
    public partial class AzureStorageService : IAzureStorageService
    {
        private async Task<bool> Upload()
        {
            return await Task.FromResult(true);
        }
    }
}
