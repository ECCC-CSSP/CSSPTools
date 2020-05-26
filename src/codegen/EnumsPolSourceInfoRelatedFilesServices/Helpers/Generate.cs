using ActionCommandDBServices.Models;
using CultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EnumsPolSourceInfoRelatedFilesServices.Services
{
    public partial class EnumsPolSourceInfoRelatedFilesService : IEnumsPolSourceInfoRelatedFilesService
    {
        private async Task<bool> Generate()
        {
            ActionResult<ActionCommand> actionActionCommand = await ActionCommandDBService.Get();

            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await ActionCommandDBService.ConsoleWriteError("actionCommand == null");
                return await Task.FromResult(false);
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Starting ...");
            ActionCommandDBService.PercentCompleted = 10;
            await ActionCommandDBService.Update();

            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.ReadingExcelDocumentAndChecking }");

            FileInfo fiExcel = new FileInfo(Config.GetValue<string>("ExcelFileName"));

            if (!await PolSourceGroupingExcelFileReadService.ReadExcelSheet(fiExcel.FullName, false))
            {
                return await Task.FromResult(false);
            }

            if (PolSourceGroupingExcelFileReadService.groupChoiceChildLevelList.Count() == 0)
            {
                string ErrorText = String.Format(CultureServicesRes.ERROR_IsEqualTo0, "_groupChoiceChildLevelList");
                ActionCommandDBService.ErrorText.AppendLine($"{ ErrorText }");
                ActionCommandDBService.PercentCompleted = 0;
                await ActionCommandDBService.Update();

                return await Task.FromResult(false);
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.ReadingExcelDocumentAndChecking } { CultureServicesRes.Done } ...");

            if (!await Generate_FillPolSourceObsInfoChildService()) await Task.FromResult(false);
            if (!await Generate_EnumsPolSourceInfo()) await Task.FromResult(false);
            if (!await Generate_PolSourceObsInfoEnum()) await Task.FromResult(false);
            if (!await Generate_EnumsPolSourceObsInfoEnumTest()) await Task.FromResult(false);
            if (!await Generate_PolSourceInfoEnumGeneratedRes_resx()) await Task.FromResult(false);
            if (!await Generate_PolSourceInfoEnumGeneratedResFR_resx()) await Task.FromResult(false);

            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Done } ...");
            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            ActionCommandDBService.PercentCompleted = 100;
            await ActionCommandDBService.Update();

            return await Task.FromResult(true);
        }
    }
}
