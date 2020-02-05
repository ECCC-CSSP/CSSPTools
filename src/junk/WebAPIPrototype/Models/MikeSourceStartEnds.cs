using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class MikeSourceStartEnds
    {
        public int MikeSourceStartEndID { get; set; }
        public int MikeSourceID { get; set; }
        public DateTime StartDateAndTime_Local { get; set; }
        public DateTime EndDateAndTime_Local { get; set; }
        public double SourceFlowStart_m3_day { get; set; }
        public double SourceFlowEnd_m3_day { get; set; }
        public int SourcePollutionStart_MPN_100ml { get; set; }
        public int SourcePollutionEnd_MPN_100ml { get; set; }
        public double SourceTemperatureStart_C { get; set; }
        public double SourceTemperatureEnd_C { get; set; }
        public double SourceSalinityStart_PSU { get; set; }
        public double SourceSalinityEnd_PSU { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual MikeSources MikeSource { get; set; }
    }
}
