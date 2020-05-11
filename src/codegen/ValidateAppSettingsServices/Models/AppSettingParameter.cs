using System;
using System.Collections.Generic;
using System.Text;

namespace ValidateAppSettingsServices.Models
{
    public class AppSettingParameter
    {
        public AppSettingParameter()
        {
            Parameter = "";
            ExpectedValue = "";
            IsCulture = false;
            IsFile = false;
            CheckExist = false;
        }
        public string Parameter { get; set; }
        public string ExpectedValue { get; set; }
        public bool IsCulture { get; set; }
        public bool IsFile { get; set; }
        public bool CheckExist { get; set; }
    }
}
