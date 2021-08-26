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

            List<CSSPCommandNameEnum> AllowableCSSPCommandNameList = new List<CSSPCommandNameEnum>()
            {
                CSSPCommandNameEnum.ClearOldUnnecessaryStats,
                CSSPCommandNameEnum.RemoveAzureDirectoriesNotFoundInTVFiles,
                CSSPCommandNameEnum.RemoveAzureFilesNotFoundInTVFiles,
                CSSPCommandNameEnum.RemoveLocalDirectoriesNotFoundInTVFiles,
                CSSPCommandNameEnum.RemoveLocalFilesNotFoundInTVFiles,
                CSSPCommandNameEnum.RemoveNationalBackupDirectoriesNotFoundInTVFiles,
                CSSPCommandNameEnum.RemoveNationalBackupFilesNotFoundInTVFiles,
                CSSPCommandNameEnum.RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile,
                CSSPCommandNameEnum.RemoveTVItemsNoAssociatedWithTVFiles,
                CSSPCommandNameEnum.UpdateAllTVItemStats,
                CSSPCommandNameEnum.UpdateChangedTVItemStats,
                CSSPCommandNameEnum.UploadAllFilesToAzure,
                CSSPCommandNameEnum.UploadAllJsonFilesToAzure,
                CSSPCommandNameEnum.UploadChangedFilesToAzure,
                CSSPCommandNameEnum.UploadChangedJsonFilesToAzure,
            };

            if (args.Count() != 1)
            {
                Console.WriteLine($"{CSSPCultureUpdateRes.AllowableCommandsAre}:");
                foreach (CSSPCommandNameEnum CSSPCommandName in AllowableCSSPCommandNameList)
                {
                    Console.WriteLine($"CSSPUpdate.exe {CSSPCommandName}");
                }
            }
            else
            {
                CSSPCommandNameEnum CSSPCommandName = (CSSPCommandNameEnum)0;

                foreach (CSSPCommandNameEnum CSSPCommandNameToFind in AllowableCSSPCommandNameList)
                {
                    if (args[0] == CSSPCommandNameToFind.ToString())
                    {
                        CSSPCommandName = CSSPCommandNameToFind;
                        break;
                    }
                }
                 
                switch (CSSPCommandName)
                {
                    case CSSPCommandNameEnum.ClearOldUnnecessaryStats:
                        await startup.CSSPUpdateService.ClearOldUnnecessaryStats();
                        break;
                    case CSSPCommandNameEnum.RemoveAzureDirectoriesNotFoundInTVFiles:
                        await startup.CSSPUpdateService.RemoveAzureDirectoriesNotFoundInTVFiles();
                        break;
                    case CSSPCommandNameEnum.RemoveAzureFilesNotFoundInTVFiles:
                        await startup.CSSPUpdateService.RemoveAzureFilesNotFoundInTVFiles();
                        break;
                    case CSSPCommandNameEnum.RemoveLocalDirectoriesNotFoundInTVFiles:
                        await startup.CSSPUpdateService.RemoveLocalDirectoriesNotFoundInTVFiles();
                        break;
                    case CSSPCommandNameEnum.RemoveLocalFilesNotFoundInTVFiles:
                        await startup.CSSPUpdateService.RemoveLocalFilesNotFoundInTVFiles();
                        break;
                    case CSSPCommandNameEnum.RemoveNationalBackupDirectoriesNotFoundInTVFiles:
                        await startup.CSSPUpdateService.RemoveNationalBackupDirectoriesNotFoundInTVFiles();
                        break;
                    case CSSPCommandNameEnum.RemoveNationalBackupFilesNotFoundInTVFiles:
                        await startup.CSSPUpdateService.RemoveNationalBackupFilesNotFoundInTVFiles();
                        break;
                    case CSSPCommandNameEnum.RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile:
                        await startup.CSSPUpdateService.RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile();
                        break;
                    case CSSPCommandNameEnum.RemoveTVItemsNoAssociatedWithTVFiles:
                        await startup.CSSPUpdateService.RemoveTVItemsNoAssociatedWithTVFiles();
                        break;
                    case CSSPCommandNameEnum.UpdateAllTVItemStats:
                        await startup.CSSPUpdateService.UpdateAllTVItemStats();
                        break;
                    case CSSPCommandNameEnum.UpdateChangedTVItemStats:
                        await startup.CSSPUpdateService.UpdateChangedTVItemStats();
                        break;
                    case CSSPCommandNameEnum.UploadAllFilesToAzure:
                        await startup.CSSPUpdateService.UploadAllFilesToAzure();
                        break;
                    case CSSPCommandNameEnum.UploadAllJsonFilesToAzure:
                        await startup.CSSPUpdateService.UploadAllJsonFilesToAzure();
                        break;
                    case CSSPCommandNameEnum.UploadChangedFilesToAzure:
                        await startup.CSSPUpdateService.UploadChangedFilesToAzure();
                        break;
                    case CSSPCommandNameEnum.UploadChangedJsonFilesToAzure:
                        await startup.CSSPUpdateService.UploadChangedJsonFilesToAzure();
                        break;
                    default:
                        {
                            Console.WriteLine($"{CSSPCultureUpdateRes.AllowableCommandsAre}:");
                            foreach (CSSPCommandNameEnum CSSPCommandNameItem in AllowableCSSPCommandNameList)
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
