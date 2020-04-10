using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPCodeGenWebAPI.Services
{
    public interface IGenerateEnumsService
    {
        Task<string> GenerateEnums(string command, CultureInfo culture, StringBuilder sbStatus);
    }
}
