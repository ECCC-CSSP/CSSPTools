using CSSPCultureServices.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPUpdate
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine($"{CSSPCultureUpdateRes.RunningCSSPUpdate} ...");

            List<string> AllowableCommandList = new List<string>()
            {
                "ClearOldUnnecessaryStats",
                "RemoveAzureDirectoriesNotFoundInTVFiles",
                "RemoveAzureFilesNotFoundInTVFiles",
                "RemoveLocalDirectoriesNotFoundInTVFiles",
                "RemoveLocalFilesNotFoundInTVFiles",
                "RemoveNationalBackupDirectoriesNotFoundInTVFiles",
                "RemoveNationalBackupFilesNotFoundInTVFiles",
                "RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile",
                "RemoveTVItemsNoAssociatedWithTVFiles",
                "UpdateAllTVItemStats",
                "UploadAllFilesToAzure",
                "UploadAllJsonFilesToAzure",
            };

            if (args.Count() != 1)
            {
                Console.WriteLine($"{CSSPCultureUpdateRes.AllowableCommandsAre}:");
                foreach (string s in AllowableCommandList)
                {
                    Console.WriteLine($"CSSPUpdate.exe {s}");
                }
            }
            else
            {
                Startup startup = new Startup();

                if (!await startup.Setup()) return;

                switch (args[0])
                {
                    case "ClearOldUnnecessaryStats":
                        await startup.CSSPUpdateService.ClearOldUnnecessaryStats();
                        break;
                    case "RemoveAzureDirectoriesNotFoundInTVFiles":
                        await startup.CSSPUpdateService.RemoveAzureDirectoriesNotFoundInTVFiles();
                        break;
                    case "RemoveAzureFilesNotFoundInTVFiles":
                        await startup.CSSPUpdateService.RemoveAzureFilesNotFoundInTVFiles();
                        break;
                    case "RemoveLocalDirectoriesNotFoundInTVFiles":
                        await startup.CSSPUpdateService.RemoveLocalDirectoriesNotFoundInTVFiles();
                        break;
                    case "RemoveLocalFilesNotFoundInTVFiles":
                        await startup.CSSPUpdateService.RemoveLocalFilesNotFoundInTVFiles();
                        break;
                    case "RemoveNationalBackupDirectoriesNotFoundInTVFiles":
                        await startup.CSSPUpdateService.RemoveNationalBackupDirectoriesNotFoundInTVFiles();
                        break;
                    case "RemoveNationalBackupFilesNotFoundInTVFiles":
                        await startup.CSSPUpdateService.RemoveNationalBackupFilesNotFoundInTVFiles();
                        break;
                    case "RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile":
                        await startup.CSSPUpdateService.RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile();
                        break;
                    case "RemoveTVItemsNoAssociatedWithTVFiles":
                        await startup.CSSPUpdateService.RemoveTVItemsNoAssociatedWithTVFiles();
                        break;
                    case "UpdateAllTVItemStats":
                        await startup.CSSPUpdateService.UpdateAllTVItemStats();
                        break;
                    case "UploadAllFilesToAzure":
                        await startup.CSSPUpdateService.UploadAllFilesToAzure();
                        break;
                    case "UploadAllJsonFilesToAzure":
                        await startup.CSSPUpdateService.UploadAllJsonFilesToAzure();
                        break;
                    default:
                        {
                            Console.WriteLine($"{CSSPCultureUpdateRes.AllowableCommandsAre}:");
                            foreach (string s in AllowableCommandList)
                            {
                                Console.WriteLine($"CSSPUpdate.exe {s}");
                            }
                        }
                        break;

                }
            }
        }
    }
}
