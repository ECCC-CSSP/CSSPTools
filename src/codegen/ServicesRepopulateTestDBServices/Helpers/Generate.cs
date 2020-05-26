using ActionCommandDBServices.Models;
using CultureServices.Resources;
using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesRepopulateTestDBServices.Services
{
    public partial class ServicesRepopulateTestDBService : IServicesRepopulateTestDBService
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

            string CSSPDBConnectionString = Config.GetValue<string>("CSSPDBConnectionString");
            string TestDBConnectionString = Config.GetValue<string>("TestDBConnectionString");

            List<Table> tableCSSPDBList = new List<Table>();
            List<Table> tableTestDBList = new List<Table>();

            ActionCommandDBService.ExecutionStatusText.AppendLine("Loading CSSPDB table information ...");
            if (!await LoadDBInfo(tableCSSPDBList, CSSPDBConnectionString)) return await Task.FromResult(false);

            ActionCommandDBService.ExecutionStatusText.AppendLine("Loading TestWeb table information ...");
            if (!await LoadDBInfo(tableTestDBList, TestDBConnectionString)) return await Task.FromResult(false);

            ActionCommandDBService.ExecutionStatusText.AppendLine("Comparing tables ...");
            if (!await CompareDBs(tableCSSPDBList, tableTestDBList)) return await Task.FromResult(false);

            ActionCommandDBService.ExecutionStatusText.AppendLine("Done comparing ... everything ok");

            ActionCommandDBService.ExecutionStatusText.AppendLine("Cleaning TestDB ...");
            if (!await CleanTestDB(tableTestDBList, TestDBConnectionString)) return await Task.FromResult(false);

            ActionCommandDBService.ExecutionStatusText.AppendLine("Done Cleaning TestDB ... everything ok");

            ActionCommandDBService.ExecutionStatusText.AppendLine("Filling TestDB ...");
            if (!await FillTestDB(tableTestDBList)) return await Task.FromResult(false);
            ActionCommandDBService.ExecutionStatusText.AppendLine("Done Filling TestDB ... everything ok");

            ActionCommandDBService.ExecutionStatusText.AppendLine("Making sure every table within TestDB has at least 10 items ...");
            if (!await MakingSureEveryTableHasEnoughItemsInTestDB()) return await Task.FromResult(false);

            ActionCommandDBService.ExecutionStatusText.AppendLine("Done Making sure every table within TestDB has at least 10 items");

            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Done } ...");
            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            ActionCommandDBService.PercentCompleted = 100;
            await ActionCommandDBService.Update();


            return true;
        }
    }
}
