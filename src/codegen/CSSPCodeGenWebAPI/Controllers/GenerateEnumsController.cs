using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSSPCodeGenWebAPI.Controllers.Resources;
using CSSPCodeGenWebAPI.Services.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;

namespace CSSPCodeGenWebAPI.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    public class GenerateEnumsController : ControllerBase
    {
        public GenerateEnumsController()
        {

        }

        [HttpPost]
        public async Task<ActionResult<ActionReturn>> post(GenerateEnumsCommand command)
        {
            Thread.Sleep(1000);

            ServicesRes.Culture = new CultureInfo(Request.RouteValues["culture"].ToString());
            ActionReturn actionReturn = new ActionReturn();

            string exePath = "";
            string args = "";
            switch (command.Command)
            {
                case "CompareEnumsAndOldEnums":
                    {
                        exePath = $@"C:\CSSPTools\src\execs\CompareEnumsAndOldEnums.exe";
                        args = "";
                    }
                    break;
                case "EnumsGenerated_cs":
                    {
                        exePath = $@"C:\CSSPTools\src\execs\EnumsGenerated_cs.exe";
                        args = "";
                    }
                    break;
                case "EnumsTestGenerated_cs":
                    {
                        exePath = $@"C:\CSSPTools\src\execs\EnumsTestGenerated_cs.exe";
                        args = "";
                    }
                    break;
                case "GeneratePolSourceEnumCodeFiles":
                    {
                        exePath = $@"C:\CSSPTools\src\execs\GeneratePolSourceEnumCodeFiles.exe";
                        args = "";
                    }
                    break;
                default:
                    actionReturn.ErrorText = String.Format(ControllersRes.Command_IsNotImplemented, command.Command);
                    return BadRequest(actionReturn);

            }

            actionReturn = await RunApplication(exePath, args);

            // temp code to test OKText
            actionReturn.OKText = "Everything worked. Life is good.";

            if (!string.IsNullOrWhiteSpace(actionReturn.OKText))
            {
                return Ok(actionReturn);
            }          

            return BadRequest(actionReturn);
        }

        public async Task<ActionReturn> RunApplication(string exePath, string args)
        {
            ActionReturn actionReturn = new ActionReturn();

            // verify that the exePath application exist
            FileInfo fiApp = new FileInfo(exePath);
            if (!fiApp.Exists)
            {
                actionReturn.ErrorText = String.Format(ControllersRes.CouldNotFindExePath_, exePath);
                return actionReturn;
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
                    actionReturn.ErrorText = String.Format(ControllersRes.CouldNotDeleteStatusFile_Error_, fiStatus.FullName, ex.Message);
                    return actionReturn;
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
            string fileText = sr.ReadToEnd();
            sr.Close();

            actionReturn.OKText = fileText;

            return actionReturn;
        }

        public class GenerateEnumsCommand
        {
            public string Command { get; set; }
        }

        public class ActionReturn
        {
            public string OKText { get; set; }
            public string ErrorText { get; set; }
        }
    }

}
