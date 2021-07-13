using Azure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files;
using Azure.Storage.Files.Shares.Models;

namespace UploadAllFilesToAzure
{
    class Program
    {
        static void Main(string[] args)
        {
            //int CountFileTotal = 0;
            //int CountFileUploaded = 0;

            Console.WriteLine("Hello World!");

            Startup startup = new Startup();

            if (!startup.Setup()) return;

            startup.RemoveTVItemsNoAssociatedWithTVFiles();
            startup.RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile();
            startup.RemoveFilesNotFoundInTVFiles($@"E:\inetpub\wwwroot\csspwebtools\App_Data\", $@"\\int.ec.gc.ca\SHARES\M\MQEM_NATIONAL\Charles_E_Drive_Backup\inetpub\wwwroot\csspwebtools\App_Data\");
            startup.RemoveDirectoriesNotFoundInTVFiles($@"E:\inetpub\wwwroot\csspwebtools\App_Data\", $@"\\int.ec.gc.ca\SHARES\M\MQEM_NATIONAL\Charles_E_Drive_Backup\inetpub\wwwroot\csspwebtools\App_Data\");

        }
    }
}
