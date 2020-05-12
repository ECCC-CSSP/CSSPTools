using ExecuteDotNetCommandServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteDotNetCommandServices.Services
{
    public interface IExecuteDotNetCommandService
    {
        Task<bool> Run(string[] args);
    }
}