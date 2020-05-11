using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateCodeBase.Models
{
    public class TableFieldEnumException
    {
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string EnumText { get; set; }
    }
}
