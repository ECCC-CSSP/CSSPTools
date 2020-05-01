using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace EnumsCompareWithOldEnumsServices.Services
{
    public interface IEnumsCompareWithOldEnumsService
    {
        Task Run(string[] args);
        Task Setup();
    }
}