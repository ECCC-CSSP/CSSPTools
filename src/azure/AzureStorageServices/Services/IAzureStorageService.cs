using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageServices.Services
{
    public interface IAzureStorageService
    {
        Task<bool> Run(string[] args);
    }
}