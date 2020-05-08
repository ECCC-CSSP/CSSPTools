using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSSPCodeGenWebAPI.Controllers.Resources;
using CSSPCodeGenWebAPI.Models;
using CSSPCodeGenWebAPI.Services;
using CSSPCodeGenWebAPI.Services.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.Extensions.Configuration;
using GenerateCodeStatusDB.Services;
using GenerateCodeStatusDB.Models;

namespace CSSPCodeGenWebAPI.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public class DotNetController : ControllerBase
    {
        #region Variables
        private readonly IConfiguration configuration;
        private readonly IDotNetService dotNetService;
        private readonly IGenerateCodeStatusDBService generateCodeStatusDBService;
        #endregion Variables

        #region Constructors
        public DotNetController(IConfiguration configuration, IDotNetService dotNetService, IGenerateCodeStatusDBService generateCodeStatusService)
        {
            this.configuration = configuration;
            this.dotNetService = dotNetService;
            this.generateCodeStatusDBService = generateCodeStatusService;
        }
        #endregion Constructors

        #region Functions public
        [HttpPost]
        public async Task<ActionResult<ActionReturn>> post(DotNetActionOnFile dotNetActionOnFile)
        {
            //Thread.Sleep(1000);

            ActionReturn actionReturn = new ActionReturn();

            try
            {
                generateCodeStatusDBService.Culture = new CultureInfo(Request.RouteValues["culture"].ToString());
                generateCodeStatusDBService.Command = $"{ dotNetActionOnFile.Action }:{ dotNetActionOnFile.SolutionFileName }";

                DotNetCommand dotNetCommand = new DotNetCommand()
                {
                    CultureName = Request.RouteValues["culture"].ToString(),
                    Action = dotNetActionOnFile.Action,
                    SolutionFileName = dotNetActionOnFile.SolutionFileName,
                };

                await dotNetService.DotNet(dotNetCommand);

                GenerateCodeStatus generateCodeStatus = await generateCodeStatusDBService.GetOrCreate();

                if (generateCodeStatus != null)
                {
                    if (!string.IsNullOrWhiteSpace(generateCodeStatus.ErrorText))
                    {
                        actionReturn.ErrorText = generateCodeStatus.ErrorText;
                        actionReturn.OKText = "";
                    }
                    else
                    {
                        actionReturn.ErrorText = "";
                        actionReturn.OKText = generateCodeStatus.StatusText;
                    }
                }
                else
                {
                    actionReturn.ErrorText = String.Format(ControllersRes.CouldNotFindCommand_StatusInDB, $"{ dotNetActionOnFile.Action }:{ dotNetActionOnFile.SolutionFileName }");
                    actionReturn.OKText = "";
                }

                if (string.IsNullOrWhiteSpace(actionReturn.ErrorText))
                {
                    return Ok(actionReturn);
                }

            }
            catch (Exception ex)
            {
                actionReturn.ErrorText = String.Format(ControllersRes.ServerCommand_Error_, $"{ dotNetActionOnFile.Action }:{ dotNetActionOnFile.SolutionFileName }", ex.Message);
                actionReturn.OKText = "";
            }

            return BadRequest(actionReturn);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }

}
