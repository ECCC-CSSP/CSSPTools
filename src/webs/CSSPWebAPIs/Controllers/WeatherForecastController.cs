using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSSPCodeGenWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CSSPCodeGenWebAPI.Controllers
{
    [ApiController]
    [Route("api/{culture}/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        #region Variables
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        #endregion Variables

        #region Constructors
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
