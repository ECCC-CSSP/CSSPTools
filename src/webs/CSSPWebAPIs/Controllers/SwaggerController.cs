using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSSPWebAPIs.Models.Temp;
using System.IO;
using Newtonsoft.Json.Serialization;

namespace CSSPWebAPIs.Controllers
{
    [Route("swagger/v1/swagger.json")]
    [ApiController]
    public class SwaggerController : ControllerBase
    {
        [HttpGet]
        public FileResult Get()
        {
            FileInfo fi = new FileInfo("swagger.json");
            StreamReader sr = fi.OpenText();
            string fileTxt = sr.ReadToEnd();
            sr.Close();

            return File(fi.FullName, "application/json", false);
        }
    }
}