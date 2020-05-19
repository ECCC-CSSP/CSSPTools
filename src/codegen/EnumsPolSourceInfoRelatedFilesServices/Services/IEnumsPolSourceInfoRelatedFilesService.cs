using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace EnumsPolSourceInfoRelatedFilesServices.Services
{
    public interface IEnumsPolSourceInfoRelatedFilesService
    {
        Task<bool> Run(string[] args);
    }
}