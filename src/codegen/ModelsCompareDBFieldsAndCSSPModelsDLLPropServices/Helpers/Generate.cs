using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;
using Microsoft.AspNetCore.Mvc;
using CultureServices.Resources;

namespace ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Services
{
    public partial class ModelsCompareDBFieldsAndCSSPModelsDLLPropService : IModelsCompareDBFieldsAndCSSPModelsDLLPropService
    {
        private async Task<bool> Generate()
        {
            ActionResult<ActionCommand> actionActionCommand = await actionCommandDBService.GetOrCreate();

            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await actionCommandDBService.ConsoleWriteError("actionCommand == null");
                return await Task.FromResult(false);
            }

            CSSPDBConnectionString = configuration.GetValue<string>("CSSPDBConnectionString");

            if (CSSPDBConnectionString == null)
            {
                await actionCommandDBService.ConsoleWriteError("CSSPDBConnectionString == null");
                return await Task.FromResult(false);
            }

            actionCommandDBService.ExecutionStatusText.AppendLine("Generate Starting ...");
            actionCommandDBService.PercentCompleted = 10;
            await actionCommandDBService.Update();

            FillPublicList();

            List<Table> tableCSSPWebList = new List<Table>();
            List<TypeProp> typePropList = new List<TypeProp>();

            // loading what currently exist in the DB
            if (!await LoadDBInfo(tableCSSPWebList, CSSPDBConnectionString)) return await Task.FromResult(false);

            // Loading what exist in the compiled CSSPModels.dll
            if (!await LoadCSSPModelsDLLInfo(typePropList)) return await Task.FromResult(false);

            // Compare DB and Compiled CSSPModels.DLL
            if (!await CompareDBAndCSSPModelsDLL(tableCSSPWebList, typePropList)) return await Task.FromResult(false);

            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Done } ...");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            actionCommandDBService.PercentCompleted = 100;
            await actionCommandDBService.Update();

            return await Task.FromResult(true);
        }
    }
}
