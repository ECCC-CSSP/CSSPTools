using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MapInfoPoints
    {
        [Key]
        public int MapInfoPointID { get; set; }
        public int MapInfoID { get; set; }
        public int Ordinal { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(MapInfoID))]
        [InverseProperty(nameof(MapInfos.MapInfoPoints))]
        public virtual MapInfos MapInfo { get; set; }
    }
}
