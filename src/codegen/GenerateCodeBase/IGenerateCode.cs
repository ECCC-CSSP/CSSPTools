using GenerateCodeBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace GenerateCodeBase
{
    public interface IGenerateCode
    {
        Task<bool> FillCSSPProp(PropertyInfo propInfo, CSSPProp csspProp, Type type);
        Task<bool> FillDLLTypeInfoList(FileInfo fiDLL, List<DLLTypeInfo> DLLTypeInfoList);
        Task<bool> SkipType(Type type);
    }
}