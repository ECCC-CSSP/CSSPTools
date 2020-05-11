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
using ActionCommandDBServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandServices.Services;

namespace CSSPCodeGenWebAPI.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public class ActionCommandController : ControllerBase
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IActionCommandService actionCommandService { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        #endregion Properties

        #region Constructors
        public ActionCommandController(IConfiguration configuration, IActionCommandService actionCommandService, IActionCommandDBService actionCommandDBService)
        {
            this.configuration = configuration;
            this.actionCommandService = actionCommandService;
            this.actionCommandDBService = actionCommandDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpPost]
        public async Task<ActionResult<ActionCommand>> post(ActionCommand actionCommand)
        {
            //Thread.Sleep(1000);

            await actionCommandService.SetCulture(new CultureInfo(Request.RouteValues["culture"].ToString()));

            return await actionCommandService.RunActionCommand(actionCommand);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }

}
