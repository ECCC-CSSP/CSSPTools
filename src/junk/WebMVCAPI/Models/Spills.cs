using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class Spills
    {
        public Spills()
        {
            SpillLanguages = new HashSet<SpillLanguages>();
        }

        public int SpillID { get; set; }
        public int MunicipalityTVItemID { get; set; }
        public int? InfrastructureTVItemID { get; set; }
        public DateTime StartDateTime_Local { get; set; }
        public DateTime? EndDateTime_Local { get; set; }
        public double AverageFlow_m3_day { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems InfrastructureTVItem { get; set; }
        public virtual TVItems MunicipalityTVItem { get; set; }
        public virtual ICollection<SpillLanguages> SpillLanguages { get; set; }
    }
}
