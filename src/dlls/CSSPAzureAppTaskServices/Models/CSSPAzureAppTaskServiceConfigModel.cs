using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPAzureAppTaskServices.Models
{
    public class CSSPAzureAppTaskServiceConfigModel
    {
        public string APISecret { get; set; }
        public string AzureCSSPDB { get; set; }
        public string AzureStore { get; set; }
        public string CSSPAzureUrl { get; set; }
    }
}
