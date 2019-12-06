using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class CoCoRaHSValueModel : LastUpdateAndContactModel
    {
        public CoCoRaHSValueModel()
        {
        }
        public int CoCoRaHSValueID { get; set; }
        public int CoCoRaHSSiteID { get; set; }
        public DateTime ObservationDateAndTime { get; set; }
        public Nullable<double> TotalPrecipAmt { get; set; }
        public Nullable<double> NewSnowDepth { get; set; }
        public Nullable<double> NewSnowSWE { get; set; }
        public Nullable<double> TotalSnowDepth { get; set; }
        public Nullable<double> TotalSnowSWE { get; set; }
    }
}
