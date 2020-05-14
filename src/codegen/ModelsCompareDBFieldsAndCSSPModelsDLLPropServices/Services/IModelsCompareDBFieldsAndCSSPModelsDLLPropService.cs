using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Services
{
    public interface IModelsCompareDBFieldsAndCSSPModelsDLLPropService
    {
        Task<bool> Run(string[] args);
        Task SetCulture(CultureInfo culture);
    }
}