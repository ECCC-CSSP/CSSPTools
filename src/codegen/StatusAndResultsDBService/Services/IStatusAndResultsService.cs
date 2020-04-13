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
        Task<StatusAndResults> Update(string command, string errorText, string statusText, int percentCompleted);
        Task<StatusAndResults> Create(string command);
        Task<StatusAndResults> Delete(string command);
        Task<StatusAndResults> Get(string command);
        Task SetCulture(CultureInfo Culture);
    }
}
