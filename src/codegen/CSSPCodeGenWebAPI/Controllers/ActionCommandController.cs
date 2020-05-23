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
        private IActionCommandDBService actionCommandDBService { get; set; }
        #endregion Properties

        #region Constructors
        public ActionCommandController(IConfiguration configuration, IActionCommandDBService actionCommandDBService)
        {
            this.configuration = configuration;
            this.actionCommandDBService = actionCommandDBService;

            //Thread.Sleep(1000);
        }
        #endregion Constructors

        #region Functions public
        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<List<ActionCommand>>> GetAll()
        {
            await actionCommandDBService.SetCulture(new CultureInfo(Request.RouteValues["culture"].ToString()));
            return await actionCommandDBService.GetAll();
        }
        [Route("ReFillAll")]
        [HttpGet]
        public async Task<ActionResult<List<ActionCommand>>> ReFillAll()
        {
            await actionCommandDBService.SetCulture(new CultureInfo(Request.RouteValues["culture"].ToString()));
            return await actionCommandDBService.ReFillAll();
        }
        [Route("Run")]
        [HttpPost]
        public async Task<ActionResult<ActionCommand>> Run(ActionCommand actionCommand)
        {
            await actionCommandDBService.SetCulture(new CultureInfo(Request.RouteValues["culture"].ToString()));
            return await actionCommandDBService.Run(actionCommand);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }

}
