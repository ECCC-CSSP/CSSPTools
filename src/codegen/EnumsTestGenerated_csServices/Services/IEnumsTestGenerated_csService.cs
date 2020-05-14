using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace EnumsTestGenerated_cs.Services
{
    public interface IEnumsTestGenerated_csService
    {
        Task<bool> Run(string[] args);
        Task SetCulture(CultureInfo culture);
    }
}