using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class CoCoRaHSSiteModel : LastUpdateAndContactModel
    {
        public CoCoRaHSSiteModel()
        {
        }
        public int CoCoRaHSSiteID { get; set; }
        public string StationNumber { get; set; }
        public string StationName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
