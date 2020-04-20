using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CSSPGenerateCodeBase.Models
{
    public class DLLPropertyInfo
    {
        public DLLPropertyInfo()
        {

        }

        public PropertyInfo PropertyInfo { get; set; }
        public CSSPProp CSSPProp { get; set; }
        //public string Name { get; set; }
        //public Type PropertyType { get; set; }
        //public string PropertyTypeName { get; set; }
    }
}
