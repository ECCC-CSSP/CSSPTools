using ExecuteDotNetCommandServices.Models;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteDotNetCommandServices.Services
{
    public interface IExecuteDotNetCommandService
    {
        IGenerateCodeStatusDBService generateCodeStatusDBService { get; set; }
        Task<bool> Run(string[] args);
    }
}