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
using CSSPCodeGenWebAPI.Services;
using CSSPCodeGenWebAPI.Services.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using StatusAndResultsDBService.Models;
using StatusAndResultsDBService.Services;

namespace CSSPCodeGenWebAPI.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public class GenerateEnumsController : ControllerBase
    {
        private readonly IGenerateEnumsService _geneerateEnumsService;
        private readonly IStatusAndResultsService _statusAndResultsService;

        public GenerateEnumsController(IGenerateEnumsService generateEnumsService, IStatusAndResultsService statusAndResultsService)
        {
            _geneerateEnumsService = generateEnumsService;
            _statusAndResultsService = statusAndResultsService;
        }

        [HttpPost]
        public async Task<ActionResult<ActionReturn>> post(GenerateEnumsCommand command)
        {
            //Thread.Sleep(1000);

            ActionReturn actionReturn = new ActionReturn();
            CultureInfo culture = new CultureInfo(Request.RouteValues["culture"].ToString());

            await _geneerateEnumsService.GenerateEnums(command.Command, culture, _statusAndResultsService);

            StatusAndResults statusAndResults = await _statusAndResultsService.Get(command.Command);

            if (statusAndResults != null)
            {
                if (!string.IsNullOrWhiteSpace(statusAndResults.ErrorText))
                {
                    actionReturn.ErrorText = statusAndResults.ErrorText;
                    actionReturn.OKText = "";
                }
                else
                {
                    actionReturn.ErrorText = "";
                    actionReturn.OKText = statusAndResults.StatusText;
                }
            }
            else
            {
                actionReturn.ErrorText = String.Format(ControllersRes.CouldNotFindCommand_StatusInDB, command.Command);
                actionReturn.OKText = "";
            }

            if (string.IsNullOrWhiteSpace(actionReturn.ErrorText))
            {
                return Ok(actionReturn);
            }          

            return BadRequest(actionReturn);
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
