using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.Extensions.Configuration;
using PolSourceGroupingExcelFileReadServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;
using Microsoft.AspNetCore.Mvc;
using ValidateAppSettingsServices.Models;
using CultureServices.Resources;

namespace EnumsPolSourceInfoRelatedFilesServices.Services
{
    public partial class EnumsPolSourceInfoRelatedFilesService : IEnumsPolSourceInfoRelatedFilesService
    {
        private async Task<bool> Generate()
        {
            ActionResult<ActionCommand> actionActionCommand = await actionCommandDBService.GetOrCreate();

            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await actionCommandDBService.ConsoleWriteError("actionCommand == null");
                return await Task.FromResult(false);
            }

            actionCommandDBService.ExecutionStatusText.AppendLine("Generate Starting ...");
            actionCommandDBService.PercentCompleted = 10;
            await actionCommandDBService.Update();

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.ReadingExcelDocumentAndChecking }");

            FileInfo fiExcel = new FileInfo(configuration.GetValue<string>("ExcelFileName"));

            if (!await polSourceGroupingExcelFileReadService.ReadExcelSheet(fiExcel.FullName, false))
            {
                return await Task.FromResult(false);
            }

            if (polSourceGroupingExcelFileReadService.groupChoiceChildLevelList.Count() == 0)
            {
                string ErrorText = String.Format(CultureServicesRes.ERROR_IsEqualTo0, "_groupChoiceChildLevelList");
                actionCommandDBService.ErrorText.AppendLine($"{ ErrorText }");
                actionCommandDBService.PercentCompleted = 0;
                await actionCommandDBService.Update();

                return await Task.FromResult(false);
            }

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.ReadingExcelDocumentAndChecking } { CultureServicesRes.Done } ...");

            if (!await Generate_FillPolSourceObsInfoChildService()) await Task.FromResult(false);
            if (!await Generate_EnumsPolSourceInfo()) await Task.FromResult(false);
            if (!await Generate_PolSourceObsInfoEnum()) await Task.FromResult(false);
            if (!await Generate_EnumsPolSourceObsInfoEnumTest()) await Task.FromResult(false);
            if (!await Generate_PolSourceInfoEnumGeneratedRes_resx()) await Task.FromResult(false);
            if (!await Generate_PolSourceInfoEnumGeneratedResFR_resx()) await Task.FromResult(false);

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Done } ...");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            actionCommandDBService.PercentCompleted = 100;
            await actionCommandDBService.Update();

            return await Task.FromResult(true);
        }
    }
}
