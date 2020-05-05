using GenerateCodeBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using GenerateCodeBase.Models;
using System.Globalization;

namespace GenerateCodeBase.Services
{
    public interface IGenerateCodeBaseService
    {
        public CultureInfo Culture { get; set; }

        bool FillCSSPProp(PropertyInfo propInfo, CSSPProp csspProp, Type type);
        bool FillDLLTypeInfoList(FileInfo fiDLL, List<DLLTypeInfo> DLLTypeInfoList);
        bool SkipType(Type type);
        void SetCulture(CultureInfo culture);

    }
}