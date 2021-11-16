using CSSPCultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        public async Task<bool> RunCommand(string[] args)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(string[] args) -- { string.Join("  ", args) }";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(false);

            List<string> AllowableCSSPCommandNameFor1ArgsList = new List<string>()
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

            List<string> AllowableCSSPCommandNameFor4ArgsList = new List<string>()
            {
                "UpdateChangedTVItemStats",
                "UploadChangedFilesToAzure",
                "UploadChangedJsonFilesToAzure",
            };

            if (args.Count() == 1)
            {
                CSSPLogService.CSSPCommandName = "Unknown";

                foreach (string CSSPCommandNameToFind in AllowableCSSPCommandNameFor1ArgsList)
                {
                    if (args[0] == CSSPCommandNameToFind.ToString())
                    {
                        CSSPLogService.CSSPCommandName = CSSPCommandNameToFind;
                        break;
                    }
                }

                switch (CSSPLogService.CSSPCommandName)
                {
                    case "ClearOldUnnecessaryStats":
                        await ClearOldUnnecessaryStats();
                        break;
                    case "RemoveAzureDirectoriesNotFoundInTVFiles":
                        await RemoveAzureDirectoriesNotFoundInTVFiles();
                        break;
                    case "RemoveAzureFilesNotFoundInTVFiles":
                        await RemoveAzureFilesNotFoundInTVFiles();
                        break;
                    case "RemoveLocalDirectoriesNotFoundInTVFiles":
                        await RemoveLocalDirectoriesNotFoundInTVFiles();
                        break;
                    case "RemoveLocalFilesNotFoundInTVFiles":
                        await RemoveLocalFilesNotFoundInTVFiles();
                        break;
                    case "RemoveNationalBackupDirectoriesNotFoundInTVFiles":
                        await RemoveNationalBackupDirectoriesNotFoundInTVFiles();
                        break;
                    case "RemoveNationalBackupFilesNotFoundInTVFiles":
                        await RemoveNationalBackupFilesNotFoundInTVFiles();
                        break;
                    case "RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile":
                        await RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile();
                        break;
                    case "RemoveTVItemsNoAssociatedWithTVFiles":
                        await RemoveTVItemsNoAssociatedWithTVFiles();
                        break;
                    case "UpdateAllTVItemStats":
                        await UpdateAllTVItemStats();
                        break;
                    case "UploadAllFilesToAzure":
                        await UploadAllFilesToAzure();
                        break;
                    case "UploadAllJsonFilesToAzure":
                        await UploadAllJsonFilesToAzure();
                        break;
                    default:
                        {
                            return await LogError1ArgsReturnFalse(AllowableCSSPCommandNameFor1ArgsList, FunctionName);
                        }

                }
            }
            else if (args.Count() == 4)
            {
                CSSPLogService.CSSPCommandName = "Unknown";

                foreach (string CSSPCommandNameToFind in AllowableCSSPCommandNameFor4ArgsList)
                {
                    if (args[0] == CSSPCommandNameToFind.ToString())
                    {
                        CSSPLogService.CSSPCommandName = CSSPCommandNameToFind;
                        break;
                    }
                }

                switch (CSSPLogService.CSSPCommandName)
                {
                    case "UpdateChangedTVItemStats":
                    case "UploadChangedFilesToAzure":
                    case "UploadChangedJsonFilesToAzure":
                        // only these commands required the yyyy MM dd args structure
                        break;
                    default:
                        {
                            return await LogError4ArgsReturnFalse(AllowableCSSPCommandNameFor4ArgsList, FunctionName);
                        }

                }

                int Year = int.Parse(args[1]);

                if (Year < 2000 || Year > DateTime.Now.Year + 1)
                {
                    return await LogError4ArgsDateReturnFalse(FunctionName);
                }

                int Month = int.Parse(args[2]);

                if (Month < 1 || Month > 12)
                {
                    return await LogError4ArgsDateReturnFalse(FunctionName);
                }

                int Day = int.Parse(args[3]);
                if (Day < 1 || Day > 31)
                {
                    return await LogError4ArgsDateReturnFalse(FunctionName);
                }

                DateTime UpdateFromDate;
                try
                {
                    UpdateFromDate = new DateTime(Year, Month, Day);
                }
                catch (Exception ex)
                {
                    string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                    CSSPLogService.AppendError($"{ ex.Message } { inner }");

                    return await Task.FromResult(false);
                }

                if (UpdateFromDate > DateTime.Now)
                {
                    return await LogError4ArgsDateReturnFalse(FunctionName);
                }

                switch (CSSPLogService.CSSPCommandName)
                {
                    case "UpdateChangedTVItemStats":
                        await UpdateChangedTVItemStats(UpdateFromDate);
                        break;
                    case "UploadChangedFilesToAzure":
                        await UploadChangedFilesToAzure(UpdateFromDate);
                        break;
                    case "UploadChangedJsonFilesToAzure":
                        await UploadChangedJsonFilesToAzure(UpdateFromDate);
                        break;
                    default:
                        {
                            return await LogError4ArgsReturnFalse(AllowableCSSPCommandNameFor4ArgsList, FunctionName);
                        }

                }
            }
            else
            {
                CSSPLogService.AppendError($"{CSSPCultureServicesRes.AllowableCommandsAre}:");
                foreach (string CSSPCommandNameItem in AllowableCSSPCommandNameFor1ArgsList)
                {
                    CSSPLogService.AppendError($"CSSPUpdate.exe {CSSPCommandNameItem}");
                }

                Console.WriteLine($"{CSSPCultureServicesRes.AllowableCommandsAre}:");
                foreach (string CSSPCommandName in AllowableCSSPCommandNameFor1ArgsList)
                {
                    CSSPLogService.AppendError($"CSSPUpdate.exe { CSSPCommandName } yyyy MM dd");
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);            

            return await Task.FromResult(true);
        }
    }
}
