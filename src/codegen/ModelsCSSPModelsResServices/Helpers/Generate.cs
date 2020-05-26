using ActionCommandDBServices.Models;
using CultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ModelsCSSPModelsResServices.Services
{
    public partial class ModelsCSSPModelsResService : IModelsCSSPModelsResService
    {
        private async Task<bool> Generate()
        {
            ActionResult<ActionCommand> actionActionCommand = await ActionCommandDBService.Get();

            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await ActionCommandDBService.ConsoleWriteError("actionCommand == null");
                return false;
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Starting ...");
            ActionCommandDBService.PercentCompleted = 10;
            await ActionCommandDBService.Update();

            foreach (string lang in new List<string>() { "", "fr" })
            {
                StringBuilder sb = new StringBuilder();

                ResxTopPart(sb);
                ResxManual(sb, lang);
                //ResxDLL(sb);

                sb.AppendLine(@"</root>");

                if (lang == "fr")
                {
                    FileInfo fiOutput = new FileInfo(Config.GetValue<string>("CSSPModelsResFR"));

                    using (StreamWriter sw = fiOutput.CreateText())
                    {
                        sw.Write(sb.ToString());
                    }

                    fiOutput = new FileInfo(Config.GetValue<string>("CSSPModelsResFR"));
                    if (fiOutput.Exists)
                    {
                        string fileLine = "Last Write Time [" + fiOutput.LastWriteTime.ToString("yyyy MMMM dd HH:mm:ss") + "] " + fiOutput.FullName;
                        ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
                    }
                    else
                    {
                        string fileLine = "Not Created" + fiOutput.FullName;
                        ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
                    }

                    ActionCommandDBService.ExecutionStatusText.AppendLine($"{ string.Format(CultureServicesRes.Created_, fiOutput.FullName) }");
                }
                else
                {
                    FileInfo fiOutput = new FileInfo(Config.GetValue<string>("CSSPModelsRes"));

                    using (StreamWriter sw = fiOutput.CreateText())
                    {
                        sw.Write(sb.ToString());
                    }

                    fiOutput = new FileInfo(Config.GetValue<string>("CSSPModelsRes"));
                    if (fiOutput.Exists)
                    {
                        string fileLine = "Last Write Time [" + fiOutput.LastWriteTime.ToString("yyyy MMMM dd HH:mm:ss") + "] " + fiOutput.FullName;
                        ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
                    }
                    else
                    {
                        string fileLine = "Not Created" + fiOutput.FullName;
                        ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
                    }

                    ActionCommandDBService.ExecutionStatusText.AppendLine($"{ string.Format(CultureServicesRes.Created_, fiOutput.FullName) }");
                }
            }

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
