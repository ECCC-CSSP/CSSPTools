using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class PolSourceSiteEffectTermModel : LastUpdateAndContactModel
    {
        public PolSourceSiteEffectTermModel()
        {
        }
        public int PolSourceSiteEffectTermID { get; set; }
        public bool IsGroup { get; set; }
        public Nullable<int> UnderGroupID { get; set; }
        public string EffectTermEN { get; set; }
        public string EffectTermFR { get; set; }
    }
}
