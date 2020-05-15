using CSSPEnums;
using CSSPModels;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServicesRepopulateTestDBServices.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;

namespace ServicesRepopulateTestDBServices.Services
{
    public partial class ServicesRepopulateTestDBService : IServicesRepopulateTestDBService
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

            string CSSPDBConnectionString = configuration.GetValue<string>("CSSPDBConnectionString");
            string TestDBConnectionString = configuration.GetValue<string>("TestDBConnectionString");

            List<Table> tableCSSPDBList = new List<Table>();
            List<Table> tableTestDBList = new List<Table>();

            actionCommandDBService.ExecutionStatusText.AppendLine("Loading CSSPDB table information ...");
            if (!await LoadDBInfo(tableCSSPDBList, CSSPDBConnectionString)) return await Task.FromResult(false);

            actionCommandDBService.ExecutionStatusText.AppendLine("Loading TestWeb table information ...");
            if (!await LoadDBInfo(tableTestDBList, TestDBConnectionString)) return await Task.FromResult(false);

            actionCommandDBService.ExecutionStatusText.AppendLine("Comparing tables ...");
            if (!await CompareDBs(tableCSSPDBList, tableTestDBList)) return await Task.FromResult(false);

            actionCommandDBService.ExecutionStatusText.AppendLine("Done comparing ... everything ok");

            actionCommandDBService.ExecutionStatusText.AppendLine("Cleaning TestDB ...");
            if (!await CleanTestDB(tableTestDBList, TestDBConnectionString)) return await Task.FromResult(false);

            actionCommandDBService.ExecutionStatusText.AppendLine("Done Cleaning TestDB ... everything ok");

            actionCommandDBService.ExecutionStatusText.AppendLine("Filling TestDB ...");
            if (!await FillTestDB(tableTestDBList)) return await Task.FromResult(false);
            actionCommandDBService.ExecutionStatusText.AppendLine("Done Filling TestDB ... everything ok");

            actionCommandDBService.ExecutionStatusText.AppendLine("Making sure every table within TestDB has at least 10 items ...");
            if (!await MakingSureEveryTableHasEnoughItemsInTestDB()) return await Task.FromResult(false);

            actionCommandDBService.ExecutionStatusText.AppendLine("Done Making sure every table within TestDB has at least 10 items");

            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine($"{ ServicesRepopulateTestDBServicesRes.Done } ...");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            actionCommandDBService.PercentCompleted = 100;
            await actionCommandDBService.Update();


            return true;
        }
    }
}
