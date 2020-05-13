using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace AngularEnumsGeneratedServices.Services
{
    public interface IAngularEnumsGeneratedService
    {
        Task<bool> Run(string[] args);
        Task SetCulture(CultureInfo culture);
    }
}