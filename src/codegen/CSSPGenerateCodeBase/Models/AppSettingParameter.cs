using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPGenerateCodeBase.Models
{
    public class AppSettingParameter
    {
        public string Parameter { get; set; }
        public string ExpectedValue { get; set; }
        public bool IsCulture { get; set; }
        public bool IsFile { get; set; }
        public bool CheckExist { get; set; }
    }
}
