using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace ModelsCSSPModelsResServices.Services
{
    public interface IModelsModelClassNameTestService
    {
        Task<bool> Run(string[] args);
        Task SetCulture(CultureInfo culture);
    }
}