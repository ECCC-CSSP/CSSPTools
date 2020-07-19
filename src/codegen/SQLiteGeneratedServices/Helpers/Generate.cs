using ActionCommandDBServices.Models;
using CSSPCultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteGeneratedServices.Services
{
    public partial class SQLiteGeneratedService : ISQLiteGeneratedService
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

            StringBuilder sb = new StringBuilder();

            FileInfo fiDLL = new FileInfo(Config.GetValue<string>("CSSPModels"));

            if (!fiDLL.Exists)
            {
                await ActionCommandDBService.ConsoleWriteError($"Could not find file [{ fiDLL.FullName }]");
                return await Task.FromResult(false);
            }

            if (! await CheckAllModelExist(fiDLL)) await Task.FromResult(false);
            if (!await CreateFillListTableToDelete(fiDLL)) await Task.FromResult(false);
            if (!await CreateTableBuilder(fiDLL)) await Task.FromResult(false);
            
            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CSSPCultureServicesRes.Done } ...");
            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            ActionCommandDBService.PercentCompleted = 100;
            await ActionCommandDBService.Update();

            return await Task.FromResult(true);
        }
    }
}
