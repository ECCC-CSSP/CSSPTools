using System;
using System.Collections.Generic;

namespace GenerateCodeBaseServices.Models
{
    public class DLLTypeInfo
    {
        public DLLTypeInfo()
        {
            FieldInfoList = new List<DLLFieldInfo>();
            PropertyInfoList = new List<DLLPropertyInfo>();
            MethodInfoList = new List<DLLMethodInfo>();
        }

        public Type Type { get; set; }
        public string Name { get; set; }
        public bool IsEnum { get; set; }
        public bool IsPublic { get; set; }
        public bool HasNotMappedAttribute { get; set; }
        public List<DLLFieldInfo> FieldInfoList { get; set; }
        public List<DLLPropertyInfo> PropertyInfoList { get; set; }
        public List<DLLMethodInfo> MethodInfoList { get; set; }
    }
}
