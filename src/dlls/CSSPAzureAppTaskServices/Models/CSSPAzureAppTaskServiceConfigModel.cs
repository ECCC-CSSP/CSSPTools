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
        public string AzureStoreCSSPFilesPath { get; set; }
        public string AzureStoreCSSPJSONPath { get; set; }
        public string AzureStoreCSSPWebAPIsPath { get; set; }
        public string CSSPAzureUrl { get; set; }
        public string CSSPDB { get; set; }
        public string CSSPDBLocal { get; set; }
        public string CSSPDBManage { get; set; }
        public string CSSPLocalUrl { get; set; }
        public string ComputerName { get; set; }
    }
}
