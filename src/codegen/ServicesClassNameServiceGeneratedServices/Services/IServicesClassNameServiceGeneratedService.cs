﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public interface IServicesClassNameServiceGeneratedService
    {
        Task<bool> Run(string[] args);
        Task SetCulture(CultureInfo culture);
    }
}