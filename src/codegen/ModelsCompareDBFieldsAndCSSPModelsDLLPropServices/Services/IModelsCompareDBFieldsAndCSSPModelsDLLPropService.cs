﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Services
{
    public interface IModelsCompareDBFieldsAndCSSPModelsDLLPropService
    {
        Task<bool> Run(string[] args);
    }
}