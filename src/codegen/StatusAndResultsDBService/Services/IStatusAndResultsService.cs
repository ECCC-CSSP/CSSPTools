using StatusAndResultsDBService.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusAndResultsDBService.Services
{
    public interface IStatusAndResultsService
    {
        string DBFileFullName { get; set; }
        string Command { get; set; }
        StringBuilder Error { get; set; }
        StringBuilder Status { get; set; }
        Task<StatusAndResults> Create();
        Task<StatusAndResults> Delete();
        Task<StatusAndResults> Get();
        Task<StatusAndResults> GetOrCreate();
        Task<StatusAndResults> Update(int percentCompleted);
        Task SetCommand(string command);
        Task SetCulture(CultureInfo culture);
    }
}
