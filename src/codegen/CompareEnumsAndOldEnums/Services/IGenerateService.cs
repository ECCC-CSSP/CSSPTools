using CompareEnumsAndOldEnums.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompareEnumsAndOldEnums.Services
{
    public interface IGenerateService
    {
        Task<string> Start(IConfigurationRoot configuration);
    }
}