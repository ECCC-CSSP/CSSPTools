using ActionCommandDBServices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace ActionCommandDBServices.Services
{
    public interface IActionCommandDBService
    {
        public long ActionCommandID { get; set; }
        public string Action { get; set; }
        public string Command { get; set; }
        public string FullFileName { get; set; }
        public string Description { get; set; }
        public StringBuilder ErrorText { get; set; }
        public StringBuilder ExecutionStatusText { get; set; }
        public StringBuilder FilesStatusText { get; set; }
        public long PercentCompleted { get; set; }

        Task<ActionResult<ActionCommand>> Get();
        Task<ActionResult<List<ActionCommand>>> GetAll();
        Task<ActionResult<List<ActionCommand>>> RefillAll();
        Task<ActionResult<ActionCommand>> Run(ActionCommand actionCommand);
        Task<ActionResult<ActionCommand>> Update();
        Task SetCulture(CultureInfo culture);

        Task ConsoleWriteEnd();
        Task ConsoleWriteError(string errMessage);
        Task ConsoleWriteStart();
    }
}
