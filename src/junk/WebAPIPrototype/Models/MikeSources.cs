using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class MikeSources
    {
        public MikeSources()
        {
            MikeSourceStartEnds = new HashSet<MikeSourceStartEnds>();
        }

        public int MikeSourceID { get; set; }
        public int MikeSourceTVItemID { get; set; }
        public bool IsContinuous { get; set; }
        public bool Include { get; set; }
        public bool IsRiver { get; set; }
        public bool UseHydrometric { get; set; }
        public int? HydrometricTVItemID { get; set; }
        public double? DrainageArea_km2 { get; set; }
        public double? Factor { get; set; }
        public string SourceNumberString { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems HydrometricTVItem { get; set; }
        public virtual TVItems MikeSourceTVItem { get; set; }
        public virtual ICollection<MikeSourceStartEnds> MikeSourceStartEnds { get; set; }
    }
}
