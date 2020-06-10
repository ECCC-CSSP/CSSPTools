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
using CultureServices.Services;

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
        private ICultureService CultureService { get; set; }
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
            CultureService.SetCulture(Request.RouteValues["culture"].ToString());
            return await actionCommandDBService.GetAll();
        }
        [Route("RefillAll")]
        [HttpGet]
        public async Task<ActionResult<List<ActionCommand>>> RefillAll()
        {
            CultureService.SetCulture(Request.RouteValues["culture"].ToString());
            return await actionCommandDBService.RefillAll();
        }
        [Route("Run")]
        [HttpPost]
        public async Task<ActionResult<ActionCommand>> Run(ActionCommand actionCommand)
        {
            CultureService.SetCulture(Request.RouteValues["culture"].ToString());
            return await actionCommandDBService.Run(actionCommand);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }

}
