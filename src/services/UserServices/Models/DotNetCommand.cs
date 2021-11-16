using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ExecuteDotNetCommandServices.Models
{
    public class DotNetCommand
    {
        public string CultureName { get; set; } // options en-CA || fr-CA
        public string Action { get; set; } // options Run || Test || Build
        public string SolutionFileName { get; set; } // Ex: CSSPEnums || CSSPModels || CSSPServices || etc...
    }
}
