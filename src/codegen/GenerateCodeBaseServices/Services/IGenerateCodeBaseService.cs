using GenerateCodeBaseServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using GenerateCodeBaseServices.Models;
using System.Globalization;

namespace GenerateCodeBaseServices.Services
{
    public interface IGenerateCodeBaseService
    {
        bool FillCSSPProp(PropertyInfo propInfo, CSSPProp csspProp, Type type);
        bool FillDLLTypeInfoList(FileInfo fiDLL, List<DLLTypeInfo> DLLTypeInfoList);
        bool SkipType(Type type);
        Task SetCulture(CultureInfo culture);

    }
}