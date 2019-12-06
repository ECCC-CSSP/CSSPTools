using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class SpillModel : LastUpdateAndContactModel
    {
        public SpillModel()
        {
        }
        public int SpillID { get; set; }
        public int MunicipalityTVItemID { get; set; }
        public string MunicipalityTVText { get; set; }
        public Nullable<int> InfrastructureTVItemID { get; set; }
        public string InfrastructureTVText { get; set; }
        public System.DateTime StartDateTime_Local { get; set; }
        public Nullable<System.DateTime> EndDateTime_Local { get; set; }
        public double AverageFlow_m3_day { get; set; }
        public string SpillComment { get; set; }

    }
}
