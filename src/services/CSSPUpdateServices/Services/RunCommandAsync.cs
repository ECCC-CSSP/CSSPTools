namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<bool> RunCommandAsync(string[] args)
    {
        string FunctionName = $"{this.GetType().Name}.{CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name)}(string[] args) -- {string.Join("  ", args)}";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(false);

        if (Environment.MachineName.ToLower() != "wmon01dtchlebl2")
        {
            CSSPLogService.AppendError($"{CSSPCultureServicesRes.CanOnlyBeRunFromComputer_wmon01dtchlebl2}:");
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(true);
        }

        List<string> AllowableCSSPCommandNameFor1ArgsList = new List<string>()
        {
            "ClearOldUnnecessaryStats",
            "RemoveAzureDirectoriesNotFoundInTVFiles",
            "RemoveAzureFilesNotFoundInTVFiles",
            "RemoveExternalHardDriveDirectoriesNotFoundInTVFiles",
            "RemoveExternalHardDriveFilesNotFoundInTVFiles",
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
                    await ClearOldUnnecessaryStatsAsync();
                    break;
                case "RemoveAzureDirectoriesNotFoundInTVFiles":
                    await RemoveAzureDirectoriesNotFoundInTVFilesAsync();
                    break;
                case "RemoveAzureFilesNotFoundInTVFiles":
                    await RemoveAzureFilesNotFoundInTVFilesAsync();
                    break;
                case "RemoveExternalHardDriveDirectoriesNotFoundInTVFiles":
                    await RemoveExternalHardDriveDirectoriesNotFoundInTVFilesAsync();
                    break;
                case "RemoveExternalHardDriveFilesNotFoundInTVFiles":
                    await RemoveExternalHardDriveFilesNotFoundInTVFilesAsync();
                    break;
                case "RemoveLocalDirectoriesNotFoundInTVFiles":
                    await RemoveLocalDirectoriesNotFoundInTVFilesAsync();
                    break;
                case "RemoveLocalFilesNotFoundInTVFiles":
                    await RemoveLocalFilesNotFoundInTVFilesAsync();
                    break;
                case "RemoveNationalBackupDirectoriesNotFoundInTVFiles":
                    await RemoveNationalBackupDirectoriesNotFoundInTVFilesAsync();
                    break;
                case "RemoveNationalBackupFilesNotFoundInTVFiles":
                    await RemoveNationalBackupFilesNotFoundInTVFilesAsync();
                    break;
                case "RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile":
                    await RemoveTVFilesDoubleAssociatedWithTVItemsTypeFileAsync();
                    break;
                case "RemoveTVItemsNoAssociatedWithTVFiles":
                    await RemoveTVItemsNoAssociatedWithTVFilesAsync();
                    break;
                case "UpdateAllTVItemStats":
                    await UpdateAllTVItemStatsAsync();
                    break;
                case "UploadAllFilesToAzure":
                    await UploadAllFilesToAzureAsync();
                    break;
                case "UploadAllJsonFilesToAzure":
                    await UploadAllJsonFilesToAzureAsync();
                    break;
                default:
                    {
                        return await LogError1ArgsReturnFalseAsync(AllowableCSSPCommandNameFor1ArgsList, FunctionName);
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
                        return await LogError4ArgsReturnFalseAsync(AllowableCSSPCommandNameFor4ArgsList, FunctionName);
                    }

            }

            int Year = int.Parse(args[1]);

            if (Year < 2000 || Year > DateTime.Now.Year + 1)
            {
                return await LogError4ArgsDateReturnFalseAsync(FunctionName);
            }

            int Month = int.Parse(args[2]);

            if (Month < 1 || Month > 12)
            {
                return await LogError4ArgsDateReturnFalseAsync(FunctionName);
            }

            int Day = int.Parse(args[3]);
            if (Day < 1 || Day > 31)
            {
                return await LogError4ArgsDateReturnFalseAsync(FunctionName);
            }

            DateTime UpdateFromDate;
            try
            {
                UpdateFromDate = new DateTime(Year, Month, Day);
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: {ex.InnerException.Message}" : "";
                CSSPLogService.AppendError($"{ex.Message} {inner}");

                return await Task.FromResult(false);
            }

            if (UpdateFromDate > DateTime.Now)
            {
                return await LogError4ArgsDateReturnFalseAsync(FunctionName);
            }

            switch (CSSPLogService.CSSPCommandName)
            {
                case "UpdateChangedTVItemStats":
                    await UpdateChangedTVItemStatsAsync(UpdateFromDate);
                    break;
                case "UploadChangedFilesToAzure":
                    await UploadChangedFilesToAzureAsync(UpdateFromDate);
                    break;
                case "UploadChangedJsonFilesToAzure":
                    await UploadChangedJsonFilesToAzureAsync(UpdateFromDate);
                    break;
                default:
                    {
                        return await LogError4ArgsReturnFalseAsync(AllowableCSSPCommandNameFor4ArgsList, FunctionName);
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
                CSSPLogService.AppendError($"CSSPUpdate.exe {CSSPCommandName} yyyy MM dd");
            }
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}

