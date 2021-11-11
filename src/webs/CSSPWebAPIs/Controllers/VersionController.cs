/*
 * Manually edited
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CSSPWebAPIs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Version: 1.0.1.9";
        }
    }
}
