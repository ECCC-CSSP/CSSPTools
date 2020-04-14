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
using StatusAndResultsDBService.Models;
using StatusAndResultsDBService.Services;

namespace CSSPCodeGenWebAPI.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public class StatusEnumsController : ControllerBase
    {
        private readonly IStatusEnumsService _statusEnumsService;
        private readonly IStatusAndResultsService _statusAndResultsService;
        private readonly IConfiguration _configuration;

        public StatusEnumsController(IStatusEnumsService statusEnumsService, IStatusAndResultsService statusAndResultsService, IConfiguration configuration)
        {
            _statusEnumsService = statusEnumsService;
            _statusAndResultsService = statusAndResultsService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<ActionReturn>> post(GenerateCommand command)
        {
            //Thread.Sleep(1000);

            ActionReturn actionReturn = new ActionReturn();
            CultureInfo culture = new CultureInfo(Request.RouteValues["culture"].ToString());

            await _statusEnumsService.StatusEnums(command.Command, culture, _configuration, _statusAndResultsService);

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


    }

}
