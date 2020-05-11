using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GenerateCodeBaseServices.Models
{
    public class DLLPropertyInfo
    {
        public DLLPropertyInfo()
        {

        }

        public PropertyInfo PropertyInfo { get; set; }
        public CSSPProp CSSPProp { get; set; }
    }
}
