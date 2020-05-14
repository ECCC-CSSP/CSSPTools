using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.Extensions.Configuration;
using ModelsCSSPModelsResServices.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace ModelsCSSPModelsResServices.Services
{
    public partial class ModelsCSSPModelsResService : IModelsCSSPModelsResService
    {
        private async Task<bool> Generate()
        {
            ActionResult<ActionCommand> actionActionCommand = await actionCommandDBService.GetOrCreate();

            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await actionCommandDBService.ConsoleWriteError("actionCommand == null");
                return false;
            }

            actionCommandDBService.ExecutionStatusText.AppendLine("Generate Starting ...");
            actionCommandDBService.PercentCompleted = 10;
            await actionCommandDBService.Update();

            foreach (string lang in new List<string>() { "", "fr" })
            {
                StringBuilder sb = new StringBuilder();

                ResxTopPart(sb);
                ResxManual(sb, lang);
                //ResxDLL(sb);

                sb.AppendLine(@"</root>");

                if (lang == "fr")
                {
                    FileInfo fiOutput = new FileInfo(configuration.GetValue<string>("CSSPModelsResFR"));

                    using (StreamWriter sw = fiOutput.CreateText())
                    {
                        sw.Write(sb.ToString());
                    }

                    actionCommandDBService.ExecutionStatusText.AppendLine($"{ string.Format(ModelsCSSPModelsResServicesRes.Created_, fiOutput.FullName) }");
                }
                else
                {
                    FileInfo fiOutput = new FileInfo(configuration.GetValue<string>("CSSPModelsRes"));

                    using (StreamWriter sw = fiOutput.CreateText())
                    {
                        sw.Write(sb.ToString());
                    }

                    actionCommandDBService.ExecutionStatusText.AppendLine($"{ string.Format(ModelsCSSPModelsResServicesRes.Created_, fiOutput.FullName) }");
                }
            }

            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine($"{ ModelsCSSPModelsResServicesRes.Done } ...");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            actionCommandDBService.PercentCompleted = 100;
            await actionCommandDBService.Update();

            return true;
        }
    }
}
