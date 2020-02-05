using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class MWQMSubsectors
    {
        public MWQMSubsectors()
        {
            MWQMSubsectorLanguages = new HashSet<MWQMSubsectorLanguages>();
        }

        public int MWQMSubsectorID { get; set; }
        public int MWQMSubsectorTVItemID { get; set; }
        public string SubsectorHistoricKey { get; set; }
        public string TideLocationSIDText { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems MWQMSubsectorTVItem { get; set; }
        public virtual ICollection<MWQMSubsectorLanguages> MWQMSubsectorLanguages { get; set; }
    }
}
