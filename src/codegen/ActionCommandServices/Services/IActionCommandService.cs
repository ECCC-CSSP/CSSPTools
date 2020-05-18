using ActionCommandDBServices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;

namespace ActionCommandServices.Services
{
    public interface IActionCommandService
    {
        Task<ActionResult<ActionCommand>> RunActionCommand(ActionCommand actionCommand);
        Task SetCulture(CultureInfo culture);
    }
}
