using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class DrogueRunPositionModel : LastUpdateAndContactModel
    {
        public DrogueRunPositionModel()
        {
        }
        public int DrogueRunPositionID { get; set; }
        public int DrogueRunID { get; set; }
        public int Ordinal { get; set; }
        public double StepLat { get; set; }
        public double StepLng { get; set; }
        public DateTime StepDateTime_Local { get; set; }
        public double CalculatedSpeed_m_s { get; set; }
        public double CalculatedDirection_deg { get; set; }
    }
}
