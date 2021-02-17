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
    public class EmptyController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Empty Just to see if its working February 15, 2021";
        }
    }
}
