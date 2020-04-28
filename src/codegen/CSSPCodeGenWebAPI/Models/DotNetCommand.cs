using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPCodeGenWebAPI.Models
{
    public class DotNetCommand : DotNetActionOnFile
    {
        public string CultureName { get; set; } // options en-CA || fr-CA
        
        // defined in DotNetActionOnFile
        //
        //public string Action { get; set; } // options Run || Test || Build
        //public string SolutionFileName { get; set; } // Ex: CSSPEnums || CSSPModels || CSSPServices || etc...

    }
}
