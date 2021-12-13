﻿namespace CSSPWebAPIs.Controllers;

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
