using ExecuteDotNetCommandServices.Models;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteDotNetCommandServices.Services
{
    public interface ICSSPCodeGenWebAPIService
    {
        Task<bool> Run(string[] args);
    }
}