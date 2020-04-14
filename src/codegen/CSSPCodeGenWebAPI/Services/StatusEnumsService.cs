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
using System.Threading.Tasks;

namespace CSSPCodeGenWebAPI.Services
{
    public class StatusEnumsService : IStatusEnumsService
    {
        /// <summary>
        /// Will try to run a console application    
        /// </summary>
        /// <param name="command">String indicating the console application to run</param>
        /// <param name="culture">Current culture setting for multilanguage error message</param>
        /// <param name="configuration">Provide a configuration object</param>
        /// <param name="statusAndResultsService">Services for accessing the {AppDataPath}CSSP\GenerateCodeStatus.db</param>
        /// <returns></returns>
        public async Task StatusEnums(string command, CultureInfo culture, IConfiguration configuration, IStatusAndResultsService statusAndResultsService)
        {

            try
            {
                ServicesRes.Culture = culture;

                StatusAndResults statusAndResults = await statusAndResultsService.Get(command);

                if (statusAndResults == null)
                {
                    statusAndResults = await statusAndResultsService.Create(command);
                    if (statusAndResults == null)
                    {
                        return;
                    }

                    statusAndResults = await statusAndResultsService.Get(command);

                    if (statusAndResults == null)
                    {
                        return;
                    }
                }

                switch (command)
                {
                    case "CompareEnumsAndOldEnums":
                    case "EnumsGenerated_cs":
                    case "EnumsTestGenerated_cs":
                    case "GeneratePolSourceEnumCodeFiles":
                        {
                            await VerifyCommandStatus(command, configuration, statusAndResultsService);
                        }
                        break;
                    default:
                        {
                            await statusAndResultsService.Update(command, String.Format(ServicesRes.Command_IsNotImplemented, command), "", 0);
                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                await statusAndResultsService.Update(command, String.Format(ServicesRes.UnmanagedServerError_, ex.Message), "", 0);
                return;
            }

            return;
        }

        private async Task VerifyCommandStatus(string command, IConfiguration configuration, IStatusAndResultsService statusAndResultsService)
        {
            StringBuilder sbError = new StringBuilder();
            StringBuilder sbStatus = new StringBuilder();

            List<string> fileTypeList = new List<string>()
            {
                "Runs", "Required", "Created", "Compiled"
            };

            foreach(string fileType in fileTypeList)
            {
                List<string> fileList = configuration.GetSection($"{ command }:{ fileType }").GetChildren().ToList().Select(x => x.Value).ToList();

                sbStatus.AppendLine(fileType);

                if (fileList != null)
                {
                    foreach (string file in fileList)
                    {
                        string CheckFile = file;
                        if (file.Contains("{AppDataPath}"))
                        {
                            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                            CheckFile = file.Replace("{AppDataPath}", appDataPath);
                        }

                        FileInfo fi = new FileInfo(CheckFile);
                        if (!fi.Exists)
                        {
                            sbError.AppendLine(String.Format(ServicesRes.FileNotFound_, fi.FullName));
                            //await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                            //return;
                        }
                        else
                        {
                            sbStatus.AppendLine($"{ fi.LastWriteTime.ToString("yyyy MM dd : HH:mm:ss") } { fi.FullName }");
                            //await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                        }
                    }
                }
                else
                {
                    sbStatus.AppendLine(ServicesRes.NoFileToVerify);
                    await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
                }
                sbStatus.AppendLine("");
                sbStatus.AppendLine("");
            }

            await statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            return;
        }
    }
}
