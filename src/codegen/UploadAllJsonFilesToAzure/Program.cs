using Azure;
using CreateGzFileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UploadAllJsonFilesToAzure
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Startup startup = new Startup();

            if (!startup.Setup()) return;

            //await startup.CreateGzFileService.CreateAllGzFiles();
            await startup.CreateGzFileService.CreateAllGzFiles();
        }
    }
}
