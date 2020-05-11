using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using ActionCommandDBServices.Services;
using ActionCommandDBServices.Models;

namespace ActionCommandServices.Services
{
    public interface IActionCommandService
    {
        Task<ActionResult<ActionCommand>> RunActionCommand(ActionCommand actionCommand);
        Task SetCulture(CultureInfo culture);
    }
}
