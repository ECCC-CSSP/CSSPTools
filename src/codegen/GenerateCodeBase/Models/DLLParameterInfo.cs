using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GenerateCodeBase.Models
{
    public class DLLParameterInfo
    {
        public DLLParameterInfo()
        {

        }

        public ParameterInfo ParameterInfo { get; set; }
        public string Name { get; set; }
    }
}
