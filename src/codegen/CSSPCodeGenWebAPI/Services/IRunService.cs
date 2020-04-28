using CSSPCodeGenWebAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerateCodeStatusDB.Services;

namespace CSSPCodeGenWebAPI.Services
{
    public interface IRunService
    {
        Task Run();
    }
}
