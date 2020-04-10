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

namespace CSSPCodeGenWebAPI.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public class GenerateEnumsController : ControllerBase
    {
        private readonly IGenerateEnumsService _geneerateEnumsService;

        public GenerateEnumsController(IGenerateEnumsService generateEnumsService)
        {
            _geneerateEnumsService = generateEnumsService;
        }

        [HttpPost]
        public async Task<ActionResult<ActionReturn>> post(GenerateEnumsCommand command)
        {
            Thread.Sleep(1000);

            ActionReturn actionReturn = new ActionReturn();
            CultureInfo culture = new CultureInfo(Request.RouteValues["culture"].ToString());
            StringBuilder sbStatus = new StringBuilder();
            string genStr = await _geneerateEnumsService.GenerateEnums(command.Command, culture, sbStatus);

            actionReturn.OKText = sbStatus.ToString();
            actionReturn.ErrorText = genStr;

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
