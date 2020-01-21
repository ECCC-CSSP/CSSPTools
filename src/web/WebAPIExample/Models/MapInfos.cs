using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MapInfos
    {
        public MapInfos()
        {
            MapInfoPoints = new HashSet<MapInfoPoints>();
        }

        [Key]
        public int MapInfoID { get; set; }
        public int TVItemID { get; set; }
        public int TVType { get; set; }
        public double LatMin { get; set; }
        public double LatMax { get; set; }
        public double LngMin { get; set; }
        public double LngMax { get; set; }
        public int MapInfoDrawType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(TVItemID))]
        [InverseProperty(nameof(TVItems.MapInfos))]
        public virtual TVItems TVItem { get; set; }
        [InverseProperty("MapInfo")]
        public virtual ICollection<MapInfoPoints> MapInfoPoints { get; set; }
    }
}
