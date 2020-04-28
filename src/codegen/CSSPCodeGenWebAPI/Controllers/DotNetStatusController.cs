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
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.Extensions.Configuration;

namespace CSSPCodeGenWebAPI.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public class DotNetStatusController : ControllerBase
    {
        #region Variables
        private readonly IGenerateCodeStatusDBService _generateCodeStatusDBService;
        private readonly IConfiguration _configuration;
        #endregion Variables

        #region Constructors
        public DotNetStatusController(IGenerateCodeStatusDBService generateCodeStatusDBService, IConfiguration configuration)
        {
            _generateCodeStatusDBService = generateCodeStatusDBService;
            _configuration = configuration;
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
                _generateCodeStatusDBService.Culture = new CultureInfo(Request.RouteValues["culture"].ToString());
                _generateCodeStatusDBService.Command = $"{ dotNetActionOnFile.Action }:{ dotNetActionOnFile.SolutionFileName }";

                GenerateCodeStatus generateCodeStatus = await _generateCodeStatusDBService.Get();

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
