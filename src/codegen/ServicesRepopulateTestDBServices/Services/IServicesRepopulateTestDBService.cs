using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace ServicesRepopulateTestDBServices.Services
{
    public interface IServicesRepopulateTestDBService
    {
        Task<bool> Run(string[] args);
        Task SetCulture(CultureInfo culture);
    }
}