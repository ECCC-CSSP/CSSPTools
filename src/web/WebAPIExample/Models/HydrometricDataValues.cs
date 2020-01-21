using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class HydrometricDataValues
    {
        [Key]
        public int HydrometricDataValueID { get; set; }
        public int HydrometricSiteID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime_Local { get; set; }
        public bool Keep { get; set; }
        public int StorageDataType { get; set; }
        public bool HasBeenRead { get; set; }
        public double? Discharge_m3_s { get; set; }
        public double? DischargeEntered_m3_s { get; set; }
        public double? Level_m { get; set; }
        [Column(TypeName = "text")]
        public string HourlyValues { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(HydrometricSiteID))]
        [InverseProperty(nameof(HydrometricSites.HydrometricDataValues))]
        public virtual HydrometricSites HydrometricSite { get; set; }
    }
}
