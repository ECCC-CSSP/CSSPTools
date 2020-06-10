using System;
using System.Collections.Generic;
using System.Reflection;

namespace GenerateCodeBaseServices.Models
{
    public class DLLMethodInfo
    {
        public DLLMethodInfo()
        {
            ParameterInfoList = new List<DLLParameterInfo>();
        }

        public MethodInfo MethodInfo { get; set; }
        public string Name { get; set; }
        public Type DeclaringType { get; set; }
        public string DeclaringTypeName { get; set; }
        public List<DLLParameterInfo> ParameterInfoList { get; set; }
    }
}
