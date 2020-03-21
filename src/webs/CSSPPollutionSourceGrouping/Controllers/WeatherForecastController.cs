using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CSSPPollutionSourceGrouping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private IWebHostEnvironment _webHostEnvironment;

        public WeatherForecastController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            string basePath = _webHostEnvironment.ContentRootPath;

            DirectoryInfo di = new DirectoryInfo($@"{basePath}\..\LabSheets\");

            if (!di.Exists)
            {
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    List<WeatherForecast> retArr = new List<WeatherForecast>();
                    retArr.Add(new WeatherForecast() { Date = DateTime.Now, Summary = ex.Message, TemperatureC = 0 });
                    return retArr.AsEnumerable();
                }
            }
            FileInfo fi = new FileInfo($@"{basePath}\..\LabSheets\test.txt");
            StreamWriter sw = fi.CreateText();
            sw.Write("Bonjour tout le monde parle le dimanche");
            sw.Close();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
