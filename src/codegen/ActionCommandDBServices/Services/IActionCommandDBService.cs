using ActionCommandDBServices.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        public StringBuilder TempStatusText { get; set; }
        public StringBuilder ErrorText { get; set; }
        public StringBuilder ExecutionStatusText { get; set; }
        public StringBuilder FilesStatusText { get; set; }
        public long PercentCompleted { get; set; }

        Task<ActionCommand> Create();
        Task<ActionCommand> Delete();
        Task<ActionCommand> Get();
        Task<ActionCommand> GetOrCreate();
        Task<ActionCommand> Update();
        Task SetCulture(CultureInfo culture);
    }
}
