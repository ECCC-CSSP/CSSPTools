using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
   public class RatingCurveValueModel : LastUpdateAndContactModel
    {
       public RatingCurveValueModel()
       {
       }
       public int RatingCurveValueID { get; set; }
       public int RatingCurveID { get; set; }
       public double StageValue_m { get; set; }
       public double DischargeValue_m3_s { get; set; }
    }
}
