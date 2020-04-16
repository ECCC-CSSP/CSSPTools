using CSSPCodeGenWebAPI.Models;
using CSSPCodeGenWebAPI.Services.Resources;
using Microsoft.Extensions.Configuration;
using StatusAndResultsDBService.Models;
using StatusAndResultsDBService.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPCodeGenWebAPI.Services
{
    public class GenerateModelsService : IGenerateModelsService
    {
        /// <summary>
        /// Will try to run a console application    
        /// </summary>
        /// <param name="command">String indicating the console application to run</param>
        /// <param name="culture">Current culture setting for multilanguage error message</param>
        /// <param name="sbStatus">Will hold all the status text during the running of the application</param>
        /// <returns></returns>
        public async Task GenerateModels(string command, CultureInfo culture, IConfiguration configuration, IStatusAndResultsService statusAndResultsService)
        {
            try
            {
                ServicesRes.Culture = culture;

                string exePath = "";
                string args = "";
                switch (command)
                {
                    case "ModelsGenerate_a":
                    case "ModelsGenerated_b":
                    case "ModelsTestGenerated_c":
                    case "ModelsGenerate_d":
                        {
                            exePath = configuration.GetSection($"{ command }:Runs").GetChildren().ToList().Select(x => x.Value).ToList().FirstOrDefault();
                            args = $" { culture.Name }";
                        }
                        break;
                    default:
                        {
                            await statusAndResultsService.Update(command, String.Format(ServicesRes.Command_IsNotImplemented, command), "", 0);
                            return;
                        }

                }

                FileInfo fiApp = new FileInfo(exePath);
                if (!fiApp.Exists)
                {
                    await statusAndResultsService.Update(command, String.Format(ServicesRes.CouldNotFindExePath_, exePath), "", 0);
                    return;
                }

                RunApplication(exePath, args);
            }
            catch (Exception ex)
            {
                await statusAndResultsService.Update(command, String.Format(ServicesRes.UnmanagedServerError_, ex.Message), "", 0);
                return;
            }

            return;
        }

        private void RunApplication(string exePath, string args)
        {
            // run exePath application
            Process process = new Process();
            process = Process.Start(exePath, args);

            while (!process.HasExited)
            {
                // report progress is needed
            }
        }
    }
}
