using CSSPCodeGenWebAPI.Services.Resources;
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
    public class GenerateEnumsService : IGenerateEnumsService
    {
        /// <summary>
        /// Will try to run a console application    
        /// </summary>
        /// <param name="command">String indicating the console application to run</param>
        /// <param name="culture">Current culture setting for multilanguage error message</param>
        /// <param name="sbStatus">Will hold all the status text during the running of the application</param>
        /// <returns></returns>
        public async Task<string> GenerateEnums(string command, CultureInfo culture, StringBuilder sbStatus)
        {
            string RunResult = "";

            try
            {
                ServicesRes.Culture = culture;

                string exePath = "";
                string args = "";
                switch (command)
                {
                    case "CompareEnumsAndOldEnums":
                        {
                            exePath = $@"C:\CSSPTools\src\execs\CompareEnumsAndOldEnums.exe";
                            args = $" { culture.Name }";
                        }
                        break;
                    case "EnumsGenerated_cs":
                        {
                            exePath = $@"C:\CSSPTools\src\execs\EnumsGenerated_cs.exe";
                            args = $" { culture.Name }";
                        }
                        break;
                    case "EnumsTestGenerated_cs":
                        {
                            exePath = $@"C:\CSSPTools\src\execs\EnumsTestGenerated_cs.exe";
                            args = $" { culture.Name }";
                        }
                        break;
                    case "GeneratePolSourceEnumCodeFiles":
                        {
                            exePath = $@"C:\CSSPTools\src\execs\GeneratePolSourceEnumCodeFiles.exe";
                            args = $" { culture.Name }";
                        }
                        break;
                    default:
                        return String.Format(ServicesRes.Command_IsNotImplemented, command);

                }

                RunResult = await RunApplication(exePath, args, sbStatus);

            }
            catch (Exception ex)
            {
                return $"Unmanaged Server Error: {ex.Message}";
            }

            // temp code to test OKText
            //RunResult = $"Everything worked for {command}. Life is good.";

            return RunResult;
        }

        private async Task<string> RunApplication(string exePath, string args, StringBuilder sbStatus)
        {
            // verify that the exePath application exist
            FileInfo fiApp = new FileInfo(exePath);
            if (!fiApp.Exists)
            {
                return String.Format(ServicesRes.CouldNotFindExePath_, exePath);
            }

            // deleting status file if already exist
            FileInfo fiStatus = new FileInfo($"{fiApp.DirectoryName}/status.txt");
            if (fiStatus.Exists)
            {
                try
                {
                    fiStatus.Delete();
                }
                catch (Exception ex)
                {
                    return String.Format(ServicesRes.CouldNotDeleteStatusFile_Error_, fiStatus.FullName, ex.Message);
                }
            }

            // run exePath application
            Process process = new Process();
            process = Process.Start(exePath, args);

            while (!process.HasExited)
            {
                // report progress is needed
            }

            StreamReader sr = fiStatus.OpenText();
            sbStatus = new StringBuilder(sr.ReadToEnd());
            sr.Close();

            return "";
        }
    }
}
