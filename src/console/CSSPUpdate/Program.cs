using CSSPCultureServices.Resources;
using CSSPEnums;
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
            Startup startup = new Startup();

            if (!await startup.Setup()) return;

            Console.WriteLine($"{CSSPCultureUpdateRes.RunningCSSPUpdate} ...");

            List<string> AllowableCSSPCommandNameList = new List<string>()
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
                "UpdateChangedTVItemStats",
                "UploadAllFilesToAzure",
                "UploadAllJsonFilesToAzure",
                "UploadChangedFilesToAzure",
                "UploadChangedJsonFilesToAzure",
            };

            if (args.Count() != 1)
            {
                Console.WriteLine($"{CSSPCultureUpdateRes.AllowableCommandsAre}:");
                foreach (string CSSPCommandName in AllowableCSSPCommandNameList)
                {
                    Console.WriteLine($"CSSPUpdate.exe {CSSPCommandName}");
                }
            }
            else
            {
                string CSSPCommandName = "Unknown";

                foreach (string CSSPCommandNameToFind in AllowableCSSPCommandNameList)
                {
                    if (args[0] == CSSPCommandNameToFind.ToString())
                    {
                        CSSPCommandName = CSSPCommandNameToFind;
                        break;
                    }
                }
                 
                switch (CSSPCommandName)
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
                    case "UpdateChangedTVItemStats":
                        await startup.CSSPUpdateService.UpdateChangedTVItemStats();
                        break;
                    case "UploadAllFilesToAzure":
                        await startup.CSSPUpdateService.UploadAllFilesToAzure();
                        break;
                    case "UploadAllJsonFilesToAzure":
                        await startup.CSSPUpdateService.UploadAllJsonFilesToAzure();
                        break;
                    case "UploadChangedFilesToAzure":
                        await startup.CSSPUpdateService.UploadChangedFilesToAzure();
                        break;
                    case "UploadChangedJsonFilesToAzure":
                        await startup.CSSPUpdateService.UploadChangedJsonFilesToAzure();
                        break;
                    default:
                        {
                            Console.WriteLine($"{CSSPCultureUpdateRes.AllowableCommandsAre}:");
                            foreach (string CSSPCommandNameItem in AllowableCSSPCommandNameList)
                            {
                                Console.WriteLine($"CSSPUpdate.exe {CSSPCommandNameItem}");
                            }
                        }
                        break;

                }
            }
        }
    }
}
