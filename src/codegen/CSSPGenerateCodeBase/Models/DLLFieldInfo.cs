using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CSSPGenerateCodeBase.Models
{
    public class DLLFieldInfo
    {
        public DLLFieldInfo()
        {

        }

        public FieldInfo FieldInfo { get; set; }
        public string Name { get; set; }
    }
}
