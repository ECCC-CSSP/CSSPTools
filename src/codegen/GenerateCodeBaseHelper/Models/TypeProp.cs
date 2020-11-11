using System;
using System.Collections.Generic;

namespace GenerateCodeBaseServices.Models
{
    public class TypeProp
    {
        public TypeProp()
        {
            csspPropList = new List<CSSPProp>();
        }

        public Type type { get; set; }
        public string Plurial { get; set; }
        public List<CSSPProp> csspPropList { get; set; }
    }
}
