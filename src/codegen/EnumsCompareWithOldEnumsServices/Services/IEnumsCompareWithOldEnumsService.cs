using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EnumsCompareWithOldEnumsServices.Services
{
    public interface IEnumsCompareWithOldEnumsService
    {
        Task<bool> Run(string[] args);
    }
}