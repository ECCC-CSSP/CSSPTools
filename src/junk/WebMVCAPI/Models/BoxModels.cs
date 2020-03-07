using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class BoxModels
    {
        public BoxModels()
        {
            BoxModelLanguages = new HashSet<BoxModelLanguages>();
            BoxModelResults = new HashSet<BoxModelResults>();
        }

        public int BoxModelID { get; set; }
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
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems InfrastructureTVItem { get; set; }
        public virtual ICollection<BoxModelLanguages> BoxModelLanguages { get; set; }
        public virtual ICollection<BoxModelResults> BoxModelResults { get; set; }
    }
}
