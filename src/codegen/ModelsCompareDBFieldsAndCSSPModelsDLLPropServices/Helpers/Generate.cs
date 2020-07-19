using ActionCommandDBServices.Models;
using CSSPCultureServices.Resources;
using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Services
{
    public partial class ModelsCompareDBFieldsAndCSSPModelsDLLPropService : IModelsCompareDBFieldsAndCSSPModelsDLLPropService
    {
        private async Task<bool> Generate()
        {
            ActionResult<ActionCommand> actionActionCommand = await ActionCommandDBService.Get();

            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await ActionCommandDBService.ConsoleWriteError("actionCommand == null");
                return await Task.FromResult(false);
            }

            CSSPDB2 = Config.GetValue<string>("CSSPDB2");

            if (CSSPDB2 == null)
            {
                await ActionCommandDBService.ConsoleWriteError("CSSPDB2 == null");
                return await Task.FromResult(false);
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Starting ...");
            ActionCommandDBService.PercentCompleted = 10;
            await ActionCommandDBService.Update();
           
            if (!await FillPublicList()) return await Task.FromResult(false);

            List<Table> tableCSSPWebList = new List<Table>();
            List<TypeProp> typePropList = new List<TypeProp>();

            // loading what currently exist in the DB
            if (!await LoadDBInfo(tableCSSPWebList, CSSPDB2)) return await Task.FromResult(false);

            // Loading what exist in the compiled CSSPModels.dll
            if (!await LoadCSSPModelsDLLInfo(typePropList)) return await Task.FromResult(false);

            // Compare DB and Compiled CSSPModels.DLL
            if (!await CompareDBAndCSSPModelsDLL(tableCSSPWebList, typePropList)) return await Task.FromResult(false);

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
