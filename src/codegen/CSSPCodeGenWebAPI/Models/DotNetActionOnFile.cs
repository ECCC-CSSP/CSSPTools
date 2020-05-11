using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPCodeGenWebAPI.Models
{
    public class DotNetActionOnFile
    {
        // is coming from web address
        //
        //public string CultureName { get; set; } // options en-CA || fr-CA

        public string Action { get; set; } // options Run || Test || Build
        public string FileName { get; set; } // Ex: CSSPEnums || CSSPModels || CSSPServices || etc...
        public bool StatusOnly { get; set; } // true to just get the status of the command
    }
}
