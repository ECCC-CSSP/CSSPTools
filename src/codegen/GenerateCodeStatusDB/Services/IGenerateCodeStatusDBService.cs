using GenerateCodeStatusDB.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCodeStatusDB.Services
{
    public interface IGenerateCodeStatusDBService
    {
        public CultureInfo Culture { get; set; }
        string DBFileFullName { get; set; }
        string Command { get; set; }
        StringBuilder Error { get; set; }
        StringBuilder Status { get; set; }
        Task<GenerateCodeStatus> Create();
        Task<GenerateCodeStatus> Delete();
        Task<GenerateCodeStatus> Get();
        Task<GenerateCodeStatus> GetOrCreate();
        Task<GenerateCodeStatus> Update(int percentCompleted);
        Task SetCommand(string command);
        Task SetCulture(CultureInfo culture);
    }
}
