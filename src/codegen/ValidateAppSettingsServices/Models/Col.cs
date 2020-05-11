using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateCodeBase.Models
{
    public class Col
    {
        public string FieldName { get; set; }
        public bool AllowNull { get; set; }
        public string DataType { get; set; }
        public int StringLength { get; set; }
    }
}
