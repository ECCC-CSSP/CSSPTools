﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModelsCompareServices.Services
{
    public interface IModelsCompareService
    {
        Task<bool> Run(string[] args);
    }
}