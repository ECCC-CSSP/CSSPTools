using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class BoxModelModel : LastUpdateAndContactModel
    {
        public BoxModelModel()
        {
            BoxModelResultModelList = new List<BoxModelResultModel>();
        }
        
        public int BoxModelID { get; set; }
        public string ScenarioName { get; set; }
        public int InfrastructureTVItemID { get; set; }
        public double Discharge_m3_day { get; set; }
        public double Depth_m { get; set; }
        public double Temperature_C { get; set; }
        public int Dilution { get; set; }
        public double DecayRate_per_day { get; set; }
        public int FCUntreated_MPN_100ml { get; set; }
        public int FCPreDisinfection_MPN_100ml { get; set; }
        public int Concentration_MPN_100ml { get; set; }
        public double T90_hour { get; set; }
        public double DischargeDuration_hour { get; set; }
        public bool FixLength { get; set; }
        public bool FixWidth { get; set; }
        public double Length_m { get; set; }
        public double Width_m { get; set; }

        public List<BoxModelResultModel> BoxModelResultModelList { get; set; }

    }
}
